using HASS.Agent.Enums;
using HASS.Agent.Extensions;
using HASS.Agent.Models.HomeAssistant.Sensors.GeneralSensors.SingleValue;
using HASS.Agent.Resources.Localization;
using HASS.Agent.Shared.Enums;
using HASS.Agent.Shared.Extensions;
using HASS.Agent.Shared.Models.Config;
using HASS.Agent.Shared.Models.HomeAssistant.Sensors;
using HASS.Agent.Shared.Models.HomeAssistant.Sensors.GeneralSensors.MultiValue;
using HASS.Agent.Shared.Models.HomeAssistant.Sensors.GeneralSensors.SingleValue;
using HASS.Agent.Shared.Models.HomeAssistant.Sensors.PerfCounterSensors.SingleValue;
using HASS.Agent.Shared.Models.HomeAssistant.Sensors.WmiSensors.SingleValue;
using Newtonsoft.Json;
using Serilog;

namespace HASS.Agent.Settings
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
        internal static async Task<bool> LoadAsync()
        {
            try
            {
                // set empty lists
                Variables.SingleValueSensors = new List<AbstractSingleValueSensor>();
                Variables.MultiValueSensors = new List<AbstractMultiValueSensor>();

                // check for existing file
                if (!File.Exists(Variables.SensorsFile))
                {
                    // none yet
                    Log.Information("[SETTINGS_SENSORS] Config not found, no entities loaded");
                    Variables.MainForm?.SetSensorsStatus(ComponentStatus.Stopped);
                    return true;
                }

                // read the content
                var sensorsRaw = await File.ReadAllTextAsync(Variables.SensorsFile);
                if (string.IsNullOrWhiteSpace(sensorsRaw))
                {
                    Log.Information("[SETTINGS_SENSORS] Config is empty, no entities loaded");
                    Variables.MainForm?.SetSensorsStatus(ComponentStatus.Stopped);
                    return true;
                }

                // deserialize
                var configuredSensors = JsonConvert.DeserializeObject<List<ConfiguredSensor>>(sensorsRaw);

                // null-check
                if (configuredSensors == null)
                {
                    Log.Error("[SETTINGS_SENSORS] Error loading entities: returned null object");
                    Variables.MainForm?.SetSensorsStatus(ComponentStatus.Failed);
                    return false;
                }

                // convert to abstract sensors
                await Task.Run(delegate
                {
                    foreach (var sensor in configuredSensors)
                    {
                        if (sensor.IsSingleValue()) Variables.SingleValueSensors.Add(ConvertConfiguredToAbstractSingleValue(sensor));
                        else Variables.MultiValueSensors.Add(ConvertConfiguredToAbstractMultiValue(sensor));
                    }
                });

                // all good
                Log.Information("[SETTINGS_SENSORS] Loaded {count} entities", (Variables.SingleValueSensors.Count + Variables.MultiValueSensors.Count));
                Variables.MainForm?.SetSensorsStatus(ComponentStatus.Ok);
                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SETTINGS_SENSORS] Error loading entities: {err}", ex.Message);
                Variables.MainForm?.ShowMessageBox(string.Format(Languages.StoredSensors_Load_MessageBox1, ex.Message), true);

                Variables.MainForm?.SetSensorsStatus(ComponentStatus.Failed);
                return false;
            }
        }
        
        /// <summary>
        /// Convert a single-value 'ConfiguredSensor' (local storage, UI) to an 'AbstractSensor' (MQTT)
        /// </summary>
        /// <param name="sensor"></param>
        /// <returns></returns>
        internal static AbstractSingleValueSensor ConvertConfiguredToAbstractSingleValue(ConfiguredSensor sensor)
        {
            AbstractSingleValueSensor abstractSensor = null;

            switch (sensor.Type)
            {
                case SensorType.UserNotificationStateSensor:
                    abstractSensor = new UserNotificationStateSensor(sensor.UpdateInterval, sensor.Name, sensor.Id.ToString());
                    break;
                case SensorType.DummySensor:
                    abstractSensor = new DummySensor(sensor.UpdateInterval, sensor.Name, sensor.Id.ToString());
                    break;
                case SensorType.CurrentClockSpeedSensor:
                    abstractSensor = new CurrentClockSpeedSensor(sensor.UpdateInterval, sensor.Name, sensor.Id.ToString());
                    break;
                case SensorType.CpuLoadSensor:
                    abstractSensor = new CpuLoadSensor(sensor.UpdateInterval, sensor.Name, sensor.Id.ToString());
                    break;
                case SensorType.MemoryUsageSensor:
                    abstractSensor = new MemoryUsageSensor(sensor.UpdateInterval, sensor.Name, sensor.Id.ToString());
                    break;
                case SensorType.ActiveWindowSensor:
                    abstractSensor = new ActiveWindowSensor(sensor.UpdateInterval, sensor.Name, sensor.Id.ToString());
                    break;
                case SensorType.NamedWindowSensor:
                    abstractSensor = new NamedWindowSensor(sensor.WindowName, sensor.Name, sensor.UpdateInterval, sensor.Id.ToString());
                    break;
                case SensorType.LastActiveSensor:
                    abstractSensor = new LastActiveSensor(sensor.UpdateInterval, sensor.Name, sensor.Id.ToString());
                    break;
                case SensorType.LastSystemStateChangeSensor:
                    abstractSensor = new LastSystemStateChangeSensor(sensor.UpdateInterval, sensor.Name, sensor.Id.ToString());
                    break;
                case SensorType.LastBootSensor:
                    abstractSensor = new LastBootSensor(sensor.UpdateInterval, sensor.Name, sensor.Id.ToString());
                    break;
                case SensorType.WebcamActiveSensor:
                    abstractSensor = new WebcamActiveSensor(sensor.UpdateInterval, sensor.Name, sensor.Id.ToString());
                    break;
                case SensorType.MicrophoneActiveSensor:
                    abstractSensor = new MicrophoneActiveSensor(sensor.UpdateInterval, sensor.Name, sensor.Id.ToString());
                    break;
                case SensorType.SessionStateSensor:
                    abstractSensor = new SessionStateSensor(sensor.UpdateInterval, sensor.Name, sensor.Id.ToString());
                    break;
                case SensorType.CurrentVolumeSensor:
                    abstractSensor = new CurrentVolumeSensor(sensor.UpdateInterval, sensor.Name, sensor.Id.ToString());
                    break;
                case SensorType.GpuLoadSensor:
                    abstractSensor = new GpuLoadSensor(sensor.UpdateInterval, sensor.Name, sensor.Id.ToString());
                    break;
                case SensorType.GpuTemperatureSensor:
                    abstractSensor = new GpuTemperatureSensor(sensor.UpdateInterval, sensor.Name, sensor.Id.ToString());
                    break;
                case SensorType.WmiQuerySensor:
                    abstractSensor = new WmiQuerySensor(sensor.Query, sensor.Scope, sensor.UpdateInterval, sensor.Name, sensor.Id.ToString());
                    break;
                case SensorType.PerformanceCounterSensor:
                    abstractSensor = new PerformanceCounterSensor(sensor.Category, sensor.Counter, sensor.Instance, sensor.UpdateInterval, sensor.Name, sensor.Id.ToString());
                    break;
                case SensorType.ProcessActiveSensor:
                    abstractSensor = new ProcessActiveSensor(sensor.Query, sensor.UpdateInterval, sensor.Name, sensor.Id.ToString());
                    break;
                case SensorType.ServiceStateSensor:
                    abstractSensor = new ServiceStateSensor(sensor.Query, sensor.UpdateInterval, sensor.Name, sensor.Id.ToString());
                    break;
                case SensorType.LoggedUsersSensor:
                    abstractSensor = new LoggedUsersSensor(sensor.UpdateInterval, sensor.Name, sensor.Id.ToString());
                    break;
                case SensorType.LoggedUserSensor:
                    abstractSensor = new LoggedUserSensor(sensor.UpdateInterval, sensor.Name, sensor.Id.ToString());
                    break;
                case SensorType.GeoLocationSensor:
                    abstractSensor = new GeoLocationSensor(sensor.UpdateInterval, sensor.Name, sensor.Id.ToString());
                    break;
                default:
                    Log.Error("[SETTINGS_SENSORS] [{name}] Unknown configured single-value sensor type: {type}", sensor.Name, sensor.Type.ToString());
                    break;
            }

            return abstractSensor;
        }

        /// <summary>
        /// Convert a multi-value 'ConfiguredSensor' (local storage, UI) to an 'AbstractSensor' (MQTT)
        /// </summary>
        /// <param name="sensor"></param>
        /// <returns></returns>
        internal static AbstractMultiValueSensor ConvertConfiguredToAbstractMultiValue(ConfiguredSensor sensor)
        {
            AbstractMultiValueSensor abstractSensor = null;

            switch (sensor.Type)
            {
                case SensorType.StorageSensors:
                    abstractSensor = new StorageSensors(sensor.UpdateInterval, sensor.Name, sensor.Id.ToString());
                    break;
                case SensorType.NetworkSensors:
                    abstractSensor = new NetworkSensors(sensor.UpdateInterval, sensor.Name, sensor.Query, sensor.Id.ToString());
                    break;
                case SensorType.WindowsUpdatesSensors:
                    abstractSensor = new WindowsUpdatesSensors(sensor.UpdateInterval, sensor.Name, sensor.Id.ToString());
                    break;
                case SensorType.BatterySensors:
                    abstractSensor = new BatterySensors(sensor.UpdateInterval, sensor.Name, sensor.Id.ToString());
                    break;
                case SensorType.DisplaySensors:
                    abstractSensor = new DisplaySensors(sensor.UpdateInterval, sensor.Name, sensor.Id.ToString());
                    break;
                case SensorType.AudioSensors:
                    abstractSensor = new AudioSensors(sensor.UpdateInterval, sensor.Name, sensor.Id.ToString());
                    break;
                default:
                    Log.Error("[SETTINGS_SENSORS] [{name}] Unknown configured multi-value sensor type: {type}", sensor.Name, sensor.Type.ToString());
                    break;
            }

            return abstractSensor;
        }

        /// <summary>
        /// Convert a single-value 'AbstractSensor' (MQTT) to an 'ConfiguredSensor' (local storage, UI)
        /// </summary>
        /// <param name="sensor"></param>
        /// <returns></returns>
        internal static ConfiguredSensor ConvertAbstractSingleValueToConfigured(AbstractSingleValueSensor sensor)
        {
            switch (sensor)
            {
                case WmiQuerySensor wmiSensor:
                {
                    _ = Enum.TryParse<SensorType>(wmiSensor.GetType().Name, out var type);
                    return new ConfiguredSensor
                    {
                        Id = Guid.Parse(wmiSensor.Id), 
                        Name = wmiSensor.Name, 
                        Type = type,
                        UpdateInterval = wmiSensor.UpdateIntervalSeconds,
                        Scope = wmiSensor.Scope,
                        Query = wmiSensor.Query
                    };
                }

                case NamedWindowSensor namedWindowSensor:
                {
                    _ = Enum.TryParse<SensorType>(namedWindowSensor.GetType().Name, out var type);
                    return new ConfiguredSensor
                    {
                        Id = Guid.Parse(namedWindowSensor.Id), 
                        Name = namedWindowSensor.Name, 
                        Type = type,
                        UpdateInterval = namedWindowSensor.UpdateIntervalSeconds,
                        WindowName = namedWindowSensor.WindowName
                    };
                }

                case PerformanceCounterSensor performanceCounterSensor:
                {
                    _ = Enum.TryParse<SensorType>(performanceCounterSensor.GetType().Name, out var type);
                    return new ConfiguredSensor
                    {
                        Id = Guid.Parse(performanceCounterSensor.Id),
                        Name = performanceCounterSensor.Name,
                        Type = type,
                        UpdateInterval = performanceCounterSensor.UpdateIntervalSeconds,
                        Category = performanceCounterSensor.CategoryName,
                        Counter = performanceCounterSensor.CounterName,
                        Instance = performanceCounterSensor.InstanceName
                    };
                }

                case ProcessActiveSensor processActiveSensor:
                {
                    _ = Enum.TryParse<SensorType>(processActiveSensor.GetType().Name, out var type);
                    return new ConfiguredSensor
                    {
                        Id = Guid.Parse(processActiveSensor.Id),
                        Name = processActiveSensor.Name,
                        Type = type,
                        UpdateInterval = processActiveSensor.UpdateIntervalSeconds,
                        Query = processActiveSensor.ProcessName
                    };
                }

                case ServiceStateSensor serviceStateSensor:
                {
                    _ = Enum.TryParse<SensorType>(serviceStateSensor.GetType().Name, out var type);
                    return new ConfiguredSensor
                    {
                        Id = Guid.Parse(serviceStateSensor.Id),
                        Name = serviceStateSensor.Name,
                        Type = type,
                        UpdateInterval = serviceStateSensor.UpdateIntervalSeconds,
                        Query = serviceStateSensor.ServiceName
                    };
                }

                default:
                {
                    _ = Enum.TryParse<SensorType>(sensor.GetType().Name, out var type);
                    return new ConfiguredSensor
                    {
                        Id = Guid.Parse(sensor.Id), 
                        Name = sensor.Name, 
                        Type = type, 
                        UpdateInterval = sensor.UpdateIntervalSeconds
                    };
                }
            }
        }

        /// <summary>
        /// Convert a multi-value 'AbstractSensor' (MQTT) to an 'ConfiguredSensor' (local storage, UI)
        /// </summary>
        /// <param name="sensor"></param>
        /// <returns></returns>
        internal static ConfiguredSensor ConvertAbstractMultiValueToConfigured(AbstractMultiValueSensor sensor)
        {
            switch (sensor)
            {
                case StorageSensors storageSensors:
                    {
                        _ = Enum.TryParse<SensorType>(storageSensors.GetType().Name, out var type);
                        return new ConfiguredSensor
                        {
                            Id = Guid.Parse(sensor.Id),
                            Name = sensor.Name,
                            Type = type,
                            UpdateInterval = sensor.UpdateIntervalSeconds
                        };
                    }
                case NetworkSensors networkSensors:
                {
                    _ = Enum.TryParse<SensorType>(networkSensors.GetType().Name, out var type);
                    return new ConfiguredSensor
                    {
                        Id = Guid.Parse(sensor.Id),
                        Name = sensor.Name,
                        Query = networkSensors.NetworkCard,
                        Type = type,
                        UpdateInterval = sensor.UpdateIntervalSeconds
                    };
                }
                case WindowsUpdatesSensors windowsUpdatesSensors:
                {
                    _ = Enum.TryParse<SensorType>(windowsUpdatesSensors.GetType().Name, out var type);
                    return new ConfiguredSensor
                    {
                        Id = Guid.Parse(sensor.Id),
                        Name = sensor.Name,
                        Type = type,
                        UpdateInterval = sensor.UpdateIntervalSeconds
                    };
                }
                case BatterySensors batterySensors:
                {
                    _ = Enum.TryParse<SensorType>(batterySensors.GetType().Name, out var type);
                    return new ConfiguredSensor
                    {
                        Id = Guid.Parse(sensor.Id),
                        Name = sensor.Name,
                        Type = type,
                        UpdateInterval = sensor.UpdateIntervalSeconds
                    };
                }
                case DisplaySensors displaySensors:
                {
                    _ = Enum.TryParse<SensorType>(displaySensors.GetType().Name, out var type);
                    return new ConfiguredSensor
                    {
                        Id = Guid.Parse(sensor.Id),
                        Name = sensor.Name,
                        Type = type,
                        UpdateInterval = sensor.UpdateIntervalSeconds
                    };
                }
                case AudioSensors audioSensors:
                {
                    _ = Enum.TryParse<SensorType>(audioSensors.GetType().Name, out var type);
                    return new ConfiguredSensor
                    {
                        Id = Guid.Parse(sensor.Id),
                        Name = sensor.Name,
                        Type = type,
                        UpdateInterval = sensor.UpdateIntervalSeconds
                    };
                }
            }

            return null;
        }

        /// <summary>
        /// Store all current sensors
        /// </summary>
        /// <returns></returns>
        internal static bool Store()
        {
            try
            {
                // check config dir
                if (!Directory.Exists(Variables.ConfigPath))
                {
                    // create
                    Directory.CreateDirectory(Variables.ConfigPath);
                }

                // convert single-value sensors
                var configuredSensors = Variables.SingleValueSensors.Select(ConvertAbstractSingleValueToConfigured).Where(configuredSensor => configuredSensor != null).ToList();

                // convert multi-value sensors
                var configuredMultiValueSensors = Variables.MultiValueSensors.Select(ConvertAbstractMultiValueToConfigured).Where(configuredSensor => configuredSensor != null).ToList();
                configuredSensors = configuredSensors.Concat(configuredMultiValueSensors).ToList();

                // serialize to file
                var sensors = JsonConvert.SerializeObject(configuredSensors, Formatting.Indented);
                File.WriteAllText(Variables.SensorsFile, sensors);

                // done
                Log.Information("[SETTINGS_SENSORS] Stored {count} entities", (Variables.SingleValueSensors.Count + Variables.MultiValueSensors.Count));
                Variables.MainForm?.SetSensorsStatus(ComponentStatus.Ok);
                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SETTINGS_SENSORS] Error storing entities: {err}", ex.Message);
                Variables.MainForm?.ShowMessageBox(string.Format(Languages.StoredSensors_Store_MessageBox1, ex.Message), true);

                Variables.MainForm?.SetSensorsStatus(ComponentStatus.Failed);
                return false;
            }
        }
    }
}
