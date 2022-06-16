
using HASS.Agent.Resources.Localization;

namespace HASS.Agent.Forms
{
    partial class WebView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WebView));
            this.WebViewControl = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)(this.WebViewControl)).BeginInit();
            this.SuspendLayout();
            // 
            // WebViewControl
            // 
            this.WebViewControl.AccessibleDescription = "Contains the website that\'s defined for this webview.";
            this.WebViewControl.AccessibleName = "Website";
            this.WebViewControl.AllowExternalDrop = false;
            this.WebViewControl.CreationProperties = null;
            this.WebViewControl.DefaultBackgroundColor = System.Drawing.Color.Transparent;
            this.WebViewControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WebViewControl.Location = new System.Drawing.Point(0, 0);
            this.WebViewControl.Name = "WebViewControl";
            this.WebViewControl.Size = new System.Drawing.Size(1006, 687);
            this.WebViewControl.TabIndex = 0;
            this.WebViewControl.ZoomFactor = 1D;
            // 
            // WebView
            // 
            this.AccessibleDescription = "Contains a webview control.";
            this.AccessibleName = "WebView";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1006, 687);
            this.Controls.Add(this.WebViewControl);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.Name = "WebView";
            this.ShowInTaskbar = false;
            this.ShowMaximizeBox = false;
            this.ShowMinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = Languages.WebView_Title;
            this.Deactivate += new System.EventHandler(this.WebView_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WebView_FormClosing);
            this.Load += new System.EventHandler(this.WebView_Load);
            this.ResizeEnd += new System.EventHandler(this.WebView_ResizeEnd);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.WebView_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.WebViewControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 WebViewControl;
    }
}

