using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HASSAgent.Sensors;
using HASSAgent.Shared.Enums;
using HASSAgent.Shared.Extensions;
using HASSAgent.Shared.Functions;
using HASSAgent.Shared.Models.Config;

namespace HASSAgent.Extensions
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

        /// <summary>
        /// Returns the name of the sensortype
        /// </summary>
        /// <param name="sensorType"></param>
        /// <returns></returns>
        public static string GetSensorName(this SensorType sensorType)
        {
            var sensorName = sensorType.ToString().ToLower().Replace("sensors", "").Replace("sensor", "");
            return $"{SharedHelperFunctions.GetSafeConfiguredDeviceName()}_{sensorName}";
        }
    }
}
