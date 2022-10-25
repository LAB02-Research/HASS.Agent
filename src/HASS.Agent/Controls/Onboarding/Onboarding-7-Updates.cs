namespace HASS.Agent.Controls.Onboarding
{
    public partial class OnboardingUpdates : UserControl
    {
        public OnboardingUpdates()
        {
            InitializeComponent();
        }

        private void OnboardingUpdates_Load(object sender, EventArgs e)
        {
            CbNofityOnUpdate.Checked = Variables.AppSettings.CheckForUpdates;
            CbExecuteUpdater.Checked = Variables.AppSettings.EnableExecuteUpdateInstaller;
        }

        internal bool Store()
        {
            Variables.AppSettings.CheckForUpdates = CbNofityOnUpdate.Checked;
            Variables.AppSettings.EnableExecuteUpdateInstaller = CbExecuteUpdater.Checked;
            return true;
        }
    }
}
