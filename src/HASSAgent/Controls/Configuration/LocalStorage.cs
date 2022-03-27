using System.Diagnostics;
using HASSAgent.Functions;
using Syncfusion.Windows.Forms;

namespace HASSAgent.Controls.Configuration
{
    public partial class LocalStorage : UserControl
    {
        public LocalStorage()
        {
            InitializeComponent();
        }

        private async void BtnClearImageCache_Click(object sender, EventArgs e)
        {
            BtnClearImageCache.Enabled = false;
            BtnClearImageCache.Text = "cleaning ..";

            await CacheManager.ClearImageCacheAsync();

            MessageBoxAdv.Show("Image cache has been cleared!", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Information);

            BtnClearImageCache.Enabled = true;
            BtnClearImageCache.Text = "clear image cache";
        }

        private void BtnOpenImageCache_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Variables.ImageCachePath)) return;
            if (!Directory.Exists(Variables.ImageCachePath)) Directory.CreateDirectory(Variables.ImageCachePath);

            HelperFunctions.OpenLocalFolder(Variables.ImageCachePath);
        }
    }
}
