using System;
using System.Diagnostics;
using System.Threading.Tasks;
using HASSAgent.Functions;
using Serilog;

namespace HASSAgent.Models.HomeAssistant.Commands
{
    public class InternalCommand : AbstractCommand
    {
        public string State { get; protected set; }
        public string CommandConfig { get; protected set; }

        public InternalCommand(string name = "Internal", string commandConfig = "", string id = default) : base(name ?? "Internal", id)
        {
            State = "OFF";
            CommandConfig = commandConfig;
        }

        public override void TurnOn()
        {
            State = "ON";

            // to be overriden

            State = "OFF";
        }
        
        public override DiscoveryConfigModel GetAutoDiscoveryConfig()
        {
            return new CommandDiscoveryConfigModel()
            {
                Name = Name,
                Unique_id = Id,
                Availability_topic = $"{Variables.AppSettings.MqttDiscoveryPrefix}/sensor/{Variables.DeviceConfig.Name}/availability",
                Command_topic = $"{Variables.AppSettings.MqttDiscoveryPrefix}/{Domain}/{Variables.DeviceConfig.Name}/{ObjectId}/set",
                State_topic = $"{Variables.AppSettings.MqttDiscoveryPrefix}/{Domain}/{Variables.DeviceConfig.Name}/{ObjectId}/state",
                Device = Variables.DeviceConfig,
            };
        }

        public override string GetState()
        {
            return State;
        }

        public override void TurnOff()
        {
            //
        }
    }
}
