using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HASSAgent.Models.Internal;
using HASSAgent.Settings;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Grid;

namespace HASSAgent.Forms.QuickActions
{
    public partial class QuickActionsConfig : MetroForm
    {
        private readonly List<QuickAction> _quickActions = new List<QuickAction>();

        private int _heightDiff;

        public QuickActionsConfig()
        {
            InitializeComponent();
        }

        private void QuickActionsConfig_Load(object sender, EventArgs e)
        {
            // set the initial height difference for resizing
            _heightDiff = Height - LcQuickActions.Height;

            // catch all key presses
            KeyPreview = true;

            // load stored actions
            PrepareQuickActionList();

            // set all flags to 'max one row'
            LcQuickActions.Grid.AllowDragSelectedCols = false;
            LcQuickActions.Grid.AllowSelection = GridSelectionFlags.Row;
            LcQuickActions.Grid.AllowDragSelectedRows = false;
            LcQuickActions.Grid.ListBoxSelectionMode = SelectionMode.One;
            LcQuickActions.SelectionMode = SelectionMode.One;

            // we have to refresh after selecting, otherwise a bunch of rows stay highlighted :\
            LcQuickActions.Grid.SelectionChanged += (o, args) => LcQuickActions.Grid.Refresh();
            LcQuickActions.Grid.SelectionChanging += (o, args) => LcQuickActions.Grid.Refresh();
        }

        /// <summary>
        /// Load the stored quickactions into the grid
        /// </summary>
        private void PrepareQuickActionList()
        {
            // make a copy of the current actions
            foreach (var quickAction in Variables.QuickActions) _quickActions.Add(quickAction);

            // bind to the list
            LcQuickActions.DataSource = _quickActions;

            // hide muid column
            LcQuickActions.Grid.HideCols["Id"] = true;

            // force column resize
            LcQuickActions.Grid.ColWidths.ResizeToFit(GridRangeInfo.Table(), GridResizeToFitOptions.IncludeHeaders);

            // set header height
            LcQuickActions.Grid.RowHeights[0] = 25;

            // add extra space
            for (var i = 1; i <= LcQuickActions.Grid.ColCount; i++) LcQuickActions.Grid.ColWidths[i] += 15;

            // redraw
            LcQuickActions.Refresh();
        }

        /// <summary>
        /// Reload the quickactions
        /// </summary>
        private void UpdateQuickActionList()
        {
            // reload data
            LcQuickActions.Grid.ResetVolatileData();

            // force column resize
            LcQuickActions.Grid.ColWidths.ResizeToFit(GridRangeInfo.Table(), GridResizeToFitOptions.IncludeHeaders);

            // add extra space
            for (var i = 1; i <= LcQuickActions.Grid.ColCount; i++) LcQuickActions.Grid.ColWidths[i] += 15;

            // redraw
            LcQuickActions.Refresh();
        }

        /// <summary>
        /// Open a new form to modify the selected quickaction
        /// </summary>
        private void ModifySelectedAction()
        {
            // find all (if any) selected rows
            var selectedRows = LcQuickActions.Grid.Selections.GetSelectedRows(true, true);
            if (selectedRows.Count == 0) return;
            
            // we can just modify one, so the first
            var selectedRow = selectedRows[0];
            var selectedAction = (QuickAction)LcQuickActions.Items[selectedRow.Top - 1];

            if (selectedAction.Id == Guid.Empty)
            {
                LcQuickActions.Refresh();
                selectedAction = (QuickAction)LcQuickActions.Items[selectedRow.Top - 1];
            }
            
            // show modding form
            using (var quickAction = new QuickActionsMod(selectedAction))
            {
                var res = quickAction.ShowDialog();
                if (res != DialogResult.OK) return;

                // update in temp list
                _quickActions[_quickActions.FindIndex(x => x.Id == quickAction.QuickAction.Id)] = quickAction.QuickAction;

                // reload the gui list
                UpdateQuickActionList();
            }
        }

        /// <summary>
        /// Delete all selected quickactions
        /// <para>Note: doesn't actually execute deletion, that's done after the user clicks 'store'</para>
        /// </summary>
        private void DeleteSelectedActions()
        {
            // check for selected rows
            var selectedRows = LcQuickActions.Grid.Selections.GetSelectedRows(true, true);
            if (selectedRows.Count == 0) return;

            // get selected row indexes
            var rowList = new List<int>();
            for (var i = LcQuickActions.Grid.Model.SelectedRanges.ActiveRange.Top; i <= LcQuickActions.Grid.Model.SelectedRanges.ActiveRange.Bottom; i++)
            {
                rowList.Add(i - 1);
            }

            // make descending
            rowList.Sort();
            rowList.Reverse();

            foreach (var row in rowList)
            {
                // get object
                var qA = (QuickAction)LcQuickActions.Items[row];

                // remove from the list
                _quickActions.RemoveAt(_quickActions.FindIndex(x => x.Id == qA.Id));
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
            using (var quickAction = new QuickActionsMod())
            {
                var res = quickAction.ShowDialog();
                if (res != DialogResult.OK) return;

                // add to the temp list
                _quickActions.Add(quickAction.QuickAction);

                // reload the gui list
                UpdateQuickActionList();
            }
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            ModifySelectedAction();
        }

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
            DialogResult = DialogResult.OK;
        }

        private void BtnRemove_Click(object sender, EventArgs e) => DeleteSelectedActions();

        private void LcQuickActions_DoubleClick(object sender, EventArgs e) => ModifySelectedAction();

        private void BtnPreview_Click(object sender, EventArgs e)
        {
            using (var quickActions = new QuickActions(_quickActions))
            {
                quickActions.ShowDialog();
            }
        }

        private void QuickActionsConfig_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape) return;
            Close();
        }

        private void QuickActionsConfig_Resize(object sender, EventArgs e)
        {
            LcQuickActions.Height = Height - _heightDiff;
        }

        private void QuickActionsConfig_ResizeEnd(object sender, EventArgs e)
        {
            if (Variables.ShuttingDown) return;
            if (!IsHandleCreated) return;
            if (IsDisposed) return;

            try
            {
                Refresh();
            }
            catch
            {
                // best effort
            }
        }
    }
}
