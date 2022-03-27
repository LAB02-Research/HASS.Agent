using HASSAgent.Models.HomeAssistant;

namespace HASSAgent.Models.Internal
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
