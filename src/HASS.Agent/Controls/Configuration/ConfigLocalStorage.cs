using System.Diagnostics;
using HASS.Agent.Functions;
using HASS.Agent.Resources.Localization;
using Syncfusion.Windows.Forms;

namespace HASS.Agent.Controls.Configuration
{
    public partial class ConfigLocalStorage : UserControl
    {
        public ConfigLocalStorage()
        {
            InitializeComponent();
        }

        private async void BtnClearImageCache_Click(object sender, EventArgs e)
        {
            BtnClearImageCache.Enabled = false;
            BtnClearImageCache.Text = Languages.ConfigLocalStorage_BtnClearImageCache_InfoText1;

            await CacheManager.ClearImageCacheAsync();

            MessageBoxAdv.Show(Languages.ConfigLocalStorage_BtnClearImageCache_MessageBox1, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

            BtnClearImageCache.Enabled = true;
            BtnClearImageCache.Text = Languages.ConfigLocalStorage_BtnClearImageCache;
        }

        private void BtnOpenImageCache_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Variables.ImageCachePath)) return;
            if (!Directory.Exists(Variables.ImageCachePath)) Directory.CreateDirectory(Variables.ImageCachePath);

            HelperFunctions.OpenLocalFolder(Variables.ImageCachePath);
        }
    }
}
