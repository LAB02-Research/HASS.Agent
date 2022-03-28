using HASS.Agent.Functions;
using Syncfusion.Windows.Forms;

namespace HASS.Agent.Forms
{
    public partial class Onboarding : MetroForm
    {
        private readonly OnboardingManager _onboardingManager;

        public Onboarding()
        {
            _onboardingManager = new OnboardingManager(this);
            InitializeComponent();
        }

        private void Onboarding_Load(object sender, EventArgs e)
        {
            // load the current onboarding control
            _onboardingManager.ShowCurrentOnboardingStatus();

            // remove topmost after half a sec
            Task.Run(async delegate
            {
                await Task.Delay(500);
                Invoke(new MethodInvoker(delegate { TopMost = false; }));
            });
        }

        /// <summary>
        /// Show the next control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNext_Click(object sender, EventArgs e) => _onboardingManager.ShowNext();

        /// <summary>
        /// Show the previous control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPrevious_Click(object sender, EventArgs e) => _onboardingManager.ShowPrevious();

        private void BtnClose_Click(object sender, EventArgs e)
        {
            if (!_onboardingManager.ConfirmBeforeClose()) return;
            DialogResult = DialogResult.OK;
        }

        private void Onboarding_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_onboardingManager.ConfirmBeforeClose()) e.Cancel = true;
        }

        private void Onboarding_ResizeEnd(object sender, EventArgs e)
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
    }
}
