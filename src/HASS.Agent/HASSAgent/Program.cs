using System;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security;
using System.Windows.Forms;
using Coderr.Client;
using Coderr.Client.Serilog;
using HASSAgent.Forms;
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
        private static void Main()
        {
            try
            {
                // syncfusion license
                Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(Variables.SyncfusionLicense);

                // get logging settings
                var enableExtendedLogging = SettingsManager.GetExtendedLoggingSetting();
                var exceptionLogging = SettingsManager.GetExceptionReportingSetting();

                // enable logging and optionally prepare Coderr
                HelperFunctions.PrepareLogging(exceptionLogging);

                if (enableExtendedLogging)
                {
                    // make sure we catch 'm all
                    AppDomain.CurrentDomain.FirstChanceException += (sender, eventArgs) =>
                    {
                        Log.Fatal(eventArgs.Exception, "[PROGRAM] FirstChanceException: {err}", eventArgs.Exception.Message);
                    };
                }
                else Log.Information("[PROGRAM] Extended logging disabled");

                // check to see if we're launched by the updater
                if (Environment.GetCommandLineArgs().Any(x => x == "update"))
                {
                    var restartTask = HelperFunctions.RestartWithTask(true);
                    if (restartTask)
                    {
                        Log.Information("[SYSTEM] Scheduled Task found and ready, restarting post-update");
                        Log.CloseAndFlush();
                        return;
                    }
                }

                // prepare application
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // prepare ui
                Variables.MainForm = new Main(enableExtendedLogging);
                HelperFunctions.SetMsgBoxStyle();

                // launch application (hidden)
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
    }
}
