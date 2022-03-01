using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HASSAgent.Controls.Configuration
{
    // ReSharper disable once InconsistentNaming
    public partial class MQTT : UserControl
    {
        public MQTT()
        {
            InitializeComponent();

            TbIntMqttPort.Culture = CultureInfo.InstalledUICulture;
        }

        private void TbMqttRootCertificate_DoubleClick(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.CheckFileExists = true;
                dialog.Multiselect = false;
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                var result = dialog.ShowDialog();
                if (result != DialogResult.OK) return;

                TbMqttRootCertificate.Text = dialog.FileName;
            }
        }

        private void TbMqttClientCertificate_DoubleClick(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.CheckFileExists = true;
                dialog.Multiselect = false;
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                var result = dialog.ShowDialog();
                if (result != DialogResult.OK) return;

                TbMqttClientCertificate.Text = dialog.FileName;
            }
        }

        private void BtnMqttClearConfig_Click(object sender, EventArgs e)
        {
            TbMqttAddress.Text = string.Empty;
            TbIntMqttPort.IntegerValue = 1883;
            CbMqttTls.CheckState = CheckState.Unchecked;
            TbMqttUsername.Text = string.Empty;
            TbMqttPassword.Text = string.Empty;
            TbMqttDiscoveryPrefix.Text = "homeassistant";
            TbMqttClientId.Text = string.Empty;
            TbMqttRootCertificate.Text = string.Empty;
            TbMqttClientCertificate.Text = string.Empty;
            CbAllowUntrustedCertificates.CheckState = CheckState.Checked;
            CbUseRetainFlag.CheckState = CheckState.Checked;
        }

        private void MQTT_Load(object sender, EventArgs e)
        {
            //
        }
    }
}
