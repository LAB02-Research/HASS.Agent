using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text;
using HASSAgent.Functions;
using Newtonsoft.Json;
using Serilog;

namespace HASSAgent.Models.HomeAssistant.Sensors.GeneralSensors.SingleValue
{
    public class LoggedUsersSensor : AbstractSingleValueSensor
    {
        public LoggedUsersSensor(int? updateInterval = null, string name = "loggedusers", string id = default) : base(name ?? "loggedusers", updateInterval ?? 30, id) { }

        public override DiscoveryConfigModel GetAutoDiscoveryConfig()
        {
            return AutoDiscoveryConfigModel ?? SetAutoDiscoveryConfigModel(new SensorDiscoveryConfigModel()
            {
                Name = Name,
                Unique_id = Id,
                Device = Variables.DeviceConfig,
                State_topic = $"{Variables.AppSettings.MqttDiscoveryPrefix}/{Domain}/{Variables.DeviceConfig.Name}/{ObjectId}/state",
                Icon = "mdi:account-group",
                Availability_topic = $"{Variables.AppSettings.MqttDiscoveryPrefix}/{Domain}/{Variables.DeviceConfig.Name}/availability"
            });
        }

        public override string GetState() => JsonConvert.SerializeObject(GetLoggedUsers());

        private static IEnumerable<string> GetLoggedUsers()
        {
            var loggedInUsers = new List<string>();

            var serverHandle = WTSOpenServer(Environment.MachineName);
            var sessionInfoPtr = IntPtr.Zero;

            try
            {
                var sessionCount = 0;
                var retVal = WTSEnumerateSessions(serverHandle, 0, 1, ref sessionInfoPtr, ref sessionCount);
                var dataSize = Marshal.SizeOf(typeof(Cassia.Impl.WTS_SESSION_INFO));
                var currentSession = sessionInfoPtr;

                if (retVal == 0)
                {
                    // nothing found, or error'd out
                    return GetLoggedUsersBackup();
                }

                for (var i = 0; i < sessionCount; i++)
                {
                    var si = (Cassia.Impl.WTS_SESSION_INFO)Marshal.PtrToStructure(currentSession, typeof(Cassia.Impl.WTS_SESSION_INFO));
                    currentSession += dataSize;

                    WTSQuerySessionInformation(serverHandle, si.SessionID, WTS_INFO_CLASS.WTSUserName, out var userPtr, out _);

                    try
                    {
                        var user = Marshal.PtrToStringAnsi(userPtr)?.Trim();
                        if (string.IsNullOrEmpty(user)) continue;

                        if (!loggedInUsers.Contains(user)) loggedInUsers.Add(user);
                    }
                    finally
                    {
                        WTSFreeMemory(userPtr);
                    }
                }

                return loggedInUsers;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[ACTIVEUSERS] Error while fetching logged users: {err}", ex.Message);
                return loggedInUsers;
            }
            finally
            {
                WTSFreeMemory(sessionInfoPtr);
                WTSCloseServer(serverHandle);
            }
        }

        private static IEnumerable<string> GetLoggedUsersBackup()
        {
            var loggedInUsers = new List<string>();

            try
            {
                var explorers = Process.GetProcessesByName("explorer");
                foreach (var explorer in explorers)
                {
                    try
                    {
                        var owner = HelperFunctions.GetProcessOwner(explorer, false);
                        if (string.IsNullOrEmpty(owner)) continue;

                        if (!loggedInUsers.Contains(owner)) loggedInUsers.Add(owner);
                    }
                    finally
                    {
                        explorer?.Dispose();
                    }
                }

                return loggedInUsers;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[ACTIVEUSERS] Error while fetching logged users: {err}", ex.Message);
                return loggedInUsers;
            }
        }

