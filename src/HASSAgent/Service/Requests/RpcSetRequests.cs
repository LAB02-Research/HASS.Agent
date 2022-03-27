using Grpc.Core;
using HASSAgent.Extensions;
using HASSAgent.Shared.Models.Config;
using HASSAgent.Shared.Models.Config.Service;
using Serilog;

namespace HASSAgent.Service
{
    internal partial class RpcClientService
    {
        /// <summary>
        /// Sets the provided devicename, triggering a re-registering of the service (and all entities) with HA
        /// </summary>
        /// <param name="deviceName"></param>
        /// <returns></returns>
        internal async Task<(bool result, string error)> SetDeviceNameAsync(string deviceName)
        {
            try
            {
                var setDeviceNameRequest = new SetDeviceNameRequest
                {
                    Auth = Variables.AppSettings.ServiceAuthId,
                    Devicename = deviceName
                };

                var response = await _rpcClient.SetDeviceNameAsync(setDeviceNameRequest);
                if (response.Ok) return (true, string.Empty);

                Log.Error("[SERVICE] SetDeviceName request failed: {err}", response.Error);
                return (false, response.Error);
            }
            catch (RpcException ex)
            {
                Log.Error("[SERVICE] RPC error [{code}]: {err}", ex.StatusCode.ToString(), ex.Message);
                return (false, $"failed with status: {ex.StatusCode}");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SERVICE] Error: {err}", ex.Message);
                return (false, "fatal error");
            }
        }

        /// <summary>
        /// Sets and activates the provided settings
        /// <para>DeviceName will be ignored, use SetDeviceNameAsync</para>
        /// </summary>
        /// <param name="serviceSettings"></param>
        /// <returns></returns>
        internal async Task<(bool result, string error)> SetServiceSettingsAsync(ServiceSettings serviceSettings)
        {
            try
            {
                var setServiceSettingsRequest = new SetServiceSettingsRequest
                {
                    Auth = Variables.AppSettings.ServiceAuthId,
                    ServiceSettings = serviceSettings.ConvertToRpcServiceSettings()
                };

                var response = await _rpcClient.SetServiceSettingsAsync(setServiceSettingsRequest);
                if (response.Ok) return (true, string.Empty);

                Log.Error("[SERVICE] SetServiceSettings request failed: {err}", response.Error);
                return (false, response.Error);
            }
            catch (RpcException ex)
            {
                Log.Error("[SERVICE] RPC error [{code}]: {err}", ex.StatusCode.ToString(), ex.Message);
                return (false, $"failed with status: {ex.StatusCode}");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SERVICE] Error: {err}", ex.Message);
                return (false, "fatal error");
            }
        }

        /// <summary>
        /// Sets and activates the provided settings, triggering a reconnect of the MQTT client
        /// </summary>
        /// <param name="serviceMqttSettings"></param>
        /// <returns></returns>
        internal async Task<(bool result, string error)> SetServiceMqttSettingsAsync(ServiceMqttSettings serviceMqttSettings)
        {
            try
            {
                var setServiceMqttSettingsRequest = new SetServiceMqttSettingsRequest
                {
                    Auth = Variables.AppSettings.ServiceAuthId,
                    ServiceMqttSettings = serviceMqttSettings.ConvertToRpcServiceMqttSettings()
                };

                var response = await _rpcClient.SetServiceMqttSettingsAsync(setServiceMqttSettingsRequest);
                if (response.Ok) return (true, string.Empty);

                Log.Error("[SERVICE] SetServiceMqttSettings request failed: {err}", response.Error);
                return (false, response.Error);
            }
            catch (RpcException ex)
            {
                Log.Error("[SERVICE] RPC error [{code}]: {err}", ex.StatusCode.ToString(), ex.Message);
                return (false, $"failed with status: {ex.StatusCode}");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SERVICE] Error: {err}", ex.Message);
                return (false, "fatal error");
            }
        }

        /// <summary>
        /// Syncs the service's command list with the provided list
        /// </summary>
        /// <param name="configuredCommands"></param>
        /// <returns></returns>
        internal async Task<(bool result, string error)> SetConfiguredCommandsAsync(List<ConfiguredCommand> configuredCommands)
        {
            try
            {
                var setConfiguredCommandsRequest = new SetConfiguredCommandsRequest
                {
                    Auth = Variables.AppSettings.ServiceAuthId
                };

                foreach (var configuredCommand in configuredCommands.ConvertToRpcConfiguredCommands()) setConfiguredCommandsRequest.ConfiguredServerCommands.Add(configuredCommand);

                var response = await _rpcClient.SetConfiguredCommandsAsync(setConfiguredCommandsRequest);
                if (response.Ok) return (true, string.Empty);

                Log.Error("[SERVICE] SetConfiguredCommands request failed: {err}", response.Error);
                return (false, response.Error);
            }
            catch (RpcException ex)
            {
                Log.Error("[SERVICE] RPC error [{code}]: {err}", ex.StatusCode.ToString(), ex.Message);
                return (false, $"failed with status: {ex.StatusCode}");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SERVICE] Error: {err}", ex.Message);
                return (false, "fatal error");
            }
        }

        /// <summary>
        /// Syncs the service's sensor list with the provided list
        /// </summary>
        /// <param name="configuredSensors"></param>
        /// <returns></returns>
        internal async Task<(bool result, string error)> SetConfiguredSensorsAsync(List<ConfiguredSensor> configuredSensors)
        {
            try
            {
                var setConfiguredSensorsRequest = new SetConfiguredSensorsRequest
                {
                    Auth = Variables.AppSettings.ServiceAuthId
                };

                foreach (var configuredSensor in configuredSensors.ConvertToRpcConfiguredSensors()) setConfiguredSensorsRequest.ConfiguredServerSensors.Add(configuredSensor);

                var response = await _rpcClient.SetConfiguredSensorsAsync(setConfiguredSensorsRequest);
                if (response.Ok) return (true, string.Empty);

                Log.Error("[SERVICE] SetConfiguredSensors request failed: {err}", response.Error);
                return (false, response.Error);
            }
            catch (RpcException ex)
            {
                Log.Error("[SERVICE] RPC error [{code}]: {err}", ex.StatusCode.ToString(), ex.Message);
                return (false, $"failed with status: {ex.StatusCode}");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SERVICE] Error: {err}", ex.Message);
                return (false, "fatal error");
            }
        }
    }
}
