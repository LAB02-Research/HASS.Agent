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
            TbMqttAddress.Text = Variables.AppSettings.MqttAddress;
            TbIntMqttPort.IntegerValue = Variables.AppSettings.MqttPort;
            CbMqttTls.Checked = Variables.AppSettings.MqttUseTls;
            TbMqttUsername.Text = Variables.AppSettings.MqttUsername;
            TbMqttPassword.Text = Variables.AppSettings.MqttPassword;

            ActiveControl = TbMqttAddress;
        }

        internal bool Store()
        {
            Variables.AppSettings.MqttAddress = TbMqttAddress.Text;
            Variables.AppSettings.MqttPort = (int)TbIntMqttPort.IntegerValue;
            Variables.AppSettings.MqttUseTls = CbMqttTls.Checked;
            Variables.AppSettings.MqttUsername = TbMqttUsername.Text;
            Variables.AppSettings.MqttPassword = TbMqttPassword.Text;
            return true;
        }
    }
}
