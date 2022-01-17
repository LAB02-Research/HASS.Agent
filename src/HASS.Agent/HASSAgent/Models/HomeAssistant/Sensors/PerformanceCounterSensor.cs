using System;
using System.Diagnostics;
using System.Globalization;
using HASSAgent.Functions;
using Serilog;

namespace HASSAgent.Models.HomeAssistant.Sensors
{
    public class PerformanceCounterSensor : AbstractSingleValueSensor
    {
        protected PerformanceCounter Counter = null;

        protected readonly string CategoryName;
        protected readonly string CounterName;
        protected readonly string InstanceName;

        public PerformanceCounterSensor(string categoryName, string counterName, string instanceName, int? updateInterval = null, string name = "PerformanceCounterSensor", string id = default) : base(name ?? "PerformanceCounterSensor", updateInterval ?? 10, id)
        {
            id = Guid.NewGuid().ToString();

            CategoryName = categoryName;
            CounterName = counterName;
            InstanceName = instanceName;

            Counter = PerformanceCounters.GetSingleInstanceCounter(categoryName, counterName);
            if (Counter == null)
            {
                Log.Error("[PERFMON] Counter not found: {cat}\\{name}\\{inst}", categoryName, counterName, instanceName);
                return;
            }

            Counter.InstanceName = instanceName;

            try
            {
                Counter.NextValue();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[PERFMON] Error retrieving counter value for {cat}\\{name}\\{inst}: {msg}", categoryName, counterName, instanceName, ex.Message);
            }
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
            if (Counter == null) return string.Empty;
            try
            {
                return Math.Round(Counter.NextValue()).ToString(CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                Log.Error("[PERFMON] Error retrieving counter value for {cat}\\{name}\\{inst}: {msg}", CategoryName, CounterName, InstanceName, ex.Message);
                return string.Empty;
            }
        }
    }
}
