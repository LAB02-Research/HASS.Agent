using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Serilog;
using System.Windows.Forms;

namespace HASSAgent.Models.HomeAssistant.Commands
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class MultipleKeysCommand : AbstractCommand
    {
        public List<string> Keys { get; set; }
        
        internal MultipleKeysCommand(List<string> keys, string name = "MultipleKeys", string id = default) : base(name ?? "MultipleKeys", id)
        {
            Keys = keys;
        }

        public override DiscoveryConfigModel GetAutoDiscoveryConfig()
        {
            return new CommandDiscoveryConfigModel
            {
                Name = Name,
                Unique_id = Id,
                Availability_topic = $"{Variables.AppSettings.MqttDiscoveryPrefix}/sensor/{Variables.DeviceConfig.Name}/availability",
                Command_topic = $"{Variables.AppSettings.MqttDiscoveryPrefix}/{Domain}/{Variables.DeviceConfig.Name}/{ObjectId}/set",
                State_topic = $"{Variables.AppSettings.MqttDiscoveryPrefix}/{Domain}/{Variables.DeviceConfig.Name}/{ObjectId}/state",
                Device = Variables.DeviceConfig
            };
        }

        public override string GetState() => "OFF";

        public override void TurnOff()
        {
            //
        }

        public override async void TurnOn()
        {
            try
            {
                foreach (var key in Keys)
                {
                    SendKeys.SendWait(key);
                    SendKeys.Flush();
                    await Task.Delay(50);
                }
            }
            catch (Exception ex)
            {
                Log.Error("[COMMAND] Launching command '{name}' failed: {ex}", Name, ex.Message);
            }
        }
    }
}
