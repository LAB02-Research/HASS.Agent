using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HASSAgent.Enums;
using HASSAgent.Models.Config;
using HASSAgent.Models.Mqtt.Sensors;
using HASSAgent.Models.Mqtt.Sensors.GeneralSensors;
using HASSAgent.Models.Mqtt.Sensors.WmiSensors;
using Newtonsoft.Json;
using Serilog;

namespace HASSAgent.Settings
{
    /// <summary>
    /// Handles loading and storing sensors
    /// </summary>
    internal static class StoredSensors
    {
        /// <summary>
        /// Load all stored sensors
        /// </summary>
        /// <returns></returns>
        internal static bool Load()
        {
            try
            {
                // add an empty list
                Variables.Sensors = new List<AbstractSensor>();

                // check for existing file
                if (!File.Exists(Variables.SensorsFile))
                {
                    // none yet
                    Log.Information("[SETTINGS_SENSORS] Config not found, no entities loaded");
                    Variables.FrmM?.SetSensorsStatus(ComponentStatus.Stopped);
                    return true;
                }

                // read the content
                var sensorsRaw = File.ReadAllText(Variables.SensorsFile);
                if (string.IsNullOrWhiteSpace(sensorsRaw))
                {
                    Log.Information("[SETTINGS_SENSORS] Config is empty, no entities loaded");
                    Variables.FrmM?.SetSensorsStatus(ComponentStatus.Stopped);
                    return true;
                }

                // deserialize
                var configuredSensors = JsonConvert.DeserializeObject<List<ConfiguredSensor>>(sensorsRaw);

                // null-check
                if (configuredSensors == null)
                {
                    Log.Error("[SETTINGS_SENSORS] Error loading entities: returned null object");
                    Variables.FrmM?.SetSensorsStatus(ComponentStatus.Failed);
                    return false;
                }

                // convert to abstract sensors
                foreach (var abstractSensor in configuredSensors.Select(ConvertConfiguredToAbstract).Where(abstractSensor => abstractSensor != null))
                {
                    Variables.Sensors.Add(abstractSensor);
                }

                // all good
                Log.Information("[SETTINGS_SENSORS] Loaded {count} entities", Variables.Sensors.Count);
                Variables.FrmM?.SetSensorsStatus(ComponentStatus.Ok);
                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SETTINGS_SENSORS] Error loading entities: {err}", ex.Message);
                Variables.FrmM?.ShowMessageBox($"Error loading sensors:\r\n\r\n{ex.Message}", true);

                Variables.FrmM?.SetSensorsStatus(ComponentStatus.Failed);
                return false;
            }
        }

        /// <summary>
        /// Convert a 'ConfiguredSensor' (local storage, UI) to an 'AbstractSensor' (MQTT)
        /// </summary>
        /// <param name="sensor"></param>
        /// <returns></returns>
        internal static AbstractSensor ConvertConfiguredToAbstract(ConfiguredSensor sensor)
        {
            AbstractSensor abstractSensor = null;

            switch (sensor.Type)
            {
                case SensorType.UserNotificationStateSensor:
                    abstractSensor = new UserNotificationStateSensor(sensor.UpdateInterval, sensor.Name, sensor.Id);
                    break;
                case SensorType.DummySensor:
                    abstractSensor = new DummySensor(sensor.UpdateInterval, sensor.Name, sensor.Id);
                    break;
                case SensorType.CurrentClockSpeedSensor:
                    abstractSensor = new CurrentClockSpeedSensor(sensor.UpdateInterval, sensor.Name, sensor.Id);
                    break;
                case SensorType.CpuLoadSensor:
                    abstractSensor = new CpuLoadSensor(sensor.UpdateInterval, sensor.Name, sensor.Id);
                    break;
                case SensorType.MemoryUsageSensor:
                    abstractSensor = new MemoryUsageSensor(sensor.UpdateInterval, sensor.Name, sensor.Id);
                    break;
                case SensorType.ActiveWindowSensor:
                    abstractSensor = new ActiveWindowSensor(sensor.UpdateInterval, sensor.Name, sensor.Id);
                    break;
                case SensorType.NamedWindowSensor:
                    abstractSensor = new NamedWindowSensor(sensor.WindowName, sensor.Name, sensor.UpdateInterval, sensor.Id);
                    break;
                case SensorType.LastActiveSensor:
                    abstractSensor = new LastActiveSensor(sensor.UpdateInterval, sensor.Name, sensor.Id);
                    break;
                case SensorType.LastBootSensor:
                    abstractSensor = new LastBootSensor(sensor.UpdateInterval, sensor.Name, sensor.Id);
                    break;
                case SensorType.WebcamActiveSensor:
                    abstractSensor = new WebcamActiveSensor(sensor.UpdateInterval, sensor.Name, sensor.Id);
                    break;
                case SensorType.MicrophoneActiveSensor:
                    abstractSensor = new MicrophoneActiveSensor(sensor.UpdateInterval, sensor.Name, sensor.Id);
                    break;
                case SensorType.SessionStateSensor:
                    abstractSensor = new SessionStateSensor(sensor.UpdateInterval, sensor.Name, sensor.Id);
                    break;
                case SensorType.CurrentVolumeSensor:
                    abstractSensor = new CurrentVolumeSensor(sensor.UpdateInterval, sensor.Name, sensor.Id);
                    break;
                case SensorType.GpuLoadSensor:
                    abstractSensor = new GpuLoadSensor(sensor.UpdateInterval, sensor.Name, sensor.Id);
                    break;
                case SensorType.WmiQuerySensor:
                    abstractSensor = new WmiQuerySensor(sensor.Query, sensor.UpdateInterval, sensor.Name, sensor.Id);
                    break;
                default:
                    Log.Error("[SETTINGS_SENSORS] [{name}] Unknown configured sensor type: {type}", sensor.Name, sensor.Type.ToString());
                    break;
            }

            return abstractSensor;
        }

