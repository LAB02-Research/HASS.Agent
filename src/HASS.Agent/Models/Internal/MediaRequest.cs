using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HASS.Agent.Enums;

namespace HASS.Agent.Models.Internal
{
    public class MediaRequest
    {
        public MediaRequest()
        {
            //
        }

        public MediaRequest SetRequest(MediaPlayerRequest request)
        {
            RequestType = MediaRequestType.Request;
            Request = request;

            return this;
        }

        public MediaRequest SetCommand(MediaPlayerCommand command)
        {
            RequestType = MediaRequestType.Command;
            Command = command;

            return this;
        }

        public MediaRequest SetPlayMedia(string mediaUri)
        {
            RequestType = MediaRequestType.PlayMedia;
            MediaUri = mediaUri;

            return this;
        }

        public MediaRequestType RequestType { get; set; } = MediaRequestType.Unknown;
        public MediaPlayerRequest Request { get; set; } = MediaPlayerRequest.Unknown;
        public MediaPlayerCommand Command { get; set; } = MediaPlayerCommand.Unknown;
        public string MediaUri { get; set; } = string.Empty;
    }
}
