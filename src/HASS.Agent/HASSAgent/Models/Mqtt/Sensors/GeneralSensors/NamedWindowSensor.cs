using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using HWND = System.IntPtr;

namespace HASSAgent.Models.Mqtt.Sensors.GeneralSensors
{
    public class NamedWindowSensor : AbstractSensor
    {
        public override string Domain => "binary_sensor";
        public string WindowName { get; protected set; }

        public NamedWindowSensor(string windowName, string name = "NamedWindow", int? updateInterval = 10, Guid id = default) : base(name ?? "NamedWindow", updateInterval ?? 30, id)
        {
            WindowName = windowName;
        }

        public override DiscoveryConfigModel GetAutoDiscoveryConfig()
        {
            return AutoDiscoveryConfigModel ?? SetAutoDiscoveryConfigModel(new SensorDiscoveryConfigModel()
            {
                Name = Name,
                Unique_id = Id.ToString(),
                Device = Variables.DeviceConfig,
                State_topic = $"homeassistant/{Domain}/{Variables.DeviceConfig.Name}/{ObjectId}/state",
                Availability_topic = $"homeassistant/sensor/{Variables.DeviceConfig.Name}/availability"
            });
        }

        public override string GetState()
        {
            var windowNames = GetOpenWindows().Values;
            return windowNames.Any(v => v.ToUpper().Contains(WindowName.ToUpper())) ? "ON" : "OFF";
        }

        /// <summary>Returns a dictionary that contains the handle and title of all the open windows.</summary>
        /// <returns>A dictionary that contains the handle and title of all the open windows.</returns>
        public static IDictionary<HWND, string> GetOpenWindows()
        {
            var shellWindow = GetShellWindow();
            var windows = new Dictionary<HWND, string>();

            EnumWindows(delegate (HWND hWnd, int lParam)
            {
                if (hWnd == shellWindow) return true;
                if (!IsWindowVisible(hWnd)) return true;

                var length = GetWindowTextLength(hWnd);
                if (length == 0) return true;

                var builder = new StringBuilder(length);
                GetWindowText(hWnd, builder, length + 1);

                windows[hWnd] = builder.ToString();
                return true;

            }, 0);

            return windows;
        }

        private delegate bool EnumWindowsProc(HWND hWnd, int lParam);

        [DllImport("USER32.DLL")]
        private static extern bool EnumWindows(EnumWindowsProc enumFunc, int lParam);

        [DllImport("USER32.DLL")]
        private static extern int GetWindowText(HWND hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("USER32.DLL")]
        private static extern int GetWindowTextLength(HWND hWnd);

        [DllImport("USER32.DLL")]
        private static extern bool IsWindowVisible(HWND hWnd);

        [DllImport("USER32.DLL")]
        private static extern IntPtr GetShellWindow();
    }
}
