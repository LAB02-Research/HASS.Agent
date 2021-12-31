using System;
using System.Runtime.InteropServices;
using HASSAgent.Functions;

namespace HASSAgent.Models.HomeAssistant.Sensors.GeneralSensors.SingleValue
{
    public class LastActiveSensor : AbstractSingleValueSensor
    {
        public LastActiveSensor(int? updateInterval = 10, string name = "LastActive", string id = default) : base(name ?? "LastActive", updateInterval ?? 10, id) { }

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

        public override string GetState() => GetLastInputTime().ToTimeZoneString();
        
        private static DateTime GetLastInputTime()
        {
            var lastInputInfo = new LASTINPUTINFO();
            lastInputInfo.cbSize = Marshal.SizeOf(lastInputInfo);
            lastInputInfo.dwTime = 0;

            var envTicks = Environment.TickCount;

            if (!GetLastInputInfo(ref lastInputInfo)) return DateTime.Now;
            var lastInputTick = Convert.ToInt32(lastInputInfo.dwTime);

            var idleTime = envTicks - lastInputTick;
            return idleTime > 0 ? DateTime.Now - TimeSpan.FromMilliseconds(idleTime) : DateTime.Now;
        }


        [DllImport("User32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        [StructLayout(LayoutKind.Sequential)]
        // ReSharper disable once InconsistentNaming
        private struct LASTINPUTINFO
        {
            private static readonly int SizeOf = Marshal.SizeOf(typeof(LASTINPUTINFO));

            [MarshalAs(UnmanagedType.U4)]
            public int cbSize;
            [MarshalAs(UnmanagedType.U4)]
            public uint dwTime;
        }
    }
}
