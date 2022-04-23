using System.ServiceProcess;
using HASS.Agent.Enums;
using HASS.Agent.Functions;
using HASS.Agent.Resources.Localization;
using HASS.Agent.Service;
using HASS.Agent.Shared.Enums;
using HASS.Agent.Shared.Functions;
using Serilog;
using Syncfusion.Windows.Forms;

namespace HASS.Agent.Controls.Configuration
{
    public partial class ConfigService : UserControl
    {
        public ConfigService()
        {
            InitializeComponent();
        }

        private void ConfigService_Load(object sender, EventArgs e)
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
                        LblServiceStatus.Text = Languages.ConfigService_NotInstalled;

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
                        LblServiceStatus.Text = Languages.ConfigService_Disabled;
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
                            LblServiceStatus.Text = Languages.ConfigService_Running;
                        }));
                        break;

                    case ServiceControllerStatus.Stopped:
                        Variables.MainForm?.SetServiceStatus(ComponentStatus.Stopped);

                        Invoke(new MethodInvoker(delegate
                        {
                            LblServiceStatus.ForeColor = Color.OrangeRed;
                            LblServiceStatus.Text = Languages.ConfigService_Stopped;
                        }));
                        break;

                    default:
                        Variables.MainForm?.SetServiceStatus(ComponentStatus.Failed);
                        
                        Invoke(new MethodInvoker(delegate
                        {
                            LblServiceStatus.ForeColor = Color.OrangeRed;
                            LblServiceStatus.Text = Languages.ConfigService_Failed;
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
            if (!done) MessageBoxAdv.Show(Languages.ConfigService_BtnStopService_MessageBox1, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                MessageBoxAdv.Show(Languages.ConfigService_BtnStartService_MessageBox1, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // needs to be done elevated
            var done = await Task.Run(() => CommandLineManager.ExecuteElevated(Variables.ApplicationExecutable, "service_start", TimeSpan.FromMinutes(2)));

            // show the new state
            _ = Task.Run(DetermineServiceStatus);

            // check if went ok
            if (!done) MessageBoxAdv.Show(Languages.ConfigService_BtnStartService_MessageBox2, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);

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
            if (!done) MessageBoxAdv.Show(Languages.ConfigService_BtnDisableService_MessageBox1, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            
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
            if (!done) MessageBoxAdv.Show(Languages.ConfigService_BtnEnableService_MessageBox1, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            
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
            if (!done) MessageBoxAdv.Show(Languages.ConfigService_BtnShowLogs_MessageBox1, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);

            // done
        }
    }
}
