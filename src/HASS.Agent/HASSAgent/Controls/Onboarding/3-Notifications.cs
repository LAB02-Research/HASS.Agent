using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HASSAgent.Functions;
using HASSAgent.Settings;
using Newtonsoft.Json;
using Serilog;
using Syncfusion.Windows.Forms;

namespace HASSAgent.Controls.Onboarding
{
    public partial class Notifications : UserControl
    {
        public Notifications()
        {
            InitializeComponent();
        }

        private void Notifications_Load(object sender, EventArgs e)
        {
            CbAcceptNotifications.Checked = Variables.AppSettings.NotificationsEnabled;
            TbIntNotifierApiPort.IntegerValue = Variables.AppSettings.NotifierApiPort;

            if (!Variables.OnboardingFirewallRuleCreated) return;

            // already done
            LblFirewallInfo.Text = "Firewall rule succesfully created!";
            LblFirewallInfo.ForeColor = Color.LimeGreen;
            BtnOpenFirewallPort.Visible = false;
        }

        internal bool Store()
        {
            Variables.AppSettings.NotificationsEnabled = CbAcceptNotifications.Checked;
            Variables.AppSettings.NotifierApiPort = (int)TbIntNotifierApiPort.IntegerValue;
            return true;
        }

        private async void BtnOpenFirewallPort_Click(object sender, EventArgs e)
        {
            // check the entered port value
            var port = (int)TbIntNotifierApiPort.IntegerValue;

            if (port < 1 || port > 65535)
            {
                MessageBoxAdv.Show("Please enter a port value between 1 and 65535.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ActiveControl = TbIntNotifierApiPort;
                return;
            }

            // lock interface
            BtnOpenFirewallPort.Text = "creating rule, hold on ..";
            BtnOpenFirewallPort.Enabled = false;

            // add the rule
            var consoleResult = await CommandLine.ExecuteCommandAsync("netsh", $"advfirewall firewall add rule name=\"HASS.Agent Notifier\" dir=in action=allow protocol=TCP localport={port}");

            // check the outcome
            if (consoleResult.Error)
            {
                // write the result to the logs
                Log.Error("[ONBOARDING] Error creating firewall rule, console output:\r\n{output}", JsonConvert.SerializeObject(consoleResult, Formatting.Indented));

                // notify user
                MessageBoxAdv.Show("Something went wrong while creating the rule for you.\r\n\r\nPlease check the logs for more info, and resort to the GitHub\r\npage for more info, or to create a ticket.",
                    "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // enable gui, incase they want to try again
                BtnOpenFirewallPort.Text = "yes, open the firewall port";
                BtnOpenFirewallPort.Enabled = true;

                return;
            }

            // all good
            LblFirewallInfo.Text = "Firewall rule succesfully created!";
            LblFirewallInfo.ForeColor = Color.LimeGreen;

            BtnOpenFirewallPort.Visible = false;

            // volatile setting, lazy way to remember we did this
            Variables.OnboardingFirewallRuleCreated = true;
        }
    }
}
