using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HASSAgent.Functions;
using Syncfusion.Windows.Forms;

namespace HASSAgent.Controls.Configuration
{
    public partial class Startup : UserControl
    {
        public Startup()
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
                    MessageBoxAdv.Show("Something went wrong while disabling start-on-login.\r\n\r\nCheck the logs for more info.",
                        "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // not active yet, so enable
                var enabled = LaunchManager.EnableLaunchOnUserLogin();
                if (!enabled)
                {
                    MessageBoxAdv.Show("Something went wrong while enabling start-on-login.\r\n\r\nCheck the logs for more info.",
                        "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Invoke(new MethodInvoker(delegate
                {
                    LblStartOnLoginStatus.ForeColor = Color.LimeGreen;
                    LblStartOnLoginStatus.Text = "enabled";
                    BtnSetStartOnLogin.Text = "disable start-on-login";
                }));
            }
            else
            {
                Invoke(new MethodInvoker(delegate
                {
                    LblStartOnLoginStatus.ForeColor = Color.OrangeRed;
                    LblStartOnLoginStatus.Text = "disabled";
                    BtnSetStartOnLogin.Text = "enable start-on-login";
                }));
            }
        }
    }
}
