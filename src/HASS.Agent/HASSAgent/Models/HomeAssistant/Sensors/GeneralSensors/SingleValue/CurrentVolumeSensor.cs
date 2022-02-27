using System;
using System.Globalization;
using CoreAudio;

namespace HASSAgent.Models.HomeAssistant.Sensors.GeneralSensors.SingleValue
{
    public class CurrentVolumeSensor : AbstractSingleValueSensor
    {
        public CurrentVolumeSensor(int? updateInterval = null, string name = "currentvolume", string id = default) : base(name ?? "currentvolume", updateInterval ?? 15, id)
        {
            //
        }

        public override DiscoveryConfigModel GetAutoDiscoveryConfig()
        {
            return AutoDiscoveryConfigModel ?? SetAutoDiscoveryConfigModel(new SensorDiscoveryConfigModel()
            {
                Name = Name,
                Unique_id = Id,
                Device = Variables.DeviceConfig,
                State_topic = $"{Variables.AppSettings.MqttDiscoveryPrefix}/{Domain}/{Variables.DeviceConfig.Name}/{ObjectId}/state",
                Icon = "mdi:volume-medium",
                Unit_of_measurement = "%",
                Availability_topic = $"{Variables.AppSettings.MqttDiscoveryPrefix}/{Domain}/{Variables.DeviceConfig.Name}/availability"
            });
        }

        public override string GetState()
        {
            using (var audioDevice = Variables.AudioDeviceEnumerator?.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia))
            {
                // check for null & mute
                if (audioDevice?.AudioEndpointVolume == null) return "0";
                if (audioDevice.AudioEndpointVolume.Mute) return "0";

                // return as percentage
                return Math.Round(audioDevice.AudioEndpointVolume.MasterVolumeLevelScalar * 100, 0).ToString(CultureInfo.InvariantCulture);
            }
        }
    }
}
