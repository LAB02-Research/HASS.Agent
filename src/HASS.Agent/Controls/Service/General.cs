using System.IO;
using HASS.Agent.Properties;
using HASS.Agent.Service;
using HASS.Agent.Settings;
using HASS.Agent.Shared.Models.Config.Service;
using Serilog;
using Syncfusion.Windows.Forms;

namespace HASS.Agent.Controls.Service
{
    public partial class General : UserControl
    {
        private enum ConfigSection
        {
            AuthId,
            DeviceName,
            DisconnectedGracePeriod,
            CustomExecutor
        }

        private ServiceSettings _serviceSettings = null;
        
        public General()
        {
            InitializeComponent();
        }

        private void General_Load(object sender, EventArgs e)
        {
            // set auth ID
            TbAuthId.Text = Variables.AppSettings.ServiceAuthId;
        }

        /// <summary>
        /// Sets the service's configuration
        /// </summary>
        /// <param name="version"></param>
        /// <param name="deviceName"></param>
        /// <param name="settings"></param>
        public void SetConfig(string version, string deviceName, ServiceSettings settings)
        {
            // show version
            LblVersion.Text = version;

            // set devicename
            settings.DeviceName = deviceName;
            TbDeviceName.Text = settings.DeviceName;

            // bind the settings
            _serviceSettings = settings;

            // show them
            NumDisconnectGrace.Value = _serviceSettings.DisconnectedGracePeriodSeconds;

            TbExternalExecutorBinary.Text = _serviceSettings.CustomExecutorBinary;
            TbExternalExecutorName.Text = _serviceSettings.CustomExecutorName;
        }

        private void TbAuthId_DoubleClick(object sender, EventArgs e) => TbAuthId.Text = Guid.NewGuid().ToString()[..16].Replace("-", "");

