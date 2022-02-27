using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Coderr.Client;
using Coderr.Client.Serilog;
using HASSAgent.Commands;
using HASSAgent.Enums;
using HASSAgent.Forms;
using HASSAgent.Models.Internal;
using HASSAgent.Mqtt;
using HASSAgent.Notifications;
using HASSAgent.Sensors;
using Serilog;
using Syncfusion.Windows.Forms;
using Task = System.Threading.Tasks.Task;

namespace HASSAgent.Functions
{
    internal static class DateTimeExtensions
    {
        /// <summary>
        /// Converts the DateTime object to a timezone-containing string
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        internal static string ToTimeZoneString(this DateTime datetime) => $"{datetime.ToUniversalTime():u}";
    }

    internal static class HelperFunctions
    {
        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool OpenProcessToken(IntPtr processHandle, uint desiredAccess, out IntPtr tokenHandle);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseHandle(IntPtr hObject);

        private delegate bool EnumWindowsProc(IntPtr hWnd, int lParam);

        [DllImport("USER32.DLL")]
        private static extern bool EnumWindows(EnumWindowsProc enumFunc, int lParam);

        [DllImport("USER32.DLL")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("USER32.DLL")]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("USER32.DLL")]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("USER32.DLL")]
        private static extern IntPtr GetShellWindow();

        private static bool _shutdownCalled = false;

        /// <summary>
        /// Initializes Syncfusion's messagebox style
        /// Todo: incomplete, button color etc need to be done
        /// </summary>
        /// <param name="font"></param>
        internal static void SetMsgBoxStyle(Font font)
        {
            var style = new MetroStyleColorTable
            {
                BackColor = Color.FromArgb(45, 45, 48),
                BorderColor = Color.FromArgb(115, 115, 115),
                CaptionBarColor = Color.FromArgb(63, 63, 70),
                CaptionForeColor = Color.FromArgb(241, 241, 241),
                ForeColor = Color.FromArgb(241, 241, 241)
            };

            MessageBoxAdv.ApplyAeroTheme = false;
            MessageBoxAdv.MetroColorTable = style;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;

            MessageBoxAdv.CaptionFont = font;
            MessageBoxAdv.ButtonFont = font;
            MessageBoxAdv.DetailsFont = font;
            MessageBoxAdv.MessageFont = font;
        }

        /// <summary>
        /// Initializes Serilog logger, optionally with exception logging through Coderr
        /// </summary>
        internal static void PrepareLogging()
        {
            if (Variables.ExceptionLogging)
            {
                PrepareCoderrEnabledLogging();
                return;
            }

            // prepare a serilog logger without coderr
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Async(a =>
                    a.File(Path.Combine(Variables.LogPath, $"[{DateTime.Now:yyyy-MM-dd}] {Variables.ApplicationName}_.log"),
                        rollingInterval: RollingInterval.Day,
                        fileSizeLimitBytes: 10000000,
                        retainedFileCountLimit: 10,
                        rollOnFileSizeLimit: true,
                        buffered: true,
                        flushToDiskInterval: TimeSpan.FromMilliseconds(150)))
                .CreateLogger();

            Log.Information("[LOG] Coderr exception reporting disabled");
        }

        /// <summary>
        /// Prepare Serilog logger and bind Coderr reporting
        /// </summary>
        private static void PrepareCoderrEnabledLogging()
        {
            // initialize coderr
            Err.Configuration.ThrowExceptions = false;

            var url = new Uri("https://report.coderr.io/");
            Err.Configuration.Credentials(url,
                "b8f26633ad354e91ab570f840080816a",
                "87163340045849d993879be4407d952b");

            Err.Configuration.CatchWinFormsExceptions();

            Err.Configuration.UserInteraction.AskUserForDetails = false;
            Err.Configuration.UserInteraction.AskUserForPermission = false;
            Err.Configuration.UserInteraction.AskForEmailAddress = false;

            // prepare a serilog logger including coderr
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Coderr()
                .WriteTo.Async(a =>
                    a.File(Path.Combine(Variables.LogPath, $"[{DateTime.Now:yyyy-MM-dd}] {Variables.ApplicationName}_.log"),
                        rollingInterval: RollingInterval.Day,
                        fileSizeLimitBytes: 10000000,
                        retainedFileCountLimit: 10,
                        rollOnFileSizeLimit: true,
                        buffered: true,
                        flushToDiskInterval: TimeSpan.FromMilliseconds(150)))
                .CreateLogger();

            Log.Information("[LOG] Coderr exception reporting enabled");
        }

        /// <summary>
        /// Restarts HASS.Agent through a temporary bat file
        /// </summary>
        /// <returns></returns>
        internal static bool Restart(bool fromElevation = false)
        {
            try
            {
                if (fromElevation)
                {
                    // launch unelevated
                    CommandLineManager.ExecuteProcessUnElevated(Variables.ApplicationExecutable, "restart");
                }
                else
                {
                    // launch from current elevation
                    Process.Start(Variables.ApplicationExecutable, "restart");
                }

                // close up
                _ = ShutdownAsync();

                // done
                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SYSTEM] Error executing regular restart: {err}", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Try to properly close the application with default 500ms waiting time
        /// </summary>
        /// <returns></returns>
        internal static async Task ShutdownAsync()
        {
            await ShutdownAsync(TimeSpan.FromMilliseconds(500));
        }

        /// <summary>
        /// Try to properly close the application
        /// </summary>
        internal static async Task ShutdownAsync(TimeSpan waitBeforeClosing)
        {
            var logClosed = false;

            try
            {
                // process only once
                if (_shutdownCalled) return;
                _shutdownCalled = true;

                // announce we're stopping
                Variables.ShuttingDown = true;

                // wait a bit
                await Task.Delay(waitBeforeClosing);

                // log our demise
                Log.Information("[SYSTEM] Application shutting down");

                // few steps only relevant if we're not in child-application mode
                if (!Variables.ChildApplicationMode)
                {
                    // stop mqtt
                    await MqttManager.AnnounceAvailabilityAsync(true);
                    MqttManager.Disconnect();

                    // remove tray icon
                    Variables.MainForm?.HideTrayIcon();

                    // stop hotkey
                    Variables.UiDispatcher.Invoke(new MethodInvoker(delegate
                    {
                        Variables.HotKeyListener?.RemoveAll();
                        Variables.HotKeyListener?.Dispose();
                    }));

                    // stop notifier api
                    NotifierManager.Stop();

                    // process disposables
                    Variables.WebClient?.Dispose();

                    // stop entity managers
                    CommandsManager.Stop();
                    SensorsManager.Stop();
                }

                // flush the log
                Log.Information("[SYSTEM] Application shutdown complete");
                Log.CloseAndFlush();
                logClosed = true;
            }
            catch (Exception ex)
            {
                if (!logClosed)
                {
                    Log.Error("[SYSTEM] Error shutting down nicely: {msg}", ex.Message);
                    Log.CloseAndFlush();
                }
            }
            finally
            {
                // shutdown
                Environment.Exit(1);
            }
        }

        /// <summary>
        /// Determine the amount of columns and rows needed for the amount of quickactions
        /// </summary>
        /// <param name="quickActions"></param>
        /// <returns></returns>
        internal static (int columns, int rows) DetermineRowColumnCount(List<QuickAction> quickActions)
        {
            try
            {
                if (!quickActions.Any()) return (0, 0);
                var count = quickActions.Count;

                switch (count)
                {
                    case 1:
                        return (1, 1);
                    case 2:
                        return (2, 1);
                    case 3:
                        return (3, 1);
                    case 4:
                        return (2, 2);
                    case 5:
                    case 6:
                        return (3, 2);
                    case 7:
                    case 8:
                        return (4, 2);
                    case 9:
                    case 10:
                        return (5, 2);
                    case 11:
                    case 12:
                        return (6, 2);
                    case 13:
                    case 14:
                    case 15:
                    case 16:
                    case 17:
                    case 18:
                        return (6, 3);

                    default:
                        // we're maxing our columns on 10, so modulo to determine the rows
                        var remaining = count % 10;
                        return remaining == 0 ? (10, count / 10) : (10, count / 10 + 1);
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Unable to determine a proper row/column count for the quickactions: {err}", ex.Message);
                return (0, 0);
            }
        }

        /// <summary>
        /// Gets the description of the provided enum
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        internal static string GetDescription(this Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            if (fieldInfo == null) return null;
            var attribute = (DescriptionAttribute)fieldInfo.GetCustomAttribute(typeof(DescriptionAttribute));
            return attribute.Description;
        }

        /// <summary>
        /// Gets the corresponding color for the status
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        internal static Color GetColor(this ComponentStatus value)
        {
            switch (value)
            {
                case ComponentStatus.Loading:
                case ComponentStatus.Connecting:
                    return Color.DodgerBlue;

                case ComponentStatus.Ok:
                    return Color.LimeGreen;

                case ComponentStatus.Failed:
                    return Color.OrangeRed;

                case ComponentStatus.Stopped:
                    return Color.Yellow;
            }

            return Color.Gray;
        }

        /// <summary>
        /// Checks whether the provided form is already opened
        /// </summary>
        /// <param name="formname"></param>
        /// <returns></returns>
        internal static bool CheckIfFormIsOpen(string formname) => Application.OpenForms.Cast<Form>().Any(form => form?.Name == formname);

        /// <summary>
        /// Launches the url with the user's custom browser if provided, or the system's default
        /// </summary>
        /// <param name="url"></param>
        /// <param name="incognito"></param>
        internal static void LaunchUrl(string url, bool incognito = false)
        {
            // did the user provide a browser?
            if (string.IsNullOrEmpty(Variables.AppSettings.BrowserBinary))
            {
                // nope
                using (_ = Process.Start(url)) { }
                return;
            }

            if (!File.Exists(Variables.AppSettings.BrowserBinary))
            {
                // yep, but not found
                Log.Warning("[BROWSER] User provided browser not found, using default: {bin}", Variables.AppSettings.BrowserBinary);

                using (_ = Process.Start(url)) { }
                return;
            }

            // yep, use it to launch
            using (var userBrowser = new Process())
            {
                var startupArgs = new ProcessStartInfo { FileName = Variables.AppSettings.BrowserBinary };

                // if incgonito flag is set, use the incog. args (if set) - otherwise, just the url
                if (incognito) startupArgs.Arguments = !string.IsNullOrEmpty(Variables.AppSettings.BrowserIncognitoArg) ? $"{Variables.AppSettings.BrowserIncognitoArg} {url}" : url;
                else startupArgs.Arguments = url;

                userBrowser.StartInfo = startupArgs;
                userBrowser.Start();
            }
        }

        /// <summary>
        /// Provides a dictionary containing the pointers and titles of all open windows
        /// </summary>
        /// <returns></returns>
        internal static IDictionary<IntPtr, string> GetOpenWindows()
        {
            var shellWindow = GetShellWindow();
            var windows = new Dictionary<IntPtr, string>();

            EnumWindows(delegate (IntPtr hWnd, int lParam)
            {
                if (hWnd == shellWindow) return true;
                if (!IsWindowVisible(hWnd)) return true;

                var length = GetWindowTextLength(hWnd);
                if (length == 0) return true;

                var builder = new StringBuilder(length);
                GetWindowText(hWnd, builder, length + 1);

                windows[hWnd] = builder.ToString();
                return true;

            }, 0);

            return windows;
        }

        private static readonly Dictionary<IntPtr, string> KnownOkInputLanguages = new Dictionary<IntPtr, string>
        {
            {new IntPtr(-268367863), "United States-International"},
            {new IntPtr(-268368877), "United States-International"}
        };

        private static readonly Dictionary<IntPtr, string> KnownNotOkInputLanguages = new Dictionary<IntPtr, string>
        {
            {new IntPtr(67568647), "German"}
        };

        /// <summary>
        /// Checks to see if the system's input language works with the default hotkey
        /// </summary>
        /// <param name="knownToCollide"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        internal static bool InputLanguageCheckDiffers(out bool knownToCollide, out string message)
        {
            message = string.Empty;
            knownToCollide = true;

            var inputLanguage = InputLanguage.CurrentInputLanguage.Handle;

            // check for known OK languages
            if (KnownOkInputLanguages.ContainsKey(inputLanguage)) return false;

            // check for known NOT OK languages
            if (KnownNotOkInputLanguages.ContainsKey(inputLanguage))
            {
                // get human-readable name
                var langName = KnownNotOkInputLanguages[inputLanguage];

                message = $"Your input language '{langName}' is known to collide with the default CTRL-ALT-Q hotkey. Please set your own.";
                return true;
            }

            // unknown
            knownToCollide = false;
            var layoutName = $"{InputLanguage.CurrentInputLanguage.Culture.DisplayName} - {InputLanguage.CurrentInputLanguage.LayoutName}";
            message = $"Your input language '{layoutName}' is unknown, and might collide with the default CTRL-ALT-Q hotkey. Please check to be sure. If it does, consider opening a ticket on GitHub so it can be added to the list.";
            return true;
        }

        /// <summary>
        /// Attempts to bring the provided form to the foreground if it's open
        /// </summary>
        /// <param name="formName"></param>
        /// <returns></returns>
        internal static async Task<bool> TryBringToFront(string formName)
        {
            try
            {
                // is it open?
                var form = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x.Name == formName);
                if (form == null) return false;

                // yep, check if we need to undo minimized
                if (form.WindowState == FormWindowState.Minimized) form.WindowState = FormWindowState.Normal;

                // force topmost for a bit
                form.TopMost = true;
                await Task.Delay(50);
                form.TopMost = false;

                // done
                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Checks the local file to see if it has the right signature
        /// </summary>
        /// <param name="localFile"></param>
        /// <returns></returns>
        internal static bool ConfirmCertificate(string localFile)
        {
            try
            {
                if (!File.Exists(localFile))
                {
                    Log.Error("[CERT] File not found, can't check certificate: {file}", localFile);
                    return false;
                }

                // load the cert, and specifically its hash
                var certInfo = X509Certificate.CreateFromSignedFile(localFile);
                var certHash = certInfo.GetCertHashString();

                // hash found?
                if (string.IsNullOrWhiteSpace(certHash))
                {
                    Log.Error("[CERT] IMPORTANT: Certificate check returned an empty hash - CHECK IF ITS PROPERLY SIGNED: {file}", localFile);
                    return false;
                }

                // compare hashes
                if (certHash != Variables.CertificateHash)
                {
                    Log.Error("[CERT] IMPORTANT: Certificate check FAILED: {file}", localFile);
                    return false;
                }

                // all good
                Log.Information("[CERT] Certificate check passed for file: {file}", localFile);
                return true;
            }
            catch (CryptographicException ex)
            {
                Log.Fatal(ex, "[CERT] IMPORTANT: Something went wrong while checking local file certificate - CHECK IF ITS ACTUALLY SIGNED: {file}", localFile);
                return false;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[CERT] Error while checking certificate of local file: {file}", localFile);
                return false;
            }
        }

        /// <summary>
        /// Returns a safe version of this machine's name
        /// </summary>
        /// <returns></returns>
        internal static string GetSafeDeviceName() => Regex.Replace(Environment.MachineName.ToLower(), "[^a-zA-Z0-9_-]", "_");

        /// <summary>
        /// Returns the configured device name, or a safe version of the machinename if nothing's stored
        /// </summary>
        /// <returns></returns>
        internal static string GetConfiguredDeviceName() =>
            string.IsNullOrEmpty(Variables.AppSettings?.DeviceName) 
                ? GetSafeDeviceName() 
                : Variables.AppSettings.DeviceName;

        /// <summary>
        /// Returns the safe variant of the configured device name, or a safe version of the machinename if nothing's stored
        /// </summary>
        /// <returns></returns>
        internal static string GetSafeConfiguredDeviceName() =>
            string.IsNullOrEmpty(Variables.AppSettings?.DeviceName)
                ? GetSafeDeviceName()
                : Regex.Replace(Variables.AppSettings.DeviceName.ToLower(), "[^a-zA-Z0-9_-]", "_");

        /// <summary>
        /// Returns a safe (lowercase) version of the provided value
        /// </summary>
        /// <returns></returns>
        internal static string GetSafeValue(string value) => Regex.Replace(value.ToLower(), "[^a-zA-Z0-9_-]", "_");

        /// <summary>
        /// Returns the owner of the supplied process
        /// </summary>
        /// <param name="process"></param>
        /// <param name="includeDomain"></param>
        /// <returns></returns>
        [SuppressMessage("ReSharper", "StringIndexOfIsCultureSpecific.1")]
        internal static string GetProcessOwner(Process process, bool includeDomain = true)
        {
            var processHandle = IntPtr.Zero;
            try
            {
                OpenProcessToken(process.Handle, 8, out processHandle);
                using (var wi = new WindowsIdentity(processHandle))
                {
                    var user = wi.Name;
                    if (!includeDomain) return user.Contains(@"\") ? user.Substring(user.IndexOf(@"\") + 1) : user;
                    else return user;
                }
            }
            catch
            {
                return "NO OWNER";
            }
            finally
            {
                if (processHandle != IntPtr.Zero) CloseHandle(processHandle);
            }
        }

        /// <summary>
        /// Checks whether the process is currently running under the current user, by default ignoring the current process
        /// </summary>
        /// <param name="process"></param>
        /// <param name="ignoreOwnProcess"></param>
        /// <returns></returns>
        internal static bool IsProcessActiveUnderCurrentUser(string process, bool ignoreOwnProcess = true)
        {
            try
            {
                if (process.Contains(".")) process = Path.GetFileNameWithoutExtension(process);
                var isRunning = false;
                var currentUser = Environment.UserName;

                var procs = Process.GetProcessesByName(process);
                using (var curProc = Process.GetCurrentProcess())
                {
                    var ownId = curProc.Id;

                    foreach (var proc in procs)
                    {
                        try
                        {
                            if (isRunning) continue;
                            if (ignoreOwnProcess && proc.Id == ownId) continue;
                            var owner = GetProcessOwner(proc, false);
                            if (owner != currentUser) continue;

                            isRunning = true;
                        }
                        finally
                        {
                            proc?.Dispose();
                        }
                    }
                }

                // done
                return isRunning;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[PROCESS] [{process}] Error while determining if process is running (ignoreOwnProcess: {ignore}): {msg}", process, ignoreOwnProcess, ex.Message);
                return false;
            }
        }
    }

    public class CamelCaseJsonNamingpolicy : JsonNamingPolicy
    {
        /// <summary>
        /// Convert name to lowerinvariant
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public override string ConvertName(string name) => name.ToLowerInvariant();
    }
}
