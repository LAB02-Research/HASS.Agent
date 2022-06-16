using HASS.Agent.API;
using HASS.Agent.Functions;
using HASS.Agent.Managers;
using HASS.Agent.Models.HomeAssistant;
using HASS.Agent.Resources.Localization;
using Serilog;
using Syncfusion.Windows.Forms;

namespace HASS.Agent.Controls.Configuration
{
    public partial class ConfigMediaPlayer : UserControl
    {
        public ConfigMediaPlayer()
        {
            InitializeComponent();
        }

        private void BtnNotificationsReadme_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://hassagent.readthedocs.io/en/latest/mediaplayer/mediaplayer-usage-and-examples/");
        
        private void ConfigMediaPlayer_Load(object sender, EventArgs e)
        {
            LblLocalApiDisabled.Visible = !Variables.AppSettings.LocalApiEnabled;
        }
    }
}
