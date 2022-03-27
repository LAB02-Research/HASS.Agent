using HASSAgent.Forms.Service;
using HASSAgent.Functions;
using HASSAgent.Properties;
using HASSAgent.Service;
using HASSAgent.Settings;
using Serilog;

namespace HASSAgent.Controls.Service
{
    public partial class Connect : UserControl
    {
        private readonly ServiceConfig _serviceConfig;

        public Connect(ServiceConfig serviceConfig)
        {
            _serviceConfig = serviceConfig;

            InitializeComponent();
        }

        private void Connect_Load(object sender, EventArgs e)
        {
            // contact the service
            InitializeService();
        }

        private async void InitializeService()
        {
            // (re)set interface
            LblLoading.ForeColor = Color.FromArgb(241, 241, 241);
            LblLoading.Text = "connecting with the satellite service, one moment please ..";

            LblConnectionMessage.ForeColor = Color.FromArgb(241, 241, 241);
            LblConnectionMessage.Text = string.Empty;

            // set indicators
            PbStep1Connect.Image = Resources.small_loader_32;
            PbStep2Authenticate.Image = Resources.todo_32;
            PbStep3Config.Image = Resources.todo_32;

            // give the ui time to load
            await Task.Delay(TimeSpan.FromSeconds(1));

            // is the service found?
            var serviceFound = await Task.Run(ServiceControllerManager.ServiceExists);
            if (!serviceFound)
            {
                PbStep1Connect.Image = Resources.failed_32;

                LblLoading.ForeColor = Color.OrangeRed;
                LblLoading.Text = "connecting to the service has failed";

                LblConnectionMessage.ForeColor = Color.OrangeRed;
                LblConnectionMessage.Text = "The service hasn't been found! You can install and manage it from the configuration panel.\r\n\r\nWhen it's up and running, come back here to configure the commands and sensors.";

                // let the user decide what to do
                return;
            }

            // can we ping?
            var (pingOk, version, pingError) = await Task.Run(async () => await Variables.RpcClient.PingAsync().WaitAsync(Variables.RpcConnectionTimeout));
            if (!pingOk)
            {
                Log.Error("[SERVICE] Unable to ping: {err}", pingError);

                PbStep1Connect.Image = Resources.failed_32;

                LblLoading.ForeColor = Color.OrangeRed;
                LblLoading.Text = "communicating with the service has failed";

                LblConnectionMessage.ForeColor = Color.OrangeRed;
                LblConnectionMessage.Text = "Unable to communicate with the service. Check the logs for more info.\r\n\r\nYou can open the logs and manage the service from the configuration panel.";

                // let the user decide what to do
                return;
            }

            // service's ready, go to authorizing
            PbStep1Connect.Image = Resources.done_32;
            PbStep2Authenticate.Image = Resources.small_loader_32;

            // can we authenticate?
            var (authenticated, deviceName, authError) = await Task.Run(async () => await Variables.RpcClient.GetDeviceNameAsync());
            if (!authenticated)
            {
                Log.Warning("[SERVICE] Authorization failed: {msg}", authError);

                PbStep2Authenticate.Image = Resources.failed_32;

                LblLoading.ForeColor = Color.Red;
                LblLoading.Text = "unauthorized";

                LblConnectionMessage.ForeColor = Color.Red;
                LblConnectionMessage.Text = "You are not authorized to contact the service.\r\n\r\nIf you have the correct auth ID, you can set it now and try again.";

                // show auth id interface
                LblRetryAuthId.Visible = true;
                TbRetryAuthId.Visible = true;
                BtnRetryAuthId.Visible = true;

                ActiveControl = TbRetryAuthId;

                // let the user decide what to do
                return;
            }

            // we're authorized, lets get the config
            PbStep2Authenticate.Image = Resources.done_32;
            PbStep3Config.Image = Resources.small_loader_32;

            // service settings
            var (settingsOk, serviceSettings, settingsError) = await Task.Run(async () => await Variables.RpcClient.GetServiceSettingsAsync().WaitAsync(Variables.RpcConnectionTimeout));
            if (!settingsOk)
            {
                Log.Warning("[SERVICE] Getting settings failed: {msg}", settingsError);

                PbStep3Config.Image = Resources.failed_32;

                LblLoading.ForeColor = Color.Red;
                LblLoading.Text = "fetching settings failed";

                LblConnectionMessage.ForeColor = Color.Red;
                LblConnectionMessage.Text = "The service returned an error while requesting its settings. Check the logs for more info.\r\n\r\nYou can open the logs and manage the service from the configuration panel.";

                // let the user decide what to do
                return;
            }

            // mqtt settings
            var (mqttOk, mqttSettings, mqttError) = await Task.Run(async () => await Variables.RpcClient.GetServiceMqttSettingsAsync().WaitAsync(Variables.RpcConnectionTimeout));
            if (!mqttOk)
            {
                Log.Warning("[SERVICE] Getting MQTT settings failed: {msg}", mqttError);

                PbStep3Config.Image = Resources.failed_32;

                LblLoading.ForeColor = Color.Red;
                LblLoading.Text = "fetching mqtt settings failed";

                LblConnectionMessage.ForeColor = Color.Red;
                LblConnectionMessage.Text = "The service returned an error while requesting its MQTT settings. Check the logs for more info.\r\n\r\nYou can open the logs and manage the service from the configuration panel.";

                // let the user decide what to do
                return;
            }

            // commands
            var (commandsOk, configuredCommands, commandsError) = await Task.Run(async () => await Variables.RpcClient.GetConfiguredCommandsAsync().WaitAsync(Variables.RpcConnectionTimeout));
            if (!commandsOk)
            {
                Log.Warning("[SERVICE] Getting configured commands failed: {msg}", commandsError);

                PbStep3Config.Image = Resources.failed_32;

                LblLoading.ForeColor = Color.Red;
                LblLoading.Text = "fetching configured commands failed";

                LblConnectionMessage.ForeColor = Color.Red;
                LblConnectionMessage.Text = "The service returned an error while requesting its configured commands. Check the logs for more info.\r\n\r\nYou can open the logs and manage the service from the configuration panel.";

                // let the user decide what to do
                return;
            }

            // sensors
            var (sensorsOk, configuredSensors, sensorsError) = await Task.Run(async () => await Variables.RpcClient.GetConfiguredSensorsAsync().WaitAsync(Variables.RpcConnectionTimeout));
            if (!sensorsOk)
            {
                Log.Warning("[SERVICE] Getting configured sensors failed: {msg}", sensorsError);

                PbStep3Config.Image = Resources.failed_32;

                LblLoading.ForeColor = Color.Red;
                LblLoading.Text = "fetching configured sensors failed";

                LblConnectionMessage.ForeColor = Color.Red;
                LblConnectionMessage.Text = "The service returned an error while requesting its configured sensors. Check the logs for more info.\r\n\r\nYou can open the logs and manage the service from the configuration panel.";

                // let the user decide what to do
                return;
            }

            // all good
            PbStep3Config.Image = Resources.done_32;

            // wait a bit
            await Task.Delay(300);

            // switch interface
            _serviceConfig.LaunchInterface(version, deviceName, serviceSettings, mqttSettings, configuredCommands, configuredSensors);
        }

        private void BtnRetryAuthId_Click(object sender, EventArgs e)
        {
            var authId = TbRetryAuthId.Text.Trim();

            // set and store auth id
            Variables.AppSettings.ServiceAuthId = authId;
            SettingsManager.StoreAppSettings();

            // hide auth id interface
            LblRetryAuthId.Visible = false;
            TbRetryAuthId.Visible = false;
            BtnRetryAuthId.Visible = false;

            // retry
            InitializeService();
        }
    }
}
