using Google.Protobuf.Collections;
using HASS.Agent.Shared.Enums;
using HASS.Agent.Shared.Models.Config;
using HASS.Agent.Shared.Models.Config.Service;

namespace HASS.Agent.Extensions
{
    /// <summary>
    /// Contains extensions for the RPC server
    /// </summary>
    public static class RpcExtensions
    {
        /// <summary>
        /// Converts the RepeatedField&lt;RpcConfiguredServerCommand&gt; to an internal List&lt;ConfiguredCommand&gt; object
        /// </summary>
        /// <param name="rpcConfiguredCommands"></param>
        /// <returns></returns>
        public static List<ConfiguredCommand> ConvertToConfiguredCommands(this RepeatedField<RpcConfiguredServerCommand> rpcConfiguredCommands)
        {
            return rpcConfiguredCommands.Select(rpcConfiguredCommand => rpcConfiguredCommand.ConvertToConfiguredCommand()).ToList();
        }

        /// <summary>
        /// Converts the RpcConfiguredServerCommand to an internal ConfiguredCommand object 
        /// </summary>
        /// <param name="rpcConfiguredCommand"></param>
        /// <returns></returns>
        public static ConfiguredCommand ConvertToConfiguredCommand(this RpcConfiguredServerCommand rpcConfiguredCommand)
        {
            var configuredCommand = new ConfiguredCommand
            {
                Type = (CommandType)rpcConfiguredCommand.Type,
                Id = Guid.Parse(rpcConfiguredCommand.Id),
                Name = rpcConfiguredCommand.Name,
                Command = rpcConfiguredCommand.Command,
                RunAsLowIntegrity = rpcConfiguredCommand.RunAsLowIntegrity,
                EntityType = (CommandEntityType)rpcConfiguredCommand.CommandEntityType
            };
            return configuredCommand;
        }

        /// <summary>
        /// Converts the List&lt;ConfiguredCommand&gt; to a RepeatedField&lt;RpcConfiguredServerCommand&gt; object
        /// </summary>
        /// <param name="configuredCommands"></param>
        /// <returns></returns>
        public static RepeatedField<RpcConfiguredServerCommand> ConvertToRpcConfiguredCommands(this List<ConfiguredCommand> configuredCommands)
        {
            var rpcConfguredCommands = new RepeatedField<RpcConfiguredServerCommand>();
            foreach (var configuredCommand in configuredCommands) rpcConfguredCommands.Add(configuredCommand.ConvertToRpcConfiguredCommand());
            return rpcConfguredCommands;
        }

        /// <summary>
        /// Converts the ConfiguredCommand to a RpcConfiguredServerCommand object 
        /// </summary>
        /// <param name="configuredCommand"></param>
        /// <returns></returns>
        public static RpcConfiguredServerCommand ConvertToRpcConfiguredCommand(this ConfiguredCommand configuredCommand)
        {
            var configuredRpcCommand = new RpcConfiguredServerCommand
            {
                Type = (int)configuredCommand.Type,
                Id = configuredCommand.Id.ToString(),
                Command = configuredCommand.Command ?? string.Empty,
                RunAsLowIntegrity = configuredCommand.RunAsLowIntegrity,
                Name = configuredCommand.Name,
                CommandEntityType = (int)configuredCommand.EntityType
            };
            return configuredRpcCommand;
        }

        /// <summary>
        /// Converts the RepeatedField&lt;RpcConfiguredServerSensor&gt; to an internal List&lt;ConfiguredSensor&gt; object
        /// </summary>
        /// <param name="rpcConfiguredSensors"></param>
        /// <returns></returns>
        public static List<ConfiguredSensor> ConvertToConfiguredSensors(this RepeatedField<RpcConfiguredServerSensor> rpcConfiguredSensors)
        {
            return rpcConfiguredSensors.Select(rpcConfiguredSensor => rpcConfiguredSensor.ConvertToConfiguredSensor()).ToList();
        }

        /// <summary>
        /// Converts the RpcConfiguredServerSensor to an internal ConfiguredSensor object 
        /// </summary>
        /// <param name="rpcConfiguredSensor"></param>
        /// <returns></returns>
        public static ConfiguredSensor ConvertToConfiguredSensor(this RpcConfiguredServerSensor rpcConfiguredSensor)
        {
            var configuredSensor = new ConfiguredSensor
            {
                Type = (SensorType)rpcConfiguredSensor.Type,
                Id = Guid.Parse(rpcConfiguredSensor.Id),
                UpdateInterval = rpcConfiguredSensor.UpdateInterval,
                Query = rpcConfiguredSensor.Query,
                Scope = rpcConfiguredSensor.Scope,
                WindowName = rpcConfiguredSensor.WindowName,
                Category = rpcConfiguredSensor.Category,
                Counter = rpcConfiguredSensor.Counter,
                Instance = rpcConfiguredSensor.Instance,
                Name = rpcConfiguredSensor.Name
            };
            return configuredSensor;
        }

        /// <summary>
        /// Converts the List&lt;ConfiguredSensor&gt; to a RepeatedField&lt;RpcConfiguredServerSensor&gt; object
        /// </summary>
        /// <param name="configuredSensors"></param>
        /// <returns></returns>
        public static RepeatedField<RpcConfiguredServerSensor> ConvertToRpcConfiguredSensors(this List<ConfiguredSensor> configuredSensors)
        {
            var rpcConfguredSensors = new RepeatedField<RpcConfiguredServerSensor>();
            foreach (var configuredSensor in configuredSensors) rpcConfguredSensors.Add(configuredSensor.ConvertToRpcConfiguredSensor());
            return rpcConfguredSensors;
        }

