using HASS.Agent.Sensors;
using HASS.Agent.Shared.Enums;
using HASS.Agent.Shared.Models.HomeAssistant.Commands;

namespace HASS.Agent.Models.HomeAssistant.Commands.InternalCommands
{
    internal class PublishAllSensorsCommand : InternalCommand
    {
        internal PublishAllSensorsCommand(string name = "PublishAllSensors", CommandEntityType entityType = CommandEntityType.Switch, string id = default) : base(name ?? "PublishAllSensors", string.Empty, entityType, id)
        {
            State = "OFF";
        }

        public override void TurnOn()
        {
            State = "ON";

            SensorsManager.ResetAllSensorChecks();

            State = "OFF";
        }
    }
}
