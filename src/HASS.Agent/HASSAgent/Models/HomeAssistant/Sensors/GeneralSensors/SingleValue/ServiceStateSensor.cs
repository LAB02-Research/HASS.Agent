using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using HASSAgent.Functions;
using Serilog;

namespace HASSAgent.Models.HomeAssistant.Sensors.GeneralSensors.SingleValue
{
    public class ServiceStateSensor : AbstractSingleValueSensor
    {
        public string ServiceName { get; protected set; }

        public ServiceStateSensor(string serviceName, int? updateInterval = null, string name = "servicestate", string id = default) : base(name ?? "servicestate", updateInterval ?? 10, id)
        {
            ServiceName = serviceName;
        }

        public override DiscoveryConfigModel GetAutoDiscoveryConfig()
        {
            return AutoDiscoveryConfigModel ?? SetAutoDiscoveryConfigModel(new SensorDiscoveryConfigModel()
            {
                Name = Name,
                Unique_id = Id,
                Device = Variables.DeviceConfig,
                State_topic = $"{Variables.AppSettings.MqttDiscoveryPrefix}/{Domain}/{Variables.DeviceConfig.Name}/{ObjectId}/state",
                Icon = "mdi:file-eye-outline",
                Availability_topic = $"{Variables.AppSettings.MqttDiscoveryPrefix}/{Domain}/{Variables.DeviceConfig.Name}/availability"
            });
        }

        public override string GetState()
        {
            using (var svc = new ServiceController(ServiceName))
            {
                try
                {
                    return svc.Status.ToString();
                }
                catch (InvalidOperationException)
                {
                    // service wasn't found
                    return "NotFound";
                }
            }
        }
    }
}
