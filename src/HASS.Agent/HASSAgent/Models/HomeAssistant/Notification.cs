namespace HASSAgent.Models.HomeAssistant
{
    public class Notification
    {
        public Notification()
        {
            //
        }

        public string Message { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public int Duration { get; set; } = 0;
    }
}
