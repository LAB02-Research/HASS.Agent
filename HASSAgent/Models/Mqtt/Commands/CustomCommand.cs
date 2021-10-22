using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Serilog;

namespace HASSAgent.Models.Mqtt.Commands
{
    public class CustomCommand : AbstractCommand
    {
        public string Command { get; protected set; }
        public string State { get; protected set; }
        public Process Process { get; set; }

        public CustomCommand(string command, string name = "Custom", Guid id = default) : base(name ?? "Custom", id)
        {
            Command = command;
            State = "OFF";
        }

        public override async void TurnOn()
        {
            State = "ON";

            using (Process = new Process())
            {
                var startInfo = new ProcessStartInfo
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true,
                    FileName = "cmd.exe",
                    Arguments = $"/C {Command}"
                };

                Process.StartInfo = startInfo;

                try
                {
                    Process.Start();
                }
                catch (Exception ex)
                {
                    Log.Error("[COMMAND] Execution of '{name}' failed: {msg}", Name, ex.Message);
                    State = "FAILED";
                }

                while (!Process.HasExited)
                {
                    await Task.Delay(1000);
                }
            }
                
            State = "OFF";
        }
        
        public override DiscoveryConfigModel GetAutoDiscoveryConfig()
        {
            return new CommandDiscoveryConfigModel()
            {
                Name = Name,
                Unique_id = Id.ToString(),
                Availability_topic = $"homeassistant/sensor/{Variables.DeviceConfig.Name}/availability",
                Command_topic = $"homeassistant/{Domain}/{Variables.DeviceConfig.Name}/{ObjectId}/set",
                State_topic = $"homeassistant/{Domain}/{Variables.DeviceConfig.Name}/{ObjectId}/state",
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
