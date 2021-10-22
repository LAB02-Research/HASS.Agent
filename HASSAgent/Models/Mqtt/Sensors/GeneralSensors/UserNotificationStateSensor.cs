using System;
using System.Runtime.InteropServices;
using HASSAgent.Enums;

namespace HASSAgent.Models.Mqtt.Sensors.GeneralSensors
{
    public class UserNotificationStateSensor : AbstractSensor
    {
        public UserNotificationStateSensor(int? updateInterval = null, string name = "NotificationState", Guid id = default) : base(name ?? "NotificationState", updateInterval ?? 10, id) { }

        public override DiscoveryConfigModel GetAutoDiscoveryConfig()
        {
            return AutoDiscoveryConfigModel ?? SetAutoDiscoveryConfigModel(new SensorDiscoveryConfigModel()
            {
                Name = Name,
                Unique_id = Id.ToString(),
                Device = Variables.DeviceConfig,
                State_topic = $"homeassistant/{Domain}/{Variables.DeviceConfig.Name}/{Name}/state",
                Icon = "mdi:laptop",
                Availability_topic = $"homeassistant/{Domain}/{Variables.DeviceConfig.Name}/availability"
            });
        }

        public override string GetState()
        {
            return GetStateEnum().ToString();
        }

        [DllImport("shell32.dll")]
        private static extern int SHQueryUserNotificationState(out UserNotificationState state);

        public UserNotificationState GetStateEnum()
        {
            SHQueryUserNotificationState(out var state);
            return state;
        }
    }
}
