using HASS.Agent.Resources.Localization;

namespace HASS.Agent.Controls.Configuration
{
    partial class ConfigUpdates
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigUpdates));
            this.CbBetaUpdates = new System.Windows.Forms.CheckBox();
            this.LblInfo2 = new System.Windows.Forms.Label();
            this.CbExecuteUpdater = new System.Windows.Forms.CheckBox();
            this.LblInfo1 = new System.Windows.Forms.Label();
            this.CbUpdates = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // CbBetaUpdates
            // 
            this.CbBetaUpdates.AutoSize = true;
            this.CbBetaUpdates.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbBetaUpdates.Location = new System.Drawing.Point(207, 209);
            this.CbBetaUpdates.Name = "CbBetaUpdates";
            this.CbBetaUpdates.Size = new System.Drawing.Size(229, 23);
            this.CbBetaUpdates.TabIndex = 39;
            this.CbBetaUpdates.Text = Languages.ConfigUpdates_CbBetaUpdates;
            this.CbBetaUpdates.UseVisualStyleBackColor = true;
            // 
            // LblInfo2
            // 
            this.LblInfo2.AutoSize = true;
            this.LblInfo2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo2.Location = new System.Drawing.Point(70, 293);
            this.LblInfo2.Name = "LblInfo2";
            this.LblInfo2.Size = new System.Drawing.Size(581, 76);
            this.LblInfo2.TabIndex = 38;
            this.LblInfo2.Text = Languages.ConfigUpdates_LblInfo2;
            // 
            // CbExecuteUpdater
            // 
            this.CbExecuteUpdater.AutoSize = true;
            this.CbExecuteUpdater.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbExecuteUpdater.Location = new System.Drawing.Point(207, 422);
            this.CbExecuteUpdater.Name = "CbExecuteUpdater";
            this.CbExecuteUpdater.Size = new System.Drawing.Size(327, 23);
            this.CbExecuteUpdater.TabIndex = 37;
            this.CbExecuteUpdater.Text = Languages.ConfigUpdates_CbExecuteUpdater;
            this.CbExecuteUpdater.UseVisualStyleBackColor = true;
            // 
            // LblInfo1
            // 
            this.LblInfo1.AutoSize = true;
            this.LblInfo1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo1.Location = new System.Drawing.Point(70, 36);
            this.LblInfo1.Name = "LblInfo1";
            this.LblInfo1.Size = new System.Drawing.Size(606, 57);
            this.LblInfo1.TabIndex = 36;
            this.LblInfo1.Text = Languages.ConfigUpdates_LblInfo1;
            // 
            // CbUpdates
            // 
            this.CbUpdates.AutoSize = true;
            this.CbUpdates.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbUpdates.Location = new System.Drawing.Point(207, 158);
            this.CbUpdates.Name = "CbUpdates";
            this.CbUpdates.Size = new System.Drawing.Size(278, 23);
            this.CbUpdates.TabIndex = 35;
            this.CbUpdates.Text = Languages.ConfigUpdates_CbUpdates;
            this.CbUpdates.UseVisualStyleBackColor = true;
            // 
            // Updates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.CbBetaUpdates);
            this.Controls.Add(this.LblInfo2);
            this.Controls.Add(this.CbExecuteUpdater);
            this.Controls.Add(this.LblInfo1);
            this.Controls.Add(this.CbUpdates);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Updates";
            this.Size = new System.Drawing.Size(740, 544);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LblInfo2;
        private System.Windows.Forms.Label LblInfo1;
        internal System.Windows.Forms.CheckBox CbBetaUpdates;
        internal System.Windows.Forms.CheckBox CbExecuteUpdater;
        internal System.Windows.Forms.CheckBox CbUpdates;
    }
}
