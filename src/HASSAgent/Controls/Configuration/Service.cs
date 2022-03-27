using System.ServiceProcess;
using HASSAgent.Enums;
using HASSAgent.Functions;
using HASSAgent.Service;
using HASSAgent.Shared.Functions;
using Serilog;
using Syncfusion.Windows.Forms;

namespace HASSAgent.Controls.Configuration
{
    public partial class Service : UserControl
    {
        public Service()
        {
            InitializeComponent();
        }

        private void Service_Load(object sender, EventArgs e)
        {
            Task.Run(DetermineServiceStatus);
        }

        /// <summary>
        /// Determine the current status of the start-on-login setting, and sets the GUI accordingly
        /// </summary>
        internal void DetermineServiceStatus()
        {
            try
            {
                if (!ServiceControllerManager.ServiceExists())
                {
                    Variables.MainForm?.SetServiceStatus(ComponentStatus.Disabled);

                    // set not-installed
                    Invoke(new MethodInvoker(delegate
                    {
                        LblServiceStatus.ForeColor = Color.OrangeRed;
                        LblServiceStatus.Text = "not installed";

                    }));

                    return;
                }

                // disabled?
                var startupState = ServiceControllerManager.GetServiceStartMode();
                if (startupState == ServiceStartMode.Disabled)
                {
                    Variables.MainForm?.SetServiceStatus(ComponentStatus.Disabled);

                    Invoke(new MethodInvoker(delegate
                    {
                        LblServiceStatus.ForeColor = Color.OrangeRed;
                        LblServiceStatus.Text = "disabled";
                    }));

                    return;
                }

                // set state
                var state = ServiceControllerManager.GetServiceState();
                switch (state)
                {
                    case ServiceControllerStatus.Running:

                        Variables.MainForm?.SetServiceStatus(ComponentStatus.Ok);

                        Invoke(new MethodInvoker(delegate
                        {
                            LblServiceStatus.ForeColor = Color.LimeGreen;
                            LblServiceStatus.Text = "running";
                        }));
                        break;

                    case ServiceControllerStatus.Stopped:
                        Variables.MainForm?.SetServiceStatus(ComponentStatus.Stopped);

                        Invoke(new MethodInvoker(delegate
                        {
                            LblServiceStatus.ForeColor = Color.OrangeRed;
                            LblServiceStatus.Text = state.ToString().ToLower();
                        }));
                        break;

                    default:
                        Variables.MainForm?.SetServiceStatus(ComponentStatus.Failed);
                        
                        Invoke(new MethodInvoker(delegate
                        {
                            LblServiceStatus.ForeColor = Color.OrangeRed;
                            LblServiceStatus.Text = state.ToString().ToLower();
                        }));
                        break;
                }
            }
            catch (InvalidOperationException)
            {
                // ignore, form closed
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SERVICE] Error setting service state: {err}", ex.Message);
            }
        }

        private void BtnRescanStatus_Click(object sender, EventArgs e) => Task.Run(DetermineServiceStatus);

        private async void BtnStopService_Click(object sender, EventArgs e)
        {
            if (ServiceControllerManager.GetServiceState() == ServiceControllerStatus.Stopped)
            {
                // already stopped, refresh the state incase it's not showing correctly
                _ = Task.Run(DetermineServiceStatus);
                return;
            }

            // needs to be done elevated
            var done = await Task.Run(() => CommandLineManager.ExecuteElevated(Variables.ApplicationExecutable, "service_stop", TimeSpan.FromMinutes(2)));

            // show the new state
            _ = Task.Run(DetermineServiceStatus);

            // check if went ok
            if (!done) MessageBoxAdv.Show("Something went wrong trying to stop the service. Did you allow the UAC prompt?\r\n\r\nCheck the HASS.Agent (not the service) logs for more info.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // done
        }

        private async void BtnStartService_Click(object sender, EventArgs e)
        {
            if (ServiceControllerManager.GetServiceState() == ServiceControllerStatus.Running)
            {
                // already running, refresh the state incase it's not showing correctly
                _ = Task.Run(DetermineServiceStatus);
                return;
            }

            if (ServiceControllerManager.GetServiceStartMode() == ServiceStartMode.Disabled)
            {
                MessageBoxAdv.Show("The service is set to 'disabled', so it can't be started.\r\n\r\nPlease enable the service first, then try again.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // needs to be done elevated
            var done = await Task.Run(() => CommandLineManager.ExecuteElevated(Variables.ApplicationExecutable, "service_start", TimeSpan.FromMinutes(2)));

            // show the new state
            _ = Task.Run(DetermineServiceStatus);

            // check if went ok
            if (!done) MessageBoxAdv.Show("Something went wrong trying to start the service. Did you allow the UAC prompt?\r\n\r\nCheck the HASS.Agent (not the service) logs for more info.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // done
        }

        private async void BtnDisableService_Click(object sender, EventArgs e)
        {
            if (ServiceControllerManager.GetServiceStartMode() == ServiceStartMode.Disabled)
            {
                // already disabled, refresh the state incase it's not showing correctly
                _ = Task.Run(DetermineServiceStatus);
                return;
            }

            // needs to be done elevated
            var done = await Task.Run(() => CommandLineManager.ExecuteElevated(Variables.ApplicationExecutable, "service_disable", TimeSpan.FromMinutes(2)));

            // show the new state
            _ = Task.Run(DetermineServiceStatus);

            // check if went ok
            if (!done) MessageBoxAdv.Show("Something went wrong trying to disable the service. Did you allow the UAC prompt?\r\n\r\nCheck the HASS.Agent (not the service) logs for more info.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            // done
        }

        private async void BtnEnableService_Click(object sender, EventArgs e)
        {
            if (ServiceControllerManager.GetServiceStartMode() == ServiceStartMode.Automatic)
            {
                // already enabled, refresh the state incase it's not showing correctly
                _ = Task.Run(DetermineServiceStatus);
                return;
            }

            // needs to be done elevated
            var done = await Task.Run(() => CommandLineManager.ExecuteElevated(Variables.ApplicationExecutable, "service_enabled", TimeSpan.FromMinutes(2)));

            // show the new state
            _ = Task.Run(DetermineServiceStatus);

            // check if went ok
            if (!done) MessageBoxAdv.Show("Something went wrong trying to enable the service. Did you allow the UAC prompt?\r\n\r\nCheck the HASS.Agent (not the service) logs for more info.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            // done
        }

        private void BtnShowLogs_Click(object sender, EventArgs e) => HelperFunctions.OpenLocalFolder(Variables.SatelliteServiceLogPath);

        private async void BtnReinstallService_Click(object sender, EventArgs e)
        {
            // needs to be done elevated
            var done = await Task.Run(() => CommandLineManager.ExecuteElevated(Variables.ApplicationExecutable, "service_reinstall", TimeSpan.FromMinutes(5)));

            // show the new state
            _ = Task.Run(DetermineServiceStatus);

            // check if went ok
            if (!done) MessageBoxAdv.Show("Something went wrong trying to reinstall the service. Did you allow the UAC prompt?\r\n\r\nCheck the HASS.Agent (not the service) logs for more info.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // done
        }
    }
}
