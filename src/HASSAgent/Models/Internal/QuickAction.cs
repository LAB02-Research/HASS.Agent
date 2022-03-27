using System.Diagnostics.CodeAnalysis;
using HASSAgent.Enums;
using HASSAgent.Models.HomeAssistant;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HASSAgent.Models.Internal
{
    public static class QuickActionExtensions
    {
        public static HassEntity ToHassEntity(this QuickAction quickAction) => new(quickAction.Domain, quickAction.Entity);
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class QuickAction
    {
        public QuickAction()
        {
            //
        }

        public Guid Id { get; set; } = Guid.Empty;

        [JsonConverter(typeof(StringEnumConverter))]
        public HassDomain Domain { get; set; }

        public string Entity { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public HassAction Action { get; set; }

        public bool HotKeyEnabled { get; set; }
        public string HotKey { get; set; }

        public string Description { get; set; }
    }
}
