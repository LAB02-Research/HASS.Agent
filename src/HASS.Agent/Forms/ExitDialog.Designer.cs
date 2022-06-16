using HASS.Agent.Resources.Localization;

namespace HASS.Agent.Forms
{
    partial class ExitDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExitDialog));
            this.LblInfo1 = new System.Windows.Forms.Label();
            this.BtnRestart = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnHide = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnExit = new Syncfusion.WinForms.Controls.SfButton();
            this.SuspendLayout();
            // 
            // LblInfo1
            // 
            this.LblInfo1.AccessibleDescription = "Question about the user\'s intention.";
            this.LblInfo1.AccessibleName = "Question";
            this.LblInfo1.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblInfo1.Location = new System.Drawing.Point(12, 9);
            this.LblInfo1.Name = "LblInfo1";
            this.LblInfo1.Size = new System.Drawing.Size(355, 43);
            this.LblInfo1.TabIndex = 1;
            this.LblInfo1.Text = Languages.ExitDialog_LblInfo1;
            this.LblInfo1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnRestart
            // 
            this.BtnRestart.AccessibleDescription = "Restart HASS.Agent.";
            this.BtnRestart.AccessibleName = "Restart";
            this.BtnRestart.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnRestart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnRestart.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnRestart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnRestart.ImageSize = new System.Drawing.Size(32, 32);
            this.BtnRestart.Location = new System.Drawing.Point(137, 63);
            this.BtnRestart.Name = "BtnRestart";
            this.BtnRestart.Size = new System.Drawing.Size(105, 84);
            this.BtnRestart.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnRestart.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnRestart.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnRestart.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnRestart.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnRestart.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnRestart.Style.Image = global::HASS.Agent.Properties.Resources.restart_32;
            this.BtnRestart.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnRestart.TabIndex = 1;
            this.BtnRestart.Text = global::HASS.Agent.Resources.Localization.Languages.ExitDialog_BtnRestart;
            this.BtnRestart.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnRestart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnRestart.UseVisualStyleBackColor = false;
            this.BtnRestart.Click += new System.EventHandler(this.BtnRestart_Click);
            // 
            // BtnHide
            // 
            this.BtnHide.AccessibleDescription = "Hide HASS.Agent in the system tray, next to the clock.";
            this.BtnHide.AccessibleName = "Hide";
            this.BtnHide.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnHide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnHide.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnHide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnHide.ImageSize = new System.Drawing.Size(32, 32);
            this.BtnHide.Location = new System.Drawing.Point(262, 63);
            this.BtnHide.Name = "BtnHide";
            this.BtnHide.Size = new System.Drawing.Size(105, 84);
            this.BtnHide.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnHide.Style.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnHide.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnHide.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnHide.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnHide.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnHide.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnHide.Style.Image = global::HASS.Agent.Properties.Resources.hide_32;
            this.BtnHide.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnHide.TabIndex = 0;
            this.BtnHide.Text = global::HASS.Agent.Resources.Localization.Languages.ExitDialog_BtnHide;
            this.BtnHide.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnHide.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnHide.UseVisualStyleBackColor = false;
            this.BtnHide.Click += new System.EventHandler(this.BtnHide_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.AccessibleDescription = "Completely close HASS.Agent.";
            this.BtnExit.AccessibleName = "Exit";
            this.BtnExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnExit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnExit.ImageSize = new System.Drawing.Size(32, 32);
            this.BtnExit.Location = new System.Drawing.Point(12, 63);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(105, 84);
            this.BtnExit.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnExit.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnExit.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnExit.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnExit.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnExit.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnExit.Style.Image = global::HASS.Agent.Properties.Resources.exit_32;
            this.BtnExit.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnExit.TabIndex = 2;
            this.BtnExit.Text = global::HASS.Agent.Resources.Localization.Languages.ExitDialog_BtnExit;
            this.BtnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // ExitDialog
            // 
            this.AccessibleDescription = "Exit, restart or hide HASS.Agent.";
            this.AccessibleName = "Exit";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(378, 158);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.BtnRestart);
            this.Controls.Add(this.BtnHide);
            this.Controls.Add(this.LblInfo1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.Name = "ExitDialog";
            this.ShowMaximizeBox = false;
            this.ShowMinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = Languages.ExitDialog_Title;
            this.Load += new System.EventHandler(this.ExitDialog_Load);
            this.ResizeEnd += new System.EventHandler(this.ExitDialog_ResizeEnd);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ExitDialog_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label LblInfo1;
        private Syncfusion.WinForms.Controls.SfButton BtnRestart;
        private Syncfusion.WinForms.Controls.SfButton BtnHide;
        private Syncfusion.WinForms.Controls.SfButton BtnExit;
    }
}

