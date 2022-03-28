using Syncfusion.Windows.Forms;
using HASS.Agent.Commands;
using HASS.Agent.Controls.Configuration;
using HASS.Agent.Functions;
using HASS.Agent.Notifications;
using HASS.Agent.Sensors;
using HASS.Agent.Settings;
using HASS.Agent.Shared;
using WK.Libraries.HotkeyListenerNS;
using Task = System.Threading.Tasks.Task;
using SatelliteService = HASS.Agent.Controls.Configuration.Service;

namespace HASS.Agent.Forms
{
    public partial class Configuration : MetroForm
    {
        private readonly HotkeySelector _hotkeySelector = new();
        private readonly Hotkey _previousHotkey = Variables.QuickActionsHotKey;

        private readonly string _previousDeviceName = Variables.AppSettings.DeviceName;
        private readonly int _previousNotificationPort = Variables.AppSettings.NotifierApiPort;

        private readonly General _general = new();
        private readonly HomeAssistantApi _homeAssistantApi = new();
        private readonly Controls.Configuration.Notifications _notifications = new();
        private readonly Controls.Configuration.MQTT _mqtt = new();
        private readonly Startup _startup = new();
        private readonly HotKey _hotKey = new();
        private readonly Updates _updates = new();
        private readonly LocalStorage _localStorage = new();
        private readonly Logging _logging = new();
        private readonly ExternalTools _externalTools = new();
        private readonly SatelliteService _service = new();

        private bool _initializing = true;

        public Configuration()
        {
            InitializeComponent();
        }

        private void Configuration_Load(object sender, EventArgs e)
        {
            // catch all key presses
            KeyPreview = true;

            // suspend global hotkeys
            Variables.HotKeyListener.Suspend();

            // load controls
            TabGeneral.Controls.Add(_general);
            TabHassApi.Controls.Add(_homeAssistantApi);
            TabNotifications.Controls.Add(_notifications);
            TabMQTT.Controls.Add(_mqtt);
            TabStartup.Controls.Add(_startup);
            TabHotKey.Controls.Add(_hotKey);
            TabUpdates.Controls.Add(_updates);
            TabLocalStorage.Controls.Add(_localStorage);
            TabLogging.Controls.Add(_logging);
            TabExternalTools.Controls.Add(_externalTools);
            TabService.Controls.Add(_service);

            // bind events
            BindEvents();

            // load current settings from memory
            LoadSettings();

            // config quick actions hotkey selector
            if (Variables.QuickActionsHotKey != null) _hotkeySelector.Enable(_hotKey.TbQuickActionsHotkey, Variables.QuickActionsHotKey);
            else _hotkeySelector.Enable(_hotKey.TbQuickActionsHotkey);
        }

        private void Configuration_FormClosing(object sender, FormClosingEventArgs e)
        {
            // resume global hotkeys
            Variables.HotKeyListener.Resume();

            // remove hotkey selector
            _hotkeySelector?.Disable(_hotKey.TbQuickActionsHotkey);
            _hotkeySelector?.Dispose();

            // dispose controls
            _general.Dispose();
            _homeAssistantApi.Dispose();
            _notifications.Dispose();
            _mqtt.Dispose();
            _startup.Dispose();
            _hotKey.Dispose();
            _updates.Dispose();
            _localStorage.Dispose();
            _logging.Dispose();
            _externalTools.Dispose();
            _service.Dispose();
        }

