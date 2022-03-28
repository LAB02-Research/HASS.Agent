using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using HASS.Agent.Enums;
using HASS.Agent.Functions;
using HASS.Agent.Settings;
using HASS.Agent.Shared.Enums;
using HASS.Agent.Shared.Models.HomeAssistant;
using HASS.Agent.Shared.Models.HomeAssistant.Commands;
using HASS.Agent.Shared.Mqtt;
using MQTTnet;
using MQTTnet.Adapter;
using MQTTnet.Client;
using MQTTnet.Client.Disconnecting;
using MQTTnet.Client.Options;
using MQTTnet.Exceptions;
using MQTTnet.Extensions.ManagedClient;
using Serilog;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace HASS.Agent.MQTT
{
    /// <summary>
    /// Handles publishing and processing HASS entities (commands and sensors) through MQTT
    /// </summary>
    public class MqttManager : IMqttManager
    {
        private IManagedMqttClient _mqttClient = null;

        private bool _disconnectionNotified = false;
        private bool _connectingFailureNotified = false;
        
        private MqttStatus _status = MqttStatus.Connecting;

        /// <summary>
        /// Returns whether the client is connected
        /// </summary>
        public bool IsConnected() => _mqttClient is { IsConnected: true };

        /// <summary>
        /// Returns the default or configured discovery prefix
        /// </summary>
        /// <returns></returns>
        public string MqttDiscoveryPrefix() => Variables.AppSettings?.MqttDiscoveryPrefix ?? "homeassistant";

        /// <summary>
        /// Returns the device's config model
        /// </summary>
        /// <returns></returns>
        public DeviceConfigModel GetDeviceConfigModel() => Variables.DeviceConfig;

        /// <summary>
        /// Initialize the MQTT manager, establish a connection
        /// </summary>
        public void Initialize()
        {
            try
            {
                // create our device's config model
                if (Variables.DeviceConfig == null) CreateDeviceConfigModel();
            
                // create a new mqtt client
                _mqttClient = Variables.MqttFactory.CreateManagedMqttClient();

                // bind 'connected' handler 
                _mqttClient.UseConnectedHandler(_ =>
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
        /// Creates a new MQTT client, using the current configuration
        /// </summary>
        public async void ReloadConfiguration()
        {
            try
            {
                Log.Information("[MQTT] Reloading configuration ..");

                // already connected?
                if (_mqttClient != null)
                {
                    // stop the connection
                    await _mqttClient.StopAsync();

                    // dispose our current client
                    _mqttClient.Dispose();
                    _mqttClient = null;
                }

                // clear our device config
                Variables.DeviceConfig = null;

                // reset state
                _status = MqttStatus.Connecting;
                Variables.MainForm?.SetMqttStatus(ComponentStatus.Connecting);
                _disconnectionNotified = false;
                _connectingFailureNotified = false;

                Log.Information("[MQTT] Initializing ..");

                // simple re-run initialization
                Initialize();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[MQTT] Error while reloading configuration: {err}", ex.Message);
                _status = MqttStatus.Error;
            }
        }

        /// <summary>
        /// Start and register a MQTT client with the provided options
        /// </summary>
        /// <param name="options"></param>
        private async void StartClient(IManagedMqttClientOptions options)
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
        private async void ConnectingFailedHandler(ManagedProcessFailedEventArgs ex)
        {
            // set state to loading
            Variables.MainForm?.SetMqttStatus(ComponentStatus.Connecting);

            // give the connection the grace period to recover
            var runningTimer = Stopwatch.StartNew();
            while (runningTimer.Elapsed.TotalSeconds < Variables.AppSettings.DisconnectedGracePeriodSeconds)
            {
                if (_mqttClient.IsConnected)
                {
                    // recovered, nevermind
                    if (_status == MqttStatus.Connected) return;
                    _status = MqttStatus.Connected;
                    Variables.MainForm?.SetMqttStatus(ComponentStatus.Ok);

                    Log.Information("[MQTT] Connected");
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

            var excMsg = ex.Exception.ToString();
            if (excMsg.Contains("SocketException")) Log.Error("[MQTT] Error while connecting: {err}", ex.Exception.Message);
            else if (excMsg.Contains("MqttCommunicationTimedOutException")) Log.Error("[MQTT] Error while connecting: {err}", "Connection timed out");
            else Log.Fatal(ex.Exception, "[MQTT] Error while connecting: {err}", ex.Exception.Message);

            Variables.MainForm?.ShowToolTip("mqtt: failed to connect", true);
        }

        /// <summary>
        /// Fires when the client gets disconnected from the broker
        /// </summary>
        /// <param name="e"></param>
        private async void DisconnectedHandler(MqttClientDisconnectedEventArgs e)
        {
            // set state to loading
            Variables.MainForm?.SetMqttStatus(ComponentStatus.Connecting);

            // give the connection the grace period to recover
            var runningTimer = Stopwatch.StartNew();
            while (runningTimer.Elapsed.TotalSeconds < Variables.AppSettings.DisconnectedGracePeriodSeconds)
            {
                if (_mqttClient.IsConnected)
                {
                    // recovered, nevermind
                    if (_status == MqttStatus.Connected) return;
                    _status = MqttStatus.Connected;
                    Variables.MainForm?.SetMqttStatus(ComponentStatus.Ok);

                    Log.Information("[MQTT] Connected");
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
        private async void InitialRegistration()
        {
            if (_mqttClient == null) return;
            while (!_mqttClient.IsConnected) await Task.Delay(2000);

            // let HA know we're here
            await AnnounceAvailabilityAsync();

            // done
            Log.Information("[MQTT] Initial registration completed");
        }

        /// <summary>
        /// Prepares info for the device we're running on
        /// </summary>
        public void CreateDeviceConfigModel()
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
        private DateTime _lastPublishFailedLogged = DateTime.MinValue;
        public async Task PublishAsync(MqttApplicationMessage message)
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
        public async Task AnnounceAutoDiscoveryConfigAsync(AbstractDiscoverable discoverable, string domain, bool clearConfig = false)
        {
            if (_mqttClient is not { IsConnected: true }) return;

            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = new CamelCaseJsonNamingpolicy(),
                    PropertyNameCaseInsensitive = true,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
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
        }

        /// <summary>
        /// Returns the status of the MQTT manager
        /// </summary>
        /// <returns></returns>
        public MqttStatus GetStatus() => _status;

        /// <summary>
        /// Announce our availability
        /// </summary>
        private DateTime _lastAvailableAnnouncement = DateTime.MinValue;
        private DateTime _lastAvailableAnnouncementFailedLogged = DateTime.MinValue;
        public async Task AnnounceAvailabilityAsync(bool offline = false)
        {
            if (_mqttClient is not { IsConnected: true }) return;

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
        public async Task ClearDeviceConfigAsync()
        {
            if (_mqttClient is not { IsConnected: true })
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
        public void Disconnect()
        {
            if (_mqttClient is { IsConnected: true })
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
        public async Task SubscribeAsync(AbstractCommand command)
        {
            if (IsConnected()) await _mqttClient.SubscribeAsync(((CommandDiscoveryConfigModel)command.GetAutoDiscoveryConfig()).Command_topic);
            else
            {
                while (IsConnected() == false) await Task.Delay(250);
                await _mqttClient.SubscribeAsync(((CommandDiscoveryConfigModel)command.GetAutoDiscoveryConfig()).Command_topic);
            }
        }

        /// <summary>
        /// Unsubscribe from the provided command's topic
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task UnubscribeAsync(AbstractCommand command)
        {
            if (IsConnected()) await _mqttClient.UnsubscribeAsync(((CommandDiscoveryConfigModel)command.GetAutoDiscoveryConfig()).Command_topic);
            else
            {
                while (IsConnected() == false) await Task.Delay(250);
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
            
            // id can be random, but we'll store it for consistency (unless user-defined)
            if (string.IsNullOrEmpty(Variables.AppSettings.MqttClientId))
            {
                Variables.AppSettings.MqttClientId = Guid.NewGuid().ToString()[..8];
                SettingsManager.StoreAppSettings();
            }
            
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
                .WithClientId(Variables.AppSettings.MqttClientId)
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

                switch (Encoding.UTF8.GetString(applicationMessage.Payload))
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
