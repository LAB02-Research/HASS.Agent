using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HASSAgent.Controls.Onboarding
{
    public partial class Updates : UserControl
    {
        public Updates()
        {
            InitializeComponent();
        }

        private void Updates_Load(object sender, EventArgs e)
        {
            CbNofityOnUpdate.Checked = Variables.AppSettings.CheckForUpdates;
        }

        internal bool Store()
        {
            Variables.AppSettings.CheckForUpdates = CbNofityOnUpdate.Checked;
            return true;
        }
    }
}
