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
            //
        }

        private void LblNotifierIntegration_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://github.com/LAB02-Research/HASS.Agent-Notifier");

        private void LblMediaPlayerIntegration_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://github.com/LAB02-Research/HASS.Agent-MediaPlayer");
    }
}
