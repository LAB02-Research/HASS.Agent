using System;
using System.Collections.Generic;
using System.IO;
using HASSAgent.Enums;
using HASSAgent.Models;
using Newtonsoft.Json;
using Serilog;

namespace HASSAgent.Settings
{
    /// <summary>
    /// Handles loading and storing quickactions
    /// </summary>
    internal static class StoredQuickActions
    {
        /// <summary>
        /// Load all stored quickactions
        /// </summary>
        /// <returns></returns>
        internal static bool Load()
        {
            try
            {
                // add an empty list
                Variables.QuickActions = new List<QuickAction>();

                // check for existing file
                if (!File.Exists(Variables.QuickActionsFile))
                {
                    // none yet
                    Log.Information("[SETTINGS_QUICKACTIONS] Config not found, no entities loaded");
                    Variables.FrmM?.SetQuickActionsStatus(ComponentStatus.Stopped);
                    return true;
                }

                // read the content
                var quickActionsRaw = File.ReadAllText(Variables.QuickActionsFile);
                if (string.IsNullOrWhiteSpace(quickActionsRaw))
                {
                    Log.Information("[SETTINGS_QUICKACTIONS] Config empty, no entities loaded");
                    Variables.FrmM?.SetQuickActionsStatus(ComponentStatus.Stopped);
                    return true;
                }

                // deserialize
                Variables.QuickActions = JsonConvert.DeserializeObject<List<QuickAction>>(quickActionsRaw);

                // null-check
                if (Variables.QuickActions == null)
                {
                    Log.Error("[SETTINGS_QUICKACTIONS] Error loading entities: returned null object");
                    Variables.FrmM?.SetQuickActionsStatus(ComponentStatus.Failed);
                    Variables.QuickActions = new List<QuickAction>();
                    return false;
                }

                // all good
                Log.Information("[SETTINGS_QUICKACTIONS] Loaded {count} entities", Variables.QuickActions.Count);
                Variables.FrmM?.SetQuickActionsStatus(ComponentStatus.Ok);
                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SETTINGS_QUICKACTIONS] Error loading entities: {err}", ex.Message);
                Variables.FrmM?.ShowMessageBox($"Error loading quick actions:\r\n\r\n{ex.Message}", true);

                Variables.FrmM?.SetQuickActionsStatus(ComponentStatus.Failed);
                return false;
            }
        }

        /// <summary>
        /// Store all current quickactions
        /// </summary>
        /// <returns></returns>
        internal static bool Store()
        {
            try
            {
                // serialize to file
                var quickActions = JsonConvert.SerializeObject(Variables.QuickActions, Formatting.Indented);
                File.WriteAllText(Variables.QuickActionsFile, quickActions);

                // done
                Log.Information("[SETTINGS_QUICKACTIONS] Stored {count} entities", Variables.QuickActions.Count);
                Variables.FrmM?.SetQuickActionsStatus(ComponentStatus.Ok);
                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SETTINGS_QUICKACTIONS] Error storing entities: {err}", ex.Message);
                Variables.FrmM?.ShowMessageBox($"Error storing quick actions:\r\n\r\n{ex.Message}", true);

                Variables.FrmM?.SetQuickActionsStatus(ComponentStatus.Failed);
                return false;
            }
        }
    }
}
