using CoreAudio;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Serilog;
using Google.Protobuf.WellKnownTypes;

namespace HASS.Agent.Media
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal static class MediaManagerCommands
    {
        [DllImport("user32.dll")]
        private static extern void keybd_event(byte virtualKey, byte scanCode, uint flags, IntPtr extraInfo);

        private const int KEYEVENTF_EXTENTEDKEY = 1;
        private const int KEYEVENTF_KEYUP = 0;
        private const int VK_MEDIA_NEXT_TRACK = 0xB0;
        private const int VK_MEDIA_PLAY_PAUSE = 0xB3;
        private const int VK_MEDIA_PREV_TRACK = 0xB1;
        private const int VK_MEDIA_STOP = 0xB2;
        private const int VK_VOLUME_MUTE = 0xAD;
        private const int VK_VOLUME_UP = 0xAF;
        private const int VK_VOLUME_DOWN = 0xAE;

        internal static void VolumeUp() => keybd_event(VK_VOLUME_UP, 0, KEYEVENTF_EXTENTEDKEY, IntPtr.Zero);

        internal static void VolumeDown() => keybd_event(VK_VOLUME_DOWN, 0, KEYEVENTF_EXTENTEDKEY, IntPtr.Zero);

        internal static void Mute() => keybd_event(VK_VOLUME_MUTE, 0, KEYEVENTF_EXTENTEDKEY, IntPtr.Zero);

        internal static void Play() => keybd_event(VK_MEDIA_PLAY_PAUSE, 0, KEYEVENTF_EXTENTEDKEY, IntPtr.Zero);

        internal static void Pause() => keybd_event(VK_MEDIA_PLAY_PAUSE, 0, KEYEVENTF_EXTENTEDKEY, IntPtr.Zero);

        internal static void Stop() => keybd_event(VK_MEDIA_STOP, 0, KEYEVENTF_EXTENTEDKEY, IntPtr.Zero);

        internal static void Next() => keybd_event(VK_MEDIA_NEXT_TRACK, 0, KEYEVENTF_EXTENTEDKEY, IntPtr.Zero);

        internal static void Previous() => keybd_event(VK_MEDIA_PREV_TRACK, 0, KEYEVENTF_EXTENTEDKEY, IntPtr.Zero);

        /// <summary>
        /// Sets the volume to the provided value (0-100)
        /// </summary>
        /// <param name="volume"></param>
        internal static void SetVolume(int volume)
        {
            try
            {
                if (volume < 0) volume = 0;
                if (volume > 100) volume = 100;

                var fVolume = volume / 100.0f;

                // get the current default endpoint
                using var audioDevice = Variables.AudioDeviceEnumerator?.GetDefaultAudioEndpoint(DataFlow.eRender, Role.Multimedia);
                if (audioDevice?.AudioEndpointVolume == null)
                {
                    Log.Warning("[MEDIA] Unable to set volume, no default audio endpoint found");
                    return;
                }

                // all good, set the volume
                audioDevice.AudioEndpointVolume.MasterVolumeLevelScalar = fVolume;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[MEDIA] Error while trying to set volume to {val}: {err}", volume, ex.Message);
            }
        }
    }
}
