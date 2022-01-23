namespace HASSAgent.Models.HomeAssistant.Sensors.PerfCounterSensors.SingleValue
{
    public class CpuLoadSensor : PerformanceCounterSensor
    {
        public CpuLoadSensor(int? updateInterval = null, string name = "cpuload", string id = default) : base("Processor", "% Processor Time", "_Total", updateInterval ?? 30, name ?? "cpuload", id) {}
        
        public override DiscoveryConfigModel GetAutoDiscoveryConfig()
        {
            return AutoDiscoveryConfigModel ?? SetAutoDiscoveryConfigModel(new SensorDiscoveryConfigModel()
            {
                Name = Name,
                Unique_id = Id,
                Device = Variables.DeviceConfig,
                State_topic = $"{Variables.AppSettings.MqttDiscoveryPrefix}/{Domain}/{Variables.DeviceConfig.Name}/{ObjectId}/state",
                Icon = "mdi:chart-areaspline",
                Unit_of_measurement = "%",
                Availability_topic = $"{Variables.AppSettings.MqttDiscoveryPrefix}/{Domain}/{Variables.DeviceConfig.Name}/availability"
            });
        }
    }
}
