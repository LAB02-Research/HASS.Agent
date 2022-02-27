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

namespace HASSAgent.Controls.Configuration
{
    public partial class General : UserControl
    {
        public General()
        {
            InitializeComponent();

            TbDisconnectGrace.Culture = CultureInfo.InstalledUICulture;
        }
    }
}
