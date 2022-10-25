using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Syncfusion.Windows.Forms;
using HASS.Agent.Functions;
using HASS.Agent.Models.Internal;
using HASS.Agent.Resources.Localization;
using HASS.Agent.Settings;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Core.Raw;
using Serilog;
using Action = System.Action;

namespace HASS.Agent.Forms
{
    public partial class WebView : MetroForm
    {
        private readonly WebViewInfo _webViewInfo;
        private bool _forceClose = false;

        public WebView(WebViewInfo webViewInfo)
        {
            _webViewInfo = webViewInfo;

            InitializeComponent();
        }

        private async void WebView_Load(object sender, EventArgs e)
        {
            // catch all key presses
            KeyPreview = true;

            // initialize webview
            var initialized = await InitializeAsync();
            if (!initialized)
            {
                // failed, abort
                Close();
                return;
            }

            // bind events (drag, title change, ..)
            BindWebViewEvents();

            // set the stored variables
            SetStoredVariables();

            // are we background loading for the tray icon, and not in preview mode?
            if (_webViewInfo.IsTrayIconWebView && !_webViewInfo.IsTrayIconPreview && Variables.AppSettings.TrayIconWebViewBackgroundLoading)
            {
                // just load the uri
                WebViewControl.Source = new Uri(_webViewInfo.Url);

                // done
                return;
            }

            // nope, show ourselves
            Opacity = 100;

            // reload ui
            Refresh();

            // load the uri
            WebViewControl.Source = new Uri(_webViewInfo.Url);
        }

        private async Task<bool> InitializeAsync()
        {
            try
            {
                // prepare an environment
                var webViewEnv = await CoreWebView2Environment.CreateAsync(null, Variables.WebViewCachePath, null);

                // initialize
                await WebViewControl.EnsureCoreWebView2Async(webViewEnv);

                // scale
                WebViewControl.Scale(new SizeF(Width, Height));

                // done
                return true;
            }
            catch (WebView2RuntimeNotFoundException ex)
            {
                Log.Fatal(ex, "[WEBVIEW] WebView2 runtime not found, unable to initialize: {err}", ex.Message);

                var q = MessageBoxAdv.Show(Languages.WebView_InitializeAsync_MessageBox1,
                    Variables.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                if (q != DialogResult.Yes) return false;
                
                HelperFunctions.LaunchUrl("https://go.microsoft.com/fwlink/p/?LinkId=2124703");
                return false;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[WEBVIEW] WebView2 initialization failed: {err}", ex.Message);

                MessageBoxAdv.Show(Languages.WebView_InitializeAsync_MessageBox2, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void BindWebViewEvents()
        {
            // bind title change event
            WebViewControl.CoreWebView2.DocumentTitleChanged += delegate
            {
                BeginInvoke(() =>
                {
                    Text = WebViewControl.CoreWebView2.DocumentTitle;
                });
            };

            // bind keyup event
            WebViewControl.KeyUp += delegate (object _, KeyEventArgs e)
            {
                if (e.KeyCode != Keys.Escape) return;
                Close();
            };
        }

        private void SetStoredVariables()
        {
            try
            {
                // set topmost
                TopMost = _webViewInfo.TopMost;

                // set the border style
                if (!_webViewInfo.ShowTitleBar) FormBorderStyle = FormBorderStyle.None;

                // set the size
                Height = _webViewInfo.Height;
                Width = _webViewInfo.Width;

                // optionally set the location
                if (!_webViewInfo.CenterScreen) Location = new Point(_webViewInfo.X, _webViewInfo.Y);
            }
            catch (Exception ex)
            {
                Log.Error("[WEBVIEW] Unable to set stored settings: {err}", ex.Message);
            }
        }

        /// <summary>
        /// Shows the form
        /// </summary>
        internal void MakeVisible()
        {
            // show ourselves
            Opacity = 100;

            // reload ui
            Refresh();
        }

        private void WebView_ResizeEnd(object sender, EventArgs e)
        {
            if (Variables.ShuttingDown) return;
            if (!IsHandleCreated) return;
            if (IsDisposed) return;

            try
            {
                Refresh();

                if (!_webViewInfo.IsTrayIconWebView) return;

                // we're running as a tray icon webview, store new size
                Variables.AppSettings.TrayIconWebViewWidth = Width;
                Variables.AppSettings.TrayIconWebViewHeight = Height;
                SettingsManager.StoreAppSettings();
            }
            catch
            {
                // best effort
            }
        }
        
        private void WebView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape) return;
            Close();
        }

        private void WebView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown || Variables.ShuttingDown)
            {
                // always exit on windows shutdown, or application-wide shutdown
                WebViewControl?.Dispose();
                e.Cancel = false;
                return;
            }

            if (_forceClose)
            {
                // we're being forced
                WebViewControl?.Dispose();
                e.Cancel = false;
                return;
            }

            // do we need to stay open?
            if (_webViewInfo.IsTrayIconWebView && !_webViewInfo.IsTrayIconPreview && Variables.AppSettings.TrayIconWebViewBackgroundLoading)
            {
                Opacity = 0;
                e.Cancel = true;
                return;
            }

            // nope, dispose
            WebViewControl?.Dispose();
        }

        private void WebView_Deactivate(object sender, EventArgs e) => Close();

        internal void ForceClose()
        {
            _forceClose = true;
            Close();
        }

        /// <summary>
        /// Hook deactivation message
        /// </summary>
        /// <param name="m"></param>
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        protected override void WndProc(ref Message m)
        {
            const int WM_ACTIVATEAPP = 0x001C;

            if (m.Msg == WM_ACTIVATEAPP)
            {
                // 0 means deactivation
                if (m.WParam.ToInt64() == 0) Close();
            }

            base.WndProc(ref m);
        }
    }
}
