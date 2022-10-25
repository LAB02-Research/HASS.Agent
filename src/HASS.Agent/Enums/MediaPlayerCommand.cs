using System.Runtime.Serialization;
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
        
        [EnumMember(Value = "play_media")]
        PlayMedia,
        
        [EnumMember(Value = "seek")]
        Seek
    }
}
