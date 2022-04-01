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
            this.LblInfo1.AutoSize = true;
            this.LblInfo1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo1.Location = new System.Drawing.Point(180, 20);
            this.LblInfo1.Name = "LblInfo1";
            this.LblInfo1.Size = new System.Drawing.Size(606, 95);
            this.LblInfo1.TabIndex = 12;
            this.LblInfo1.Text = Languages.OnboardingUpdates_LblInfo1;
            // 
            // CbNofityOnUpdate
            // 
            this.CbNofityOnUpdate.AutoSize = true;
            this.CbNofityOnUpdate.Checked = true;
            this.CbNofityOnUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbNofityOnUpdate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbNofityOnUpdate.Location = new System.Drawing.Point(180, 160);
            this.CbNofityOnUpdate.Name = "CbNofityOnUpdate";
            this.CbNofityOnUpdate.Size = new System.Drawing.Size(215, 23);
            this.CbNofityOnUpdate.TabIndex = 26;
            this.CbNofityOnUpdate.Text = Languages.OnboardingUpdates_CbNofityOnUpdate;
            this.CbNofityOnUpdate.UseVisualStyleBackColor = true;
            // 
            // CbExecuteUpdater
            // 
            this.CbExecuteUpdater.AutoSize = true;
            this.CbExecuteUpdater.Checked = true;
            this.CbExecuteUpdater.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbExecuteUpdater.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbExecuteUpdater.Location = new System.Drawing.Point(180, 358);
            this.CbExecuteUpdater.Name = "CbExecuteUpdater";
            this.CbExecuteUpdater.Size = new System.Drawing.Size(305, 23);
            this.CbExecuteUpdater.TabIndex = 27;
            this.CbExecuteUpdater.Text = Languages.OnboardingUpdates_CbExecuteUpdater;
            this.CbExecuteUpdater.UseVisualStyleBackColor = true;
            // 
            // LblInfo2
            // 
            this.LblInfo2.AutoSize = true;
            this.LblInfo2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo2.Location = new System.Drawing.Point(180, 238);
            this.LblInfo2.Name = "LblInfo2";
            this.LblInfo2.Size = new System.Drawing.Size(581, 76);
            this.LblInfo2.TabIndex = 31;
            this.LblInfo2.Text = Languages.OnboardingUpdates_LblInfo2;
            // 
            // Updates
            // 
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
            this.Name = "Updates";
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
