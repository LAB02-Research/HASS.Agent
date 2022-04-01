using HASS.Agent.HomeAssistant;
using HASS.Agent.Resources.Localization;
using Syncfusion.Windows.Forms;

namespace HASS.Agent.Controls.Onboarding
{
    // ReSharper disable once InconsistentNaming
    public partial class OnboardingApi : UserControl
    {
        public OnboardingApi()
        {
            InitializeComponent();
        }

        private void OnboardingApi_Load(object sender, EventArgs e)
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
                MessageBoxAdv.Show(Languages.OnboardingApi_BtnTest_MessageBox1, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ActiveControl = TbHassApiToken;
                return;
            }

            if (string.IsNullOrEmpty(hassUri))
            {
                MessageBoxAdv.Show(Languages.OnboardingApi_BtnTest_MessageBox2, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ActiveControl = TbHassIp;
                return;
            }

            // lock gui
            TbHassIp.Enabled = false;
            TbHassApiToken.Enabled = false;
            BtnTest.Enabled = false;
            BtnTest.Text = Languages.OnboardingApi_BtnTest_Testing;
            
            // perform test
            var (success, message) = await HassApiManager.CheckHassConfigAsync(hassUri, apiKey);
            if (!success) MessageBoxAdv.Show(string.Format(Languages.OnboardingApi_BtnTest_MessageBox3, message), Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else MessageBoxAdv.Show(string.Format(Languages.OnboardingApi_BtnTest_MessageBox4, message), Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

            // unlock gui
            TbHassIp.Enabled = true;
            TbHassApiToken.Enabled = true;
            BtnTest.Enabled = true;
            BtnTest.Text = Languages.OnboardingApi_BtnTest;
        }
    }
}
