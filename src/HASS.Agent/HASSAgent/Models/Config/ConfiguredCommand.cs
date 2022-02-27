using System;
using HASSAgent.Enums;
using HASSAgent.Functions;
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
        public static string GetCommandName(this CommandType commandType)
        {
            var commandName = commandType.ToString().ToLower().Replace("command", "");
            return $"{HelperFunctions.GetSafeConfiguredDeviceName()}_{commandName}";
        }
    }

    public class ConfiguredCommand
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public CommandType Type { get; set; }
        public Guid Id { get; set; } = Guid.Empty;
        public string Command { get; set; }
        public byte KeyCode { get; set; }
        public bool RunAsLowIntegrity { get; set; } = false;
        public string Name { get; set; }
    }
}
