using System.ServiceProcess;
using HASS.Agent.Enums;
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
    public partial class ServiceSetState : MetroForm
    {
        private readonly ServiceDesiredState _desiredState;

        public ServiceSetState(ServiceDesiredState desiredState)
        {
            _desiredState = desiredState;

            InitializeComponent();
        }

        private void ServiceSetState_Load(object sender, EventArgs e)
        {
            // set the right action description
            LblStep1Configure.Text = _desiredState switch
            {
                ServiceDesiredState.Automatic => "Enable Satellite Service",
                ServiceDesiredState.Disabled => "Disable Satellite Service",
                ServiceDesiredState.Started => "Start Satellite Service",
                ServiceDesiredState.Stopped => "Stop Satellite Service",
                _ => LblStep1Configure.Text
            };

            ProcessState();
        }

        /// <summary>
        /// Performs post-update steps to check system state before launch
        /// </summary>
        private async void ProcessState()
        {
            // set initial busy indicator
            PbStep1Configure.Image = Resources.small_loader_32;

            // give the ui time to load
            await Task.Delay(TimeSpan.FromSeconds(2));

            // make sure settings are loaded
            await SettingsManager.LoadAsync(false, false);

            // set desired state
            var stateDone = false;
            switch (_desiredState)
            {
                case ServiceDesiredState.Automatic:
                    stateDone = await Task.Run(async () => await SetAutomaticAsync());
                    break;

                case ServiceDesiredState.Disabled:
                    stateDone = await Task.Run(async () => await SetDisabledAsync());
                    break;

                case ServiceDesiredState.Started:
                    stateDone = await Task.Run(async () => await StartServiceAsync());
                    break;

                case ServiceDesiredState.Stopped:
                    stateDone = await Task.Run(async () => await StopServiceAsync());
                    break;
            }

            PbStep1Configure.Image = stateDone ? Resources.done_32 : Resources.failed_32;
            
            // notify the user if something went wrong
            if (!stateDone) MessageBoxAdv.Show("Something went wrong while processing the desired service state.\r\n\r\nPlease consult the logs for more information.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        /// Sets the state of the service to DISABLED
        /// </summary>
        /// <returns></returns>
        private static async Task<bool> SetDisabledAsync()
        {
            try
            {
                if (ServiceControllerManager.GetServiceStartMode() == ServiceStartMode.Disabled) return true;

                // still running?
                if (ServiceControllerManager.GetServiceState() == ServiceControllerStatus.Running)
                {
                    // stop it
                    var stopped = await ServiceControllerManager.StopServiceAsync();
                    if (!stopped.stopped)
                    {
                        Log.Error("[SERVICESETSTATE] Startmode set to disabled, but unable to stop process");
                        return false;
                    }
                }

                // change startmode to disabled
                var success = ServiceControllerManager.SetServiceStartMode(ServiceStartMode.Disabled);
                if (!success)
                {
                    Log.Error("[SERVICESETSTATE] Unable to set startmode to disabled");
                    return false;
                }

                // all good
                Log.Information("[SERVICESETSTATE] Startmode set to disabled");
                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SERVICESETSTATE] Error setting startmode to disabled: {err}", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Sets the state of the service to AUTOMATIC
        /// </summary>
        /// <returns></returns>
        private static async Task<bool> SetAutomaticAsync()
        {
            try
            {
                if (ServiceControllerManager.GetServiceStartMode() == ServiceStartMode.Automatic) return true;

                // change startmode to enabled
                var success = ServiceControllerManager.SetServiceStartMode(ServiceStartMode.Automatic);
                if (!success)
                {
                    Log.Error("[SERVICESETSTATE] Unable to set startmode to automatic");
                    return false;
                }

                // all good
                Log.Information("[SERVICESETSTATE] Startmode set to automatic");

                // start it so the user doesn't have to allow another uac prompt
                return await StartServiceAsync();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SERVICESETSTATE] Error setting startmode to automatic: {err}", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Attempts to stop the service
        /// </summary>
        /// <returns></returns>
        private static async Task<bool> StopServiceAsync()
        {
            try
            {
                if (ServiceControllerManager.GetServiceState() == ServiceControllerStatus.Stopped) return true;

                // try to stop the service
                var result = await ServiceControllerManager.StopServiceAsync();
                if (!result.stopped)
                {
                    Log.Error("[SERVICESETSTATE] Unable to stop the service");
                    return false;
                }

                // all good
                Log.Information("[SERVICESETSTATE] Service succesfully stopped");
                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SERVICESETSTATE] Error while stopping the service: {err}", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Attempts to start the service
        /// </summary>
        /// <returns></returns>
        private static async Task<bool> StartServiceAsync()
        {
            try
            {
                if (ServiceControllerManager.GetServiceState() == ServiceControllerStatus.Running) return true;

                // try to start the service
                var result = await ServiceControllerManager.StartServiceAsync();
                if (!result.started)
                {
                    Log.Error("[SERVICESETSTATE] Unable to start the service");
                    return false;
                }

                // all good
                Log.Information("[SERVICESETSTATE] Service succesfully started");
                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SERVICESETSTATE] Error while starting the service: {err}", ex.Message);
                return false;
            }
        }

        private void ServiceSetState_ResizeEnd(object sender, EventArgs e)
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
