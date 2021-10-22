using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using CoreAudio;
using Grapevine;
using HASSAgent.Forms;
using HASSAgent.Models;
using HASSAgent.Models.Mqtt;
using HASSAgent.Models.Mqtt.Commands;
using HASSAgent.Models.Mqtt.Sensors;
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
        internal static string SyncfusionLicense => "";

        /// <summary>
        /// Internal references
        /// </summary>
        internal static Main FrmM { get; set; }
        internal static Configuration FrmConfig { get; set; }
        internal static WebClient ImageWebClient { get; } = new WebClient();
        internal static Hotkey HotKey { get; set; } = new Hotkey(Keys.Control | Keys.Alt, Keys.Q);
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
        internal static bool ShuttingDown { get; set; } = false;

        /// <summary>
        /// Local IO
        /// </summary>
        internal static string StartupPath { get; } = Path.GetDirectoryName(Application.ExecutablePath);
        internal static string TempPath { get; } = Path.Combine(StartupPath, "Temp");
        internal static string LogPath { get; } = Path.Combine(StartupPath, "Logs");
        internal static string ConfigPath { get; } = Path.Combine(StartupPath, "Config");
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
        internal static List<AbstractSensor> Sensors { get; set; }
    }
}
