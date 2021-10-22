using System;
using System.Threading.Tasks;
using HASSAgent.Mqtt;
using MQTTnet;
using Serilog;

namespace HASSAgent.Models.Mqtt.Sensors
{
    public abstract class AbstractSensor : AbstractDiscoverable
    {
        public int UpdateIntervalSeconds { get; protected set; }
        public DateTime? LastUpdated { get; protected set; }
        public string PreviousPublishedState { get; protected set; }
        public override string Domain => "sensor";

        internal AbstractSensor(string name, int updateIntervalSeconds = 10, Guid id = default)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
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

        /// <summary>
        /// Returns the name and update interval (in seconds) of the sensor
        /// </summary>
        /// <returns></returns>
        internal (string name, int interval) GetInfo()
        {
            return (Name, UpdateIntervalSeconds);
        }

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

                await MqttManager.Publish(message);

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
            await MqttManager.AnnounceAutoDiscoveryConfig(this, Domain);
        }

        public async Task UnPublishAutoDiscoveryConfigAsync()
        {
            await MqttManager.AnnounceAutoDiscoveryConfig(this, Domain, true);
        }
    }
}
