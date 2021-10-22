using System;

namespace HASSAgent.Models.Mqtt.Sensors.GeneralSensors
{
    public class DummySensor : AbstractSensor
    {
        public DummySensor(int? updateInterval = null, string name = "Dummy", Guid id = default) : base(name ?? "Dummy", updateInterval ?? 5, id) { }

        public override DiscoveryConfigModel GetAutoDiscoveryConfig()
        {
            return AutoDiscoveryConfigModel ?? SetAutoDiscoveryConfigModel(new SensorDiscoveryConfigModel()
            {
                Name = Name,
                Unique_id = Id.ToString(),
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
