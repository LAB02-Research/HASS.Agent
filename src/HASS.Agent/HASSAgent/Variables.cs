using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Threading;
using CoreAudio;
using Grapevine;
using HASSAgent.Forms;
using HASSAgent.Functions;
using HASSAgent.Models.HomeAssistant;
using HASSAgent.Models.HomeAssistant.Commands;
using HASSAgent.Models.HomeAssistant.Sensors;
using HASSAgent.Models.Internal;
using MQTTnet;
using WK.Libraries.HotkeyListenerNS;
using AppSettings = HASSAgent.Models.Config.AppSettings;

namespace HASSAgent
{
    public static class Variables
    {
        /// <summary>
        /// Application info
        /// </summary>
        public static string ApplicationName { get; } = Assembly.GetExecutingAssembly().GetName().Name;
        public static string ApplicationExecutable { get; } = Assembly.GetExecutingAssembly().Location;
        public static string Version { get; } = $"{Assembly.GetExecutingAssembly().GetName().Version.Major}.{Assembly.GetExecutingAssembly().GetName().Version.Minor}.{Assembly.GetExecutingAssembly().GetName().Version.Build}.{Assembly.GetExecutingAssembly().GetName().Version.Revision}";
        
        /// <summary>
        /// Constants
        /// </summary>
        internal const string SyncfusionLicense = "NTA2NTgzQDMxMzkyZTMyMmUzMEhrMG96Rmx5N3JCTmJYT1o0R0g1ZjVlUVdoSDJvRFNSS0QvcktBSXhsb1U9";
        internal const string RootRegKey = @"HKEY_CURRENT_USER\SOFTWARE\LAB02Research\HASSAgent";
        internal const string CertificateHash = "E4C76406BD0AC3937014764596B1697E4EB4A953";
        
        /// <summary>
        /// Internal references
        /// </summary>
        internal static Main MainForm { get; set; }
        internal static Dispatcher UiDispatcher { get; set; }
        internal static WebClient WebClient { get; } = new WebClient();
        internal static Hotkey QuickActionsHotKey { get; set; } = new Hotkey(Keys.Control | Keys.Alt, Keys.Q);
        internal static HotKeyManager HotKeyManager { get; } = new HotKeyManager();
        internal static HotkeyListener HotKeyListener { get; set; }
        internal static MMDeviceEnumerator AudioDeviceEnumerator { get; } = new MMDeviceEnumerator();
        internal static Random Rnd { get; } = new Random();

        /// <summary>
        /// MQTT
        /// </summary>
        internal static MqttFactory MqttFactory { get; } = new MqttFactory();
        internal static DeviceConfigModel DeviceConfig { get; set; } = null;

        /// <summary>
        /// Internal state
        /// </summary>
        internal static bool ChildApplicationMode { get; set; } = false;
        internal static bool ShuttingDown { get; set; } = false;
        internal static bool OnboardingLaunchOnLoginKeyCreated { get; set; } = false;
        internal static bool ExtendedLogging { get; set; } = false;
        internal static bool ExceptionLogging { get; set; } = false;

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
