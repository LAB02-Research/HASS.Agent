using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CliWrap;
using CliWrap.Buffered;
using HASSAgent.Models.Internal;
using Microsoft.Win32.SafeHandles;
using Serilog;
// ReSharper disable InconsistentNaming

namespace HASSAgent.Functions
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal static class CommandLineManager
    {
        /// <summary>
        /// Executes the file within a command prompt, parses & returns the output
        /// <para>Uses default timeout of 5 minutes</para>
        /// </summary>
        /// <param name="file"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        internal static async Task<ConsoleResult> ExecuteCommandAsync(string file, string args)
        {
            return await ExecuteCommandAsync(file, args, TimeSpan.FromMinutes(5));
        }

        /// <summary>
        /// Executes the file within a command prompt, parses & returns the output
        /// </summary>
        /// <param name="file"></param>
        /// <param name="args"></param>
        /// <param name="timout"></param>
        /// <returns></returns>
        internal static async Task<ConsoleResult> ExecuteCommandAsync(string file, string args, TimeSpan timout)
        {
            var consoleResult = new ConsoleResult();

            try
            {
                using (var cts = new CancellationTokenSource())
                {
                    cts.CancelAfter(timout);
                    
                    var result = await Cli.Wrap(file)
                        .WithArguments(args)
                        .WithValidation(CommandResultValidation.None)
                        .ExecuteBufferedAsync(cts.Token);

                    var exitCode = result.ExitCode;
                    var stdOut = result.StandardOutput;
                    var stdErr = result.StandardError;

                    if (cts.IsCancellationRequested)
                    {
                        // timeout elapsed
                        Log.Error("[CLI] Execution didn't finish within timeout limit (exitcode: {exitCode}): {file}", exitCode, file);
                    }
                    else
                    {
                        // executed within timeout
                        if (exitCode != 0) Log.Warning("[PROCESS] Execution returned non-ok exitcode (exitcode: {exitCode}): {file}", exitCode, file);
                    }

                    // add console output to the console result
                    if (!string.IsNullOrEmpty(stdOut))
                    {
                        var output = stdOut.Trim();
                        output = output.Replace(@"\r\n", Environment.NewLine);
                        output = output.Replace(@"\n", Environment.NewLine);

                        var consoleOutput = new StringBuilder();

                        foreach (var row in output.Split(new[] { Environment.NewLine }, StringSplitOptions.None))
                        {
                            consoleOutput.AppendLine(row);
                        }

                        consoleResult.Output = consoleOutput.ToString();
                    }
                    else consoleResult.Output = string.Empty;

                    // add console error output to the console result
                    if (!string.IsNullOrEmpty(stdErr))
                    {
                        var err = stdErr.Trim();
                        err = err.Replace(@"\r\n", Environment.NewLine);
                        err = err.Replace(@"\n", Environment.NewLine);

                        var errorOutput = new StringBuilder();

                        foreach (var row in err.Split(new[] { Environment.NewLine }, StringSplitOptions.None))
                        {
                            errorOutput.AppendLine(row);
                        }

                        consoleResult.ErrorOutput = errorOutput.ToString();
                    }
                    else consoleResult.ErrorOutput = string.Empty;

                    // complete the console result
                    var success = exitCode == 0 && string.IsNullOrEmpty(stdErr);

                    consoleResult.Error = !success;
                    consoleResult.ExitCode = exitCode;

                    // done
                    return consoleResult;
                }
            }
            catch (Win32Exception we)
            {
                // win32 file-not-found error
                if (we.NativeErrorCode == FileNotFoundError || we.NativeErrorCode == 2)
                {
                    Log.Error("[CLI] File not found, unable to execute: {file}", file);
                    return consoleResult.SetError("file not found");
                }

                // this error means a x64 file has been run on an x86 environment (probably)
                if (we.NativeErrorCode == 193)
                {
                    var os32 = Environment.Is64BitOperatingSystem ? "NO" : "YES";
                    Log.Error("[CLI] File isn't compatible with the current platform (OS is 32bit: {os32})", os32);
                    return consoleResult.SetError("file incompatible with platform");
                }

                // code unknown
                Log.Error("[CLI] Unknown WIN32 error encountered (code: {code}): {file}", we.NativeErrorCode, file);
                return consoleResult.SetError("unknown error");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[CLI] Fatal error when executing file: {file}", file);
                return consoleResult.SetError("fatal error");
            }
        }

        /// <summary>
        /// Execute a command without waiting for or checking results
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        internal static bool ExecuteHeadless(string command)
        {
            try
            {
                using (var process = new Process())
                {
                    var startInfo = new ProcessStartInfo
                    {
                        WindowStyle = ProcessWindowStyle.Hidden,
                        CreateNoWindow = true,
                        FileName = "cmd.exe",
                        Arguments = $"/C {command}"
                    };

                    process.StartInfo = startInfo;
                    var start = process.Start();

                    if (!start)
                    {
                        Log.Error("[CLI] Unable to start executing command: {command}", command);
                        return false;
                    }

                    // done
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[CLI] Fatal error when executing command: {command}", command);
                return true;
            }
        }

        /// <summary>
        /// Executes the file without elevation, no feedback
        /// Source: https://stackoverflow.com/a/58579679
        /// </summary>
        /// <param name="file"></param>
        /// <param name="args"></param>
        [SuppressMessage("ReSharper", "SuspiciousTypeConversion.Global")]
        internal static void ExecuteProcessUnElevated(string file, string args = "")
        {
            var shellWindows = (IShellWindows)new CShellWindows();

            // get the desktop window
            object loc = CSIDL_Desktop;
            var unused = new object();
            var serviceProvider = (IServiceProvider)shellWindows.FindWindowSW(ref loc, ref unused, SWC_DESKTOP, out _, SWFO_NEEDDISPATCH);

            // get the shell browser
            var serviceGuid = SID_STopLevelBrowser;
            var interfaceGuid = typeof(IShellBrowser).GUID;
            var shellBrowser = (IShellBrowser)serviceProvider.QueryService(ref serviceGuid, ref interfaceGuid);

            // get the shell dispatch
            var dispatch = typeof(IDispatch).GUID;
            var folderView = (IShellFolderViewDual)shellBrowser.QueryActiveShellView().GetItemObject(SVGIO_BACKGROUND, ref dispatch);
            var shellDispatch = (IShellDispatch2)folderView.Application;

            // use the dispatch (which is unelevated) to launch the process for us
            shellDispatch.ShellExecute(file, args, Variables.StartupPath, string.Empty, SW_SHOWNORMAL);
        }

        /// <summary>
        /// Launches the application with low integrity
        /// <para>Both application and arguments need to be in the commandLine variable</para>
        /// <para>Source: https://github.com/edetoc/samples/tree/18cdf198694a4398b9ac9c605fc14a6b39706f12/CSCreateLowIntegrityProcess/CSCreateLowIntegrityProcess </para>
        /// </summary>
        /// <param name="commandLine"></param>
        /// <exception cref="Win32Exception"></exception>
        internal static void LaunchAsLowIntegrity(string commandLine)
        {
            SafeTokenHandle hToken = null;
            SafeTokenHandle hNewToken = null;
            var pIntegritySid = IntPtr.Zero;
            var pTokenInfo = IntPtr.Zero;
            var si = new STARTUPINFO();
            var pi = new PROCESS_INFORMATION();
            int cbTokenInfo;

            try
            {
                // open the primary access token of the process
                if (!NativeMethod.OpenProcessToken(Process.GetCurrentProcess().Handle, NativeMethod.TOKEN_DUPLICATE | NativeMethod.TOKEN_ADJUST_DEFAULT | NativeMethod.TOKEN_QUERY | NativeMethod.TOKEN_ASSIGN_PRIMARY, out hToken))
                {
                    Log.Fatal(new Win32Exception(), "[CLI] Error while launching as low integrity: unable to open current process' access token");
                    return;
                }

                // duplicate the primary token of the current process
                if (!NativeMethod.DuplicateTokenEx(hToken, 0, IntPtr.Zero, SECURITY_IMPERSONATION_LEVEL.SecurityImpersonation, TOKEN_TYPE.TokenPrimary, out hNewToken))
                {
                    Log.Fatal(new Win32Exception(), "[CLI] Error while launching as low integrity: unable to duplicate current process' primary token");
                    return;
                }

                // create the low integrity SID
                if (!NativeMethod.AllocateAndInitializeSid(ref NativeMethod.SECURITY_MANDATORY_LABEL_AUTHORITY, 1, 
                        NativeMethod.SECURITY_MANDATORY_LOW_RID, 0, 0, 0, 0, 0, 0, 0, out pIntegritySid))
                {
                    Log.Fatal(new Win32Exception(), "[CLI] Error while launching as low integrity: unable to create the low integrity SID");
                    return;
                }

                TOKEN_MANDATORY_LABEL tml;
                tml.Label.Attributes = NativeMethod.SE_GROUP_INTEGRITY;
                tml.Label.Sid = pIntegritySid;

                // marshal the TOKEN_MANDATORY_LABEL struct to the native memory
                cbTokenInfo = Marshal.SizeOf(tml);
                pTokenInfo = Marshal.AllocHGlobal(cbTokenInfo);
                Marshal.StructureToPtr(tml, pTokenInfo, false);

                // set the integrity level in the access token to low
                if (!NativeMethod.SetTokenInformation(hNewToken, TOKEN_INFORMATION_CLASS.TokenIntegrityLevel, pTokenInfo, cbTokenInfo + NativeMethod.GetLengthSid(pIntegritySid)))
                {
                    Log.Fatal(new Win32Exception(), "[CLI] Error while launching as low integrity: unable to set integrity level to low");
                    return;
                }

                // create the new process at the Low integrity level
                si.cb = Marshal.SizeOf(si);
                if (!NativeMethod.CreateProcessAsUser(hNewToken, null, commandLine, IntPtr.Zero, IntPtr.Zero, false, 0, IntPtr.Zero, null, ref si, out pi))
                {
                    Log.Fatal(new Win32Exception(), "[CLI] Error while launching as low integrity: unable to create the new process at low integrity");
                }

                // all done, no feedback
            }
            catch (Win32Exception ex)
            {
                Log.Fatal(ex, "[CLI] Error while launching as low integrity (W32): {err}", ex.Message);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[CLI] Error while launching as low integrity: {err}", ex.Message);
            }
            finally
            {
                // centralized cleanup for all allocated resources
                if (hToken != null)
                {
                    hToken.Close();
                    hToken = null;
                }

                if (hNewToken != null)
                {
                    hNewToken.Close();
                    hNewToken = null;
                }

                if (pIntegritySid != IntPtr.Zero)
                {
                    NativeMethod.FreeSid(pIntegritySid);
                    pIntegritySid = IntPtr.Zero;
                }

                if (pTokenInfo != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(pTokenInfo);
                    pTokenInfo = IntPtr.Zero;
                    cbTokenInfo = 0;
                }

                if (pi.hProcess != IntPtr.Zero)
                {
                    NativeMethod.CloseHandle(pi.hProcess);
                    pi.hProcess = IntPtr.Zero;
                }

                if (pi.hThread != IntPtr.Zero)
                {
                    NativeMethod.CloseHandle(pi.hThread);
                    pi.hThread = IntPtr.Zero;
                }
            }
        }

        #region Launch Unelevated
            /// <summary>
            /// Interop definitions
            /// </summary>
        private const int CSIDL_Desktop = 0;
        private const int SWC_DESKTOP = 8;
        private const int SWFO_NEEDDISPATCH = 1;
        private const int SW_SHOWNORMAL = 1;
        private const int SVGIO_BACKGROUND = 0;
        private static readonly Guid SID_STopLevelBrowser = new Guid("4C96BE40-915C-11CF-99D3-00AA004AE837");

        [ComImport]
        [Guid("9BA05972-F6A8-11CF-A442-00A0C90A8F39")]
        [ClassInterfaceAttribute(ClassInterfaceType.None)]
        private class CShellWindows
        {
            //
        }

        [ComImport]
        [Guid("85CB6900-4D95-11CF-960C-0080C7F4EE85")]
        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        private interface IShellWindows
        {
            [return: MarshalAs(UnmanagedType.IDispatch)]
            object FindWindowSW([MarshalAs(UnmanagedType.Struct)] ref object pvarloc, [MarshalAs(UnmanagedType.Struct)] ref object pvarlocRoot, int swClass, out int pHWND, int swfwOptions);
        }

        [ComImport]
        [Guid("6d5140c1-7436-11ce-8034-00aa006009fa")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IServiceProvider
        {
            [return: MarshalAs(UnmanagedType.Interface)]
            object QueryService(ref Guid guidService, ref Guid riid);
        }

        [ComImport]
        [Guid("000214E2-0000-0000-C000-000000000046")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IShellBrowser
        {
            void VTableGap01(); // GetWindow
            void VTableGap02(); // ContextSensitiveHelp
            void VTableGap03(); // InsertMenusSB
            void VTableGap04(); // SetMenuSB
            void VTableGap05(); // RemoveMenusSB
            void VTableGap06(); // SetStatusTextSB
            void VTableGap07(); // EnableModelessSB
            void VTableGap08(); // TranslateAcceleratorSB
            void VTableGap09(); // BrowseObject
            void VTableGap10(); // GetViewStateStream
            void VTableGap11(); // GetControlWindow
            void VTableGap12(); // SendControlMsg
            IShellView QueryActiveShellView();
        }

        [ComImport]
        [Guid("000214E3-0000-0000-C000-000000000046")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IShellView
        {
            void VTableGap01(); // GetWindow
            void VTableGap02(); // ContextSensitiveHelp
            void VTableGap03(); // TranslateAcceleratorA
            void VTableGap04(); // EnableModeless
            void VTableGap05(); // UIActivate
            void VTableGap06(); // Refresh
            void VTableGap07(); // CreateViewWindow
            void VTableGap08(); // DestroyViewWindow
            void VTableGap09(); // GetCurrentInfo
            void VTableGap10(); // AddPropertySheetPages
            void VTableGap11(); // SaveViewState
            void VTableGap12(); // SelectItem

            [return: MarshalAs(UnmanagedType.Interface)]
            object GetItemObject(uint aspectOfView, ref Guid riid);
        }

        [ComImport]
        [Guid("00020400-0000-0000-C000-000000000046")]
        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        private interface IDispatch
        {
            //
        }

        [ComImport]
        [Guid("E7A1AF80-4D96-11CF-960C-0080C7F4EE85")]
        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        private interface IShellFolderViewDual
        {
            object Application { [return: MarshalAs(UnmanagedType.IDispatch)] get; }
        }

        [ComImport]
        [Guid("A4C6892C-3BA9-11D2-9DEA-00C04FB16162")]
        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        public interface IShellDispatch2
        {
            void ShellExecute([MarshalAs(UnmanagedType.BStr)] string File, [MarshalAs(UnmanagedType.Struct)] object vArgs, [MarshalAs(UnmanagedType.Struct)] object vDir, [MarshalAs(UnmanagedType.Struct)] object vOperation, [MarshalAs(UnmanagedType.Struct)] object vShow);
        }

        // ReSharper disable once ConvertToConstant.Local
        private static readonly uint FileNotFoundUint = 0x80004005;
        private static readonly int FileNotFoundError = (int)FileNotFoundUint;
        #endregion
    }

    #region Launch with Low Integrity
    // Source: https://github.com/edetoc/samples/tree/18cdf198694a4398b9ac9c605fc14a6b39706f12/CSCreateLowIntegrityProcess/CSCreateLowIntegrityProcess

    /// <summary>
    /// The TOKEN_INFORMATION_CLASS enumeration type contains values that 
    /// specify the type of information being assigned to or retrieved from 
    /// an access token.
    /// </summary>
    internal enum TOKEN_INFORMATION_CLASS
    {
        TokenUser = 1,
        TokenGroups,
        TokenPrivileges,
        TokenOwner,
        TokenPrimaryGroup,
        TokenDefaultDacl,
        TokenSource,
        TokenType,
        TokenImpersonationLevel,
        TokenStatistics,
        TokenRestrictedSids,
        TokenSessionId,
        TokenGroupsAndPrivileges,
        TokenSessionReference,
        TokenSandBoxInert,
        TokenAuditPolicy,
        TokenOrigin,
        TokenElevationType,
        TokenLinkedToken,
        TokenElevation,
        TokenHasRestrictions,
        TokenAccessInformation,
        TokenVirtualizationAllowed,
        TokenVirtualizationEnabled,
        TokenIntegrityLevel,
        TokenUIAccess,
        TokenMandatoryPolicy,
        TokenLogonSid,
        MaxTokenInfoClass
    }

    /// <summary>
    /// The SECURITY_IMPERSONATION_LEVEL enumeration type contains values 
    /// that specify security impersonation levels. Security impersonation 
    /// levels govern the degree to which a server process can act on behalf 
    /// of a client process.
    /// </summary>
    internal enum SECURITY_IMPERSONATION_LEVEL
    {
        SecurityAnonymous,
        SecurityIdentification,
        SecurityImpersonation,
        SecurityDelegation
    }

    /// <summary>
    /// The TOKEN_TYPE enumeration type contains values that differentiate 
    /// between a primary token and an impersonation token. 
    /// </summary>
    internal enum TOKEN_TYPE
    {
        TokenPrimary = 1,
        TokenImpersonation
    }

    /// <summary>
    /// The structure represents a security identifier (SID) and its 
    /// attributes. SIDs are used to uniquely identify users or groups.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct SID_AND_ATTRIBUTES
    {
        public IntPtr Sid;
        public uint Attributes;
    }

    /// <summary>
    /// The SID_IDENTIFIER_AUTHORITY structure represents the top-level 
    /// authority of a security identifier (SID).
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct SID_IDENTIFIER_AUTHORITY
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = UnmanagedType.I1)]
        public byte[] Value;

        public SID_IDENTIFIER_AUTHORITY(byte[] value)
        {
            Value = value;
        }
    }

    /// <summary>
    /// The structure specifies the mandatory integrity level for a token.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct TOKEN_MANDATORY_LABEL
    {
        public SID_AND_ATTRIBUTES Label;
    }

    /// <summary>
    /// Specifies the window station, desktop, standard handles, and 
    /// appearance of the main window for a process at creation time.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    internal struct STARTUPINFO
    {
        public int cb;
        public string lpReserved;
        public string lpDesktop;
        public string lpTitle;
        public int dwX;
        public int dwY;
        public int dwXSize;
        public int dwYSize;
        public int dwXCountChars;
        public int dwYCountChars;
        public int dwFillAttribute;
        public int dwFlags;
        public short wShowWindow;
        public short cbReserved2;
        public IntPtr lpReserved2;
        public IntPtr hStdInput;
        public IntPtr hStdOutput;
        public IntPtr hStdError;
    }

    /// <summary>
    /// Contains information about a newly created process and its primary 
    /// thread.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct PROCESS_INFORMATION
    {
        public IntPtr hProcess;
        public IntPtr hThread;
        public int dwProcessId;
        public int dwThreadId;
    }

    /// <summary>
    /// Represents a wrapper class for a token handle.
    /// </summary>
    internal class SafeTokenHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        private SafeTokenHandle()
            : base(true)
        {
        }

        internal SafeTokenHandle(IntPtr handle)
            : base(true)
        {
            SetHandle(handle);
        }

        protected override bool ReleaseHandle()
        {
            return NativeMethod.CloseHandle(handle);
        }
    }

    internal class NativeMethod
    {
        // Token Specific Access Rights
        public const uint STANDARD_RIGHTS_REQUIRED = 0x000F0000;
        public const uint STANDARD_RIGHTS_READ = 0x00020000;
        public const uint TOKEN_ASSIGN_PRIMARY = 0x0001;
        public const uint TOKEN_DUPLICATE = 0x0002;
        public const uint TOKEN_IMPERSONATE = 0x0004;
        public const uint TOKEN_QUERY = 0x0008;
        public const uint TOKEN_QUERY_SOURCE = 0x0010;
        public const uint TOKEN_ADJUST_PRIVILEGES = 0x0020;
        public const uint TOKEN_ADJUST_GROUPS = 0x0040;
        public const uint TOKEN_ADJUST_DEFAULT = 0x0080;
        public const uint TOKEN_ADJUST_SESSIONID = 0x0100;
        public const uint TOKEN_READ = (STANDARD_RIGHTS_READ | TOKEN_QUERY);
        public const uint TOKEN_ALL_ACCESS = (STANDARD_RIGHTS_REQUIRED |
            TOKEN_ASSIGN_PRIMARY | TOKEN_DUPLICATE | TOKEN_IMPERSONATE |
            TOKEN_QUERY | TOKEN_QUERY_SOURCE | TOKEN_ADJUST_PRIVILEGES |
            TOKEN_ADJUST_GROUPS | TOKEN_ADJUST_DEFAULT | TOKEN_ADJUST_SESSIONID);

        public const int ERROR_INSUFFICIENT_BUFFER = 122;

        // Integrity Levels
        public static SID_IDENTIFIER_AUTHORITY SECURITY_MANDATORY_LABEL_AUTHORITY = new SID_IDENTIFIER_AUTHORITY(new byte[] { 0, 0, 0, 0, 0, 16 });
        public const int SECURITY_MANDATORY_UNTRUSTED_RID = 0x00000000;
        public const int SECURITY_MANDATORY_LOW_RID = 0x00001000;
        public const int SECURITY_MANDATORY_MEDIUM_RID = 0x00002000;
        public const int SECURITY_MANDATORY_HIGH_RID = 0x00003000;
        public const int SECURITY_MANDATORY_SYSTEM_RID = 0x00004000;

        // Group related SID Attributes
        public const uint SE_GROUP_MANDATORY = 0x00000001;
        public const uint SE_GROUP_ENABLED_BY_DEFAULT = 0x00000002;
        public const uint SE_GROUP_ENABLED = 0x00000004;
        public const uint SE_GROUP_OWNER = 0x00000008;
        public const uint SE_GROUP_USE_FOR_DENY_ONLY = 0x00000010;
        public const uint SE_GROUP_INTEGRITY = 0x00000020;
        public const uint SE_GROUP_INTEGRITY_ENABLED = 0x00000040;
        public const uint SE_GROUP_LOGON_ID = 0xC0000000;
        public const uint SE_GROUP_RESOURCE = 0x20000000;
        public const uint SE_GROUP_VALID_ATTRIBUTES = (SE_GROUP_MANDATORY |
            SE_GROUP_ENABLED_BY_DEFAULT | SE_GROUP_ENABLED | SE_GROUP_OWNER |
            SE_GROUP_USE_FOR_DENY_ONLY | SE_GROUP_LOGON_ID | SE_GROUP_RESOURCE |
            SE_GROUP_INTEGRITY | SE_GROUP_INTEGRITY_ENABLED);

        /// <summary>
        /// The function opens the access token associated with a process.
        /// </summary>
        /// <param name="hProcess">
        /// A handle to the process whose access token is opened.
        /// </param>
        /// <param name="desiredAccess">
        /// Specifies an access mask that specifies the requested types of 
        /// access to the access token. 
        /// </param>
        /// <param name="hToken">
        /// Outputs a handle that identifies the newly opened access token 
        /// when the function returns.
        /// </param>
        /// <returns></returns>
        [DllImport("advapi32", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool OpenProcessToken(
            IntPtr hProcess,
            uint desiredAccess,
            out SafeTokenHandle hToken);

        /// <summary>
        /// The DuplicateTokenEx function creates a new access token that 
        /// duplicates an existing token. This function can create either a 
        /// primary token or an impersonation token.
        /// </summary>
        /// <param name="hExistingToken">
        /// A handle to an access token opened with TOKEN_DUPLICATE access.
        /// </param>
        /// <param name="desiredAccess">
        /// Specifies the requested access rights for the new token.
        /// </param>
        /// <param name="pTokenAttributes">
        /// A pointer to a SECURITY_ATTRIBUTES structure that specifies a 
        /// security descriptor for the new token and determines whether 
        /// child processes can inherit the token. If lpTokenAttributes is 
        /// NULL, the token gets a default security descriptor and the handle 
        /// cannot be inherited. 
        /// </param>
        /// <param name="ImpersonationLevel">
        /// Specifies the impersonation level of the new token.
        /// </param>
        /// <param name="TokenType">
        /// TokenPrimary - The new token is a primary token that you can use 
        /// in the CreateProcessAsUser function.
        /// TokenImpersonation - The new token is an impersonation token.
        /// </param>
        /// <param name="hNewToken">
        /// Receives the new token.
        /// </param>
        /// <returns></returns>
        [DllImport("advapi32", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DuplicateTokenEx(
            SafeTokenHandle hExistingToken,
            uint desiredAccess,
            IntPtr pTokenAttributes,
            SECURITY_IMPERSONATION_LEVEL ImpersonationLevel,
            TOKEN_TYPE TokenType,
            out SafeTokenHandle hNewToken);

        /// <summary>
        /// The function retrieves a specified type of information about an 
        /// access token. The calling process must have appropriate access 
        /// rights to obtain the information.
        /// </summary>
        /// <param name="hToken">
        /// A handle to an access token from which information is retrieved.
        /// </param>
        /// <param name="tokenInfoClass">
        /// Specifies a value from the TOKEN_INFORMATION_CLASS enumerated 
        /// type to identify the type of information the function retrieves.
        /// </param>
        /// <param name="pTokenInfo">
        /// A pointer to a buffer the function fills with the requested 
        /// information.
        /// </param>
        /// <param name="tokenInfoLength">
        /// Specifies the size, in bytes, of the buffer pointed to by the 
        /// TokenInformation parameter. 
        /// </param>
        /// <param name="returnLength">
        /// A pointer to a variable that receives the number of bytes needed 
        /// for the buffer pointed to by the TokenInformation parameter. 
        /// </param>
        /// <returns></returns>
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetTokenInformation(
            SafeTokenHandle hToken,
            TOKEN_INFORMATION_CLASS tokenInfoClass,
            IntPtr pTokenInfo,
            int tokenInfoLength,
            out int returnLength);

        /// <summary>
        /// The function sets various types of information for a specified 
        /// access token. The information that this function sets replaces 
        /// existing information. The calling process must have appropriate 
        /// access rights to set the information.
        /// </summary>
        /// <param name="hToken">
        /// A handle to the access token for which information is to be set.
        /// </param>
        /// <param name="tokenInfoClass">
        /// A value from the TOKEN_INFORMATION_CLASS enumerated type that 
        /// identifies the type of information the function sets. 
        /// </param>
        /// <param name="pTokenInfo">
        /// A pointer to a buffer that contains the information set in the 
        /// access token. 
        /// </param>
        /// <param name="tokenInfoLength">
        /// Specifies the length, in bytes, of the buffer pointed to by 
        /// TokenInformation.
        /// </param>
        /// <returns></returns>
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetTokenInformation(
            SafeTokenHandle hToken,
            TOKEN_INFORMATION_CLASS tokenInfoClass,
            IntPtr pTokenInfo,
            int tokenInfoLength);

        /// <summary>
        /// The function returns a pointer to a specified subauthority in a 
        /// security identifier (SID). The subauthority value is a relative 
        /// identifier (RID).
        /// </summary>
        /// <param name="pSid">
        /// A pointer to the SID structure from which a pointer to a 
        /// subauthority is to be returned.
        /// </param>
        /// <param name="nSubAuthority">
        /// Specifies an index value identifying the subauthority array 
        /// element whose address the function will return.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a pointer to the 
        /// specified SID subauthority. To get extended error information, 
        /// call GetLastError. If the function fails, the return value is 
        /// undefined. The function fails if the specified SID structure is 
        /// not valid or if the index value specified by the nSubAuthority 
        /// parameter is out of bounds.
        /// </returns>
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr GetSidSubAuthority(
            IntPtr pSid,
            uint nSubAuthority);

        /// <summary>
        /// The AllocateAndInitializeSid function allocates and initializes a 
        /// security identifier (SID) with up to eight subauthorities.
        /// </summary>
        /// <param name="pIdentifierAuthority">
        /// A reference of a SID_IDENTIFIER_AUTHORITY structure. This 
        /// structure provides the top-level identifier authority value to 
        /// set in the SID.
        /// </param>
        /// <param name="nSubAuthorityCount">
        /// Specifies the number of subauthorities to place in the SID. 
        /// </param>
        /// <param name="dwSubAuthority0">
        /// Subauthority value to place in the SID.
        /// </param>
        /// <param name="dwSubAuthority1">
        /// Subauthority value to place in the SID.
        /// </param>
        /// <param name="dwSubAuthority2">
        /// Subauthority value to place in the SID.
        /// </param>
        /// <param name="dwSubAuthority3">
        /// Subauthority value to place in the SID.
        /// </param>
        /// <param name="dwSubAuthority4">
        /// Subauthority value to place in the SID.
        /// </param>
        /// <param name="dwSubAuthority5">
        /// Subauthority value to place in the SID.
        /// </param>
        /// <param name="dwSubAuthority6">
        /// Subauthority value to place in the SID.
        /// </param>
        /// <param name="dwSubAuthority7">
        /// Subauthority value to place in the SID.
        /// </param>
        /// <param name="pSid">
        /// Outputs the allocated and initialized SID structure.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is true. If the 
        /// function fails, the return value is false. To get extended error 
        /// information, call GetLastError.
        /// </returns>
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AllocateAndInitializeSid(
            ref SID_IDENTIFIER_AUTHORITY pIdentifierAuthority,
            byte nSubAuthorityCount,
            int dwSubAuthority0, int dwSubAuthority1,
            int dwSubAuthority2, int dwSubAuthority3,
            int dwSubAuthority4, int dwSubAuthority5,
            int dwSubAuthority6, int dwSubAuthority7,
            out IntPtr pSid);
        
        /// <summary>
        /// The FreeSid function frees a security identifier (SID) previously 
        /// allocated by using the AllocateAndInitializeSid function.
        /// </summary>
        /// <param name="pSid">
        /// A pointer to the SID structure to free.
        /// </param>
        /// <returns>
        /// If the function succeeds, the function returns NULL. If the 
        /// function fails, it returns a pointer to the SID structure 
        /// represented by the pSid parameter.
        /// </returns>
        [DllImport("advapi32.dll")]
        public static extern IntPtr FreeSid(IntPtr pSid);
        
        /// <summary>
        /// The function returns the length, in bytes, of a valid security 
        /// identifier (SID).
        /// </summary>
        /// <param name="pSID">
        /// A pointer to the SID structure whose length is returned. 
        /// </param>
        /// <returns>
        /// If the SID structure is valid, the return value is the length, in 
        /// bytes, of the SID structure.
        /// </returns>
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetLengthSid(IntPtr pSID);
        
        /// <summary>
        /// Creates a new process and its primary thread. The new process 
        /// runs in the security context of the user represented by the 
        /// specified token.
        /// </summary>
        /// <param name="hToken">
        /// A handle to the primary token that represents a user. 
        /// </param>
        /// <param name="applicationName">
        /// The name of the module to be executed.
        /// </param>
        /// <param name="commandLine">
        /// The command line to be executed. The maximum length of this 
        /// string is 32K characters. 
        /// </param>
        /// <param name="pProcessAttributes">
        /// A pointer to a SECURITY_ATTRIBUTES structure that specifies a 
        /// security descriptor for the new process object and determines 
        /// whether child processes can inherit the returned handle to the 
        /// process.
        /// </param>
        /// <param name="pThreadAttributes">
        /// A pointer to a SECURITY_ATTRIBUTES structure that specifies a 
        /// security descriptor for the new thread object and determines 
        /// whether child processes can inherit the returned handle to the 
        /// thread.
        /// </param>
        /// <param name="bInheritHandles">
        /// If this parameter is true, each inheritable handle in the calling 
        /// process is inherited by the new process. If the parameter is 
        /// false, the handles are not inherited. 
        /// </param>
        /// <param name="dwCreationFlags">
        /// The flags that control the priority class and the creation of the 
        /// process.
        /// </param>
        /// <param name="pEnvironment">
        /// A pointer to an environment block for the new process. 
        /// </param>
        /// <param name="currentDirectory">
        /// The full path to the current directory for the process. 
        /// </param>
        /// <param name="startupInfo">
        /// References a STARTUPINFO structure.
        /// </param>
        /// <param name="processInformation">
        /// Outputs a PROCESS_INFORMATION structure that receives 
        /// identification information about the new process. 
        /// </param>
        /// <returns></returns>
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CreateProcessAsUser(
            SafeTokenHandle hToken,
            string applicationName,
            string commandLine,
            IntPtr pProcessAttributes,
            IntPtr pThreadAttributes,
            bool bInheritHandles,
            uint dwCreationFlags,
            IntPtr pEnvironment,
            string currentDirectory,
            ref STARTUPINFO startupInfo,
            out PROCESS_INFORMATION processInformation);
        
        /// <summary>
        /// Closes an open object handle.
        /// </summary>
        /// <param name="handle">A valid handle to an open object.</param>
        /// <returns></returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseHandle(IntPtr handle);

        // edetoc
        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern IntPtr LoadLibrary([MarshalAs(UnmanagedType.LPStr)] string lpFileName);
    }

    /// <summary>
    /// Well-known folder paths
    /// </summary>
    internal class KnownFolder
    {
        private static readonly Guid LocalAppDataGuid = new Guid("F1B32785-6FBA-4FCF-9D55-7B8E7F157091");
        public static string LocalAppData => SHGetKnownFolderPath(LocalAppDataGuid);

        private static readonly Guid LocalAppDataLowGuid = new Guid("A520A1A4-1780-4FF6-BD18-167343C5AF16");
        public static string LocalAppDataLow => SHGetKnownFolderPath(LocalAppDataLowGuid);
        
        /// <summary>
        /// Retrieves the full path of a known folder identified by the 
        /// folder's KNOWNFOLDERID.
        /// </summary>
        /// <param name="rfid">
        /// A reference to the KNOWNFOLDERID that identifies the folder.
        /// </param>
        /// <returns></returns>
        public static string SHGetKnownFolderPath(Guid rfid)
        {
            var pPath = IntPtr.Zero;
            string path;
            try
            {
                var hr = SHGetKnownFolderPath(rfid, 0, IntPtr.Zero, out pPath);
                if (hr != 0) throw Marshal.GetExceptionForHR(hr);
                path = Marshal.PtrToStringUni(pPath);
            }
            finally
            {
                if (pPath != IntPtr.Zero)
                {
                    Marshal.FreeCoTaskMem(pPath);
                    pPath = IntPtr.Zero;
                }
            }
            return path;
        }

        /// <summary>
        /// Retrieves the full path of a known folder identified by the 
        /// folder's KNOWNFOLDERID.
        /// </summary>
        /// <param name="rfid">
        /// A reference to the KNOWNFOLDERID that identifies the folder.
        /// </param>
        /// <param name="dwFlags">
        /// Flags that specify special retrieval options.
        /// </param>
        /// <param name="hToken">
        /// An access token that represents a particular user. If this 
        /// parameter is NULL, which is the most common usage, the function 
        /// requests the known folder for the current user.
        /// </param>
        /// <param name="pszPath">
        /// When this method returns, contains the address of a pointer to a 
        /// null-terminated Unicode string that specifies the path of the 
        /// known folder. The calling process is responsible for freeing this 
        /// resource once it is no longer needed by calling CoTaskMemFree.
        /// </param>
        /// <returns>HRESULT</returns>
        [DllImport("shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int SHGetKnownFolderPath(
            [MarshalAs(UnmanagedType.LPStruct)] Guid rfid,
            uint dwFlags,
            IntPtr hToken,
            out IntPtr pszPath);
    }
#endregion
}