        /// <summary>
        /// Convert an 'AbstractSensor' (MQTT) to an 'ConfiguredSensor' (local storage, UI)
        /// </summary>
        /// <param name="sensor"></param>
        /// <returns></returns>
        internal static ConfiguredSensor ConvertAbstractToConfigured(AbstractSensor sensor)
        {
            switch (sensor)
            {
                case WmiQuerySensor wmiSensor:
                {
                    _ = Enum.TryParse<SensorType>(wmiSensor.GetType().Name, out var type);
                    return new ConfiguredSensor
                    {
                        Id = wmiSensor.Id, 
                        Name = wmiSensor.Name, 
                        Type = type,
                        UpdateInterval = wmiSensor.UpdateIntervalSeconds, 
                        Query = wmiSensor.Query
                    };
                }

                case NamedWindowSensor namedWindowSensor:
                {
                    _ = Enum.TryParse<SensorType>(namedWindowSensor.GetType().Name, out var type);
                    return new ConfiguredSensor
                    {
                        Id = namedWindowSensor.Id, 
                        Name = namedWindowSensor.Name, 
                        Type = type,
                        UpdateInterval = namedWindowSensor.UpdateIntervalSeconds,
                        WindowName = namedWindowSensor.WindowName
                    };
                }

                default:
                {
                    _ = Enum.TryParse<SensorType>(sensor.GetType().Name, out var type);
                    return new ConfiguredSensor
                    {
                        Id = sensor.Id, 
                        Name = sensor.Name, 
                        Type = type, 
                        UpdateInterval = sensor.UpdateIntervalSeconds
                    };
                }
            }
        }

        /// <summary>
        /// Store all current sensors
        /// </summary>
        /// <returns></returns>
        internal static bool Store()
        {
            try
            {
                // convert sensors
                var configuredSensors = Variables.Sensors.Select(ConvertAbstractToConfigured).Where(configuredSensor => configuredSensor != null).ToList();

                // serialize to file
                var sensors = JsonConvert.SerializeObject(configuredSensors, Formatting.Indented);
                File.WriteAllText(Variables.SensorsFile, sensors);

                // done
                Log.Information("[SETTINGS_SENSORS] Stored {count} entities", Variables.Sensors.Count);
                Variables.FrmM?.SetSensorsStatus(ComponentStatus.Ok);
                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SETTINGS_SENSORS] Error storing entities: {err}", ex.Message);
                Variables.FrmM?.ShowMessageBox($"Error storing sensors:\r\n\r\n{ex.Message}", true);

                Variables.FrmM?.SetSensorsStatus(ComponentStatus.Failed);
                return false;
            }
        }
    }
}
