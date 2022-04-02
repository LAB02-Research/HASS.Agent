using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using Grapevine;
using HASS.Agent.Forms;
using HASS.Agent.Functions;
using HASS.Agent.Models.Config;
using HASS.Agent.Models.Internal;
using HASS.Agent.MQTT;
using HASS.Agent.Service;
using HASS.Agent.Shared.Models.HomeAssistant;
using HASS.Agent.Shared.Models.HomeAssistant.Commands;
using HASS.Agent.Shared.Models.HomeAssistant.Sensors;
using HASS.Agent.Shared.Mqtt;
using MQTTnet;
using WK.Libraries.HotkeyListenerNS;

namespace HASS.Agent
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public static class Variables
    {
        /// <summary>
        /// Application info
        /// </summary>
        public static string ApplicationName { get; } = Assembly.GetExecutingAssembly().GetName().Name ?? "HASS.Agent";
        public static string MessageBoxTitle { get; } = "HASS.Agent";
        public static string ApplicationExecutable { get; } = Assembly.GetExecutingAssembly().Location.Replace(".dll", ".exe");
        public static string Version { get; } = $"{Assembly.GetExecutingAssembly().GetName().Version?.Major}.{Assembly.GetExecutingAssembly().GetName().Version?.Minor}.{Assembly.GetExecutingAssembly().GetName().Version?.Build}.{Assembly.GetExecutingAssembly().GetName().Version?.Revision}";
        public static bool Beta { get; set; } = false;

        /// <summary>
        /// Constants
        /// </summary>
        internal const string SyncfusionLicense = "NTk0MzAyQDMxMzkyZTM0MmUzMGpOM2NCRmROQWpybDZPYnBBa0twMWdqTFFRMGRUTERqa1laazRST2N6N1E9";
        internal const string RootRegKey = @"HKEY_CURRENT_USER\SOFTWARE\LAB02Research\HASSAgent";
        internal const string CertificateHash = "E4C76406BD0AC3937014764596B1697E4EB4A953";
        
        /// <summary>
        /// Internal references
        /// </summary>
        internal static Main MainForm { get; set; }
        internal static HttpClient HttpClient { get; set; } = new();
        internal static Hotkey QuickActionsHotKey { get; set; } = new(Keys.Control | Keys.Alt, Keys.Q);
        internal static HotKeyManager HotKeyManager { get; } = new();
        internal static HotkeyListener HotKeyListener { get; set; }
        internal static Random Rnd { get; } = new();
        internal static  Font DefaultFont { get; } = new("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);

        /// <summary>
        /// Localization
        /// </summary>
        internal static List<SupportedUILanguage> SupportedUILanguages { get; } = new();
        internal static SupportedUILanguage CurrentUICulture { get; set; } = new(new CultureInfo("en"));

        /// <summary>
        /// MQTT
        /// </summary>
        internal static IMqttManager MqttManager { get; } = new MqttManager();
        internal static MqttFactory MqttFactory { get; } = new();
        internal static DeviceConfigModel DeviceConfig { get; set; } = null;

        /// <summary>
        /// RPC (satellite service)
        /// </summary>
        internal static string PipeName => "5aaac90b-d046-4db2-be76-af225e0d249f";
        internal static string SatelliteServiceName => "HASS.Agent Satellite Service";
        internal static string SatelliteMachineRootRegKey => @"HKEY_LOCAL_MACHINE\SOFTWARE\LAB02Research\HASSAgent\SatelliteService";
        internal static string SatelliteServiceRootPath { get; set; } = string.Empty;
        internal static string SatelliteServiceBinary { get; set; } = string.Empty;
        internal static string SatelliteServiceLogPath { get; set; } = string.Empty;
        internal static RpcClientService RpcClient => new();
        internal static TimeSpan RpcConnectionTimeout { get; } = TimeSpan.FromSeconds(15);

        /// <summary>
        /// Internal state
        /// </summary>
        internal static bool ChildApplicationMode { get; set; } = false;
        internal static bool ShuttingDown { get; set; } = false;
        internal static bool OnboardingLaunchOnLoginKeyCreated { get; set; } = false;
        internal static bool ExtendedLogging { get; set; } = false;

        /// <summary>
        /// Local IO
        /// </summary>
        internal static string StartupPath { get; } = Path.GetDirectoryName(Application.ExecutablePath);
        internal static string CachePath { get; } = Path.Combine(StartupPath, "cache");
        internal static string ImageCachePath { get; } = Path.Combine(CachePath, "images");
        internal static string LogPath { get; } = Path.Combine(StartupPath, "logs");
        internal static string ConfigPath { get; } = Path.Combine(StartupPath, "config");
        internal static string AppSettingsFile { get; } = Path.Combine(ConfigPath, "appsettings.json");
        internal static string QuickActionsFile { get; } = Path.Combine(ConfigPath, "quickactions.json");
        internal static string CommandsFile { get; } = Path.Combine(ConfigPath, "commands.json");
        internal static string SensorsFile { get; } = Path.Combine(ConfigPath, "sensors.json");

        /// <summary>
        /// Notifier API
        /// </summary>
        internal static IRestServer NotificationServer { get; set; } = null;

        /// <summary>
        /// Config
        /// </summary>
        internal static AppSettings AppSettings { get; set; }
        internal static List<QuickAction> QuickActions { get; set; }
        internal static List<AbstractCommand> Commands { get; set; }
        internal static List<AbstractSingleValueSensor> SingleValueSensors { get; set; }
        internal static List<AbstractMultiValueSensor> MultiValueSensors { get; set; }
    }
}
