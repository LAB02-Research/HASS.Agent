using Syncfusion.Windows.Forms;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using HASSAgent.Functions;
using HASSAgent.Models.Internal;
using MessageBoxAdv = Syncfusion.Windows.Forms.MessageBoxAdv;

namespace HASSAgent.Forms
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
                LblNewReleaseInfo.Text = "There's a new BETA release available:";
                Text = "HASS.Agent BETA Update";
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
                    LblUpdateQuestion.Text = "Do you want to download and launch the installer?";
                    BtnDownload.Text = !_pendingUpdate.IsBeta ? "install update" : "install BETA release";
                }
                else
                {
                    LblUpdateQuestion.Text = "Do you want to navigate to the release page?";
                    BtnDownload.Text = !_pendingUpdate.IsBeta ? "open release page" : "open BETA release page";
                }
                
                BtnDownload.Enabled = true;
            }));
        }

        private async void BtnDownload_Click(object sender, EventArgs e)
        {
            // lock the interface
            LblUpdateQuestion.Text = "Hold on, processing your request ..";
            BtnDownload.Text = "processing ..";
            BtnDownload.Enabled = false;
            BtnIgnore.Enabled = false;

            // execute the update
            await ExecuteUpdate();

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
            await UpdateManager.DownloadAndExecuteUpdate(_pendingUpdate);
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
