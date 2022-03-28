using System.ComponentModel;
using System.Runtime.Serialization;

namespace HASS.Agent.Enums
{
    public enum HassDomain
    {
        [Description("automation")]
        [EnumMember(Value = "Automation")]
        Automation,
        [Description("climate")]
        [EnumMember(Value = "Climate")]
        Climate,
        [Description("cover")]
        [EnumMember(Value = "Cover")]
        Cover,
        [Description("input_boolean")]
        [EnumMember(Value = "InputBoolean")]
        InputBoolean,
        [Description("light")]
        [EnumMember(Value = "Light")]
        Light,
        [Description("media_player")]
        [EnumMember(Value = "MediaPlayer")]
        MediaPlayer,
        [Description("scene")]
        [EnumMember(Value = "Scene")]
        Scene,
        [Description("script")]
        [EnumMember(Value = "Script")]
        Script,
        [Description("switch")]
        [EnumMember(Value = "Switch")]
        Switch
    }
}