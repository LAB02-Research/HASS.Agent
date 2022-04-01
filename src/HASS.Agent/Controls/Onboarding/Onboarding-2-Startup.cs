using HASS.Agent.Functions;
using HASS.Agent.Resources.Localization;
using Task = System.Threading.Tasks.Task;

namespace HASS.Agent.Controls.Onboarding
{
    public partial class OnboardingStartup : UserControl
    {
        public OnboardingStartup()
        {
            InitializeComponent();
        }

        private void OnboardingStartup_Load(object sender, EventArgs e)
        {
            // check if it's already done
            if (Variables.OnboardingLaunchOnLoginKeyCreated)
            {
                // already done
                LblCreateInfo.Text = Languages.OnboardingStartup_Activated;
                LblCreateInfo.ForeColor = Color.LimeGreen;
                BtnSetLaunchOnLogin.Visible = false;
                return;
            }

            // nope, run tests
            Task.Run(DetermineLaunchOnLoginStatus);
        }

        /// <summary>
        /// Determine the current status of the launch-on-login reg key
        /// </summary>
        private void DetermineLaunchOnLoginStatus()
        {
            var present = LaunchManager.CheckLaunchOnUserLogin();
            if (!present)
            {
                Invoke(new MethodInvoker(delegate
                {
                    LblCreateInfo.Text = Languages.OnboardingStartup_EnableNow;
                    BtnSetLaunchOnLogin.Enabled = true;
                }));
            }
            else
            {
                LblCreateInfo.Text = Languages.OnboardingStartup_AlreadyActivated;
                LblCreateInfo.ForeColor = Color.LimeGreen;
                BtnSetLaunchOnLogin.Enabled = false;
            }
        }

        private void BtnSetLaunchOnLogin_Click(object sender, EventArgs e)
        {
            // lock interface
            BtnSetLaunchOnLogin.Text = Languages.OnboardingStartup_Activating;
            BtnSetLaunchOnLogin.Enabled = false;

            // set the key
            var enabled = LaunchManager.EnableLaunchOnUserLogin();
            if (enabled)
            {
                // success
                Variables.OnboardingLaunchOnLoginKeyCreated = true;

                BtnSetLaunchOnLogin.Visible = false;

                LblCreateInfo.Text = Languages.OnboardingStartup_Activated;
                LblCreateInfo.ForeColor = Color.LimeGreen;
            }
            else
            {
                LblCreateInfo.Text = Languages.OnboardingStartup_Failed;
                LblCreateInfo.ForeColor = Color.Yellow;

                BtnSetLaunchOnLogin.Text = Languages.OnboardingStartup_BtnSetLaunchOnLogin_2;
                BtnSetLaunchOnLogin.Enabled = true;
            }
        }
    }
}
