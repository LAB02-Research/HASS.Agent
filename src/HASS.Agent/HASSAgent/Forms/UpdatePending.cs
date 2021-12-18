using Syncfusion.Windows.Forms;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using HASSAgent.Functions;

namespace HASSAgent.Forms
{
    public partial class UpdatePending : MetroForm
    {
        private readonly string _version;

        private string _releaseInfo = string.Empty;
        private string _releaseUrl = string.Empty;

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
            var (releaseUrl, releaseNotes) = await UpdateManager.GetLatestVersionInfoAsync();

            // assign to the vars
            _releaseInfo = releaseNotes;
            _releaseUrl = releaseUrl;

            // update gui
            Invoke(new MethodInvoker(delegate
            {
                TbReleaseNotes.Text = _releaseInfo;

                BtnDownload.Text = "open release page";
                BtnDownload.Enabled = true;
            }));
        }

        private void BtnDownload_Click(object sender, EventArgs e)
        {
            // check if we got an asset url
            if (string.IsNullOrEmpty(_releaseUrl))
            {
                // nope
                MessageBoxAdv.Show("Unable to fetch the release's url, opening the github page instead.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                HelperFunctions.LaunchUrl("https://github.com/LAB02-Research/HASS.Agent");
            }
            else HelperFunctions.LaunchUrl(_releaseUrl);

            // done
            Close();
        }

        private void BtnClose_Click(object sender, EventArgs e) => Close();
    }
}
