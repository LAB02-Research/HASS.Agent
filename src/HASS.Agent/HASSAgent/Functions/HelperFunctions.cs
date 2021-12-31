using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using Coderr.Client;
using Coderr.Client.Serilog;
using HASSAgent.Commands;
using HASSAgent.Enums;
using HASSAgent.Models;
using HASSAgent.Models.Internal;
using HASSAgent.Mqtt;
using HASSAgent.Notifications;
using HASSAgent.Sensors;
using Microsoft.Win32.TaskScheduler;
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

        /// <summary>
        /// Initializes Syncfusion's messagebox style
        /// Todo: incomplete, button color etc need to be done
        /// </summary>
        internal static void SetMsgBoxStyle()
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

            MessageBoxAdv.CaptionFont = Variables.MainForm.Font;
            MessageBoxAdv.ButtonFont = Variables.MainForm.Font;
            MessageBoxAdv.DetailsFont = Variables.MainForm.Font;
            MessageBoxAdv.MessageFont = Variables.MainForm.Font;
        }

        /// <summary>
        /// Download an image to local temp path
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="localPath"></param>
        /// <returns></returns>
        internal static bool DownloadImage(string uri, out string localPath)
        {
            localPath = string.Empty;

            try
            {
                if (string.IsNullOrWhiteSpace(uri))
                {
                    Log.Error("[DOWNLOADIMAGE] Can't parse an empty uri");
                    return false;
                }

                if (!uri.StartsWith("http"))
                {
                    Log.Error("[DOWNLOADIMAGE] Only HTTP uri's are allowed, received: {uri}", uri);
                    return false;
                }

                if (!Directory.Exists(Variables.TempPath)) Directory.CreateDirectory(Variables.TempPath);

                // check for extension
                // this fails for hass proxy urls, so add an extra length check
                var ext = Path.GetExtension(uri);
                if (string.IsNullOrEmpty(ext) || ext.Length > 5) ext = ".png";

                // create a random local filename
                var localFile = $"{DateTime.Now:yyyyMMddHHmmss}_{Guid.NewGuid().ToString().Substring(0, 8)}";
                localPath = Path.Combine(Variables.TempPath, $"{localFile}{ext}");

                // make the uri safe
                var safeUri = Uri.EscapeUriString(uri);
                
                // download the file
                Variables.ImageWebClient.DownloadFile(new Uri(safeUri), localPath);

                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[DOWNLOADIMAGE] Error downloading image: {uri}", uri);
                return false;
            }
        }

        /// <summary>
        /// Initializes Serilog logger, optionally with Coderr
        /// </summary>
        /// <param name="enableCoderr"></param>
        internal static void PrepareLogging(bool enableCoderr)
        {
            if (enableCoderr)
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
        }

        /// <summary>
        /// Determines if HASS.Agent has been launched through Scheduled Task or not, and restarts accordingly
        /// </summary>
        /// <returns></returns>
        internal static bool Restart()
        {
            try
            {
                // check if there's a task
                var present = ScheduledTasks.IsTaskPresent();
                if (!present) return RestartWithoutTask();

                // get task status
                var status = ScheduledTasks.TaskStatus();
                
                // check if it's running or ready
                if (status != TaskState.Running && status != TaskState.Ready) return RestartWithoutTask();

                // restart using task
                return RestartWithTask();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SYSTEM] Error executing restart: {msg}", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Restart HASS.Agent based on its Scheduled Task
        /// <para>Optionally check for existence/status by enabling the 'performCheck' bool</para>
        /// </summary>
        /// <param name="performCheck"></param>
        /// <returns></returns>
        internal static bool RestartWithTask(bool performCheck = false)
        {
            try
            {
                if (performCheck)
                {
                    // check if there's a task
                    var present = ScheduledTasks.IsTaskPresent();
                    if (!present) return false;

                    // get task status
                    var status = ScheduledTasks.TaskStatus();

                    // check if it's running or ready
                    if (status != TaskState.Running && status != TaskState.Ready) return false;
                }

                var restartBat = Path.Combine(Variables.StartupPath, "restart_hass_agent.bat");
                if (File.Exists(restartBat)) File.Delete(restartBat);

                var restartBatContent = new StringBuilder();

                // prepare the .bat content
                restartBatContent.AppendLine("@echo off");
                restartBatContent.AppendLine("TITLE HASS.Agent Restarter");
                restartBatContent.AppendLine("echo.");
                restartBatContent.AppendLine("echo HASS.Agent Restarter");
                restartBatContent.AppendLine("echo.");
                restartBatContent.AppendLine("echo.");
                restartBatContent.AppendLine("echo Waiting 10 seconds for HASS.Agent to properly close ..");
                restartBatContent.AppendLine("echo.");
                restartBatContent.AppendLine("timeout 10 > NUL");
                restartBatContent.AppendLine("echo.");
                restartBatContent.AppendLine($"echo Starting scheduled task: {ScheduledTasks.TaskName} ..");
                restartBatContent.AppendLine($"schtasks /run /TN \"{ScheduledTasks.TaskName}\"");
                restartBatContent.AppendLine("echo.");
                restartBatContent.AppendLine("echo Done!");
                restartBatContent.AppendLine("timeout 1 > NUL");

                // create the .bat
                File.WriteAllText(restartBat, restartBatContent.ToString());

                // launch it
                Process.Start(restartBat);

                // close up
                _ = ShutdownAsync();

                // done
                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SYSTEM] Error executing task restart: {err}", ex.Message);
                return false;
            }
        }

        private static bool RestartWithoutTask()
        {
            try
            {
                var restartBat = Path.Combine(Variables.StartupPath, "restart_hass_agent.bat");
                if (File.Exists(restartBat)) File.Delete(restartBat);
                
                var restartBatContent = new StringBuilder();

                // prepare the .bat content
                restartBatContent.AppendLine("@echo off");
                restartBatContent.AppendLine("TITLE HASS.Agent Restarter");
                restartBatContent.AppendLine("echo.");
                restartBatContent.AppendLine("echo HASS.Agent Restarter");
                restartBatContent.AppendLine("echo.");
                restartBatContent.AppendLine("echo.");
                restartBatContent.AppendLine("echo Waiting 10 seconds for HASS.Agent to properly close ..");
                restartBatContent.AppendLine("echo.");
                restartBatContent.AppendLine("timeout 10 > NUL");
                restartBatContent.AppendLine("echo.");
                restartBatContent.AppendLine("echo Launching HASS.Agent ..");
                restartBatContent.AppendLine($"start \"\" \"{Variables.ApplicationExecutable}\"");
                restartBatContent.AppendLine("echo.");
                restartBatContent.AppendLine("echo Done!");
                restartBatContent.AppendLine("timeout 1 > NUL");

                // create the .bat
                File.WriteAllText(restartBat, restartBatContent.ToString());

                // launch it
                Process.Start(restartBat);

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
            try
            {
                // announce we're stopping
                Variables.ShuttingDown = true;

                // wait a bit
                await Task.Delay(waitBeforeClosing);

                // log our demise
                Log.Information("[SYSTEM] Application shutting down");

                // stop mqtt
                await MqttManager.AnnounceAvailabilityAsync(true);
                MqttManager.Disconnect();

                // stop hotkey
                Variables.UiDispatcher.Invoke(new MethodInvoker(delegate
                {
                    Variables.HotKeyListener?.RemoveAll();
                    Variables.HotKeyListener?.Dispose();
                }));

                // stop notifier api
                NotifierManager.Stop();

                // process disposables
                Variables.ImageWebClient?.Dispose();

                // stop entity managers
                CommandsManager.Stop();
                SensorsManager.Stop();

                // flush the log
                Log.Information("[SYSTEM] Application shutdown complete");
                Log.CloseAndFlush();

                if (!Variables.MainForm.IsHandleCreated) return;
                if (Variables.MainForm.IsDisposed) return;

                // try to close nicely
                Application.Exit();
            }
            catch (Exception ex)
            {
                Log.Error("[SYSTEM] Error shutting down nicely: {msg}", ex.Message);
                Log.CloseAndFlush();

                // screw it
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
        /// Launches the system's default browser with the provided url
        /// </summary>
        /// <param name="url"></param>
        internal static void LaunchUrl(string url) => Process.Start(url);

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
