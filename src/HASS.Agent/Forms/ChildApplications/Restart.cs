using System.Diagnostics;
using HASS.Agent.Properties;
using HASS.Agent.Resources.Localization;
using HASS.Agent.Shared.Functions;
using Syncfusion.Windows.Forms;
using HelperFunctions = HASS.Agent.Functions.HelperFunctions;
using Task = System.Threading.Tasks.Task;

namespace HASS.Agent.Forms.ChildApplications
{
    public partial class Restart : MetroForm
    {
        private const int MAX_WAIT_SECONDS = 20;

        public Restart()
        {
            InitializeComponent();
        }

        private void Restart_Load(object sender, EventArgs e) => ProcessRestart();

        /// <summary>
        /// Performs post-update steps to check system state before launch
        /// </summary>
        private async void ProcessRestart()
        {
            // set initial busy indicator
            PbStep1WaitForInstances.Image = Properties.Resources.small_loader_32;

            // give the ui time to load
            await Task.Delay(TimeSpan.FromSeconds(2));

            // check for other instances
            var closed = await GetAllInstancesClosedAsync();
            if (!closed)
            {
                PbStep1WaitForInstances.Image = Properties.Resources.failed_32;
                MessageBoxAdv.Show(string.Format(Languages.Restart_ProcessRestart_MessageBox1, MAX_WAIT_SECONDS), Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);

                // close up
                _ = HelperFunctions.ShutdownAsync();
                return;
            }

            // instances done
            PbStep1WaitForInstances.Image = Properties.Resources.done_32;

            // launch new instance
            PbStep2Restart.Image = Properties.Resources.small_loader_32;

            // launch unelevated
            CommandLineManager.ExecuteProcessUnElevated(Variables.ApplicationExecutable);

            // wait for ui reasons
            await Task.Delay(150);

            // set restart done
            PbStep2Restart.Image = Properties.Resources.done_32;

            // wait for ui reasons
            await Task.Delay(150);

            // close up
            _ = HelperFunctions.ShutdownAsync();
        }

        private static async Task<bool> GetAllInstancesClosedAsync()
        {
            var sw = Stopwatch.StartNew();

            while (sw.Elapsed.TotalSeconds < MAX_WAIT_SECONDS)
            {
                var stillActive = await Task.Run(() => HelperFunctions.IsProcessActiveUnderCurrentUser(Variables.ApplicationExecutable));
                if (!stillActive) return true;

                await Task.Delay(TimeSpan.FromSeconds(1));
            }

            // still active after 20 sec
            return false;
        }
        
        private void Restart_ResizeEnd(object sender, EventArgs e)
        {
            if (Variables.ShuttingDown) return;
            if (!IsHandleCreated) return;
            if (IsDisposed) return;

            try
            {
                Refresh();
            }
            catch
            {
                // best effort
            }
        }
    }
}
