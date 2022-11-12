using HASS.Agent.HomeAssistant;
using HASS.Agent.Resources.Localization;
using HASS.Agent.Shared.Functions;
using Syncfusion.Windows.Forms;

namespace HASS.Agent.Controls.Configuration
{
    public partial class ConfigHomeAssistantApi : UserControl
    {
        public ConfigHomeAssistantApi()
        {
            InitializeComponent();
        }

        private void TbHassClientCertificate_DoubleClick(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog();
            dialog.CheckFileExists = true;
            dialog.Multiselect = false;
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            var result = dialog.ShowDialog();
            if (result != DialogResult.OK) return;

            TbHassClientCertificate.Text = dialog.FileName;
        }

        private async void BtnTestApi_Click(object sender, EventArgs e)
        {
            // test entered values
            var apiKey = TbHassApiToken.Text.Trim();
            var hassUri = TbHassIp.Text.Trim();

            if (string.IsNullOrEmpty(apiKey))
            {
                MessageBoxAdv.Show(this, Languages.ConfigHomeAssistantApi_BtnTestApi_MessageBox1, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ActiveControl = TbHassApiToken;
                return;
            }

            if (string.IsNullOrEmpty(hassUri))
            {
                MessageBoxAdv.Show(this, Languages.ConfigHomeAssistantApi_BtnTestApi_MessageBox2, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ActiveControl = TbHassIp;
                return;
            }

            if (!SharedHelperFunctions.CheckHomeAssistantApiToken(apiKey))
            {
                var q = MessageBoxAdv.Show(this, Languages.ConfigHomeAssistantApi_BtnTestApi_MessageBox5, Variables.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (q != DialogResult.Yes)
                {
                    ActiveControl = TbHassApiToken;
                    return;
                }
            }

            if (!SharedHelperFunctions.CheckHomeAssistantUri(hassUri))
            {
                var q = MessageBoxAdv.Show(this, Languages.ConfigHomeAssistantApi_BtnTestApi_MessageBox6, Variables.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (q != DialogResult.Yes)
                {
                    ActiveControl = TbHassIp;
                    return;
                }
            }

            var clientCert = TbHassClientCertificate.Text;
            var useAutoCert = CbHassAutoClientCertificate.CheckState == CheckState.Checked;
            var allowUnsafeCert = CbHassAllowUntrustedCertificates.CheckState == CheckState.Checked;

            // lock gui
            TbHassIp.Enabled = false;
            TbHassApiToken.Enabled = false;
            TbHassClientCertificate.Enabled = false;
            CbHassAutoClientCertificate.Enabled = false;
            CbHassAllowUntrustedCertificates.Enabled = false;
            BtnTestApi.Enabled = false;
            BtnTestApi.Text = Languages.ConfigHomeAssistantApi_BtnTestApi_Testing;

            // perform test
            var (success, message) = await HassApiManager.CheckHassConfigAsync(hassUri, apiKey, useAutoCert, allowUnsafeCert, clientCert);
            if (!success) MessageBoxAdv.Show(this, string.Format(Languages.ConfigHomeAssistantApi_BtnTestApi_MessageBox3, message), Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else MessageBoxAdv.Show(this, string.Format(Languages.ConfigHomeAssistantApi_BtnTestApi_MessageBox4, message), Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

            // unlock gui
            TbHassIp.Enabled = true;
            TbHassApiToken.Enabled = true;
            TbHassClientCertificate.Enabled = true;
            CbHassAutoClientCertificate.Enabled = true;
            CbHassAllowUntrustedCertificates.Enabled = true;
            BtnTestApi.Enabled = true;
            BtnTestApi.Text = Languages.ConfigHomeAssistantApi_BtnTestApi;
        }

        private void ConfigHomeAssistantApi_Load(object sender, EventArgs e)
        {
            //
        }
    }
}
