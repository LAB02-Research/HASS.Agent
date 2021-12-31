using System;
using HASSAgent.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HASSAgent.Models.Config
{
    public static class CommandExtensions
    {
        /// <summary>
        /// Returns the name of the commandtype
        /// </summary>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public static string GetCommandName(this CommandType commandType) => commandType.ToString().Replace("Command", "");
    }

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
