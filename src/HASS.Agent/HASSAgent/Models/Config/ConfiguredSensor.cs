using System;
using HASSAgent.Enums;
using HASSAgent.Functions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HASSAgent.Models.Config
{
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
        public static bool IsSingleValue(this SensorType sensorType)
        {
            return sensorType != SensorType.StorageSensors
                   && sensorType != SensorType.NetworkSensors
                   && sensorType != SensorType.WindowsUpdatesSensors
                   && sensorType != SensorType.BatterySensors;
        }

        /// <summary>
        /// Returns the name of the sensortype
        /// </summary>
        /// <param name="sensorType"></param>
        /// <returns></returns>
        public static string GetSensorName(this SensorType sensorType)
        {
            var sensorName = sensorType.ToString().ToLower().Replace("sensors", "").Replace("sensor", "");
            return $"{HelperFunctions.GetSafeConfiguredDeviceName()}_{sensorName}";
        }
    }

    public class ConfiguredSensor
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public SensorType Type { get; set; }
        public Guid Id { get; set; } = Guid.Empty;
        public int? UpdateInterval { get; set; }
        public string Query { get; set; }
        public string WindowName { get; set; }
        public string Category { get; set; }
        public string Counter { get; set; }
        public string Instance { get; set; }
        public string Name { get; set; }
    }
}
