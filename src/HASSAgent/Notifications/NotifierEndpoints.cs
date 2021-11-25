using System;
using System.Threading.Tasks;
using Grapevine;
using HASSAgent.Models;
using Serilog;

namespace HASSAgent.Notifications
{
    /// <summary>
    /// Endpoints for the Notificatoin API
    /// </summary>
    public class NotifierEndpoints : NotifierDeserialization
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
                _ = Task.Run(() => NotifierManager.ShowNotification(notification));
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[NOTIFIER] Error while processing incoming notification: {ex}", ex.Message);
            }
            finally
            {
                await context.Response.SendResponseAsync("notification processed");
            }
        }
    }
}
