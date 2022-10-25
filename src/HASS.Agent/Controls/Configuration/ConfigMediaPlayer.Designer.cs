using HASS.Agent.Resources.Localization;

namespace HASS.Agent.Controls.Configuration
{
    partial class ConfigMediaPlayer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigMediaPlayer));
            this.LblInfo2 = new System.Windows.Forms.Label();
            this.LblInfo1 = new System.Windows.Forms.Label();
            this.BtnMediaPlayerReadme = new Syncfusion.WinForms.Controls.SfButton();
            this.CbEnableMediaPlayer = new System.Windows.Forms.CheckBox();
            this.LblConnectivityDisabled = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LblInfo2
            // 
            this.LblInfo2.AccessibleDescription = "Debugging info in case the media player doesn\'t work.";
            this.LblInfo2.AccessibleName = "Debugging info";
            this.LblInfo2.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo2.Location = new System.Drawing.Point(37, 336);
            this.LblInfo2.Name = "LblInfo2";
            this.LblInfo2.Size = new System.Drawing.Size(643, 192);
            this.LblInfo2.TabIndex = 37;
            this.LblInfo2.Text = Languages.ConfigMediaPlayer_LblInfo2;
            // 
            // LblInfo1
            // 
            this.LblInfo1.AccessibleDescription = "Media player information.";
            this.LblInfo1.AccessibleName = "Information";
            this.LblInfo1.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo1.Location = new System.Drawing.Point(70, 36);
            this.LblInfo1.Name = "LblInfo1";
            this.LblInfo1.Size = new System.Drawing.Size(575, 104);
            this.LblInfo1.TabIndex = 36;
            this.LblInfo1.Text = Languages.ConfigMediaPlayer_LblInfo1;
            // 
            // BtnMediaPlayerReadme
            // 
            this.BtnMediaPlayerReadme.AccessibleDescription = "Launches the media player documentation webpage.";
            this.BtnMediaPlayerReadme.AccessibleName = "Open documentation";
            this.BtnMediaPlayerReadme.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnMediaPlayerReadme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnMediaPlayerReadme.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnMediaPlayerReadme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnMediaPlayerReadme.Location = new System.Drawing.Point(452, 497);
            this.BtnMediaPlayerReadme.Name = "BtnMediaPlayerReadme";
            this.BtnMediaPlayerReadme.Size = new System.Drawing.Size(228, 31);
            this.BtnMediaPlayerReadme.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnMediaPlayerReadme.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnMediaPlayerReadme.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnMediaPlayerReadme.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnMediaPlayerReadme.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnMediaPlayerReadme.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnMediaPlayerReadme.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnMediaPlayerReadme.TabIndex = 1;
            this.BtnMediaPlayerReadme.Text = Languages.ConfigMediaPlayer_BtnMediaPlayerReadme;
            this.BtnMediaPlayerReadme.UseVisualStyleBackColor = false;
            this.BtnMediaPlayerReadme.Click += new System.EventHandler(this.BtnNotificationsReadme_Click);
            // 
            // CbEnableMediaPlayer
            // 
            this.CbEnableMediaPlayer.AccessibleDescription = "Enable the MediaPlayer functionality.";
            this.CbEnableMediaPlayer.AccessibleName = "Enable MediaPlayer";
            this.CbEnableMediaPlayer.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.CbEnableMediaPlayer.AutoSize = true;
            this.CbEnableMediaPlayer.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbEnableMediaPlayer.Location = new System.Drawing.Point(232, 174);
            this.CbEnableMediaPlayer.Name = "CbEnableMediaPlayer";
            this.CbEnableMediaPlayer.Size = new System.Drawing.Size(229, 23);
            this.CbEnableMediaPlayer.TabIndex = 0;
            this.CbEnableMediaPlayer.Text = Languages.ConfigMediaPlayer_CbEnableMediaPlayer;
            this.CbEnableMediaPlayer.UseVisualStyleBackColor = true;
            // 
            // LblConnectivityDisabled
            // 
            this.LblConnectivityDisabled.AccessibleDescription = "Warns that the local api or mqtt needs to be enabled for this to work.";
            this.LblConnectivityDisabled.AccessibleName = "Connectivity warning";
            this.LblConnectivityDisabled.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblConnectivityDisabled.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblConnectivityDisabled.ForeColor = System.Drawing.Color.OrangeRed;
            this.LblConnectivityDisabled.Location = new System.Drawing.Point(17, 263);
            this.LblConnectivityDisabled.Name = "LblConnectivityDisabled";
            this.LblConnectivityDisabled.Size = new System.Drawing.Size(663, 54);
            this.LblConnectivityDisabled.TabIndex = 62;
            this.LblConnectivityDisabled.Text = Languages.ConfigMediaPlayer_LblConnectivityDisabled;
            this.LblConnectivityDisabled.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.LblConnectivityDisabled.Visible = false;
            // 
            // ConfigMediaPlayer
            // 
            this.AccessibleDescription = "Panel containing the media player integration\'s configuration.";
            this.AccessibleName = "Media player";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.LblConnectivityDisabled);
            this.Controls.Add(this.LblInfo1);
            this.Controls.Add(this.BtnMediaPlayerReadme);
            this.Controls.Add(this.CbEnableMediaPlayer);
            this.Controls.Add(this.LblInfo2);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ConfigMediaPlayer";
            this.Size = new System.Drawing.Size(700, 544);
            this.Load += new System.EventHandler(this.ConfigMediaPlayer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblInfo2;
        private System.Windows.Forms.Label LblInfo1;
        internal Syncfusion.WinForms.Controls.SfButton BtnMediaPlayerReadme;
        internal System.Windows.Forms.CheckBox CbEnableMediaPlayer;
        private Label LblConnectivityDisabled;
    }
}
