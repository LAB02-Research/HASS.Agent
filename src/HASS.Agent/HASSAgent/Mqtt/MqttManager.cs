using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HASSAgent.Enums;
using HASSAgent.Functions;
using HASSAgent.Models.HomeAssistant;
using HASSAgent.Models.HomeAssistant.Commands;
using HASSAgent.Sensors;
using MQTTnet;
using MQTTnet.Adapter;
using MQTTnet.Client;
using MQTTnet.Client.Disconnecting;
using MQTTnet.Client.Options;
using MQTTnet.Exceptions;
using MQTTnet.Extensions.ManagedClient;
using Serilog;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace HASSAgent.Mqtt
{
    /// <summary>
    /// Handles publishing and processing HASS entities (commands and sensors) through MQTT
    /// </summary>
    internal static class MqttManager
    {
        private static IManagedMqttClient _mqttClient = null;

        private static bool _disconnectionNotified = false;
        private static bool _connectingFailureNotified = false;

        internal static DateTime LastConfigAnnounce { get; private set; }
        internal static DateTime LastAvailabilityAnnounce { get; private set; }

        private static MqttStatus _status = MqttStatus.Connecting;
        internal static bool IsConnected => _mqttClient != null && _mqttClient.IsConnected;

        /// <summary>
        /// Initialize the MQTT manager, establish a connection
        /// </summary>
        internal static void Initialize()
        {
            try
            {
                // create our device's config model
                if (Variables.DeviceConfig == null) CreateDeviceConfigModel();
            
                // create a new mqtt client
                _mqttClient = Variables.MqttFactory.CreateManagedMqttClient();

                // bind 'connected' handler 
                _mqttClient.UseConnectedHandler(e =>
                {
                    _status = MqttStatus.Connected;
                    Variables.MainForm?.SetMqttStatus(ComponentStatus.Ok);
                    Log.Information("[MQTT] Connected");

                    // reset error notifications 
                    _disconnectionNotified = false;
                    _connectingFailureNotified = false;
                });

                // bind 'connecting failed' handler
                _mqttClient.ConnectingFailedHandler = new ConnectingFailedHandlerDelegate(ConnectingFailedHandler);

                // bind 'messager received' handler
                _mqttClient.UseApplicationMessageReceivedHandler(e => HandleMessageReceived(e.ApplicationMessage));

                // bind 'disconnected' handler
                _mqttClient.DisconnectedHandler = new MqttClientDisconnectedHandlerDelegate(DisconnectedHandler);

                // get the mqtt options
                var options = GetOptions();

                // only start connecting if they're found
                if (options == null)
                {
                    _status = MqttStatus.ConfigMissing;
                    Variables.MainForm?.SetMqttStatus(ComponentStatus.Stopped);
                    Log.Warning("[MQTT] Configuration missing");
                    return;
                }

                Log.Information("[MQTT] Connecting ..");
                Variables.MainForm?.SetMqttStatus(ComponentStatus.Loading);
                StartClient(options);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[MQTT] Error while initializing: {err}", ex.Message);

                _status = MqttStatus.Error;
                Variables.MainForm?.SetMqttStatus(ComponentStatus.Failed);
                Variables.MainForm?.ShowToolTip("mqtt: error while connecting", true);
            }
        }

        /// <summary>
        /// Start and register a MQTT client with the provided options
        /// </summary>
        /// <param name="options"></param>
        private static async void StartClient(IManagedMqttClientOptions options)
        {
            if (_mqttClient == null) return;

            try
            {
                // start the client
                await _mqttClient.StartAsync(options);

                // perform initial registration
                InitialRegistration();
            }
            catch (MqttConnectingFailedException ex)
            {
                Log.Error("[MQTT] Unable to connect to broker: {msg}", ex.Result.ToString());
            }
            catch (MqttCommunicationException ex)
            {
                Log.Error("[MQTT] Unable to communicate with broker: {msg}", ex.Message);
            }
            catch (Exception ex)
            {
                Log.Error("[MQTT] Exception while connecting with broker: {msg}", ex.ToString());
            }
        }

        /// <summary>
        /// Fires when connecting to the broker failed
        /// </summary>
        private static async void ConnectingFailedHandler(ManagedProcessFailedEventArgs ex)
        {
            // set state to loading
            Variables.MainForm?.SetMqttStatus(ComponentStatus.Connecting);

            // give the connection the grace period to recover
            var runningTimer = Stopwatch.StartNew();
            while (runningTimer.Elapsed.TotalSeconds < Variables.AppSettings.DisconnectedGracePeriodSeconds)
            {
                if (_mqttClient.IsConnected)
                {
                    // recoved, nevermind
                    Variables.MainForm?.SetMqttStatus(ComponentStatus.Ok);
                    return;
                }

                await Task.Delay(TimeSpan.FromSeconds(5));
            }

            // nope, call it
            _status = MqttStatus.Error;
            Variables.MainForm?.SetMqttStatus(ComponentStatus.Failed);

            // log only once
            if (_connectingFailureNotified) return;
            _connectingFailureNotified = true;

            Log.Fatal(ex.Exception, "[MQTT] Error while connecting: {err}", ex.Exception.Message);

            Variables.MainForm?.ShowToolTip("mqtt: failed to connect", true);
        }

        /// <summary>
        /// Fires when the client gets disconnected from the broker
        /// </summary>
        /// <param name="e"></param>
        private static async void DisconnectedHandler(MqttClientDisconnectedEventArgs e)
        {
            // set state to loading
            Variables.MainForm?.SetMqttStatus(ComponentStatus.Connecting);

            // give the connection the grace period to recover
            var runningTimer = Stopwatch.StartNew();
            while (runningTimer.Elapsed.TotalSeconds < Variables.AppSettings.DisconnectedGracePeriodSeconds)
            {
                if (_mqttClient.IsConnected)
                {
                    // recoved, nevermind
                    Variables.MainForm?.SetMqttStatus(ComponentStatus.Ok);
                    return;
                }

                await Task.Delay(TimeSpan.FromSeconds(5));
            }

            // nope, call it
            _status = MqttStatus.Disconnected;
            Variables.MainForm?.SetMqttStatus(ComponentStatus.Stopped);

            // log if we're not shutting down
            if (Variables.ShuttingDown) return;

            // only once
            if (_disconnectionNotified) return;
            _disconnectionNotified = true;

            Variables.MainForm?.ShowToolTip("mqtt: disconnected", true);
            Log.Warning("[MQTT] Disconnected: {reason}", e.Reason.ToString());
        }

        /// <summary>
        /// Announce our availability
        /// <para>Deprecated: used to announce sensors/commands, now left to their managers</para>
        /// </summary>
        private static async void InitialRegistration()
        {
            if (_mqttClient == null) return;
            while (!_mqttClient.IsConnected) await Task.Delay(2000);

            // let HA know we're here
            await AnnounceAvailabilityAsync();

            // done
            Log.Information("[MQTT] Initial registration completed");

            // rest is deprecated: the sensor & command managers can do it themselves, lazy bastards

            //var errorsFound = false;
            //try
            //{
            //    // we're making temp copies of all lists, to prevent 'collection has been changed' if the user's very
            //    // enthousiastic in adding/modding directly after launch

            //    // register commands
            //    var currentCommands = Variables.Commands.Select(x => x).ToArray();
            //    foreach (var command in currentCommands)
            //    {
            //        // check if it's still there
            //        if (Variables.Commands.All(x => x.Id != command.Id)) continue;

            //        // publish
            //        await SubscribeAsync(command);
            //        await command.PublishStateAsync(false);
            //    }

            //    // register single-value sensors
            //    var currentSensors = Variables.SingleValueSensors.Select(x => x).ToArray();
            //    foreach (var sensor in currentSensors)
            //    {
            //        // check if it's still there
            //        if (Variables.SingleValueSensors.All(x => x.Id != sensor.Id)) continue;

            //        // publish
            //        await sensor.PublishStateAsync(false);
            //    }

            //    // register multi-value sensors
            //    var currentMultivalueSensors = Variables.MultiValueSensors.Select(x => x).ToArray();
            //    foreach (var mvSensor in currentMultivalueSensors)
            //    {
            //        // check if it's still there
            //        if (Variables.MultiValueSensors.All(x => x.Id != mvSensor.Id)) continue;

            //        // start publishing sensors
            //        currentSensors = mvSensor.Sensors.Select(x => x.Value).ToArray();
            //        foreach (var sensor in currentSensors)
            //        {
            //            // check if it's still there (including parent multivalue sensor)
            //            if (Variables.MultiValueSensors.All(x => x.Id != mvSensor.Id)) break;
            //            if (mvSensor.Sensors.All(x => x.Value.Id != sensor.Id)) continue;

            //            // publish
            //            await sensor.PublishStateAsync(false);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Log.Fatal(ex, "[MQTT] Error while processing entity registration: {err}", ex.Message);
            //    errorsFound = true;
            //}
        }
        
        /// <summary>
        /// Prepares info for the device we're running on
        /// </summary>
        internal static void CreateDeviceConfigModel()
        {
            var name = HelperFunctions.GetConfiguredDeviceName();
            Log.Information("[MQTT] Identifying as device: {name}", name);

            Variables.DeviceConfig = new DeviceConfigModel
            {
                Name = name,
                Identifiers = "hass.agent-" + name,
                Manufacturer = "LAB02 Research",
                Model = Environment.OSVersion.ToString(),
                Sw_version = Variables.Version
            };
        }

        /// <summary>
        /// Publishes the provided message
        /// </summary>
        private static DateTime _lastPublishFailedLogged = DateTime.MinValue;
        internal static async Task PublishAsync(MqttApplicationMessage message)
        {
            if (_mqttClient.IsConnected) await _mqttClient.PublishAsync(message);
            else
            {
                // only log failures once every 5 minutes to minimize log growth
                if ((DateTime.Now - _lastPublishFailedLogged).TotalMinutes < 5) return;
                _lastPublishFailedLogged = DateTime.Now;

                Log.Warning("[MQTT] Not connected, message dropped (won't report again for 5 minutes)");
            }
        }

        /// <summary>
        /// Publish the provided autodiscovery config
        /// </summary>
        /// <param name="discoverable"></param>
        /// <param name="domain"></param>
        /// <param name="clearConfig"></param>
        /// <returns></returns>
        public static async Task AnnounceAutoDiscoveryConfigAsync(AbstractDiscoverable discoverable, string domain, bool clearConfig = false)
        {
            if (_mqttClient == null) return;
            if (!_mqttClient.IsConnected) return;

            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = new CamelCaseJsonNamingpolicy(),
                    IgnoreNullValues = true,
                    PropertyNameCaseInsensitive = true,
                };

                // prepare prefix
                if (string.IsNullOrEmpty(Variables.AppSettings.MqttDiscoveryPrefix)) Variables.AppSettings.MqttDiscoveryPrefix = "homeassistant";

                // prepare topic
                var topic = $"{Variables.AppSettings.MqttDiscoveryPrefix}/{domain}/{Variables.DeviceConfig.Name}/{discoverable.ObjectId}/config";
                
                // build config message
                var messageBuilder = new MqttApplicationMessageBuilder()
                    .WithTopic(topic);

                // set retain flag
                if (Variables.AppSettings.MqttUseRetainFlag) messageBuilder.WithRetainFlag();

                // add payload
                if (clearConfig) messageBuilder.WithPayload(Array.Empty<byte>());
                else messageBuilder.WithPayload(JsonSerializer.Serialize(discoverable.GetAutoDiscoveryConfig(), discoverable.GetAutoDiscoveryConfig().GetType(), options));

                // publish disco config
                await PublishAsync(messageBuilder.Build());
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[MQTT] Error while announcing autodiscovery: {err}", ex.Message);
            }

            LastConfigAnnounce = DateTime.Now;
        }

        /// <summary>
        /// Returns the status of the MQTT manager
        /// </summary>
        /// <returns></returns>
        internal static MqttStatus GetStatus()
        {
            return _status;
        }

        /// <summary>
        /// Announce our availability
        /// </summary>
        private static DateTime _lastAvailableAnnouncement = DateTime.MinValue;
        private static DateTime _lastAvailableAnnouncementFailedLogged = DateTime.MinValue;
        internal static async Task AnnounceAvailabilityAsync(bool offline = false)
        {
            if (_mqttClient == null) return;
            if (!_mqttClient.IsConnected) return;

            try
            {
                // offline msgs always need to be sent, the rest once every 30 secs
                if (!offline)
                {
                    if ((DateTime.Now - _lastAvailableAnnouncement).TotalSeconds < 30) return;
                    _lastAvailableAnnouncement = DateTime.Now;
                }

                if (_mqttClient.IsConnected)
                {
                    if (string.IsNullOrEmpty(Variables.AppSettings.MqttDiscoveryPrefix)) Variables.AppSettings.MqttDiscoveryPrefix = "homeassistant";

                    // prepare message
                    var messageBuilder = new MqttApplicationMessageBuilder()
                        .WithTopic($"{Variables.AppSettings.MqttDiscoveryPrefix}/sensor/{Variables.DeviceConfig.Name}/availability")
                        .WithPayload(offline ? "offline" : "online");

                    // set retain flag
                    if (Variables.AppSettings.MqttUseRetainFlag) messageBuilder.WithRetainFlag();

                    // publish
                    await _mqttClient.PublishAsync(messageBuilder.Build());

                    LastAvailabilityAnnounce = DateTime.Now;
                }
                else
                {
                    // only log failures once every 5 minutes to minimize log growth
                    if ((DateTime.Now - _lastAvailableAnnouncementFailedLogged).TotalMinutes < 5) return;
                    _lastAvailableAnnouncementFailedLogged = DateTime.Now;

                    Log.Warning("[MQTT] Not connected, availability announcement dropped");
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[MQTT] Error while announcing availability: {err}", ex.Message);
            }
        }

        /// <summary>
        /// CLears the device config, removing the retained message
        /// </summary>
        /// <returns></returns>
        internal static async Task ClearDeviceConfig()
        {
            if (_mqttClient == null || !_mqttClient.IsConnected)
            {
                Log.Warning("[MQTT] Not connected, clearing device config failed");
                return;
            }

            try
            {
                if (_mqttClient.IsConnected)
                {
                    if (string.IsNullOrEmpty(Variables.AppSettings.MqttDiscoveryPrefix)) Variables.AppSettings.MqttDiscoveryPrefix = "homeassistant";

                    // prepare message
                    var messageBuilder = new MqttApplicationMessageBuilder()
                        .WithTopic($"{Variables.AppSettings.MqttDiscoveryPrefix}/sensor/{Variables.DeviceConfig.Name}/availability")
                        .WithPayload(Array.Empty<byte>());

                    // set retain flag
                    if (Variables.AppSettings.MqttUseRetainFlag) messageBuilder.WithRetainFlag();
                    
                    // publish
                    await _mqttClient.PublishAsync(messageBuilder.Build());
                }
                else Log.Warning("[MQTT] Not connected, clearing device config failed");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[MQTT] Error while clearing device config: {err}", ex.Message);
            }
        }

        /// <summary>
        /// Disconnect from the broker (if connected)
        /// </summary>
        internal static void Disconnect()
        {
            if (_mqttClient == null) return;
            if (_mqttClient.IsConnected)
            {
                _mqttClient.InternalClient.DisconnectAsync();
                _mqttClient.Dispose();
            }

            Log.Information("[MQTT] Disconnected");
        }

        /// <summary>
        /// Subscribe to the provided command's topic
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        internal static async Task SubscribeAsync(AbstractCommand command)
        {
            if (_mqttClient == null) return;
            if (IsConnected) await _mqttClient.SubscribeAsync(((CommandDiscoveryConfigModel)command.GetAutoDiscoveryConfig()).Command_topic);
            else
            {
                while (IsConnected == false) await Task.Delay(250);
                await _mqttClient.SubscribeAsync(((CommandDiscoveryConfigModel)command.GetAutoDiscoveryConfig()).Command_topic);
            }
        }

        /// <summary>
        /// Unsubscribe from the provided command's topic
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        internal static async Task UnubscribeAsync(AbstractCommand command)
        {
            if (_mqttClient == null) return;
            if (IsConnected) await _mqttClient.UnsubscribeAsync(((CommandDiscoveryConfigModel)command.GetAutoDiscoveryConfig()).Command_topic);
            else
            {
                while (IsConnected == false) await Task.Delay(250);
                await _mqttClient.UnsubscribeAsync(((CommandDiscoveryConfigModel)command.GetAutoDiscoveryConfig()).Command_topic);
            }
        }

        /// <summary>
        /// Prepare the required settings for a MQTT client
        /// </summary>
        /// <returns></returns>
        private static ManagedMqttClientOptions GetOptions()
        {
            if (string.IsNullOrEmpty(Variables.AppSettings.MqttAddress)) return null;
            
            // id can be random
            var clientId = Guid.NewGuid().ToString().Substring(0, 8);

            // configure last will message
            // todo: cover other domains
            var lastWillMessageBuilder = new MqttApplicationMessageBuilder()
                .WithTopic($"{Variables.AppSettings.MqttDiscoveryPrefix}/sensor/{Variables.DeviceConfig.Name}/availability")
                .WithPayload("offline");

            // set retain flag
            if (Variables.AppSettings.MqttUseRetainFlag) lastWillMessageBuilder.WithRetainFlag();

            // prepare message
            var lastWillMessage = lastWillMessageBuilder.Build();

            // basic options
            var clientOptionsBuilder = new MqttClientOptionsBuilder()
                .WithClientId(clientId)
                .WithTcpServer(Variables.AppSettings.MqttAddress, Variables.AppSettings.MqttPort)
                .WithCleanSession()
                .WithWillMessage(lastWillMessage)
                .WithKeepAlivePeriod(TimeSpan.FromSeconds(15));

            // optional credentials
            if (!string.IsNullOrEmpty(Variables.AppSettings.MqttUsername)) clientOptionsBuilder.WithCredentials(Variables.AppSettings.MqttUsername, Variables.AppSettings.MqttPassword);

            // configure tls
            var tlsParameters = new MqttClientOptionsBuilderTlsParameters()
            {
                UseTls = Variables.AppSettings.MqttUseTls,
                AllowUntrustedCertificates = Variables.AppSettings.MqttAllowUntrustedCertificates,
                SslProtocol = Variables.AppSettings.MqttUseTls ? System.Security.Authentication.SslProtocols.Tls12 : System.Security.Authentication.SslProtocols.None
            };

            // configure certificates
            var certificates = new List<X509Certificate>();
            if (!string.IsNullOrEmpty(Variables.AppSettings.MqttRootCertificate))
            {
                if (!File.Exists(Variables.AppSettings.MqttRootCertificate)) Log.Error("[MQTT] Provided root certificate not found: {cert}", Variables.AppSettings.MqttRootCertificate);
                else certificates.Add(new X509Certificate2(Variables.AppSettings.MqttRootCertificate));
            }

            if (!string.IsNullOrEmpty(Variables.AppSettings.MqttClientCertificate))
            {
                if (!File.Exists(Variables.AppSettings.MqttClientCertificate)) Log.Error("[MQTT] Provided client certificate not found: {cert}", Variables.AppSettings.MqttClientCertificate);
                certificates.Add(new X509Certificate2(Variables.AppSettings.MqttClientCertificate));
            }

            if (certificates.Count > 0) tlsParameters.Certificates = certificates;
            clientOptionsBuilder.WithTls(tlsParameters);

            // build the client options
            clientOptionsBuilder.Build();

            // build and return the mqtt options
            return new ManagedMqttClientOptionsBuilder()
                .WithAutoReconnectDelay(TimeSpan.FromSeconds(5))
                .WithClientOptions(clientOptionsBuilder).Build();
        }
        
        /// <summary>
        /// Handle incoming messages
        /// </summary>
        /// <param name="applicationMessage"></param>
        private static void HandleMessageReceived(MqttApplicationMessage applicationMessage)
        {
            if (!Variables.Commands.Any()) return;
            foreach (var command in Variables.Commands)
            {
                if (((CommandDiscoveryConfigModel)command.GetAutoDiscoveryConfig()).Command_topic != applicationMessage.Topic) continue;

                switch (Encoding.UTF8.GetString(applicationMessage?.Payload))
                {
                    case "ON":
                        command.TurnOn();
                        break;
                    case "OFF":
                        command.TurnOff();
                        break;
                }
            }
        }
    }
}
