using System;
using System.Runtime.InteropServices;
using HASSAgent.Functions;

namespace HASSAgent.Models.HomeAssistant.Sensors.GeneralSensors.SingleValue
{
    public class LastBootSensor : AbstractSingleValueSensor
    {
        public LastBootSensor(int? updateInterval = 10, string name = "LastBoot", string id = default) : base(name ?? "LastBoot", updateInterval ?? 10, id) {}

        public override DiscoveryConfigModel GetAutoDiscoveryConfig()
        {
            return AutoDiscoveryConfigModel ?? SetAutoDiscoveryConfigModel(new SensorDiscoveryConfigModel()
            {
                Name = Name,
                Unique_id = Id,
                Device = Variables.DeviceConfig,
                State_topic = $"homeassistant/{Domain}/{Variables.DeviceConfig.Name}/{ObjectId}/state",
                Icon = "mdi:clock-time-three-outline",
                Availability_topic = $"homeassistant/{Domain}/{Variables.DeviceConfig.Name}/availability",
                Device_class = "timestamp"
            });
        }

        public override string GetState() => (DateTime.Now - TimeSpan.FromMilliseconds(GetTickCount64())).ToTimeZoneString();

        [DllImport("kernel32")]
        private static extern ulong GetTickCount64();
    }
}
