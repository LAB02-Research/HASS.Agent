using HASS.Agent.Functions;

namespace HASS.Agent.Controls.Onboarding
{
    public partial class OnboardingIntegrations : UserControl
    {
        public OnboardingIntegrations()
        {
            InitializeComponent();
        }

        private void OnboardingIntegrations_Load(object sender, EventArgs e)
        {
            CbEnableNotifications.Checked = Variables.AppSettings.NotificationsEnabled;
            CbEnableMediaPlayer.Checked = Variables.AppSettings.MediaPlayerEnabled;
        }

        internal bool Store()
        {
            Variables.AppSettings.NotificationsEnabled = CbEnableNotifications.Checked;
            Variables.AppSettings.MediaPlayerEnabled = CbEnableMediaPlayer.Checked;

            return true;
        }

        private void LblNotifierIntegration_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://github.com/LAB02-Research/HASS.Agent-Integration");
    }
}
