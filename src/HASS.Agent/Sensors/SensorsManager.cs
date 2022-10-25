using HASS.Agent.Extensions;
using HASS.Agent.Models.Internal;
using HASS.Agent.Resources.Localization;
using HASS.Agent.Settings;
using HASS.Agent.Shared.Enums;
using HASS.Agent.Shared.Extensions;
using HASS.Agent.Shared.Models.Config;
using Serilog;

namespace HASS.Agent.Sensors
{
    /// <summary>
    /// Continuously performs sensor autodiscovery and state publishing
    /// </summary>
    internal static class SensorsManager
    {
        internal static readonly Dictionary<SensorType, SensorInfoCard> SensorInfoCards = new();

        private static bool _active = true;
        private static bool _pause;

        private static DateTime _lastAutoDiscoPublish = DateTime.MinValue;

        /// <summary>
        /// Initializes the sensor manager
        /// </summary>
        internal static async void Initialize()
        {
            // is mqtt enabled?
            if (!Variables.AppSettings.MqttEnabled)
            {
                Variables.MainForm?.SetSensorsStatus(ComponentStatus.Stopped);
                return;
            }

            // wait while mqtt's connecting
            while (Variables.MqttManager.GetStatus() == MqttStatus.Connecting) await Task.Delay(250);

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
                    if (Variables.MqttManager.GetStatus() != MqttStatus.Connected)
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
                        await Variables.MqttManager.AnnounceAvailabilityAsync();

                        // publish the autodisco's
                        if (SingleValueSensorsPresent())
                        {
                            foreach (var sensor in Variables.SingleValueSensors.TakeWhile(_ => !_pause).TakeWhile(_ => _active))
                            {
                                if (_pause || Variables.MqttManager.GetStatus() != MqttStatus.Connected) continue;
                                await sensor.PublishAutoDiscoveryConfigAsync();
                            }
                        }

                        if (MultiValueSensorsPresent())
                        {
                            foreach (var sensor in Variables.MultiValueSensors.TakeWhile(_ => !_pause).TakeWhile(_ => _active))
                            {
                                if (_pause || Variables.MqttManager.GetStatus() != MqttStatus.Connected) continue;
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
                        foreach (var sensor in Variables.SingleValueSensors.TakeWhile(_ => !_pause).TakeWhile(_ => _active))
                        {
                            if (_pause || Variables.MqttManager.GetStatus() != MqttStatus.Connected) continue;
                            await sensor.PublishStateAsync(!firstRun);
                        }
                    }

                    // check if there are multivalue sensors
                    if (!MultiValueSensorsPresent()) continue;

                    foreach (var sensor in Variables.MultiValueSensors.TakeWhile(_ => !_pause).TakeWhile(_ => _active))
                    {
                        if (_pause || Variables.MqttManager.GetStatus() != MqttStatus.Connected) continue;
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
            toBeDeletedSensors ??= new List<ConfiguredSensor>();

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
                await Variables.MqttManager.AnnounceAvailabilityAsync();

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
        /// Returns default information for the specified sensor type, or null if not found
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        internal static SensorInfoCard GetSensorDefaultInfo(SensorType type) => SensorInfoCards.ContainsKey(type) ? SensorInfoCards[type] : null;

        /// <summary>
        /// Loads info regarding the various sensor types
        /// </summary>
        internal static void LoadSensorInfo()
        {
            // =================================

            var sensorInfoCard = new SensorInfoCard(SensorType.ActiveWindowSensor,
                Languages.SensorsManager_ActiveWindowSensorDescription,
                15, false, true, false);

            SensorInfoCards.Add(sensorInfoCard.SensorType, sensorInfoCard);

            // =================================

            sensorInfoCard = new SensorInfoCard(SensorType.AudioSensors,
                Languages.SensorsManager_AudioSensorsDescription,
                20, true, true, true);

            SensorInfoCards.Add(sensorInfoCard.SensorType, sensorInfoCard);

            // =================================

            sensorInfoCard = new SensorInfoCard(SensorType.BatterySensors,
                Languages.SensorsManager_BatterySensorsDescription,
                30, true, true, false);

            SensorInfoCards.Add(sensorInfoCard.SensorType, sensorInfoCard);

            // =================================

            sensorInfoCard = new SensorInfoCard(SensorType.BluetoothDevicesSensor,
                Languages.SensorsManager_BluetoothDevicesSensorDescription,
                30, false, true, false);

            SensorInfoCards.Add(sensorInfoCard.SensorType, sensorInfoCard);

            // =================================

            sensorInfoCard = new SensorInfoCard(SensorType.BluetoothLeDevicesSensor,
                Languages.SensorsManager_BluetoothLeDevicesSensorDescription,
                30, false, true, false);

            SensorInfoCards.Add(sensorInfoCard.SensorType, sensorInfoCard);

            // =================================

            sensorInfoCard = new SensorInfoCard(SensorType.CpuLoadSensor,
                Languages.SensorsManager_CpuLoadSensorDescription,
                30, false, true, true);

            SensorInfoCards.Add(sensorInfoCard.SensorType, sensorInfoCard);

            // =================================

            sensorInfoCard = new SensorInfoCard(SensorType.CurrentClockSpeedSensor,
                Languages.SensorsManager_CurrentClockSpeedSensorDescription,
                300, false, true, true);

            SensorInfoCards.Add(sensorInfoCard.SensorType, sensorInfoCard);

            // =================================

            sensorInfoCard = new SensorInfoCard(SensorType.CurrentVolumeSensor,
                Languages.SensorsManager_CurrentVolumeSensorDescription,
                15, false, true, true);

            SensorInfoCards.Add(sensorInfoCard.SensorType, sensorInfoCard);

            // =================================

            sensorInfoCard = new SensorInfoCard(SensorType.DisplaySensors,
                Languages.SensorsManager_DisplaySensorsDescription,
                15, true, true, false);

            SensorInfoCards.Add(sensorInfoCard.SensorType, sensorInfoCard);

            // =================================

            sensorInfoCard = new SensorInfoCard(SensorType.DummySensor,
                Languages.SensorsManager_DummySensorDescription,
                5, false, true, true);

            SensorInfoCards.Add(sensorInfoCard.SensorType, sensorInfoCard);

            // =================================

            sensorInfoCard = new SensorInfoCard(SensorType.GeoLocationSensor,
                Languages.SensorsManager_GeoLocationSensorDescription,
                30, false, true, false);

            SensorInfoCards.Add(sensorInfoCard.SensorType, sensorInfoCard);

            // =================================

            sensorInfoCard = new SensorInfoCard(SensorType.GpuLoadSensor,
                Languages.SensorsManager_GpuLoadSensorDescription,
                30, false, true, true);

            SensorInfoCards.Add(sensorInfoCard.SensorType, sensorInfoCard);

            // =================================

            sensorInfoCard = new SensorInfoCard(SensorType.GpuTemperatureSensor,
                Languages.SensorsManager_GpuTemperatureSensorDescription,
                30, false, true, true);

            SensorInfoCards.Add(sensorInfoCard.SensorType, sensorInfoCard);

            // =================================

            sensorInfoCard = new SensorInfoCard(SensorType.LastActiveSensor,
                Languages.SensorsManager_LastActiveSensorDescription,
                10, false, true, false);

            SensorInfoCards.Add(sensorInfoCard.SensorType, sensorInfoCard);

            // =================================

            sensorInfoCard = new SensorInfoCard(SensorType.LastBootSensor,
                Languages.SensorsManager_LastBootSensorDescription,
                10, false, true, true);

            SensorInfoCards.Add(sensorInfoCard.SensorType, sensorInfoCard);

            // =================================

            sensorInfoCard = new SensorInfoCard(SensorType.LastSystemStateChangeSensor,
                Languages.SensorsManager_LastSystemStateChangeSensorDescription,
                10, false, true, true);

            SensorInfoCards.Add(sensorInfoCard.SensorType, sensorInfoCard);

            // =================================

            sensorInfoCard = new SensorInfoCard(SensorType.LoggedUserSensor,
                Languages.SensorsManager_LoggedUserSensorDescription,
                10, false, true, true);

            SensorInfoCards.Add(sensorInfoCard.SensorType, sensorInfoCard);

            // =================================

            sensorInfoCard = new SensorInfoCard(SensorType.LoggedUsersSensor,
                Languages.SensorsManager_LoggedUsersSensorDescription,
                30, false, true, true);

            SensorInfoCards.Add(sensorInfoCard.SensorType, sensorInfoCard);

            // =================================

            sensorInfoCard = new SensorInfoCard(SensorType.MemoryUsageSensor,
                Languages.SensorsManager_MemoryUsageSensorDescription,
                30, false, true, true);

            SensorInfoCards.Add(sensorInfoCard.SensorType, sensorInfoCard);

            // =================================

            sensorInfoCard = new SensorInfoCard(SensorType.MicrophoneActiveSensor,
                Languages.SensorsManager_MicrophoneActiveSensorDescription,
                10, false, true, true);

            SensorInfoCards.Add(sensorInfoCard.SensorType, sensorInfoCard);

            // =================================

            sensorInfoCard = new SensorInfoCard(SensorType.MicrophoneProcessSensor,
                Languages.SensorsManager_MicrophoneProcessSensorDescription,
                10, false, true, true);

            SensorInfoCards.Add(sensorInfoCard.SensorType, sensorInfoCard);

            // =================================

            sensorInfoCard = new SensorInfoCard(SensorType.MonitorPowerStateSensor,
                Languages.SensorsManager_MonitorPowerStateSensorDescription,
                3, false, true, false);

            SensorInfoCards.Add(sensorInfoCard.SensorType, sensorInfoCard);

            // =================================

            sensorInfoCard = new SensorInfoCard(SensorType.NamedWindowSensor,
                Languages.SensorsManager_NamedWindowSensorDescription,
                30, false, true, false);

            SensorInfoCards.Add(sensorInfoCard.SensorType, sensorInfoCard);

            // =================================

            sensorInfoCard = new SensorInfoCard(SensorType.NetworkSensors,
                Languages.SensorsManager_NetworkSensorsDescription,
                30, true, true, true);

            SensorInfoCards.Add(sensorInfoCard.SensorType, sensorInfoCard);

            // =================================

            sensorInfoCard = new SensorInfoCard(SensorType.PerformanceCounterSensor,
                Languages.SensorsManager_PerformanceCounterSensorDescription,
                30, false, true, true);

            SensorInfoCards.Add(sensorInfoCard.SensorType, sensorInfoCard);

            // =================================

            sensorInfoCard = new SensorInfoCard(SensorType.PowershellSensor,
                Languages.SensorsManager_PowershellSensorDescription,
                30, false, true, true);

            SensorInfoCards.Add(sensorInfoCard.SensorType, sensorInfoCard);

            // =================================

            sensorInfoCard = new SensorInfoCard(SensorType.PrintersSensors,
                Languages.SensorsManager_PrintersSensorsDescription,
                5, true, true, false);

            SensorInfoCards.Add(sensorInfoCard.SensorType, sensorInfoCard);

            // =================================

            sensorInfoCard = new SensorInfoCard(SensorType.ProcessActiveSensor,
                Languages.SensorsManager_ProcessActiveSensorDescription,
                10, false, true, true);

            SensorInfoCards.Add(sensorInfoCard.SensorType, sensorInfoCard);

            // =================================

            sensorInfoCard = new SensorInfoCard(SensorType.ServiceStateSensor,
                Languages.SensorsManager_ServiceStateSensorDescription,
                10, false, true, true);

            SensorInfoCards.Add(sensorInfoCard.SensorType, sensorInfoCard);

            // =================================

            sensorInfoCard = new SensorInfoCard(SensorType.SessionStateSensor,
                Languages.SensorsManager_SessionStateSensorDescription,
                10, false, true, false);

            SensorInfoCards.Add(sensorInfoCard.SensorType, sensorInfoCard);

            // =================================

            sensorInfoCard = new SensorInfoCard(SensorType.StorageSensors,
                Languages.SensorsManager_StorageSensorsDescription,
                30, true, true, true);

            SensorInfoCards.Add(sensorInfoCard.SensorType, sensorInfoCard);

            // =================================

            sensorInfoCard = new SensorInfoCard(SensorType.UserNotificationStateSensor,
                Languages.SensorsManager_UserNotificationStateSensorDescription,
                10, false, true, false);

            SensorInfoCards.Add(sensorInfoCard.SensorType, sensorInfoCard);

            // =================================

            sensorInfoCard = new SensorInfoCard(SensorType.WebcamActiveSensor,
                Languages.SensorsManager_WebcamActiveSensorDescription,
                10, false, true, true);

            SensorInfoCards.Add(sensorInfoCard.SensorType, sensorInfoCard);

            // =================================

            sensorInfoCard = new SensorInfoCard(SensorType.WebcamProcessSensor,
                Languages.SensorsManager_WebcamProcessSensorDescription,
                10, false, true, true);

            SensorInfoCards.Add(sensorInfoCard.SensorType, sensorInfoCard);

            // =================================

            sensorInfoCard = new SensorInfoCard(SensorType.WindowStateSensor,
                Languages.SensorsManager_WindowStateSensorDescription,
                10, false, true, false);

            SensorInfoCards.Add(sensorInfoCard.SensorType, sensorInfoCard);

            // =================================

            sensorInfoCard = new SensorInfoCard(SensorType.WindowsUpdatesSensors,
                Languages.SensorsManager_WindowsUpdatesSensorsDescription,
                900, true, true, true);

            SensorInfoCards.Add(sensorInfoCard.SensorType, sensorInfoCard);

            // =================================

            sensorInfoCard = new SensorInfoCard(SensorType.WmiQuerySensor,
                Languages.SensorsManager_WmiQuerySensorDescription,
                10, false, true, true);

            SensorInfoCards.Add(sensorInfoCard.SensorType, sensorInfoCard);

            // =================================
        }
    }
}
