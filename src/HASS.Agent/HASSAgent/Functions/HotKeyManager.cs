using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HASSAgent.HomeAssistant;
using Serilog;
using WK.Libraries.HotkeyListenerNS;

namespace HASSAgent.Functions
{
    internal class HotKeyManager
    {
        /// <summary>
        /// Initializes the quickaction hotkeys
        /// </summary>
        internal void InitializeQuickActionsHotKeys()
        {
            Variables.UiDispatcher?.BeginInvoke(new MethodInvoker(delegate
            {
                // first the global hotkey
                InitializeGlobalQuickActionsHotKey();

                // then the individual hotkeys
                InitializeIndividualQuickActionsHotKeys();
            }));
        }

        /// <summary>
        /// Reloads the global- and individual quickaction hotkey bindings
        /// </summary>
        internal void ReloadQuickActionsHotKeys()
        {
            Variables.UiDispatcher?.BeginInvoke(new MethodInvoker(delegate
            {
                // remove all bindings
                Variables.HotKeyListener?.RemoveAll();

                // reload
                InitializeQuickActionsHotKeys();
            }));
        }

        /// <summary>
        /// Looks up the specific quick action bound to the specified hotkey, and executes it
        /// </summary>
        /// <param name="hotkey"></param>
        internal void ProcessQuickActionHotKey(string hotkey)
        {
            if (string.IsNullOrEmpty(hotkey)) return;

            // check if we stil have the hotkey bound to a quickaction
            if (Variables.QuickActions.All(x => x.HotKey != hotkey))
            {
                Log.Warning("[HOTKEY] Registered hotkey no longer bound to a QuickAction: {hotkey}", hotkey);
                return;
            }

            // fetch the associated quickaction
            var quickAction = Variables.QuickActions.Find(x => x.HotKey == hotkey);
            if (!quickAction.HotKeyEnabled)
            {
                Log.Warning("[HOTKEY] QuickAction bound to hotkey has 'hotkey enabled' set to false: {hotkey}", hotkey);
                return;
            }

            // execute the command (don't wait)
            Task.Run(() => HassApiManager.ProcessQuickActionAsync(quickAction));
        }

        private void InitializeGlobalQuickActionsHotKey()
        {
            Variables.UiDispatcher?.BeginInvoke(new MethodInvoker(delegate
            {
                // check if the quick action hotkey's active
                if (!Variables.AppSettings.QuickActionsHotKeyEnabled) return;

                // check if it's configured
                if (Variables.QuickActionsHotKey == null || Variables.QuickActionsHotKey.ToString() == "None") return;

                // all good, bind
                Variables.HotKeyListener?.Add(Variables.QuickActionsHotKey);

                Log.Information("[HOTKEY] Completed bind for global quickaction hotkey");
            }));
        }

        private void InitializeIndividualQuickActionsHotKeys()
        {
            Variables.UiDispatcher?.BeginInvoke(new MethodInvoker(delegate
            {
                var count = 0;
                foreach (var quickAcion in Variables.QuickActions.Where(x => x.HotKeyEnabled && !string.IsNullOrWhiteSpace(x.HotKey)))
                {
                    try
                    {
                        Variables.HotKeyListener?.Add(new Hotkey(quickAcion.HotKey));
                        count++;
                    }
                    catch (Exception ex)
                    {
                        Log.Fatal(ex, "[HOTKEYS] Unable to bind individual quickaction hotkey '{hotkey}': {msg}", quickAcion.HotKey, ex.Message);
                    }
                }

                if (count == 0) return;
                Log.Information("[HOTKEY] Completed bind for {count} individual quickaction hotkeys", count);
            }));
        }

        /// <summary>
        /// Process a changed quickactions hotkey
        /// </summary>
        /// <param name="previousKey"></param>
        /// <param name="register"></param>
        internal void QuickActionsHotKeyChanged(Hotkey previousKey, bool register = true)
        {
            Variables.UiDispatcher?.BeginInvoke(new MethodInvoker(delegate
            {
                Variables.HotKeyListener?.Remove(previousKey);
                if (register && Variables.QuickActionsHotKey != null && Variables.QuickActionsHotKey.KeyCode != Keys.None) Variables.HotKeyListener?.Add(Variables.QuickActionsHotKey);
            }));
        }
    }
}
