using HASSAgent.Controls.Service;
using HASSAgent.Shared.Models.Config;
using HASSAgent.Shared.Models.Config.Service;
using Serilog;
using Syncfusion.Windows.Forms;
using ServiceSensors = HASSAgent.Controls.Service.Sensors;
using ServiceCommands = HASSAgent.Controls.Service.Commands; 
using ServiceMqtt = HASSAgent.Controls.Service.MQTT;
using ServiceConnect = HASSAgent.Controls.Service.Connect;

namespace HASSAgent.Forms.Service
{
    public partial class ServiceConfig : MetroForm
    {
        private ServiceConnect _connect;
        private readonly General _general = new();
        private readonly ServiceSensors _sensors = new();
        private readonly ServiceCommands _commands = new();
        private readonly ServiceMqtt _mqtt = new();

        public ServiceConfig()
        {
            InitializeComponent();
        }

        private void ServiceConfig_Load(object sender, EventArgs e)
        {
            // catch all key presses
            KeyPreview = true;

            // bind new connect form to us
            _connect = new ServiceConnect(this);

            // load controls
            TabGeneral.Controls.Add(_connect);
            TabMqtt.Controls.Add(_mqtt);
            TabSensors.Controls.Add(_sensors);
            TabCommands.Controls.Add(_commands);
        }
        
        /// <summary>
        /// Switches general from 'connect' to 'general', sets the version and shows the other tabs
        /// </summary>
        public void LaunchInterface(string version, string deviceName, ServiceSettings settings, ServiceMqttSettings mqttSettings, List<ConfiguredCommand> configuredCommands, List<ConfiguredSensor> configuredSensors)
        {
            try
            {
                // switch general control
                TabGeneral.Controls.Remove(_connect);
                TabGeneral.Controls.Add(_general);

                // set version, devicename and settings
                _general?.SetConfig(version, deviceName, settings);

                // set mqtt settings
                _mqtt?.SetConfig(mqttSettings);

                // set commands
                _commands?.SetCommands(configuredCommands, deviceName);

                // set sensors
                _sensors?.SetSensors(configuredSensors, deviceName);

                // show tabs
                TabMqtt.TabVisible = true;
                TabSensors.TabVisible = true;
                TabCommands.TabVisible = true;
            }
            catch (NullReferenceException)
            {
                // whatever
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SERVICECONFIG] Error while launching: {err}", ex.Message);
                Close();
            }
        }

        private void SensorsConfig_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape) return;
            Close();
        }

        private void SensorsConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            _mqtt?.StopUpdating();

            _connect?.Dispose();
            _general?.Dispose();
            _mqtt?.Dispose();
            _sensors?.Dispose();
            _commands?.Dispose();
        }
        
        private void SensorsConfig_ResizeEnd(object sender, EventArgs e)
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
