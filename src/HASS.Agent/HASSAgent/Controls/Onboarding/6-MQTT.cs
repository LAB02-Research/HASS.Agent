using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HASSAgent.Settings;
using Serilog;

namespace HASSAgent.Controls.Onboarding
{
    // ReSharper disable once InconsistentNaming
    public partial class MQTT : UserControl
    {
        public MQTT()
        {
            InitializeComponent();
        }

        private void MQTT_Load(object sender, EventArgs e)
        {
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
    }
}
