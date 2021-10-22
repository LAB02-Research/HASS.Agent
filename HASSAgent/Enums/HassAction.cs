using System.ComponentModel;
using System.Runtime.Serialization;

namespace HASSAgent.Enums
{
    public enum HassAction
    {
        [Description("turn_on")]
        [EnumMember(Value = "On")]
        On,
        [Description("turn_off")]
        [EnumMember(Value = "Off")]
        Off,
        [Description("toggle")]
        [EnumMember(Value = "Toggle")]
        Toggle
    }
}