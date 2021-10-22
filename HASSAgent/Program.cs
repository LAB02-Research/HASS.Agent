using System;
using System.IO;
using System.Windows.Forms;
using HASSAgent.Forms;
using HASSAgent.Functions;
using Serilog;

namespace HASSAgent
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            // syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(Variables.SyncfusionLicense);

            // prepare a serilog logger
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Async(a => a.File(Path.Combine(Variables.LogPath, $"[{DateTime.Now:yyyy-MM-dd}] {Variables.ApplicationName}_.log"),
                    rollingInterval: RollingInterval.Day,
                    fileSizeLimitBytes: 10000000,
                    retainedFileCountLimit: 10,
                    rollOnFileSizeLimit: true,
                    buffered: true,
                    flushToDiskInterval: TimeSpan.FromMilliseconds(150)))
                .CreateLogger();

            // prepare application
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // prepare ui
            Variables.FrmM = new Main();
            HelperFunctions.SetMsgBoxStyle();

            // launch application (hidden)
            Application.Run(new CustomApplicationContext(Variables.FrmM));
        }
    }
}
