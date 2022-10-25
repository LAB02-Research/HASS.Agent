using Syncfusion.Windows.Forms;
using HASS.Agent.Functions;

namespace HASS.Agent.Forms
{
    public partial class About : MetroForm
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            // catch all key presses
            KeyPreview = true;

            // set version
            var beta = Variables.Beta ? " [BETA]" : string.Empty;
            LblVersion.Text = $"{Variables.Version}{beta}";
        }

        private void LblCoreAudio_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://github.com/morphx666/CoreAudio");

        private void LblGrapevine_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://scottoffen.github.io/grapevine/");

        private void LblHADotNet_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://github.com/qJake/HADotNet");

        private void LblHotkeyListener_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://github.com/Willy-Kimura/HotkeyListener");

        private void LblLibreHardwareMonitor_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://github.com/LibreHardwareMonitor/LibreHardwareMonitor");

        private void LblMicrosoftToolkitUwpNotifications_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://github.com/CommunityToolkit/WindowsCommunityToolkit");

        private void LblMQTTnet_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://github.com/chkr1011/MQTTnet");

        private void LblNewtonsoftJson_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://www.newtonsoft.com/json");

        private void LblSerilog_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://github.com/serilog/serilog");

        private void LblSyncfusion_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://www.syncfusion.com/");

        private void LblHassAgentProject_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://github.com/LAB02-Research/HASS.Agent");

        private void PbHassAgentLogo_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://github.com/LAB02-Research/HASS.Agent");

        private void PbHassLogo_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://www.home-assistant.io");

        private void BtnClose_Click(object sender, EventArgs e) => Close();

        private void LblLab02Research_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://lab02-research.org");

        private void LblOctokit_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://github.com/octokit/octokit.net");

        private void LblCliWrap_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://github.com/Tyrrrz/CliWrap");

        private void About_ResizeEnd(object sender, EventArgs e)
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

        private void PbBMAC_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://www.buymeacoffee.com/lab02research");

        private void LblCassia_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://www.nuget.org/packages/Cassia.NetStandard/");

        private void LblGrpcDotNetNamedPipes_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://github.com/cyanfish/grpc-dotnet-namedpipes");
        private void LblGrpc_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://github.com/grpc/grpc");

        private void PbGithubSponsor_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://github.com/sponsors/LAB02-Admin");

        private void LblByteSize_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://github.com/omar/ByteSize");

        private void PbPayPal_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://www.paypal.com/donate/?hosted_button_id=5YL6UP94AQSPC");

        private void PbKoFi_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://ko-fi.com/lab02research");

        private void About_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape) return;
            Close();
        }
    }
}
