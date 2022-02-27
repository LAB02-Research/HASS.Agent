using HASSAgent.Sensors;

namespace HASSAgent.Models.HomeAssistant.Commands.InternalCommands
{
    internal class PublishAllSensorsCommand : InternalCommand
    {
        internal PublishAllSensorsCommand(string name = "PublishAllSensors", string id = default) : base(name ?? "PublishAllSensors", "", id)
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
