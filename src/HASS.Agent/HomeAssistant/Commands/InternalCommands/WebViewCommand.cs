using HASS.Agent.Functions;
using HASS.Agent.Models.Internal;
using HASS.Agent.Shared.Enums;
using HASS.Agent.Shared.HomeAssistant.Commands;
using Newtonsoft.Json;
using Serilog;

namespace HASS.Agent.HomeAssistant.Commands.InternalCommands
{
    internal class WebViewCommand : InternalCommand
    {
        private readonly WebViewInfo _webViewInfo = new();

        internal WebViewCommand(string name = "WebView", string webViewInfo = "", CommandEntityType entityType = CommandEntityType.Switch, string id = default) : base(name ?? "WebView", webViewInfo, entityType, id)
        {
            CommandConfig = webViewInfo;
            State = "OFF";

            if (string.IsNullOrEmpty(webViewInfo)) return;
            var webViewPackage = JsonConvert.DeserializeObject<WebViewInfo>(webViewInfo);
            if (webViewPackage == null) return;

            _webViewInfo = webViewPackage;
        }

        public override void TurnOn()
        {
            State = "ON";

            if (string.IsNullOrWhiteSpace(_webViewInfo.Url))
            {
                Log.Warning("[COMMAND] Unable to launch webview '{name}', it's configured as action-only", Name);

                State = "OFF";
                return;
            }

            HelperFunctions.LaunchWebView(_webViewInfo);

            State = "OFF";
        }

        public override void TurnOnWithAction(string action)
        {
            State = "ON";

            // prepare url
            var url = string.IsNullOrWhiteSpace(_webViewInfo.Url) ? _webViewInfo.Url : $"{_webViewInfo.Url} {action}";

            HelperFunctions.LaunchWebView(_webViewInfo, url);

            State = "OFF";
        }
    }
}
