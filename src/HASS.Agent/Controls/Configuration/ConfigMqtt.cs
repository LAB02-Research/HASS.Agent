namespace HASS.Agent.Controls.Configuration
{
    // ReSharper disable once InconsistentNaming
    public partial class ConfigMqtt : UserControl
    {
        public ConfigMqtt()
        {
            InitializeComponent();
        }

        private void TbMqttRootCertificate_DoubleClick(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog();
            dialog.CheckFileExists = true;
            dialog.Multiselect = false;
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            var result = dialog.ShowDialog();
            if (result != DialogResult.OK) return;

            TbMqttRootCertificate.Text = dialog.FileName;
        }

        private void TbMqttClientCertificate_DoubleClick(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog();
            dialog.CheckFileExists = true;
            dialog.Multiselect = false;
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            var result = dialog.ShowDialog();
            if (result != DialogResult.OK) return;

            TbMqttClientCertificate.Text = dialog.FileName;
        }

        private void BtnMqttClearConfig_Click(object sender, EventArgs e)
        {
            TbMqttAddress.Text = string.Empty;
            NumMqttPort.Value = 1883;
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

        private void ConfigMqtt_Load(object sender, EventArgs e)
        {
            //
        }

        private void PbShow_Click(object sender, EventArgs e) => TbMqttPassword.UseSystemPasswordChar = !TbMqttPassword.UseSystemPasswordChar;
    }
}
