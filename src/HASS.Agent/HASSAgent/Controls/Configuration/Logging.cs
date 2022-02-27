using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HASSAgent.Functions;

namespace HASSAgent.Controls.Configuration
{
    public partial class Logging : UserControl
    {
        public Logging()
        {
            InitializeComponent();
        }

        private void LblCoderr_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://coderr.io");
    }
}
