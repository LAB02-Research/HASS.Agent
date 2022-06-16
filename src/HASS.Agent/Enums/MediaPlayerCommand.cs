using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;

namespace HASS.Agent.Enums
{
    public enum MediaPlayerCommand
    {
        [Default]
        [EnumMember(Value = "unknown")]
        Unknown,

        [EnumMember(Value = "volumeup")]
        VolumeUp,

        [EnumMember(Value = "volumedown")]
        VolumeDown,

        [EnumMember(Value = "mute")]
        Mute,

        [EnumMember(Value = "play")]
        Play,

        [EnumMember(Value = "pause")]
        Pause,

        [EnumMember(Value = "stop")]
        Stop,

        [EnumMember(Value = "next")]
        Next,

        [EnumMember(Value = "previous")]
        Previous,
    }
}
