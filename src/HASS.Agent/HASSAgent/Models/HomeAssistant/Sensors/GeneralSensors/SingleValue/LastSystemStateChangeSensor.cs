using HASSAgent.Functions;

namespace HASSAgent.Models.HomeAssistant.Sensors.GeneralSensors.SingleValue
{
    public class LastSystemStateChangeSensor : AbstractSingleValueSensor
    {
        public LastSystemStateChangeSensor(int? updateInterval = 10, string name = "LastSystemStateChange", string id = default) : base(name ?? "LastSystemStateChange", updateInterval ?? 10, id) { }

        public override DiscoveryConfigModel GetAutoDiscoveryConfig()
        {
            return AutoDiscoveryConfigModel ?? SetAutoDiscoveryConfigModel(new SensorDiscoveryConfigModel()
            {
                Name = Name,
                Unique_id = Id,
                Device = Variables.DeviceConfig,
                State_topic = $"{Variables.AppSettings.MqttDiscoveryPrefix}/{Domain}/{Variables.DeviceConfig.Name}/{ObjectId}/state",
                Icon = "mdi:cog",
                Availability_topic = $"{Variables.AppSettings.MqttDiscoveryPrefix}/{Domain}/{Variables.DeviceConfig.Name}/availability"
            });
        }

        public override string GetState() => SystemStateManager.LastSystemStateEvent.ToString();
    }
}