        private async void BtnStoreAuthId_Click(object sender, EventArgs e)
        {
            var authId = TbAuthId.Text.Trim();
            if (string.IsNullOrEmpty(authId))
            {
                var q = MessageBoxAdv.Show("Storing an empty auth ID will allow all HASS.Agents to access the server.\r\n\r\nAre you sure you want this?", "HASS.Agent", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (q != DialogResult.Yes)
                {
                    ActiveControl = TbAuthId;
                    return;
                }
            }

            var previousId = _serviceSettings.AuthId;
            _serviceSettings.AuthId = authId;

            // lock ui
            LockUi(ConfigSection.AuthId);

            // try to store
            var (storedOk, _) = await Task.Run(async () => await Variables.RpcClient.SetServiceSettingsAsync(_serviceSettings).WaitAsync(Variables.RpcConnectionTimeout));
            if (!storedOk)
            {
                // failed
                MessageBoxAdv.Show("An error occured while saving, check the logs for more info.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // restore previous ID
                _serviceSettings.AuthId = previousId;

                // unlock ui
                UnlockUi(ConfigSection.AuthId);

                // done
                return;
            }

            // set and store auth id locally
            Variables.AppSettings.ServiceAuthId = authId;
            SettingsManager.StoreAppSettings();

            // show 'stored'
            await ShowSuccess(ConfigSection.AuthId);

            // unlock ui
            UnlockUi(ConfigSection.AuthId);
        }

        private async void BtnStoreDeviceName_Click(object sender, EventArgs e)
        {
            var deviceName = TbDeviceName.Text.Trim();
            if (string.IsNullOrEmpty(deviceName))
            {
                MessageBoxAdv.Show("Please enter a devicename first.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ActiveControl = TbDeviceName;
                return;
            }

            var previousName = _serviceSettings.DeviceName;
            _serviceSettings.DeviceName = deviceName;

            // lock ui
            LockUi(ConfigSection.DeviceName);

            // try to store
            var (storedOk, _) = await Task.Run(async () => await Variables.RpcClient.SetDeviceNameAsync(deviceName).WaitAsync(Variables.RpcConnectionTimeout));
            if (!storedOk)
            {
                // failed
                MessageBoxAdv.Show("An error occured while saving, check the logs for more info.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // restore previous ID
                _serviceSettings.DeviceName = previousName;

                // unlock ui
                UnlockUi(ConfigSection.DeviceName);

                // done
                return;
            }

            // show 'stored'
            await ShowSuccess(ConfigSection.DeviceName);

            // unlock ui
            UnlockUi(ConfigSection.DeviceName);
        }

        private async void BtnStoreDisconGrace_Click(object sender, EventArgs e)
        {
            var grace = (int)NumDisconnectGrace.Value;

            var previousValue = _serviceSettings.DisconnectedGracePeriodSeconds;
            _serviceSettings.DisconnectedGracePeriodSeconds = grace;

            // lock ui
            LockUi(ConfigSection.DisconnectedGracePeriod);

            // try to store
            var (storedOk, _) = await Task.Run(async () => await Variables.RpcClient.SetServiceSettingsAsync(_serviceSettings).WaitAsync(Variables.RpcConnectionTimeout));
            if (!storedOk)
            {
                // failed
                MessageBoxAdv.Show("An error occured while saving, check the logs for more info.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // restore previous ID
                _serviceSettings.DisconnectedGracePeriodSeconds = previousValue;

                // unlock ui
                UnlockUi(ConfigSection.DisconnectedGracePeriod);

                // done
                return;
            }

            // show 'stored'
            await ShowSuccess(ConfigSection.DisconnectedGracePeriod);

            // unlock ui
            UnlockUi(ConfigSection.DisconnectedGracePeriod);
        }

        private async void BtnStoreCustomExecutor_Click(object sender, EventArgs e)
        {
            var executorBinary = TbExternalExecutorBinary.Text.Trim();
            if (string.IsNullOrEmpty(executorBinary))
            {
                MessageBoxAdv.Show("Please select an executor first (tip: doubleclick to browse).", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ActiveControl = TbExternalExecutorBinary;
                return;
            }

            // check if the binary exists
            if (!File.Exists(executorBinary))
            {
                MessageBoxAdv.Show("The selected executor isn't found. Please select a new one.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ActiveControl = TbExternalExecutorBinary;
                return;
            }

            // set executorname
            var executorName = TbExternalExecutorName.Text.Trim();
            if (string.IsNullOrEmpty(executorName))
            {
                // if empty, use filename withut extension
                executorName = Path.GetFileNameWithoutExtension(executorBinary);
                TbExternalExecutorName.Text = executorName;
            }

            var previousExecutorBinary = _serviceSettings.CustomExecutorBinary;
            var previousExeutorName = _serviceSettings.CustomExecutorName;
            _serviceSettings.CustomExecutorBinary = executorBinary;
            _serviceSettings.CustomExecutorName = executorName;

            // lock ui
            LockUi(ConfigSection.CustomExecutor);

            // try to store
            var (storedOk, _) = await Task.Run(async () => await Variables.RpcClient.SetServiceSettingsAsync(_serviceSettings).WaitAsync(Variables.RpcConnectionTimeout));
            if (!storedOk)
            {
                // failed
                MessageBoxAdv.Show("An error occured while saving, check the logs for more info.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // restore previous ID
                _serviceSettings.CustomExecutorBinary = previousExecutorBinary;
                _serviceSettings.CustomExecutorName = previousExeutorName;

                // unlock ui
                UnlockUi(ConfigSection.CustomExecutor);

                // done
                return;
            }

            // show 'stored'
            await ShowSuccess(ConfigSection.CustomExecutor);

            // unlock ui
            UnlockUi(ConfigSection.CustomExecutor);
        }

        private void TbExternalExecutorBinary_DoubleClick(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog();
            dialog.CheckFileExists = true;
            dialog.Multiselect = false;
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);

            var result = dialog.ShowDialog();
            if (result != DialogResult.OK) return;

            TbExternalExecutorBinary.Text = dialog.FileName;
            TbExternalExecutorName.Text = Path.GetFileNameWithoutExtension(dialog.FileName);
        }

        /// <summary>
        /// Locks the corresponding UI objects
        /// </summary>
        /// <param name="configSection"></param>
        private void LockUi(ConfigSection configSection)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new MethodInvoker(() => LockUi(configSection)));
                    return;
                }

                switch (configSection)
                {
                    case ConfigSection.AuthId:
                        TbAuthId.Enabled = false;
                        BtnStoreAuthId.Enabled = false;
                        break;

                    case ConfigSection.DeviceName:
                        TbDeviceName.Enabled = false;
                        BtnStoreDeviceName.Enabled = false;
                        break;

                    case ConfigSection.DisconnectedGracePeriod:
                        NumDisconnectGrace.Enabled = false;
                        BtnStoreDisconGrace.Enabled = false;
                        break;

                    case ConfigSection.CustomExecutor:
                        TbExternalExecutorBinary.Enabled = false;
                        TbExternalExecutorName.Enabled = false;
                        BtnStoreCustomExecutor.Enabled = false;
                        break;
                }
            }
            catch (InvalidOperationException)
            {
                // ignore, form closed
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SERVICE] Error locking general ui: {err}", ex.Message);
            }
        }

        /// <summary>
        /// Enables the corresponding UI objects
        /// </summary>
        /// <param name="configSection"></param>
        private void UnlockUi(ConfigSection configSection)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new MethodInvoker(() => LockUi(configSection)));
                    return;
                }

