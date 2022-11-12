using Syncfusion.Windows.Forms;
using HASS.Agent.Functions;
using HASS.Agent.Managers;
using HASS.Agent.Models.Internal;
using HASS.Agent.Resources.Localization;

namespace HASS.Agent.Forms
{
    public partial class UpdatePending : MetroForm
    {
        private PendingUpdate _pendingUpdate;

        public UpdatePending(PendingUpdate pendingUpdate)
        {
            _pendingUpdate = pendingUpdate;
            InitializeComponent();
        }

        private void UpdatePending_Load(object sender, EventArgs e)
        {
            // show version nr
            LblVersion.Text = _pendingUpdate.Version;

            // optionally show beta ui
            if (_pendingUpdate.IsBeta)
            {
                LblNewReleaseInfo.Text = Languages.UpdatePending_NewBetaRelease;
                Text = Languages.UpdatePending_Title_Beta;
            }

            // load the rest of the info
            Task.Run(FetchInfo);
        }

        private void FetchInfo()
        {
            // add the rest of the update info
            _pendingUpdate = UpdateManager.GetLatestVersionInfo(_pendingUpdate);
            
            // update gui
            Invoke(new MethodInvoker(delegate
            {
                TbReleaseNotes.Text = _pendingUpdate.ReleaseNotes;

                if (Variables.AppSettings.EnableExecuteUpdateInstaller && !string.IsNullOrEmpty(_pendingUpdate.InstallerUrl))
                {
                    LblUpdateQuestion.Text = Languages.UpdatePending_LblUpdateQuestion_Download;
                    BtnDownload.Text = !_pendingUpdate.IsBeta ? Languages.UpdatePending_InstallUpdate : Languages.UpdatePending_InstallBetaRelease;
                }
                else
                {
                    LblUpdateQuestion.Text = Languages.UpdatePending_LblUpdateQuestion_Navigate;
                    BtnDownload.Text = !_pendingUpdate.IsBeta ? Languages.UpdatePending_OpenReleasePage : Languages.UpdatePending_OpenBetaReleasePage;
                }
                
                BtnDownload.Enabled = true;
            }));
        }

        private async void BtnDownload_Click(object sender, EventArgs e)
        {
            // lock the interface
            LblUpdateQuestion.Text = Languages.UpdatePending_LblUpdateQuestion_Processing;
            BtnDownload.Text = Languages.UpdatePending_BtnDownload_Processing;
            BtnDownload.Enabled = false;
            BtnIgnore.Enabled = false;

            // execute the update
            await Task.Run(ExecuteUpdate);

            // are we in automatic mode?
            if (Variables.AppSettings.EnableExecuteUpdateInstaller)
            {
                // yep, shutdown
                _ = Task.Run(HelperFunctions.ShutdownAsync);
            }

            // done
            Close();
        }

        /// <summary>
        /// Executes the update protocol, based on users settings
        /// </summary>
        /// <returns></returns>
        private async Task ExecuteUpdate()
        {
            // are we in automatic mode?
            if (!Variables.AppSettings.EnableExecuteUpdateInstaller)
            {
                // nope, open github
                UpdateManager.LaunchReleaseUrl(_pendingUpdate);
                return;
            }

            // yep, go for it
            await UpdateManager.DownloadAndExecuteUpdate(_pendingUpdate, this);
        }

        private void BtnIgnore_Click(object sender, EventArgs e) => Close();

        private void UpdatePending_ResizeEnd(object sender, EventArgs e)
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

        private void LblRelease_Click(object sender, EventArgs e) => UpdateManager.LaunchReleaseUrl(_pendingUpdate);

        private void TbReleaseNotes_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.LinkText)) return;
            if (!e.LinkText.ToLower().StartsWith("http")) return;

            HelperFunctions.LaunchUrl(e.LinkText);
        }
    }
}
