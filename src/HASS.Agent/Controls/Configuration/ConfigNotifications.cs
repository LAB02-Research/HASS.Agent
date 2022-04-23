using HASS.Agent.Functions;
using HASS.Agent.Models.HomeAssistant;
using HASS.Agent.Notifications;
using HASS.Agent.Resources.Localization;
using Serilog;
using Syncfusion.Windows.Forms;

namespace HASS.Agent.Controls.Configuration
{
    public partial class ConfigNotifications : UserControl
    {
        public ConfigNotifications()
        {
            InitializeComponent();
        }

        private void BtnNotificationsReadme_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://github.com/LAB02-Research/HASS.Agent/wiki/Notification-Usage-&-Examples");

        private void BtnSendTestNotification_Click(object sender, EventArgs e)
        {
            if (!Variables.AppSettings.NotificationsEnabled)
            {
                MessageBoxAdv.Show(Languages.ConfigNotifications_BtnSendTestNotification_MessageBox1, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var testNotification = new Notification
            {
                Message = Languages.ConfigNotifications_TestNotification,
                Title = "HASS.Agent"
            };

            Log.Information("[NOTIFIER] Attempting to show test notification ..");

            NotifierManager.ShowNotification(testNotification);

            Log.Information("[NOTIFIER] Test notification attempt completed");

            MessageBoxAdv.Show(Languages.ConfigNotifications_BtnSendTestNotification_MessageBox2,
                Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void BtnExecutePortReservation_Click(object sender, EventArgs e)
        {
            BtnExecutePortReservation.Text = Languages.ConfigNotifications_BtnExecutePortReservation_Busy;

            BtnSendTestNotification.Enabled = false;
            BtnExecutePortReservation.Enabled = false;

            // try to reserve elevated
            if (!await Task.Run(NotifierManager.ExecuteElevatedPortReservation))
            {
                // failed, copy the command onto the clipboard
                Clipboard.SetText($"netsh http add urlacl url=http://+:{Variables.AppSettings.NotifierApiPort}/ user={Environment.UserDomainName}\\{Environment.UserName}");

                // notify the user
                MessageBoxAdv.Show(Languages.ConfigNotifications_BtnExecutePortReservation_MessageBox1, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            BtnExecutePortReservation.Text = Languages.ConfigNotifications_BtnExecutePortReservation;

            BtnExecutePortReservation.Enabled = true;
            BtnSendTestNotification.Enabled = true;
        }
    }
}
