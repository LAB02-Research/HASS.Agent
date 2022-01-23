using System;
using System.Diagnostics;
using System.Threading.Tasks;
using HASSAgent.Functions;
using Serilog;

namespace HASSAgent.Models.HomeAssistant.Commands
{
    public class CustomCommand : AbstractCommand
    {
        public string Command { get; protected set; }
        public string State { get; protected set; }
        public bool RunAsLowIntegrity { get; protected set; }
        public Process Process { get; set; }

        public CustomCommand(string command, bool runAsLowIntegrity, string name = "Custom", string id = default) : base(name ?? "Custom", id)
        {
            Command = command;
            RunAsLowIntegrity = runAsLowIntegrity;
            State = "OFF";
        }

        public override void TurnOn()
        {
            State = "ON";

            if (RunAsLowIntegrity) CommandLineManager.LaunchAsLowIntegrity(Command);
            else
            {
                var executed = CommandLineManager.ExecuteHeadless(Command);

                if (!executed)
                {
                    Log.Error("[COMMAND] Launching command '{name}' failed", Name);
                    State = "FAILED";
                    return;
                }
            }

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
            Process.Kill();
        }
    }
}
