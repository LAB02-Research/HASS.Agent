using System.IO;
using System.ServiceProcess;
using HASS.Agent.Functions;
using HASS.Agent.Resources.Localization;
using HASS.Agent.Shared.Managers;
using Microsoft.Win32;
using Serilog;
using TimeoutException = System.ServiceProcess.TimeoutException;

namespace HASS.Agent.Managers
{
    internal static class ServiceControllerManager
    {
        /// <summary>
        /// Returns whether the satellite service exists
        /// </summary>
        /// <returns></returns>
        internal static bool ServiceExists()
        {
            try
            {
                using var svc = new ServiceController(Variables.SatelliteServiceName);
                return !string.IsNullOrEmpty(svc.DisplayName);
            }
            catch (InvalidOperationException)
            {
                // service wasn't found
                return false;
            }
        }

        /// <summary>
        /// Returns the current state of the service (started, stopped, etc)
        /// </summary>
        /// <returns></returns>
        internal static ServiceControllerStatus GetServiceState()
        {
            using var svc = new ServiceController(Variables.SatelliteServiceName);
            return svc.Status;
        }

        /// <summary>
        /// Starts the satellite service
        /// </summary>
        /// <returns></returns>
        internal static async Task<(bool started, string error)> StartServiceAsync()
        {
            try
            {
                using (var sc = new ServiceController(Variables.SatelliteServiceName))
                {
                    // already running?
                    if (sc.Status == ServiceControllerStatus.Running) return (true, string.Empty);

                    // nope, start
                    sc.Start();

                    try
                    {
                        // wait max 10 seconds for it to start
                        sc.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(10));
                    }
                    catch (TimeoutException ex)
                    {
                        Log.Error("[SERVICE] Timeout trying to start: {err}", ex.Message);
                        return (false, Languages.ServiceControllerManager_Error_Timeout);
                    }
                    catch (Exception ex)
                    {
                        Log.Fatal(ex, "[SERVICE] Unable to start: {err}", ex.Message);
                        return (false, Languages.ServiceControllerManager_Error_Fatal);
                    }
                }

                // it should be started, but check again
                for (var rotation = 0; rotation < 6; rotation++)
                {
                    using (var sc = new ServiceController(Variables.SatelliteServiceName))
                    {
                        if (sc.Status == ServiceControllerStatus.Running)
                        {
                            // all good
                            return (true, string.Empty);
                        }
                    }

                    // nope ..
                    await Task.Delay(TimeSpan.FromSeconds(1));
                }

                // failed
                Log.Error("[SERVICE] Service still hasn't started after 5 seconds, unknown reason");
                return (false, Languages.ServiceControllerManager_Error_Unknown);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SERVICE] Error while starting: {err}", ex.Message);
                return (false, Languages.ServiceControllerManager_Error_Fatal);
            }
        }

        /// <summary>
        /// Stops the satellite service, first by asking to shutdown, then by forcing
        /// </summary>
        /// <returns></returns>
        internal static async Task<(bool stopped, string error)> StopServiceAsync()
        {
            try
            {
                using (var sc = new ServiceController(Variables.SatelliteServiceName))
                {
                    // already stopped?
                    if (sc.Status == ServiceControllerStatus.Stopped) return (true, string.Empty);

                    // nope, first try to ask nicely if it's running
                    if (sc.Status == ServiceControllerStatus.Running)
                    {
                        var (success, error) = await Task.Run(async () => await Variables.RpcClient.ShutdownServiceAsync().WaitAsync(Variables.RpcConnectionTimeout));
                        if (success) return (true, string.Empty);

                        Log.Warning("[SERVICE] Asking service to stop failed with message: {err}", error);
                        Log.Warning("[SERVICE] Attempting to force stop..");
                    }

                    // not started, not responding or failed, so force-stop
                    sc.Stop();

                    try
                    {
                        // wait max 10 seconds for it to stop
                        sc.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(10));
                    }
                    catch (TimeoutException ex)
                    {
                        Log.Error("[SERVICE] Timeout trying to stop: {err}", ex.Message);
                        return (false, Languages.ServiceControllerManager_Error_Timeout);
                    }
                    catch (Exception ex)
                    {
                        Log.Fatal(ex, "[SERVICE] Unable to stop: {err}", ex.Message);
                        return (false, Languages.ServiceControllerManager_Error_Fatal);
                    }
                }

                // it should be stopped, but check again
                for (var rotation = 0; rotation < 6; rotation++)
                {
                    using (var sc = new ServiceController(Variables.SatelliteServiceName))
                    {
                        if (sc.Status == ServiceControllerStatus.Stopped)
                        {
                            // all good
                            return (true, string.Empty);
                        }
                    }

                    // nope
                    await Task.Delay(TimeSpan.FromSeconds(1));
                }

                // failed
                Log.Error("[SERVICE] Service still hasn't stopped after 5 seconds, unknown reason");
                return (false, Languages.ServiceControllerManager_Error_Unknown);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SERVICE] Error while stopping: {err}", ex.Message);
                return (false, Languages.ServiceControllerManager_Error_Fatal);
            }
        }

        /// <summary>
        /// Returns the current startmode. Returns disabled on 'not found' and 'unknown'.
        /// </summary>
        /// <returns></returns>
        internal static ServiceStartMode GetServiceStartMode()
        {
            try
            {
                using var reg = Registry.LocalMachine.OpenSubKey(@$"SYSTEM\CurrentControlSet\Services\{Variables.SatelliteServiceName}", false);
                if (reg == null) return ServiceStartMode.Disabled;

                // get start mode
                var startModeValue = Convert.ToInt32(reg.GetValue("Start", -1));

                // get delayed-start setting
                var delayedAutoStartValue = Convert.ToInt32(reg.GetValue("DelayedAutoStart", 0));
                if (startModeValue == -1) return ServiceStartMode.Disabled;

                // return mode
                return (ServiceStartMode)Enum.Parse(typeof(ServiceStartMode), (startModeValue - delayedAutoStartValue).ToString());
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SERVICE] Error while checking startmode: {err}", ex.Message);
                return ServiceStartMode.Disabled;
            }
        }

        /// <summary>
        /// Changes the startmode for the provided service
        /// </summary>
        /// <param name="startupMode"></param>
        /// <returns></returns>
        internal static bool SetServiceStartMode(ServiceStartMode startupMode)
        {
            try
            {
                if (!ServiceExists()) return false;

                // get the service controller
                using var svc = new ServiceController(Variables.SatelliteServiceName);

                // set the new startmode
                var success = ServiceHelper.ChangeStartMode(svc, startupMode, out var error);
                if (!success)
                {
                    Log.Error("[SERVICE] Error while changing startup mode: {err}", error);
                    return false;
                }

                // all good
                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SERVICE] Error while setting startmode: {err}", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Attempts to install the service
        /// </summary>
        /// <returns></returns>
        internal static async Task<bool> InstallServiceAsync()
        {
            try
            {
                if (ServiceExists()) return true;

                if (string.IsNullOrEmpty(Variables.SatelliteServiceBinary))
                {
                    Log.Error("[SERVICE] Unable to install, binary location unknown");
                    return false;
                }

                if (!File.Exists(Variables.SatelliteServiceBinary))
                {
                    Log.Error("[SERVICE] Unable to install, binary location known but file not found");
                    return false;
                }

                // try to install
                var result = await CommandLineManager.ExecuteCommandAsync("sc.exe", $"create \"{Variables.SatelliteServiceName}\" binpath= \"{Variables.SatelliteServiceBinary}\"");
                if (!result.Error)
                {
                    // all good
                    Log.Information("[SERVICE] Succesfully installed: {binary}", Variables.SatelliteServiceBinary);
                    return true;
                }

                if (result.ExitCode == 5) Log.Error("[SERVICE] Installation failed, access denied - restart elevated");
                else
                {
                    var errMsg = string.IsNullOrEmpty(result.ErrorOutput) ? result.Output : result.ErrorOutput;
                    Log.Error("[SERVICE] Installation returned an error (code {code}):\r\n{err}", result.ExitCode, errMsg);
                }

                // failed
                return false;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SERVICE] Error while installing: {err}", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Attempts to uninstall the service
        /// </summary>
        /// <returns></returns>
        internal static async Task<bool> UninstallServiceAsync()
        {
            try
            {
                if (!ServiceExists()) return true;
                
                // try to uninstall
                var result = await CommandLineManager.ExecuteCommandAsync("sc.exe", $"delete \"{Variables.SatelliteServiceName}\"");
                if (!result.Error)
                {
                    // all good
                    Log.Information("[SERVICE] Succesfully uninstalled: {binary}", Variables.SatelliteServiceBinary);
                    return true;
                }

                if (result.ExitCode == 5) Log.Error("[SERVICE] Uninstallation failed, access denied - restart elevated");
                else
                {
                    var errMsg = string.IsNullOrEmpty(result.ErrorOutput) ? result.Output : result.ErrorOutput;
                    Log.Error("[SERVICE] Uninstallation returned an error (code {code}):\r\n{err}", result.ExitCode, errMsg);
                }

                // failed
                return false;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SERVICE] Error while uninstalling: {err}", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Configures the auto-restart and auto-startup settings of the service
        /// </summary>
        /// <returns></returns>
        internal static async Task<bool> ConfigureServiceAsync()
        {
            try
            {
                if (!ServiceExists())
                {
                    Log.Error("[SERVICE] Unable to configure, service not found");
                    return false;
                }

                // configure auto-restart settings
                var result = await CommandLineManager.ExecuteCommandAsync("sc.exe", $"failure \"{Variables.SatelliteServiceName}\" reset= 86400 actions= restart/60000/restart/60000//1000");
                if (result.Error)
                {
                    if (result.ExitCode == 5) Log.Error("[SERVICE] Configuration phase one failed, access denied - restart elevated");
                    else
                    {
                        var errMsg = string.IsNullOrEmpty(result.ErrorOutput) ? result.Output : result.ErrorOutput;
                        Log.Error("[SERVICE] Configuration phase one returned an error (code {code}):\r\n{err}", result.ExitCode, errMsg);
                    }

                    return false;
                }

                // configure automatic startup
                result = await CommandLineManager.ExecuteCommandAsync("sc.exe", $"config \"{Variables.SatelliteServiceName}\" start= auto");
                if (result.Error)
                {
                    if (result.ExitCode == 5) Log.Error("[SERVICE] Configuration phase two failed, access denied - restart elevated");
                    else
                    {
                        var errMsg = string.IsNullOrEmpty(result.ErrorOutput) ? result.Output : result.ErrorOutput;
                        Log.Error("[SERVICE] Configuration phase two returned an error (code {code}):\r\n{err}", result.ExitCode, errMsg);
                    }

                    return false;
                }

                // configure the descrption
                result = await CommandLineManager.ExecuteCommandAsync("sc.exe", $"description \"{Variables.SatelliteServiceName}\" \"Satellite service for HASS.Agent: a Windows based Home Assistant client. This service processes commands and sensors without the requirement of a logged-in user.\"");
                if (result.Error)
                {
                    if (result.ExitCode == 5) Log.Error("[SERVICE] Configuration phase three failed, access denied - restart elevated");
                    else
                    {
                        var errMsg = string.IsNullOrEmpty(result.ErrorOutput) ? result.Output : result.ErrorOutput;
                        Log.Error("[SERVICE] Configuration phase three returned an error (code {code}):\r\n{err}", result.ExitCode, errMsg);
                    }

                    return false;
                }

                // done
                Log.Information("[SERVICE] Succesfully configured");
                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SERVICE] Error while configuring: {err}", ex.Message);
                return false;
            }
        }
    }
}
