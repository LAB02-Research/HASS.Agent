using HASS.Agent.Enums;

namespace HASS.Agent.Models.Config
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
        public string LastUpdateNotificationShown { get; set; } = string.Empty;
        public bool EnableExecuteUpdateInstaller { get; set; } = true;
        public bool ShowBetaUpdates { get; set; }
        public int DisconnectedGracePeriodSeconds { get; set; } = 60;

        public int ImageCacheRetentionDays { get; set; } = 7;

        public string ServiceAuthId { get; set; } = string.Empty;

        public string BrowserName { get; set; } = string.Empty;
        public string BrowserBinary { get; set; } = string.Empty;
        public string BrowserIncognitoArg { get; set; } = string.Empty;

        public string CustomExecutorName { get; set; } = string.Empty;
        public string CustomExecutorBinary { get; set; } = string.Empty;

        public bool NotificationsEnabled { get; set; } = true;
        public int NotifierApiPort { get; set; } = 5115;

        public string HassUri { get; set; } = "http://homeassistant.local:8123";
        public string HassToken { get; set; } = string.Empty;
        public bool HassAutoClientCertificate { get; set; } = false;
        public string HassClientCertificate { get; set; } = string.Empty;

        public bool QuickActionsHotKeyEnabled { get; set; } = true;
        public string QuickActionsHotKey { get; set; } = string.Empty;

        public string MqttAddress { get; set; } = "homeassistant.local";
        public int MqttPort { get; set; } = 1883;
        public bool MqttUseTls { get; set; }
        public bool MqttAllowUntrustedCertificates { get; set; } = true;
        public string MqttUsername { get; set; } = string.Empty;
        public string MqttPassword { get; set; } = string.Empty;
        public string MqttDiscoveryPrefix { get; set; } = "homeassistant";
        public string MqttClientId { get; set; } = string.Empty;
        public bool MqttUseRetainFlag { get; set; } = true;
        public string MqttRootCertificate { get; set; } = string.Empty;
        public string MqttClientCertificate { get; set; } = string.Empty;
    }
}
