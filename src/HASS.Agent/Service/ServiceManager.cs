using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using HASS.Agent.Enums;
using HASS.Agent.Functions;
using HASS.Agent.Shared.Functions;
using Microsoft.Win32;
using Serilog;

namespace HASS.Agent.Service
{
    internal static class ServiceManager
    {
        /// <summary>
        /// Initializes the satellite service manager
        /// </summary>
        internal static void Initialize()
        {
            try
            {
                // fetch the local installation path and set the log path etc
                var ioLoaded = SetSatelliteServiceLocalStorage();
                if (!ioLoaded)
                {
                    Variables.MainForm?.SetServiceStatus(ComponentStatus.Failed);
                    return;
                }

                // does it exist?
                if (!ServiceControllerManager.ServiceExists())
                {
                    Variables.MainForm?.SetServiceStatus(ComponentStatus.Disabled);
                    return;
                }

                // yep, get state
                var state = ServiceControllerManager.GetServiceState();

                // process accordingly
                switch (state)
                {
                    case ServiceControllerStatus.Running:
                        Variables.MainForm?.SetServiceStatus(ComponentStatus.Ok);
                        return;
                    case ServiceControllerStatus.Stopped:
                        Variables.MainForm?.SetServiceStatus(ComponentStatus.Stopped);
                        return;
                    default:
                        Variables.MainForm?.SetServiceStatus(ComponentStatus.Failed);
                        return;
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SERVICE] Error initializing: {err}", ex.Message);
            }
        }

        /// <summary>
        /// Sets the local install paths (if found)
        /// <para>By default handled by Initialize(), only call on child applications</para>
        /// </summary>
        /// <returns></returns>
        internal static bool SetSatelliteServiceLocalStorage()
        {
            // get service binary & log path
            var installPath = GetInstallPath();
            if (string.IsNullOrEmpty(installPath)) return false;

            // set local io
            Variables.SatelliteServiceRootPath = installPath;
            Variables.SatelliteServiceBinary = Path.Combine(installPath, "HASS.Agent.Satellite.Service.exe");
            Variables.SatelliteServiceLogPath = Path.Combine(installPath, "logs");

            // done
            return true;
        }

        /// <summary>
        /// Gets the 'extended logging' setting from registry, or the default location
        /// </summary>
        /// <returns></returns>
        internal static string GetInstallPath()
        {
            try
            {
                // should be in reg
                var installPath = (string)Registry.GetValue(Variables.SatelliteMachineRootRegKey, "InstallPath", string.Empty);
                if (!string.IsNullOrEmpty(installPath))
                {
                    Log.Information("[SERVICE] Local install path: {path}", installPath);
                    return installPath;
                }

                // not found, probably first launch, try defaults
                var defaultDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "LAB02 Research", "HASS.Agent Satellite Service");
                if (Directory.Exists(defaultDir)) return defaultDir;

                defaultDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "LAB02 Research", "HASS.Agent Satellite Service");
                if (Directory.Exists(defaultDir)) return defaultDir;

                defaultDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "LAB02 Research", "HASS.Agent Satellite Service");
                if (Directory.Exists(defaultDir)) return defaultDir;

                // nothing
                Log.Error("[SERVICE] Unable to retrieve install path from service, and default path not found");
                return string.Empty;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SERVICE] Error retrieving startup path: {err}", ex.Message);
                return string.Empty;
            }
        }
    }
}
