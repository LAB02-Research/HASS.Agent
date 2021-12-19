using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HASSAgent.Forms;
using HASSAgent.Functions;
using Microsoft.Win32.TaskScheduler;
using Syncfusion.Windows.Forms;
using Task = System.Threading.Tasks.Task;

namespace HASSAgent.Controls.Onboarding
{
    public partial class ScheduledTask : UserControl
    {
        private TaskState _taskState = TaskState.Unknown;

        public ScheduledTask()
        {
            InitializeComponent();
        }

        private void ScheduledTask_Load(object sender, EventArgs e)
        {
            // check if it's already done
            if (Variables.OnboardingScheduledTaskCreated)
            {
                // already done
                LblCreateInfo.Text = "Task succesfully created!";
                LblCreateInfo.ForeColor = Color.LimeGreen;
                BtnCreateScheduledTask.Visible = false;
                return;
            }

            // nope, run tests
            Task.Run(DetermineScheduledTaskStatus);
        }

        /// <summary>
        /// Determine the current status (if any) of the run-on-login scheduled task
        /// </summary>
        private void DetermineScheduledTaskStatus()
        {
            var present = ScheduledTasks.IsTaskPresent();
            if (!present)
            {
                Invoke(new MethodInvoker(delegate
                {
                    LblCreateInfo.Text = "Do you want to create one now?";
                    BtnCreateScheduledTask.Enabled = true;
                }));

                return;
            }

            _taskState = ScheduledTasks.TaskStatus();

            Invoke(new MethodInvoker(delegate
            {
                switch (_taskState)
                {
                    case TaskState.Running:
                        LblCreateInfo.Text = "The task's already present and running, all set!";
                        LblCreateInfo.ForeColor = Color.LimeGreen;
                        BtnCreateScheduledTask.Enabled = false;
                        return;

                    case TaskState.Disabled:
                        LblCreateInfo.Text = "The task's already present and disabled. Click the button to re-enable the task.";
                        LblCreateInfo.ForeColor = Color.Yellow;
                        BtnCreateScheduledTask.Enabled = true;
                        BtnCreateScheduledTask.Text = "yes, re-enable the scheduled task";
                        return;

                    case TaskState.Ready:
                        LblCreateInfo.Text = "The task's already present but not running. HASS.Agent will start it for you at the end of the onboarding process.";
                        LblCreateInfo.ForeColor = Color.LawnGreen;
                        BtnCreateScheduledTask.Enabled = false;
                        return;

                    case TaskState.Queued:
                        LblCreateInfo.Text = "The task's already present but in 'queued' state. It'll start after a reboot.";
                        LblCreateInfo.ForeColor = Color.Yellow;
                        BtnCreateScheduledTask.Enabled = false;
                        break;

                    case TaskState.Unknown:
                        LblCreateInfo.Text = "The task's already present but in 'unknown' state. It'll probably start after a reboot..";
                        LblCreateInfo.ForeColor = Color.Yellow;
                        BtnCreateScheduledTask.Enabled = false;
                        break;
                }
            }));
        }

        private async void BtnCreateScheduledTask_Click(object sender, EventArgs e)
        {
            if (_taskState == TaskState.Disabled)
            {
                ReenableScheduledTask();
                return;
            }

            // lock interface
            BtnCreateScheduledTask.Text = "creating task, hold on ..";
            BtnCreateScheduledTask.Enabled = false;

            using (var userCredentials = new GetUserCredentials())
            {
                // get the user's credentials
                var result = userCredentials.ShowDialog();
                if (result != DialogResult.OK)
                {
                    LblCreateInfo.Text = "Your credentials are needed to create the task. They are never stored. You can try again if you want, or skip to the next page.";
                    LblCreateInfo.ForeColor = Color.Yellow;

                    BtnCreateScheduledTask.Text = "create scheduled task";
                    BtnCreateScheduledTask.Enabled = true;
                    return;
                }

                // create the task
                var created = await Task.Run(() => ScheduledTasks.InstallLaunchOnLoginTask(userCredentials.Username, userCredentials.Password));
                if (created)
                {
                    // success
                    Variables.OnboardingScheduledTaskCreated = true;

                    BtnCreateScheduledTask.Visible = false;

                    LblCreateInfo.Text = "Task succesfully created!";
                    LblCreateInfo.ForeColor = Color.LimeGreen;
                }
                else
                {
                    LblCreateInfo.Text = "Something went wrong, perhaps the credentials weren't right? You can try again, or skip to the next page.";
                    LblCreateInfo.ForeColor = Color.Yellow;

                    BtnCreateScheduledTask.Text = "create scheduled task";
                    BtnCreateScheduledTask.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Tries to enable a disabled Scheduled Task
        /// </summary>
        private async void ReenableScheduledTask()
        {
            var enabled = await Task.Run(ScheduledTasks.Enable);
            if (!enabled)
            {
                BtnCreateScheduledTask.Visible = false;
                LblCreateInfo.Text = "Something went wrong. You can try deleting the task manually, and then recreating it later through the configuration window.";
                LblCreateInfo.ForeColor = Color.Yellow;
            }

            BtnCreateScheduledTask.Visible = false;

            LblCreateInfo.Text = "Task succesfully enabled!";
            LblCreateInfo.ForeColor = Color.LimeGreen;
        }
    }
}
