using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CliWrap;
using CliWrap.Buffered;
using HASSAgent.Models.Internal;
using Serilog;

namespace HASSAgent.Functions
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal static class CommandLine
    {
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

        /// <summary>
        /// Executes the file within a command prompt, parses & returns the output
        /// /// <para>Uses default timeout of 5 minutes</para>
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
    }
}
