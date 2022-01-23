using System.Linq;
using Microsoft.Win32;

namespace HASSAgent.Models.HomeAssistant.Sensors.GeneralSensors.SingleValue
{
    public class WebcamActiveSensor : AbstractSingleValueSensor
    {
        public override string Domain => "binary_sensor";
        public WebcamActiveSensor(int? updateInterval = null, string name = "webcamactive", string id = default) : base(name ?? "webcamactive", updateInterval ?? 10, id) {}

        public override string GetState()
        {
            return IsWebcamInUse() ? "ON" : "OFF";
        }

        public override DiscoveryConfigModel GetAutoDiscoveryConfig()
        {
            return AutoDiscoveryConfigModel ?? SetAutoDiscoveryConfigModel(new SensorDiscoveryConfigModel()
            {
                Name = Name,
                Unique_id = Id,
                Device = Variables.DeviceConfig,
                State_topic = $"{Variables.AppSettings.MqttDiscoveryPrefix}/{Domain}/{Variables.DeviceConfig.Name}/{Name}/state",
                Availability_topic = $"{Variables.AppSettings.MqttDiscoveryPrefix}/sensor/{Variables.DeviceConfig.Name}/availability"
            });
        }
        
        private static bool IsWebcamInUse()
        {
            const string regKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\webcam";
            bool inUse;

            // first local machine
            using (var key = Registry.LocalMachine.OpenSubKey(regKey))
            {
                inUse = CheckRegForWebcamInUse(key);
                if (inUse) return true;
            }

            // then current user
            using (var key = Registry.CurrentUser.OpenSubKey(regKey))
            {
                inUse = CheckRegForWebcamInUse(key);
                if (inUse) return true;
            }

            // nope
            return false;
        }

        private static bool CheckRegForWebcamInUse(RegistryKey key)
        {
            if (key == null) return false;

            foreach (var subKeyName in key.GetSubKeyNames())
            {
                // NonPackaged has multiple subkeys
                if (subKeyName == "NonPackaged")
                {
                    using (var nonpackagedkey = key.OpenSubKey(subKeyName))
                    {
                        if (nonpackagedkey == null) continue;

                        foreach (var nonpackagedSubKeyName in nonpackagedkey.GetSubKeyNames())
                        {
                            using (var subKey = nonpackagedkey.OpenSubKey(nonpackagedSubKeyName))
                            {
                                if (subKey == null || !subKey.GetValueNames().Contains("LastUsedTimeStop")) continue;

                                var endTime = subKey.GetValue("LastUsedTimeStop") is long 
                                    ? (long)subKey.GetValue("LastUsedTimeStop") 
                                    : -1;

                                if (endTime <= 0) return true;
                            }
                        }
                    }
                }
                else
                {
                    using (var subKey = key.OpenSubKey(subKeyName))
                    {
                        if (subKey == null || !subKey.GetValueNames().Contains("LastUsedTimeStop")) continue;

                        var endTime = subKey.GetValue("LastUsedTimeStop") is long 
                            ? (long)subKey.GetValue("LastUsedTimeStop") 
                            : -1;

                        if (endTime <= 0) return true;
                    }
                }
            }

            return false;
        }
    }
}
