namespace HASS.Agent.Controls.Onboarding
{
    public partial class OnboardingWelcome : UserControl
    {
        public OnboardingWelcome()
        {
            InitializeComponent();
        }

        private void OnboardingWelcome_Load(object sender, EventArgs e)
        {
            TbDeviceName.Text = Variables.AppSettings.DeviceName;
            ActiveControl = TbDeviceName;
        }

        internal bool Store()
        {
            Variables.AppSettings.DeviceName = TbDeviceName.Text;
            return true;
        }
    }
}
