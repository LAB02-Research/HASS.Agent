using System.Diagnostics.CodeAnalysis;
using Grapevine;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace HASSAgent.Notifications
{
    /// <summary>
    /// Configuration for the Notification API
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class NotifierConfiguration
    {
        public IConfiguration Configuration { get; private set; }

        public NotifierConfiguration(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.AddSerilog();
            });
        }

        public void ConfigureServer(IRestServer server)
        {
            server.Prefixes.Add($"http://+:{Variables.AppSettings.NotifierApiPort}/");
            server.Router.Options.SendExceptionMessages = true;
        }
    }
}
