using System;
using System.Runtime.InteropServices;
using System.Text;

namespace HASSAgent.Models.Mqtt.Sensors.GeneralSensors
{
    public class ActiveWindowSensor : AbstractSensor
    {
        public ActiveWindowSensor(int? updateInterval = null, string name = "ActiveWindow", Guid id = default) : base(name ?? "ActiveWindow", updateInterval ?? 15, id) { }

        public override DiscoveryConfigModel GetAutoDiscoveryConfig()
        {
            return AutoDiscoveryConfigModel ?? SetAutoDiscoveryConfigModel(new SensorDiscoveryConfigModel()
            {
                Name = Name,
                Unique_id = Id.ToString(),
                Device = Variables.DeviceConfig,
                State_topic = $"homeassistant/{Domain}/{Variables.DeviceConfig.Name}/{ObjectId}/state",
                Icon = "mdi:window-maximize",
                Availability_topic = $"homeassistant/{Domain}/{Variables.DeviceConfig.Name}/availability"
            });
        }

        public override string GetState()
        {
            return GetActiveWindowTitle();
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        private static string GetActiveWindowTitle()
        {
            const int nChars = 256;
            var buff = new StringBuilder(nChars);
            var handle = GetForegroundWindow();

            return GetWindowText(handle, buff, nChars) > 0 ? buff.ToString() : null;
        }
    }
}
