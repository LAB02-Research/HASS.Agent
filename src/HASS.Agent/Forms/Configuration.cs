using HASS.Agent.API;
using Syncfusion.Windows.Forms;
using HASS.Agent.Commands;
using HASS.Agent.Controls.Configuration;
using HASS.Agent.Functions;
using HASS.Agent.Resources.Localization;
using HASS.Agent.Sensors;
using HASS.Agent.Settings;
using HASS.Agent.Shared;
using HASS.Agent.Shared.Functions;
using WK.Libraries.HotkeyListenerNS;
using Task = System.Threading.Tasks.Task;
using ConfigSatelliteService = HASS.Agent.Controls.Configuration.ConfigService;

namespace HASS.Agent.Forms
{
    public partial class Configuration : MetroForm
    {
        private readonly HotkeySelector _hotkeySelector = new();
        private readonly Hotkey _previousHotkey = Variables.QuickActionsHotKey;

        private readonly string _previousDeviceName = Variables.AppSettings.DeviceName;
        private readonly int _previousLocalApiPort = Variables.AppSettings.LocalApiPort;

        private readonly ConfigGeneral _general = new();
        private readonly ConfigHomeAssistantApi _homeAssistantApi = new();
        private readonly ConfigNotifications _notifications = new();
        private readonly ConfigMqtt _mqtt = new();
        private readonly ConfigStartup _startup = new();
        private readonly ConfigHotKey _hotKey = new();
        private readonly ConfigUpdates _updates = new();
        private readonly ConfigLocalStorage _localStorage = new();
        private readonly ConfigLogging _logging = new();
        private readonly ConfigExternalTools _externalTools = new();
        private readonly ConfigSatelliteService _service = new();
        private readonly ConfigLocalApi _localApi = new();
        private readonly ConfigMediaPlayer _mediaPlayer = new();
        private readonly ConfigTrayIcon _trayIcon = new();

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
            TablLocalApi.Controls.Add(_localApi);
            TabMediaPlayer.Controls.Add(_mediaPlayer);
            TabTrayIcon.Controls.Add(_trayIcon);

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
            _localApi.Dispose();
            _mediaPlayer.Dispose();
            _trayIcon.Dispose();
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

            // check if all values look ok
            if (!CheckValues())
            {
                // something's off and the user wants to abort
                return;
            }

            // lock ui
            ConfigTabs.Enabled = false;
            BtnAbout.Enabled = false;
            BtnHelp.Enabled = false;
            BtnClose.Enabled = false;
            BtnStore.Enabled = false;

            BtnStore.Text = Languages.Configuration_BtnStore_Busy;

            // optionally sanitize device name
            if (_general.CbEnableDeviceNameSanitation.Checked) _general.TbDeviceName.Text = SharedHelperFunctions.GetSafeValue(_general.TbDeviceName.Text);

            // store settings
            await StoreSettingsAsync();

            // (re)load tray icon's webview if needed
            if (Variables.AppSettings.TrayIconWebViewBackgroundLoading) HelperFunctions.PrepareTrayIconWebView();

