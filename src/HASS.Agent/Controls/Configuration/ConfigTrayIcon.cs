using System.Diagnostics;
using HASS.Agent.Functions;
using HASS.Agent.Models.Internal;

namespace HASS.Agent.Controls.Configuration
{
    public partial class ConfigTrayIcon : UserControl
    {
        public ConfigTrayIcon()
        {
            InitializeComponent();
        }

        private void ConfigTrayIcon_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TbWebViewUrl.Text)) TbWebViewUrl.Text = Variables.AppSettings.HassUri;
        }

        private void CbDefaultMenu_CheckedChanged(object sender, EventArgs e)
        {
            CbShowWebView.Checked = !CbDefaultMenu.Checked;
        }

        private void CbShowWebView_CheckedChanged(object sender, EventArgs e)
        {
            CbDefaultMenu.Checked = !CbShowWebView.Checked;

            TbWebViewUrl.Enabled = CbShowWebView.Checked;
            NumWebViewWidth.Enabled = CbShowWebView.Checked;
            NumWebViewHeight.Enabled = CbShowWebView.Checked;
            BtnShowWebViewPreview.Enabled = CbShowWebView.Checked;
        }

        private void BtnShowWebViewPreview_Click(object sender, EventArgs e)
        {
            var webView = new WebViewInfo
            {
                Url = TbWebViewUrl.Text,
                Height = (int)NumWebViewHeight.Value,
                Width = (int)NumWebViewWidth.Value,
            };

            HelperFunctions.LaunchTrayIconWebView(webView);
        }

        private void BtnWebViewReset_Click(object sender, EventArgs e)
        {
            NumWebViewWidth.Value = 700;
            NumWebViewHeight.Value = 560;
        }
    }
}
