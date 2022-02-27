using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using HASSAgent.Functions;
using Serilog;

namespace HASSAgent.Models.HomeAssistant.Sensors.GeneralSensors.SingleValue
{
    public class ProcessActiveSensor : AbstractSingleValueSensor
    {
        public string ProcessName { get; protected set; }

        public ProcessActiveSensor(string processName, int? updateInterval = null, string name = "processactive", string id = default) : base(name ?? "processactive", updateInterval ?? 10, id)
        {
            ProcessName = processName;
        }

        public override DiscoveryConfigModel GetAutoDiscoveryConfig()
        {
            return AutoDiscoveryConfigModel ?? SetAutoDiscoveryConfigModel(new SensorDiscoveryConfigModel()
            {
                Name = Name,
                Unique_id = Id,
                Device = Variables.DeviceConfig,
                State_topic = $"{Variables.AppSettings.MqttDiscoveryPrefix}/{Domain}/{Variables.DeviceConfig.Name}/{ObjectId}/state",
                Icon = "mdi:file-eye-outline",
                Availability_topic = $"{Variables.AppSettings.MqttDiscoveryPrefix}/sensor/{Variables.DeviceConfig.Name}/availability"
            });
        }

        public override string GetState()
        {
            // we don't need the extension
            if (ProcessName.Contains(".")) ProcessName = Path.GetFileNameWithoutExtension(ProcessName);

            // search for our process
            var procs = Process.GetProcessesByName(ProcessName);
            var instanceCount = procs.Any() ? procs.Length : 0;

            // dispose all objects
            foreach (var proc in procs) proc?.Dispose();

            // done
            return instanceCount.ToString();
        }
    }
}
