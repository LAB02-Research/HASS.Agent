using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;

namespace HASSAgent.Models.HomeAssistant.Sensors
{
    public abstract class AbstractMultiValueSensor : AbstractDiscoverable
    {
        public int UpdateIntervalSeconds { get; protected set; }
        public DateTime? LastUpdated { get; protected set; }
        public override string Domain => "sensor";

        public abstract Dictionary<string, AbstractSingleValueSensor> Sensors { get; protected set; }

        internal AbstractMultiValueSensor(string name, int updateIntervalSeconds = 10, string id = default)
        {
            Id = id == Guid.Empty.ToString() ? Guid.NewGuid().ToString() : id;
            Name = name;
            UpdateIntervalSeconds = updateIntervalSeconds;
        }

        public abstract void UpdateSensorValues();
        
        public async Task PublishStatesAsync(bool respectChecks = true)
        {
            try
            {
                if (respectChecks)
                {
                    if (LastUpdated.HasValue && LastUpdated.Value.AddSeconds(UpdateIntervalSeconds) > DateTime.UtcNow) return;
                }

                if (Sensors == null || !Sensors.Any()) return;

                // fetch new values for all sensors
                UpdateSensorValues();

                // update their values
                foreach (var sensor in Sensors) await sensor.Value.PublishStateAsync(respectChecks);

                LastUpdated = DateTime.UtcNow;
            }
            catch (Exception ex)
            {
                Log.Fatal("[SENSOR] [{name}] Error publishing state: {err}", Name, ex.Message);
            }
        }

        public async Task PublishAutoDiscoveryConfigAsync()
        {
            foreach (var sensor in Sensors) await sensor.Value.PublishAutoDiscoveryConfigAsync();
        }

        public async Task UnPublishAutoDiscoveryConfigAsync()
        {
            foreach (var sensor in Sensors) await sensor.Value.UnPublishAutoDiscoveryConfigAsync();
        }
    }
}
