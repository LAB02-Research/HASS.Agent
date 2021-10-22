using System;
using System.Threading.Tasks;
using HASSAgent.Enums;
using HASSAgent.Models.Mqtt.Sensors;
using HASSAgent.Models.Mqtt.Sensors.GeneralSensors;
using HASSAgent.Models.Mqtt.Sensors.WmiSensors;
using HASSAgent.Mqtt;
using Serilog;

namespace HASSAgent.Sensors
{
    /// <summary>
    /// Continuously performs sensor autodiscovery and state publishing
    /// </summary>
    internal static class SensorsManager
    {
        private static bool _active = true;
        private static bool _pause;

        /// <summary>
        /// Initializes the sensor manager
        /// </summary>
        internal static async void Intialise()
        {
            // wait while mqtt's connecting
            while (MqttManager.GetStatus() == MqttStatus.Connecting) await Task.Delay(250);

            // start background processing
            _ = Task.Run(Process);
        }

        /// <summary>
        /// Stop processing sensor states
        /// </summary>
        internal static void Stop()
        {
            _active = false;
        }

        /// <summary>
        /// Pause processing sensor states
        /// </summary>
        internal static void Pause()
        {
            _pause = true;
        }

        /// <summary>
        /// Resume processing sensor states
        /// </summary>
        internal static void Unpause()
        {
            _pause = false;
        }

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

                    // let hass know we're still here
                    await MqttManager.AnnounceAvailabilityAsync("sensor");

                    // publish sensor autodisco's
                    foreach (var sensor in Variables.Sensors) await sensor.PublishAutoDiscoveryConfigAsync();

                    // publish sensor states
                    foreach (var sensor in Variables.Sensors) await sensor.PublishStateAsync();
                }
                catch (Exception ex)
                {
                    Log.Fatal(ex, "[SENSORSMANAGER] Eroor while publishing: {err}", ex.Message);
                }
            }
        }

        /// <summary>
        /// Returns default information for the specified sensor type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        internal static (string name, int interval) GetSensorDefaultInfo(SensorType type)
        {
            switch (type)
            {
                case SensorType.UserNotificationStateSensor:
                    return new UserNotificationStateSensor().GetInfo();
                case SensorType.DummySensor:
                    return new DummySensor().GetInfo();
                case SensorType.CurrentClockSpeedSensor:
                    return new CurrentClockSpeedSensor().GetInfo();
                case SensorType.CpuLoadSensor:
                    return new CpuLoadSensor().GetInfo();
                case SensorType.MemoryUsageSensor:
                    return new MemoryUsageSensor().GetInfo();
                case SensorType.ActiveWindowSensor:
                    return new ActiveWindowSensor().GetInfo();
                case SensorType.NamedWindowSensor:
                    return new NamedWindowSensor("").GetInfo();
                case SensorType.LastActiveSensor:
                    return new LastActiveSensor().GetInfo();
                case SensorType.LastBootSensor:
                    return new LastBootSensor().GetInfo();
                case SensorType.WebcamActiveSensor:
                    return new WebcamActiveSensor().GetInfo();
                case SensorType.MicrophoneActiveSensor:
                    return new MicrophoneActiveSensor().GetInfo();
                case SensorType.SessionStateSensor:
                    return new SessionStateSensor().GetInfo();
                case SensorType.CurrentVolumeSensor:
                    return new CurrentVolumeSensor().GetInfo();
                case SensorType.GpuLoadSensor:
                    return new GpuLoadSensor().GetInfo();
                case SensorType.WmiQuerySensor:
                    return new WmiQuerySensor("").GetInfo();
                default:
                    return ("", 10);
            }
        }
    }
}
