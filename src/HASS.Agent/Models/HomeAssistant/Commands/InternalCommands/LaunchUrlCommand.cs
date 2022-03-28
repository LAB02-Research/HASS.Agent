using HASS.Agent.Functions;
using HASS.Agent.Models.Internal;
using HASS.Agent.Shared.Models.HomeAssistant.Commands;
using Newtonsoft.Json;

namespace HASS.Agent.Models.HomeAssistant.Commands.InternalCommands
{
    internal class LaunchUrlCommand : InternalCommand
    {
        private readonly string _url = string.Empty;
        private readonly bool _incognito;

        internal LaunchUrlCommand(string name = "LaunchUrl", string urlInfo = "", string id = default) : base(name ?? "LaunchUrl", urlInfo, id)
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

            HelperFunctions.LaunchUrl(_url, _incognito);

            State = "OFF";
        }
    }
}
