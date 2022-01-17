using System;
using System.Drawing;
using System.Windows.Forms;
using HASSAgent.Functions;
using Task = System.Threading.Tasks.Task;

namespace HASSAgent.Controls.Onboarding
{
    public partial class Startup : UserControl
    {
        public Startup()
        {
            InitializeComponent();
        }

        private void Startup_Load(object sender, EventArgs e)
        {
            // check if it's already done
            if (Variables.OnboardingLaunchOnLoginKeyCreated)
            {
                // already done
                LblCreateInfo.Text = "Launch-on-login succesfully activated!";
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
            var present = Reg.CheckLaunchOnUserLogin();
            if (!present)
            {
                Invoke(new MethodInvoker(delegate
                {
                    LblCreateInfo.Text = "Do you want to enable launch-on-login now?";
                    BtnSetLaunchOnLogin.Enabled = true;
                }));
            }
            else
            {
                LblCreateInfo.Text = "Launch-on-login is already activated, all set!";
                LblCreateInfo.ForeColor = Color.LimeGreen;
                BtnSetLaunchOnLogin.Enabled = false;
            }
        }

        private void BtnSetLaunchOnLogin_Click(object sender, EventArgs e)
        {
            // lock interface
            BtnSetLaunchOnLogin.Text = "activating launch-on-login, hold on ..";
            BtnSetLaunchOnLogin.Enabled = false;

            // set the key
            var enabled = Reg.EnableLaunchOnUserLogin();
            if (enabled)
            {
                // success
                Variables.OnboardingLaunchOnLoginKeyCreated = true;

                BtnSetLaunchOnLogin.Visible = false;

                LblCreateInfo.Text = "Launch-on-login succesfully activated!";
                LblCreateInfo.ForeColor = Color.LimeGreen;
            }
            else
            {
                LblCreateInfo.Text = "Something went wrong. You can try again, or skip to the next page and retry after HASS.Agent's restart.";
                LblCreateInfo.ForeColor = Color.Yellow;

                BtnSetLaunchOnLogin.Text = "enable launch-on-login";
                BtnSetLaunchOnLogin.Enabled = true;
            }
        }
    }
}
