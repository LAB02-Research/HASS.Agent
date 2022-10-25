using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HASS.Agent.Functions
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal static class NativeMethods
    {
        internal const uint DEVICE_NOTIFY_WINDOW_HANDLE = 0x0;
        internal const uint DEVICE_NOTIFY_SERVICE_HANDLE = 0x1;
        internal const int WM_POWERBROADCAST = 0x0218;
        internal const int PBT_POWERSETTINGCHANGE = 0x8013;
        internal const int WM_QUERYENDSESSION = 0x11;
        internal const int SM_SHUTTINGDOWN = 0x2000;

        [DllImport("user32.dll")]
        internal static extern int GetSystemMetrics(int smIndex);

        [DllImport("User32.dll", SetLastError = true)]
        internal static extern IntPtr RegisterPowerSettingNotification(IntPtr hWnd, [In] Guid PowerSettingGuid, uint Flags);

        [DllImport("User32.dll", SetLastError = true)]
        internal static extern bool UnregisterPowerSettingNotification(IntPtr hWnd);

        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        internal struct POWERBROADCAST_SETTING
        {
            public Guid PowerSetting;
            public uint DataLength;
            public byte Data;
        }

        [DllImport("advapi32.dll", SetLastError = true)]
        internal static extern bool OpenProcessToken(IntPtr processHandle, uint desiredAccess, out IntPtr tokenHandle);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool CloseHandle(IntPtr hObject);

        internal delegate bool EnumWindowsProc(IntPtr hWnd, int lParam);

        [DllImport("USER32.DLL")]
        internal static extern bool EnumWindows(EnumWindowsProc enumFunc, int lParam);

        [DllImport("USER32.DLL")]
        internal static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("USER32.DLL")]
        internal static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("USER32.DLL")]
        internal static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("USER32.DLL")]
        internal static extern IntPtr GetShellWindow();

        [DllImport("gdi32.dll")]
        internal static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        internal enum DeviceCap
        {
            VERTRES = 10,
            DESKTOPVERTRES = 117,
            LOGPIXELSY = 90

            // http://pinvoke.net/default.aspx/gdi32/GetDeviceCaps.html
        }

        // https://docs.microsoft.com/en-us/windows/win32/power/power-setting-guids
        internal class PowerSettingGuid
        {
            // 0: Powered by AC, 1: Powered by Battery, 2: Powered by short-term source (UPC)
            internal Guid AcdcPowerSource { get; } = new("5d3e9a59-e9D5-4b00-a6bd-ff34ff516548");

            // POWERBROADCAST_SETTING.Data:  1-100
            internal Guid BatteryPercentageRemaining { get; } = new("a7ad8041-b45a-4cae-87a3-eecbb468a9e1");

            // Windows 8+:
            // 0: Monitor Off, 1: Monitor On, 2: Monitor Dimmed
            internal Guid ConsoleDisplayState { get; } = new("6fe69556-704a-47a0-8f24-c28d936fda47");

            // Windows 8+ Session 0 enabled:
            // 0: User providing Input, 2: User Idle
            internal Guid GlobalUserPresence { get; } = new("786E8A1D-B427-4344-9207-09E70BDCBEA9");

            // 0=Monitor Off, 1=Monitor On
            internal Guid MonitorPowerGuid { get; } = new("02731015-4510-4526-99e6-e5a17ebd1aea");

            // 0: Battery Saver Off, 1: Battery Saver On
            internal Guid PowerSavingStatus { get; } = new("E00958C0-C213-4ACE-AC77-FECCED2EEEA5");

            // Windows 8+:
            // 0: Off, 1: On, 2: Dimmed
            internal Guid SessionDisplayStatus { get; } = new("2B84C20E-AD23-4ddf-93DB-05FFBD7EFCA5");

            // Windows 8+, no Session 0:
            // 0: User providing Input, 2: User Idle
            internal Guid SessionUserPresence { get; } = new("3C0F4548-C03F-4c4d-B9F2-237EDE686376");

            // 0: Exiting away mode, 1: Entering away mode
            internal Guid SystemAwaymode { get; } = new("98a7f580-01f7-48aa-9c0f-44352c29e5C0");

            /* Windows 8+ */
            // POWERBROADCAST_SETTING.Data not used
            internal Guid IdleBackgroundTask { get; } = new(0x515C31D8, 0xF734, 0x163D, 0xA0, 0xFD, 0x11, 0xA0, 0x8C, 0x91, 0xE8, 0xF1);
            internal Guid PowerSchemePersonality { get; } = new(0x245D8541, 0x3943, 0x4422, 0xB0, 0x25, 0x13, 0xA7, 0x84, 0xF6, 0x79, 0xB7);

            // The following 3 GUIDs are the POWERBROADCAST_SETTING.Data result of PowerSchemePersonality
            internal Guid MinPowerSavings { get; } = new("8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c");
            internal Guid MaxPowerSavings { get; } = new("a1841308-3541-4fab-bc81-f71556f20b4a");
            internal Guid TypicalPowerSavings { get; } = new("381b4222-f694-41f0-9685-ff5bb260df2e");
        }
    }
}
