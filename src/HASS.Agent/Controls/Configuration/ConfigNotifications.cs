using HASS.Agent.API;
using HASS.Agent.Functions;
using HASS.Agent.Managers;
using HASS.Agent.Models.HomeAssistant;
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

        private void BtnNotificationsReadme_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://hassagent.readthedocs.io/en/latest/notifications/notification-usage-and-examples/");

        private void BtnSendTestNotification_Click(object sender, EventArgs e)
        {
            if (!Variables.AppSettings.NotificationsEnabled)
            {
                MessageBoxAdv.Show(this, Languages.ConfigNotifications_BtnSendTestNotification_MessageBox1, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var testNotification = new Notification
            {
                Message = Languages.ConfigNotifications_TestNotification,
                Title = "HASS.Agent"
            };

            Log.Information("[NOTIFIER] Attempting to show test notification ..");

            NotificationManager.ShowNotification(testNotification);

            Log.Information("[NOTIFIER] Test notification attempt completed");

            MessageBoxAdv.Show(this, Languages.ConfigNotifications_BtnSendTestNotification_MessageBox2,
                Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ConfigNotifications_Load(object sender, EventArgs e)
        {
            LblConnectivityDisabled.Visible = !Variables.AppSettings.LocalApiEnabled && !Variables.AppSettings.MqttEnabled;
        }
    }
}
