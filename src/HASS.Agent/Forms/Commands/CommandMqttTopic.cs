using HASS.Agent.Functions;
using HASS.Agent.Resources.Localization;
using Syncfusion.Windows.Forms;

namespace HASS.Agent.Forms.Commands
{
    public partial class CommandMqttTopic : MetroForm
    {
        public CommandMqttTopic(string topic)
        {
            InitializeComponent();

            TbMqttTopic.Text = topic;
        }

        private void MqttTopic_Load(object sender, EventArgs e)
        {
            // catch all key presses
            KeyPreview = true;
        }

        private void MqttTopic_ResizeEnd(object sender, EventArgs e)
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

        private void MqttTopic_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape) return;
            Close();
        }

        private void BtnCopyClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(TbMqttTopic.Text);
            BtnCopyClipboard.Text = Languages.CommandMqttTopic_BtnCopyClipboard_Copied;
            BtnCopyClipboard.Enabled = false;
        }

        private void LblHelp_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://github.com/LAB02-Research/HASS.Agent/wiki/Command-Actions-Usage-&-Examples");

        private void BtnClose_Click(object sender, EventArgs e) => Close();
    }
}
