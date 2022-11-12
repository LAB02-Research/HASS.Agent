using HASS.Agent.Functions;
using HASS.Agent.Managers;
using HASS.Agent.Resources.Localization;
using Syncfusion.Windows.Forms;

namespace HASS.Agent.Controls.Configuration
{
    public partial class ConfigStartup : UserControl
    {
        public ConfigStartup()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Enables or disables start-on-login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSetStartOnLogin_Click(object sender, EventArgs e)
        {
            if (LaunchManager.CheckLaunchOnUserLogin())
            {
                // already active, so disable
                var disabled = LaunchManager.DisableLaunchOnUserLogin();
                if (!disabled)
                {
                    MessageBoxAdv.Show(this, Languages.ConfigStartup_BtnSetStartOnLogin_MessageBox1,
                        Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // not active yet, so enable
                var enabled = LaunchManager.EnableLaunchOnUserLogin();
                if (!enabled)
                {
                    MessageBoxAdv.Show(this, Languages.ConfigStartup_BtnSetStartOnLogin_MessageBox2,
                        Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // set the current state
            DetermineStartOnLoginStatus();
        }

        /// <summary>
        /// Determine the current status of the start-on-login setting, and sets the GUI accordingly
        /// </summary>
        internal void DetermineStartOnLoginStatus()
        {
            if (LaunchManager.CheckLaunchOnUserLogin())
            {
                // set enabled
                Invoke(new MethodInvoker(delegate
                {
                    LblStartOnLoginStatus.ForeColor = Color.LimeGreen;
                    LblStartOnLoginStatus.Text = Languages.ConfigStartup_Enabled;
                    BtnSetStartOnLogin.Text = Languages.ConfigStartup_Disable;
                }));

                return;
            }

            // set disabled
            Invoke(new MethodInvoker(delegate
            {
                LblStartOnLoginStatus.ForeColor = Color.OrangeRed;
                LblStartOnLoginStatus.Text = Languages.ConfigStartup_Disabled;
                BtnSetStartOnLogin.Text = Languages.ConfigStartup_Enable;
            }));
        }
    }
}
