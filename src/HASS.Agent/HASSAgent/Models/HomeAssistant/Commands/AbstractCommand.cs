using System;
using System.Threading.Tasks;
using HASSAgent.Mqtt;
using MQTTnet;
using Serilog;

namespace HASSAgent.Models.HomeAssistant.Commands
{
    public abstract class AbstractCommand : AbstractDiscoverable
    {
        public int UpdateIntervalSeconds => 1;
        public DateTime? LastUpdated { get; set; }
        public string PreviousPublishedState { get; set; }
        public override string Domain => "switch";
        
        internal AbstractCommand(string name, string id = default)
        {
            Id = id == Guid.Empty.ToString() ? Guid.NewGuid().ToString() : id;
            Name = name;
        }

        protected CommandDiscoveryConfigModel AutoDiscoveryConfigModel;
        protected CommandDiscoveryConfigModel SetAutoDiscoveryConfigModel(CommandDiscoveryConfigModel config)
        {
            AutoDiscoveryConfigModel = config;
            return config;
        }

        public abstract string GetState();
        
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

                await MqttManager.PublishAsync(message);

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
            await MqttManager.AnnounceAutoDiscoveryConfigAsync(this, Domain);
        }

        public async Task UnPublishAutoDiscoveryConfigAsync()
        {
            await MqttManager.AnnounceAutoDiscoveryConfigAsync(this, Domain, true);
        }

        public abstract void TurnOn();
        public abstract void TurnOff();
    }
}
