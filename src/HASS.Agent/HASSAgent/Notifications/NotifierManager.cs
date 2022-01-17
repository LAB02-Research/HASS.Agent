using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading.Tasks;
using Grapevine;
using HASSAgent.Enums;
using HASSAgent.Functions;
using HASSAgent.Models.HomeAssistant;
using Microsoft.Toolkit.Uwp.Notifications;
using Newtonsoft.Json;
using Serilog;

namespace HASSAgent.Notifications
{
    /// <summary>
    /// The Notification manager handles incoming notifications from HASS through a local Rest API (requires our custom integration)
    /// </summary>
    internal static class NotifierManager
    {
        /// <summary>
        /// Initializes and launches a new REST server to receive notifications
        /// </summary>
        internal static void Initialize()
        {
            if (!Variables.AppSettings.NotificationsEnabled)
            {
                Log.Information("[NOTIFIER] Disabled, skipping local API");
                Variables.MainForm?.SetNotificationApiStatus(ComponentStatus.Stopped);
                return;
            }

            Log.Information("[NOTIFIER] Initializing local API ..");

            // prepare and use a new server
            using (Variables.NotificationServer = RestServerBuilder.From<NotifierConfiguration>().Build())
            {
                Variables.NotificationServer.AfterStarting += (s) =>
                {
                    // root route to show we're up & running
                    s.Router.Register(new Route(async (ctx) =>
                    {
                        await ctx.Response.SendResponseAsync("HASS.Agent Active");
                    }, "Get", "/", true, "RootEndpoint"));

                    // notification route
                    var notifyRoute = new Route(NotifierEndpoints.NotifyRoute, "Post", "/notify", true, "NotifyRoute");
                    s.Router.Register(notifyRoute);

                    // done
                    Log.Information("[NOTIFIER] API listening on port {port}", Variables.AppSettings.NotifierApiPort);
                    Variables.MainForm?.SetNotificationApiStatus(ComponentStatus.Ok);
                };

                // register shutdown event
                Variables.NotificationServer.AfterStopping += (s) =>
                {
                    if (Variables.ShuttingDown) return;

                    Log.Information("[NOTIFIER] API stopped");
                    Variables.MainForm?.SetNotificationApiStatus(ComponentStatus.Stopped);
                };

                // try to launch server
                try
                {
                    Variables.NotificationServer.Run();
                }
                catch (Exception ex)
                {
                    Log.Fatal(ex, "[NOTIFIER] Error trying to bind the API to port {port}: {err}", Variables.AppSettings.NotifierApiPort, ex.Message);
                    Variables.MainForm?.ShowMessageBox($"Error trying to bind the API to port {Variables.AppSettings.NotifierApiPort}.\r\n\r\nMake sure no other instance of HASS.Agent is running and the port is available and registered.", true);

                    Variables.MainForm?.SetNotificationApiStatus(ComponentStatus.Failed);
                }
            }
        }

        /// <summary>
        /// Stops and disposes the REST server
        /// </summary>
        internal static void Stop()
        {
            try
            {
                Variables.NotificationServer?.Stop();
                Variables.NotificationServer?.Dispose();
            }
            catch (ObjectDisposedException)
            {
                // whatever
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[NOTIFIER] Error trying to stop: {err}", ex.Message);
            }
        }

        /// <summary>
        /// Show a notification object as a toast message
        /// </summary>
        /// <param name="notification"></param>
        internal static void ShowNotification(Notification notification)
        {
            try
            {
                // are notifications enabled?
                if (!Variables.AppSettings.NotificationsEnabled) return;

                // prepare new toast
                var toastBuilder = new ToastContentBuilder();

                // prepare title
                if (string.IsNullOrWhiteSpace(notification.Title)) notification.Title = "Home Assistant";
                toastBuilder.AddHeader("HASS.Agent", notification.Title, string.Empty);
                
                // prepare image
                if (!string.IsNullOrWhiteSpace(notification.Image))
                {
                    var imageOk = HelperFunctions.DownloadImage(notification.Image, out var localPath);
                    if (imageOk) toastBuilder.AddInlineImage(new Uri(localPath));
                    else Log.Error("[NOTIFIER] Image download failed, dropping: {img}", notification.Image);
                }

                // prepare message
                toastBuilder.AddText(notification.Message);

                // check for duration limit
                if (notification.Duration > 0)
                {
                    // there's a duration added, so show for x seconds
                    // todo: unreliable
                    toastBuilder.Show(toast =>
                    {
                        toast.ExpiresOnReboot = true;
                        toast.ExpirationTime = DateTime.Now.AddSeconds(notification.Duration);
                    });

                    return;
                }

                // show indefinitely, but clear on reboot
                toastBuilder.Show(toast =>
                {
                    toast.ExpiresOnReboot = true;
                });
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[NOTIFIER] Error while showing notification:\r\n{json}", JsonConvert.SerializeObject(notification, Formatting.Indented));
            }
        }

