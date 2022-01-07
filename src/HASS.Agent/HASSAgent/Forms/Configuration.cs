using Syncfusion.Windows.Forms;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using HASSAgent.Functions;
using HASSAgent.HomeAssistant;
using HASSAgent.Settings;
using Microsoft.Win32.TaskScheduler;
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

        public Configuration()
        {
            InitializeComponent();

            // force dotted group seperator (instead of comma)
            TbIntNotifierApiPort.NumberGroupSeparator = ".";
            TbIntMqttPort.NumberGroupSeparator = ".";
        }

        private void Configuration_Load(object sender, EventArgs e)
        {
            // catch all key presses
            KeyPreview = true;

            // load current settings from memory
            LoadSettings();

            // config quick actions hotkey selector
            if (Variables.QuickActionsHotKey != null) _hotkeySelector.Enable(TbQuickActionsHotkey, Variables.QuickActionsHotKey);
            else _hotkeySelector.Enable(TbQuickActionsHotkey);
        }

        private void BtnStore_Click(object sender, EventArgs e)
        {
            // store settings
            StoreSettings();

            // ask the user if they want to restart
            var question = MessageBoxAdv.Show("Your configuration has been saved. Some changes require HASS.Agent to restart before they take effect.\r\n\r\nDo you want to restart now?", "HASS.Agent", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (question == DialogResult.Yes)
            {
                // prepare the restart
                var restartPrepared = HelperFunctions.Restart();
                if (!restartPrepared) MessageBoxAdv.Show("Something went wrong while preparing to restart.\r\nPlease restart manually.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // done
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Load all stored sensors into the UI
        /// </summary>
        private void LoadSettings()
        {
            // startup settings
            Task.Run(DetermineScheduledTaskStatus);

            // notifications
            CbAcceptNotifications.CheckState = Variables.AppSettings.NotificationsEnabled ? CheckState.Checked : CheckState.Unchecked;
            TbIntNotifierApiPort.IntegerValue = Variables.AppSettings.NotifierApiPort;

            // hass settings
            TbHassIp.Text = Variables.AppSettings.HassUri;
            TbHassApiToken.Text = Variables.AppSettings.HassToken;

            // hotkey
            CbEnableQuickActionsHotkey.CheckState = Variables.AppSettings.QuickActionsHotKeyEnabled ? CheckState.Checked : CheckState.Unchecked;

            // mqtt
            TbMqttAddress.Text = Variables.AppSettings.MqttAddress;
            TbIntMqttPort.IntegerValue = Variables.AppSettings.MqttPort;
            CbMqttTls.CheckState = Variables.AppSettings.MqttUseTls ? CheckState.Checked : CheckState.Unchecked;
            TbMqttUsername.Text = Variables.AppSettings.MqttUsername;
            TbMqttPassword.Text = Variables.AppSettings.MqttPassword;
            TbMqttDiscoveryPrefix.Text = Variables.AppSettings.MqttDiscoveryPrefix;

            // updates
            CbUpdates.CheckState = Variables.AppSettings.CheckForUpdates ? CheckState.Checked : CheckState.Unchecked;

            // cache
            TbImageCacheLocation.Text = Variables.ImageCachePath;
            TbIntImageRetention.IntegerValue = Variables.AppSettings.ImageCacheRetentionDays;

            // logging
            CbExtendedLogging.CheckState = SettingsManager.GetExtendedLoggingSetting() ? CheckState.Checked : CheckState.Unchecked;
            CbExceptionReporting.CheckState = SettingsManager.GetExceptionReportingSetting() ? CheckState.Checked : CheckState.Unchecked;
        }

        /// <summary>
        /// Store all settings
        /// </summary>
        private void StoreSettings()
        {
            // notifications
            Variables.AppSettings.NotificationsEnabled = CbAcceptNotifications.CheckState == CheckState.Checked;
            Variables.AppSettings.NotifierApiPort = (int)TbIntNotifierApiPort.IntegerValue;

            // hass settings
            Variables.AppSettings.HassUri = TbHassIp.Text;
            Variables.AppSettings.HassToken = TbHassApiToken.Text;

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

            // updates
            Variables.AppSettings.CheckForUpdates = CbUpdates.CheckState == CheckState.Checked;

            // cache
            Variables.AppSettings.ImageCacheRetentionDays = (int)TbIntImageRetention.IntegerValue;

            // logging
            SettingsManager.SetExtendedLoggingSetting(CbExtendedLogging.CheckState == CheckState.Checked);
            SettingsManager.SetExceptionReportingSetting(CbExceptionReporting.CheckState == CheckState.Checked);

            // save to file
            SettingsManager.StoreAppSettings();
        }

        /// <summary>
        /// Determine the current status (if any) of the run-on-login scheduled task
        /// </summary>
        private void DetermineScheduledTaskStatus()
        {
            var present = ScheduledTasks.IsTaskPresent();
            var status = present ? ScheduledTasks.TaskStatus() : TaskState.Unknown;

            Invoke(new MethodInvoker(delegate
            {
                if (!present)
                {
                    LblLaunchOnBootActive.Text = "not present";
                    LblLaunchOnBootActive.ForeColor = Color.OrangeRed;
                    return;
                }

                switch (status)
                {
                    case TaskState.Running:
                        LblLaunchOnBootActive.Text = "active";
                        LblLaunchOnBootActive.ForeColor = Color.LimeGreen;
                        return;

                    case TaskState.Disabled:
                        LblLaunchOnBootActive.Text = "present, but disabled";
                        LblLaunchOnBootActive.ForeColor = Color.Yellow;
                        return;

                    case TaskState.Ready:
                        LblLaunchOnBootActive.Text = "present, not running";
                        LblLaunchOnBootActive.ForeColor = Color.LawnGreen;
                        return;

                    default:
                        LblLaunchOnBootActive.Text = $"present, status: {status.ToString().ToLower()}";
                        LblLaunchOnBootActive.ForeColor = Color.OrangeRed;
                        return;
                }
            }));
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

        private void BtnNotificationsReadme_Click(object sender, System.EventArgs e) => HelperFunctions.LaunchUrl("https://github.com/LAB02-Research/HASS.Agent#configuration");

        private void BtnScheduledTaskReadme_Click(object sender, System.EventArgs e) => HelperFunctions.LaunchUrl("https://github.com/LAB02-Research/HASS.Agent#installation");

        private void BtnHelp_Click(object sender, System.EventArgs e) => HelperFunctions.LaunchUrl("https://github.com/LAB02-Research/HASS.Agent");

        /// <summary>
        /// Try to create a run-on-login scheduled task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnCreateLaunchOnBootTask_Click(object sender, EventArgs e)
        {
            // check the current status
            var present = ScheduledTasks.IsTaskPresent();
            var status = present ? ScheduledTasks.TaskStatus() : TaskState.Unknown;

            if (status == TaskState.Running)
            {
                MessageBoxAdv.Show("The task is already present and running.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // lock interface
            BtnCreateLaunchOnBootTask.Text = "creating task ..";
            BtnCreateLaunchOnBootTask.Enabled = false;

            using (var userCredentials = new GetUserCredentials())
            {
                // get the user's credentials
                var result = userCredentials.ShowDialog();
                if (result != DialogResult.OK)
                {
                    BtnCreateLaunchOnBootTask.Text = "create launch-on-login scheduled task";
                    BtnCreateLaunchOnBootTask.Enabled = true;
                    return;
                }

                // create the task
                var created = await Task.Run(() => ScheduledTasks.InstallLaunchOnLoginTask(userCredentials.Username, userCredentials.Password));
                if (created)
                {
                    // success
                    _ = Task.Run(DetermineScheduledTaskStatus);
                    BtnCreateLaunchOnBootTask.Text = "launch-on-login scheduled task created";

                    // ask the user if they want to launch using the task
                    var question = MessageBoxAdv.Show("The task has sucessfully been created.\r\n\r\nDo you want to restart HASS.Agent using the new task?", "HASS.Agent", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (question != DialogResult.Yes) return;

                    // prepare the restart
                    var restartPrepared = HelperFunctions.RestartWithTask();
                    if (!restartPrepared) MessageBoxAdv.Show("Something went wrong while preparing the scheduled task restart.\r\nPlease restart manually through Windows' Task Scheduler.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else DialogResult = DialogResult.OK;
                    return;
                }
            }

            // failed
            BtnCreateLaunchOnBootTask.Text = "create launch-on-login scheduled task";
            BtnCreateLaunchOnBootTask.Enabled = true;

            MessageBoxAdv.Show("There was an error while creating the task.\r\n\r\nMake sure you have sufficient rights. Check the readme and logs for more info.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Configuration_FormClosing(object sender, FormClosingEventArgs e)
        {
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

            // lock gui
            TbHassIp.Enabled = false;
            TbHassApiToken.Enabled = false;
            BtnTestApi.Enabled = false;
            BtnTestApi.Text = "testing ..";

            // perform test
            var (success, message) = await HassApiManager.CheckHassConfigAsync(hassUri, apiKey);
            if (!success) MessageBoxAdv.Show($"Unable to connect, the following error was returned:\r\n\r\n{message}", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else MessageBoxAdv.Show($"Connection OK!\r\n\r\nHome Assistant version: {message}", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // unlock gui
            TbHassIp.Enabled = true;
            TbHassApiToken.Enabled = true;
            BtnTestApi.Enabled = true;
            BtnTestApi.Text = "test connection";
        }

        private async void BtnOpenFirewallPort_Click(object sender, EventArgs e)
        {
            // check the entered port value
            var port = (int)TbIntNotifierApiPort.IntegerValue;

            if (port < 1 || port > 65535)
            {
                MessageBoxAdv.Show("Please enter a port value between 1 and 65535.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ActiveControl = TbIntNotifierApiPort;
                return;
            }

            // lock interface
            BtnOpenFirewallPort.Text = "creating rule, hold on ..";
            BtnOpenFirewallPort.Enabled = false;

            // add the rule
            var consoleResult = await CommandLine.ExecuteCommandAsync("netsh", $"advfirewall firewall add rule name=\"HASS.Agent Notifier\" dir=in action=allow protocol=TCP localport={port}");

            // check the outcome
            if (consoleResult.Error)
            {
                // write the result to the logs
                Log.Error("[ONBOARDING] Error creating firewall rule, console output:\r\n{output}", JsonConvert.SerializeObject(consoleResult, Formatting.Indented));

                // notify user
                MessageBoxAdv.Show("Something went wrong while creating the rule for you.\r\n\r\nPlease check the logs for more info, and resort to the GitHub\r\npage for more info, or to create a ticket.",
                    "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // enable gui, incase they want to try again
                BtnOpenFirewallPort.Text = "yes, open the firewall port";
                BtnOpenFirewallPort.Enabled = true;

                return;
            }

            // all good
            LblFirewallInfo.Text = "Firewall rule succesfully created!";
            LblFirewallInfo.ForeColor = Color.LimeGreen;

            BtnOpenFirewallPort.Visible = false;

            // volatile setting, lazy way to remember we did this
            Variables.OnboardingFirewallRuleCreated = true;
        }

        private void BtnMqttClearConfig_Click(object sender, EventArgs e)
        {
            TbMqttAddress.Text = string.Empty;
            TbIntMqttPort.IntegerValue = 1883;
            CbMqttTls.CheckState = CheckState.Unchecked;
            TbMqttUsername.Text = string.Empty;
            TbMqttPassword.Text = string.Empty;
            TbMqttDiscoveryPrefix.Text = "homeassistant";
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
    }
}
