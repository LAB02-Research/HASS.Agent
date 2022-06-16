using Grapevine;
using HASS.Agent.Enums;
using HASS.Agent.Extensions;
using HASS.Agent.Managers;
using HASS.Agent.Media;
using HASS.Agent.Models.HomeAssistant;
using Serilog;
using HttpMethod = System.Net.Http.HttpMethod;

namespace HASS.Agent.API
{
    /// <summary>
    /// Endpoints for the local API
    /// </summary>
    public class ApiEndpoints : ApiDeserialization
    {
        /// <summary>
        /// Notification route, handles all incoming notifications on '/notify'
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task NotifyRoute(IHttpContext context)
        {
            try
            {
                var notification = await DeserializeAsync<Notification>(context.Request.InputStream, context.CancellationToken);
                _ = Task.Run(() => NotificationManager.ShowNotification(notification));
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[LOCALAPI] Error while processing incoming notification: {ex}", ex.Message);
            }
            finally
            {
                await context.Response.SendResponseAsync("notification processed");
            }
        }

        /// <summary>
        /// Media route, handles all incoming requests on '/media'
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task MediaRoute(IHttpContext context)
        {
            try
            {
                if (context.Request.HttpMethod != HttpMethod.Get) return;
                if (!context.Request.QueryString.HasKeys()) return;

                var apiMediaRequest = context.Request.QueryString.ParseApiMediaRequest();

                switch (apiMediaRequest.RequestType)
                {
                    case MediaRequestType.Unknown:
                        // unable to parse, drop
                        return;

                    case MediaRequestType.Request:
                        // HA's waiting for info, have the mediamanager return it
                        await context.Response.SendResponseAsync(MediaManager.ProcessRequest(apiMediaRequest.Request));
                        break;

                    case MediaRequestType.Command:
                        // have HA wait for us to complete
                        MediaManager.ProcessCommand(apiMediaRequest.Command);
                        break;

                    case MediaRequestType.PlayMedia:
                        // media might take a while, process async
                        _ = Task.Run(() => MediaManager.ProcessMedia(apiMediaRequest.MediaUri));
                        break;
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[LOCALAPI] Error while processing incoming media request: {ex}", ex.Message);
            }
        }
    }
}
