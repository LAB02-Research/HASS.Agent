namespace HASS.Agent.Controls.Onboarding
{
    public partial class OnboardingLocalApi : UserControl
    {
        private bool _loading = true;

        public OnboardingLocalApi()
        {
            InitializeComponent();
        }

        private void OnboardingLocalApi_Load(object sender, EventArgs e)
        {
            CbEnableLocalApi.Checked = Variables.AppSettings.NotificationsEnabled;
            NumNotificationApiPort.Value = Variables.AppSettings.NotifierApiPort;

            if (!CbEnableLocalApi.Checked)
            {
                CbEnableNotifications.Enabled = false;
                CbEnableMediaPlayer.Enabled = false;
            }
            else
            {
                CbEnableNotifications.Checked = Variables.AppSettings.NotificationsEnabled;
                CbEnableMediaPlayer.Checked = Variables.AppSettings.MediaPlayerEnabled;
            }
            
            _loading = false;
        }

        internal bool Store()
        {
            Variables.AppSettings.NotificationsEnabled = CbEnableLocalApi.Checked;
            Variables.AppSettings.NotifierApiPort = (int)NumNotificationApiPort.Value;

            Variables.AppSettings.NotificationsEnabled = CbEnableNotifications.Checked;
            Variables.AppSettings.MediaPlayerEnabled = CbEnableMediaPlayer.Checked;

            return true;
        }

        private void CbEnableLocalApi_CheckStateChanged(object sender, EventArgs e)
        {
            if (_loading) return;
            
            if (!CbEnableLocalApi.Checked)
            {
                CbEnableNotifications.Checked = false;
                CbEnableMediaPlayer.Checked = false;
            }

            CbEnableNotifications.Enabled = CbEnableLocalApi.Checked;
            CbEnableMediaPlayer.Enabled = CbEnableLocalApi.Checked;
        }
    }
}
