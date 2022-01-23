using System;
using System.Text.RegularExpressions;
using HASSAgent.Enums;
using HASSAgent.Functions;

namespace HASSAgent.Models.Config
{
    public class AppSettings
    {
        public AppSettings()
        {
            //
        }

        public OnboardingStatus OnboardingStatus { get; set; } = OnboardingStatus.NeverDone;

        public string DeviceName { get; set; } = Environment.MachineName;

        public bool CheckForUpdates { get; set; } = true;
        public string LastUpdateNotificationShown { get; set; }
        public bool EnableExecuteUpdateInstaller { get; set; } = true;

        public int ImageCacheRetentionDays { get; set; } = 7;
        
        public bool NotificationsEnabled { get; set; } = true;
        public int NotifierApiPort { get; set; } = 5115;

        public string HassUri { get; set; } = "http://homeassistant.local:8123";
        public string HassToken { get; set; }
        public bool HassAutoClientCertificate { get; set; } = false;
        public string HassClientCertificate { get; set; }

        public bool QuickActionsHotKeyEnabled { get; set; } = true;
        public string QuickActionsHotKey { get; set; }

        public string MqttAddress { get; set; } = "homeassistant.local";
        public int MqttPort { get; set; } = 1883;
        public bool MqttUseTls { get; set; }
        public bool MqttAllowUntrustedCertificates { get; set; } = true;
        public string MqttUsername { get; set; }
        public string MqttPassword { get; set; }
        public string MqttDiscoveryPrefix { get; set; } = "homeassistant";
        public bool MqttUseRetainFlag { get; set; } = true;
        public string MqttRootCertificate { get; set; }
        public string MqttClientCertificate { get; set; }
    }
}
