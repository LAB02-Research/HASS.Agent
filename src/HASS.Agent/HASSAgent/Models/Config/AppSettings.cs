using HASSAgent.Enums;

namespace HASSAgent.Models.Config
{
    public class AppSettings
    {
        public AppSettings()
        {
            //
        }

        public OnboardingStatus OnboardingStatus { get; set; } = OnboardingStatus.NeverDone;

        public bool CheckForUpdates { get; set; } = true;
        public string LastUpdateNotificationShown { get; set; }
        
        public bool NotificationsEnabled { get; set; } = true;
        public int NotifierApiPort { get; set; } = 5115;

        public string HassUri { get; set; } = "http://homeassistant.local:8123";
        public string HassToken { get; set; }

        public bool QuickActionsHotKeyEnabled { get; set; } = true;
        public string QuickActionsHotKey { get; set; }

        public string MqttAddress { get; set; } = "homeassistant.local";
        public int MqttPort { get; set; } = 1883;
        public bool MqttUseTls { get; set; }
        public string MqttUsername { get; set; }
        public string MqttPassword { get; set; }
    }
}
