using System;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security;
using System.Windows.Forms;
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
        /// <para>HandleProcessCorruptedStateExceptions and SecurityCritical make sure we can catch and log PCS exceptions before shutting down:
        /// https://docs.microsoft.com/en-us/archive/msdn-magazine/2009/february/clr-inside-out-handling-corrupted-state-exceptions#id0070035 </para> 
        /// </summary>
        [HandleProcessCorruptedStateExceptions]
        [SecurityCritical]
        [STAThread]
        private static void Main(string[] args)
        {
            try
            {
                // syncfusion license
                Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(Variables.SyncfusionLicense);

                // get logging settings
                Variables.ExtendedLogging = SettingsManager.GetExtendedLoggingSetting();
                Variables.ExceptionLogging = SettingsManager.GetExceptionReportingSetting();

                // enable logging and optionally prepare Coderr
                HelperFunctions.PrepareLogging();

                if (Variables.ExtendedLogging)
                {
                    // make sure we catch 'm all
                    AppDomain.CurrentDomain.FirstChanceException += (sender, eventArgs) =>
                    {
                        Log.Fatal(eventArgs.Exception, "[PROGRAM] FirstChanceException: {err}", eventArgs.Exception.Message);
                    };
                }
                else Log.Information("[PROGRAM] Extended logging disabled");

                // prepare application
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                
                // check to see if we're launched as a child application
                if (args.Any(x => x == "update"))
                {
                    Log.Information("[SYSTEM] Post-update mode activated");
                    Variables.ChildApplicationMode = true;

                    // prepare form
                    var postUpdate = new PostUpdate();

                    // prepare msgbox
                    HelperFunctions.SetMsgBoxStyle(postUpdate.Font);

                    // run
                    Application.Run(postUpdate);
                }
                else if (args.Any(x => x == "portreservation"))
                {
                    Log.Information("[SYSTEM] Port reservation mode activated");
                    Variables.ChildApplicationMode = true;

                    // prepare form
                    var portReservation = new PortReservation();

                    // prepare msgbox
                    HelperFunctions.SetMsgBoxStyle(portReservation.Font);

                    // run
                    Application.Run(portReservation);
                }
                else
                {
                    // prepare default application
                    Variables.MainForm = new Main();

                    // prepare msgbox
                    HelperFunctions.SetMsgBoxStyle(Variables.MainForm.Font);

                    // run (hidden)
                    Application.Run(new CustomApplicationContext(Variables.MainForm));
                }
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
    }
}
