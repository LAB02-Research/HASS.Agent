using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HASSAgent.HomeAssistant;
using Syncfusion.Windows.Forms;

namespace HASSAgent.Controls.Configuration
{
    public partial class HomeAssistantApi : UserControl
    {
        public HomeAssistantApi()
        {
            InitializeComponent();
        }

        private void TbHassClientCertificate_DoubleClick(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.CheckFileExists = true;
                dialog.Multiselect = false;
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                var result = dialog.ShowDialog();
                if (result != DialogResult.OK) return;

                TbHassClientCertificate.Text = dialog.FileName;
            }
        }

        private async void BtnTestApi_Click(object sender, EventArgs e)
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

            var clientCert = TbHassClientCertificate.Text;
            var useAutoCert = CbHassAutoClientCertificate.CheckState == CheckState.Checked;

            // lock gui
            TbHassIp.Enabled = false;
            TbHassApiToken.Enabled = false;
            TbHassClientCertificate.Enabled = false;
            CbHassAutoClientCertificate.Enabled = false;
            BtnTestApi.Enabled = false;
            BtnTestApi.Text = "testing ..";

            // perform test
            var (success, message) = await HassApiManager.CheckHassConfigAsync(hassUri, apiKey, useAutoCert, clientCert);
            if (!success) MessageBoxAdv.Show($"Unable to connect, the following error was returned:\r\n\r\n{message}", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else MessageBoxAdv.Show($"Connection OK!\r\n\r\nHome Assistant version: {message}", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // unlock gui
            TbHassIp.Enabled = true;
            TbHassApiToken.Enabled = true;
            TbHassClientCertificate.Enabled = true;
            CbHassAutoClientCertificate.Enabled = true;
            BtnTestApi.Enabled = true;
            BtnTestApi.Text = "test connection";
        }
    }
}
