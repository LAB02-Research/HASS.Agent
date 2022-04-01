using HASS.Agent.Forms.Service;
using HASS.Agent.Functions;
using HASS.Agent.Properties;
using HASS.Agent.Resources.Localization;
using HASS.Agent.Service;
using HASS.Agent.Settings;
using Serilog;

namespace HASS.Agent.Controls.Service
{
    public partial class ServiceConnect : UserControl
    {
        private readonly ServiceConfig _serviceConfig;

        public ServiceConnect(ServiceConfig serviceConfig)
        {
            _serviceConfig = serviceConfig;

            InitializeComponent();
        }

        private void ServiceConnect_Load(object sender, EventArgs e)
        {
            // contact the service
            InitializeService();
        }

        private async void InitializeService()
        {
            // (re)set interface
            LblLoading.ForeColor = Color.FromArgb(241, 241, 241);
            LblLoading.Text = Languages.ServiceConnect_Connecting;

            LblConnectionMessage.ForeColor = Color.FromArgb(241, 241, 241);
            LblConnectionMessage.Text = string.Empty;

            // set indicators
            PbStep1Connect.Image = Properties.Resources.small_loader_32;
            PbStep2Authenticate.Image = Properties.Resources.todo_32;
            PbStep3Config.Image = Properties.Resources.todo_32;

            // give the ui time to load
            await Task.Delay(TimeSpan.FromSeconds(1));

            // is the service found?
            var serviceFound = await Task.Run(ServiceControllerManager.ServiceExists);
            if (!serviceFound)
            {
                PbStep1Connect.Image = Properties.Resources.failed_32;

                LblLoading.ForeColor = Color.OrangeRed;
                LblLoading.Text = Languages.ServiceConnect_Failed;

                LblConnectionMessage.ForeColor = Color.OrangeRed;
                LblConnectionMessage.Text = Languages.ServiceConnect_FailedMessage;

                // let the user decide what to do
                return;
            }

            // can we ping?
            var (pingOk, version, pingError) = await Task.Run(async () => await Variables.RpcClient.PingAsync().WaitAsync(Variables.RpcConnectionTimeout));
            if (!pingOk)
            {
                Log.Error("[SERVICE] Unable to ping: {err}", pingError);

                PbStep1Connect.Image = Properties.Resources.failed_32;

                LblLoading.ForeColor = Color.OrangeRed;
                LblLoading.Text = Languages.ServiceConnect_CommunicationFailed;

                LblConnectionMessage.ForeColor = Color.OrangeRed;
                LblConnectionMessage.Text = Languages.ServiceConnect_CommunicationFailedMessage;

                // let the user decide what to do
                return;
            }

            // service's ready, go to authorizing
            PbStep1Connect.Image = Properties.Resources.done_32;
            PbStep2Authenticate.Image = Properties.Resources.small_loader_32;

            // can we authenticate?
            var (authenticated, deviceName, authError) = await Task.Run(async () => await Variables.RpcClient.GetDeviceNameAsync());
            if (!authenticated)
            {
                Log.Warning("[SERVICE] Authorization failed: {msg}", authError);

                PbStep2Authenticate.Image = Properties.Resources.failed_32;

                LblLoading.ForeColor = Color.Red;
                LblLoading.Text = Languages.ServiceConnect_Unauthorized;

                LblConnectionMessage.ForeColor = Color.Red;
                LblConnectionMessage.Text = Languages.ServiceConnect_UnauthorizedMessage;

                // show auth id interface
                LblRetryAuthId.Visible = true;
                TbRetryAuthId.Visible = true;
                BtnRetryAuthId.Visible = true;

                ActiveControl = TbRetryAuthId;

                // let the user decide what to do
                return;
            }

            // we're authorized, lets get the config
            PbStep2Authenticate.Image = Properties.Resources.done_32;
            PbStep3Config.Image = Properties.Resources.small_loader_32;

            // service settings
            var (settingsOk, serviceSettings, settingsError) = await Task.Run(async () => await Variables.RpcClient.GetServiceSettingsAsync().WaitAsync(Variables.RpcConnectionTimeout));
            if (!settingsOk)
            {
                Log.Warning("[SERVICE] Getting settings failed: {msg}", settingsError);

                PbStep3Config.Image = Properties.Resources.failed_32;

                LblLoading.ForeColor = Color.Red;
                LblLoading.Text = Languages.ServiceConnect_SettingsFailed;

                LblConnectionMessage.ForeColor = Color.Red;
                LblConnectionMessage.Text = Languages.ServiceConnect_SettingsFailedMessage;

                // let the user decide what to do
                return;
            }

            // mqtt settings
            var (mqttOk, mqttSettings, mqttError) = await Task.Run(async () => await Variables.RpcClient.GetServiceMqttSettingsAsync().WaitAsync(Variables.RpcConnectionTimeout));
            if (!mqttOk)
            {
                Log.Warning("[SERVICE] Getting MQTT settings failed: {msg}", mqttError);

                PbStep3Config.Image = Properties.Resources.failed_32;

                LblLoading.ForeColor = Color.Red;
                LblLoading.Text = Languages.ServiceConnect_MqttFailed;

                LblConnectionMessage.ForeColor = Color.Red;
                LblConnectionMessage.Text = Languages.ServiceConnect_MqttFailedMessage;

                // let the user decide what to do
                return;
            }

            // commands
            var (commandsOk, configuredCommands, commandsError) = await Task.Run(async () => await Variables.RpcClient.GetConfiguredCommandsAsync().WaitAsync(Variables.RpcConnectionTimeout));
            if (!commandsOk)
            {
                Log.Warning("[SERVICE] Getting configured commands failed: {msg}", commandsError);

                PbStep3Config.Image = Properties.Resources.failed_32;

                LblLoading.ForeColor = Color.Red;
                LblLoading.Text = Languages.ServiceConnect_CommandsFailed;

                LblConnectionMessage.ForeColor = Color.Red;
                LblConnectionMessage.Text = Languages.ServiceConnect_CommandsFailedMessage;

                // let the user decide what to do
                return;
            }

            // sensors
            var (sensorsOk, configuredSensors, sensorsError) = await Task.Run(async () => await Variables.RpcClient.GetConfiguredSensorsAsync().WaitAsync(Variables.RpcConnectionTimeout));
            if (!sensorsOk)
            {
                Log.Warning("[SERVICE] Getting configured sensors failed: {msg}", sensorsError);

                PbStep3Config.Image = Properties.Resources.failed_32;

                LblLoading.ForeColor = Color.Red;
                LblLoading.Text = Languages.ServiceConnect_SensorsFailed;

                LblConnectionMessage.ForeColor = Color.Red;
                LblConnectionMessage.Text = Languages.ServiceConnect_SensorsFailedMessage;

                // let the user decide what to do
                return;
            }

            // all good
            PbStep3Config.Image = Properties.Resources.done_32;

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
