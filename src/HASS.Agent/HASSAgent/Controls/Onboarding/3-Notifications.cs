using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using HASSAgent.Functions;
using Newtonsoft.Json;
using Serilog;
using Syncfusion.Windows.Forms;

namespace HASSAgent.Controls.Onboarding
{
    public partial class Notifications : UserControl
    {
        public Notifications()
        {
            InitializeComponent();

            TbIntNotifierApiPort.Culture = CultureInfo.InstalledUICulture;
        }

        private void Notifications_Load(object sender, EventArgs e)
        {
            // hide group seperator
            TbIntNotifierApiPort.NumberGroupSeparator = "";

            CbAcceptNotifications.Checked = Variables.AppSettings.NotificationsEnabled;
            TbIntNotifierApiPort.IntegerValue = Variables.AppSettings.NotifierApiPort;
        }

        internal bool Store()
        {
            Variables.AppSettings.NotificationsEnabled = CbAcceptNotifications.Checked;
            Variables.AppSettings.NotifierApiPort = (int)TbIntNotifierApiPort.IntegerValue;
            
            return true;
        }
    }
}
