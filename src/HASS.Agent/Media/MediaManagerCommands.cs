using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

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
    }
}