        /// <summary>
        /// Converts the ConfiguredSensor to a RpcConfiguredServerSensor object 
        /// </summary>
        /// <param name="configuredSensor"></param>
        /// <returns></returns>
        public static RpcConfiguredServerSensor ConvertToRpcConfiguredSensor(this ConfiguredSensor configuredSensor)
        {
            var updateInterval = configuredSensor.UpdateInterval ?? 30;

            var configuredRpcSensor = new RpcConfiguredServerSensor
            {
                Type = (int)configuredSensor.Type,
                Id = configuredSensor.Id.ToString(),
                UpdateInterval = updateInterval,
                Query = configuredSensor.Query ?? string.Empty,
                Scope = configuredSensor.Scope ?? string.Empty,
                WindowName = configuredSensor.WindowName ?? string.Empty,
                Category = configuredSensor.Category ?? string.Empty,
                Counter = configuredSensor.Counter ?? string.Empty,
                Instance = configuredSensor.Instance ?? string.Empty,
                Name = configuredSensor.Name
            };
            return configuredRpcSensor;
        }

        /// <summary>
        /// Converts the RpcServiceMqttSettings to an internal ServiceMqttSettings object
        /// </summary>
        /// <param name="rpcServiceMqttSettings"></param>
        /// <returns></returns>
        public static ServiceMqttSettings ConvertToServiceMqttSettings(this RpcServiceMqttSettings rpcServiceMqttSettings)
        {
            var serviceMqttSettings = new ServiceMqttSettings
            {
                MqttAddress = rpcServiceMqttSettings.MqttAddress,
                MqttPort = rpcServiceMqttSettings.MqttPort,
                MqttUseTls = rpcServiceMqttSettings.MqttUseTls,
                MqttAllowUntrustedCertificates = rpcServiceMqttSettings.MqttAllowUntrustedCertificates,
                MqttUsername = rpcServiceMqttSettings.MqttUsername,
                MqttPassword = rpcServiceMqttSettings.MqttPassword,
                MqttDiscoveryPrefix = rpcServiceMqttSettings.MqttDiscoveryPrefix,
                MqttUseRetainFlag = rpcServiceMqttSettings.MqttUseRetainFlag,
                MqttRootCertificate = rpcServiceMqttSettings.MqttRootCertificate,
                MqttClientCertificate = rpcServiceMqttSettings.MqttClientCertificate,
                MqttClientId = rpcServiceMqttSettings.MqttClientId
            };
            return serviceMqttSettings;
        }

        /// <summary>
        /// Converts the ServiceMqttSettings to a RpcServiceMqttSettings object
        /// </summary>
        /// <param name="serviceMqttSettings"></param>
        /// <returns></returns>
        public static RpcServiceMqttSettings ConvertToRpcServiceMqttSettings(this ServiceMqttSettings serviceMqttSettings)
        {
            var rpcServiceMqttSettings = new RpcServiceMqttSettings
            {
                MqttAddress = serviceMqttSettings.MqttAddress,
                MqttPort = serviceMqttSettings.MqttPort,
                MqttUseTls = serviceMqttSettings.MqttUseTls,
                MqttAllowUntrustedCertificates = serviceMqttSettings.MqttAllowUntrustedCertificates,
                MqttUsername = serviceMqttSettings.MqttUsername,
                MqttPassword = serviceMqttSettings.MqttPassword,
                MqttDiscoveryPrefix = serviceMqttSettings.MqttDiscoveryPrefix,
                MqttUseRetainFlag = serviceMqttSettings.MqttUseRetainFlag,
                MqttRootCertificate = serviceMqttSettings.MqttRootCertificate,
                MqttClientCertificate = serviceMqttSettings.MqttClientCertificate,
                MqttClientId = serviceMqttSettings.MqttClientId
            };
            return rpcServiceMqttSettings;
        }

        /// <summary>
        /// Converts the RpcServiceSettings to an internal ServiceSettings object
        /// </summary>
        /// <param name="rpcServiceSettings"></param>
        /// <returns></returns>
        public static ServiceSettings ConvertToServiceSettings(this RpcServiceSettings rpcServiceSettings)
        {
            var serviceSettings = new ServiceSettings
            {
                AuthId = rpcServiceSettings.AuthId,
                CustomExecutorName = rpcServiceSettings.CustomExecutorName,
                CustomExecutorBinary = rpcServiceSettings.CustomExecutorBinary,
                DisconnectedGracePeriodSeconds = rpcServiceSettings.DisconnectedGracePeriodSeconds
            };

            return serviceSettings;
        }

        /// <summary>
        /// Converts the ServiceSettings to a RpcServiceSettings object
        /// </summary>
        /// <param name="serviceSettings"></param>
        /// <returns></returns>
        public static RpcServiceSettings ConvertToRpcServiceSettings(this ServiceSettings serviceSettings)
        {
            var rpcServiceSettings = new RpcServiceSettings
            {
                AuthId = serviceSettings.AuthId,
                CustomExecutorName = serviceSettings.CustomExecutorName,
                CustomExecutorBinary = serviceSettings.CustomExecutorBinary,
                DisconnectedGracePeriodSeconds = serviceSettings.DisconnectedGracePeriodSeconds
            };

            return rpcServiceSettings;
        }
    }
}
