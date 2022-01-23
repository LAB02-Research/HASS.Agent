using System;
using System.Diagnostics;
using System.Threading.Tasks;
using HASSAgent.Functions;
using Serilog;

namespace HASSAgent.Models.HomeAssistant.Commands
{
    public class PowershellCommand : AbstractCommand
    {
        public string Command { get; protected set; }
        public string State { get; protected set; }
        public Process Process { get; set; }

        private readonly bool _isScript = false;
        private readonly string _descriptor = "command";

        public PowershellCommand(string command, string name = "Powershell", string id = default) : base(name ?? "Powershell", id)
        {
            Command = command;
            if (Command.ToLower().EndsWith(".ps1"))
            {
                _isScript = true;
                _descriptor = "script";
            }

            State = "OFF";
        }

        public override void TurnOn()
        {
            State = "ON";

            var executed = _isScript
                ? PowershellManager.ExecuteScriptHeadless(Command)
                : PowershellManager.ExecuteCommandHeadless(Command);

            if (!executed)
            {
                Log.Error("[COMMAND] Launching PS {descriptor} '{name}' failed", _descriptor, Name);
                State = "FAILED";
            }
            else State = "OFF";
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