            // unpublish all entities if the device's name is changed
            if (_general.TbDeviceName.Text != _previousDeviceName)
            {
                // show the corresponding warning message (either with or without sanitation)
                MessageBoxAdv.Show(_general.CbEnableDeviceNameSanitation.Checked
                        ? Languages.Configuration_ProcessChanges_MessageBox1
                        : Languages.Configuration_ProcessChanges_MessageBox6, Variables.MessageBoxTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

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

            // reserve the new local api's port if it's changed
            if (Variables.AppSettings.LocalApiPort != _previousLocalApiPort)
            {
                MessageBoxAdv.Show(Languages.Configuration_ProcessChanges_MessageBox2, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                // try to reserve elevated
                if (!ApiManager.ExecuteElevatedPortReservation())
                {
                    // failed, copy the command onto the clipboard
                    Clipboard.SetText($"netsh http add urlacl url=http://+:{Variables.AppSettings.LocalApiPort}/ user=\"{SharedHelperFunctions.EveryoneLocalizedAccountName()}\"");

                    // notify the user
                    MessageBoxAdv.Show(Languages.Configuration_ProcessChanges_MessageBox3, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // notify the user
                    MessageBoxAdv.Show(Languages.Configuration_ProcessChanges_MessageBox4, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // we need to restart, so go ahead, otherwise it's starting to look like popup-spam ..
                    forceRestart = true;
                }
            }

            if (forceRestart)
            {
                // prepare the restart without asking
                var restartPrepared = HelperFunctions.Restart();
                if (!restartPrepared) MessageBoxAdv.Show(Languages.Configuration_MessageBox_RestartManually, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // ask the user if they want to restart
                var question = MessageBoxAdv.Show(Languages.Configuration_ProcessChanges_MessageBox5, Variables.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (question == DialogResult.Yes)
                {
                    // prepare the restart
                    var restartPrepared = HelperFunctions.Restart();
                    if (!restartPrepared) MessageBoxAdv.Show(Languages.Configuration_MessageBox_RestartManually, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // done
            Close();
        }

        /// <summary>
        /// Checks various values for known faults
        /// </summary>
        /// <returns></returns>
        private bool CheckValues()
        {
            // hass api token
            var hassApi = _homeAssistantApi.TbHassApiToken.Text.Trim();
            if (!string.IsNullOrEmpty(hassApi))
            {
                if (!SharedHelperFunctions.CheckHomeAssistantApiToken(hassApi))
                {
                    var q = MessageBoxAdv.Show(Languages.Configuration_CheckValues_MessageBox1, Variables.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (q != DialogResult.Yes) return false;
                }
            }

            // hass uri
            var hassUri = _homeAssistantApi.TbHassIp.Text.Trim();
            if (!string.IsNullOrEmpty(hassUri))
            {
                if (!SharedHelperFunctions.CheckHomeAssistantUri(hassUri))
                {
                    var q = MessageBoxAdv.Show(Languages.Configuration_CheckValues_MessageBox2, Variables.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (q != DialogResult.Yes) return false;
                }
            }

            // mqtt uri
            var mqttUri = _mqtt.TbMqttAddress.Text.Trim();
            if (!string.IsNullOrEmpty(mqttUri))
            {
                if (!SharedHelperFunctions.CheckMqttBrokerUri(mqttUri))
                {
                    var q = MessageBoxAdv.Show(Languages.Configuration_CheckValues_MessageBox3, Variables.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (q != DialogResult.Yes) return false;
                }
            }

            // all good
            return true;
        }

        /// <summary>
        /// Load all stored sensors into the UI
        /// </summary>
        private void LoadSettings()
        {
            // general
            _general.TbDeviceName.Text = Variables.AppSettings.DeviceName;
            _general.CbEnableDeviceNameSanitation.CheckState = Variables.AppSettings.SanitizeName ? CheckState.Checked : CheckState.Unchecked;
            _general.NumDisconnectGrace.Value = Variables.AppSettings.DisconnectedGracePeriodSeconds;
            _general.CbEnableStateNotifications.CheckState = Variables.AppSettings.EnableStateNotifications ? CheckState.Checked : CheckState.Unchecked;

            // startup settings
            Task.Run(_startup.DetermineStartOnLoginStatus);

            // local api
            _localApi.NumLocalApiPort.Value = Variables.AppSettings.LocalApiPort;
            _localApi.CbLocalApiActive.CheckState = Variables.AppSettings.LocalApiEnabled ? CheckState.Checked : CheckState.Unchecked;

            // notifications
            _notifications.CbAcceptNotifications.CheckState = Variables.AppSettings.NotificationsEnabled ? CheckState.Checked : CheckState.Unchecked;
            _notifications.CbNotificationsIgnoreImageCertErrors.CheckState = Variables.AppSettings.NotificationsIgnoreImageCertificateErrors ? CheckState.Checked : CheckState.Unchecked;

            // hass settings
            _homeAssistantApi.TbHassIp.Text = Variables.AppSettings.HassUri;
            _homeAssistantApi.TbHassApiToken.Text = Variables.AppSettings.HassToken;
            _homeAssistantApi.TbHassClientCertificate.Text = Variables.AppSettings.HassClientCertificate;
            _homeAssistantApi.CbHassAutoClientCertificate.CheckState = Variables.AppSettings.HassAutoClientCertificate ? CheckState.Checked : CheckState.Unchecked;
            _homeAssistantApi.CbHassAllowUntrustedCertificates.CheckState = Variables.AppSettings.HassAllowUntrustedCertificates ? CheckState.Checked : CheckState.Unchecked;
            if (Variables.AppSettings.HassAutoClientCertificate)
            {
                _homeAssistantApi.TbHassClientCertificate.Text = string.Empty;
                _homeAssistantApi.TbHassClientCertificate.Enabled = false;
            }

            // hotkey
            _hotKey.CbEnableQuickActionsHotkey.CheckState = Variables.AppSettings.QuickActionsHotKeyEnabled ? CheckState.Checked : CheckState.Unchecked;

            // mqtt
            _mqtt.CbEnableMqtt.CheckState = Variables.AppSettings.MqttEnabled ? CheckState.Checked : CheckState.Unchecked;
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
            _localStorage.TbAudioCacheLocation.Text = Variables.AudioCachePath;
            _localStorage.NumAudioRetention.Value = Variables.AppSettings.AudioCacheRetentionDays;
            _localStorage.TbWebViewCacheLocation.Text = Variables.WebViewCachePath;
            _localStorage.NumWebViewRetention.Value = Variables.AppSettings.WebViewCacheRetentionDays;

            // logging
            _logging.CbExtendedLogging.CheckState = SettingsManager.GetExtendedLoggingSetting() ? CheckState.Checked : CheckState.Unchecked;

            // external tools
            _externalTools.TbExternalBrowserName.Text = Variables.AppSettings.BrowserName;
            _externalTools.TbExternalBrowserBinary.Text = Variables.AppSettings.BrowserBinary;
            _externalTools.TbExternalBrowserIncognito.Text = Variables.AppSettings.BrowserIncognitoArg;
            _externalTools.TbExternalExecutorName.Text = Variables.AppSettings.CustomExecutorName;
            _externalTools.TbExternalExecutorBinary.Text = Variables.AppSettings.CustomExecutorBinary;

            // mediaplayer
            _mediaPlayer.CbEnableMediaPlayer.CheckState = Variables.AppSettings.MediaPlayerEnabled ? CheckState.Checked : CheckState.Unchecked;

            // tray icon
            _trayIcon.CbDefaultMenu.CheckState = Variables.AppSettings.TrayIconShowDefaultMenu ? CheckState.Checked : CheckState.Unchecked;
            _trayIcon.CbShowWebView.CheckState = Variables.AppSettings.TrayIconShowWebView ? CheckState.Checked : CheckState.Unchecked;
            _trayIcon.NumWebViewWidth.Value = Variables.AppSettings.TrayIconWebViewWidth;
            _trayIcon.NumWebViewHeight.Value = Variables.AppSettings.TrayIconWebViewHeight;
            _trayIcon.TbWebViewUrl.Text = Variables.AppSettings.TrayIconWebViewUrl;
            _trayIcon.CbWebViewKeepLoaded.CheckState = Variables.AppSettings.TrayIconWebViewBackgroundLoading ? CheckState.Checked : CheckState.Unchecked;
            _trayIcon.CbWebViewShowMenuOnLeftClick.CheckState = Variables.AppSettings.TrayIconWebViewShowMenuOnLeftClick ? CheckState.Checked : CheckState.Unchecked;

            // done
            _initializing = false;
        }

        /// <summary>
        /// Store all settings
        /// </summary>
        private async Task StoreSettingsAsync()
        {
            // general
            var deviceName = string.IsNullOrEmpty(_general.TbDeviceName.Text) ? SharedHelperFunctions.GetSafeDeviceName() : _general.TbDeviceName.Text;
            Variables.AppSettings.DeviceName = deviceName;
            Variables.AppSettings.SanitizeName = _general.CbEnableDeviceNameSanitation.CheckState == CheckState.Checked;
            Variables.AppSettings.EnableStateNotifications = _general.CbEnableStateNotifications.CheckState == CheckState.Checked;

            var uiLanguage = Variables.SupportedUILanguages.Find(x => x.DisplayName == _general.CbLanguage.Text);
            Variables.AppSettings.InterfaceLanguage = uiLanguage?.Name ?? "en";

            Variables.AppSettings.DisconnectedGracePeriodSeconds = (int)_general.NumDisconnectGrace.Value;

            // local api
            Variables.AppSettings.LocalApiPort = (int)_localApi.NumLocalApiPort.Value;
            Variables.AppSettings.LocalApiEnabled = _localApi.CbLocalApiActive.CheckState == CheckState.Checked;

            // notifications
            Variables.AppSettings.NotificationsEnabled = _notifications.CbAcceptNotifications.CheckState == CheckState.Checked;
            Variables.AppSettings.NotificationsIgnoreImageCertificateErrors = _notifications.CbNotificationsIgnoreImageCertErrors.CheckState == CheckState.Checked;

            // hass settings
            Variables.AppSettings.HassUri = _homeAssistantApi.TbHassIp.Text;
            Variables.AppSettings.HassToken = _homeAssistantApi.TbHassApiToken.Text;
            Variables.AppSettings.HassClientCertificate = _homeAssistantApi.TbHassClientCertificate.Text;
            Variables.AppSettings.HassAutoClientCertificate = _homeAssistantApi.CbHassAutoClientCertificate.CheckState == CheckState.Checked;
            Variables.AppSettings.HassAllowUntrustedCertificates = _homeAssistantApi.CbHassAllowUntrustedCertificates.CheckState == CheckState.Checked;

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
            Variables.AppSettings.MqttEnabled = _mqtt.CbEnableMqtt.CheckState == CheckState.Checked;
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

            // mqtt -> service
            await SettingsManager.SendMqttSettingsToServiceAsync();

            // updates
            Variables.AppSettings.CheckForUpdates = _updates.CbUpdates.CheckState == CheckState.Checked;
            Variables.AppSettings.ShowBetaUpdates = _updates.CbBetaUpdates.CheckState == CheckState.Checked;
            Variables.AppSettings.EnableExecuteUpdateInstaller = _updates.CbExecuteUpdater.CheckState == CheckState.Checked;

            // cache
            Variables.AppSettings.ImageCacheRetentionDays = (int)_localStorage.NumImageRetention.Value;
            Variables.AppSettings.AudioCacheRetentionDays = (int)_localStorage.NumAudioRetention.Value;
            Variables.AppSettings.WebViewCacheRetentionDays = (int)_localStorage.NumWebViewRetention.Value;

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

            // mediaplayer
            Variables.AppSettings.MediaPlayerEnabled = _mediaPlayer.CbEnableMediaPlayer.CheckState == CheckState.Checked;

            // tray icon
            Variables.AppSettings.TrayIconShowDefaultMenu = _trayIcon.CbDefaultMenu.CheckState == CheckState.Checked;
            Variables.AppSettings.TrayIconShowWebView = _trayIcon.CbShowWebView.CheckState == CheckState.Checked;
            Variables.AppSettings.TrayIconWebViewWidth = (int)_trayIcon.NumWebViewWidth.Value;
            Variables.AppSettings.TrayIconWebViewHeight = (int)_trayIcon.NumWebViewHeight.Value;
            Variables.AppSettings.TrayIconWebViewUrl = _trayIcon.TbWebViewUrl.Text;
            Variables.AppSettings.TrayIconWebViewBackgroundLoading = _trayIcon.CbWebViewKeepLoaded.CheckState == CheckState.Checked;
            Variables.AppSettings.TrayIconWebViewShowMenuOnLeftClick = _trayIcon.CbWebViewShowMenuOnLeftClick.CheckState == CheckState.Checked;

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
