
namespace HASSAgent.Controls
{
    partial class QuickActionControl
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
            this.PbImage = new System.Windows.Forms.PictureBox();
            this.LblEntity = new System.Windows.Forms.Label();
            this.LblAction = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // PbImage
            // 
            this.PbImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbImage.Image = global::HASSAgent.Properties.Resources.hass_avatar;
            this.PbImage.Location = new System.Drawing.Point(12, 13);
            this.PbImage.Name = "PbImage";
            this.PbImage.Size = new System.Drawing.Size(128, 128);
            this.PbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbImage.TabIndex = 0;
            this.PbImage.TabStop = false;
            this.PbImage.Click += new System.EventHandler(this.PbImage_Click);
            // 
            // LblEntity
            // 
            this.LblEntity.BackColor = System.Drawing.Color.Transparent;
            this.LblEntity.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblEntity.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblEntity.Location = new System.Drawing.Point(9, 180);
            this.LblEntity.Name = "LblEntity";
            this.LblEntity.Size = new System.Drawing.Size(131, 60);
            this.LblEntity.TabIndex = 1;
            this.LblEntity.Text = "-";
            this.LblEntity.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.LblEntity.Click += new System.EventHandler(this.LblEntity_Click);
            // 
            // LblAction
            // 
            this.LblAction.BackColor = System.Drawing.Color.Transparent;
            this.LblAction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblAction.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblAction.ForeColor = System.Drawing.Color.DarkGray;
            this.LblAction.Location = new System.Drawing.Point(0, 144);
            this.LblAction.Name = "LblAction";
            this.LblAction.Size = new System.Drawing.Size(152, 17);
            this.LblAction.TabIndex = 2;
            this.LblAction.Text = "[ TOGGLE ]";
            this.LblAction.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.LblAction.Click += new System.EventHandler(this.LblAction_Click);
            // 
            // QuickActionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.LblAction);
            this.Controls.Add(this.LblEntity);
            this.Controls.Add(this.PbImage);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Name = "QuickActionControl";
            this.Size = new System.Drawing.Size(152, 255);
            this.Load += new System.EventHandler(this.QuickActionControl_Load);
            this.Click += new System.EventHandler(this.QuickActionControl_Click);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.QuickActionControl_KeyUp);
            this.MouseEnter += new System.EventHandler(this.QuickActionControl_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.QuickActionControl_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.PbImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PbImage;
        private System.Windows.Forms.Label LblEntity;
        private System.Windows.Forms.Label LblAction;
    }
}