        private void BindEvents()
        {
            // hass
            _homeAssistantApi.CbHassAutoClientCertificate.CheckedChanged += CbHassAutoClientCertificate_CheckedChanged;
            
            // mqtt
            _mqtt.CbMqttTls.CheckedChanged += CbMqttTls_CheckedChanged;
            
            // hotkey
            _hotKey.BtnClearHotKey.Click += BtnClearHotKey_Click;
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
            BtnClose.Enabled = false;
            BtnStore.Enabled = false;

            BtnStore.Text = "busy, hold on ..";

            // store settings
            StoreSettings();

            // unpublish all entities if the device's name is changed
            if (_general.TbDeviceName.Text != _previousDeviceName)
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
                await Variables.MqttManager.ClearDeviceConfigAsync();

                // give everything some time to process
                await Task.Delay(250);

                // disconnect mqtt so we don't get announced again
                await Task.Run(Variables.MqttManager.Disconnect);
                
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
            _general.TbDeviceName.Text = Variables.AppSettings.DeviceName;
            _general.NumDisconnectGrace.Value = Variables.AppSettings.DisconnectedGracePeriodSeconds;

            // startup settings
            Task.Run(_startup.DetermineStartOnLoginStatus);

            // notifications
            _notifications.CbAcceptNotifications.CheckState = Variables.AppSettings.NotificationsEnabled ? CheckState.Checked : CheckState.Unchecked;
            _notifications.NumNotificationApiPort.Value = Variables.AppSettings.NotifierApiPort;

            // hass settings
            _homeAssistantApi.TbHassIp.Text = Variables.AppSettings.HassUri;
            _homeAssistantApi.TbHassApiToken.Text = Variables.AppSettings.HassToken;
            _homeAssistantApi.TbHassClientCertificate.Text = Variables.AppSettings.HassClientCertificate;
            _homeAssistantApi.CbHassAutoClientCertificate.CheckState = Variables.AppSettings.HassAutoClientCertificate ? CheckState.Checked : CheckState.Unchecked;
            if (Variables.AppSettings.HassAutoClientCertificate)
            {
                _homeAssistantApi.TbHassClientCertificate.Text = string.Empty;
                _homeAssistantApi.TbHassClientCertificate.Enabled = false;
            }

            // hotkey
            _hotKey.CbEnableQuickActionsHotkey.CheckState = Variables.AppSettings.QuickActionsHotKeyEnabled ? CheckState.Checked : CheckState.Unchecked;

            // mqtt
            _mqtt.TbMqttAddress.Text = Variables.AppSettings.MqttAddress;
            _mqtt.NumMqttPort.Value = Variables.AppSettings.MqttPort;
            _mqtt.CbMqttTls.CheckState = Variables.AppSettings.MqttUseTls ? CheckState.Checked : CheckState.Unchecked;
            _mqtt.TbMqttUsername.Text = Variables.AppSettings.MqttUsername;
            _mqtt.TbMqttPassword.Text = Variables.AppSettings.MqttPassword;
            _mqtt.TbMqttDiscoveryPrefix.Text = Variables.AppSettings.MqttDiscoveryPrefix;
            _mqtt.TbMqttClientId.Text = Variables.AppSettings.MqttClientId;
            _mqtt.TbMqttRootCertificate.Text = Variables.AppSettings.MqttRootCertificate;
            _mqtt.TbMqttClientCertificate.Text = Variables.AppSettings.MqttClientCertificate;
            _mqtt.CbAllowUntrustedCertificates.CheckState = Variables.AppSettings.MqttAllowUntrustedCertificates ? CheckState.Checked : CheckState.Unchecked;
            _mqtt.CbUseRetainFlag.CheckState = Variables.AppSettings.MqttUseRetainFlag ? CheckState.Checked : CheckState.Unchecked;

            // updates
            _updates.CbUpdates.CheckState = Variables.AppSettings.CheckForUpdates ? CheckState.Checked : CheckState.Unchecked;
            _updates.CbBetaUpdates.CheckState = Variables.AppSettings.ShowBetaUpdates ? CheckState.Checked : CheckState.Unchecked;
            _updates.CbExecuteUpdater.CheckState = Variables.AppSettings.EnableExecuteUpdateInstaller ? CheckState.Checked : CheckState.Unchecked;

            // cache
            _localStorage.TbImageCacheLocation.Text = Variables.ImageCachePath;
            _localStorage.NumImageRetention.Value = Variables.AppSettings.ImageCacheRetentionDays;

            // logging
            _logging.CbExtendedLogging.CheckState = SettingsManager.GetExtendedLoggingSetting() ? CheckState.Checked : CheckState.Unchecked;

            // external tools
            _externalTools.TbExternalBrowserName.Text = Variables.AppSettings.BrowserName;
            _externalTools.TbExternalBrowserBinary.Text = Variables.AppSettings.BrowserBinary;
            _externalTools.TbExternalBrowserIncognito.Text = Variables.AppSettings.BrowserIncognitoArg;
            _externalTools.TbExternalExecutorName.Text = Variables.AppSettings.CustomExecutorName;
            _externalTools.TbExternalExecutorBinary.Text = Variables.AppSettings.CustomExecutorBinary;

            // done
            _initializing = false;
        }

