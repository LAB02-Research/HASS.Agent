using System.IO;
using HASS.Agent.Commands;
using HASS.Agent.Enums;
using HASS.Agent.Models.Config;
using HASS.Agent.Models.Internal;
using HASS.Agent.Resources.Localization;
using HASS.Agent.Sensors;
using HASS.Agent.Shared;
using HASS.Agent.Shared.HomeAssistant.Commands;
using HASS.Agent.Shared.HomeAssistant.Sensors;
using HASS.Agent.Shared.Models.Config.Service;
using HASS.Agent.Shared.Models.HomeAssistant;
using Microsoft.Win32;
using Newtonsoft.Json;
using Serilog;
using Syncfusion.Windows.Forms;
using WK.Libraries.HotkeyListenerNS;

namespace HASS.Agent.Settings
{
    /// <summary>
    /// Handles loading and storing objects and settings
    /// </summary>
    internal class SettingsManager
    {
        /// <summary>
        /// Load all stored settings and objects
        /// </summary>
        /// <param name="createInitialSettings"></param>
        /// <returns></returns>
        internal static async Task<bool> LoadAsync(bool createInitialSettings = true)
        {
            Log.Information("[SETTINGS] Config storage path: {path}", Variables.ConfigPath);
            
            // check config dir
            if (!Directory.Exists(Variables.ConfigPath))
            {
                // only create initial settings when asked
                if (!createInitialSettings)
                {
                    StoreInitialSettings(false);
                    return true;
                }

                // create dir
                Directory.CreateDirectory(Variables.ConfigPath);

                // create default config
                StoreInitialSettings();

                // set onboarding
                Variables.AppSettings.OnboardingStatus = OnboardingStatus.NeverDone;

                // done
                return true;
            }

            var allGood = true;

            // load app settings
            var ok = await Task.Run(LoadAppSettings);
            if (!ok) allGood = false;
            
            // done
            return allGood;
        }

        /// <summary>
        /// Loads all entities (quick actions, commands and sensors)
        /// </summary>
        /// <returns></returns>
        internal static async Task<bool> LoadEntitiesAsync()
        {
            var allGood = true;

            await Task.Run(delegate
            {
                CommandsManager.LoadCommandInfo();
                SensorsManager.LoadSensorInfo();
            });

            // load quick actions
            var ok = StoredQuickActions.Load();
            if (!ok) allGood = false;

            // load commands
            ok = await StoredCommands.LoadAsync();
            if (!ok) allGood = false;

            // load sensors
            ok = await StoredSensors.LoadAsync();
            if (!ok) allGood = false;

            // done
            return allGood;
        }

        /// <summary>
        /// Load stored application settings
        /// </summary>
        /// <returns></returns>
        private static bool LoadAppSettings()
        {
            try
            {
                if (!File.Exists(Variables.AppSettingsFile))
                {
                    // store default settings
                    StoreInitialSettings();

                    // set onboarding
                    Variables.AppSettings.OnboardingStatus = OnboardingStatus.NeverDone;

                    // done
                    return true;
                }

                var appSettingsRaw = File.ReadAllText(Variables.AppSettingsFile);
                if (string.IsNullOrWhiteSpace(appSettingsRaw)) return true;

                // get the global settings
                Variables.AppSettings = JsonConvert.DeserializeObject<AppSettings>(appSettingsRaw);
                if (Variables.AppSettings == null)
                {
                    // something went wrong, but we're not saving new ones, user might want to recover values
                    Log.Error("[SETTINGS] Error loading settings: returned null object");
                    return false;
                }

                // fix onboarding status for backwards compat.
                if (Variables.AppSettings.OnboardingStatus == OnboardingStatus.NeverDone)
                {
                    Variables.AppSettings.OnboardingStatus = OnboardingStatus.Completed;
                    StoreAppSettings();
                }

                // set shared config
                AgentSharedBase.SetDeviceName(Variables.AppSettings.DeviceName);
                AgentSharedBase.SetCustomExecutorBinary(Variables.AppSettings.CustomExecutorBinary);

                // load the hotkey
                Variables.QuickActionsHotKey = string.IsNullOrEmpty(Variables.AppSettings.QuickActionsHotKey) ? null : HotkeyListener.Convert(Variables.AppSettings.QuickActionsHotKey);

                // done
                Log.Information("[SETTINGS] Configuration loaded");
                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SETTINGS] Error loading app settings: {err}", ex.Message);
                Variables.MainForm?.ShowMessageBox(string.Format(Languages.SettingsManager_LoadAppSettings_MessageBox1, ex.Message), true);
                return false;
            }
        }

