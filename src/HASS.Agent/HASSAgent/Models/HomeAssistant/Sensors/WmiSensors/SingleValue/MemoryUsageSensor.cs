using System.Globalization;
using System.Management;

namespace HASSAgent.Models.HomeAssistant.Sensors.WmiSensors.SingleValue
{
    public class MemoryUsageSensor : WmiQuerySensor
    {
        public MemoryUsageSensor(int? updateInterval = null, string name = "MemoryUsage", string id = default) : base("SELECT FreePhysicalMemory,TotalVisibleMemorySize FROM Win32_OperatingSystem", updateInterval ?? 30, name ?? "MemoryUsage", id) {}

        public override DiscoveryConfigModel GetAutoDiscoveryConfig()
        {
            return AutoDiscoveryConfigModel ?? SetAutoDiscoveryConfigModel(new SensorDiscoveryConfigModel()
            {
                Name = Name,
                Unique_id = Id,
                Device = Variables.DeviceConfig,
                State_topic = $"{Variables.AppSettings.MqttDiscoveryPrefix}/{Domain}/{Variables.DeviceConfig.Name}/{ObjectId}/state",
                Icon = "mdi:memory",
                Unit_of_measurement = "%",
                Availability_topic = $"{Variables.AppSettings.MqttDiscoveryPrefix}/{Domain}/{Variables.DeviceConfig.Name}/availability"
            });
        }

        public override string GetState()
        {
            using (var collection = Searcher.Get())
            {
                ulong? totalMemory = null;
                ulong? freeMemory = null;

                foreach (var o in collection)
                {
                    var mo = (ManagementObject)o;
                    try
                    {
                        totalMemory = (ulong)mo.Properties["TotalVisibleMemorySize"]?.Value;
                        freeMemory = (ulong)mo.Properties["FreePhysicalMemory"]?.Value;
                    }
                    finally
                    {
                        mo?.Dispose();
                    }
                }

                if (totalMemory == null) return string.Empty;

                decimal totalMemoryDec = totalMemory.Value;
                decimal freeMemoryDec = freeMemory.Value;

                var precentageUsed = 100 - (freeMemoryDec / totalMemoryDec) * 100;
                return precentageUsed.ToString("#.##", CultureInfo.InvariantCulture);
            }
        }
    }
}
