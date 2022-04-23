using System.Diagnostics;
using System.Globalization;
using HASS.Agent.Enums;
using HASS.Agent.Forms;
using HASS.Agent.Forms.ChildApplications;
using HASS.Agent.Functions;
using HASS.Agent.Settings;
using HASS.Agent.Shared.Extensions;
using Serilog;

namespace HASS.Agent
{
    internal static class Program
    {
        /// <summary>
        /// Main entry point
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            try
            {
                // syncfusion license
                Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(Variables.SyncfusionLicense);
                
                // enable logging
                LoggingManager.PrepareLogging(args);

                // get extended logging settings
                Variables.ExtendedLogging = SettingsManager.GetExtendedLoggingSetting();

                if (Variables.ExtendedLogging)
                {
                    Log.Information("[MAIN] Extended logging enabled");

                    // make sure we catch 'm all
                    AppDomain.CurrentDomain.FirstChanceException += LoggingManager.CurrentDomainOnFirstChanceException;
                }
                
                // prepare application
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // check if we're a child application
                var childApp = LaunchAsChildApplication(args);

                // load app settings
                var settingsLoaded = SettingsManager.LoadAsync(!childApp).GetAwaiter().GetResult();
                if (!settingsLoaded)
                {
                    Log.Error("[PROGRAM] Something went wrong while loading the settings. Check appsettings.json, or delete the file to start fresh.");
                    Log.CloseAndFlush();
                    return;
                }

                // set ui culture
                LocalizationManager.Initialize();

                // set scaling
                Application.SetHighDpiMode(HighDpiMode.DpiUnawareGdiScaled);

                // set default font
                Application.SetDefaultFont(Variables.DefaultFont);

                // check to see if we're launched as a child application
                if (LaunchedAsChildApplication(args))
                {
                    // yep, nothing left to do
                    return;
                }

                // nope, prepare default application
                Variables.MainForm = new Main();

                // prepare msgbox
                HelperFunctions.SetMsgBoxStyle(Variables.DefaultFont);

                // run (hidden)
                Application.Run(new CustomApplicationContext(Variables.MainForm));
            }
            catch (AccessViolationException ex)
            {
                Log.Fatal(ex, "[PROGRAM] AccessViolationException: {err}", ex.Message);
                Log.CloseAndFlush();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[PROGRAM] {err}", ex.Message);
                Log.CloseAndFlush();
            }
        }

        /// <summary>
        /// Checks whether we're asked to launch as a child application
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        internal static bool LaunchAsChildApplication(string[] args)
        {
            return args.Any(x => x == "update")
                   || args.Any(x => x == "portreservation")
                   || args.Any(x => x == "restart")
                   || args.Any(x => x == "service_disable")
                   || args.Any(x => x == "service_enabled")
                   || args.Any(x => x == "service_start")
                   || args.Any(x => x == "service_stop")
                   || args.Any(x => x == "service_reinstall");
        }

        /// <summary>
        /// Launches as a child application according to the provided arguments
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private static bool LaunchedAsChildApplication(string[] args)
        {
            try
            {
                // post-update
                if (args.Any(x => x == "update"))
                {
                    Log.Information("[SYSTEM] Post-update mode activated");
                    Variables.ChildApplicationMode = true;

                    // prepare form
                    var postUpdate = new PostUpdate();

                    // prepare msgbox
                    HelperFunctions.SetMsgBoxStyle(Variables.DefaultFont);

                    // run
                    Application.Run(postUpdate);

                    // done
                    return true;
                }

                // port reservation
                if (args.Any(x => x == "portreservation"))
                {
                    Log.Information("[SYSTEM] Port reservation mode activated");
                    Variables.ChildApplicationMode = true;

                    // prepare form
                    var portReservation = new PortReservation();

                    // prepare msgbox
                    HelperFunctions.SetMsgBoxStyle(Variables.DefaultFont);

                    // run
                    Application.Run(portReservation);

                    // done
                    return true;
                }

                // restart hass.agent
                if (args.Any(x => x == "restart"))
                {
                    Log.Information("[SYSTEM] Restart mode activated");
                    Variables.ChildApplicationMode = true;

                    // prepare form
                    var restart = new Restart();

                    // prepare msgbox
                    HelperFunctions.SetMsgBoxStyle(Variables.DefaultFont);

                    // run
                    Application.Run(restart);

                    // done
                    return true;
                }

                // disable service
                if (args.Any(x => x == "service_disable"))
                {
                    Log.Information("[SYSTEM] Set service disabled mode activated");
                    Variables.ChildApplicationMode = true;

                    // prepare form
                    var serviceState = new ServiceSetState(ServiceDesiredState.Disabled);

                    // prepare msgbox
                    HelperFunctions.SetMsgBoxStyle(Variables.DefaultFont);

                    // run
                    Application.Run(serviceState);

                    // done
                    return true;
                }

                // enable service
                if (args.Any(x => x == "service_enabled"))
                {
                    Log.Information("[SYSTEM] Set service enabled mode activated");
                    Variables.ChildApplicationMode = true;

                    // prepare form
                    var serviceState = new ServiceSetState(ServiceDesiredState.Automatic);

                    // prepare msgbox
                    HelperFunctions.SetMsgBoxStyle(Variables.DefaultFont);

                    // run
                    Application.Run(serviceState);

                    // done
                    return true;
                }

                // start service
                if (args.Any(x => x == "service_start"))
                {
                    Log.Information("[SYSTEM] Start service mode activated");
                    Variables.ChildApplicationMode = true;

                    // prepare form
                    var serviceState = new ServiceSetState(ServiceDesiredState.Started);

                    // prepare msgbox
                    HelperFunctions.SetMsgBoxStyle(Variables.DefaultFont);

                    // run
                    Application.Run(serviceState);

                    // done
                    return true;
                }

                // stop service
                if (args.Any(x => x == "service_stop"))
                {
                    Log.Information("[SYSTEM] Stop service mode activated");
                    Variables.ChildApplicationMode = true;

                    // prepare form
                    var serviceState = new ServiceSetState(ServiceDesiredState.Stopped);

                    // prepare msgbox
                    HelperFunctions.SetMsgBoxStyle(Variables.DefaultFont);

                    // run
                    Application.Run(serviceState);

                    // done
                    return true;
                }

                // reinstall service
                if (args.Any(x => x == "service_reinstall"))
                {
                    Log.Information("[SYSTEM] Reinstall service mode activated");
                    Variables.ChildApplicationMode = true;

                    // prepare form
                    var serviceReinstall = new ServiceReinstall();

                    // prepare msgbox
                    HelperFunctions.SetMsgBoxStyle(Variables.DefaultFont);

                    // run
                    Application.Run(serviceReinstall);

                    // done
                    return true;
                }

                // nothing, launch normally
                return false;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[PROGRAM] Error while trying to determine child-application mode: {err}", ex.Message);
                return false;
            }
        }
    }
}