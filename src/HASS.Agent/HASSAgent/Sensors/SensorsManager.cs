using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HASSAgent.Enums;
using HASSAgent.Models.Config;
using HASSAgent.Mqtt;
using HASSAgent.Settings;
using Serilog;

namespace HASSAgent.Sensors
{
    /// <summary>
    /// Continuously performs sensor autodiscovery and state publishing
    /// </summary>
    internal static class SensorsManager
    {
        private static readonly Dictionary<SensorType, (string description, int interval)> SensorInfo = new Dictionary<SensorType, (string description, int interval)>();

        private static bool _active = true;
        private static bool _pause;

        private static DateTime _lastAutoDiscoPublish = DateTime.MinValue;

        /// <summary>
        /// Initializes the sensor manager
        /// </summary>
        internal static async void Initialize()
        {
            // load sensor descriptions
            LoadSensorInfo();

            // wait while mqtt's connecting
            while (MqttManager.GetStatus() == MqttStatus.Connecting) await Task.Delay(250);

            // start background processing
            _ = Task.Run(Process);
        }

        /// <summary>
        /// Stop processing sensor states
        /// </summary>
        internal static void Stop() => _active = false;

        /// <summary>
        /// Pause processing sensor states
        /// </summary>
        internal static void Pause() => _pause = true;

        /// <summary>
        /// Resume processing sensor states
        /// </summary>
        internal static void Unpause() => _pause = false;

        /// <summary>
        /// Unpublishes all single- and multivalue sensors
        /// </summary>
        /// <returns></returns>
        internal static async Task UnpublishAllSensors()
        {
            // unpublish the autodisco's
            if (SingleValueSensorsPresent()) foreach (var sensor in Variables.SingleValueSensors) await sensor.UnPublishAutoDiscoveryConfigAsync();
            if (MultiValueSensorsPresent()) foreach (var sensor in Variables.MultiValueSensors) await sensor.UnPublishAutoDiscoveryConfigAsync();
        }

        /// <summary>
        /// Continously processes sensors (autodiscovery, states)
        /// </summary>
        private static async void Process()
        {
            // we use the firstrun flag to publish our state without respecting the time elapsed/value change check
            // otherwise, the state might stay in 'unknown' in HA until the value changes
            var firstRun = true;
            var firstRunDone = false;

            while (_active)
            {
                try
                {
                    await Task.Delay(TimeSpan.FromMilliseconds(750));

                    // are we paused?
                    if (_pause) continue;

                    // is mqtt available?
                    if (MqttManager.GetStatus() != MqttStatus.Connected)
                    {
                        // nothing to do
                        continue;
                    }

                    // optionally flag as the first real run
                    if (!firstRunDone) firstRunDone = true;

                    // publish availability & sensor autodisco's every 30 sec
                    if ((DateTime.Now - _lastAutoDiscoPublish).TotalSeconds > 30)
                    {
                        // let hass know we're still here
                        await MqttManager.AnnounceAvailabilityAsync();

                        // publish the autodisco's
                        if (SingleValueSensorsPresent())
                        {
                            foreach (var sensor in Variables.SingleValueSensors.TakeWhile(sensor => !_pause).TakeWhile(command => _active))
                            {
                                if (_pause || MqttManager.GetStatus() != MqttStatus.Connected) continue;
                                await sensor.PublishAutoDiscoveryConfigAsync();
                            }
                        }

                        if (MultiValueSensorsPresent())
                        {
                            foreach (var sensor in Variables.MultiValueSensors.TakeWhile(sensor => !_pause).TakeWhile(command => _active))
                            {
                                if (_pause || MqttManager.GetStatus() != MqttStatus.Connected) continue;
                                await sensor.PublishAutoDiscoveryConfigAsync();
                            }
                        }

                        // log moment
                        _lastAutoDiscoPublish = DateTime.Now;
                    }

                    if (_pause) continue;

                    // publish sensor states (they have their own time-based scheduling)
                    if (SingleValueSensorsPresent())
                    {
                        foreach (var sensor in Variables.SingleValueSensors.TakeWhile(sensor => !_pause).TakeWhile(command => _active))
                        {
                            if (_pause || MqttManager.GetStatus() != MqttStatus.Connected) continue;
                            await sensor.PublishStateAsync(!firstRun);
                        }
                    }

                    // check if there are multivalue sensors
                    if (!MultiValueSensorsPresent()) continue;

                    foreach (var sensor in Variables.MultiValueSensors.TakeWhile(sensor => !_pause).TakeWhile(command => _active))
                    {
                        if (_pause || MqttManager.GetStatus() != MqttStatus.Connected) continue;
                        await sensor.PublishStatesAsync(!firstRun);
                    }
                }
                catch (Exception ex)
                {
                    Log.Fatal(ex, "[SENSORSMANAGER] Error while publishing: {err}", ex.Message);
                }
                finally
                {
                    // check if we need to take down the 'first run' flag
                    if (firstRunDone && firstRun) firstRun = false;
                }
            }
        }

