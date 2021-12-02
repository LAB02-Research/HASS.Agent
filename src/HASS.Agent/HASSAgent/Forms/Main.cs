using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using HASSAgent.Commands;
using HASSAgent.Enums;
using HASSAgent.Forms.Commands;
using HASSAgent.Forms.Sensors;
using HASSAgent.Functions;
using HASSAgent.HomeAssistant;
using HASSAgent.Models;
using HASSAgent.Mqtt;
using HASSAgent.Notifications;
using HASSAgent.Sensors;
using HASSAgent.Settings;
using Microsoft.Win32.TaskScheduler;
using Serilog;
using Syncfusion.Windows.Forms;
using WK.Libraries.HotkeyListenerNS;
using QuickActionsConfig = HASSAgent.Forms.QuickActions.QuickActionsConfig;
using Task = System.Threading.Tasks.Task;

namespace HASSAgent.Forms
{
    [SuppressMessage("ReSharper", "MemberCanBeMadeStatic.Local")]
    public partial class Main : MetroForm
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                if (Properties.Settings.Default.EnableExtendedLogging)
                {
                    // exception handlers
                    Application.ThreadException += Application_ThreadException;
                    AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
                }

                // catch all key presses
                KeyPreview = true;

                // prepare configuration form
                Variables.FrmConfig = new Configuration();

                // set all statuses to loading
                SetNotificationApiStatus(ComponentStatus.Loading);
                SetHassApiStatus(ComponentStatus.Loading);
                SetQuickActionsStatus(ComponentStatus.Loading);
                SetSensorsStatus(ComponentStatus.Loading);
                SetCommandsStatus(ComponentStatus.Loading);
                SetMqttStatus(ComponentStatus.Loading);

                // create a hotkey listener
                Variables.HotKeyListener = new HotkeyListener();

                // load settings
                SettingsManager.Load(out var firstLaunch);

                // check firstlaunch, optionally abort launching if we're restarting
                if (ProcessFirstLaunch(firstLaunch)) return;

                // initialize hotkey
                InitializeHotkey();

                // initialize managers
                Task.Run(NotifierManager.Initialize);
                Task.Run(HassApiManager.Initialize);
                Task.Run(MqttManager.Initialize);
                Task.Run(SensorsManager.Initialize);
                Task.Run(CommandsManager.Initialize);
                Task.Run(UpdateManager.Initialize);

