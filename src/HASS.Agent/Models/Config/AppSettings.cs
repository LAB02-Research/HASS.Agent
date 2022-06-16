using HASS.Agent.Enums;
using HASS.Agent.Functions;
using HASS.Agent.Shared.Functions;

namespace HASS.Agent.Models.Config
{
    public class AppSettings
    {
        public AppSettings()
        {
            //
        }

        public OnboardingStatus OnboardingStatus { get; set; } = OnboardingStatus.NeverDone;

        public string DeviceName { get; set; } = SharedHelperFunctions.GetSafeDeviceName();
        public string InterfaceLanguage { get; set; } = string.Empty;

        public bool CheckForUpdates { get; set; } = true;
        public string LastUpdateNotificationShown { get; set; } = string.Empty;
        public bool EnableExecuteUpdateInstaller { get; set; } = true;
        public bool ShowBetaUpdates { get; set; }
        public int DisconnectedGracePeriodSeconds { get; set; } = 60;

        public int ImageCacheRetentionDays { get; set; } = 7;
        public int AudioCacheRetentionDays { get; set; } = 7;

        public int WebViewCacheRetentionDays { get; set; } = 0;
        public DateTime WebViewCacheLastCleared { get; set; } = DateTime.Now;

        public bool TrayIconShowDefaultMenu { get; set; } = true;
        public bool TrayIconShowWebView { get; set; } = false;
        public int TrayIconWebViewWidth { get; set; } = 700;
        public int TrayIconWebViewHeight { get; set; } = 560;
        public string TrayIconWebViewUrl { get; set; } = string.Empty;
        public bool TrayIconWebViewBackgroundLoading { get; set; } = false;

        public string ServiceAuthId { get; set; } = string.Empty;

        public string BrowserName { get; set; } = string.Empty;
        public string BrowserBinary { get; set; } = string.Empty;
        public string BrowserIncognitoArg { get; set; } = string.Empty;

        public string CustomExecutorName { get; set; } = string.Empty;
        public string CustomExecutorBinary { get; set; } = string.Empty;

        public bool LocalApiEnabled { get; set; } = true;
        public int LocalApiPort { get; set; } = 5115;

        public bool NotificationsEnabled { get; set; } = true;
        public bool NotificationsIgnoreImageCertificateErrors { get; set; } = false;

        // to be removed in next release
        public int NotifierApiPort { get; set; } = 5115;

        public bool MediaPlayerEnabled { get; set; } = true;

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
