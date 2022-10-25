using HASS.Agent.Functions;
using HASS.Agent.Managers;
using HASS.Agent.Resources.Localization;
using Syncfusion.Windows.Forms;

namespace HASS.Agent.Forms
{
    public partial class Onboarding : MetroForm
    {
        private readonly OnboardingManager _onboardingManager;
        private bool _forceClose = false;

        public Onboarding()
        {
            _onboardingManager = new OnboardingManager(this);
            InitializeComponent();
        }

        private void Onboarding_Load(object sender, EventArgs e)
        {
            // load the current onboarding control
            var statusLoaded = _onboardingManager.ShowCurrentOnboardingStatus();
            if (!statusLoaded)
            {
                _forceClose = true;
                DialogResult = DialogResult.OK;
                return;
            }

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

        private async void BtnClose_Click(object sender, EventArgs e)
        {
            if (!_forceClose)
            {
                if (!await _onboardingManager.ConfirmBeforeCloseAsync()) return;
            }

            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Reloads the control's language
        /// </summary>
        internal void ReloadControlLanguage()
        {
            BtnNext.Text = Languages.Onboarding_BtnNext;
            BtnClose.Text = Languages.Onboarding_BtnClose;
            BtnPrevious.Text = Languages.Onboarding_BtnPrevious;
        }

        private async void Onboarding_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_forceClose) return;
            if (!await _onboardingManager.ConfirmBeforeCloseAsync()) e.Cancel = true;
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
