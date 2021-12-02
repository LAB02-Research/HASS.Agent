using System;
using HASSAgent.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HASSAgent.Models.Config
{
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
