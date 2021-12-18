using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HADotNet.Core;
using HADotNet.Core.Clients;
using HASSAgent.Enums;
using HASSAgent.Functions;
using HASSAgent.Models;
using Serilog;

namespace HASSAgent.HomeAssistant
{
    /// <summary>
    /// Uses HASS's API to fetch entities, their status and to execute actions (on, off, etc) 
    /// </summary>
    internal static class HassApiManager
    {
        private static ConfigClient _configClient;
        private static ServiceClient _serviceClient;
        private static EntityClient _entityClient;
        private static StatesClient _statesClient = null;
        
        internal static HassManagerStatus ManagerStatus = HassManagerStatus.Initialising;

        internal static List<string> AutomationList = new List<string>();
        internal static List<string> ScriptList = new List<string>();
        internal static List<string> InputBooleanList = new List<string>();
        internal static List<string> SceneList = new List<string>();
        internal static List<string> SwitchList = new List<string>();
        internal static List<string> LightList = new List<string>();

        private static readonly string[] OnStates = { "on", "playing", "open", "opening" };
        private static readonly string[] OffStates = { "off", "idle", "closed", "closing" };

        /// <summary>
        /// Initializes the HASS API manager, establishes a connection and loads the entities
        /// </summary>
        /// <returns></returns>
        internal static async Task<HassManagerStatus> InitializeAsync()
        {
            try
            {
                // do we have the required settings?
                if (!CheckSettings())
                {
                    ManagerStatus = HassManagerStatus.ConfigMissing;
                    Variables.MainForm?.SetHassApiStatus(ComponentStatus.Stopped);
                    return ManagerStatus;
                }
                
                // initialize hass client
                var hassUri = new Uri(Variables.AppSettings.HassUri);
                ClientFactory.Initialize(hassUri, Variables.AppSettings.HassToken);

                // retrieve config
                _configClient = ClientFactory.GetClient<ConfigClient>();
                var config = await _configClient.GetConfiguration();
                Log.Information("[HASS_API] Home Assistant version: {version}", config.Version);

                // prepare clients
                _serviceClient = ClientFactory.GetClient<ServiceClient>();
                _entityClient = ClientFactory.GetClient<EntityClient>();
                _statesClient = ClientFactory.GetClient<StatesClient>();

                // load entities
                ManagerStatus = HassManagerStatus.LoadingData;
                await LoadEntitiesAsync();

                // start periodic state retriever
                _ = Task.Run(PeriodicStatusUpdates);

                // start periodic entity reloading
                _ = Task.Run(PeriodicEntityReload);

                // done
                Log.Information("[HASS_API] System connected with {ip}", Variables.AppSettings.HassUri);
                Variables.MainForm?.SetHassApiStatus(ComponentStatus.Ok);

                ManagerStatus = HassManagerStatus.Ready;
                return ManagerStatus;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[HASS_API] Error while initializing: {err}", ex.Message);

                Variables.MainForm?.SetHassApiStatus(ComponentStatus.Failed);
                ManagerStatus = HassManagerStatus.Failed;

                Variables.MainForm?.ShowToolTip("hass api: connection failed", true);
                return ManagerStatus;
            }
        }

        /// <summary>
        /// Checks the provided provided credentials to see if we can connect
        /// <para>This will disconnect any current connections!</para>
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        internal static async Task<(bool success, string message)> CheckHassConfigAsync(string uri, string apiKey)
        {
            try
            {
                var hassUri = new Uri(Variables.AppSettings.HassUri);

                // initialize hass client
                if (ClientFactory.IsInitialized) ClientFactory.Reset();
                ClientFactory.Initialize(uri, apiKey);

                // check if we're initialized
                if (!ClientFactory.IsInitialized) return (false, "unable to connect, check uri");

                // check if we can fetch config
                _configClient = ClientFactory.GetClient<ConfigClient>();
                var config = await _configClient.GetConfiguration();
                if (config == null) return (false, "unable to fetch config, check api key");

                // looks ok
                return (true, config.Version);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[HASS_API] Error while checking config: {err}", ex.Message);
                return (false, "unable to connect, check uri");
            }
            finally
            {
                // reset if we're intialised
                if (ClientFactory.IsInitialized) ClientFactory.Reset();
            }
        }

