using HASS.Agent.Resources.Localization;
using HASS.Agent.Shared.Enums;
using HASS.Agent.Shared.Models.Config.Service;
using Newtonsoft.Json;
using Serilog;
using Syncfusion.Windows.Forms;

namespace HASS.Agent.Controls.Service
{
    // ReSharper disable once InconsistentNaming
    public partial class ServiceMqtt : UserControl
    {
        private bool _statusUpdateActive = true;

        public ServiceMqtt()
        {
            InitializeComponent();
        }

        private void ServiceMqtt_Load(object sender, EventArgs e)
        {
            // periodically update mqtt status
            Task.Run(UpdateMqttStatus);
        }

        /// <summary>
        /// Continuously fetches the service's MQTT status
        /// </summary>
        private async void UpdateMqttStatus()
        {
            try
            {
                var firstrun = true;
                while (_statusUpdateActive)
                {
                    // wait a sec before updating (except on first run)
                    if (!firstrun) await Task.Delay(TimeSpan.FromSeconds(1));
                    else firstrun = false;

                    if (!_statusUpdateActive) return;

                    // fetch result
                    var (queryOk, status, _) = await Variables.RpcClient.GetMqttStatusAsync();
                    if (!_statusUpdateActive) return;

                    // ok?
                    if (queryOk)
                    {
                        SetMqttStatus(status);
                        continue;
                    }

                    // nope, something went wrong
                    Invoke(new MethodInvoker(delegate
                    {
                        LblStatus.ForeColor = Color.Red;
                        LblStatus.Text = Languages.ServiceMqtt_StatusError;
                    }));
                }
            }
            catch 
            {
                // best effort
            }
        }

        /// <summary>
        /// Shows the MQTT status with corresponding color in the UI
        /// </summary>
        /// <param name="status"></param>
        private void SetMqttStatus(MqttStatus status)
        {
            if (!_statusUpdateActive) return;
            Invoke(new MethodInvoker(delegate
            {
                switch (status)
                {
                    case MqttStatus.Connected:
                        LblStatus.ForeColor = Color.LimeGreen;
                        break;

                    case MqttStatus.Connecting:
                        LblStatus.ForeColor = Color.DarkOrange;
                        break;

                    case MqttStatus.ConfigMissing:
                    case MqttStatus.Disconnected:
                    case MqttStatus.Error:
                        LblStatus.ForeColor = Color.Red;
                        break;
                }

                LblStatus.Text = status.ToString().ToLower();
            }));
        }

        /// <summary>
        /// Stops updating the MQTT status
        /// </summary>
        public void StopUpdating() => _statusUpdateActive = false;

        /// <summary>
        /// Sets the service's MQTT configuration
        /// </summary>
        /// <param name="mqttSettings"></param>
        public void SetConfig(ServiceMqttSettings mqttSettings)
        {
            TbMqttAddress.Text = mqttSettings.MqttAddress;
            NumMqttPort.Value = mqttSettings.MqttPort;
            CbMqttTls.Checked = mqttSettings.MqttUseTls;
            TbMqttUsername.Text = mqttSettings.MqttUsername;
            TbMqttPassword.Text = mqttSettings.MqttPassword;
            TbMqttDiscoveryPrefix.Text = mqttSettings.MqttDiscoveryPrefix;
            TbMqttClientId.Text = mqttSettings.MqttClientId;
            TbMqttRootCertificate.Text = mqttSettings.MqttRootCertificate;
            TbMqttClientCertificate.Text = mqttSettings.MqttClientCertificate;
            CbAllowUntrustedCertificates.Checked = mqttSettings.MqttAllowUntrustedCertificates;
            CbUseRetainFlag.Checked = mqttSettings.MqttUseRetainFlag;
        }

        /// <summary>
        /// Copies the settings from HASS.Agent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCopy_Click(object sender, EventArgs e)
        {
            TbMqttAddress.Text = Variables.AppSettings.MqttAddress;
            NumMqttPort.Value = Variables.AppSettings.MqttPort;
            CbMqttTls.Checked = Variables.AppSettings.MqttUseTls;
            TbMqttUsername.Text = Variables.AppSettings.MqttUsername;
            TbMqttPassword.Text = Variables.AppSettings.MqttPassword;
            TbMqttDiscoveryPrefix.Text = Variables.AppSettings.MqttDiscoveryPrefix;
            TbMqttClientId.Text = Guid.NewGuid().ToString()[..8];
            TbMqttRootCertificate.Text = Variables.AppSettings.MqttRootCertificate;
            TbMqttClientCertificate.Text = Variables.AppSettings.MqttClientCertificate;
            CbAllowUntrustedCertificates.Checked = Variables.AppSettings.MqttAllowUntrustedCertificates;
            CbUseRetainFlag.Checked = Variables.AppSettings.MqttUseRetainFlag;
        }

