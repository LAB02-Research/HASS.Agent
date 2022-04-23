using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HASS.Agent.Sensors;
using HASS.Agent.Shared.Enums;
using HASS.Agent.Shared.Extensions;
using HASS.Agent.Shared.Functions;
using HASS.Agent.Shared.Models.Config;

namespace HASS.Agent.Extensions
{
    /// <summary>
    /// Extensions for HASS.Agent sensor objects
    /// </summary>
    public static class SensorExtensions
    {
        /// <summary>
        /// Returns TRUE if the configured sensor is single-value
        /// </summary>
        /// <param name="configuredSensor"></param>
        /// <returns></returns>
        public static bool IsSingleValue(this ConfiguredSensor configuredSensor) => configuredSensor.Type.IsSingleValue();

        /// <summary>
        /// Returns TRUE if the sensor-type is single-value
        /// </summary>
        /// <param name="sensorType"></param>
        /// <returns></returns>
        public static bool IsSingleValue(this SensorType sensorType) => !SensorsManager.SensorInfoCards[sensorType].MultiValue;
    }
}