        #region IMPORTS
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Local")]
        private readonly struct SystemPowerCapabilities
        {
            [MarshalAs(UnmanagedType.U1)] internal readonly bool PowerButtonPresent;
            [MarshalAs(UnmanagedType.U1)] internal readonly bool SleepButtonPresent;
            [MarshalAs(UnmanagedType.U1)] internal readonly bool LidPresent;
            [MarshalAs(UnmanagedType.U1)] internal readonly bool SystemS1;
            [MarshalAs(UnmanagedType.U1)] internal readonly bool SystemS2;
            [MarshalAs(UnmanagedType.U1)] internal readonly bool SystemS3;
            [MarshalAs(UnmanagedType.U1)] internal readonly bool SystemS4;
            [MarshalAs(UnmanagedType.U1)] internal readonly bool SystemS5;
            [MarshalAs(UnmanagedType.U1)] internal readonly bool HiberFilePresent;
            [MarshalAs(UnmanagedType.U1)] internal readonly bool FullWake;
            [MarshalAs(UnmanagedType.U1)] internal readonly bool VideoDimPresent;
            [MarshalAs(UnmanagedType.U1)] internal readonly bool ApmPresent;
            [MarshalAs(UnmanagedType.U1)] internal readonly bool UpsPresent;
            [MarshalAs(UnmanagedType.U1)] internal readonly bool ThermalControl;
            [MarshalAs(UnmanagedType.U1)] internal readonly bool ProcessorThrottle;
            private readonly byte ProcessorMinThrottle;
            private readonly byte ProcessorMaxThrottle;
            [MarshalAs(UnmanagedType.U1)] internal readonly bool FastSystemS4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] internal readonly byte[] spare2;
            [MarshalAs(UnmanagedType.U1)] internal readonly bool DiskSpinDown;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)] internal readonly byte[] spare3;
            [MarshalAs(UnmanagedType.U1)] internal readonly bool SystemBatteriesPresent;
            [MarshalAs(UnmanagedType.U1)] internal readonly bool BatteriesAreShortTerm;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] internal readonly BatteryReportingScale[] BatteryScale;
            private readonly SystemPowerState AcOnLineWake;
            private readonly SystemPowerState SoftLidWake;
            private readonly SystemPowerState RtcWake;
            private readonly SystemPowerState MinDeviceWakeState;
            private readonly SystemPowerState DefaultLowLatencyWake;
        }

        internal struct BatteryReportingScale
        {
            internal ulong Granularity;
            internal ulong Capacity;
        }

        internal enum SystemPowerState
        {
            PowerSystemUnspecified = 0,
            PowerSystemWorking = 1,
            PowerSystemSleeping1 = 2,
            PowerSystemSleeping2 = 3,
            PowerSystemSleeping3 = 4,
            PowerSystemHibernate = 5,
            PowerSystemShutdown = 6,
            PowerSystemMaximum = 7
        }

        [DllImport("powrprof.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetPwrCapabilities(out SystemPowerCapabilities systemPowerCapabilites);

        private static SystemPowerCapabilities SystemPowerCapabilites;

        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool GetTokenInformation(IntPtr tokenHandle, TokenInformationClass tokenInformationClass,
            IntPtr tokenInformation, int tokenInformationLength, out int returnLength);

        private enum TokenInformationClass
        {
            TokenElevationType
        }

        private enum TokenElevationType
        {
            TokenElevationTypeDefault = 1,
            TokenElevationTypeFull,
            TokenElevationTypeLimited
        }

        [DllImport("user32.dll", EntryPoint = ("GetSystemMetrics"))]
        private static extern int GetSystemMetrics(int nIndex);


        // Ingelogde Users imports
        [DllImport("wtsapi32.dll")]
        private static extern IntPtr WTSOpenServer([MarshalAs(UnmanagedType.LPStr)] string pServerName);

        [DllImport("wtsapi32.dll")]
        private static extern void WTSCloseServer(IntPtr hServer);

        [DllImport("wtsapi32.dll")]
        private static extern int WTSEnumerateSessions(
            IntPtr hServer,
            [MarshalAs(UnmanagedType.U4)] int Reserved,
            [MarshalAs(UnmanagedType.U4)] int Version,
            ref IntPtr ppSessionInfo,
            [MarshalAs(UnmanagedType.U4)] ref int pCount);

        [DllImport("wtsapi32.dll")]
        private static extern void WTSFreeMemory(IntPtr pMemory);

        [DllImport("wtsapi32.dll")]
        private static extern bool WTSQuerySessionInformation(
            IntPtr hServer, int sessionId, WTS_INFO_CLASS wtsInfoClass, out IntPtr ppBuffer, out uint pBytesReturned);

        [StructLayout(LayoutKind.Sequential)]
        private readonly struct WTS_SESSION_INFO
        {
            public readonly int SessionID;

            [MarshalAs(UnmanagedType.LPStr)]
            private readonly string pWinStationName;

            private readonly WTS_CONNECTSTATE_CLASS State;
        }

        [StructLayout(LayoutKind.Sequential)]
        private readonly struct WTS_CLIENT_ADDRESS
        {
            private readonly int iAddressFamily;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
            public readonly byte[] bAddress;
        }

        public enum WTS_INFO_CLASS
        {
            WTSInitialProgram,
            WTSApplicationName,
            WTSWorkingDirectory,
            WTSOEMId,
            WTSSessionId,
            WTSUserName,
            WTSWinStationName,
            WTSDomainName,
            WTSConnectState,
            WTSClientBuildNumber,
            WTSClientName,
            WTSClientDirectory,
            WTSClientProductId,
            WTSClientHardwareId,
            WTSClientAddress,
            WTSClientDisplay,
            WTSClientProtocolType
        }

        public enum WTS_CONNECTSTATE_CLASS
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
        #endregion
    }
}
