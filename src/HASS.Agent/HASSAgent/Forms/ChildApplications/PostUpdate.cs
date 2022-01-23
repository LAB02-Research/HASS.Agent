using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using HASSAgent.Functions;
using HASSAgent.Notifications;
using HASSAgent.Properties;
using HASSAgent.Settings;
using Microsoft.Win32.TaskScheduler;
using Serilog;
using Syncfusion.Windows.Forms;
using Task = System.Threading.Tasks.Task;

namespace HASSAgent.Forms.ChildApplications
{
    public partial class PostUpdate : MetroForm
    {
        public PostUpdate()
        {
            InitializeComponent();
        }

        private void PostUpdate_Load(object sender, EventArgs e)
        {
            ProcessPostUpdate();
        }

        /// <summary>
        /// Performs post-update steps to check system state before launch
        /// </summary>
        private async void ProcessPostUpdate()
        {
            // set initial busy indicator
            PbStep1ScheduledTask.Image = Resources.small_loader_32;

            // give the ui time to load
            await Task.Delay(TimeSpan.FromSeconds(2));

            // make sure settings are loaded
            await SettingsManager.LoadAsync(false);

            // check leftover legacy tasks
            var taskDone = await ProcessLegacyTaskAsync();
            PbStep1ScheduledTask.Image = taskDone ? Resources.done_32 : Resources.failed_32;

            // execute port reservation
            var portDone = await ProcessPortReservationAsync();
            PbStep2PortBinding.Image = portDone ? Resources.done_32 : Resources.failed_32;

            // notify the user if something went wrong
            if (!taskDone || !portDone) MessageBoxAdv.Show("Not all steps completed succesfully. Please consult the logs for more information.",
                    "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                // wait a bit to show the 'completed' checks
                await Task.Delay(750);
            }

            // relaunch normally
            HelperFunctions.Restart(true);

            // done, the relauncher will close up
        }

        /// <summary>
        /// Attempts to clean up legacy scheduled tasks, if any
        /// </summary>
        /// <returns></returns>
        private async Task<bool> ProcessLegacyTaskAsync()
        {
            try
            {
                // set busy indicator
                PbStep1ScheduledTask.Image = Resources.small_loader_32;

                // check if it's there
                var taskFound = await Task.Run(ScheduledTasks.IsTaskPresent);
                if (!taskFound) return true;

                // yep, stop if it's still active
                var taskStatus = await Task.Run(ScheduledTasks.TaskStatus);
                if (taskStatus == TaskState.Running)
                {
                    var stopped = ScheduledTasks.Stop();
                    if (!stopped) Log.Warning("[POSTUPDATE] Unable to stop scheduled task, deletion may fail");
                    
                    await Task.Delay(250);
                }

                // try to delete
                var deleted = await ScheduledTasks.RemoveAsync();
                if (!deleted) Log.Error("[POSTUPDATE] Unable to remove scheduled task, manual action required");
                else Log.Information("[POSTUPDATE] Legacy scheduled task removed");

                // set startup-through-reg
                var launchOnLoginSet = LaunchManager.EnableLaunchOnUserLogin();
                if (!launchOnLoginSet) Log.Error("[POSTUPDATE] Unable to activate registry based launch-on-login method");
                else Log.Information("[POSTUPDATE] Registry based launch-on-login method activated");

                // done
                return deleted;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[POSTUPDATE] Error processing legacy task: {err}", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Processes port reservation for the notifier API
        /// </summary>
        /// <returns></returns>
        private async Task<bool> ProcessPortReservationAsync()
        {
            try
            {
                // set busy indicator
                PbStep2PortBinding.Image = Resources.small_loader_32;

                // is the notifier enabled?
                if (!Variables.AppSettings.NotificationsEnabled) return true;

                // yep, set it at the configured port
                var portReserved = await NotifierManager.ExecutePortReservationAsync(Variables.AppSettings.NotifierApiPort);
                if (!portReserved) Log.Error("[POSTUPDATE] Unable to execute port reservation, notifier api might fail");
                else Log.Information("[POSTUPDATE] Port reservation completed");

                // done
                return portReserved;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[POSTUPDATE] Error processing port reservation: {err}", ex.Message);
                return false;
            }
        }

        private void PostUpdate_ResizeEnd(object sender, EventArgs e)
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
    }
}
