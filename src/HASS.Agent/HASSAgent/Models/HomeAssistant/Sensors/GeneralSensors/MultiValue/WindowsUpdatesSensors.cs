using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using ByteSizeLib;
using HASSAgent.Functions;
using HASSAgent.Models.HomeAssistant.Sensors.GeneralSensors.MultiValue.DataTypes;
using Newtonsoft.Json;
using Serilog;

namespace HASSAgent.Models.HomeAssistant.Sensors.GeneralSensors.MultiValue
{
    public class WindowsUpdatesSensors : AbstractMultiValueSensor
    {
        private readonly int _updateInterval;

        public sealed override Dictionary<string, AbstractSingleValueSensor> Sensors { get; protected set; } = new Dictionary<string, AbstractSingleValueSensor>();
        
        public WindowsUpdatesSensors(int? updateInterval = null, string name = "windowsupdates", string id = default) : base(name ?? "windowsupdates", updateInterval ?? 900, id)
        {
            _updateInterval = updateInterval ?? 900;

            UpdateSensorValues();
        }

        public sealed override void UpdateSensorValues()
        {
            // lowercase and safe name of the multivalue sensor
            var parentSensorSafeName = HelperFunctions.GetSafeValue(Name);

            // fetch the latest updates
            var (driverUpdates, softwareUpdates) = WindowsUpdatesManager.GetAvailableUpdates();

            // driver update count
            var driverUpdateCount = driverUpdates.Count;

            var driverUpdateCountId = $"{parentSensorSafeName}_driver_updates_pending";
            var driverUpdateCountSensor = new DataTypeIntSensor(_updateInterval, $"{Name} Driver Updates Pending", driverUpdateCountId, string.Empty, "mdi:microsoft-windows", string.Empty, Name);
            driverUpdateCountSensor.SetState(driverUpdateCount);

            if (!Sensors.ContainsKey(driverUpdateCountId)) Sensors.Add(driverUpdateCountId, driverUpdateCountSensor);
            else Sensors[driverUpdateCountId] = driverUpdateCountSensor;

            // software update count
            var softwareUpdateCount = softwareUpdates.Count;

            var softwareUpdateCountId = $"{parentSensorSafeName}_software_updates_pending";
            var softwareUpdateCountSensor = new DataTypeIntSensor(_updateInterval, $"{Name} Software Updates Pending", softwareUpdateCountId, string.Empty, "mdi:microsoft-windows", string.Empty, Name);
            softwareUpdateCountSensor.SetState(softwareUpdateCount);

            if (!Sensors.ContainsKey(softwareUpdateCountId)) Sensors.Add(softwareUpdateCountId, softwareUpdateCountSensor);
            else Sensors[softwareUpdateCountId] = softwareUpdateCountSensor;

            // driver updates array
            // todo
            //var driverUpdatesStr = JsonConvert.SerializeObject(driverUpdates, Formatting.Indented);
            
            //var driverUpdatesId = $"{parentSensorSafeName}_driver_updates";

            //var driverUpdatesSensor = new DataTypeStringSensor(_updateInterval, $"{Name} Available Driver Updates", driverUpdatesId, string.Empty, "mdi:microsoft-windows", string.Empty, Name);
            //driverUpdatesSensor.SetState(driverUpdatesStr);

            //if (!Sensors.ContainsKey(driverUpdatesId)) Sensors.Add(driverUpdatesId, driverUpdatesSensor);
            //else Sensors[driverUpdatesId] = driverUpdatesSensor;

            // software updates array
            // todo
            //var softwareUpdatesStr = JsonConvert.SerializeObject(softwareUpdates, Formatting.Indented);

            //var softwareUpdatesId = $"{parentSensorSafeName}_software_updates";

            //var softwareUpdatesSensor = new DataTypeStringSensor(_updateInterval, $"{Name} Available Software Updates", softwareUpdatesId, string.Empty, "mdi:microsoft-windows", string.Empty, Name);
            //softwareUpdatesSensor.SetState(softwareUpdatesStr);

            //if (!Sensors.ContainsKey(softwareUpdatesId)) Sensors.Add(softwareUpdatesId, softwareUpdatesSensor);
            //else Sensors[softwareUpdatesId] = softwareUpdatesSensor;

            // all done!
        }

        public override DiscoveryConfigModel GetAutoDiscoveryConfig() => null;
    }
}
