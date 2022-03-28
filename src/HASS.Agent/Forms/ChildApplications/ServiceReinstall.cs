using System.ServiceProcess;
using HASS.Agent.Functions;
using HASS.Agent.Notifications;
using HASS.Agent.Properties;
using HASS.Agent.Service;
using HASS.Agent.Settings;
using Serilog;
using Syncfusion.Windows.Forms;
using Task = System.Threading.Tasks.Task;

namespace HASS.Agent.Forms.ChildApplications
{
    public partial class ServiceReinstall : MetroForm
    {
        public ServiceReinstall()
        {
            InitializeComponent();
        }

        private void ServiceReinstall_Load(object sender, EventArgs e) => ProcessReinstall();

        /// <summary>
        /// Performs post-update steps to check system state before launch
        /// </summary>
        private async void ProcessReinstall()
        {
            // set initial busy indicator
            PbStep1Remove.Image = Resources.small_loader_32;

            // give the ui time to load
            await Task.Delay(TimeSpan.FromSeconds(2));

            // make sure settings are loaded
            await SettingsManager.LoadAsync(false, false);

            // we need additional service local paths for the service
            var ioOk = await Task.Run(ServiceManager.SetSatelliteServiceLocalStorage);
            if (!ioOk) Log.Warning("[SERVICEREINSTALL] Locating service local storage failed, installation may as well");

            // uninstall satellite service
            var uninstallDone = await UninstallSatelliteServiceAsync();
            PbStep1Remove.Image = uninstallDone ? Resources.done_32 : Resources.failed_32;

            // install/configure satellite service
            var installDone = await InstallSatelliteServiceAsync();
            PbStep2Install.Image = installDone ? Resources.done_32 : Resources.failed_32;

            // notify the user if something went wrong
            if (!uninstallDone || !installDone) MessageBoxAdv.Show("Not all steps completed succesfully. Please consult the logs for more information.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                // wait a bit to show the 'completed' checks
                await Task.Delay(750);
            }

            // we don't need to relaunch, just close
            _ = HelperFunctions.ShutdownAsync();

            // hide
            Visible = false;
        }

        /// <summary>
        /// Uninstalls (if needed) the satellite service
        /// </summary>
        /// <returns></returns>
        private async Task<bool> UninstallSatelliteServiceAsync()
        {
            try
            {
                // set busy indicator
                PbStep1Remove.Image = Resources.small_loader_32;

                // service installed?
                if (!await Task.Run(ServiceControllerManager.ServiceExists))
                {
                    Log.Information("[SERVICEREINSTALL] Service already uninstalled, skipping");
                    return true;
                }
                
                // is it running?
                if (await Task.Run(ServiceControllerManager.GetServiceState) == ServiceControllerStatus.Running)
                {
                    // yep, ask it to stop
                    var stopResult = await Task.Run(async () => await ServiceControllerManager.StopServiceAsync());
                    if (!stopResult.stopped) Log.Error("[SERVICEREINSTALL] Stopping the service failed, system may need to reboot after uninstalling");
                }

                // uninstall
                var uninstalled = await Task.Run(async () => await ServiceControllerManager.UninstallServiceAsync());
                if (!uninstalled)
                {
                    Log.Error("[SERVICEREINSTALL] Uninstalling service failed");
                    return false;
                }

                // all good
                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SERVICEREINSTALL] Error uninstalling service: {err}", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Installs (if needed) and configures the satellite service
        /// </summary>
        /// <returns></returns>
        private async Task<bool> InstallSatelliteServiceAsync()
        {
            try
            {
                // set busy indicator
                PbStep2Install.Image = Resources.small_loader_32;

                // short pause to make sure the service's removed
                await Task.Delay(TimeSpan.FromSeconds(2));

                // service installed? shouldn't be, as we just uninstalled..
                if (await Task.Run(ServiceControllerManager.ServiceExists))
                {
                    Log.Error("[SERVICEREINSTALL] Installing the service failed: already installed, but should be uninstalled");
                    return false;
                }

                // nope, install
                var installed = await Task.Run(async () => await ServiceControllerManager.InstallServiceAsync());
                if (!installed) return false;

                // configurre
                var configured = await Task.Run(async () => await ServiceControllerManager.ConfigureServiceAsync());
                if (!configured) return false;

                // is it running?
                if (await Task.Run(ServiceControllerManager.GetServiceState) == ServiceControllerStatus.Running)
                {
                    // yep (weird ..)
                    return true;
                }

                // nope, try to start
                var (started, _) = await Task.Run(async () => await ServiceControllerManager.StartServiceAsync());
                return started;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SERVICEREINSTALL] Error installing satellite service: {err}", ex.Message);
                return false;
            }
        }

        private void ServiceReinstall_ResizeEnd(object sender, EventArgs e)
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
