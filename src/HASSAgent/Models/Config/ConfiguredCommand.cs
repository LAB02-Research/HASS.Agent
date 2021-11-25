using System;
using HASSAgent.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HASSAgent.Models.Config
{
    public class ConfiguredCommand
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public CommandType Type { get; set; }
        public Guid Id { get; set; } = Guid.Empty;
        public string Command { get; set; }
        public byte KeyCode { get; set; }
        public string Name { get; set; }
    }
}
