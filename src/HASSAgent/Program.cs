using System.Diagnostics;
using HASSAgent.Enums;
using HASSAgent.Forms;
using HASSAgent.Forms.ChildApplications;
using HASSAgent.Functions;
using HASSAgent.Settings;
using Serilog;

namespace HASSAgent
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

                // get logging settings
                Variables.ExtendedLogging = SettingsManager.GetExtendedLoggingSetting();

                // enable logging
                LoggingManager.PrepareLogging();

                if (Variables.ExtendedLogging)
                {
                    // make sure we catch 'm all
                    AppDomain.CurrentDomain.FirstChanceException += LoggingManager.CurrentDomainOnFirstChanceException;
                }
                else Log.Information("[PROGRAM] Extended logging disabled");

                // prepare application
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

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
        /// Checks the provided arguments to see if we need to launch as a task-specific child application
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