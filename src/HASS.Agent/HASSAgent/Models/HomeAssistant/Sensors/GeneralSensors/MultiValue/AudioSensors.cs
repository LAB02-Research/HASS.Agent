using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using CoreAudio;
using HASSAgent.Functions;
using HASSAgent.Models.HomeAssistant.Sensors.GeneralSensors.MultiValue.DataTypes;
using HASSAgent.Models.Internal;
using Newtonsoft.Json;
using Serilog;

namespace HASSAgent.Models.HomeAssistant.Sensors.GeneralSensors.MultiValue
{
    public class AudioSensors : AbstractMultiValueSensor
    {
        private static readonly Dictionary<int, string> ApplicationNames = new Dictionary<int, string>();
        private bool _errorPrinted = false;
        
        private readonly int _updateInterval;

        public sealed override Dictionary<string, AbstractSingleValueSensor> Sensors { get; protected set; } = new Dictionary<string, AbstractSingleValueSensor>();
        
        public AudioSensors(int? updateInterval = null, string name = "audio", string id = default) : base(name ?? "audio", updateInterval ?? 20, id)
        {
            _updateInterval = updateInterval ?? 20;
            
            UpdateSensorValues();
        }

        public sealed override void UpdateSensorValues()
        {
            try
            {
                // lowercase and safe name of the multivalue sensor
                var parentSensorSafeName = HelperFunctions.GetSafeValue(Name);

                // get the default audio device
                using (var audioDevice = Variables.AudioDeviceEnumerator.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia))
                {
                    // default device name
                    var defaultDeviceId = $"{parentSensorSafeName}_default_device";
                    var defaultDeviceSensor = new DataTypeStringSensor(_updateInterval, $"{Name} Default Device", defaultDeviceId, string.Empty, "mdi:speaker", string.Empty, Name);
                    defaultDeviceSensor.SetState(audioDevice.FriendlyName);

                    if (!Sensors.ContainsKey(defaultDeviceId)) Sensors.Add(defaultDeviceId, defaultDeviceSensor);
                    else Sensors[defaultDeviceId] = defaultDeviceSensor;

                    // default device state
                    var defaultDeviceStateId = $"{parentSensorSafeName}_default_device_state";
                    var defaultDeviceStateSensor = new DataTypeStringSensor(_updateInterval, $"{Name} Default Device State", defaultDeviceStateId, string.Empty, "mdi:speaker", string.Empty, Name);
                    defaultDeviceStateSensor.SetState(GetReadableState(audioDevice.State));

                    if (!Sensors.ContainsKey(defaultDeviceStateId)) Sensors.Add(defaultDeviceStateId, defaultDeviceStateSensor);
                    else Sensors[defaultDeviceStateId] = defaultDeviceStateSensor;

                    // default device volume
                    var masterVolume = (int)(audioDevice.AudioEndpointVolume?.MasterVolumeLevelScalar * 100 ?? 0);
                    var defaultDeviceVolumeId = $"{parentSensorSafeName}_default_device_volume";
                    var defaultDeviceVolumeSensor = new DataTypeIntSensor(_updateInterval, $"{Name} Default Device Volume", defaultDeviceVolumeId, string.Empty, "mdi:speaker", string.Empty, Name);
                    defaultDeviceVolumeSensor.SetState(masterVolume);

                    if (!Sensors.ContainsKey(defaultDeviceVolumeId)) Sensors.Add(defaultDeviceVolumeId, defaultDeviceVolumeSensor);
                    else Sensors[defaultDeviceVolumeId] = defaultDeviceVolumeSensor;

                    // get session and volume info
                    var sessionInfos = GetSessions(out var peakVolume);

                    // peak value sensor
                    var peakVolumeId = $"{parentSensorSafeName}_peak_volume";
                    var peakVolumeSensor = new DataTypeStringSensor(_updateInterval, $"{Name} Peak Volume", peakVolumeId, string.Empty, "mdi:volume-high", string.Empty, Name);
                    peakVolumeSensor.SetState(peakVolume.ToString(CultureInfo.CurrentCulture));

                    if (!Sensors.ContainsKey(peakVolumeId)) Sensors.Add(peakVolumeId, peakVolumeSensor);
                    else Sensors[peakVolumeId] = peakVolumeSensor;

                    // sessions sensor
                    var sessions = JsonConvert.SerializeObject(sessionInfos, Formatting.Indented);
                    var sessionsId = $"{parentSensorSafeName}_audio_sessions";
                    var sessionsSensor = new DataTypeStringSensor(_updateInterval, $"{Name} Audio Sessions", sessionsId, string.Empty, "mdi:music-box-multiple-outline", string.Empty, Name);
                    sessionsSensor.SetState(sessions);

                    if (!Sensors.ContainsKey(sessionsId)) Sensors.Add(sessionsId, sessionsSensor);
                    else Sensors[sessionsId] = sessionsSensor;
                }

                // optionally reset error flag
                if (_errorPrinted) _errorPrinted = false;
            }
            catch (Exception ex)
            {
                // only worry if we're active
                if (Variables.ShuttingDown) return;

                // something went wrong, only print once
                if (_errorPrinted) return;
                _errorPrinted = true;

                Log.Fatal(ex, "[AUDIO] Error while fetching audio info: {err}", ex.Message);
            }
        }

