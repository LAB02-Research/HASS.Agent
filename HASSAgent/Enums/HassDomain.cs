using System.ComponentModel;
using System.Runtime.Serialization;

namespace HASSAgent.Enums
{
    public enum HassDomain
    {
        [Description("automation")]
        [EnumMember(Value = "Automation")]
        Automation,
        [Description("script")]
        [EnumMember(Value = "Script")]
        Script,
        [Description("input_boolean")]
        [EnumMember(Value = "InputBoolean")]
        InputBoolean,
        [Description("scene")]
        [EnumMember(Value = "Scene")]
        Scene,
        [Description("switch")]
        [EnumMember(Value = "Switch")]
        Switch,
        [Description("light")]
        [EnumMember(Value = "Light")]
        Light
    }
}