        /// <summary>
        /// Store default settings
        /// </summary>
        /// <returns></returns>
        private static bool StoreInitialSettings(bool storeSettings = true)
        {
            try
            {
                Log.Information("[SETTINGS] No config found, storing default settings");

                // empty collections
                Variables.QuickActions = new List<QuickAction>();
                Variables.Commands = new List<AbstractCommand>();
                Variables.SingleValueSensors = new List<AbstractSingleValueSensor>();
                Variables.MultiValueSensors = new List<AbstractMultiValueSensor>();

                // default settings
                Variables.AppSettings = new AppSettings();

                // store ?
                if (!storeSettings) return true;

                // jep
                var appSettings = JsonConvert.SerializeObject(Variables.AppSettings, Formatting.Indented);
                File.WriteAllText(Variables.AppSettingsFile, appSettings);
                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SETTINGS] Error storing initial settings: {err}", ex.Message);
                Variables.MainForm?.ShowMessageBox(string.Format(Languages.SettingsManager_StoreInitialSettings_MessageBox1, ex.Message), true);
                return false;
            }
        }

        /// <summary>
        /// Store all settings and objects
        /// </summary>
        /// <returns></returns>
        internal static bool Store()
        {
            // start positive
            var allGood = true;

            // store app settings
            var ok = StoreAppSettings();
            if (!ok) allGood = false;

            // store quick settings
            ok = StoredQuickActions.Store();
            if (!ok) allGood = false;

            // store commands
            ok = StoredCommands.Store();
            if (!ok) allGood = false;

            // store sensors
            ok = StoredSensors.Store();
            if (!ok) allGood = false;

            // done
            return allGood;
        }

        /// <summary>
        /// Store current application settings
        /// </summary>
        /// <returns></returns>
        internal static bool StoreAppSettings()
        {
            try
            {
                // check config dir
                if (!Directory.Exists(Variables.ConfigPath))
                {
                    // create
                    Directory.CreateDirectory(Variables.ConfigPath);
                }

                // serialize to file
                var appSettings = JsonConvert.SerializeObject(Variables.AppSettings, Formatting.Indented);
                File.WriteAllText(Variables.AppSettingsFile, appSettings);

                // done
                Log.Information("[SETTINGS] Configuration stored");
                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SETTINGS] Error storing app settings: {err}", ex.Message);
                Variables.MainForm?.ShowMessageBox(string.Format(Languages.SettingsManager_StoreAppSettings_MessageBox1, ex.Message), true);
                return false;
            }
        }

        /// <summary>
        /// Gets the 'extended logging' setting from registry
        /// </summary>
        /// <returns></returns>
        internal static bool GetExtendedLoggingSetting()
        {
            try
            {
                var setting = (string)Registry.GetValue(Variables.RootRegKey, "ExtendedLogging", "0");
                if (string.IsNullOrEmpty(setting)) return false;

                return setting == "1";
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SETTINGS] Error retrieving extended logging setting: {err}", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Stores the 'extended logging' setting in registry
        /// </summary>
        /// <param name="enabled"></param>
        internal static void SetExtendedLoggingSetting(bool enabled)
        {
            try
            {
                Registry.SetValue(Variables.RootRegKey, "ExtendedLogging", enabled ? "1" : "0", RegistryValueKind.String);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SETTINGS] Error storing extended logging setting: {err}", ex.Message);
            }
        }

        /// <summary>
        /// Gets the 'dpi warning shown' setting from registry
        /// </summary>
        /// <returns></returns>
        internal static bool GetDpiWarningShown()
        {
            try
            {
                var setting = (string)Registry.GetValue(Variables.RootRegKey, "DpiWarningShown", "0");
                if (string.IsNullOrEmpty(setting)) return false;

                return setting == "1";
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SETTINGS] Error retrieving dpi-warning-shown setting: {err}", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Stores the 'dpi warning shown' setting in registry
        /// </summary>
        /// <param name="shown"></param>
        internal static void SetDpiWarningShown(bool shown)
        {
            try
            {
                Registry.SetValue(Variables.RootRegKey, "DpiWarningShown", shown ? "1" : "0", RegistryValueKind.String);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SETTINGS] Error storing dpi-warning-shown setting: {err}", ex.Message);
            }
        }
        
        /// <summary>
        /// Sends the current MQTT appsettings to the satellite service, optionally with a new client ID
        /// </summary>
        /// <returns></returns>
        internal static async Task<bool> SendMqttSettingsToServiceAsync(bool sendNewClientId = false)
        {
            try
            {
                // create settings obj
                var config = new ServiceMqttSettings
                {
                    MqttAddress = Variables.AppSettings.MqttAddress,
                    MqttPort = Variables.AppSettings.MqttPort,
                    MqttUseTls = Variables.AppSettings.MqttUseTls,
                    MqttUsername = Variables.AppSettings.MqttUsername,
                    MqttPassword = Variables.AppSettings.MqttPassword,
                    MqttDiscoveryPrefix = Variables.AppSettings.MqttDiscoveryPrefix,
                    MqttClientId = sendNewClientId ? Guid.NewGuid().ToString()[..8] : string.Empty,
                    MqttRootCertificate = Variables.AppSettings.MqttRootCertificate,
                    MqttClientCertificate = Variables.AppSettings.MqttClientCertificate,
                    MqttAllowUntrustedCertificates = Variables.AppSettings.MqttAllowUntrustedCertificates,
                    MqttUseRetainFlag = Variables.AppSettings.MqttUseRetainFlag
                };

                // store
                var (storedOk, _) = await Task.Run(async () => await Variables.RpcClient.SetServiceMqttSettingsAsync(config).WaitAsync(Variables.RpcConnectionTimeout));
                if (!storedOk)
                {
                    Log.Error("[SETTINGS] Sending MQTT settings to service failed");
                    return false;
                }

                // done
                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SETTINGS] Error sending MQTT settings to service: {err}", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Gets the device's serial number (unique, generated, stored)
        /// </summary>
        /// <returns></returns>
        internal static string DeviceSerialNumber()
        {
            var guid = (string)Registry.GetValue(Variables.RootRegKey, "DeviceSerialNumber", string.Empty);
            if (string.IsNullOrEmpty(guid))
            {
                guid = Guid.NewGuid().ToString();
                StoreDeviceSerialNumber(guid);
            }

            return guid;
        }
        
        private static void StoreDeviceSerialNumber(string guid)
        {
            Registry.SetValue(Variables.RootRegKey, "DeviceSerialNumber", guid, RegistryValueKind.String);
        }

        /// <summary>
        /// Gets the 'hide donate button from the main window' setting from registry
        /// </summary>
        /// <returns></returns>
        internal static bool GetHideDonateButton()
        {
            try
            {
                var setting = (string)Registry.GetValue(Variables.RootRegKey, "HideDonateButton", "0");
                if (string.IsNullOrEmpty(setting)) return false;

                return setting == "1";
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SETTINGS] Error retrieving 'hide donate button from the main window' setting: {err}", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Stores the 'hide donate button from the main window' setting in registry
        /// </summary>
        /// <param name="hide"></param>
        internal static void SetHideDonateButton(bool hide)
        {
            try
            {
                Registry.SetValue(Variables.RootRegKey, "HideDonateButton", hide ? "1" : "0", RegistryValueKind.String);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SETTINGS] Error storing 'hide donate button from the main window' setting: {err}", ex.Message);
            }
        }
    }
}
