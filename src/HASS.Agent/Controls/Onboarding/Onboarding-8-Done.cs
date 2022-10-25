using HASS.Agent.Functions;

namespace HASS.Agent.Controls.Onboarding
{
    public partial class OnboardingDone : UserControl
    {
        public OnboardingDone()
        {
            InitializeComponent();
        }

        private void OnboardingDone_Load(object sender, EventArgs e)
        {
            //
        }

        private void PbBMAC_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://www.buymeacoffee.com/lab02research");
    }
}
