using System.Diagnostics;
using HASS.Agent.Functions;

namespace HASS.Agent.Controls.Configuration
{
    public partial class ConfigLogging : UserControl
    {
        public ConfigLogging()
        {
            InitializeComponent();
        }

        private void BtnShowLogs_Click(object sender, EventArgs e) => HelperFunctions.OpenLocalFolder(Variables.LogPath);
    }
}