                // run a check to see if we need to restart through the scheduled task
                Task.Run(ScheduledTaskCheck);

#if DEBUG
            // show the form while we're debugging
            Task.Run(async delegate
            {
                await Task.Delay(500);
                Invoke(new MethodInvoker(Show));
                await Task.Delay(150);
                Invoke(new MethodInvoker(BringToFront));
            });
#endif
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[MAIN] Main_Load: {err}", ex.Message);
                MessageBoxAdv.Show("There was an error launching HASS.Agent.\r\nPlease check the logs and make a bug report on github.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // we're done
                Application.Exit();
            }
        }
        
        private void ScheduledTaskCheck()
        {
#if DEBUG
            // don't perform this check when we're debugging
            return;
#endif

            // check task status
            var present = ScheduledTasks.IsTaskPresent();
            var status = present ? ScheduledTasks.TaskStatus() : TaskState.Unknown;

            // ready means present-but-not-started, so check for that
            if (status != TaskState.Ready)
            {
                // todo: show a one-time message asking the user if they want the task created
                return;
            }

            Invoke(new MethodInvoker(delegate
            {
                // ask the user if they want to launch using the task
                // todo: only ask once
                var question = MessageBoxAdv.Show("You've launched HASS.Agent manually, but there's a Scheduled Task present (recommended).\r\n\r\nDo you want to restart HASS.Agent using the task?", "HASS.Agent", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (question != DialogResult.Yes) return;

                // prepare the restart
                var restartPrepared = ScheduledTasks.RestartScheduledTask();
                if (!restartPrepared) MessageBoxAdv.Show("Something went wrong while preparing the scheduled task restart.\r\nPlease restart manually through Windows' Task Scheduler.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    Variables.ShuttingDown = true;
                    Close();
                }
            }));
        }

        private bool ProcessFirstLaunch(bool firstLaunch)
        {
            if (!firstLaunch) return false;

            var question = MessageBoxAdv.Show("No configuration found. Do you want to show the configuration screen now?", "HASS.Agent", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (question != DialogResult.Yes) return false;

            // show config screen
            ShowConfiguration();

            // check if the user wants to restart, no point continueing in that case
            return Variables.ShuttingDown;
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Log.Fatal(e.Exception, "[MAIN] ThreadException: {err}", e.Exception.Message);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = e.ExceptionObject as Exception;
            Log.Fatal(ex, "[MAIN] ThreadException: {err}", ex.Message);
        }


        /// <summary>
        /// Initialize the hotkey (if any)
        /// </summary>
        private void InitializeHotkey()
        {
            // prepare listener
            Variables.HotKeyListener.HotkeyPressed += HotkeyListener_HotkeyPressed;
            Variables.HotKeyListener.SuspendOn(Variables.FrmConfig);

            // check if hotkey's active
            if (!Variables.AppSettings.HotKeyEnabled) return;
            if (Variables.HotKey == null) return;
            if (Variables.HotKey.ToString() == "None") return;

            // bind the loaded hotkey
            Variables.HotKeyListener.Add(Variables.HotKey);
        }

        /// <summary>
        /// Process a changed hotkey
        /// </summary>
        /// <param name="register"></param>
        internal void HotkeyChanged(bool register = true)
        {
            // process a new hotkey
            Variables.HotKeyListener.RemoveAll();
            if (register) Variables.HotKeyListener.Add(Variables.HotKey);
        }

        /// <summary>
        /// Fires when the registered hotkey is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HotkeyListener_HotkeyPressed(object sender, HotkeyEventArgs e)
        {
            ShowQuickActions();
        }

        /// <summary>
        /// Hide if not shutting down, close otherwise
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Invoke(new MethodInvoker(Hide));

            if (!Variables.ShuttingDown)
            {
                e.Cancel = true;
                return;
            }

            await HelperFunctions.Shutdown();
        }

        /// <summary>
        /// Show a messagebox on the UI thread
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="error"></param>
        internal void ShowMessageBox(string msg, bool error = false)
        {
            if (!IsHandleCreated) return;
            if (IsDisposed) return;

            Invoke(new MethodInvoker(delegate
            {
                var icon = error ? MessageBoxIcon.Error : MessageBoxIcon.Information;
                MessageBoxAdv.Show(msg, "HASS.Agent", MessageBoxButtons.OK, icon);
            }));
        }

        /// <summary>
        /// Show/hide ourself
        /// </summary>
        private async void ShowMain()
        {
            if (!IsHandleCreated) return;
            if (IsDisposed) return;

            if (Visible) Hide();
            else
            {
                Show();

                await Task.Delay(150);

                BringToFront();
                Activate();
            }
        }

        /// <summary>
        /// Show the QuickActions form
        /// </summary>
        private void ShowQuickActions()
        {
            // check if quickactions aren't already open, and if there are any actions
            if (HelperFunctions.CheckIfFormIsOpen("QuickActions")) return;
            if (!Variables.QuickActions.Any()) return;

            // show a new window
            using (var quickActions = new QuickActions.QuickActions(Variables.QuickActions))
            {
                quickActions.ShowDialog();
            }
        }

        /// <summary>
        /// Get confirmation to close, if so, close
        /// </summary>
        private void Exit()
        {
#if !DEBUG
            // only ask for confirmation if we're not debugging
            var q = MessageBoxAdv.Show("Are you sure? You won't be able to receive notifications,\r\nuse quick actions, receive commands or transmit sensor data.", "HASS.Agent", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (q != DialogResult.Yes) return;
#endif

            Variables.ShuttingDown = true;
            Close();
        }

        /// <summary>
        /// Show the config form
        /// </summary>
        private void ShowConfiguration()
        {
            var result = Variables.FrmConfig.ShowDialog();
            if (result != DialogResult.OK) return;

            // check to see if we're restarting
            if (!Variables.ShuttingDown) return;

            // jep, close
            Close();
        }

        /// <summary>
        /// Show the quickactions manager form
        /// </summary>
        private void ShowQuickActionsManager()
        {
            using (var quickActions = new QuickActionsConfig())
            {
                quickActions.ShowDialog();
            }
        }

        /// <summary>
        /// Show the sensors manager form
        /// </summary>
        private void ShowSensorsManager()
        {
            using (var sensorsConfig = new SensorsConfig())
            {
                sensorsConfig.ShowDialog();
            }
        }

        /// <summary>
        /// /Show the commands manager form
        /// </summary>
        private void ShowCommandsManager()
        {
            using (var commandsConfig = new CommandsConfig())
            {
                commandsConfig.ShowDialog();
            }
        }

        /// <summary>
        /// Change the status of the Notification API
        /// </summary>
        /// <param name="status"></param>
        internal void SetNotificationApiStatus(ComponentStatus status)
        {
            SetComponentStatus(new ComponentStatusUpdate(Component.NotificationApi, status));
        }

        /// <summary>
        /// Change the status of the HASS API manager
        /// </summary>
        /// <param name="status"></param>
        internal void SetHassApiStatus(ComponentStatus status)
        {
            SetComponentStatus(new ComponentStatusUpdate(Component.HassApi, status));
        }

        /// <summary>
        /// Change the status of the QuickActions
        /// </summary>
        /// <param name="status"></param>
        internal void SetQuickActionsStatus(ComponentStatus status)
        {
            SetComponentStatus(new ComponentStatusUpdate(Component.QuickActions, status));
        }

        /// <summary>
        /// Change the status of the sensors manager
        /// </summary>
        /// <param name="status"></param>
        internal void SetSensorsStatus(ComponentStatus status)
        {
            SetComponentStatus(new ComponentStatusUpdate(Component.Sensors, status));
        }

        /// <summary>
        /// Change the status of the commands manager status
        /// </summary>
        /// <param name="status"></param>
        internal void SetCommandsStatus(ComponentStatus status)
        {
            SetComponentStatus(new ComponentStatusUpdate(Component.Commands, status));
        }

        /// <summary>
        /// Change the status of the MQTT manager status
        /// </summary>
        /// <param name="status"></param>
        internal void SetMqttStatus(ComponentStatus status)
        {
            SetComponentStatus(new ComponentStatusUpdate(Component.Mqtt, status));
        }

        /// <summary>
        /// Set the status of the component in our UI
        /// </summary>
        /// <param name="update"></param>
        internal void SetComponentStatus(ComponentStatusUpdate update)
        {
            if (!IsHandleCreated) return;
            if (IsDisposed) return;

            try
            {
                Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        var status = update.Status;

                        switch (update.Component)
                        {
                            case Component.NotificationApi:
                                LblStatusNotificationApi.Text = status.ToString().ToLower();
                                LblStatusNotificationApi.ForeColor = status.GetColor();
                                break;

                            case Component.HassApi:
                                LblStatusHassApi.Text = status.ToString().ToLower();
                                LblStatusHassApi.ForeColor = status.GetColor();
                                break;

                            case Component.Mqtt:
                                LblStatusMqtt.Text = status.ToString().ToLower();
                                LblStatusMqtt.ForeColor = status.GetColor();
                                break;

                            case Component.QuickActions:
                                LblStatusQuickActions.Text = status.ToString().ToLower();
                                LblStatusQuickActions.ForeColor = status.GetColor();
                                break;

                            case Component.Sensors:
                                LblStatusSensors.Text = status.ToString().ToLower();
                                LblStatusSensors.ForeColor = status.GetColor();
                                break;

                            case Component.Commands:
                                LblStatusCommands.Text = status.ToString().ToLower();
                                LblStatusCommands.ForeColor = status.GetColor();
                                break;
                        }

                        GpStatus.Refresh();
                    }
                    catch
                    {
                        // best effort
                    }
                }));
            }
            catch
            {
                // best effort
            }
        }

        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            ShowMain();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void BtnHide_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void BtnAppSettings_Click(object sender, EventArgs e)
        {
            ShowConfiguration();
        }

        private void BtnActionsManager_Click(object sender, EventArgs e)
        {
            ShowQuickActionsManager();
        }

        private void BtnSensorsManager_Click(object sender, EventArgs e)
        {
            ShowSensorsManager();
        }

        private void BtnCommandsManager_Click(object sender, EventArgs e)
        {
            ShowCommandsManager();
        }

        private void Main_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape) return;
            Hide();
        }

        private void TsShow_Click(object sender, EventArgs e)
        {
            ShowMain();
        }

        private void TsShowQuickActions_Click(object sender, EventArgs e)
        {
            ShowQuickActions();
        }

        private void TsConfig_Click(object sender, EventArgs e)
        {
            ShowConfiguration();
        }

        private void TsQuickItemsConfig_Click(object sender, EventArgs e)
        {
            ShowQuickActionsManager();
        }

        private void TsLocalSensors_Click(object sender, EventArgs e)
        {
            ShowSensorsManager();
        }

        private void TsCommands_Click(object sender, EventArgs e)
        {
            ShowCommandsManager();
        }

        private void TsExit_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void TsAbout_Click(object sender, EventArgs e)
        {
            using (var about = new About())
            {
                about.ShowDialog();
            }
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            using (var about = new About())
            {
                about.ShowDialog();
            }
        }

        private void BtnCheckForUpdate_Click(object sender, EventArgs e)
        {
            CheckForUpdate();
        }

        private void TsCheckForUpdates_Click(object sender, EventArgs e)
        {
            CheckForUpdate();
        }

        private async void CheckForUpdate()
        {
            try
            {
                TsCheckForUpdates.Enabled = false;
                BtnCheckForUpdate.Enabled = false;

                TsCheckForUpdates.Text = "checking ..";
                BtnCheckForUpdate.Text = "checking ..";

                var (isAvailable, version) = await UpdateManager.UpdateAvailable();
                if (!isAvailable)
                {
                    MessageBoxAdv.Show("You're running the latest version!", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var choice = MessageBoxAdv.Show($"There's a new version available: {version}\r\n\r\nDo you want to open your browser and download the .zip?", "HASS.Agent", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (choice != DialogResult.Yes) return;

                var url = await UpdateManager.GetLatestVersionAssetUrl();
                if (string.IsNullOrEmpty(url))
                {
                    MessageBoxAdv.Show("Unable to fetch the .zip url, opening the github page instead.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    HelperFunctions.LaunchUrl("https://github.com/LAB02-Research/HASS.Agent");
                    return;
                }

                HelperFunctions.LaunchUrl(url);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[MAIN] Error while checking for updates: {msg}", ex.Message);
            }
            finally
            {
                TsCheckForUpdates.Enabled = true;
                BtnCheckForUpdate.Enabled = true;

                TsCheckForUpdates.Text = "check for updates";
                BtnCheckForUpdate.Text = "check for updates";
            }
        }
    }
}
