using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HASSAgent.Functions;

namespace HASSAgent.Controls.Onboarding
{
    public partial class Integration : UserControl
    {
        public Integration()
        {
            InitializeComponent();
        }

        private void Integration_Load(object sender, EventArgs e)
        {
            //
        }

        private void LblIntegration_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://github.com/LAB02-Research/HASS.Agent-Notifier");
    }
}
