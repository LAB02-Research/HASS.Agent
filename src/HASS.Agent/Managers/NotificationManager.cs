using HASS.Agent.API;
using HASS.Agent.Functions;
using HASS.Agent.HomeAssistant;
using HASS.Agent.Models.HomeAssistant;
using Microsoft.Toolkit.Uwp.Notifications;
using MQTTnet;
using Newtonsoft.Json;
using Serilog;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace HASS.Agent.Managers
{
    internal static class NotificationManager
    {
        /// <summary>
        /// Initializes the notification manager
        /// </summary>
        internal static void Initialize()
        {
            if (!Variables.AppSettings.NotificationsEnabled)
            {
                Log.Information("[NOTIFIER] Disabled");
                return;
            }

            if (!Variables.AppSettings.LocalApiEnabled && !Variables.AppSettings.MqttEnabled)
            {
                Log.Warning("[NOTIFIER] Both local API and MQTT are disabled, unable to receive notifications");
                return;
            }

            _ = Task.Run(Variables.MqttManager.SubscribeNotificationsAsync);

            ToastNotificationManagerCompat.OnActivated += OnNotificationButtonPressed;

            // no task other than logging
            Log.Information("[NOTIFIER] Ready");
        }

        private static async void OnNotificationButtonPressed(ToastNotificationActivatedEventArgsCompat e)
        {
            var haEventTask = HassApiManager.FireEvent("hass_agent_notifications", new
            {
                device_name = HelperFunctions.GetConfiguredDeviceName(),
                action = e.Argument
            });

            var haMessageBuilder = new MqttApplicationMessageBuilder()
                .WithTopic($"hass.agent/notifications/{Variables.DeviceConfig.Name}/actions")
                .WithPayload(JsonSerializer.Serialize(new
                {
                    action = e.Argument,
                    input = e.UserInput.ContainsKey("input") ? e.UserInput["input"] : null
                }, ApiDeserialization.SerializerOptions));
            
            var mqttTask = Variables.MqttManager.PublishAsync(haMessageBuilder.Build());

            await Task.WhenAny(haEventTask, mqttTask);
        }

        /// <summary>
        /// Show a notification object as a toast message
        /// </summary>
        /// <param name="notification"></param>
        internal static async void ShowNotification(Notification notification)
        {
            try
            {
                // are notifications enabled?
                if (!Variables.AppSettings.NotificationsEnabled) return;

                // prepare new toast
                var toastBuilder = new ToastContentBuilder();

                // prepare title
                toastBuilder.AddHeader("HASS.Agent", notification.Title, string.Empty);

                // prepare image
                if (!string.IsNullOrWhiteSpace(notification.Data?.Image))
                {
                    var (success, localFile) = await StorageManager.DownloadImageAsync(notification.Data.Image);
                    if (success) toastBuilder.AddInlineImage(new Uri(localFile));
                    else Log.Error("[NOTIFIER] Image download failed, dropping: {img}", notification.Data.Image);
                }

                // prepare message
                toastBuilder.AddText(notification.Message);

                if (notification.Data?.Actions.Count > 0)
                {
                    foreach (var action in notification.Data.Actions)
                    {
                        if (string.IsNullOrEmpty(action.Action)) continue;
                        toastBuilder.AddButton(action.Title, ToastActivationType.Background, action.Action);
                    }
                }

                // check for duration limit
                if (notification.Data?.Duration > 0)
                {
                    // there's a duration added, so show for x seconds
                    // todo: unreliable
                    toastBuilder.Show(toast =>
                    {
                        toast.ExpirationTime = DateTime.Now.AddSeconds(notification.Data.Duration);
                    });

                    return;
                }

                // show indefinitely, but clear on reboot
                toastBuilder.Show();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[NOTIFICATIONS] Error while showing notification:\r\n{json}", JsonConvert.SerializeObject(notification, Formatting.Indented));
            }
        }
    }
}
