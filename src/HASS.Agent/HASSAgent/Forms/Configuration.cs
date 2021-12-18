using System.Drawing;
using System.Windows.Forms;
using HASSAgent.Functions;
using HASSAgent.Mqtt;
using HASSAgent.Settings;
using Microsoft.Win32.TaskScheduler;
using Syncfusion.Windows.Forms;
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

        private void AppSettings_Load(object sender, System.EventArgs e)
        {
            // catch all key presses
            KeyPreview = true;

            // load current settings from memory
            LoadSettings();
            
            // config quick actions hotkey selector
            if (Variables.QuickActionsHotKey != null) _hotkeySelector.Enable(TbQuickActionsHotkey, Variables.QuickActionsHotKey);
            else _hotkeySelector.Enable(TbQuickActionsHotkey);
        }
        
        private void BtnStore_Click(object sender, System.EventArgs e)
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

            // updates
            CbUpdates.CheckState = Variables.AppSettings.CheckForUpdates ? CheckState.Checked : CheckState.Unchecked;
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

            // updates
            Variables.AppSettings.CheckForUpdates = CbUpdates.CheckState == CheckState.Checked;

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
        /// Try to create a run-on-login scheduled task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnCreateLaunchOnBootTask_Click(object sender, System.EventArgs e)
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

        /// <summary>
        /// Show our very entertaining 'about' form, always the center of attention of every application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAbout_Click(object sender, System.EventArgs e)
        {
            using (var about = new About())
            {
                about.ShowDialog();
            }
        }

        private void BtnNotificationsReadme_Click(object sender, System.EventArgs e) => HelperFunctions.LaunchUrl("https://github.com/LAB02-Research/HASS.Agent#configuration");

        private void BtnScheduledTaskReadme_Click(object sender, System.EventArgs e) => HelperFunctions.LaunchUrl("https://github.com/LAB02-Research/HASS.Agent#installation");

        private void BtnHelp_Click(object sender, System.EventArgs e) => HelperFunctions.LaunchUrl("https://github.com/LAB02-Research/HASS.Agent");
    }
}
