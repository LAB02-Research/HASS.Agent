using System;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Security;
using System.Windows.Forms;
using Coderr.Client;
using Coderr.Client.Serilog;
using HASSAgent.Forms;
using HASSAgent.Functions;
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

                // enable logging and optionally prepare Coderr
                HelperFunctions.PrepareLogging(Properties.Settings.Default.EnableCoderrExceptionReporting);

                if (Properties.Settings.Default.EnableExtendedLogging)
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

                // prepare ui
                Variables.MainForm = new Main();
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
