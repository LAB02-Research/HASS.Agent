using Grpc.Core;
using HASS.Agent.Extensions;
using HASS.Agent.Shared.Enums;
using HASS.Agent.Shared.Models.Config;
using HASS.Agent.Shared.Models.Config.Service;
using Serilog;

namespace HASS.Agent.Service
{
    internal partial class RpcClientService
    {
        /// <summary>
        /// Returns the service's current devicename as registered in HA
        /// </summary>
        /// <returns></returns>
        internal async Task<(bool result, string output, string error)> GetDeviceNameAsync()
        {
            try
            {
                var response = await _rpcClient.GetDeviceNameAsync(new GetDeviceNameRequest { Auth = Variables.AppSettings.ServiceAuthId });
                if (response.Ok) return (true, response.DeviceName, string.Empty);

                Log.Error("[SERVICE] GetDeviceName request failed: {err}", response.Error);
                return (false, string.Empty, response.Error);
            }
            catch (RpcException ex)
            {
                Log.Error("[SERVICE] RPC error [{code}]: {err}", ex.StatusCode.ToString(), ex.Message);
                return (false, string.Empty, $"failed with status: {ex.StatusCode}");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SERVICE] Error: {err}", ex.Message);
                return (false, string.Empty, "fatal error");
            }
        }

        /// <summary>
        /// Returns the service's MQTT connection state
        /// </summary>
        /// <returns></returns>
        internal async Task<(bool result, MqttStatus status, string error)> GetMqttStatusAsync()
        {
            try
            {
                var response = await _rpcClient.GetMqttStatusAsync(new GetMqttStatusRequest { Auth = Variables.AppSettings.ServiceAuthId });
                if (response.Ok) return (true, (MqttStatus)response.MqttStatus, string.Empty);

                Log.Error("[SERVICE] GetMqttStatus request failed: {err}", response.Error);
                return (false, MqttStatus.Error, response.Error);
            }
            catch (RpcException ex)
            {
                Log.Error("[SERVICE] RPC error [{code}]: {err}", ex.StatusCode.ToString(), ex.Message);
                return (false, MqttStatus.Error, $"failed with status: {ex.StatusCode}");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SERVICE] Error: {err}", ex.Message);
                return (false, MqttStatus.Error, "fatal error");
            }
        }

        /// <summary>
        /// Returns the service's current active settings
        /// </summary>
        /// <returns></returns>
        internal async Task<(bool result, ServiceSettings output, string error)> GetServiceSettingsAsync()
        {
            try
            {
                var response = await _rpcClient.GetServiceSettingsAsync(new GetServiceSettingsRequest { Auth = Variables.AppSettings.ServiceAuthId });
                if (response.Ok) return (true, response.ServiceSettings.ConvertToServiceSettings(), string.Empty);

                Log.Error("[SERVICE] GetServiceSettings request failed: {err}", response.Error);
                return (false, null, response.Error);
            }
            catch (RpcException ex)
            {
                Log.Error("[SERVICE] RPC error [{code}]: {err}", ex.StatusCode.ToString(), ex.Message);
                return (false, null, $"failed with status: {ex.StatusCode}");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SERVICE] Error: {err}", ex.Message);
                return (false, null, "fatal error");
            }
        }

        /// <summary>
        /// Returns the service's current active MQTT settings
        /// </summary>
        /// <returns></returns>
        internal async Task<(bool result, ServiceMqttSettings output, string error)> GetServiceMqttSettingsAsync()
        {
            try
            {
                var response = await _rpcClient.GetServiceMqttSettingsAsync(new GetServiceMqttSettingsRequest { Auth = Variables.AppSettings.ServiceAuthId });
                if (response.Ok) return (true, response.ServiceMqttSettings.ConvertToServiceMqttSettings(), string.Empty);

                Log.Error("[SERVICE] GetServiceMqttSettings request failed: {err}", response.Error);
                return (false, null, response.Error);
            }
            catch (RpcException ex)
            {
                Log.Error("[SERVICE] RPC error [{code}]: {err}", ex.StatusCode.ToString(), ex.Message);
                return (false, null, $"failed with status: {ex.StatusCode}");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SERVICE] Error: {err}", ex.Message);
                return (false, null, "fatal error");
            }
        }

        /// <summary>
        /// Returns the service's current active configured commands
        /// </summary>
        /// <returns></returns>
        internal async Task<(bool result, List<ConfiguredCommand> output, string error)> GetConfiguredCommandsAsync()
        {
            try
            {
                var response = await _rpcClient.GetConfiguredCommandsAsync(new GetConfiguredCommandsRequest { Auth = Variables.AppSettings.ServiceAuthId });
                if (response.Ok) return (true, response.ConfiguredServerCommands.ConvertToConfiguredCommands(), string.Empty);

                Log.Error("[SERVICE] GetConfiguredCommands request failed: {err}", response.Error);
                return (false, null, response.Error);
            }
            catch (RpcException ex)
            {
                Log.Error("[SERVICE] RPC error [{code}]: {err}", ex.StatusCode.ToString(), ex.Message);
                return (false, null, $"failed with status: {ex.StatusCode}");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SERVICE] Error: {err}", ex.Message);
                return (false, null, "fatal error");
            }
        }

        /// <summary>
        /// Returns the service's current active sensors
        /// </summary>
        /// <returns></returns>
        internal async Task<(bool result, List<ConfiguredSensor> output, string error)> GetConfiguredSensorsAsync()
        {
            try
            {
                var response = await _rpcClient.GetConfiguredSensorsAsync(new GetConfiguredSensorsRequest { Auth = Variables.AppSettings.ServiceAuthId });
                if (response.Ok) return (true, response.ConfiguredServerSensors.ConvertToConfiguredSensors(), string.Empty);

                Log.Error("[SERVICE] GetConfiguredSensors request failed: {err}", response.Error);
                return (false, null, response.Error);
            }
            catch (RpcException ex)
            {
                Log.Error("[SERVICE] RPC error [{code}]: {err}", ex.StatusCode.ToString(), ex.Message);
                return (false, null, $"failed with status: {ex.StatusCode}");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SERVICE] Error: {err}", ex.Message);
                return (false, null, "fatal error");
            }
        }
    }
}
