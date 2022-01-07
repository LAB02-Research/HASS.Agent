using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using HASSAgent.Enums;
using Serilog;

namespace HASSAgent.Functions
{
    /// <summary>
    /// Sources:
    /// - https://stackoverflow.com/a/36596656
    /// - https://github.com/murrayju/CreateProcessAsUser/blob/master/ProcessExtensions/ProcessExtensions.cs
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedMember.Local")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal static class SessionInfo
    {
        private const int FALSE = 0;

        private static readonly IntPtr WTS_CURRENT_SERVER = IntPtr.Zero;

        private const int WTS_SESSIONSTATE_LOCK = 0;
        private const int WTS_SESSIONSTATE_UNLOCK = 1;

        private static readonly bool OsIsWin7 = false;

        static SessionInfo()
        {
            var osVersion = Environment.OSVersion;
            OsIsWin7 = (osVersion.Platform == PlatformID.Win32NT && osVersion.Version.Major == 6 && osVersion.Version.Minor == 1);
        }

        [DllImport("wtsapi32.dll")]
        private static extern int WTSQuerySessionInformation(
            IntPtr hServer,
            [MarshalAs(UnmanagedType.U4)] uint SessionId,
            [MarshalAs(UnmanagedType.U4)] WTS_INFO_CLASS WTSInfoClass,
            out IntPtr ppBuffer,
            [MarshalAs(UnmanagedType.U4)] out uint pBytesReturned
        );

        [DllImport("wtsapi32.dll")]
        private static extern void WTSFreeMemoryEx(
            WTS_TYPE_CLASS WTSTypeClass,
            IntPtr pMemory,
            uint NumberOfEntries
        );

        private enum WTS_INFO_CLASS
        {
            WTSInitialProgram = 0,
            WTSApplicationName = 1,
            WTSWorkingDirectory = 2,
            WTSOEMId = 3,
            WTSSessionId = 4,
            WTSUserName = 5,
            WTSWinStationName = 6,
            WTSDomainName = 7,
            WTSConnectState = 8,
            WTSClientBuildNumber = 9,
            WTSClientName = 10,
            WTSClientDirectory = 11,
            WTSClientProductId = 12,
            WTSClientHardwareId = 13,
            WTSClientAddress = 14,
            WTSClientDisplay = 15,
            WTSClientProtocolType = 16,
            WTSIdleTime = 17,
            WTSLogonTime = 18,
            WTSIncomingBytes = 19,
            WTSOutgoingBytes = 20,
            WTSIncomingFrames = 21,
            WTSOutgoingFrames = 22,
            WTSClientInfo = 23,
            WTSSessionInfo = 24,
            WTSSessionInfoEx = 25,
            WTSConfigInfo = 26,
            WTSValidationInfo = 27,
            WTSSessionAddressV4 = 28,
            WTSIsRemoteSession = 29
        }

        private enum WTS_TYPE_CLASS
        {
            WTSTypeProcessInfoLevel0,
            WTSTypeProcessInfoLevel1,
            WTSTypeSessionInfoLevel1
        }

        private enum WTS_CONNECTSTATE_CLASS
        {
            WTSActive,
            WTSConnected,
            WTSConnectQuery,
            WTSShadow,
            WTSDisconnected,
            WTSIdle,
            WTSListen,
            WTSReset,
            WTSDown,
            WTSInit
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct WTSINFOEX
        {
            public readonly uint Level;
            private readonly uint Reserved;
            public readonly WTSINFOEX_LEVEL Data;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct WTSINFOEX_LEVEL
        {
            public readonly WTSINFOEX_LEVEL1 WTSInfoExLevel1;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct WTSINFOEX_LEVEL1
        {
            private readonly uint SessionId;
            private readonly WTS_CONNECTSTATE_CLASS SessionState;
            public readonly int SessionFlags;
        }

        [DllImport("wtsapi32.dll", ExactSpelling = true, SetLastError = false)]
        private static extern void WTSFreeMemory(IntPtr memory);

        [DllImport("wtsapi32.dll", SetLastError = true)]
        private static extern int WTSEnumerateSessions(
            IntPtr hServer,
            int Reserved,
            int Version,
            ref IntPtr ppSessionInfo,
            ref int pCount);

        private const uint INVALID_SESSION_ID = 0xFFFFFFFF;
        private static readonly IntPtr WTS_CURRENT_SERVER_HANDLE = IntPtr.Zero;

        [StructLayout(LayoutKind.Sequential)]
        private struct WTS_SESSION_INFO
        {
            public readonly uint SessionID;
            [MarshalAs(UnmanagedType.LPStr)]
            private readonly string pWinStationName;
            public readonly WTS_CONNECTSTATE_CLASS State;
        }

        /// <summary>
        /// Retrieves the active session's lockstate
        /// </summary>
        /// <returns></returns>
        public static LockState GetActiveSessionLockState()
        {
            try
            {
                var activeSessionId = GetActiveUserId();
                if (activeSessionId == INVALID_SESSION_ID) return LockState.Unknown;

                var result = WTSQuerySessionInformation(
                    WTS_CURRENT_SERVER,
                    activeSessionId,
                    WTS_INFO_CLASS.WTSSessionInfoEx,
                    out var ppBuffer,
                    out _
                );

                if (result == FALSE) return LockState.Unknown;

                var sessionInfoEx = Marshal.PtrToStructure<WTSINFOEX>(ppBuffer);

                if (sessionInfoEx.Level != 1)
                {
                    WTSFreeMemory(ppBuffer);
                    return LockState.Unknown;
                }

                var lockState = sessionInfoEx.Data.WTSInfoExLevel1.SessionFlags;
                WTSFreeMemory(ppBuffer);

                if (OsIsWin7)
                {
                    /* Ref: https://msdn.microsoft.com/en-us/library/windows/desktop/ee621019(v=vs.85).aspx
                    * Windows Server 2008 R2 and Windows 7:  Due to a code defect, the usage of the WTS_SESSIONSTATE_LOCK
                    * and WTS_SESSIONSTATE_UNLOCK flags is reversed. That is, WTS_SESSIONSTATE_LOCK indicates that the
                    * session is unlocked, and WTS_SESSIONSTATE_UNLOCK indicates the session is locked.
                    * */
                    switch (lockState)
                    {
                        case WTS_SESSIONSTATE_LOCK:
                            return LockState.Unlocked;

                        case WTS_SESSIONSTATE_UNLOCK:
                            return LockState.Locked;

                        default:
                            return LockState.Unknown;
                    }
                }

                switch (lockState)
                {
                    case WTS_SESSIONSTATE_LOCK:
                        return LockState.Locked;

                    case WTS_SESSIONSTATE_UNLOCK:
                        return LockState.Unlocked;

                    default:
                        return LockState.Unknown;
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SESSION] Error retrieving the active session state: {err}", ex.Message);
                return LockState.Unknown;
            }
        }

        private static uint GetActiveUserId()
        {
            var activeSessionId = INVALID_SESSION_ID;

            try
            {
                var pSessionInfo = IntPtr.Zero;
                var sessionCount = 0;

                // get a handle to the user access token for the current active session
                if (WTSEnumerateSessions(WTS_CURRENT_SERVER_HANDLE, 0, 1, ref pSessionInfo, ref sessionCount) == 0) return activeSessionId;

                var arrayElementSize = Marshal.SizeOf(typeof(WTS_SESSION_INFO));
                var current = pSessionInfo;

                for (var i = 0; i < sessionCount; i++)
                {
                    var si = (WTS_SESSION_INFO)Marshal.PtrToStructure(current, typeof(WTS_SESSION_INFO));
                    current += arrayElementSize;

                    // we only want the active session
                    if (si.State != WTS_CONNECTSTATE_CLASS.WTSActive) continue;

                    activeSessionId = si.SessionID;
                    break;
                }

                return activeSessionId;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SESSION] Error retrieving the active user ID: {err}", ex.Message);
                return activeSessionId;
            }
        }
    }
}
