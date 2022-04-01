namespace HASS.Agent.Controls.Onboarding
{
    public partial class OnboardingNotifications : UserControl
    {
        public OnboardingNotifications()
        {
            InitializeComponent();
        }

        private void OnboardingNotifications_Load(object sender, EventArgs e)
        {
            CbAcceptNotifications.Checked = Variables.AppSettings.NotificationsEnabled;
            NumNotificationApiPort.Value = Variables.AppSettings.NotifierApiPort;
        }

        internal bool Store()
        {
            Variables.AppSettings.NotificationsEnabled = CbAcceptNotifications.Checked;
            Variables.AppSettings.NotifierApiPort = (int)NumNotificationApiPort.Value;
            
            return true;
        }
    }
}
