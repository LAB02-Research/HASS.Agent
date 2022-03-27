using HASSAgent.HomeAssistant;
using Syncfusion.Windows.Forms;

namespace HASSAgent.Controls.Onboarding
{
    // ReSharper disable once InconsistentNaming
    public partial class API : UserControl
    {
        public API()
        {
            InitializeComponent();
        }

        private void API_Load(object sender, EventArgs e)
        {
            TbHassIp.Text = Variables.AppSettings.HassUri;
            TbHassApiToken.Text = Variables.AppSettings.HassToken;

            ActiveControl = TbHassApiToken;
        }

        internal bool Store()
        {
            Variables.AppSettings.HassUri = TbHassIp.Text;
            Variables.AppSettings.HassToken = TbHassApiToken.Text;
            return true;
        }

        private async void BtnTest_Click(object sender, EventArgs e)
        {
            // test entered values
            var apiKey = TbHassApiToken.Text.Trim();
            var hassUri = TbHassIp.Text.Trim();

            if (string.IsNullOrEmpty(apiKey))
            {
                MessageBoxAdv.Show("Please enter a valid API key.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ActiveControl = TbHassApiToken;
                return;
            }

            if (string.IsNullOrEmpty(hassUri))
            {
                MessageBoxAdv.Show("Please enter your Home Assistant's URI.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ActiveControl = TbHassIp;
                return;
            }

            // lock gui
            TbHassIp.Enabled = false;
            TbHassApiToken.Enabled = false;
            BtnTest.Enabled = false;
            BtnTest.Text = "testing ..";
            
            // perform test
            var (success, message) = await HassApiManager.CheckHassConfigAsync(hassUri, apiKey);
            if (!success) MessageBoxAdv.Show($"Unable to connect, the following error was returned:\r\n\r\n{message}", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else MessageBoxAdv.Show($"Connection OK!\r\n\r\nHome Assistant version: {message}", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // unlock gui
            TbHassIp.Enabled = true;
            TbHassApiToken.Enabled = true;
            BtnTest.Enabled = true;
            BtnTest.Text = "test connection";
        }
    }
}
