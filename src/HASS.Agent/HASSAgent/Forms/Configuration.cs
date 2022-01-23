using Syncfusion.Windows.Forms;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using HASSAgent.Commands;
using HASSAgent.Functions;
using HASSAgent.HomeAssistant;
using HASSAgent.Mqtt;
using HASSAgent.Notifications;
using HASSAgent.Sensors;
using HASSAgent.Settings;
using Newtonsoft.Json;
using Serilog;
using WK.Libraries.HotkeyListenerNS;
using Task = System.Threading.Tasks.Task;

namespace HASSAgent.Forms
{
    public partial class Configuration : MetroForm
    {
        private readonly HotkeySelector _hotkeySelector = new HotkeySelector();
        private readonly Hotkey _previousHotkey = Variables.QuickActionsHotKey;

        private readonly string _previousDeviceName = Variables.AppSettings.DeviceName;
        private readonly int _previousNotificationPort = Variables.AppSettings.NotifierApiPort;

        private bool _initializing = true;

        public Configuration()
        {
            InitializeComponent();

            // hide group seperator
            TbIntNotifierApiPort.NumberGroupSeparator = "";
            TbIntMqttPort.NumberGroupSeparator = "";
        }

        private void Configuration_Load(object sender, EventArgs e)
        {
            // catch all key presses
            KeyPreview = true;

            // suspend global hotkeys
            Variables.HotKeyListener.Suspend();

            // load current settings from memory
            LoadSettings();

            // config quick actions hotkey selector
            if (Variables.QuickActionsHotKey != null) _hotkeySelector.Enable(TbQuickActionsHotkey, Variables.QuickActionsHotKey);
            else _hotkeySelector.Enable(TbQuickActionsHotkey);

            // remove topmost
            Task.Run(async delegate
            {
                await Task.Delay(150);
                Invoke(new MethodInvoker(delegate { TopMost = false; }));
            });
        }

        private void BtnStore_Click(object sender, EventArgs e) => ProcessChanges();

