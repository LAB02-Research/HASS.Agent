using System;
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
