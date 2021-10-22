namespace HASSAgent.Models
{
    public class Action
    {
        public Action()
        {
            //
        }

        public string Description { get; set; }
        public HassEntity Entity { get; set; }
    }
}
