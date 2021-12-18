using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WK.Libraries.HotkeyListenerNS;

namespace HASSAgent.Controls.Onboarding
{
    public partial class HotKey : UserControl
    {
        private readonly HotkeySelector _hotkeySelector = new HotkeySelector();

        public HotKey()
        {
            InitializeComponent();
        }

        private void HotKey_Load(object sender, EventArgs e)
        {
            // config quick actions hotkey selector
            _hotkeySelector.Enable(TbQuickActionsHotkey);

            // if nothing set, load default
            if (string.IsNullOrEmpty(Variables.AppSettings.QuickActionsHotKey)) TbQuickActionsHotkey.Text = "Control, Alt + Q";
            // if set to empty, show empty
            else if (Variables.AppSettings.QuickActionsHotKey == _hotkeySelector.EmptyHotkeyText) TbQuickActionsHotkey.Text = _hotkeySelector.EmptyHotkeyText;
            // show set value
            else TbQuickActionsHotkey.Text = Variables.AppSettings.QuickActionsHotKey;
        }

        internal bool Store()
        {
            Variables.AppSettings.QuickActionsHotKey = TbQuickActionsHotkey.Text;
            _hotkeySelector.Dispose();
            return true;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            TbQuickActionsHotkey.Text = _hotkeySelector.EmptyHotkeyText;
        }
    }
}
