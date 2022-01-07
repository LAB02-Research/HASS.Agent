using System.Runtime.InteropServices;
using HASSAgent.Enums;

namespace HASSAgent.Models.HomeAssistant.Sensors.GeneralSensors.SingleValue
{
    public class UserNotificationStateSensor : AbstractSingleValueSensor
    {
        public UserNotificationStateSensor(int? updateInterval = null, string name = "NotificationState", string id = default) : base(name ?? "NotificationState", updateInterval ?? 10, id) { }

        public override DiscoveryConfigModel GetAutoDiscoveryConfig()
        {
            return AutoDiscoveryConfigModel ?? SetAutoDiscoveryConfigModel(new SensorDiscoveryConfigModel()
            {
                Name = Name,
                Unique_id = Id,
                Device = Variables.DeviceConfig,
                State_topic = $"{Variables.AppSettings.MqttDiscoveryPrefix}/{Domain}/{Variables.DeviceConfig.Name}/{Name}/state",
                Icon = "mdi:laptop",
                Availability_topic = $"{Variables.AppSettings.MqttDiscoveryPrefix}/{Domain}/{Variables.DeviceConfig.Name}/availability"
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