        /// <summary>
        /// Store all settings
        /// </summary>
        private void StoreSettings()
        {
            // general
            var deviceName = string.IsNullOrEmpty(_general.TbDeviceName.Text) ? HelperFunctions.GetSafeDeviceName() : _general.TbDeviceName.Text;
            Variables.AppSettings.DeviceName = deviceName;

            Variables.AppSettings.DisconnectedGracePeriodSeconds = (int)_general.NumDisconnectGrace.Value;

            // notifications
            Variables.AppSettings.NotificationsEnabled = _notifications.CbAcceptNotifications.CheckState == CheckState.Checked;
            Variables.AppSettings.NotifierApiPort = (int)_notifications.NumNotificationApiPort.Value;

            // hass settings
            Variables.AppSettings.HassUri = _homeAssistantApi.TbHassIp.Text;
            Variables.AppSettings.HassToken = _homeAssistantApi.TbHassApiToken.Text;
            Variables.AppSettings.HassClientCertificate = _homeAssistantApi.TbHassClientCertificate.Text;
            Variables.AppSettings.HassAutoClientCertificate = _homeAssistantApi.CbHassAutoClientCertificate.CheckState == CheckState.Checked;

            // hotkey config
            Variables.AppSettings.QuickActionsHotKeyEnabled = _hotKey.CbEnableQuickActionsHotkey.CheckState == CheckState.Checked;
            if (Variables.AppSettings.QuickActionsHotKeyEnabled)
            {
                // hotkey enabled, store and activate
                Variables.QuickActionsHotKey = new Hotkey(_hotKey.TbQuickActionsHotkey.Text);
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
            Variables.AppSettings.MqttAddress = _mqtt.TbMqttAddress.Text;
            Variables.AppSettings.MqttPort = (int)_mqtt.NumMqttPort.Value;
            Variables.AppSettings.MqttUseTls = _mqtt.CbMqttTls.CheckState == CheckState.Checked;
            Variables.AppSettings.MqttUsername = _mqtt.TbMqttUsername.Text;
            Variables.AppSettings.MqttPassword = _mqtt.TbMqttPassword.Text;
            Variables.AppSettings.MqttDiscoveryPrefix = _mqtt.TbMqttDiscoveryPrefix.Text;
            Variables.AppSettings.MqttClientId = _mqtt.TbMqttClientId.Text;
            Variables.AppSettings.MqttRootCertificate = _mqtt.TbMqttRootCertificate.Text;
            Variables.AppSettings.MqttClientCertificate = _mqtt.TbMqttClientCertificate.Text;
            Variables.AppSettings.MqttAllowUntrustedCertificates = _mqtt.CbAllowUntrustedCertificates.CheckState == CheckState.Checked;
            Variables.AppSettings.MqttUseRetainFlag = _mqtt.CbUseRetainFlag.CheckState == CheckState.Checked;

            // updates
            Variables.AppSettings.CheckForUpdates = _updates.CbUpdates.CheckState == CheckState.Checked;
            Variables.AppSettings.ShowBetaUpdates = _updates.CbBetaUpdates.CheckState == CheckState.Checked;
            Variables.AppSettings.EnableExecuteUpdateInstaller = _updates.CbExecuteUpdater.CheckState == CheckState.Checked;

            // cache
            Variables.AppSettings.ImageCacheRetentionDays = (int)_localStorage.NumImageRetention.Value;

            // logging
            SettingsManager.SetExtendedLoggingSetting(_logging.CbExtendedLogging.CheckState == CheckState.Checked);

            // external tools
            Variables.AppSettings.BrowserName = _externalTools.TbExternalBrowserName.Text;
            Variables.AppSettings.BrowserBinary = _externalTools.TbExternalBrowserBinary.Text;
            Variables.AppSettings.BrowserIncognitoArg = _externalTools.TbExternalBrowserIncognito.Text;
            Variables.AppSettings.CustomExecutorName = _externalTools.TbExternalExecutorName.Text;
            Variables.AppSettings.CustomExecutorBinary = _externalTools.TbExternalExecutorBinary.Text;

            // set shared config
            AgentSharedBase.SetCustomExecutorBinary(Variables.AppSettings.CustomExecutorBinary);

            // save to file
            SettingsManager.StoreAppSettings();
        }

        /// <summary>
        /// Show our very entertaining 'about' form, always the center of attention of every application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnAbout_Click(object sender, EventArgs e)
        {
            if (await HelperFunctions.TryBringToFront("About")) return;

            var form = new About();
            form.FormClosed += delegate { form.Dispose(); };
            form.Show(this);
        }

        private async void BtnHelp_Click(object sender, EventArgs e)
        {
            if (await HelperFunctions.TryBringToFront("Help")) return;

            var form = new Help();
            form.FormClosed += delegate { form.Dispose(); };
            form.Show(this);
        }

        private void Configuration_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape) return;
            Close();
        }

        private void BtnClearHotKey_Click(object sender, EventArgs e)
        {
            _hotKey.TbQuickActionsHotkey.Text = _hotkeySelector.EmptyHotkeyText;
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
            _mqtt.NumMqttPort.Value = _mqtt.CbMqttTls.Checked ? 8883 : 1883;
        }

        private void CbHassAutoClientCertificate_CheckedChanged(object sender, EventArgs e)
        {
            if (_initializing) return;

            if (_homeAssistantApi.CbHassAutoClientCertificate.CheckState == CheckState.Checked)
            {
                _homeAssistantApi.TbHassClientCertificate.Text = string.Empty;
                _homeAssistantApi.TbHassClientCertificate.Enabled = false;
            }
            else _homeAssistantApi.TbHassClientCertificate.Enabled = true;
        }

        private void BtnClose_Click(object sender, EventArgs e) => Close();
    }
}
