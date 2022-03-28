using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using HASS.Agent.Shared.Functions;
using Serilog;

namespace HASS.Agent.Functions
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal static class ServiceHelper
    {
        private const uint SERVICE_NO_CHANGE = 0xFFFFFFFF;
        private const uint SERVICE_QUERY_CONFIG = 0x00000001;
        private const uint SERVICE_CHANGE_CONFIG = 0x00000002;


        [StructLayout(LayoutKind.Sequential)]
        private sealed class SERVICE_STATUS_PROCESS
        {
            [MarshalAs(UnmanagedType.U4)]
            private uint dwServiceType;
            [MarshalAs(UnmanagedType.U4)]
            private uint dwCurrentState;
            [MarshalAs(UnmanagedType.U4)]
            private uint dwControlsAccepted;
            [MarshalAs(UnmanagedType.U4)]
            private uint dwWin32ExitCode;
            [MarshalAs(UnmanagedType.U4)]
            private uint dwServiceSpecificExitCode;
            [MarshalAs(UnmanagedType.U4)]
            private uint dwCheckPoint;
            [MarshalAs(UnmanagedType.U4)]
            private uint dwWaitHint;
            [MarshalAs(UnmanagedType.U4)]
            private uint dwProcessId;
            [MarshalAs(UnmanagedType.U4)]
            private uint dwServiceFlags;
        }

        private const uint SC_MANAGER_ALL_ACCESS = 0x000F003F;
        private const int ERROR_INSUFFICIENT_BUFFER = 0x7a;
        private const int SC_STATUS_PROCESS_INFO = 0;
        private const uint SC_MANAGER_CONNECT = 0x0001;
        private const uint SC_MANAGER_ENUMERATE_SERVICE = 0x0004;


        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern bool ChangeServiceConfig(
            IntPtr hService,
            uint nServiceType,
            uint nStartType,
            uint nErrorControl,
            string lpBinaryPathName,
            string lpLoadOrderGroup,
            IntPtr lpdwTagId,
            [In] char[] lpDependencies,
            string lpServiceStartName,
            string lpPassword,
            string lpDisplayName);

        [StructLayout(LayoutKind.Sequential)]
        private struct SERVICE_FAILURE_ACTIONS
        {
            private int dwResetPeriod;
            [MarshalAs(UnmanagedType.LPTStr)]
            private string lpRebootMsg;
            [MarshalAs(UnmanagedType.LPTStr)]
            private string lpCommand;
            private int cActions;
            private IntPtr lpsaActions;
        }

        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr OpenService(IntPtr hSCManager, string lpServiceName, uint dwDesiredAccess);

        [DllImport("advapi32.dll", EntryPoint = "OpenSCManagerW", ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern IntPtr OpenSCManager(string machineName, string databaseName, uint dwAccess);

        [DllImport("advapi32.dll", EntryPoint = "CloseServiceHandle")]
        private static extern int CloseServiceHandle(IntPtr hSCObject);

        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool QueryServiceStatusEx(SafeHandle hService, int infoLevel, IntPtr lpBuffer, uint cbBufSize, out uint pcbBytesNeeded);

        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ChangeServiceConfig2(
            IntPtr hService,
            int dwInfoLevel,
            IntPtr lpInfo);
        
        /// <summary>
        /// Change the startup mode for the provided service
        /// </summary>
        /// <param name="svc"></param>
        /// <param name="mode"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        internal static bool ChangeStartMode(ServiceController svc, ServiceStartMode mode, out string error)
        {
            error = "";

            var hManager = IntPtr.Zero;
            var hService = IntPtr.Zero;

            try
            {
                // open the service manager
                hManager = OpenSCManager(null, null, SC_MANAGER_CONNECT + SC_MANAGER_ENUMERATE_SERVICE);
                if (hManager == IntPtr.Zero)
                {
                    Log.Error("[SERVICE] Error while setting startup mode: opening servicemanager returned a zero pointer");
                    error = "unable to open servicemanager";
                    return false;
                }

                // open the service
                hService = OpenService(hManager, svc.ServiceName, SERVICE_QUERY_CONFIG | SERVICE_CHANGE_CONFIG);
                if (hService == IntPtr.Zero)
                {
                    Log.Error("[SERVICE] Error while setting startup mode: opening service returned a zero pointer");
                    error = "unable to open service";
                    return false;
                }

                // set the new startup config
                var result = ChangeServiceConfig(hService, SERVICE_NO_CHANGE, (uint)mode, SERVICE_NO_CHANGE, null, null,
                    IntPtr.Zero, null, null, null, null);

                if (result == false)
                {
                    // failed, get the error
                    var nError = Marshal.GetLastWin32Error();
                    var win32Exception = new Win32Exception(nError);

                    Log.Fatal(win32Exception, "[SERVICE] Win32 error while setting startup mode: {err}", win32Exception.Message);
                    error = "error configuring startup mode, check logs";
                    return false;
                }

                // all good
                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SERVICE] Error while setting startup mode: {err}", ex.Message);
                error = "error setting startup mode, check logs";
                return false;
            }
            finally
            {
                if (hService != IntPtr.Zero) CloseServiceHandle(hService);
                if (hManager != IntPtr.Zero) CloseServiceHandle(hManager);
            }
        }
    }
}
