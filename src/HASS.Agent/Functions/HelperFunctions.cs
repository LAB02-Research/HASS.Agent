using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using HASS.Agent.API;
using HASS.Agent.Commands;
using HASS.Agent.Enums;
using HASS.Agent.Forms;
using HASS.Agent.Models.Internal;
using HASS.Agent.Resources.Localization;
using HASS.Agent.Sensors;
using HASS.Agent.Shared.Functions;
using Serilog;
using Syncfusion.Windows.Forms;
using Task = System.Threading.Tasks.Task;
using MediaManager = HASS.Agent.Media.MediaManager;

namespace HASS.Agent.Functions
{
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

        [DllImport("gdi32.dll")]
        private static extern int GetDeviceCaps(IntPtr hdc, int nIndex);
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        private enum DeviceCap
        {
            VERTRES = 10,
            DESKTOPVERTRES = 117,
            LOGPIXELSY = 90

            // http://pinvoke.net/default.aspx/gdi32/GetDeviceCaps.html
        }

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
        /// Returns the scaling and dpi scaling factors
        /// Based on https://stackoverflow.com/a/33791877
        /// </summary>
        /// <returns></returns>
        internal static (float scalingFactor, float dpiScalingFactor) GetScalingFactors()
        {
            try
            {
                using var g = Graphics.FromHwnd(IntPtr.Zero);

                // get desktop handle
                var desktop = g.GetHdc();

                // get size variables
                var logicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.VERTRES);
                var physicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.DESKTOPVERTRES);
                var logpixelsy = GetDeviceCaps(desktop, (int)DeviceCap.LOGPIXELSY);

                // determine the scaling factors
                var screenScalingFactor = (float)physicalScreenHeight / (float)logicalScreenHeight;
                var dpiScalingFactor = (float)logpixelsy / (float)96;

                // release the handle
                g.ReleaseHdc(desktop);

