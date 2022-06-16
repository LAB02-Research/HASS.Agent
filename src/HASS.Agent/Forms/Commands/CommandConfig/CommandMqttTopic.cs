using HASS.Agent.Functions;
using HASS.Agent.Resources.Localization;
using Syncfusion.Windows.Forms;

namespace HASS.Agent.Forms.Commands.CommandConfig
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
            // setting clipboard needs to be done in STA mode
            var thread = new Thread(() => Clipboard.SetText(TbMqttTopic.Text));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();

            // wait for clipboard to finish
            thread.Join(TimeSpan.FromSeconds(1));

            // all done
            BtnCopyClipboard.Text = Languages.CommandMqttTopic_BtnCopyClipboard_Copied;
            BtnCopyClipboard.Enabled = false;
        }

        private void LblHelp_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://hassagent.readthedocs.io/en/latest/commands/actions-usage-and-examples");

        private void BtnClose_Click(object sender, EventArgs e) => Close();
    }
}
