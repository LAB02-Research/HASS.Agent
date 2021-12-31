using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using HASSAgent.Functions;
using HWND = System.IntPtr;

namespace HASSAgent.Models.HomeAssistant.Sensors.GeneralSensors.SingleValue
{
    public class NamedWindowSensor : AbstractSingleValueSensor
    {
        public override string Domain => "binary_sensor";
        public string WindowName { get; protected set; }

        public NamedWindowSensor(string windowName, string name = "NamedWindow", int? updateInterval = 10, string id = default) : base(name ?? "NamedWindow", updateInterval ?? 30, id)
        {
            WindowName = windowName;
        }

        public override DiscoveryConfigModel GetAutoDiscoveryConfig()
        {
            return AutoDiscoveryConfigModel ?? SetAutoDiscoveryConfigModel(new SensorDiscoveryConfigModel()
            {
                Name = Name,
                Unique_id = Id,
                Device = Variables.DeviceConfig,
                State_topic = $"homeassistant/{Domain}/{Variables.DeviceConfig.Name}/{ObjectId}/state",
                Availability_topic = $"homeassistant/sensor/{Variables.DeviceConfig.Name}/availability"
            });
        }

        public override string GetState()
        {
            var windowNames = HelperFunctions.GetOpenWindows().Values;
            return windowNames.Any(v => v.ToUpper().Contains(WindowName.ToUpper())) ? "ON" : "OFF";
        }
    }
}
