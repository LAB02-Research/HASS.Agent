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
        [Description("open_cover")]
        [EnumMember(Value = "Open")]
        Open,
        [Description("close_cover")]
        [EnumMember(Value = "Close")]
        Close,
        [Description("media_play")]
        [EnumMember(Value = "Play")]
        Play,
        [Description("media_pause")]
        [EnumMember(Value = "Pause")]
        Pause,
        [Description("media_stop")]
        [EnumMember(Value = "Stop")]
        Stop,
        [Description("toggle")]
        [EnumMember(Value = "Toggle")]
        Toggle
    }
}