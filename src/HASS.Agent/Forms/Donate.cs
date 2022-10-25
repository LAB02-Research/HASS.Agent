using Syncfusion.Windows.Forms;
using HASS.Agent.Functions;
using HASS.Agent.Settings;

namespace HASS.Agent.Forms
{
    public partial class Donate : MetroForm
    {
        public Donate()
        {
            InitializeComponent();
        }

        private void Donate_Load(object sender, EventArgs e)
        {
            // catch all key presses
            KeyPreview = true;

            // get hide state
            CbHideDonateButton.CheckState = SettingsManager.GetHideDonateButton() ? CheckState.Checked : CheckState.Unchecked;
        }
        
        private void LblHassAgentProject_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://github.com/LAB02-Research/HASS.Agent");

        private void PbHassAgentLogo_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://github.com/LAB02-Research/HASS.Agent");

        private void BtnClose_Click(object sender, EventArgs e)
        {
            var hide = CbHideDonateButton.CheckState == CheckState.Checked;
            SettingsManager.SetHideDonateButton(hide);

            if (hide) Variables.MainForm.HideDonateButton();

            Close();
        }

        private void Donate_ResizeEnd(object sender, EventArgs e)
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

        private void PbGithubSponsor_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://github.com/sponsors/LAB02-Admin");

        private void PbKoFi_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://ko-fi.com/lab02research");

        private void Donate_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape) return;
            Close();
        }
    }
}
