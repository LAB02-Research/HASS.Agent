using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Coderr.Client;
using Coderr.Client.Serilog;
using HASSAgent.Commands;
using HASSAgent.Enums;
using HASSAgent.Models;
using HASSAgent.Mqtt;
using HASSAgent.Notifications;
using HASSAgent.Sensors;
using Serilog;
using Syncfusion.Windows.Forms;

namespace HASSAgent.Functions
{
    internal static class HelperFunctions
    {
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

            MessageBoxAdv.CaptionFont = Variables.FrmM.Font;
            MessageBoxAdv.ButtonFont = Variables.FrmM.Font;
            MessageBoxAdv.DetailsFont = Variables.FrmM.Font;
            MessageBoxAdv.MessageFont = Variables.FrmM.Font;
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

                var ext = Path.GetExtension(uri);
                if (string.IsNullOrEmpty(ext)) ext = ".png";

                var localFile = $"{DateTime.Now:yyyyMMddHHmmss}_{Guid.NewGuid().ToString().Substring(0, 8)}";
                localPath = Path.Combine(Variables.TempPath, $"{localFile}.{ext}");

                Variables.ImageWebClient.DownloadFile(new Uri(uri), localPath);

                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[DOWNLOADIMAGE] Error downloading image: {uri}", uri);
                return false;
            }
        }

        /// <summary>
        /// Initializes Serilog logger, optionally with coderr
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
        /// Try to properly close the application
        /// </summary>
        internal static async Task Shutdown()
        {
            try
            {
                // announce we're stopping
                Variables.ShuttingDown = true;

                // log it
                Log.Information("[SYSTEM] Application shutting down");

                // stop hotkey
                Variables.HotKeyListener?.RemoveAll();

                // stop notifier api
                NotifierManager.Stop();

                // process disposables
                Variables.ImageWebClient?.Dispose();
                Variables.HotKeyListener?.Dispose();

                // stop entity managers
                CommandsManager.Stop();
                SensorsManager.Stop();

                // stop mqtt
                await MqttManager.AnnounceAvailabilityAsync("sensor", true);
                MqttManager.Disconnect();

                // flush the log
                Log.Information("[SYSTEM] Application shutdown complete");
                Log.CloseAndFlush();

                if (!Variables.FrmM.IsHandleCreated) return;
                if (Variables.FrmM.IsDisposed) return;

                // try to close nicely
                Application.Exit();
            }
            catch
            {
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
