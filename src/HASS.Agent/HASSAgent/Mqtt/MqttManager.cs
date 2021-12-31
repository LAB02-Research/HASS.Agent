using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using HASSAgent.Enums;
using HASSAgent.Functions;
using HASSAgent.Models.HomeAssistant;
using HASSAgent.Models.HomeAssistant.Commands;
using MQTTnet;
using MQTTnet.Adapter;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using MQTTnet.Exceptions;
using MQTTnet.Extensions.ManagedClient;
using Newtonsoft.Json;
using Serilog;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace HASSAgent.Mqtt
{
    /// <summary>
    /// Handles publishing and processing HASS entities (commands and sensors) through MQTT
    /// </summary>
    internal static class MqttManager
    {
        private static IManagedMqttClient _mqttClient;

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
                _mqttClient.UseDisconnectedHandler(e =>
                {
                    _status = MqttStatus.Disconnected;
                    Variables.MainForm?.SetMqttStatus(ComponentStatus.Stopped);

                    // log if we're not shutting down
                    if (Variables.ShuttingDown) return;

                    // only once
                    if (_disconnectionNotified) return;
                    _disconnectionNotified = true;

                    Variables.MainForm?.ShowToolTip("mqtt: disconnected", true);
                    Log.Warning("[MQTT] Disconnected: {reason}", e.Reason.ToString());
                });

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
        private static void ConnectingFailedHandler(ManagedProcessFailedEventArgs ex)
        {
            _status = MqttStatus.Error;
            Variables.MainForm?.SetMqttStatus(ComponentStatus.Failed);

            // log only once
            if (_connectingFailureNotified) return;
            _connectingFailureNotified = true;

            Log.Fatal(ex.Exception, "[MQTT] Error while connecting: {err}", ex.Exception.Message);

            Variables.MainForm?.ShowToolTip("mqtt: failed to connect", true);
        }

        /// <summary>
        /// Registers stored commands and sensors
        /// </summary>
        private static async void InitialRegistration()
        {
            while (!_mqttClient.IsConnected) await Task.Delay(2000);

            // register commands
            foreach (var command in Variables.Commands)
            {
                await SubscribeAsync(command);
                await command.PublishStateAsync(false);
            }

            // register sensors
            foreach (var sensor in Variables.SingleValueSensors)
            {
                await sensor.PublishStateAsync(false);
            }

            // let hass know we're here
            await AnnounceAvailabilityAsync();

            // done
            Log.Information("[MQTT] Initial registration completed");
        }
        
        /// <summary>
        /// Prepares info for the device we're running on
        /// </summary>
        private static void CreateDeviceConfigModel()
        {
            Variables.DeviceConfig = new DeviceConfigModel
            {
                Name = Environment.MachineName,
                Identifiers = "hass.agent-" + Environment.MachineName,
                Manufacturer = Environment.UserName,
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
                var diff = DateTime.Now - _lastPublishFailedLogged;
                if (diff.TotalMinutes < 5) return;

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
            if (!_mqttClient.IsConnected) return;

            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = new CamelCaseJsonNamingpolicy(),
                    IgnoreNullValues = true,
                    PropertyNameCaseInsensitive = true,
                };

                var topic = string.IsNullOrEmpty(discoverable.TopicName)
                    ? $"homeassistant/{domain}/{Variables.DeviceConfig.Name}/{discoverable.ObjectId}/config"
                    : $"homeassistant/{domain}/{Variables.DeviceConfig.Name}/{discoverable.TopicName}/{discoverable.ObjectId}/config";
                
                var message = new MqttApplicationMessageBuilder()
                    .WithTopic(topic)
                    .WithPayload(clearConfig ? "" : JsonSerializer.Serialize(discoverable.GetAutoDiscoveryConfig(), discoverable.GetAutoDiscoveryConfig().GetType(), options))
                    .WithRetainFlag()
                    .Build();

                await PublishAsync(message);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[MQTT] Error while announcing autodiscovery: {err}", ex.Message);
            }

            LastConfigAnnounce = DateTime.UtcNow;
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
            // offline msgs always need to be sent, the rest once every 30 secs
            if (!offline)
            {
                var diff = DateTime.Now - _lastAvailableAnnouncement;
                if (diff.TotalSeconds < 30) return;

                _lastAvailableAnnouncement = DateTime.Now;
            }

            if (_mqttClient.IsConnected)
            {
                await _mqttClient.PublishAsync(
                    new MqttApplicationMessageBuilder()
                        .WithTopic($"homeassistant/sensor/{Variables.DeviceConfig.Name}/availability")
                        .WithPayload(offline ? "offline" : "online")
                        .Build()
                );

                LastAvailabilityAnnounce = DateTime.UtcNow;
            }
            else
            {
                // only log failures once every 5 minutes to minimize log growth
                var diff = DateTime.Now - _lastAvailableAnnouncementFailedLogged;
                if (diff.TotalMinutes < 5) return;

                _lastAvailableAnnouncementFailedLogged = DateTime.Now;
                Log.Warning("[MQTT] Not connected, availability announcement dropped");
            }
        }

        /// <summary>
        /// Disconnect from the broker (if connected)
        /// </summary>
        internal static void Disconnect()
        {
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
            if (IsConnected) await _mqttClient.SubscribeAsync(((CommandDiscoveryConfigModel)command.GetAutoDiscoveryConfig()).Command_topic);
            else
            {
                while (IsConnected == false) await Task.Delay(5500);
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
            if (IsConnected) await _mqttClient.UnsubscribeAsync(((CommandDiscoveryConfigModel)command.GetAutoDiscoveryConfig()).Command_topic);
            else
            {
                while (IsConnected == false) await Task.Delay(5500);
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
            
            // basic options
            var clientOptionsBuilder = new MqttClientOptionsBuilder()
                .WithClientId(clientId)
                .WithTcpServer(Variables.AppSettings.MqttAddress, Variables.AppSettings.MqttPort)
                .WithCleanSession()
                .WithKeepAlivePeriod(TimeSpan.FromSeconds(15));

            // optional credentials
            if (!string.IsNullOrEmpty(Variables.AppSettings.MqttUsername)) clientOptionsBuilder.WithCredentials(Variables.AppSettings.MqttUsername, Variables.AppSettings.MqttPassword);

            // optional tls
            if (Variables.AppSettings.MqttUseTls) clientOptionsBuilder.WithTls();

            // build the client options
            clientOptionsBuilder.Build();

            // build and return the mqtt options
            return new ManagedMqttClientOptionsBuilder()
                .WithAutoReconnectDelay(TimeSpan.FromSeconds(5))
                .WithClientOptions(clientOptionsBuilder).Build();
        }

        /// <summary>
        /// Deprecated - Reload new settings (and build a new client)
        /// </summary>
        /// <returns></returns>
        internal static async Task ReloadMqttSettingsAsync()
        {
            Log.Information("[MQTT] Reloading config");
            
            // stop our client
            await _mqttClient.StopAsync();

            // get new options
            var options = GetOptions();

            if (options == null)
            {
                Log.Warning("[MQTT] Configuration missing, unable to reconnect");
                return;
            }

            // restart the client
            StartClient(options);
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
