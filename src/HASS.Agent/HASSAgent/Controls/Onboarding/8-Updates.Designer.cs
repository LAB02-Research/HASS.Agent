namespace HASSAgent.Controls.Onboarding
{
    partial class Updates
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Updates));
            this.PbHassAgentLogo = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CbNofityOnUpdate = new System.Windows.Forms.CheckBox();
            this.CbExecuteUpdater = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PbHassAgentLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // PbHassAgentLogo
            // 
            this.PbHassAgentLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbHassAgentLogo.Image = global::HASSAgent.Properties.Resources.logo_128;
            this.PbHassAgentLogo.Location = new System.Drawing.Point(24, 20);
            this.PbHassAgentLogo.Name = "PbHassAgentLogo";
            this.PbHassAgentLogo.Size = new System.Drawing.Size(128, 128);
            this.PbHassAgentLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbHassAgentLogo.TabIndex = 2;
            this.PbHassAgentLogo.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(180, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(401, 128);
            this.label1.TabIndex = 12;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // CbNofityOnUpdate
            // 
            this.CbNofityOnUpdate.AutoSize = true;
            this.CbNofityOnUpdate.Checked = true;
            this.CbNofityOnUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbNofityOnUpdate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbNofityOnUpdate.Location = new System.Drawing.Point(183, 151);
            this.CbNofityOnUpdate.Name = "CbNofityOnUpdate";
            this.CbNofityOnUpdate.Size = new System.Drawing.Size(204, 21);
            this.CbNofityOnUpdate.TabIndex = 26;
            this.CbNofityOnUpdate.Text = "yes, notify me on new updates";
            this.CbNofityOnUpdate.UseVisualStyleBackColor = true;
            // 
            // CbExecuteUpdater
            // 
            this.CbExecuteUpdater.AutoSize = true;
            this.CbExecuteUpdater.Checked = true;
            this.CbExecuteUpdater.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbExecuteUpdater.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbExecuteUpdater.Location = new System.Drawing.Point(183, 296);
            this.CbExecuteUpdater.Name = "CbExecuteUpdater";
            this.CbExecuteUpdater.Size = new System.Drawing.Size(292, 21);
            this.CbExecuteUpdater.TabIndex = 27;
            this.CbExecuteUpdater.Text = "yes, download and launch the installer for me";
            this.CbExecuteUpdater.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(180, 200);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(401, 79);
            this.label8.TabIndex = 31;
            this.label8.Text = resources.GetString("label8.Text");
            // 
            // Updates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CbExecuteUpdater);
            this.Controls.Add(this.CbNofityOnUpdate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PbHassAgentLogo);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Updates";
            this.Size = new System.Drawing.Size(610, 364);
            this.Load += new System.EventHandler(this.Updates_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbHassAgentLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox PbHassAgentLogo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CbNofityOnUpdate;
        private System.Windows.Forms.CheckBox CbExecuteUpdater;
        private System.Windows.Forms.Label label8;
    }
}
