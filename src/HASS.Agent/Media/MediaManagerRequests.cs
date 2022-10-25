using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreAudio;
using Serilog;

namespace HASS.Agent.Media
{
    internal static class MediaManagerRequests
    {
        /// <summary>
        /// Gets the volume for the default audio device
        /// </summary>
        /// <returns></returns>
        internal static int GetVolume()
        {
            try
            {
                // get the default audio device
                using var audioDevice = Variables.AudioDeviceEnumerator.GetDefaultAudioEndpoint(DataFlow.eRender, Role.Multimedia);

                // get default device volume
                var volume = (int)(audioDevice.AudioEndpointVolume?.MasterVolumeLevelScalar * 100 ?? 0);

                // Log.Debug("[MEDIA] Current volume: {vol}", volume);

                // return it
                return volume;
            }
            catch (Exception ex)
            {
                Log.Error("[MEDIA] Unable to get the volume: {err}", ex.Message);
                return 0;
            }
        }

        /// <summary>
        /// Gets the muted state for the default audio device
        /// </summary>
        /// <returns></returns>
        internal static bool GetMuteState()
        {
            try
            {
                // get the default audio device
                using var audioDevice = Variables.AudioDeviceEnumerator.GetDefaultAudioEndpoint(DataFlow.eRender, Role.Multimedia);

                // get mute state
                var muted = audioDevice.AudioEndpointVolume?.Mute ?? false;

                // Log.Debug("[MEDIA] Muted: {mute}", muted);

                // return it
                return muted;
            }
            catch (Exception ex)
            {
                Log.Error("[MEDIA] Unable to get the mute state: {err}", ex.Message);
                return false;
            }
        }
    }
}
