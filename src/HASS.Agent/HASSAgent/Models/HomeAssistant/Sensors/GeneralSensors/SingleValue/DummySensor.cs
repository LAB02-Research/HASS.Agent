namespace HASSAgent.Models.HomeAssistant.Sensors.GeneralSensors.SingleValue
{
    public class DummySensor : AbstractSingleValueSensor
    {
        public DummySensor(int? updateInterval = null, string name = "Dummy", string id = default) : base(name ?? "Dummy", updateInterval ?? 5, id) { }

        public override DiscoveryConfigModel GetAutoDiscoveryConfig()
        {
            return AutoDiscoveryConfigModel ?? SetAutoDiscoveryConfigModel(new SensorDiscoveryConfigModel()
            {
                Name = Name,
                Unique_id = Id,
                Device = Variables.DeviceConfig,
                State_topic = $"homeassistant/{Domain}/{Variables.DeviceConfig.Name}/{ObjectId}/state",
                Availability_topic = $"homeassistant/{Domain}/{Variables.DeviceConfig.Name}/availability"
            });
        }

        public override string GetState()
        {
            return Variables.Rnd.Next(0, 100).ToString();
        }
    }
}
