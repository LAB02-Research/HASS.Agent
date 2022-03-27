using HASSAgent.Functions;
using HASSAgent.Models.HomeAssistant;
using HASSAgent.Notifications;
using Serilog;
using Syncfusion.Windows.Forms;

namespace HASSAgent.Controls.Configuration
{
    public partial class Notifications : UserControl
    {
        public Notifications()
        {
            InitializeComponent();
        }

        private void BtnNotificationsReadme_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://github.com/LAB02-Research/HASS.Agent/wiki/Notification-Usage-&-Examples");

        private void BtnSendTestNotification_Click(object sender, EventArgs e)
        {
            if (!Variables.AppSettings.NotificationsEnabled)
            {
                MessageBoxAdv.Show("Notifications are still disabled. Please enable, restart HASS.Agent and try again.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var testNotification = new Notification
            {
                Message = "This is a test notification.",
                Title = "HASS.Agent"
            };

            Log.Information("[NOTIFIER] Attempting to show test notification ..");

            NotifierManager.ShowNotification(testNotification);

            Log.Information("[NOTIFIER] Test notification attempt completed");

            MessageBoxAdv.Show("The notification should've popped up. If not, check the logs, or check the documentation for troubleshooting tips.\r\n\r\nNote: this only tests locally whether notifications can be shown!",
                "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void BtnExecutePortReservation_Click(object sender, EventArgs e)
        {
            BtnExecutePortReservation.Text = "executing, please wait ..";

            BtnSendTestNotification.Enabled = false;
            BtnExecutePortReservation.Enabled = false;

            // try to reserve elevated
            if (!await Task.Run(NotifierManager.ExecuteElevatedPortReservation))
            {
                // failed, copy the command onto the clipboard
                Clipboard.SetText($"http add urlacl url=http://+:{Variables.AppSettings.NotifierApiPort}/ user={Environment.UserDomainName}\\{Environment.UserName}");

                // notify the user
                MessageBoxAdv.Show("Something went wrong!\r\n\r\nPlease manually execute the required command. It has been copied onto your clipboard, " +
                                   "you just need to paste it into an elevated command prompt.\r\n\r\nRemember to change your firewall rule's port as well.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            BtnExecutePortReservation.Text = "execute port reservation";

            BtnExecutePortReservation.Enabled = true;
            BtnSendTestNotification.Enabled = true;
        }
    }
}
