using HASS.Agent.Functions;
using HASS.Agent.Models.Internal;
using HASS.Agent.Shared.Enums;
using HASS.Agent.Shared.HomeAssistant.Commands;
using Newtonsoft.Json;
using Serilog;

namespace HASS.Agent.HomeAssistant.Commands.InternalCommands
{
    internal class LaunchUrlCommand : InternalCommand
    {
        private readonly string _url = string.Empty;
        private readonly bool _incognito;

        internal LaunchUrlCommand(string name = "LaunchUrl", string urlInfo = "", CommandEntityType entityType = CommandEntityType.Switch, string id = default) : base(name ?? "LaunchUrl", urlInfo, entityType, id)
        {
            CommandConfig = urlInfo;
            State = "OFF";

            if (string.IsNullOrEmpty(urlInfo)) return;
            var urlPackage = JsonConvert.DeserializeObject<UrlInfo>(urlInfo);
            if (urlPackage == null) return;

            _url = urlPackage.Url;
            _incognito = urlPackage.Incognito;
        }

        public override void TurnOn()
        {
            State = "ON";

            if (string.IsNullOrWhiteSpace(_url))
            {
                Log.Error("[LAUNCHURL] [{name}] Unable to launch URL, it's configured as action-only", Name);

                State = "OFF";
                return;
            }

            HelperFunctions.LaunchUrl(_url, _incognito);

            State = "OFF";
        }

        public override void TurnOnWithAction(string action)
        {
            State = "ON";

            if (string.IsNullOrWhiteSpace(action) && string.IsNullOrWhiteSpace(_url))
            {
                Log.Error("[LAUNCHURL] [{name}] Unable to launch URL, it's configured as action-only but no URL is provided.", Name);

                State = "OFF";
                return;
            }

            // prepare command
            var command = string.IsNullOrWhiteSpace(_url) ? action : $"{_url} {action}";

            HelperFunctions.LaunchUrl(command, _incognito);

            State = "OFF";
        }
    }
}
