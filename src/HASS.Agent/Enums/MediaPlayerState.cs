using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HASS.Agent.Enums
{
    public enum MediaPlayerState
    {
        [EnumMember(Value = "off")]
        Off,

        [EnumMember(Value = "idle")]
        Idle,

        [EnumMember(Value = "playing")]
        Playing,

        [EnumMember(Value = "paused")]
        Paused
    }
}
