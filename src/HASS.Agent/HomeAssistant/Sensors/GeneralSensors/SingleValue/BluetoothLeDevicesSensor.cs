using HASS.Agent.Managers;
using HASS.Agent.Models.Internal;
using HASS.Agent.Shared.Extensions;
using HASS.Agent.Shared.Models.HomeAssistant;
using Newtonsoft.Json;

namespace HASS.Agent.HomeAssistant.Sensors.GeneralSensors.SingleValue
{
    /// <summary>
    /// Sensor containing detected bluetooth LE devices
    /// </summary>
    public class BluetoothLeDevicesSensor : AbstractSingleValueSensor
    {
        private string _attributes = "{}";

        public BluetoothLeDevicesSensor(int? updateInterval = 30, string name = "bluetoothledevices", string id = default) : base(name ?? "bluetoothledevices", updateInterval ?? 30, id) 
        {
            UseAttributes = true;

            // start the scanner if it hasn't already
            BluetoothManager.StartWatchingForLeDevices();
        }

        public override DiscoveryConfigModel GetAutoDiscoveryConfig()
        {
            if (Variables.MqttManager == null) return null;

            var deviceConfig = Variables.MqttManager.GetDeviceConfigModel();
            if (deviceConfig == null) return null;

            return AutoDiscoveryConfigModel ?? SetAutoDiscoveryConfigModel(new SensorDiscoveryConfigModel()
            {
                Name = Name,
                Unique_id = Id,
                Device = deviceConfig,
                State_topic = $"{Variables.MqttManager.MqttDiscoveryPrefix()}/{Domain}/{deviceConfig.Name}/{ObjectId}/state",
                Icon = "mdi:bluetooth",
                Availability_topic = $"{Variables.MqttManager.MqttDiscoveryPrefix()}/{Domain}/{deviceConfig.Name}/availability",
                Json_attributes_topic = $"{Variables.MqttManager.MqttDiscoveryPrefix()}/{Domain}/{deviceConfig.Name}/{ObjectId}/attributes"
            });
        }

        public override string GetState()
        {
            var devices = BluetoothManager.GetDetectedLeDevicesAsync().GetAwaiter().GetResult();
            if (!devices.Any())
            {
                _attributes = "{}";
                return "0";
            }

            _attributes = JsonConvert.SerializeObject(new BluetoothLeDeviceCollection(devices), Formatting.Indented);
            return devices.Count.ToString();
        }

        public override string GetAttributes() => _attributes;
    }
}
