using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HASSAgent.Functions;

namespace HASSAgent.Controls.Configuration
{
    public partial class Notifications : UserControl
    {
        public Notifications()
        {
            InitializeComponent();

            TbIntNotifierApiPort.Culture = CultureInfo.InstalledUICulture;
        }

        private void BtnNotificationsReadme_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://github.com/LAB02-Research/HASS.Agent/wiki/Notification-Usage-&-Examples");

        private void Notifications_Load(object sender, EventArgs e)
        {
            //
        }
    }
}
