using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using Microsoft.Win32.TaskScheduler;
using Serilog;

namespace HASSAgent.Functions
{
    /// <summary>
    /// Functions to check and create Windows 'Scheduled Tasks'
    /// </summary>
    internal static class ScheduledTasks
    {
        private const string TaskName = "HASS.Agent";

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
                Log.Fatal(ex, "[SCHEDULEDTASKS] Error while checking task exists: {err}", ex.Message);
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
                Log.Fatal(ex, "[SCHEDULEDTASKS] Error while getting task status: {err}", ex.Message);
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
                    Log.Information("[TASK] Launch-on-login task created");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SCHEDULEDTASKS] Error while creating task: {err}", ex.Message);
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
                Log.Fatal(ex, "[SCHEDULEDTASKS] Error while elevating task: {err}", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Launches a .bat that starts the scheduled task after 10 seconds
        /// </summary>
        /// <returns></returns>
        internal static bool RestartScheduledTask()
        {
            try
            {
                var restartBat = Path.Combine(Variables.StartupPath, "restart_hass_agent.bat");
                if (File.Exists(restartBat)) File.Delete(restartBat);

                var restartBatContent = new StringBuilder();

                // prepare the .bat content
                restartBatContent.AppendLine("@echo off");
                restartBatContent.AppendLine("TITLE HASS.Agent Restarter");
                restartBatContent.AppendLine("echo.");
                restartBatContent.AppendLine("echo HASS.Agent Restarter");
                restartBatContent.AppendLine("echo.");
                restartBatContent.AppendLine("echo.");
                restartBatContent.AppendLine("echo Waiting 10 seconds for HASS.Agent to properly close ..");
                restartBatContent.AppendLine("echo.");
                restartBatContent.AppendLine("timeout 10 > NUL");
                restartBatContent.AppendLine("echo.");
                restartBatContent.AppendLine($"echo Starting scheduled task: {TaskName} ..");
                restartBatContent.AppendLine($"schtasks /run /TN \"{TaskName}\"");
                restartBatContent.AppendLine("echo.");
                restartBatContent.AppendLine("echo Done!");
                restartBatContent.AppendLine("timeout 1 > NUL");

                // create the .bat
                File.WriteAllText(restartBat, restartBatContent.ToString());

                // launch it
                Process.Start(restartBat);

                // done
                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SCHEDULEDTASKS] Error while preparing task restart: {err}", ex.Message);
                return false;
            }
        }
    }
}