        /// <summary>
        /// Check whether the HASS config is available
        /// </summary>
        /// <returns></returns>
        private static bool CheckSettings()
        {
            // todo: check data values
            if (!string.IsNullOrEmpty(Variables.AppSettings.HassUri) && !string.IsNullOrEmpty(Variables.AppSettings.HassToken)) return true;

            return false;
        }

        /// <summary>
        /// Fetches all entities from HASS
        /// </summary>
        /// <returns></returns>
        private static async Task LoadEntitiesAsync(bool clearCurrent = false)
        {
            if (clearCurrent)
            {
                // clear current lists
                AutomationList.Clear();
                ScriptList.Clear();
                InputBooleanList.Clear();
                SceneList.Clear();
                SwitchList.Clear();
                LightList.Clear();
            }

            var domain = "automation";
            var entities = await _entityClient.GetEntities(domain);
            foreach (var automation in entities)
            {
                AutomationList.Add(automation.Remove(0, domain.Length + 1));
            }

            domain = "script";
            entities = await _entityClient.GetEntities(domain);
            foreach (var script in entities)
            {
                ScriptList.Add(script.Remove(0, domain.Length + 1));
            }

            domain = "input_boolean";
            entities = await _entityClient.GetEntities(domain);
            foreach (var inputboolean in entities)
            {
                InputBooleanList.Add(inputboolean.Remove(0, domain.Length + 1));
            }

            domain = "scene";
            entities = await _entityClient.GetEntities(domain);
            foreach (var scene in entities)
            {
                SceneList.Add(scene.Remove(0, domain.Length + 1));
            }

            domain = "switch";
            entities = await _entityClient.GetEntities(domain);
            foreach (var @switch in entities)
            {
                SwitchList.Add(@switch.Remove(0, domain.Length + 1));
            }

            domain = "light";
            entities = await _entityClient.GetEntities(domain);
            foreach (var light in entities)
            {
                LightList.Add(light.Remove(0, domain.Length + 1));
            }
        }

        /// <summary>
        /// Executes the quick action
        /// </summary>
        /// <param name="quickAction"></param>
        /// <returns></returns>
        internal static async Task ProcessQuickActionAsync(QuickAction quickAction)
        {
            await ProcessActionAsync(quickAction.ToHassEntity(), quickAction.Action);
        }

