using System;
using Grapevine;
using HASSAgent.Enums;
using HASSAgent.Functions;
using HASSAgent.Models;
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
                    Variables.FrmM?.SetNotificationApiStatus(ComponentStatus.Ok);
                };

                // register shutdown event
                Variables.NotificationServer.AfterStopping += (s) =>
                {
                    if (Variables.ShuttingDown) return;

                    Log.Information("[NOTIFIER] API stopped");
                    Variables.FrmM?.SetNotificationApiStatus(ComponentStatus.Stopped);
                };

                // try to launch server
                try
                {
                    Variables.NotificationServer.Run();
                }
                catch (Exception ex)
                {
                    Log.Fatal(ex, "[NOTIFIER] Error trying to bind the API to port {port}: {err}", Variables.AppSettings.NotifierApiPort, ex.Message);
                    Variables.FrmM?.ShowMessageBox($"Error trying to bind the API to port {Variables.AppSettings.NotifierApiPort}.\r\n\r\nMake sure you have administrator rights, no other instance of HASS Agent is running\r\nand the port is available.", true);

                    Variables.FrmM?.SetNotificationApiStatus(ComponentStatus.Failed);
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
    }
}
