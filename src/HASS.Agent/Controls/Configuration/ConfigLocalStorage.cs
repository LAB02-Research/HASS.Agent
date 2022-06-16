using System.Diagnostics;
using HASS.Agent.Functions;
using HASS.Agent.Managers;
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

        private void ConfigLocalStorage_Load(object sender, EventArgs e)
        {
            //
        }

        private async void BtnClearAudioCache_Click(object sender, EventArgs e)
        {
            BtnClearAudioCache.Enabled = false;
            BtnClearAudioCache.Text = Languages.ConfigLocalStorage_BtnClearAudioCache_InfoText1;

            await CacheManager.ClearAudioCacheAsync();

            MessageBoxAdv.Show(Languages.ConfigLocalStorage_BtnClearAudioCache_MessageBox1, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

            BtnClearAudioCache.Enabled = true;
            BtnClearAudioCache.Text = Languages.ConfigLocalStorage_BtnClearAudioCache;
        }

        private void BtnOpenAudioCache_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Variables.AudioCachePath)) return;
            if (!Directory.Exists(Variables.AudioCachePath)) Directory.CreateDirectory(Variables.AudioCachePath);

            HelperFunctions.OpenLocalFolder(Variables.AudioCachePath);
        }

        private async void BtnClearWebViewCache_Click(object sender, EventArgs e)
        {
            BtnClearWebViewCache.Enabled = false;
            BtnClearWebViewCache.Text = Languages.ConfigLocalStorage_BtnClearWebViewCache_InfoText1;

            await CacheManager.ClearWebViewCacheAsync();

            MessageBoxAdv.Show(Languages.ConfigLocalStorage_BtnClearWebViewCache_MessageBox1, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

            BtnClearWebViewCache.Enabled = true;
            BtnClearWebViewCache.Text = Languages.ConfigLocalStorage_BtnClearWebViewCache;
        }

        private void BtnOpenWebViewCache_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Variables.WebViewCachePath)) return;
            if (!Directory.Exists(Variables.WebViewCachePath)) Directory.CreateDirectory(Variables.WebViewCachePath);

            HelperFunctions.OpenLocalFolder(Variables.WebViewCachePath);
        }
    }
}
