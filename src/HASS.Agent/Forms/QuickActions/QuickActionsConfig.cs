using HASS.Agent.Functions;
using HASS.Agent.Models.Internal;
using HASS.Agent.Settings;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Grid;

namespace HASS.Agent.Forms.QuickActions
{
    public partial class QuickActionsConfig : MetroForm
    {
        private readonly List<QuickAction> _quickActions = new();

        private bool _storing = false;

        public QuickActionsConfig()
        {
            InitializeComponent();

            BindListViewTheme();
        }

        private void BindListViewTheme()
        {
            LvQuickActions.DrawItem += ListViewTheme.DrawItem;
            LvQuickActions.DrawSubItem += ListViewTheme.DrawSubItem;
            LvQuickActions.DrawColumnHeader += ListViewTheme.DrawColumnHeader;
        }

        private void QuickActionsConfig_Load(object sender, EventArgs e)
        {
            // catch all key presses
            KeyPreview = true;

            // load stored actions
            PrepareQuickActionList();
        }

        /// <summary>
        /// Load the stored quickactions into the grid
        /// </summary>
        private void PrepareQuickActionList()
        {
            // make a copy of the current actions
            foreach (var quickAction in Variables.QuickActions) _quickActions.Add(quickAction);

            // show them
            UpdateQuickActionList();
        }

        /// <summary>
        /// Reload the quickactions
        /// </summary>
        private void UpdateQuickActionList()
        {
            LvQuickActions.BeginUpdate();

            // reload data
            LvQuickActions.Items.Clear();

            foreach (var quickAction in _quickActions)
            {
                var hotkey = quickAction.HotKey;
                if (hotkey == "None") hotkey = string.Empty;

                var lviQuickAction = new ListViewItem(quickAction.Id.ToString());
                lviQuickAction.SubItems.Add(quickAction.Domain.ToString());
                lviQuickAction.SubItems.Add(quickAction.Entity);
                lviQuickAction.SubItems.Add(quickAction.Action.ToString());
                lviQuickAction.SubItems.Add(quickAction.HotKeyEnabled ? "√" : "");
                lviQuickAction.SubItems.Add(hotkey);
                lviQuickAction.SubItems.Add(quickAction.Description);

                LvQuickActions.Items.Add(lviQuickAction);
            }

            LvQuickActions.EndUpdate();
        }

        /// <summary>
        /// Open a new form to modify the selected quickaction
        /// </summary>
        private void ModifySelectedAction()
        {
            // are we currently storing them?
            if (_storing) return;

            // check for selected rows
            if (LvQuickActions.SelectedItems.Count == 0) return;

            // we can just modify one, so the first
            var guid = Guid.Parse(LvQuickActions.SelectedItems[0].Text);
            var selectedQuickAction = _quickActions.Find(x => x.Id == guid);

            // show modding form
            using var quickAction = new QuickActionsMod(selectedQuickAction);
            var res = quickAction.ShowDialog();
            if (res != DialogResult.OK) return;

            // update in temp list
            _quickActions[_quickActions.FindIndex(x => x.Id == quickAction.QuickAction.Id)] = quickAction.QuickAction;

            // reload the gui list
            UpdateQuickActionList();
        }

        /// <summary>
        /// Delete all selected quickactions
        /// <para>Note: doesn't actually execute deletion, that's done after the user clicks 'store'</para>
        /// </summary>
        private void DeleteSelectedActions()
        {
            // check for selected rows
            if (LvQuickActions.SelectedItems.Count == 0) return;

            // iterate them
            foreach (ListViewItem row in LvQuickActions.SelectedItems)
            {
                // get object
                var guid = Guid.Parse(row.Text);

                // remove from the list
                _quickActions.RemoveAt(_quickActions.FindIndex(x => x.Id == guid));
            }

            // reload the gui list
            UpdateQuickActionList();
        }

        /// <summary>
        /// Show a form to add a new quickaction
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using var quickAction = new QuickActionsMod();
            var res = quickAction.ShowDialog();
            if (res != DialogResult.OK) return;

            // add to the temp list
            _quickActions.Add(quickAction.QuickAction);

            // reload the gui list
            UpdateQuickActionList();
        }

        private void BtnModify_Click(object sender, EventArgs e) => ModifySelectedAction();

        /// <summary>
        /// Stores our temporary list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStore_Click(object sender, EventArgs e)
        {
            // copy our list to the main one
            Variables.QuickActions = new List<QuickAction>();
            foreach (var quickAction in _quickActions) Variables.QuickActions.Add(quickAction);

            // store to file
            StoredQuickActions.Store();

            // reload hotkey bindings
            Variables.HotKeyManager.ReloadQuickActionsHotKeys();

            // done
            Close();
        }

        private void BtnRemove_Click(object sender, EventArgs e) => DeleteSelectedActions();

        private void LvQuickActions_DoubleClick(object sender, EventArgs e) => ModifySelectedAction();

        private void BtnPreview_Click(object sender, EventArgs e)
        {
            using var quickActions = new QuickActions(_quickActions);
            quickActions.ShowDialog();
        }

        private void QuickActionsConfig_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape) return;
            Close();
        }

        private void QuickActionsConfig_ResizeEnd(object sender, EventArgs e)
        {
            if (Variables.ShuttingDown) return;
            if (!IsHandleCreated) return;
            if (IsDisposed) return;

            try
            {
                // show the listview
                LvQuickActions.Visible = true;

                // hide the pesky horizontal scrollbar
                ListViewTheme.ShowScrollBar(LvQuickActions.Handle, ListViewTheme.SB_HORZ, false);

                Refresh();
            }
            catch
            {
                // best effort
            }
        }

        private void QuickActionsConfig_ResizeBegin(object sender, EventArgs e)
        {
            if (Variables.ShuttingDown) return;
            if (!IsHandleCreated) return;
            if (IsDisposed) return;

            try
            {
                // hide the listview to prevent flickering
                LvQuickActions.Visible = false;
            }
            catch
            {
                // best effort
            }
        }

        private void QuickActionsConfig_Layout(object sender, LayoutEventArgs e)
        {
            // hide the pesky horizontal scrollbar
            ListViewTheme.ShowScrollBar(LvQuickActions.Handle, ListViewTheme.SB_HORZ, false);
        }
    }
}
