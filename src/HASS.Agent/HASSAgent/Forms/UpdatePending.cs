using Syncfusion.Windows.Forms;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using HASSAgent.Functions;
using MessageBoxAdv = Syncfusion.Windows.Forms.MessageBoxAdv;

namespace HASSAgent.Forms
{
    public partial class UpdatePending : MetroForm
    {
        private readonly string _version;

        private string _releaseInfo = string.Empty;
        private string _releaseUrl = string.Empty;
        private string _installerUrl = string.Empty;

        public UpdatePending(string version)
        {
            _version = version;
            InitializeComponent();
        }

        private void UpdatePending_Load(object sender, EventArgs e)
        {
            LblVersion.Text = _version;

            Task.Run(FetchInfo);
        }

        private async void FetchInfo()
        {
            // fetch asset info
            var (releaseUrl, releaseNotes, installerUrl) = await UpdateManager.GetLatestVersionInfoAsync();

            // assign to the vars
            _releaseInfo = releaseNotes;
            _releaseUrl = releaseUrl;
            _installerUrl = installerUrl;

            // update gui
            Invoke(new MethodInvoker(delegate
            {
                TbReleaseNotes.Text = _releaseInfo;

                if (Variables.AppSettings.EnableExecuteUpdateInstaller && !string.IsNullOrEmpty(_installerUrl))
                {
                    LblUpdateQuestion.Text = "Do you want to download and launch the installer?";
                    BtnDownload.Text = "install update";
                }
                else
                {
                    LblUpdateQuestion.Text = "Do you want to navigate to the release page?";
                    BtnDownload.Text = "open release page";
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
            TbReleaseNotes.Enabled = false;

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
                UpdateManager.LaunchReleaseUrl(_releaseUrl);
                return;
            }

            // yep, go for it
            await UpdateManager.DownloadAndExecuteUpdate(_installerUrl, _releaseUrl);
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

        private void LblRelease_Click(object sender, EventArgs e) => UpdateManager.LaunchReleaseUrl(_releaseUrl);
    }
}
