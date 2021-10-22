using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management;

namespace HASSAgent.Models.Mqtt.Sensors.WmiSensors
{
    public class CpuLoadSensor : WmiQuerySensor
    {
        public CpuLoadSensor(int? updateInterval = null, string name = "CpuLoadSensor", Guid id = default) : base("SELECT PercentProcessorTime FROM Win32_PerfFormattedData_PerfOS_Processor", updateInterval ?? 30, name ?? "CpuLoadSensor", id) {}
        
        public override DiscoveryConfigModel GetAutoDiscoveryConfig()
        {
            return AutoDiscoveryConfigModel ?? SetAutoDiscoveryConfigModel(new SensorDiscoveryConfigModel()
            {
                Name = Name,
                Unique_id = Id.ToString(),
                Device = Variables.DeviceConfig,
                State_topic = $"homeassistant/{Domain}/{Variables.DeviceConfig.Name}/{ObjectId}/state",
                Icon = "mdi:chart-areaspline",
                Unit_of_measurement = "%",
                Availability_topic = $"homeassistant/{Domain}/{Variables.DeviceConfig.Name}/availability"
            });
        }
        
        public override string GetState()
        {
            using (var collection = Searcher.Get())
            {
                var processorLoadPercentages = new List<int>();
                foreach (var o in collection)
                {
                    var mo = (ManagementObject)o;
                    try
                    {
                        foreach (var property in mo.Properties)
                        {
                            var parsed = int.TryParse(property.Value.ToString(), out var value);
                            if (!parsed) continue;

                            processorLoadPercentages.Add(value);
                        }
                    }
                    finally
                    {
                        mo?.Dispose();
                    }
                }
                var average = processorLoadPercentages.Count > 0 ? processorLoadPercentages.Average() : 0.0;
                return average.ToString("#.##", CultureInfo.InvariantCulture);
            }
        }
    }
}
