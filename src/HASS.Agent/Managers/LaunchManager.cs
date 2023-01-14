using Microsoft.Win32;
using Serilog;

namespace HASS.Agent.Managers
{
    internal static class LaunchManager
    {
        private const string RunKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
        private static readonly RegistryView RegView = Environment.Is64BitOperatingSystem ? RegistryView.Registry32 : RegistryView.Default;

        /// <summary>
        /// Checks whether the current executable has been set as run-on-login
        /// </summary>
        /// <returns></returns>
        internal static bool CheckLaunchOnUserLogin()
        {
            try
            {
                using var localKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegView);
                using var key = localKey.OpenSubKey(RunKey, false);
                var val = (string)key?.GetValue(Variables.ApplicationName, string.Empty);
                if (string.IsNullOrWhiteSpace(val)) return false;

                return val == $"\"{Variables.ApplicationExecutable}\"";
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[REG] Unable to get status of run-on-login: {msg}", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Places the executable in HKCU's run key
        /// </summary>
        /// <returns></returns>
        internal static bool EnableLaunchOnUserLogin()
        {
            try
            {
                using var localKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegView);
                using var key = localKey.CreateSubKey(RunKey, true);
                key.OpenSubKey("Run", true);
                key.SetValue(Variables.ApplicationName, $"\"{Variables.ApplicationExecutable}\"", RegistryValueKind.String);
                key.Flush();

                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[REG] Unable to set executable as run-on-login: {msg}", ex.Message);
                return false;
            }
        }


        /// <summary>
        /// Removes the executable from HKCU's run key
        /// </summary>
        /// <returns></returns>
        internal static bool DisableLaunchOnUserLogin()
        {
            try
            {
                using var localKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegView);
                using var key = localKey.OpenSubKey(RunKey, true);
                key?.DeleteValue(Variables.ApplicationName, false);
                key?.Flush();
                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[REG] Unable to remove executable from run-on-login: {msg}", ex.Message);
                return false;
            }
        }
    }
}
