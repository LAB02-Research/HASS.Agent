using HASS.Agent.API;
using HASS.Agent.Functions;
using HASS.Agent.Managers;
using HASS.Agent.Models.HomeAssistant;
using HASS.Agent.Resources.Localization;
using HASS.Agent.Shared.Functions;
using Serilog;
using Syncfusion.Windows.Forms;

namespace HASS.Agent.Controls.Configuration
{
    public partial class ConfigLocalApi : UserControl
    {
        public ConfigLocalApi()
        {
            InitializeComponent();
        }
        
        private async void BtnExecutePortReservation_Click(object sender, EventArgs e)
        {
            BtnExecutePortReservation.Text = Languages.ConfigNotifications_BtnExecutePortReservation_Busy;
            
            BtnExecutePortReservation.Enabled = false;

            // try to reserve elevated
            if (!await Task.Run(ApiManager.ExecuteElevatedPortReservation))
            {
                // failed, copy the command onto the clipboard
                Clipboard.SetText($"netsh http add urlacl url=http://+:{Variables.AppSettings.LocalApiPort}/ user=\"{SharedHelperFunctions.EveryoneLocalizedAccountName()}\"");

                // notify the user
                MessageBoxAdv.Show(Languages.ConfigNotifications_BtnExecutePortReservation_MessageBox1, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            BtnExecutePortReservation.Text = Languages.ConfigNotifications_BtnExecutePortReservation;

            BtnExecutePortReservation.Enabled = true;
        }

        private void ConfigLocalApi_Load(object sender, EventArgs e)
        {
            //
        }
    }
}
