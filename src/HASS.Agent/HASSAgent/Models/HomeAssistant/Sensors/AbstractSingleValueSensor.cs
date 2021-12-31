using System;
using System.Threading.Tasks;
using HASSAgent.Mqtt;
using MQTTnet;
using Serilog;

namespace HASSAgent.Models.HomeAssistant.Sensors
{
    public abstract class AbstractSingleValueSensor : AbstractDiscoverable
    {
        public int UpdateIntervalSeconds { get; protected set; }
        public DateTime? LastUpdated { get; protected set; }
        public string PreviousPublishedState { get; protected set; }
        public override string Domain => "sensor";

        internal AbstractSingleValueSensor(string name, int updateIntervalSeconds = 10, string id = default)
        {
            Id = id == Guid.Empty.ToString() ? Guid.NewGuid().ToString() : id;
            Name = name;
            UpdateIntervalSeconds = updateIntervalSeconds;
        }

        protected SensorDiscoveryConfigModel AutoDiscoveryConfigModel;
        protected SensorDiscoveryConfigModel SetAutoDiscoveryConfigModel(SensorDiscoveryConfigModel config)
        {
            AutoDiscoveryConfigModel = config;
            return config;
        }

        public abstract string GetState();
        
        public async Task PublishStateAsync(bool respectChecks = true)
        {
            try
            {
                if (respectChecks)
                {
                    if (LastUpdated.HasValue && LastUpdated.Value.AddSeconds(UpdateIntervalSeconds) > DateTime.UtcNow) return;
                }
            
                var state = GetState();

                if (respectChecks)
                {
                    if (PreviousPublishedState == state) return;
                }

                var message = new MqttApplicationMessageBuilder()
                    .WithTopic(GetAutoDiscoveryConfig().State_topic)
                    .WithPayload(state)
                    .WithExactlyOnceQoS()
                    .WithRetainFlag()
                    .Build();

                await MqttManager.PublishAsync(message);

                PreviousPublishedState = state;
                LastUpdated = DateTime.UtcNow;
            }
            catch (Exception ex)
            {
                Log.Fatal("[SENSOR] [{name}] Error publishing state: {err}", Name, ex.Message);
            }
        }

        public async Task PublishAutoDiscoveryConfigAsync()
        {
            await MqttManager.AnnounceAutoDiscoveryConfigAsync(this, Domain);
        }

        public async Task UnPublishAutoDiscoveryConfigAsync()
        {
            await MqttManager.AnnounceAutoDiscoveryConfigAsync(this, Domain, true);
        }
    }
}
