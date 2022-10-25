using HASS.Agent.Shared.Managers;
using Newtonsoft.Json;
using Serilog;

namespace HASS.Agent.Managers
{
    internal static class FirewallManager
    {
        /// <summary>
        /// Removes any existing HASS.Agent firewall rule
        /// </summary>
        /// <returns></returns>
        internal static async Task<bool> RemoveRule()
        {
            try
            {
                await CommandLineManager.ExecuteCommandAsync("netsh", "advfirewall firewall delete rule name=\"HASS.Agent Local API\"");
                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[FIREWALL] Error while removing rule: {msg}", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Creates a firewall rule for the specified port
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        internal static async Task<bool> CreateRule(int port)
        {
            try
            {
                // add the rule
                var consoleResult = await CommandLineManager.ExecuteCommandAsync("netsh", $"advfirewall firewall add rule name=\"HASS.Agent Local API\" dir=in action=allow protocol=TCP localport={port}");

                // error'd?
                if (consoleResult.Error)
                {
                    Log.Error("[FIREWALL] Error creating firewall rule, console output:\r\n{output}", JsonConvert.SerializeObject(consoleResult, Formatting.Indented));
                    return false;
                }

                // all good
                Log.Information("[FIREWALL] Succesfully created firewall rule on port: {port}", port);
                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[FIREWALL] Error while creating rule: {msg}", ex.Message);
                return false;
            }
        }
    }
}
