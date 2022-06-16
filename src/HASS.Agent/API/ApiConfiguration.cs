using System.Diagnostics.CodeAnalysis;
using Grapevine;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace HASS.Agent.API
{
    /// <summary>
    /// Configuration for the local API
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class ApiConfiguration
    {
        public IConfiguration Configuration { get; private set; }

        public ApiConfiguration(IConfiguration configuration)
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
