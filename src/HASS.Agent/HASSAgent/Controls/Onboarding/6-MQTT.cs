using System;
using System.Globalization;
using System.Windows.Forms;
using Serilog;

namespace HASSAgent.Controls.Onboarding
{
    // ReSharper disable once InconsistentNaming
    public partial class MQTT : UserControl
    {
        private bool _initializing = true;

        public MQTT()
        {
            InitializeComponent();

            TbIntMqttPort.Culture = CultureInfo.InstalledUICulture;
        }

        private void MQTT_Load(object sender, EventArgs e)
        {
            // hide group seperator
            TbIntMqttPort.NumberGroupSeparator = "";

            // let's see if we can get the host from the provided HASS uri
            if (!string.IsNullOrEmpty(Variables.AppSettings.HassUri))
            {
                try
                {
                    var host = new Uri(Variables.AppSettings.HassUri).Host;
                    TbMqttAddress.Text = host;
                }
                catch (Exception ex)
                {
                    Log.Error("[MQTT] Unable to parse URI {uri}: {msg}", Variables.AppSettings.HassUri, ex.Message);
                }
            }
            
            // if the above process failed somewhere, just enter the entire address (if any)
            if (string.IsNullOrEmpty(TbMqttAddress.Text)) TbMqttAddress.Text = Variables.AppSettings.MqttAddress;

            // optionally set default port
            if (Variables.AppSettings.MqttPort < 1) Variables.AppSettings.MqttPort = 1883;
            TbIntMqttPort.IntegerValue = Variables.AppSettings.MqttPort;

            CbMqttTls.Checked = Variables.AppSettings.MqttUseTls;
            TbMqttUsername.Text = Variables.AppSettings.MqttUsername;
            TbMqttPassword.Text = Variables.AppSettings.MqttPassword;
            TbMqttDiscoveryPrefix.Text = Variables.AppSettings.MqttDiscoveryPrefix;

            _initializing = false;

            ActiveControl = !string.IsNullOrEmpty(TbMqttAddress.Text) ? TbMqttUsername : TbMqttAddress;
        }

        internal bool Store()
        {
            Variables.AppSettings.MqttAddress = TbMqttAddress.Text;
            Variables.AppSettings.MqttPort = (int)TbIntMqttPort.IntegerValue;
            Variables.AppSettings.MqttUseTls = CbMqttTls.Checked;
            Variables.AppSettings.MqttUsername = TbMqttUsername.Text;
            Variables.AppSettings.MqttPassword = TbMqttPassword.Text;
            Variables.AppSettings.MqttDiscoveryPrefix = TbMqttDiscoveryPrefix.Text;
            return true;
        }

        private void CbMqttTls_CheckedChanged(object sender, EventArgs e)
        {
            if (_initializing) return;
            TbIntMqttPort.IntegerValue = CbMqttTls.Checked ? 8883 : 1883;
        }
    }
}
