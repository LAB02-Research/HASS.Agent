using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Windows.Forms;
using ByteSizeLib;
using HASSAgent.Functions;
using HASSAgent.Models.HomeAssistant.Sensors.GeneralSensors.MultiValue.DataTypes;
using Newtonsoft.Json;
using Serilog;

namespace HASSAgent.Models.HomeAssistant.Sensors.GeneralSensors.MultiValue
{
    public class DisplaySensors : AbstractMultiValueSensor
    {
        private readonly int _updateInterval;

        public sealed override Dictionary<string, AbstractSingleValueSensor> Sensors { get; protected set; } = new Dictionary<string, AbstractSingleValueSensor>();
        
        public DisplaySensors(int? updateInterval = null, string name = "display", string id = default) : base(name ?? "display", updateInterval ?? 30, id)
        {
            _updateInterval = updateInterval ?? 30;

            UpdateSensorValues();
        }

        public sealed override void UpdateSensorValues()
        {
            // lowercase and safe name of the multivalue sensor
            var parentSensorSafeName = HelperFunctions.GetSafeValue(Name);

            // fetch the latest battery state
            var displayInfo = Screen.AllScreens;

            // prepare the data
            var primaryDisplayStr = string.Empty;
            var primaryDisplay = displayInfo.FirstOrDefault(x => x.Primary);
            if (primaryDisplay != null) primaryDisplayStr = primaryDisplay.DeviceName;

            // display count sensor
            var displayCount = displayInfo.Length;

            var displayCountId = $"{parentSensorSafeName}_display_count";
            var displayCountSensor = new DataTypeIntSensor(_updateInterval, $"{Name} Display Count", displayCountId, string.Empty, "mdi:monitor", string.Empty, Name);
            displayCountSensor.SetState(displayCount);

            if (!Sensors.ContainsKey(displayCountId)) Sensors.Add(displayCountId, displayCountSensor);
            else Sensors[displayCountId] = displayCountSensor;

            // nothing to do if there aren't any displays
            if (displayCount == 0) return;

            // primary display sensor
            var primaryDisplayId = $"{parentSensorSafeName}_primary_display";
            var primaryDisplaySensor = new DataTypeStringSensor(_updateInterval, $"{Name} Primay Display", primaryDisplayId, string.Empty, "mdi:monitor", string.Empty, Name);
            primaryDisplaySensor.SetState(primaryDisplayStr);

            if (!Sensors.ContainsKey(primaryDisplayId)) Sensors.Add(primaryDisplayId, primaryDisplaySensor);
            else Sensors[primaryDisplayId] = primaryDisplaySensor;

            // process all monitors
            foreach (var display in displayInfo)
            {
                // id
                var id = HelperFunctions.GetSafeValue(display.DeviceName);
                if (string.IsNullOrWhiteSpace(id)) continue;

                // name
                var name = display.DeviceName;

                var nameId = $"{parentSensorSafeName}_{id}_name";
                var nameSensor = new DataTypeStringSensor(_updateInterval, $"{Name} {name} Name", nameId, string.Empty, "mdi:monitor", string.Empty, Name);
                nameSensor.SetState(name);

                if (!Sensors.ContainsKey(nameId)) Sensors.Add(nameId, nameSensor);
                else Sensors[nameId] = nameSensor;

                // resolution
                var resolution = $"{display.Bounds.Width}x{display.Bounds.Height}";

                var resolutionId = $"{parentSensorSafeName}_{id}_resolution";
                var resolutionSensor = new DataTypeStringSensor(_updateInterval, $"{Name} {name} Resolution", resolutionId, string.Empty, "mdi:monitor", string.Empty, Name);
                resolutionSensor.SetState(resolution);

                if (!Sensors.ContainsKey(resolutionId)) Sensors.Add(resolutionId, resolutionSensor);
                else Sensors[resolutionId] = resolutionSensor;

                // bit
                var bit = display.BitsPerPixel;

                var bitId = $"{parentSensorSafeName}_{id}_bit";
                var bitSensor = new DataTypeIntSensor(_updateInterval, $"{Name} {name} Bits Per Pixel", bitId, string.Empty, "mdi:monitor", string.Empty, Name);
                bitSensor.SetState(bit);

                if (!Sensors.ContainsKey(bitId)) Sensors.Add(bitId, bitSensor);
                else Sensors[bitId] = bitSensor;
            }
        }

        public override DiscoveryConfigModel GetAutoDiscoveryConfig() => null;
    }
}