                // done
                return (screenScalingFactor, dpiScalingFactor);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SYSTEM] Unable to determine scaling factors: {err}", ex.Message);
                return (1, 1);
            }
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
                    using (_ = Process.Start(new ProcessStartInfo(Variables.ApplicationExecutable, "restart") { UseShellExecute = true })) { }
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
            var exitCode = 0;

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
                    await Variables.MqttManager.AnnounceAvailabilityAsync(true);
                    Variables.MqttManager.Disconnect();

                    // remove tray icon
                    Variables.MainForm?.HideTrayIcon();

                    // stop hotkey
                    Variables.MainForm?.Invoke(new MethodInvoker(delegate
                    {
                        Variables.HotKeyListener?.RemoveAll();
                        Variables.HotKeyListener?.Dispose();
                    }));

                    // stop notifier api
                    ApiManager.Stop();

                    // process disposables
                    Variables.HttpClient?.Dispose();

                    // stop media manager
                    MediaManager.Stop();

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
                exitCode = 1;

                if (!logClosed)
                {
                    Log.Error("[SYSTEM] Error shutting down nicely: {msg}", ex.Message);
                    Log.CloseAndFlush();
                }
            }
            finally
            {
                // shutdown
                Environment.Exit(exitCode);
            }
        }

        /// <summary>
        /// Tries to parse the keyString into multiple keys (they need to be encapsuled in square brackets)
        /// </summary>
        /// <param name="keyString"></param>
        /// <param name="keys"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        internal static bool ParseMultipleKeys(string keyString, out List<string> keys, out string errorMsg)
        {
            keys = new List<string>();
            errorMsg = string.Empty;

            try
            {
                // any value?
                if (string.IsNullOrWhiteSpace(keyString))
                {
                    errorMsg = Languages.HelperFunctions_ParseMultipleKeys_ErrorMsg1;
                    return false;
                }

                // any brackets?
                if (!keyString.Contains('[') || !keyString.Contains(']'))
                {
                    errorMsg = Languages.HelperFunctions_ParseMultipleKeys_ErrorMsg2;
                    return false;
                }

                // replace all escaped brackets
                // todo: ugly, let regex do that
                keyString = keyString.Replace(@"\[", "left_bracket");
                keyString = keyString.Replace(@"\]", "right_bracket");

                // lets see if the brackets corresponds
                var leftBrackets = keyString.Count(x => x == '[');
                var rightBrackets = keyString.Count(x => x == ']');

                if (leftBrackets != rightBrackets)
                {
                    errorMsg = string.Format(Languages.HelperFunctions_ParseMultipleKeys_ErrorMsg4, leftBrackets, rightBrackets);
                    return false;
                }

                // ok, try parsen
                var pattern = @"\[(.*?)\]";
                var matches = Regex.Matches(keyString, pattern);
                keys.AddRange(from Match m in matches select m.Groups[1].ToString());

                // restore escaped brackets
                for (var i = 0; i < keys.Count; i++)
                {
                    if (keys[i] == "left_bracket") keys[i] = "[";
                    if (keys[i] == "right_bracket") keys[i] = "]";
                }

                // done
                return true;
            }
            catch (Exception ex)
            {
                errorMsg = Languages.HelperFunctions_ParseMultipleKeys_ErrorMsg3;
                Log.Error("[PARSER] Error parsing multiple keys: {msg}", ex.Message);
                return false;
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
                Log.Fatal(ex, "[HF] Unable to determine a proper row/column count for the quickactions: {err}", ex.Message);
                return (0, 0);
            }
        }

        /// <summary>
        /// Opens the path in Explorer
        /// </summary>
        /// <param name="path"></param>
        internal static void OpenLocalFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Log.Error("[HF] Unable to open non-existing path: {path}", path);
                return;
            }

            var winDir = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
            using (_ = Process.Start(new ProcessStartInfo($"{winDir}\\explorer.exe", path) { UseShellExecute = true })) { }
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
                using (_ = Process.Start(new ProcessStartInfo(url) { UseShellExecute = true })) { }
                return;
            }

            if (!File.Exists(Variables.AppSettings.BrowserBinary))
            {
                // yep, but not found
                Log.Warning("[BROWSER] User provided browser not found, using default: {bin}", Variables.AppSettings.BrowserBinary);

                using (_ = Process.Start(new ProcessStartInfo(url) { UseShellExecute = true })) { }
                return;
            }

            // yep, use it to launch
            using var userBrowser = new Process();
            var startupArgs = new ProcessStartInfo { FileName = Variables.AppSettings.BrowserBinary };

            // if incgonito flag is set, use the incog. args (if set) - otherwise, just the url
            if (incognito) startupArgs.Arguments = !string.IsNullOrEmpty(Variables.AppSettings.BrowserIncognitoArg) ? $"{Variables.AppSettings.BrowserIncognitoArg} {url}" : url;
            else startupArgs.Arguments = url;

            userBrowser.StartInfo = startupArgs;
            userBrowser.Start();
        }

        /// <summary>
        /// Shows a new webview form with the provided config
        /// </summary>
        /// <param name="webViewInfo"></param>
        /// <param name="url"></param>
        internal static void LaunchWebView(WebViewInfo webViewInfo, string url = "")
        {
            // optionally set an alternative url
            if (!string.IsNullOrEmpty(url)) webViewInfo.Url = url;

            // show it from within the UI thread
            Variables.MainForm.Invoke(new MethodInvoker(delegate
            {
                var webView = new WebView(webViewInfo);
                webView.Opacity = 0;
                webView.Show();
            }));
        }

        /// <summary>
        /// Prepares and loadsthe tray icon's webview
        /// </summary>
        internal static void PrepareTrayIconWebView()
        {
            // prepare the webview info
            var webViewInfo = new WebViewInfo
            {
                Url = Variables.AppSettings.TrayIconWebViewUrl,
                Height = Variables.AppSettings.TrayIconWebViewHeight,
                Width = Variables.AppSettings.TrayIconWebViewWidth,
            };

            var x = Screen.PrimaryScreen.WorkingArea.Width - webViewInfo.Width;
            var y = Screen.PrimaryScreen.WorkingArea.Height - webViewInfo.Height;

            webViewInfo.X = x;
            webViewInfo.Y = y;

            webViewInfo.TopMost = true;
            webViewInfo.ShowTitleBar = false;
            webViewInfo.CenterScreen = false;
            webViewInfo.IsTrayIconWebView = true;

            // prepare the webview
            Variables.MainForm.Invoke(new MethodInvoker(delegate
            {
                Variables.TrayIconWebView = new WebView(webViewInfo);
                Variables.TrayIconWebView.Opacity = 0;
                Variables.TrayIconWebView.Show();
            }));
        }

        /// <summary>
        /// Shows a new webview form near the tray icon
        /// </summary>
        /// <param name="webViewInfo"></param>
        internal static void LaunchTrayIconWebView(WebViewInfo webViewInfo)
        {
            // is background loading enabled?
            if (Variables.AppSettings.TrayIconWebViewBackgroundLoading)
            {
                // yep
                Variables.MainForm.Invoke(new MethodInvoker(delegate
                {
                    // make sure it's ready
                    if (Variables.TrayIconWebView == null) PrepareTrayIconWebView();

                    // show it
                    Variables.TrayIconWebView?.MakeVisible();
                }));

                // done
                return;
            }

            // show a new webview from within the UI thread
            Variables.MainForm.Invoke(new MethodInvoker(delegate
            {
                var x = Screen.PrimaryScreen.WorkingArea.Width - webViewInfo.Width;
                var y = Screen.PrimaryScreen.WorkingArea.Height - webViewInfo.Height;

                webViewInfo.X = x;
                webViewInfo.Y = y;

                webViewInfo.TopMost = true;
                webViewInfo.ShowTitleBar = false;
                webViewInfo.CenterScreen = false;
                webViewInfo.IsTrayIconWebView = true;

                var webView = new WebView(webViewInfo);
                webView.Opacity = 0;
                webView.Show();
            }));
        }

        private static readonly Dictionary<IntPtr, string> KnownOkInputLanguage = new()
        {
            { new IntPtr(-268367863), "United States-International" },
            { new IntPtr(-268368877), "United States-International" }
        };

        private static readonly Dictionary<IntPtr, string> KnownNotOkInputLanguage = new()
        {
            { new IntPtr(67568647), "German" }
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
            if (KnownOkInputLanguage.ContainsKey(inputLanguage)) return false;

            // check for known NOT OK languages
            if (KnownNotOkInputLanguage.ContainsKey(inputLanguage))
            {
                // get human-readable name
                var langName = KnownNotOkInputLanguage[inputLanguage];

                message = string.Format(Languages.HelperFunctions_InputLanguageCheckDiffers_ErrorMsg1, langName);
                return true;
            }

            // unknown
            knownToCollide = false;
            var layoutName = $"{InputLanguage.CurrentInputLanguage.Culture.DisplayName} - {InputLanguage.CurrentInputLanguage.LayoutName}";
            message = string.Format(Languages.HelperFunctions_InputLanguageCheckDiffers_ErrorMsg2, layoutName);
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
        /// Returns the configured device name, or a safe version of the machinename if nothing's stored
        /// </summary>
        /// <returns></returns>
        internal static string GetConfiguredDeviceName() =>
            string.IsNullOrEmpty(Variables.AppSettings?.DeviceName) 
                ? SharedHelperFunctions.GetSafeDeviceName() 
                : SharedHelperFunctions.GetSafeValue(Variables.AppSettings.DeviceName);
        
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
                if (process.Contains('.')) process = Path.GetFileNameWithoutExtension(process);
                var isRunning = false;
                var currentUser = Environment.UserName;

                var procs = Process.GetProcessesByName(process);
                using var curProc = Process.GetCurrentProcess();
                var ownId = curProc.Id;

                foreach (var proc in procs)
                {
                    try
                    {
                        if (isRunning) continue;
                        if (ignoreOwnProcess && proc.Id == ownId) continue;
                        var owner = SharedHelperFunctions.GetProcessOwner(proc, false);
                        if (owner != currentUser) continue;

                        isRunning = true;
                    }
                    finally
                    {
                        proc.Dispose();
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

        /// <summary>
        /// Checks whether the provided scope-string is probably indeed a WMI scope (no guarantees!)
        /// </summary>
        /// <param name="scope"></param>
        /// <returns></returns>
        internal static bool CheckWmiScope(string scope) => scope.StartsWith(@"\\");
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
