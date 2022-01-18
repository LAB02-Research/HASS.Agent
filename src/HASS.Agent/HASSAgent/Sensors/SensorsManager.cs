using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HASSAgent.Enums;
using HASSAgent.Mqtt;
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
        /// Continously processes sensors (autodiscovery, states)
        /// </summary>
        private static async void Process()
        {
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

                    // publish availability & sensor autodisco's every 30 sec
                    if ((DateTime.Now - _lastAutoDiscoPublish).TotalSeconds > 30)
                    {
                        // let hass know we're still here
                        await MqttManager.AnnounceAvailabilityAsync();

                        // publish the autodisco's
                        if (SingleValueSensorsPresent()) foreach (var sensor in Variables.SingleValueSensors) await sensor.PublishAutoDiscoveryConfigAsync();
                        if (MultiValueSensorsPresent()) foreach (var sensor in Variables.MultiValueSensors) await sensor.PublishAutoDiscoveryConfigAsync();

                        // log moment
                        _lastAutoDiscoPublish = DateTime.Now;
                    }

                    // publish sensor states (they have their own time-based scheduling)
                    if (SingleValueSensorsPresent()) foreach (var sensor in Variables.SingleValueSensors) await sensor.PublishStateAsync();
                    if (MultiValueSensorsPresent()) foreach (var sensor in Variables.MultiValueSensors) await sensor.PublishStatesAsync();
                }
                catch (Exception ex)
                {
                    Log.Fatal(ex, "[SENSORSMANAGER] Eroor while publishing: {err}", ex.Message);
                }
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
            return !SensorInfo.ContainsKey(type) ? ("unknown sensor", 0) : SensorInfo[type];
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
        }
    }
}
