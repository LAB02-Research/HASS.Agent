using System;

namespace HASSAgent.Models.Mqtt.Sensors.WmiSensors
{
    public class CurrentClockSpeedSensor : WmiQuerySensor
    {
        public CurrentClockSpeedSensor(int? updateInterval = null, string name = "CurrentClockSpeed", Guid id = default) : base("SELECT CurrentClockSpeed FROM Win32_Processor", updateInterval ?? 300, name ?? "CurrentClockSpeed", id) { }

        public override DiscoveryConfigModel GetAutoDiscoveryConfig()
        {
            return AutoDiscoveryConfigModel ?? SetAutoDiscoveryConfigModel(new SensorDiscoveryConfigModel()
            {
                Name = Name,
                Unique_id = Id.ToString(),
                Device = Variables.DeviceConfig,
                State_topic = $"homeassistant/{Domain}/{Variables.DeviceConfig.Name}/{ObjectId}/state",
                Icon = "mdi:speedometer",
                Unit_of_measurement = "MHz",
                Availability_topic = $"homeassistant/{Domain}/{Variables.DeviceConfig.Name}/availability"
            });
        }
    }
}