        /// <summary>
        /// Executes the desired action on the entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        internal static async Task<bool> ProcessActionAsync(HassEntity entity, HassAction action)
        {
            var actionVal = action.GetDescription();
            var domainVal = entity.Domain.GetDescription();
            var entityVal = entity.Entity.ToLower();

            try
            {
                // check if the states client is up
                if (_statesClient == null) return false;

                Log.Information("[HASS_API] [{domain}.{entity}] Performing action: {action}", domainVal, entityVal, actionVal);

                var fullEntity = $"{domainVal}.{entityVal}";

                // if a toggle is requested, we need to know its current state
                if (action == HassAction.Toggle)
                {
                    // try to find the entity
                    var state = await _statesClient.GetState(fullEntity);

                    // toggle based on state
                    if (OnStates.Contains(state.State))
                    {
                        Log.Information("[HASS_API] [{domain}.{entity}] Entity currently ON, changing action to 'turn_off'", domainVal, entityVal);
                        action = HassAction.Off;
                        actionVal = action.GetDescription();
                    }
                    else if (OffStates.Contains(state.State))
                    {
                        Log.Information("[HASS_API] [{domain}.{entity}] Entity currently OFF, changing action to 'turn_on'", domainVal, entityVal);
                        action = HassAction.On;
                        actionVal = action.GetDescription();
                    }
                    else
                    {
                        Log.Information("[HASS_API] [{domain}.{entity}] Entity in unknown state ({state}), defaulting to 'turn_on'", domainVal, entityVal, state.State);
                        action = HassAction.On;
                        actionVal = action.GetDescription();
                    }
                }

                // determine service
                var service = DetermineServiceForDomain(entity.Domain, action);

                // process the request
                var _ = await _serviceClient.CallService(service, $@"{{""entity_id"":""{fullEntity}""}}");

                // done
                Log.Information("[HASS_API] [{domain}.{entity}] Action completed: {action}", domainVal, entityVal, actionVal);
                return true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("code 404"))
                {
                    Log.Error("[HASS_API] [{domain}.{entity}] Error while processing action: entity not found", domainVal, entityVal);
                    return false;
                }

                Log.Fatal(ex, "[HASS_API] [{domain}.{entity}] Error while processing action: {ex}", domainVal, entityVal, ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Periodically fetches all entities
        /// </summary>
        private static async void PeriodicEntityReload()
        {
            while (!Variables.ShuttingDown)
            {
                // wait a while
                await Task.Delay(TimeSpan.FromMinutes(30));

                // check if we can connect
                try
                {
                    var res = await _configClient.GetConfiguration();
                    if (res == null)
                    {
                        Log.Warning("[HASS_API] Unable to contact API, skipping entity reload");
                        continue;
                    }
                }
                catch
                {
                    Log.Warning("[HASS_API] Unable to contact API, skipping entity reload");
                    continue;
                }

                // reload all entities
                await LoadEntitiesAsync(true);
            }
        }

        /// <summary>
        /// Periodically gets the status of all the QuickActions
        /// <para>If we don't do this, it takes 10 seconds to get the state after idleing a while</para>
        /// </summary>
        private static async void PeriodicStatusUpdates()
        {
            while (!Variables.ShuttingDown)
            {
                await Task.Delay(TimeSpan.FromSeconds(3));

                foreach (var quickAction in Variables.QuickActions)
                {
                    try
                    {
                        var entity = quickAction.ToHassEntity();

                        var domainVal = entity.Domain.GetDescription();
                        var entityVal = entity.Entity.ToLower();
                        var fullEntity = $"{domainVal}.{entityVal}";

                        _ = await _statesClient.GetState(fullEntity);

                        if (Variables.ShuttingDown) return;
                    }
                    catch (HttpRequestException ex)
                    {
                        if (Variables.ShuttingDown) return;

                        if (ex.Message.Contains("404"))
                        {
                            Log.Warning("[HASS] Server returned 404 (not found) while getting entity state, this can happen after a server reboot. If the problem persists, please file a ticket on github.\r\nError message: {err}", ex.Message);
                            return;
                        }

                        Log.Fatal(ex, "[HASS] HTTP error while sending periodic status update: {err}", ex.Message);
                    }
                    catch (Exception ex)
                    {
                        if (Variables.ShuttingDown) return;
                        Log.Fatal(ex, "[HASS] Error while sending periodic status update: {err}", ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Determines the full service call for the domain and action
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        private static string DetermineServiceForDomain(HassDomain domain, HassAction action)
        {
            var domainValue = domain.GetDescription();
            var actionValue = action.GetDescription();

            return $"{domainValue}.{actionValue}";

            //case HassDomain.Cover:
            //    return on ? "cover.open_cover" : "cover.close_cover";

            //case "water_heater":
            //    return on ? "water_heater.turn_on" : "water_heater.turn_off";

            //case "climate":
            //    return on ? "climate.turn_on" : "climate.turn_off";

            //case "media_player":
            //    return on ? "media_player.media_play" : "media_player.media_stop";
        }
    }
}
