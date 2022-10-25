namespace HASS.Agent.Models.HomeAssistant
{
    public class NotificationAction
    {
        public string Action { get; set; }
        public string Title { get; set; }
    }

    public class NotificationData
    {
        public int Duration { get; set; } = 0;
        public string Image { get; set; }

        public List<NotificationAction> Actions { get; set; } = new();
    }
    
    public class Notification
    {
        public string Message { get; set; }
        public string Title { get; set; }

        public NotificationData Data { get; set; }
    }
}
