using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;

namespace HASS.Agent.Enums
{
    public enum MediaRequestType
    {
        [Default]
        [EnumMember(Value = "unknown")]
        Unknown,

        [EnumMember(Value = "request")]
        Request,

        [EnumMember(Value = "command")]
        Command,

        [EnumMember(Value = "play_media")]
        PlayMedia,
    }
}
