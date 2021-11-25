using System;
using System.Threading.Tasks;
using HASSAgent.Mqtt;
using MQTTnet;
using Serilog;

namespace HASSAgent.Models.Mqtt.Commands
{
    public abstract class AbstractCommand : AbstractDiscoverable
    {
        public int UpdateIntervalSeconds => 1;
        public DateTime? LastUpdated { get; set; }
        public string PreviousPublishedState { get; set; }
        public override string Domain => "switch";
        
        internal AbstractCommand(string name, Guid id = default)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
            Name = name;
        }

        protected CommandDiscoveryConfigModel AutoDiscoveryConfigModel;
        protected CommandDiscoveryConfigModel SetAutoDiscoveryConfigModel(CommandDiscoveryConfigModel config)
        {
            AutoDiscoveryConfigModel = config;
            return config;
        }

        public abstract string GetState();

        /// <summary>
        /// Returns the name of the command
        /// </summary>
        /// <returns></returns>
        internal string GetInfo()
        {
            return Name;
        }

        public async Task PublishStateAsync(bool respectChecks = true)
        {
            try
            {
                var state = GetState();

                if (respectChecks)
                {
                    if (LastUpdated.HasValue && LastUpdated.Value.AddSeconds(UpdateIntervalSeconds) > DateTime.UtcNow) return;
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
                Log.Fatal("[COMMAND] [{name}] Error publishing state: {err}", Name, ex.Message);
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

        public abstract void TurnOn();
        public abstract void TurnOff();
    }
}
