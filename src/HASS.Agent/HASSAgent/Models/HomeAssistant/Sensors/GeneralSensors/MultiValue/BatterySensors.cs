using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Windows.Forms;
using ByteSizeLib;
using HASSAgent.Functions;
using HASSAgent.Models.HomeAssistant.Sensors.GeneralSensors.MultiValue.DataTypes;
using Newtonsoft.Json;
using Serilog;

namespace HASSAgent.Models.HomeAssistant.Sensors.GeneralSensors.MultiValue
{
    public class BatterySensors : AbstractMultiValueSensor
    {
        private readonly int _updateInterval;

        public sealed override Dictionary<string, AbstractSingleValueSensor> Sensors { get; protected set; } = new Dictionary<string, AbstractSingleValueSensor>();
        
        public BatterySensors(int? updateInterval = null, string name = "battery", string id = default) : base(name ?? "battery", updateInterval ?? 30, id)
        {
            _updateInterval = updateInterval ?? 30;

            UpdateSensorValues();
        }

        public sealed override void UpdateSensorValues()
        {
            // lowercase and safe name of the multivalue sensor
            var parentSensorSafeName = HelperFunctions.GetSafeValue(Name);

            // fetch the latest battery state
            var powerStatus = SystemInformation.PowerStatus;

            // prepare the data
            var lifetimeMinutes = powerStatus.BatteryFullLifetime;
            if (lifetimeMinutes != -1) lifetimeMinutes = Convert.ToInt32(Math.Round(TimeSpan.FromSeconds(lifetimeMinutes).TotalMinutes));

            var remainingMinutes = powerStatus.BatteryLifeRemaining;
            if (remainingMinutes != -1) remainingMinutes = Convert.ToInt32(Math.Round(TimeSpan.FromSeconds(remainingMinutes).TotalMinutes));
            
            // charge status sensor
            var chargeStatus = powerStatus.BatteryChargeStatus.ToString();

            var chargeStatusId = $"{parentSensorSafeName}_charge_status";
            var chargeStatusSensor = new DataTypeStringSensor(_updateInterval, $"{Name} Charge Status", chargeStatusId, string.Empty, "mdi:battery-charging", string.Empty, Name);
            chargeStatusSensor.SetState(chargeStatus);

            if (!Sensors.ContainsKey(chargeStatusId)) Sensors.Add(chargeStatusId, chargeStatusSensor);
            else Sensors[chargeStatusId] = chargeStatusSensor;

            // full charge lifetime sensor
            var fullChargeLifetimeMinutes = lifetimeMinutes;

            var fullChargeLifetimeId = $"{parentSensorSafeName}_full_charge_lifetime";
            var fullChargeLifetimeSensor = new DataTypeIntSensor(_updateInterval, $"{Name} Full Charge Lifetime", fullChargeLifetimeId, string.Empty, "mdi:battery-high", string.Empty, Name);
            fullChargeLifetimeSensor.SetState(fullChargeLifetimeMinutes);

            if (!Sensors.ContainsKey(fullChargeLifetimeId)) Sensors.Add(fullChargeLifetimeId, fullChargeLifetimeSensor);
            else Sensors[fullChargeLifetimeId] = fullChargeLifetimeSensor;

            // charge remaining percentage sensor
            var chargeRemainingPercentage = Convert.ToInt32(powerStatus.BatteryLifePercent * 100);

            var chargeRemainingPercentageId = $"{parentSensorSafeName}_charge_remaining_percentage";
            var chargeRemainingPercentageSensor = new DataTypeIntSensor(_updateInterval, $"{Name} Charge Remaining Percentage", chargeRemainingPercentageId, string.Empty, "mdi:battery-high", "%", Name);
            chargeRemainingPercentageSensor.SetState(chargeRemainingPercentage);

            if (!Sensors.ContainsKey(chargeRemainingPercentageId)) Sensors.Add(chargeRemainingPercentageId, chargeRemainingPercentageSensor);
            else Sensors[chargeRemainingPercentageId] = chargeRemainingPercentageSensor;

            // charge remaining minutes sensor
            var chargeRemainingMinutes = remainingMinutes;

            var chargeRemainingMinutesId = $"{parentSensorSafeName}_charge_remaining";
            var chargeRemainingMinutesSensor = new DataTypeIntSensor(_updateInterval, $"{Name} Charge Remaining", chargeRemainingMinutesId, string.Empty, "mdi:battery-high", string.Empty, Name);
            chargeRemainingMinutesSensor.SetState(chargeRemainingMinutes);

            if (!Sensors.ContainsKey(chargeRemainingMinutesId)) Sensors.Add(chargeRemainingMinutesId, chargeRemainingMinutesSensor);
            else Sensors[chargeRemainingMinutesId] = chargeRemainingMinutesSensor;

            // powerline status sensor
            var powerlineStatus = powerStatus.PowerLineStatus.ToString();

            var powerlineStatusId = $"{parentSensorSafeName}_powerline_status";
            var powerlineStatusSensor = new DataTypeStringSensor(_updateInterval, $"{Name} Powerline Status", powerlineStatusId, string.Empty, "mdi:power-plug", string.Empty, Name);
            powerlineStatusSensor.SetState(powerlineStatus);

            if (!Sensors.ContainsKey(powerlineStatusId)) Sensors.Add(powerlineStatusId, powerlineStatusSensor);
            else Sensors[powerlineStatusId] = powerlineStatusSensor;
        }

        public override DiscoveryConfigModel GetAutoDiscoveryConfig() => null;
    }
}