        /// <summary>
        /// Attempt to add HTTP port reservation through an elevated console
        /// </summary>
        /// <returns></returns>
        internal static bool ExecuteElevatedPortReservation()
        {
            try
            {
                using (var p = new Process())
                {
                    p.StartInfo.Verb = "runas";
                    p.StartInfo.FileName = Variables.ApplicationExecutable;
                    p.StartInfo.Arguments = "portreservation";

                    var success = p.Start();
                    if (!success)
                    {
                        Log.Error("[NOTIFIER] Error while executing elevated port reservation");
                        return false;
                    }

                    p.WaitForExit();

                    if (p.ExitCode != 0) Log.Warning("[NOTIFIER] Elevated port reservation executed with non-standard exitcode: {exitcode}", p.ExitCode);
                    else Log.Information("[NOTIFIER] Elevated port reservation executed succesfully");

                    return p.ExitCode == 0;
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Attempt to add HTTP port reservation (requires elevation!)
        /// </summary>
        /// <returns></returns>
        [SuppressMessage("ReSharper", "InvertIf")]
        internal static async Task<bool> ExecutePortReservationAsync(int port)
        {
            try
            {
                Log.Information("[NOTIFIER] Executing port reservation for port: {port}", port);

                var args = $"http add urlacl url=http://+:{port}/ user={Environment.UserDomainName}\\{Environment.UserName}";
                var executionResult = await CommandLine.ExecuteCommandAsync("netsh", args, TimeSpan.FromMinutes(2));

                // capture normal and error output
                var output = executionResult.Output.Trim();
                var errOutput = executionResult.ErrorOutput.Trim();
                var exitCode = executionResult.ExitCode;

                // check for all-good output
                if (output.Contains("URL reservation successfully added"))
                {
                    Log.Information("[NOTIFIER] Port reservation succesfully added");
                    return true;
                }

                // check for already-exists
                if (output.Contains("183") || errOutput.Contains("183"))
                {
                    Log.Information("[NOTIFIER] Port reservation already exists, nothing to do");
                    return true;
                }

                // nope, something went wrong
                Log.Error("[NOTIFIER] Unexpected console output, port reservation probably failed");
                if (executionResult.Error) Log.Error("[NOTIFIER] Completed with errors");
                if (exitCode != 0) Log.Error("[NOTIFIER] Completed with non-zero exitcode: {code}", exitCode);

                // process & print normal output
                if (!string.IsNullOrEmpty(output))
                {
                    var consoleLog = new StringBuilder();

                    consoleLog.AppendLine("[NOTIFIER] Console output:");
                    consoleLog.AppendLine("");
                    consoleLog.AppendLine(output);
                    consoleLog.AppendLine("");

                    Log.Information(consoleLog.ToString());
                }

                // process & print error output
                if (!string.IsNullOrEmpty(errOutput))
                {
                    var consoleErrLog = new StringBuilder();

                    consoleErrLog.AppendLine("[NOTIFIER] Error output:");
                    consoleErrLog.AppendLine("");
                    consoleErrLog.AppendLine(errOutput);
                    consoleErrLog.AppendLine("");

                    Log.Error(consoleErrLog.ToString());
                }

                // done
                return false;
            }
            catch (Exception ex)
            {
                Log.Fatal("[NOTIFIER] Error while executing port reservation: {msg}", ex.Message);
                return false;
            }
        }
    }
}
