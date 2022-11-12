using System.Diagnostics.CodeAnalysis;
using Syncfusion.Windows.Forms;
using HASS.Agent.Functions;
using HASS.Agent.Models.Internal;
using HASS.Agent.Resources.Localization;
using HASS.Agent.Settings;
using Microsoft.Web.WebView2.Core;
using Serilog;
using System.Runtime.InteropServices;
using Windows.Web.UI.Interop;

namespace HASS.Agent.Forms
{
    public partial class WebView : MetroForm
    {
        private readonly WebViewInfo _webViewInfo;
        private bool _forceClose = false;
        private bool _isTrayIcon = false;

        public WebView(WebViewInfo webViewInfo)
        {
            _webViewInfo = webViewInfo;

            InitializeComponent();
        }

        private async void WebView_Load(object sender, EventArgs e)
        {
            try
            {
                // catch all key presses
                KeyPreview = true;

                // set the stored variables
                SetStoredVariables();

                // initialize webview
                var initialized = await InitializeAsync();
                if (!initialized)
                {
                    // failed, abort
                    Close();
                    return;
                }

                // are we background loading for the tray icon, and not in preview mode?
                if (_webViewInfo.IsTrayIconWebView && !_webViewInfo.IsTrayIconPreview && Variables.AppSettings.TrayIconWebViewBackgroundLoading)
                {
                    _isTrayIcon = true;
                    
                    // done
                    return;
                }

                // nope, show ourselves
                Opacity = 100;

                // optionally force topmost
                if (_webViewInfo.TopMost)
                {
                    TopMost = true;
                    BringToFront();
                }

                // reload ui
                Refresh();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[WEBVIEW] Error on loading: {err}", ex.Message);
                _forceClose = true;
                Close();
            }
        }

        private async Task<bool> InitializeAsync()
        {
            try
            {
                // prepare an environment
                if (Variables.WebViewEnvironment == null)
                {
                    Log.Debug("[WEBVIEW] Creating new CoreWebView2Environment");
                    Variables.WebViewEnvironment = await CoreWebView2Environment.CreateAsync(null, Variables.WebViewCachePath, null);
                }

                // bind initialization completed event
                WebViewControl.CoreWebView2InitializationCompleted += WebViewControlOnCoreWebView2InitializationCompleted;
                
                // initialize
                await WebViewControl.EnsureCoreWebView2Async(Variables.WebViewEnvironment);

                // scale
                WebViewControl.Scale(new SizeF(Width, Height));

                // done
                return true;
            }
            catch (WebView2RuntimeNotFoundException ex)
            {
                Log.Fatal(ex, "[WEBVIEW] WebView2 runtime not found, unable to initialize: {err}", ex.Message);

                var q = MessageBoxAdv.Show(this, Languages.WebView_InitializeAsync_MessageBox1,
                    Variables.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                if (q != DialogResult.Yes) return false;

                HelperFunctions.LaunchUrl("https://go.microsoft.com/fwlink/p/?LinkId=2124703");
                return false;
            }
            catch (COMException ex)
            {
                if (ex.Message.Contains("E_ABORT"))
                {
                    // aborted, closing
                    return true;
                }

                Log.Fatal(ex, "[WEBVIEW] WebView2 initialization failed: {err}", ex.Message);

                MessageBoxAdv.Show(this, Languages.WebView_InitializeAsync_MessageBox2, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[WEBVIEW] WebView2 initialization failed: {err}", ex.Message);

                MessageBoxAdv.Show(this, Languages.WebView_InitializeAsync_MessageBox2, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void WebViewControlOnCoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            try
            {
                // make sure the corewebview 2 got loaded
                if (WebViewControl.CoreWebView2 == null)
                {
                    Log.Debug("[WEBVIEW] WebViewControl.CoreWebView2 null, skipping initialization");
                    return;
                }

                // bind title change event
                WebViewControl.CoreWebView2.DocumentTitleChanged += delegate
                {
                    if (IsClosingOrClosed()) return;
                    BeginInvoke(() =>
                    {
                        Text = WebViewControl.CoreWebView2?.DocumentTitle ?? string.Empty;
                    });
                };

                // bind keyup event
                WebViewControl.KeyUp += delegate (object _, KeyEventArgs e)
                {
                    if (e.KeyCode != Keys.Escape) return;
                    Close();
                };

                // load the uri
                WebViewControl.Source = new Uri(_webViewInfo.Url);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[WEBVIEW] Error completing webview initialization: {err}", ex.Message);
            }
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
            if (IsClosingOrClosed()) return;

            try
            {
                // show ourselves
                Opacity = 100;

                // check if we need to move
                var x = Screen.PrimaryScreen.WorkingArea.Width - Width;
                var y = Screen.PrimaryScreen.WorkingArea.Height - Height;

                if (x != _webViewInfo.X || y != _webViewInfo.Y)
                {
                    // yep
                    _webViewInfo.X = x;
                    _webViewInfo.Y = y;
                    Location = new Point(_webViewInfo.X, _webViewInfo.Y);
                }

                // optionally force topmost
                if (_isTrayIcon || _webViewInfo.TopMost)
                {
                    TopMost = true;
                    BringToFront();
                }

                // reload ui
                Refresh();
            }
            catch (Exception ex)
            {
                if (IsClosingOrClosed()) return;
                Log.Error("[WEBVIEW] Error while showing: {err}", ex.Message);
                _forceClose = true;
                Close();
            }
        }

        private void WebView_ResizeEnd(object sender, EventArgs e)
        {
            try
            {
                if (IsClosingOrClosed()) return;

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
            try
            {
                // always exit on windows shutdown, application-wide shutdown or when forced
                if (e.CloseReason == CloseReason.WindowsShutDown || Variables.ShuttingDown || _forceClose)
                {
                    WebViewControl.CoreWebView2InitializationCompleted -= WebViewControlOnCoreWebView2InitializationCompleted;
                    WebViewControl?.Dispose();
                    e.Cancel = false;
                    return;
                }

                // do we need to stay open?
                if (_isTrayIcon)
                {
                    Opacity = 0;
                    e.Cancel = true;
                    return;
                }

                // nope, dispose
                WebViewControl.CoreWebView2InitializationCompleted -= WebViewControlOnCoreWebView2InitializationCompleted;
                WebViewControl?.Dispose();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, ex.Message);
            }
        }

        private void WebView_Deactivate(object sender, EventArgs e) => Close();

        private bool IsClosingOrClosed()
        {
            if (Variables.ShuttingDown) return true;
            if (!IsHandleCreated) return true;
            if (IsDisposed) return true;
            return false;
        }

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
