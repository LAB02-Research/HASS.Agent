using System;
using HASSAgent.Enums;
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
            return sensorType != SensorType.StorageSensors && sensorType != SensorType.NetworkSensors;
        }

        /// <summary>
        /// Returns the name of the sensortype
        /// </summary>
        /// <param name="sensorType"></param>
        /// <returns></returns>
        public static string GetSensorName(this SensorType sensorType) => sensorType.ToString().Replace("Sensors", "").Replace("Sensor", "");
    }

    public class ConfiguredSensor
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public SensorType Type { get; set; }
        public Guid Id { get; set; } = Guid.Empty;
        public int? UpdateInterval { get; set; }
        public string Query { get; set; }
        public string WindowName { get; set; }
        public string Name { get; set; }
    }
}
