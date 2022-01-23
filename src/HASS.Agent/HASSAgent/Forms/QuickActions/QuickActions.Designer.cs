
namespace HASSAgent.Forms.QuickActions
{
    partial class QuickActions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuickActions));
            this.LblLoading = new System.Windows.Forms.Label();
            this.PnlActions = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // LblLoading
            // 
            this.LblLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblLoading.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLoading.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.LblLoading.Location = new System.Drawing.Point(0, 0);
            this.LblLoading.Name = "LblLoading";
            this.LblLoading.Size = new System.Drawing.Size(407, 125);
            this.LblLoading.TabIndex = 8;
            this.LblLoading.Text = "please wait while your entities are fetched ...";
            this.LblLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblLoading.Visible = false;
            // 
            // PnlActions
            // 
            this.PnlActions.ColumnCount = 2;
            this.PnlActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PnlActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PnlActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlActions.Location = new System.Drawing.Point(0, 0);
            this.PnlActions.Name = "PnlActions";
            this.PnlActions.RowCount = 2;
            this.PnlActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PnlActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PnlActions.Size = new System.Drawing.Size(407, 125);
            this.PnlActions.TabIndex = 9;
            // 
            // QuickActions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(407, 125);
            this.Controls.Add(this.LblLoading);
            this.Controls.Add(this.PnlActions);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(129)))), ((int)(((byte)(131)))));
            this.Name = "QuickActions";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.ShowMaximizeBox = false;
            this.ShowMinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quick Actions";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuickActions_FormClosing);
            this.Load += new System.EventHandler(this.QuickActions_Load);
            this.ResizeEnd += new System.EventHandler(this.QuickActions_ResizeEnd);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.QuickActions_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblLoading;
        private System.Windows.Forms.TableLayoutPanel PnlActions;
    }
}

