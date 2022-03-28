using HASS.Agent.Models.HomeAssistant;

namespace HASS.Agent.Models.Internal
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