        /// <summary>
        /// Resets all settings to their default
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMqttClearConfig_Click(object sender, EventArgs e)
        {
            TbMqttAddress.Text = "homeassistant.local";
            NumMqttPort.Value = 1883;
            CbMqttTls.Checked = false;
            TbMqttUsername.Text = string.Empty;
            TbMqttPassword.Text = string.Empty;
            TbMqttDiscoveryPrefix.Text = "homeassistant";
            TbMqttClientId.Text = Guid.NewGuid().ToString()[..8];
            TbMqttRootCertificate.Text = string.Empty;
            TbMqttClientCertificate.Text = string.Empty;
            CbAllowUntrustedCertificates.Checked = true;
            CbUseRetainFlag.Checked = true;
        }

        private async void BtnStore_Click(object sender, EventArgs e)
        {
            // lock interface
            LockUi();

            // optionally set our client id
            if (string.IsNullOrWhiteSpace(TbMqttClientId.Text)) TbMqttClientId.Text = Guid.NewGuid().ToString()[..8];

            // create settings obj
            var config = new ServiceMqttSettings
            {
                MqttAddress = TbMqttAddress.Text,
                MqttPort = (int)NumMqttPort.Value,
                MqttUseTls = CbMqttTls.Checked,
                MqttUsername = TbMqttUsername.Text,
                MqttPassword = TbMqttPassword.Text,
                MqttDiscoveryPrefix = TbMqttDiscoveryPrefix.Text,
                MqttClientId = TbMqttClientId.Text,
                MqttRootCertificate = TbMqttRootCertificate.Text,
                MqttClientCertificate = TbMqttClientCertificate.Text,
                MqttAllowUntrustedCertificates = CbAllowUntrustedCertificates.Checked,
                MqttUseRetainFlag = CbUseRetainFlag.Checked
            };

            // store
            var (storedOk, _) = await Task.Run(async () => await Variables.RpcClient.SetServiceMqttSettingsAsync(config).WaitAsync(Variables.RpcConnectionTimeout));
            if (!storedOk) MessageBoxAdv.Show(Languages.ServiceMqtt_BtnStore_MessageBox1, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else await ShowStored();

            // done, unlock ui
            UnlockUi();
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

        private void LockUi()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(LockUi));
                return;
            }

            BtnStore.Text = Languages.ServiceMqtt_BtnStore_Storing;

            foreach (var button in Controls.OfType<Button>()) button.Enabled = false;
            foreach (var textBox in Controls.OfType<TextBox>()) textBox.Enabled = false;
            foreach (var checkBox in Controls.OfType<CheckBox>()) checkBox.Enabled = false;
            foreach (var numericUpDown in Controls.OfType<NumericUpDown>()) numericUpDown.Enabled = false;
        }

        private void UnlockUi()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(UnlockUi));
                return;
            }

            BtnStore.Text = Languages.ServiceMqtt_BtnStore;

            foreach (var button in Controls.OfType<Button>()) button.Enabled = true;
            foreach (var textBox in Controls.OfType<TextBox>()) textBox.Enabled = true;
            foreach (var checkBox in Controls.OfType<CheckBox>()) checkBox.Enabled = true;
            foreach (var numericUpDown in Controls.OfType<NumericUpDown>()) numericUpDown.Enabled = true;
        }

        private async Task ShowStored()
        {
            Invoke(new MethodInvoker(delegate { LblStored.Visible = true; }));
            await Task.Delay(TimeSpan.FromSeconds(3));
            Invoke(new MethodInvoker(delegate { LblStored.Visible = false; }));
        }

        private void PbShow_Click(object sender, EventArgs e) => TbMqttPassword.UseSystemPasswordChar = !TbMqttPassword.UseSystemPasswordChar;
    }
}
