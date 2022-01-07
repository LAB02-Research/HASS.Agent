using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Threading;
using HASSAgent.Commands;
using HASSAgent.Enums;
using HASSAgent.Forms.Commands;
using HASSAgent.Forms.Sensors;
using HASSAgent.Functions;
using HASSAgent.HomeAssistant;
using HASSAgent.Models;
using HASSAgent.Models.Internal;
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
        private static int WM_QUERYENDSESSION = 0x11;
        private bool _isClosing = false;

        private readonly bool _extendedLogging;

        public Main(bool extendedLogging)
        {
            _extendedLogging = extendedLogging;
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                // bind the ui dispatcher
                Variables.UiDispatcher = Dispatcher.CurrentDispatcher;

                // check if we're enabling extended logging
                if (_extendedLogging)
                {
                    // exception handlers
                    Application.ThreadException += Application_ThreadException;
                    AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
                }

                // catch all key presses
                KeyPreview = true;

                // prepare configuration form
                Variables.ConfigForm = new Configuration();

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
                var loaded = SettingsManager.Load();
                if (!loaded)
                {
                    MessageBoxAdv.Show("Something went wrong while loading your settings.\r\n\r\nCheck appsettings.json in the 'Config' subfolder, or just delete it to start fresh.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // abort
                    Variables.ShuttingDown = true;
                    Log.CloseAndFlush();
                    Close();
                    return;
                }

                // process onboarding
                ProcessOnboarding();

                // if we're shutting down, no point continuing
                if (Variables.ShuttingDown) return;
                
                // initialize hotkeys
                InitializeHotkeys();

                // initialize managers
                Task.Run(NotifierManager.Initialize);
                Task.Run(HassApiManager.InitializeAsync);
                Task.Run(MqttManager.Initialize);
                Task.Run(SensorsManager.Initialize);
                Task.Run(CommandsManager.Initialize);
                Task.Run(UpdateManager.Initialize);
                Task.Run(SystemStateManager.Initialize);
                Task.Run(CacheManager.Initialize);

                // run a check to see if we could restart through the scheduled task
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

        /// <summary>
        /// Listen to Windows messages to detect session endings
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_QUERYENDSESSION) SystemStateManager.ProcessSessionEnd();
            base.WndProc(ref m);
        }

        /// <summary>
        /// Looks for our Scheduled Task, if it's there but not started, offers to restart using it
        /// </summary>
        private void ScheduledTaskCheck()
        {
#if DEBUG
            // don't perform this check when we're debugging
            return;
#endif

            // check if there's a task
            var present = ScheduledTasks.IsTaskPresent();
            if (!present) return;

            // get the task status
            var status = ScheduledTasks.TaskStatus();

            // only relevant if the task's in 'ready' state
            if (status != TaskState.Ready) return;

            Invoke(new MethodInvoker(delegate
            {
                // ask the user if they want to launch using the task
                var question = MessageBoxAdv.Show("You've launched HASS.Agent manually, but there's a Scheduled Task present. That's the recommended way to start HASS.Agent.\r\n\r\nDo you want to restart HASS.Agent using the task?", "HASS.Agent", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (question != DialogResult.Yes) return;

                // prepare the restart
                var restartPrepared = HelperFunctions.RestartWithTask();
                if (!restartPrepared) MessageBoxAdv.Show("Something went wrong while preparing the restart.\r\nPlease restart manually through Windows' Task Scheduler.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }));
        }

        /// <summary>
        /// Checks to see if we need to launch onboarding, and if so, does that
        /// </summary>
        private void ProcessOnboarding()
        {
            if (Variables.AppSettings.OnboardingStatus == OnboardingStatus.Completed || Variables.AppSettings.OnboardingStatus == OnboardingStatus.Aborted) return;
            
            // show onboarding
            using (var onboarding = new Onboarding())
            {
                onboarding.ShowDialog();
            }
        }

        /// <summary>
        /// Log ThreadExceptions (if enabled)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Log.Fatal(e.Exception, "[MAIN] ThreadException: {err}", e.Exception.Message);
        }

        /// <summary>
        /// Log unhandled exceptions (if enabled)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception ex) Log.Fatal(ex, "[MAIN] ThreadException: {err}", ex.Message);
        }
        
        /// <summary>
        /// Initialize the hotkeys (if any)
        /// </summary>
        private void InitializeHotkeys()
        {
            // prepare listener
            Variables.HotKeyListener.HotkeyPressed += HotkeyListener_HotkeyPressed;

            // always suspend when configuring
            Variables.HotKeyListener.SuspendOn(Variables.ConfigForm);

            // bind quick actions hotkey (if configured)
            Variables.HotKeyManager.InitializeQuickActionsHotKeys();
        }

        /// <summary>
        /// Fires when a registered hotkey is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HotkeyListener_HotkeyPressed(object sender, HotkeyEventArgs e)
        {
            if (e.Hotkey == Variables.QuickActionsHotKey) ShowQuickActions();
            else Variables.HotKeyManager.ProcessQuickActionHotKey(e.Hotkey.ToString());
        }

        /// <summary>
        /// Hide if not shutting down, close otherwise
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isClosing) return;

            Invoke(new MethodInvoker(Hide));
            
            if (!Variables.ShuttingDown)
            {
                e.Cancel = true;
                return;
            }

            // we're calling the shutdown function, but async won't hold so ignore that
            Task.Run(HelperFunctions.ShutdownAsync);

            // cancel and let the shutdown function handle it
            _isClosing = true;
            e.Cancel = true;
        }

        /// <summary>
        /// Hides the tray icon
        /// </summary>
        internal void HideTrayIcon()
        {
            if (!IsHandleCreated) return;
            if (IsDisposed) return;

            Invoke(new MethodInvoker(delegate
            {
                NotifyIcon.Visible = false;
            }));
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
            var q = MessageBoxAdv.Show("Are you sure?\r\n\r\nYou won't be able to receive notifications,\r\nuse quick actions, receive commands or transmit sensor data.", "HASS.Agent", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (q != DialogResult.Yes) return;
#endif

            Variables.ShuttingDown = true;
            Close();
        }

        /// <summary>
        /// Show the config form
        /// </summary>
        private void ShowConfiguration() => Variables.ConfigForm.ShowDialog();

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
        internal void SetNotificationApiStatus(ComponentStatus status) => SetComponentStatus(new ComponentStatusUpdate(Component.NotificationApi, status));

        /// <summary>
        /// Change the status of the HASS API manager
        /// </summary>
        /// <param name="status"></param>
        internal void SetHassApiStatus(ComponentStatus status) => SetComponentStatus(new ComponentStatusUpdate(Component.HassApi, status));

        /// <summary>
        /// Change the status of the QuickActions
        /// </summary>
        /// <param name="status"></param>
        internal void SetQuickActionsStatus(ComponentStatus status) => SetComponentStatus(new ComponentStatusUpdate(Component.QuickActions, status));

        /// <summary>
        /// Change the status of the sensors manager
        /// </summary>
        /// <param name="status"></param>
        internal void SetSensorsStatus(ComponentStatus status) => SetComponentStatus(new ComponentStatusUpdate(Component.Sensors, status));

        /// <summary>
        /// Change the status of the commands manager status
        /// </summary>
        /// <param name="status"></param>
        internal void SetCommandsStatus(ComponentStatus status) => SetComponentStatus(new ComponentStatusUpdate(Component.Commands, status));

        /// <summary>
        /// Change the status of the MQTT manager status
        /// </summary>
        /// <param name="status"></param>
        internal void SetMqttStatus(ComponentStatus status) => SetComponentStatus(new ComponentStatusUpdate(Component.Mqtt, status));

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

        /// <summary>
        /// Shows a tray-icon tooltip containing the message, and optionally and error-icon
        /// </summary>
        /// <param name="message"></param>
        /// <param name="error"></param>
        internal void ShowToolTip(string message, bool error = false)
        {
            if (!IsHandleCreated) return;
            if (IsDisposed) return;

            try
            {
                Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        NotifyIcon.BalloonTipIcon = error ? ToolTipIcon.Error : ToolTipIcon.Info;
                        NotifyIcon.BalloonTipText = message;
                        NotifyIcon.ShowBalloonTip((int)TimeSpan.FromSeconds(5).TotalMilliseconds);
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

        private void NotifyIcon_DoubleClick(object sender, EventArgs e) => ShowMain();

        private void BtnExit_Click(object sender, EventArgs e) => Exit();

        private void BtnHide_Click(object sender, EventArgs e) => Hide();

        private void BtnAppSettings_Click(object sender, EventArgs e) => ShowConfiguration();

        private void BtnActionsManager_Click(object sender, EventArgs e) => ShowQuickActionsManager();

        private void BtnSensorsManager_Click(object sender, EventArgs e) => ShowSensorsManager();

        private void BtnCommandsManager_Click(object sender, EventArgs e) => ShowCommandsManager();

        private void Main_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape) return;
            Hide();
        }

        private void TsShow_Click(object sender, EventArgs e) => ShowMain();

        private void TsShowQuickActions_Click(object sender, EventArgs e) => ShowQuickActions();

        private void TsConfig_Click(object sender, EventArgs e) => ShowConfiguration();

        private void TsQuickItemsConfig_Click(object sender, EventArgs e) => ShowQuickActionsManager();

        private void TsLocalSensors_Click(object sender, EventArgs e) => ShowSensorsManager();

        private void TsCommands_Click(object sender, EventArgs e) => ShowCommandsManager();

        private void TsExit_Click(object sender, EventArgs e) => Exit();

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

        private void BtnCheckForUpdate_Click(object sender, EventArgs e) => CheckForUpdate();

        private void TsCheckForUpdates_Click(object sender, EventArgs e) => CheckForUpdate();

        /// <summary>
        /// Checks GitHub API to see if there's a newer release available
        /// </summary>
        private async void CheckForUpdate()
        {
            try
            {
                TsCheckForUpdates.Enabled = false;
                BtnCheckForUpdate.Enabled = false;

                TsCheckForUpdates.Text = "checking ..";
                BtnCheckForUpdate.Text = "checking ..";

                var (isAvailable, version) = await UpdateManager.CheckIsUpdateAvailableAsync();
                if (!isAvailable)
                {
                    MessageBoxAdv.Show("You're running the latest version!", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // new update, show info
                ShowUpdateInfo(version);
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

        /// <summary>
        /// Shows a window, informing the user of a pending update
        /// </summary>
        /// <param name="version"></param>
        internal void ShowUpdateInfo(string version)
        {
            if (!IsHandleCreated) return;
            if (IsDisposed) return;

            try
            {
                Invoke(new MethodInvoker(delegate
                {
                    var updatePending = new UpdatePending(version);
                    updatePending.FormClosed += delegate { updatePending.Dispose(); };
                    updatePending.Show();
                }));
            }
            catch
            {
                // best effort
            }
        }
    }
}
