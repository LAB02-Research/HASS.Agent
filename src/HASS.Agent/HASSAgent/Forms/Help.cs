using Syncfusion.Windows.Forms;
using System;
using HASSAgent.Functions;

namespace HASSAgent.Forms
{
    public partial class Help : MetroForm
    {
        public Help()
        {
            InitializeComponent();
        }

        private void Help_Load(object sender, EventArgs e) => LblVersion.Text = Variables.Version;

        private void PbHassAgentLogo_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://github.com/LAB02-Research/HASS.Agent");

        private void BtnClose_Click(object sender, EventArgs e) => Close();

        private void LblAbout_Click(object sender, EventArgs e)
        {
            using (var about = new About())
            {
                about.ShowDialog();
            }
        }

        private void Help_ResizeEnd(object sender, EventArgs e)
        {
            if (Variables.ShuttingDown) return;
            if (!IsHandleCreated) return;
            if (IsDisposed) return;

            try
            {
                Refresh();
            }
            catch
            {
                // best effort
            }
        }

        private void PbGitHub_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://github.com/LAB02-Research/HASS.Agent");

        private void LblGitHub_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://github.com/LAB02-Research/HASS.Agent");

        private void LblGitHubInfo_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://github.com/LAB02-Research/HASS.Agent");

        private void PbDiscord_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://discord.gg/nMvqzwrVBU");

        private void LblDiscord_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://discord.gg/nMvqzwrVBU");

        private void LblDiscordInfo_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://discord.gg/nMvqzwrVBU");

        private void PbHAForum_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://community.home-assistant.io/t/hass-agent-a-new-windows-based-client-to-receive-notifications-perform-quick-actions-and-much-more/369094");

        private void LblHAForum_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://community.home-assistant.io/t/hass-agent-a-new-windows-based-client-to-receive-notifications-perform-quick-actions-and-much-more/369094");

        private void LblHAInfo_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://community.home-assistant.io/t/hass-agent-a-new-windows-based-client-to-receive-notifications-perform-quick-actions-and-much-more/369094");
    }
}
