using HASS.Agent.API;
using HASS.Agent.Functions;
using HASS.Agent.Managers;
using HASS.Agent.Properties;
using HASS.Agent.Resources.Localization;
using HASS.Agent.Settings;
using Serilog;
using Syncfusion.Windows.Forms;
using Task = System.Threading.Tasks.Task;

namespace HASS.Agent.Forms.ChildApplications
{
    public partial class PortReservation : MetroForm
    {
        public PortReservation()
        {
            InitializeComponent();
        }

        private void PortReservation_Load(object sender, EventArgs e) => ProcessPostUpdate();

        /// <summary>
        /// Performs post-update steps to check system state before launch
        /// </summary>
        private async void ProcessPostUpdate()
        {
            // set busy indicator
            PbStep1PortBinding.Image = Properties.Resources.small_loader_32;

            // give the ui time to load
            await Task.Delay(TimeSpan.FromSeconds(2));
            
            // execute port reservation
            var portDone = await ProcessPortReservationAsync();
            PbStep1PortBinding.Image = portDone ? Properties.Resources.done_32 : Properties.Resources.failed_32;

            // execute firewall rule creation
            var firewallDone = await ProcessFirewallRuleAsync();
            PbStep2Firewall.Image = firewallDone ? Properties.Resources.done_32 : Properties.Resources.failed_32;

            // notify the user if something went wrong
            if (!portDone || !firewallDone) MessageBoxAdv.Show(Languages.PortReservation_ProcessPostUpdate_MessageBox1,
                    Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                // wait a bit to show the 'completed' check
                await Task.Delay(750);
            }

            // flush the logs
            Log.CloseAndFlush();

            // done, close
            Environment.Exit(portDone ? 0 : -1);
        }
        
        /// <summary>
        /// Processes port reservation for the notifier API
        /// </summary>
        /// <returns></returns>
        private async Task<bool> ProcessPortReservationAsync()
        {
            try
            {
                // set busy indicator
                PbStep1PortBinding.Image = Properties.Resources.small_loader_32;

                // is the notifier enabled?
                if (!Variables.AppSettings.NotificationsEnabled) return true;

                // yep, set it at the configured port
                var portReserved = await Task.Run(async () => await ApiManager.ExecutePortReservationAsync(Variables.AppSettings.NotifierApiPort));
                if (!portReserved) Log.Error("[PORTRESERVATION] Unable to execute port reservation, notifier api might fail");
                else Log.Information("[PORTRESERVATION] Port reservation completed");

                // done
                return portReserved;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[PORTRESERVATION] Error processing port reservation: {err}", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Processes the firewall rule
        /// </summary>
        /// <returns></returns>
        private async Task<bool> ProcessFirewallRuleAsync()
        {
            try
            {
                // set busy indicator
                PbStep2Firewall.Image = Properties.Resources.small_loader_32;

                // remove any existing rules (ignore result)
                await FirewallManager.RemoveRule();

                // is the notifier enabled?
                if (!Variables.AppSettings.NotificationsEnabled) return true;

                // yep, add a rule for the port
                var portReserved = await Task.Run(async () => await FirewallManager.CreateRule(Variables.AppSettings.NotifierApiPort));
                if (!portReserved) Log.Error("[PORTRESERVATION] Unable to create firewall rule, notifier api might not receive connections");
                else Log.Information("[PORTRESERVATION] Firewall rule created");

                // done
                return portReserved;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[PORTRESERVATION] Error creating firewall rule: {err}", ex.Message);
                return false;
            }
        }

        private void PortReservation_ResizeEnd(object sender, EventArgs e)
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
