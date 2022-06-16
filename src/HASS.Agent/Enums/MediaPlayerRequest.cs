using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;

namespace HASS.Agent.Enums
{
    public enum MediaPlayerRequest
    {
        [Default]
        [EnumMember(Value = "unknown")]
        Unknown,

        [EnumMember(Value = "muted")]
        Muted,

        [EnumMember(Value = "volume")]
        Volume,

        [EnumMember(Value = "playing")]
        Playing,

        [EnumMember(Value = "state")]
        State
    }
}