        /// <summary>
        /// Stores the configuration, and executes extra steps if necessary
        /// </summary>
        private async void ProcessChanges()
        {
            var forceRestart = false;

            // lock ui
            ConfigTabs.Enabled = false;
            BtnAbout.Enabled = false;
            BtnHelp.Enabled = false;
            BtnStore.Enabled = false;

            BtnStore.Text = "busy, hold on ..";

            // store settings
            StoreSettings();

            // unpublish all entities if the device's name is changed
            if (TbDeviceName.Text != _previousDeviceName)
            {
                MessageBoxAdv.Show("You've changed your device's name.\r\n\r\nAll your sensors and commands will now be unpublished, and HASS.Agent\r\nwill restart afterwards to republish them.\r\n\r\nThey'll keep their current names, to avoid breaking automations or scripts.",
                    "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // make sure the managers stop publishing
                SensorsManager.Stop();
                CommandsManager.Stop();

                // give the managers some time to stop
                await Task.Delay(250);

                // unpublish all entities
                await SensorsManager.UnpublishAllSensors();
                await CommandsManager.UnpublishAllCommands();

                // unpublish the current device
                await MqttManager.ClearDeviceConfig();

                // give everything some time to process
                await Task.Delay(250);

                // disconnect mqtt so we don't get announced again
                await Task.Run(MqttManager.Disconnect);
                
                forceRestart = true;
            }

            // reserve the new notifier's port if it's changed
            if (Variables.AppSettings.NotifierApiPort != _previousNotificationPort)
            {
                MessageBoxAdv.Show("You've changed the notification API's port. This new port needs to be reserved.\r\n\r\nYou'll get an UAC request to do so, please approve.",
                    "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // try to reserve elevated
                if (!NotifierManager.ExecuteElevatedPortReservation())
                {
                    // failed, copy the command onto the clipboard
                    Clipboard.SetText($"http add urlacl url=http://+:{Variables.AppSettings.NotifierApiPort}/ user={Environment.UserDomainName}\\{Environment.UserName}");

                    // notify the user
                    MessageBoxAdv.Show("Something went wrong!\r\n\r\nPlease manually execute the required command. It has been copied onto your clipboard, " +
                                       "you just need to paste it into an elevated command prompt.\r\n\r\nRemember to change your firewall rule's port as well.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // notify the user
                    MessageBoxAdv.Show("The port has succesfully been reserved!\r\n\r\nHASS.Agent will now restart to activate the new configuration.",
                        "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // we need to restart, so go ahead, otherwise it's starting to look like popup-spam ..
                    forceRestart = true;
                }
            }

            if (forceRestart)
            {
                // prepare the restart without asking
                var restartPrepared = HelperFunctions.Restart();
                if (!restartPrepared) MessageBoxAdv.Show("Something went wrong while preparing to restart.\r\nPlease restart manually.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // ask the user if they want to restart
                var question = MessageBoxAdv.Show("Your configuration has been saved. Most changes require HASS.Agent to restart before they take effect.\r\n\r\nDo you want to restart now?", "HASS.Agent", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (question == DialogResult.Yes)
                {
                    // prepare the restart
                    var restartPrepared = HelperFunctions.Restart();
                    if (!restartPrepared) MessageBoxAdv.Show("Something went wrong while preparing to restart.\r\nPlease restart manually.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // done
            Close();
        }

        /// <summary>
        /// Load all stored sensors into the UI
        /// </summary>
        private void LoadSettings()
        {
            // general
            TbDeviceName.Text = Variables.AppSettings.DeviceName;

            // startup settings
            Task.Run(DetermineStartOnLoginStatus);

            // notifications
            CbAcceptNotifications.CheckState = Variables.AppSettings.NotificationsEnabled ? CheckState.Checked : CheckState.Unchecked;
            TbIntNotifierApiPort.IntegerValue = Variables.AppSettings.NotifierApiPort;

            // hass settings
            TbHassIp.Text = Variables.AppSettings.HassUri;
            TbHassApiToken.Text = Variables.AppSettings.HassToken;
            TbHassClientCertificate.Text = Variables.AppSettings.HassClientCertificate;
            CbHassAutoClientCertificate.CheckState = Variables.AppSettings.HassAutoClientCertificate ? CheckState.Checked : CheckState.Unchecked;
            if (Variables.AppSettings.HassAutoClientCertificate)
            {
                TbHassClientCertificate.Text = string.Empty;
                TbHassClientCertificate.Enabled = false;
            }

            // hotkey
            CbEnableQuickActionsHotkey.CheckState = Variables.AppSettings.QuickActionsHotKeyEnabled ? CheckState.Checked : CheckState.Unchecked;

            // mqtt
            TbMqttAddress.Text = Variables.AppSettings.MqttAddress;
            TbIntMqttPort.IntegerValue = Variables.AppSettings.MqttPort;
            CbMqttTls.CheckState = Variables.AppSettings.MqttUseTls ? CheckState.Checked : CheckState.Unchecked;
            TbMqttUsername.Text = Variables.AppSettings.MqttUsername;
            TbMqttPassword.Text = Variables.AppSettings.MqttPassword;
            TbMqttDiscoveryPrefix.Text = Variables.AppSettings.MqttDiscoveryPrefix;
            TbMqttRootCertificate.Text = Variables.AppSettings.MqttRootCertificate;
            TbMqttClientCertificate.Text = Variables.AppSettings.MqttClientCertificate;
            CbAllowUntrustedCertificates.CheckState = Variables.AppSettings.MqttAllowUntrustedCertificates ? CheckState.Checked : CheckState.Unchecked;
            CbUseRetainFlag.CheckState = Variables.AppSettings.MqttUseRetainFlag ? CheckState.Checked : CheckState.Unchecked;

            // updates
            CbUpdates.CheckState = Variables.AppSettings.CheckForUpdates ? CheckState.Checked : CheckState.Unchecked;
            CbExecuteUpdater.CheckState = Variables.AppSettings.EnableExecuteUpdateInstaller ? CheckState.Checked : CheckState.Unchecked;

            // cache
            TbImageCacheLocation.Text = Variables.ImageCachePath;
            TbIntImageRetention.IntegerValue = Variables.AppSettings.ImageCacheRetentionDays;

            // logging
            CbExtendedLogging.CheckState = SettingsManager.GetExtendedLoggingSetting() ? CheckState.Checked : CheckState.Unchecked;
            CbExceptionReporting.CheckState = SettingsManager.GetExceptionReportingSetting() ? CheckState.Checked : CheckState.Unchecked;

            // done
            _initializing = false;
        }

        /// <summary>
        /// Store all settings
        /// </summary>
        private void StoreSettings()
        {
            // general
            var deviceName = string.IsNullOrEmpty(TbDeviceName.Text) ? HelperFunctions.GetSafeDeviceName() : TbDeviceName.Text;
            Variables.AppSettings.DeviceName = deviceName;

            // notifications
            Variables.AppSettings.NotificationsEnabled = CbAcceptNotifications.CheckState == CheckState.Checked;
            Variables.AppSettings.NotifierApiPort = (int)TbIntNotifierApiPort.IntegerValue;

            // hass settings
            Variables.AppSettings.HassUri = TbHassIp.Text;
            Variables.AppSettings.HassToken = TbHassApiToken.Text;
            Variables.AppSettings.HassClientCertificate = TbHassClientCertificate.Text;
            Variables.AppSettings.HassAutoClientCertificate = CbHassAutoClientCertificate.CheckState == CheckState.Checked;

            // hotkey config
            Variables.AppSettings.QuickActionsHotKeyEnabled = CbEnableQuickActionsHotkey.CheckState == CheckState.Checked;
            if (Variables.AppSettings.QuickActionsHotKeyEnabled)
            {
                // hotkey enabled, store and activate
                Variables.QuickActionsHotKey = new Hotkey(TbQuickActionsHotkey.Text);
                Variables.AppSettings.QuickActionsHotKey = Variables.QuickActionsHotKey.ToString();
                Variables.HotKeyManager.QuickActionsHotKeyChanged(_previousHotkey);
            }
            else
            {
                // hotkey disabled, remove and deactivate
                Variables.QuickActionsHotKey = null;
                Variables.AppSettings.QuickActionsHotKey = string.Empty;
                Variables.HotKeyManager.QuickActionsHotKeyChanged(_previousHotkey, false);
            }

            // mqtt
            Variables.AppSettings.MqttAddress = TbMqttAddress.Text;
            Variables.AppSettings.MqttPort = (int)TbIntMqttPort.IntegerValue;
            Variables.AppSettings.MqttUseTls = CbMqttTls.CheckState == CheckState.Checked;
            Variables.AppSettings.MqttUsername = TbMqttUsername.Text;
            Variables.AppSettings.MqttPassword = TbMqttPassword.Text;
            Variables.AppSettings.MqttDiscoveryPrefix = TbMqttDiscoveryPrefix.Text;
            Variables.AppSettings.MqttRootCertificate = TbMqttRootCertificate.Text;
            Variables.AppSettings.MqttClientCertificate = TbMqttClientCertificate.Text;
            Variables.AppSettings.MqttAllowUntrustedCertificates = CbAllowUntrustedCertificates.CheckState == CheckState.Checked;
            Variables.AppSettings.MqttUseRetainFlag = CbUseRetainFlag.CheckState == CheckState.Checked;

            // updates
            Variables.AppSettings.CheckForUpdates = CbUpdates.CheckState == CheckState.Checked;
            Variables.AppSettings.EnableExecuteUpdateInstaller = CbExecuteUpdater.CheckState == CheckState.Checked;

            // cache
            Variables.AppSettings.ImageCacheRetentionDays = (int)TbIntImageRetention.IntegerValue;

            // logging
            SettingsManager.SetExtendedLoggingSetting(CbExtendedLogging.CheckState == CheckState.Checked);
            SettingsManager.SetExceptionReportingSetting(CbExceptionReporting.CheckState == CheckState.Checked);

            // save to file
            SettingsManager.StoreAppSettings();
        }

        /// <summary>
        /// Determine the current status of the start-on-login setting, and sets the GUI accordingly
        /// </summary>
        private void DetermineStartOnLoginStatus()
        {
            if (LaunchManager.CheckLaunchOnUserLogin())
            {
                Invoke(new MethodInvoker(delegate
                {
                    LblStartOnLoginStatus.ForeColor = Color.LimeGreen;
                    LblStartOnLoginStatus.Text = "enabled";
                    BtnSetStartOnLogin.Text = "disable start-on-login";
                }));
            }
            else
            {
                Invoke(new MethodInvoker(delegate
                {
                    LblStartOnLoginStatus.ForeColor = Color.OrangeRed;
                    LblStartOnLoginStatus.Text = "disabled";
                    BtnSetStartOnLogin.Text = "enable start-on-login";
                }));
            }
        }

        /// <summary>
        /// Show our very entertaining 'about' form, always the center of attention of every application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAbout_Click(object sender, EventArgs e)
        {
            using (var about = new About())
            {
                about.ShowDialog();
            }
        }

        private void BtnNotificationsReadme_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://github.com/LAB02-Research/HASS.Agent#configuration");

        private void BtnHelp_Click(object sender, EventArgs e)
        {
            using (var help = new Help())
            {
                help.ShowDialog();
            }
        }

        /// <summary>
        /// Enables or disables start-on-login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSetStartOnLogin_Click(object sender, EventArgs e)
        {
            if (LaunchManager.CheckLaunchOnUserLogin())
            {
                // already active, so disable
                var disabled = LaunchManager.DisableLaunchOnUserLogin();
                if (!disabled)
                {
                    MessageBoxAdv.Show("Something went wrong while disabling start-on-login.\r\n\r\nCheck the logs for more info.",
                        "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // not active yet, so enable
                var enabled = LaunchManager.EnableLaunchOnUserLogin();
                if (!enabled)
                {
                    MessageBoxAdv.Show("Something went wrong while enabling start-on-login.\r\n\r\nCheck the logs for more info.",
                        "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // set the current state
            DetermineStartOnLoginStatus();
        }

        private void Configuration_FormClosing(object sender, FormClosingEventArgs e)
        {
            // resume global hotkeys
            Variables.HotKeyListener.Resume();

            _hotkeySelector?.Disable(TbQuickActionsHotkey);
            _hotkeySelector?.Dispose();
        }

        private void Configuration_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape) return;
            Close();
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

        private void BtnMqttClearConfig_Click(object sender, EventArgs e)
        {
            TbMqttAddress.Text = string.Empty;
            TbIntMqttPort.IntegerValue = 1883;
            CbMqttTls.CheckState = CheckState.Unchecked;
            TbMqttUsername.Text = string.Empty;
            TbMqttPassword.Text = string.Empty;
            TbMqttDiscoveryPrefix.Text = "homeassistant";
            TbMqttRootCertificate.Text = string.Empty;
            TbMqttClientCertificate.Text = string.Empty;
            CbAllowUntrustedCertificates.CheckState = CheckState.Checked;
            CbUseRetainFlag.CheckState = CheckState.Checked;
        }

        private void LblCoderr_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://coderr.io");

        private void BtnClear_Click(object sender, EventArgs e)
        {
            TbQuickActionsHotkey.Text = _hotkeySelector.EmptyHotkeyText;
        }

        private async void BtnClearImageCache_Click(object sender, EventArgs e)
        {
            BtnClearImageCache.Enabled = false;
            BtnClearImageCache.Text = "cleaning ..";

            await CacheManager.ClearImageCacheAsync();

            MessageBoxAdv.Show("Image cache has been cleared!", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Information);

            BtnClearImageCache.Enabled = true;
            BtnClearImageCache.Text = "clear image cache";
        }

        private void BtnOpenImageCache_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Variables.ImageCachePath)) return;
            if (!Directory.Exists(Variables.ImageCachePath)) Directory.CreateDirectory(Variables.ImageCachePath);

            Process.Start("explorer.exe", Variables.ImageCachePath);
        }

        private void Configuration_ResizeEnd(object sender, EventArgs e)
        {
            if (Variables.ShuttingDown) return;
            if (!IsHandleCreated) return;
            if (IsDisposed) return;

            try
            {
                Refresh();
            }
            catch
            {
                // best effort
            }
        }

        private void CbMqttTls_CheckedChanged(object sender, EventArgs e)
        {
            if (_initializing) return;
            TbIntMqttPort.IntegerValue = CbMqttTls.Checked ? 8883 : 1883;
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

        private void CbHassAutoClientCertificate_CheckedChanged(object sender, EventArgs e)
        {
            if (_initializing) return;

            if (CbHassAutoClientCertificate.CheckState == CheckState.Checked)
            {
                TbHassClientCertificate.Text = string.Empty;
                TbHassClientCertificate.Enabled = false;
            }
            else TbHassClientCertificate.Enabled = true;
        }
    }
}