                switch (configSection)
                {
                    case ConfigSection.AuthId:
                        TbAuthId.Enabled = true;
                        BtnStoreAuthId.Enabled = true;
                        break;

                    case ConfigSection.DeviceName:
                        TbDeviceName.Enabled = true;
                        BtnStoreDeviceName.Enabled = true;
                        break;

                    case ConfigSection.DisconnectedGracePeriod:
                        NumDisconnectGrace.Enabled = true;
                        BtnStoreDisconGrace.Enabled = true;
                        break;

                    case ConfigSection.CustomExecutor:
                        TbExternalExecutorBinary.Enabled = true;
                        TbExternalExecutorName.Enabled = true;
                        BtnStoreCustomExecutor.Enabled = true;
                        break;
                }
            }
            catch (InvalidOperationException)
            {
                // ignore, form closed
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SERVICE] Error unlocking general ui: {err}", ex.Message);
            }
        }

        /// <summary>
        /// Shows the 'stored!' label for 3 seconds
        /// </summary>
        /// <param name="configSection"></param>
        private async Task ShowSuccess(ConfigSection configSection)
        {
            try
            {
                Label successLabel = null;

                switch (configSection)
                {
                    case ConfigSection.AuthId:
                        successLabel = LblAuthStored;
                        break;

                    case ConfigSection.DeviceName:
                        successLabel = LblDeviceNameStored;
                        break;

                    case ConfigSection.DisconnectedGracePeriod:
                        successLabel = LblDisconGraceStored;
                        break;

                    case ConfigSection.CustomExecutor:
                        successLabel = LblCustomExecutorStored;
                        break;
                }

                if (successLabel == null) return;

                Invoke(new MethodInvoker(delegate { successLabel.Visible = true; }));

                await Task.Delay(TimeSpan.FromSeconds(3));

                Invoke(new MethodInvoker(delegate { successLabel.Visible = false; }));
            }
            catch (InvalidOperationException)
            {
                // ignore, form closed
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SERVICE] Error setting general ui success state: {err}", ex.Message);
            }
        }
        
        private void LblAuthIdInfo_Click(object sender, EventArgs e) =>
            MessageBoxAdv.Show(
                "Set an auth ID if you don't want every instance of HASS.Agent on this PC to connect with the satellite service.\r\n\r\nOnly the instances that have the correct ID, can connect.\r\n\r\nLeave empty to allow all to connect.",
                "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Information);

        private void LblDeviceNameInfo_Click(object sender, EventArgs e) =>
            MessageBoxAdv.Show(
                "This is the name with which the satellite service registers itself on Home Assistant.\r\n\r\nBy default, it's your PC's name plus '-satellite'.",
                "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Information);

        private void LblDisconGraceInfo_Click(object sender, EventArgs e) =>
            MessageBoxAdv.Show(
                "The amount of time the satellite service will wait before reporting a lost connection to the MQTT broker.",
                "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
