using HASSAgent.Functions;

namespace HASSAgent.Models.HomeAssistant.Sensors.GeneralSensors.SingleValue
{
    public class SessionStateSensor : AbstractSingleValueSensor
    {
        public SessionStateSensor(int? updateInterval = null, string name = "SessionState", string id = default) : base(name ?? "SessionState", updateInterval ?? 10, id) { }

        public override DiscoveryConfigModel GetAutoDiscoveryConfig()
        {
            return AutoDiscoveryConfigModel ?? SetAutoDiscoveryConfigModel(new SensorDiscoveryConfigModel()
            {
                Name = Name,
                Unique_id = Id,
                Device = Variables.DeviceConfig,
                State_topic = $"{Variables.AppSettings.MqttDiscoveryPrefix}/{Domain}/{Variables.DeviceConfig.Name}/{ObjectId}/state",
                Icon = "mdi:lock",
                Availability_topic = $"{Variables.AppSettings.MqttDiscoveryPrefix}/{Domain}/{Variables.DeviceConfig.Name}/availability"
            });
        }

        public override string GetState() => SessionInfo.GetActiveSessionLockState().ToString();
    }
}
