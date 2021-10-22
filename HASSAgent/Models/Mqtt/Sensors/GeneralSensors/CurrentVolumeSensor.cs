using System;
using System.Globalization;
using System.Linq;
using CoreAudio;

namespace HASSAgent.Models.Mqtt.Sensors.GeneralSensors
{
    public class CurrentVolumeSensor : AbstractSensor
    {
        private readonly MMDeviceCollection _devices;

        public CurrentVolumeSensor(int? updateInterval = null, string name = "CurrentVolume", Guid id = default) : base(name ?? "CurrentVolume", updateInterval ?? 15, id)
        {
            _devices = Variables.AudioDeviceEnumerator.EnumerateAudioEndPoints(EDataFlow.eRender, DEVICE_STATE.DEVICE_STATE_ACTIVE);
        }

        public override DiscoveryConfigModel GetAutoDiscoveryConfig()
        {
            return AutoDiscoveryConfigModel ?? SetAutoDiscoveryConfigModel(new SensorDiscoveryConfigModel()
            {
                Name = Name,
                Unique_id = Id.ToString(),
                Device = Variables.DeviceConfig,
                State_topic = $"homeassistant/{Domain}/{Variables.DeviceConfig.Name}/{ObjectId}/state",
                Icon = "mdi:volume-medium",
                Unit_of_measurement = "%",
                Availability_topic = $"homeassistant/{Domain}/{Variables.DeviceConfig.Name}/availability"
            });
        }

        public override string GetState()
        {
            var peaks = (from device in _devices where device.AudioMeterInformation != null select device.AudioMeterInformation.PeakValues[0]).ToList();
            return Math.Round(peaks.Max() * 100, 0).ToString(CultureInfo.InvariantCulture);
        }
    }
}
