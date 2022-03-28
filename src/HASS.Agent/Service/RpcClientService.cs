using System.Security.Principal;
using Grpc.Core;
using GrpcDotNetNamedPipes;
using Serilog;

namespace HASS.Agent.Service
{
    internal partial class RpcClientService
    {
        private readonly NamedPipeChannel _serviceChannel = new(".", Variables.PipeName, new NamedPipeChannelOptions 
            { 
                CurrentUserOnly = false, 
                ConnectionTimeout = (int)TimeSpan.FromSeconds(10).TotalMilliseconds
            });

        private readonly HassAgentSatelliteRpcCalls.HassAgentSatelliteRpcCallsClient _rpcClient;

        /// <summary>
        /// Initialize our RPC client
        /// </summary>
        internal RpcClientService() => _rpcClient = new HassAgentSatelliteRpcCalls.HassAgentSatelliteRpcCallsClient(_serviceChannel);

        /// <summary>
        /// Sends a PING request
        /// </summary>
        /// <returns></returns>
        internal async Task<(bool success, string version, string error)> PingAsync()
        {
            try
            {
                var response = await _rpcClient.PingAsync(new PingRequest());
                if (response.Ok) return (true, response.Version, string.Empty);

                Log.Error("[SERVICE] Ping request failed: {err}", response.Error);
                return (false, string.Empty, response.Error);
            }
            catch (RpcException ex)
            {
                Log.Error("[SERVICE] RPC error [{code}]: {err}", ex .StatusCode.ToString(), ex.Message);
                return (false, string.Empty, $"failed with status: {ex.StatusCode}");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SERVICE] Error: {err}", ex.Message);
                return (false, string.Empty, "fatal error");
            }
        }

        /// <summary>
        /// Asks the service to clear all its entities locally and in HA
        /// </summary>
        /// <returns></returns>
        internal async Task<(bool success, string error)> ClearEntitiesAsync()
        {
            try
            {
                var response = await _rpcClient.ClearEntitiesAsync(new ClearEntitiesRequest { Auth = Variables.AppSettings.ServiceAuthId });
                if (response.Ok) return (true, string.Empty);

                Log.Error("[SERVICE] ClearEntities request failed: {err}", response.Error);
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
        /// Asks the service to nicely shutdown
        /// </summary>
        /// <returns></returns>
        internal async Task<(bool success, string error)> ShutdownServiceAsync()
        {
            try
            {
                var response = await _rpcClient.ShutdownServiceAsync(new ShutdownServiceRequest { Auth = Variables.AppSettings.ServiceAuthId });
                if (response.Ok) return (true, string.Empty);

                Log.Error("[SERVICE] ShutdownService request failed: {err}", response.Error);
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
