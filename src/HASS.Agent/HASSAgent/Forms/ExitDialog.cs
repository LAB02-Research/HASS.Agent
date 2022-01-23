using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using HASSAgent.Functions;
using HASSAgent.Notifications;
using HASSAgent.Properties;
using HASSAgent.Settings;
using Microsoft.Win32.TaskScheduler;
using Serilog;
using Syncfusion.Windows.Forms;
using Task = System.Threading.Tasks.Task;

namespace HASSAgent.Forms
{
    public partial class ExitDialog : MetroForm
    {
        public bool Exit { get; private set; }
        public bool Restart { get; private set; }
        public bool HideToTray { get; private set; }

        public ExitDialog()
        {
            InitializeComponent();
        }

        private void ExitDialog_Load(object sender, EventArgs e)
        {
            // catch all key presses
            KeyPreview = true;

            ActiveControl = BtnHide;
            BtnHide.Focus();
        }

        private void ExitDialog_ResizeEnd(object sender, EventArgs e)
        {
            if (Variables.ShuttingDown) return;
            if (!IsHandleCreated) return;
            if (IsDisposed) return;

            try
            {
                Refresh();
            }
            catch
            {
                // best effort
            }
        }

        private void ExitDialog_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape) return;
            DialogResult = DialogResult.Abort;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Exit = true;
            DialogResult = DialogResult.OK;
        }

        private void BtnRestart_Click(object sender, EventArgs e)
        {
            Restart = true;
            DialogResult = DialogResult.OK;
        }

        private void BtnHide_Click(object sender, EventArgs e)
        {
            HideToTray = true;
            DialogResult = DialogResult.OK;
        }
    }
}
