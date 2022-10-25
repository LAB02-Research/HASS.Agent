using HASS.Agent.Resources.Localization;

namespace HASS.Agent.Controls.Onboarding
{
    partial class OnboardingUpdates
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OnboardingUpdates));
            this.PbHassAgentLogo = new System.Windows.Forms.PictureBox();
            this.LblInfo1 = new System.Windows.Forms.Label();
            this.CbNofityOnUpdate = new System.Windows.Forms.CheckBox();
            this.CbExecuteUpdater = new System.Windows.Forms.CheckBox();
            this.LblInfo2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PbHassAgentLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // PbHassAgentLogo
            // 
            this.PbHassAgentLogo.AccessibleDescription = "HASS Agent logo image.";
            this.PbHassAgentLogo.AccessibleName = "HASS Agent logo";
            this.PbHassAgentLogo.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic;
            this.PbHassAgentLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbHassAgentLogo.Image = global::HASS.Agent.Properties.Resources.logo_128;
            this.PbHassAgentLogo.Location = new System.Drawing.Point(24, 20);
            this.PbHassAgentLogo.Name = "PbHassAgentLogo";
            this.PbHassAgentLogo.Size = new System.Drawing.Size(128, 128);
            this.PbHassAgentLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbHassAgentLogo.TabIndex = 2;
            this.PbHassAgentLogo.TabStop = false;
            // 
            // LblInfo1
            // 
            this.LblInfo1.AccessibleDescription = "Updates information.";
            this.LblInfo1.AccessibleName = "Information";
            this.LblInfo1.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo1.Location = new System.Drawing.Point(180, 20);
            this.LblInfo1.Name = "LblInfo1";
            this.LblInfo1.Size = new System.Drawing.Size(606, 128);
            this.LblInfo1.TabIndex = 12;
            this.LblInfo1.Text = Languages.OnboardingUpdates_LblInfo1;
            // 
            // CbNofityOnUpdate
            // 
            this.CbNofityOnUpdate.AccessibleDescription = "Enables being notified on new updates.";
            this.CbNofityOnUpdate.AccessibleName = "Enable update notifications";
            this.CbNofityOnUpdate.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.CbNofityOnUpdate.AutoSize = true;
            this.CbNofityOnUpdate.Checked = true;
            this.CbNofityOnUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbNofityOnUpdate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbNofityOnUpdate.Location = new System.Drawing.Point(180, 160);
            this.CbNofityOnUpdate.Name = "CbNofityOnUpdate";
            this.CbNofityOnUpdate.Size = new System.Drawing.Size(215, 23);
            this.CbNofityOnUpdate.TabIndex = 0;
            this.CbNofityOnUpdate.Text = global::HASS.Agent.Resources.Localization.Languages.OnboardingUpdates_CbNofityOnUpdate;
            this.CbNofityOnUpdate.UseVisualStyleBackColor = true;
            // 
            // CbExecuteUpdater
            // 
            this.CbExecuteUpdater.AccessibleDescription = "Enables automatically downloading the installer, and when \'install\' is pressed, l" +
    "aunching the installer.";
            this.CbExecuteUpdater.AccessibleName = "Enable semi-automatic updater";
            this.CbExecuteUpdater.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.CbExecuteUpdater.AutoSize = true;
            this.CbExecuteUpdater.Checked = true;
            this.CbExecuteUpdater.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbExecuteUpdater.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbExecuteUpdater.Location = new System.Drawing.Point(180, 381);
            this.CbExecuteUpdater.Name = "CbExecuteUpdater";
            this.CbExecuteUpdater.Size = new System.Drawing.Size(305, 23);
            this.CbExecuteUpdater.TabIndex = 1;
            this.CbExecuteUpdater.Text = global::HASS.Agent.Resources.Localization.Languages.OnboardingUpdates_CbExecuteUpdater;
            this.CbExecuteUpdater.UseVisualStyleBackColor = true;
            // 
            // LblInfo2
            // 
            this.LblInfo2.AccessibleDescription = "Information about the working of the semi-automatic updater.";
            this.LblInfo2.AccessibleName = "Semi-automatic updater info";
            this.LblInfo2.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo2.Location = new System.Drawing.Point(180, 207);
            this.LblInfo2.Name = "LblInfo2";
            this.LblInfo2.Size = new System.Drawing.Size(581, 158);
            this.LblInfo2.TabIndex = 31;
            this.LblInfo2.Text = Languages.OnboardingUpdates_LblInfo2;
            this.LblInfo2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // OnboardingUpdates
            // 
            this.AccessibleDescription = "Panel containing the onboarding updates configuration.";
            this.AccessibleName = "Updates";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.LblInfo2);
            this.Controls.Add(this.CbExecuteUpdater);
            this.Controls.Add(this.CbNofityOnUpdate);
            this.Controls.Add(this.LblInfo1);
            this.Controls.Add(this.PbHassAgentLogo);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "OnboardingUpdates";
            this.Size = new System.Drawing.Size(803, 457);
            this.Load += new System.EventHandler(this.OnboardingUpdates_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbHassAgentLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox PbHassAgentLogo;
        private System.Windows.Forms.Label LblInfo1;
        private System.Windows.Forms.CheckBox CbNofityOnUpdate;
        private System.Windows.Forms.CheckBox CbExecuteUpdater;
        private System.Windows.Forms.Label LblInfo2;
    }
}
