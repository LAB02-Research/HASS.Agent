using System;
using System.Management;

namespace HASSAgent.Models.HomeAssistant.Sensors
{
    public class WmiQuerySensor : AbstractSingleValueSensor
    {
        public string Query { get; private set; }
        protected readonly ObjectQuery ObjectQuery;
        protected readonly ManagementObjectSearcher Searcher;

        public WmiQuerySensor(string query, int? updateInterval = null, string name = "wmiquerysensor", string id = default) : base(name ?? "wmiquerysensor", updateInterval ?? 10, id)
        {
            Query = query;
            ObjectQuery = new ObjectQuery(Query);
            Searcher = new ManagementObjectSearcher(query);
        }

        public override DiscoveryConfigModel GetAutoDiscoveryConfig()
        {
            return AutoDiscoveryConfigModel ?? SetAutoDiscoveryConfigModel(new SensorDiscoveryConfigModel()
            {
                Name = Name,
                Unique_id = Id,
                Device = Variables.DeviceConfig,
                State_topic = $"{Variables.AppSettings.MqttDiscoveryPrefix}/{Domain}/{Variables.DeviceConfig.Name}/{Name}/state",
                Availability_topic = $"{Variables.AppSettings.MqttDiscoveryPrefix}/{Domain}/{Variables.DeviceConfig.Name}/availability"
            });
        }

        public override string GetState()
        {
            using (var collection = Searcher.Get())
            {
                var retValue = string.Empty;
                foreach (var managementBaseObject in collection)
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(retValue)) continue;

                        using (var managementObject = (ManagementObject)managementBaseObject)
                        {
                            foreach (var property in managementObject.Properties)
                            {
                                retValue = property.Value.ToString();
                                break;
                            }
                        }
                    }
                    finally
                    {
                        managementBaseObject?.Dispose();
                    }
                }

                return string.Empty;
            }
        }
    }
}
