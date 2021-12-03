namespace HASSAgent.Models.Config
{
    public class AppSettings
    {
        public AppSettings()
        {
            //
        }
        
        public bool NotificationsEnabled { get; set; } = true;
        public int NotifierApiPort { get; set; } = 5115;

        public string HassUri { get; set; } = "http://hass.local:8123";
        public string HassToken { get; set; }

        public bool QuickActionsHotKeyEnabled { get; set; } = true;
        public string QuickActionsHotKey { get; set; } 

        public string MqttAddress { get; set; }
        public int MqttPort { get; set; } = 1883;
        public bool MqttUseTls { get; set; }
        public string MqttUsername { get; set; }
        public string MqttPassword { get; set; }
    }
}
