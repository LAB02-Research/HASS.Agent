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
        private readonly HotkeySelector _hokHotkeySelector = new HotkeySelector();
        private bool _schedTaskPresent = false;

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
            
            // config hotkey selector
            if (Variables.HotKey != null) _hokHotkeySelector.Enable(TbHotkey, Variables.HotKey);
            else _hokHotkeySelector.Enable(TbHotkey);

        }
        
        private void BtnStore_Click(object sender, System.EventArgs e)
        {
            // store settings
            StoreSettings();

            // reload mqtt
            Task.Run(MqttManager.ReloadMqttSettingsAsync);
            
            // inform the user
            if (!_schedTaskPresent) MessageBoxAdv.Show("Your configuration has been saved.\r\n\r\nSome changes require HASS.Agent to restart before they take effect.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                // we're launched using the scheduled task, which would require the task scheduler to restart
                // ask the user to do it for them
                var question = MessageBoxAdv.Show("Your configuration has been saved. Some changes require HASS.Agent to restart before they take effect.\r\n\r\nDo you want to restart now?", "HASS.Agent", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (question == DialogResult.Yes)
                {
                    // prepare the restart
                    var restartPrepared = ScheduledTasks.RestartScheduledTask();
                    if (!restartPrepared) MessageBoxAdv.Show("Something went wrong while preparing the scheduled task restart.\r\nPlease restart manually through Windows' Task Scheduler.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else Variables.ShuttingDown = true;
                }
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
            CbEnableHotkey.CheckState = Variables.AppSettings.HotKeyEnabled ? CheckState.Checked : CheckState.Unchecked;

            // mqtt
            TbMqttAddress.Text = Variables.AppSettings.MqttAddress;
            TbIntMqttPort.IntegerValue = Variables.AppSettings.MqttPort;
            CbMqttTls.CheckState = Variables.AppSettings.MqttUseTls ? CheckState.Checked : CheckState.Unchecked;
            TbMqttUsername.Text = Variables.AppSettings.MqttUsername;
            TbMqttPassword.Text = Variables.AppSettings.MqttPassword;
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
            Variables.AppSettings.HotKeyEnabled = CbEnableHotkey.CheckState == CheckState.Checked;
            if (Variables.AppSettings.HotKeyEnabled)
            {
                // hotkey enabled, store and activate
                Variables.HotKey = new Hotkey(TbHotkey.Text);
                Variables.AppSettings.HotKey = Variables.HotKey.ToString();
                Variables.FrmM.HotkeyChanged();
            }
            else
            {
                // hotkey disabled, remove and deactivate
                Variables.HotKey = null;
                Variables.AppSettings.HotKey = string.Empty;
                Variables.FrmM.HotkeyChanged(false);
            }

            // mqtt
            Variables.AppSettings.MqttAddress = TbMqttAddress.Text;
            Variables.AppSettings.MqttPort = (int)TbIntMqttPort.IntegerValue;
            Variables.AppSettings.MqttUseTls = CbMqttTls.CheckState == CheckState.Checked;
            Variables.AppSettings.MqttUsername = TbMqttUsername.Text;
            Variables.AppSettings.MqttPassword = TbMqttPassword.Text;

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
                        _schedTaskPresent = true;
                        return;

                    case TaskState.Disabled:
                        LblLaunchOnBootActive.Text = "present, but disabled";
                        LblLaunchOnBootActive.ForeColor = Color.Yellow;
                        return;

                    case TaskState.Ready:
                        LblLaunchOnBootActive.Text = "present, not running";
                        LblLaunchOnBootActive.ForeColor = Color.LawnGreen;
                        _schedTaskPresent = true;
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
                    var restartPrepared = ScheduledTasks.RestartScheduledTask();
                    if (!restartPrepared) MessageBoxAdv.Show("Something went wrong while preparing the scheduled task restart.\r\nPlease restart manually through Windows' Task Scheduler.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        Variables.ShuttingDown = true;
                        DialogResult = DialogResult.OK;
                    }
                    return;
                }
            }

            // failed
            BtnCreateLaunchOnBootTask.Text = "create launch-on-login scheduled task";
            BtnCreateLaunchOnBootTask.Enabled = true;

            MessageBoxAdv.Show("The was an error while creating the task.\r\n\r\nMake sure you have sufficient rights. Check the readme and logs for more info.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Configuration_FormClosing(object sender, FormClosingEventArgs e)
        {
            _hokHotkeySelector?.Dispose();
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

        private void BtnNotificationsReadme_Click(object sender, System.EventArgs e)
        {
            HelperFunctions.LaunchUrl("https://github.com/LAB02-Research/HASS.Agent#configuration");
        }

        private void BtnScheduledTaskReadme_Click(object sender, System.EventArgs e)
        {
            HelperFunctions.LaunchUrl("https://github.com/LAB02-Research/HASS.Agent#installation");
        }

        private void BtnHelp_Click(object sender, System.EventArgs e)
        {
            HelperFunctions.LaunchUrl("https://github.com/LAB02-Research/HASS.Agent");
        }
    }
}
