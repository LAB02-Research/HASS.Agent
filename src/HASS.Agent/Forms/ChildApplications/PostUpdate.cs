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
    public partial class PostUpdate : MetroForm
    {
        public PostUpdate()
        {
            InitializeComponent();
        }

        private void PostUpdate_Load(object sender, EventArgs e) => ProcessPostUpdate();

        /// <summary>
        /// Performs post-update steps to check system state before launch
        /// </summary>
        private async void ProcessPostUpdate()
        {
            // set initial busy indicator
            PbStep1InstallSatelliteService.Image = Resources.small_loader_32;

            // give the ui time to load
            await Task.Delay(TimeSpan.FromSeconds(2));

            // make sure settings are loaded
            await SettingsManager.LoadAsync(false, false);

            // install/configure satellite service
            var serviceDone = await ConfigureSatelliteServiceAsync();
            PbStep1InstallSatelliteService.Image = serviceDone ? Resources.done_32 : Resources.failed_32;

            // execute port reservation
            var portDone = await ProcessPortReservationAsync();
            PbStep2PortBinding.Image = portDone ? Resources.done_32 : Resources.failed_32;

            // notify the user if something went wrong
            if (!serviceDone || !portDone) MessageBoxAdv.Show("Not all steps completed succesfully. Please consult the logs for more information.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                // wait a bit to show the 'completed' checks
                await Task.Delay(750);
            }

            // relaunch normally
            HelperFunctions.Restart(true);

            // done, the relauncher will close up
        }

        /// <summary>
        /// Installs (if needed) and configures the satellite service
        /// </summary>
        /// <returns></returns>
        private async Task<bool> ConfigureSatelliteServiceAsync()
        {
            try
            {
                // set busy indicator
                PbStep1InstallSatelliteService.Image = Resources.small_loader_32;

                // make sure we have the location of the service's binary
                await Task.Run(ServiceManager.SetSatelliteServiceLocalStorage);
                
                // service installed?
                if (await Task.Run(ServiceControllerManager.ServiceExists))
                {
                    // what's it state
                    var startMode = await Task.Run(ServiceControllerManager.GetServiceStartMode);
                    if (startMode == ServiceStartMode.Disabled)
                    {
                        // it's disabled, leave it alone
                        return true;
                    }

                    if (startMode != ServiceStartMode.Automatic)
                    {
                        // set it to automatic
                        var startModeChanged = await Task.Run(() => ServiceControllerManager.SetServiceStartMode(ServiceStartMode.Automatic));
                        if (!startModeChanged) return false;
                    }
                }
                else
                {
                    // nope, install
                    var installed = await Task.Run(async () => await ServiceControllerManager.InstallServiceAsync());
                    if (!installed) return false;

                    // configurre
                    var configured = await Task.Run(async () => await ServiceControllerManager.ConfigureServiceAsync());
                    if (!configured) return false;
                }
                
                // is it running?
                if (await Task.Run(ServiceControllerManager.GetServiceState) == ServiceControllerStatus.Running)
                {
                    // yep
                    return true;
                }

                // nope, try to start
                var (started, _) = await Task.Run(async () => await ServiceControllerManager.StartServiceAsync());
                return started;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[POSTUPDATE] Error configuring satellite service: {err}", ex.Message);
                return false;
            }
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
                PbStep2PortBinding.Image = Resources.small_loader_32;

                // is the notifier enabled?
                if (!Variables.AppSettings.NotificationsEnabled) return true;

                // yep, set it at the configured port
                var portReserved = await Task.Run(async () => await NotifierManager.ExecutePortReservationAsync(Variables.AppSettings.NotifierApiPort));
                if (!portReserved) Log.Error("[POSTUPDATE] Unable to execute port reservation, notifier api might fail");
                else Log.Information("[POSTUPDATE] Port reservation completed");

                // done
                return portReserved;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[POSTUPDATE] Error processing port reservation: {err}", ex.Message);
                return false;
            }
        }

        private void PostUpdate_ResizeEnd(object sender, EventArgs e)
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