        private List<AudioSessionInfo> GetSessions(out float peakVolume)
        {
            var sessionInfos = new List<AudioSessionInfo>();
            peakVolume = 0f;

            try
            {
                var errors = false;

                foreach (var device in Variables.AudioDeviceEnumerator.EnumerateAudioEndPoints(EDataFlow.eRender, DEVICE_STATE.DEVICE_STATE_ACTIVE))
                {
                    // process sessions (and get peak volume)
                    foreach (var session in device.AudioSessionManager2?.Sessions.Where(x => x != null))
                    {
                        try
                        {
                            // filter inactive sessions
                            if (session.State != AudioSessionState.AudioSessionStateActive) continue;

                            // prepare sessioninfo
                            var sessionInfo = new AudioSessionInfo();

                            // get displayname
                            string displayName;
                            var procId = (int)session.GetProcessID;
                            if (procId <= 0)
                            {
                                // faulty process id, use the provided displayname
                                displayName = session.DisplayName;
                            }
                            else
                            {
                                if (ApplicationNames.ContainsKey(procId)) displayName = ApplicationNames[procId];
                                else
                                {
                                    // we don't know this app yet, get process info
                                    using (var p = Process.GetProcessById(procId))
                                    {
                                        displayName = p.ProcessName;
                                        ApplicationNames.Add(procId, displayName);
                                    }
                                }
                            }

                            // set displayname
                            if (displayName.Length > 30) displayName = $"{displayName.Substring(0, 30)}..";
                            sessionInfo.Application = displayName;

                            // get muted state
                            sessionInfo.Muted = session.SimpleAudioVolume?.Mute ?? false;

                            // set master volume
                            sessionInfo.MasterVolume = session.SimpleAudioVolume?.MasterVolume * 100 ?? 0f;

                            // set peak volume
                            sessionInfo.PeakVolume = session.AudioMeterInformation?.MasterPeakValue * 100 ?? 0f;

                            // new max?
                            if (sessionInfo.PeakVolume > peakVolume) peakVolume = sessionInfo.PeakVolume;

                            // store the session info
                            sessionInfos.Add(sessionInfo);
                        }
                        catch (Exception ex)
                        {
                            if (!_errorPrinted) Log.Fatal(ex, "[AUDIO] [{app}] Exception while retrieving info: {err}", session.DisplayName, ex.Message);
                            errors = true;
                        }
                        finally
                        {
                            session?.Dispose();
                            device?.Dispose();
                        }
                    }
                }

                // only print errors once
                if (errors && !_errorPrinted)
                {
                    _errorPrinted = true;
                    return sessionInfos;
                }

                // optionally reset error flag
                if (_errorPrinted) _errorPrinted = false;
            }
            catch (Exception ex)
            {
                // something went wrong, only print once
                if (_errorPrinted) return sessionInfos;
                _errorPrinted = true;

                Log.Fatal(ex, "[AUDIO] Fatal exception while getting sessions: {err}", ex.Message);
            }

            return sessionInfos;
        }

        /// <summary>
        /// Converts the audio device's state to a better readable form
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        private static string GetReadableState(DEVICE_STATE state)
        {
            switch (state)
            {
                case DEVICE_STATE.DEVICE_STATE_ACTIVE:
                    return "ACTIVE";
                case DEVICE_STATE.DEVICE_STATE_DISABLED:
                    return "DISABLED";
                case DEVICE_STATE.DEVICE_STATE_NOTPRESENT:
                    return "NOT PRESENT";
                case DEVICE_STATE.DEVICE_STATE_UNPLUGGED:
                    return "UNPLUGGED";
                case DEVICE_STATE.DEVICE_STATEMASK_ALL:
                    return "STATEMASK_ALL";
                default:
                    return "UNKNOWN";
            }
        }

        public override DiscoveryConfigModel GetAutoDiscoveryConfig() => null;
    }
}
