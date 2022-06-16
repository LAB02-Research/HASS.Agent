using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Control;
using HASS.Agent.Enums;

namespace HASS.Agent.Extensions
{
    internal static class MediaSessionExtensions
    {
        internal static MediaPlayerState ConvertToMediaPlayerState(this GlobalSystemMediaTransportControlsSessionPlaybackStatus playbackStatus)
        {
            switch (playbackStatus)
            {
                case GlobalSystemMediaTransportControlsSessionPlaybackStatus.Closed:
                    return MediaPlayerState.Idle;

                case GlobalSystemMediaTransportControlsSessionPlaybackStatus.Opened:
                    return MediaPlayerState.Idle;

                case GlobalSystemMediaTransportControlsSessionPlaybackStatus.Changing:
                    return MediaPlayerState.Idle;

                case GlobalSystemMediaTransportControlsSessionPlaybackStatus.Stopped:
                    return MediaPlayerState.Idle;

                case GlobalSystemMediaTransportControlsSessionPlaybackStatus.Playing:
                    return MediaPlayerState.Playing;

                case GlobalSystemMediaTransportControlsSessionPlaybackStatus.Paused:
                    return MediaPlayerState.Paused;

                default:
                    return MediaPlayerState.Idle;
            }
        }
    }
}
