using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading.Tasks;
using Microsoft.Win32.TaskScheduler;
using Serilog;
using Task = System.Threading.Tasks.Task;

namespace HASSAgent.Functions
{
    /// <summary>
    /// Functions to check and create Windows 'Scheduled Tasks'
    /// </summary>
    internal static class ScheduledTasks
    {
        internal const string TaskName = "HASS.Agent";

        /// <summary>
        /// Check whether the task is present
        /// </summary>
        /// <returns></returns>
        internal static bool IsTaskPresent()
        {
            try
            {
                using (var ts = new TaskService())
                {
                    var task = ts.FindTask(TaskName);
                    return task != null;
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SCHEDULEDTASK] Error while checking task exists: {err}", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Check our task status
        /// </summary>
        /// <returns></returns>
        internal static TaskState TaskStatus()
        {
            try
            {
                using (var ts = new TaskService())
                {
                    var task = ts.FindTask(TaskName);
                    return task?.State ?? TaskState.Unknown;
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SCHEDULEDTASK] Error while getting task status: {err}", ex.Message);
                return TaskState.Unknown;
            }
        }

        /// <summary>
        /// Install a launch-on-login task
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        internal static bool InstallLaunchOnLoginTask(string username, SecureString password)
        {
            try
            {
                using (var ts = new TaskService())
                {
                    // determine supported scheduler version
                    var supported = true;
                    var xp = false;
                    if (ts.HighestSupportedVersion.Major < 2)
                    {
                        supported = false;
                        xp = true;
                    }
                    else if (ts.HighestSupportedVersion.Minor < 1) supported = false;

                    // prepare task definition
                    var taskDefinition = ts.NewTask();
                    taskDefinition.RegistrationInfo.Description = "HASS.Agent launch-on-login task";
                    taskDefinition.RegistrationInfo.Author = username;

                    // prepare logon trigger
                    var logonTrigger = new LogonTrigger
                    {
                        Enabled = true,
                        UserId = username
                    };
                    
                    // bind the trigger
                    taskDefinition.Triggers.Add(logonTrigger);

                    // configure the task, based on supported version
                    if (!xp)
                    {
                        if (supported) taskDefinition.Settings.DisallowStartOnRemoteAppSession = false;

                        taskDefinition.Principal.UserId = username;
                        taskDefinition.Principal.LogonType = TaskLogonType.InteractiveToken;
                        taskDefinition.Principal.RunLevel = TaskRunLevel.Highest;

                        taskDefinition.Settings.AllowDemandStart = true;
                        taskDefinition.Settings.RestartCount = 3;
                    }
                    
                    taskDefinition.Settings.MultipleInstances = TaskInstancesPolicy.IgnoreNew;

                    taskDefinition.Settings.StopIfGoingOnBatteries = false;
                    taskDefinition.Settings.DisallowStartIfOnBatteries = false;

                    taskDefinition.Settings.Enabled = true;
                    taskDefinition.Settings.ExecutionTimeLimit = new TimeSpan(0);

                    // add executable
                    taskDefinition.Actions.Add(new ExecAction(Variables.ApplicationExecutable));

                    // prepare password
                    var passwordBstr = Marshal.SecureStringToBSTR(password);

                    // register task
                    ts.RootFolder.RegisterTaskDefinition(TaskName, taskDefinition, TaskCreation.CreateOrUpdate, username, Marshal.PtrToStringAuto(passwordBstr), TaskLogonType.InteractiveToken);

                    // elevate the new task
                    var elevated = Elevate();
                    if (!elevated) return false;

                    // done
                    Log.Information("[SCHEDULEDTASK] Launch-on-login task created");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SCHEDULEDTASK] Error while creating task: {err}", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Enable 'run with highest privileges'
        /// This has to be done after the task is created
        /// </summary>
        /// <returns></returns>
        private static bool Elevate()
        {
            try
            {
                using (var ts = new TaskService())
                {
                    var task = ts.FindTask(TaskName);
                    if (task == null) return false;

                    if (task.Definition.Principal.RunLevel == TaskRunLevel.Highest) return true;
                    
                    task.Definition.Principal.RunLevel = TaskRunLevel.Highest;
                    task.RegisterChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SCHEDULEDTASK] Error while elevating task: {err}", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Sets the Scheduled Task to enabled
        /// </summary>
        /// <returns></returns>
        internal static bool Enable()
        {
            try
            {
                using (var ts = new TaskService())
                {
                    var task = ts.FindTask(TaskName);
                    if (task == null) return false;

                    if (task.State != TaskState.Disabled) return true;

                    task.Definition.Settings.Enabled = true;
                    task.RegisterChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SCHEDULEDTASK] Error while reenabling task: {err}", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Checks and prepares the Scheduled Task, and finally removes it
        /// </summary>
        /// <returns></returns>
        internal static async Task<bool> RemoveAsync()
        {
            try
            {
                // check if task exists
                using (var ts = new TaskService())
                {
                    var task = ts.FindTask(TaskName);
                    if (task == null) return true;

                    // task found, get current state
                    Log.Information("[SCHEDULEDTASK] HASS.Agent task found, checking state ..");

                    var taskState = TaskStatus();
                    switch (taskState)
                    {
                        case TaskState.Running:
                        {
                            Log.Information("[SCHEDULEDTASK] Task still active, attempting to stop ..");
                            var stopped = Stop();
                            if (!stopped) Log.Warning("[SCHEDULEDTASK] Stopping task failed, removal might fail");
                            else Log.Information("[SCHEDULEDTASK] Task succesfully stopped, ready for removal");

                            // wait a bit
                            await Task.Delay(250);
                            break;
                        }

                        case TaskState.Ready:
                            Log.Information("[SCHEDULEDTASK] Task is stopped, ready for removal");
                            break;

                        default:
                            Log.Information("[SCHEDULEDTASK] Task in unexpected state, removal might fail: {state}",
                                taskState.ToString());
                            break;
                    }

                    // remove the task
                    // remove the task from the containing folder
                    task.Folder.DeleteTask(TaskName, false);

                    // give it some time
                    await Task.Delay(TimeSpan.FromSeconds(5));

                    // check if it's really gone
                    task = ts.FindTask(TaskName);
                    if (task != null)
                    {
                        Log.Error("[SCHEDULEDTASK] Task removal failed, still present");
                        return false;
                    }

                    // done
                    Log.Information("[SCHEDULEDTASK] Task succesfully removed");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SCHEDULEDTASK] Error while processing scheduled task: {msg}", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Attempts to stop the Scheduled Task
        /// </summary>
        /// <returns></returns>
        internal static bool Stop()
        {
            try
            {
                using (var ts = new TaskService())
                {
                    var task = ts.FindTask(TaskName);

                    if (task == null) return true;

                    switch (task.State)
                    {
                        case TaskState.Running:
                            task.Stop();
                            return true;

                        case TaskState.Disabled:
                            task.Stop();
                            Log.Warning("[SCHEDULEDTASK] Task is DISABLED, attempted to stop");
                            return true;

                        case TaskState.Queued:
                            task.Stop();
                            Log.Warning("[SCHEDULEDTASK] Task is QUEUED, attempted to stop");
                            return false;

                        case TaskState.Ready:
                            return true;

                        case TaskState.Unknown:
                            task.Stop();
                            Log.Information("[SCHEDULEDTASK] Task state is UNKNOWN, attempted to stop");
                            return true;
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("0x80070534"))
                {
                    Log.Error("[SCHEDULEDTASK] Task is corrupt, manual removal required");
                    return false;
                }

                Log.Fatal(ex, ex.Message);
                return false;
            }
        }
    }
}