        /// <summary>
        /// Resets all sensor checks (last sent and previous value), so they'll all be published again
        /// </summary>
        internal static void ResetAllSensorChecks()
        {
            try
            {
                // pause processing
                Pause();

                // reset single-value sensors
                if (SingleValueSensorsPresent())
                {
                    foreach (var sensor in Variables.SingleValueSensors) sensor.ResetChecks();
                }

                // reset multi-value sensors
                if (MultiValueSensorsPresent())
                {
                    foreach (var sensor in Variables.MultiValueSensors) sensor.ResetChecks();
                }

                // done
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SENSORSMANAGER] Error while resetting all sensor checks: {err}", ex.Message);
            }
            finally
            {
                // resume processing
                Unpause();
            }
        }

        /// <summary>
        /// Stores the provided sensors, and (re)publishes them
        /// </summary>
        /// <param name="sensors"></param>
        /// <param name="toBeDeletedSensors"></param>
        /// <returns></returns>
        internal static async Task<bool> StoreAsync(List<ConfiguredSensor> sensors, List<ConfiguredSensor> toBeDeletedSensors = null)
        {
            if (toBeDeletedSensors == null) toBeDeletedSensors = new List<ConfiguredSensor>();

            try
            {
                // pause processing
                Pause();

                // process the to-be-removed
                if (toBeDeletedSensors.Any())
                {
                    foreach (var sensor in toBeDeletedSensors.Where(sensor => sensor != null))
                    {
                        if (sensor.IsSingleValue())
                        {
                            var abstractSensor = StoredSensors.ConvertConfiguredToAbstractSingleValue(sensor);

                            // remove and unregister
                            await abstractSensor.UnPublishAutoDiscoveryConfigAsync();
                            Variables.SingleValueSensors.RemoveAt(Variables.SingleValueSensors.FindIndex(x => x.Id == abstractSensor.Id));

                            Log.Information("[SENSORS] Removed single-value sensor: {sensor}", abstractSensor.Name);
                        }
                        else
                        {
                            var abstractSensor = StoredSensors.ConvertConfiguredToAbstractMultiValue(sensor);

                            // remove and unregister
                            await abstractSensor.UnPublishAutoDiscoveryConfigAsync();
                            Variables.MultiValueSensors.RemoveAt(Variables.MultiValueSensors.FindIndex(x => x.Id == abstractSensor.Id));

                            Log.Information("[SENSORS] Removed multi-value sensor: {sensor}", abstractSensor.Name);
                        }
                    }
                }

                // copy our list to the main one
                foreach (var sensor in sensors.Where(sensor => sensor != null))
                {
                    if (sensor.IsSingleValue())
                    {
                        var abstractSensor = StoredSensors.ConvertConfiguredToAbstractSingleValue(sensor);
                        if (Variables.SingleValueSensors.All(x => x.Id != abstractSensor.Id))
                        {
                            // new, add and register
                            Variables.SingleValueSensors.Add(abstractSensor);
                            await abstractSensor.PublishAutoDiscoveryConfigAsync();
                            await abstractSensor.PublishStateAsync(false);

                            Log.Information("[SENSORS] Added single-value sensor: {sensor}", abstractSensor.Name);
                            continue;
                        }

                        // existing, update and re-register
                        var currentSensorIndex = Variables.SingleValueSensors.FindIndex(x => x.Id == abstractSensor.Id);
                        if (Variables.SingleValueSensors[currentSensorIndex].Name != abstractSensor.Name)
                        {
                            // name changed, unregister
                            Log.Information("[SENSORS] Single-value sensor changed name, re-registering as new entity: {old} to {new}", Variables.SingleValueSensors[currentSensorIndex].Name, abstractSensor.Name);

                            await Variables.SingleValueSensors[currentSensorIndex].UnPublishAutoDiscoveryConfigAsync();
                        }

                        Variables.SingleValueSensors[currentSensorIndex] = abstractSensor;
                        await abstractSensor.PublishAutoDiscoveryConfigAsync();
                        await abstractSensor.PublishStateAsync(false);

                        Log.Information("[SENSORS] Modified single-value sensor: {sensor}", abstractSensor.Name);
                    }
                    else
                    {
                        var abstractSensor = StoredSensors.ConvertConfiguredToAbstractMultiValue(sensor);
                        if (Variables.MultiValueSensors.All(x => x.Id != abstractSensor.Id))
                        {
                            // new, add and register
                            Variables.MultiValueSensors.Add(abstractSensor);
                            await abstractSensor.PublishAutoDiscoveryConfigAsync();
                            await abstractSensor.PublishStatesAsync(false);

                            Log.Information("[SENSORS] Added multi-value sensor: {sensor}", abstractSensor.Name);
                            continue;
                        }

                        // existing, update and re-register
                        var currentSensorIndex = Variables.MultiValueSensors.FindIndex(x => x.Id == abstractSensor.Id);
                        if (Variables.MultiValueSensors[currentSensorIndex].Name != abstractSensor.Name)
                        {
                            // name changed, unregister
                            Log.Information("[SENSORS] Multi-value sensor changed name, re-registering as new entity: {old} to {new}", Variables.MultiValueSensors[currentSensorIndex].Name, abstractSensor.Name);

                            await Variables.MultiValueSensors[currentSensorIndex].UnPublishAutoDiscoveryConfigAsync();
                        }

                        Variables.MultiValueSensors[currentSensorIndex] = abstractSensor;
                        await abstractSensor.PublishAutoDiscoveryConfigAsync();
                        await abstractSensor.PublishStatesAsync(false);

                        Log.Information("[SENSORS] Modified multi-value sensor: {sensor}", abstractSensor.Name);
                    }
                }

                // annouce ourselves
                await MqttManager.AnnounceAvailabilityAsync();

                // store to file
                StoredSensors.Store();

                // done
                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SENSORSMANAGER] Error while storing: {err}", ex.Message);
                return false;
            }
            finally
            {
                // resume processing
                Unpause();
            }
        }

        private static bool SingleValueSensorsPresent() => Variables.SingleValueSensors != null && Variables.SingleValueSensors.Any();
        private static bool MultiValueSensorsPresent() => Variables.MultiValueSensors != null && Variables.MultiValueSensors.Any();

        /// <summary>
        /// Returns default information for the specified sensor type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        internal static (string name, int interval) GetSensorDefaultInfo(SensorType type)
        {
            return !SensorInfo.ContainsKey(type) ? ("Unknown sensor, make sure HASS.Agent has finished booting up", 0) : SensorInfo[type];
        }

        /// <summary>
        /// Loads info regarding the various sensor types
        /// </summary>
        private static void LoadSensorInfo()
        {
            SensorInfo.Add(SensorType.UserNotificationStateSensor, ("Provides the current user state:\r\n\r\nNotPresent, Busy, RunningDirect3dFullScreen, PresentationMode, AcceptsNotifications, QuietTime or RunningWindowsStoreApp.\r\n\r\nCan for instance be used to determine whether to send notifications or TTS messages.", 10));
            SensorInfo.Add(SensorType.DummySensor, ("Dummy sensor for testing purposes, sends a random integer value between 0 and 100.", 5));
            SensorInfo.Add(SensorType.CurrentClockSpeedSensor, ("Provides the current clockspeed of the first CPU.", 300));
            SensorInfo.Add(SensorType.CpuLoadSensor, ("Provides the current load of the first CPU as a percentage.", 30));
            SensorInfo.Add(SensorType.MemoryUsageSensor, ("Provides the amount of used memory as a percentage.", 30));
            SensorInfo.Add(SensorType.ActiveWindowSensor, ("Provides the title of the current active window.", 15));
            SensorInfo.Add(SensorType.NamedWindowSensor, ("Provides an ON/OFF value based on whether the window is currently open (doesn't have to be active).", 30));
            SensorInfo.Add(SensorType.LastActiveSensor, ("Provides a datetime value containing the last moment the user provided any input.", 10));
            SensorInfo.Add(SensorType.LastSystemStateChangeSensor, ("Provides the last system state change:\r\n\r\nHassAgentStarted, Logoff, SystemShutdown, Resume, Suspend, ConsoleConnect, ConsoleDisconnect, RemoteConnect, RemoteDisconnect, SessionLock, SessionLogoff, SessionLogon, SessionRemoteControl and SessionUnlock.", 10));
            SensorInfo.Add(SensorType.LastBootSensor, ("Provides a datetime value containing the last moment the system (re)booted.\r\n\r\nImportant: Windows' FastBoot option can throw this value off, because that's a form of hibernation. You can disable it through Power Options -> 'Choose what the power buttons do' -> uncheck 'Turn on fast start-up'. It doesn't make much difference for modern machines with SSDs, but disabling makes sure you get a clean state after rebooting.", 10));
            SensorInfo.Add(SensorType.WebcamActiveSensor, ("Provides a bool value based on whether the webcam is currently being used.", 10));
            SensorInfo.Add(SensorType.MicrophoneActiveSensor, ("Provides a bool value based on whether the microphone is currently being used.", 10));
            SensorInfo.Add(SensorType.SessionStateSensor, ("Provides the current session state:\r\n\r\nLocked, Unlocked or Unknown.\r\n\r\nUse a LastSystemStateChangeSensor to monitor session state changes.", 10));
            SensorInfo.Add(SensorType.CurrentVolumeSensor, ("Provides the current volume level as a percentage.\r\n\r\nCurrently takes the volume of your default device.", 15));
            SensorInfo.Add(SensorType.GpuLoadSensor, ("Provides the current load of the first GPU as a percentage.", 30));
            SensorInfo.Add(SensorType.GpuTemperatureSensor, ("Provides the current temperature of the first GPU.", 30));
            SensorInfo.Add(SensorType.WmiQuerySensor, ("Provides the result of the provided WMI query.", 10));
            SensorInfo.Add(SensorType.StorageSensors, ("Provides the labels, total size (MB), available space (MB), used space (MB) and file system of all present non-removable disks.\r\n\r\nThis is a multi-value sensor.", 30));
            SensorInfo.Add(SensorType.NetworkSensors, ("Provides card info, configuration, transfer- & package statistics and addresses (ip, mac, dhcp, dns) of all present network cards.\r\n\r\nThis is a multi-value sensor.", 30));
            SensorInfo.Add(SensorType.PerformanceCounterSensor, ("Provides the values of a performance counter.\r\n\r\nFor example, the built-in CPU load sensor uses these values:\r\n\r\nCategory: Processor\r\nCounter: % Processor Time\r\nInstance: _Total\r\n\r\nYou can explore the counters through Windows' 'perfmon.exe' tool.", 30));

            //SensorInfo.Add(SensorType.WindowsUpdatesSensors, ("Provides a sensor with the amount of pending driver updates, a sensor with the amount of pending software updates, a sensor containing all pending driver updates information (title, kb article id's, hidden, type and categories) and a sensor containing the same for pending software updates.\r\n\r\nThis is a costly request, so the recommended interval is 15 minutes (900 seconds). But it's capped at 10 minutes, if you provide a lower value, you'll get the last known list.\r\n\r\nThis is a multi-value sensor.", 900));
            SensorInfo.Add(SensorType.WindowsUpdatesSensors, ("Provides a sensor with the amount of pending driver updates and a sensor with the amount of pending software updates.\r\n\r\nThis is a costly request, so the recommended interval is 15 minutes (900 seconds). But it's capped at 10 minutes, if you provide a lower value, you'll get the last known list.\r\n\r\nThis is a multi-value sensor.", 900));

            SensorInfo.Add(SensorType.BatterySensors, ("Provides a sensor with the current charging status, estimated amount of minutes on a full charge, remaining charge in percentage, remaining charge in minutes and the powerline status.\r\n\r\nThis is a multi-value sensor.", 30));
            SensorInfo.Add(SensorType.DisplaySensors, ("Provides a sensor with the amount of displays, name of the primary display, and per display its name, resolution and bits per pixel.\r\n\r\nThis is a multi-value sensor.", 15));
            SensorInfo.Add(SensorType.AudioSensors, ("Provides information various aspects of your device's audio:\r\n\r\nCurrent peak volume level (can be used as a simple 'is something playing' value).\r\n\r\nDefault audiodevice: name, state and volume.\r\n\r\nSummary of your audio sessions: application name, muted state, volume and current peak volume.\r\n\r\nThis is a multi-value sensor.", 20));
            SensorInfo.Add(SensorType.ProcessActiveSensor, ("Provides the number of active instances of the process.", 10));
            SensorInfo.Add(SensorType.ServiceStateSensor, ("Returns the state of the provided service: NotFound, Stopped, StartPending, StopPending, Running, ContinuePending, PausePending or Paused.\r\n\r\nMake sure to provide the 'Service name', not the 'Display name'.", 10));
            SensorInfo.Add(SensorType.LoggedUsersSensor, ("Returns a json-formatted list of currently logged users.", 30));
            SensorInfo.Add(SensorType.LoggedUserSensor, ("Returns the name of the currently logged user.", 30));
        }
    }
}
