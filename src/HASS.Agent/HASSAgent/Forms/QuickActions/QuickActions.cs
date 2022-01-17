using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HASSAgent.Controls;
using HASSAgent.Enums;
using HASSAgent.Functions;
using HASSAgent.HomeAssistant;
using HASSAgent.Models.Internal;
using Serilog;
using Syncfusion.Windows.Forms;

namespace HASSAgent.Forms.QuickActions
{
    public partial class QuickActions : MetroForm
    {
        public event EventHandler ClearFocus;
        
        private readonly List<QuickAction> _quickActions = new List<QuickAction>();
        private readonly List<QuickActionPanelControl> _quickActionPanelControls = new List<QuickActionPanelControl>();

        private readonly Dictionary<int, int> _rowColumnCounts = new Dictionary<int, int>();

        private int _columns = 0;
        private int _rows = 0;

        private int _selectedColumn = -1;
        private int _selectedRow = -1;

        public QuickActions(List<QuickAction> quickActions)
        {
            foreach (var quickAction in quickActions) _quickActions.Add(quickAction);

            InitializeComponent();
        }

        private async void QuickActions_Load(object sender, EventArgs e)
        {
            // catch all key presses
            KeyPreview = true;

            // hide to prevent flickering
            Visible = false;

            // create our layout
            BuildLayout();

            // re-center
            CenterToScreen();

            // show ourselves
            Opacity = 100;
            Visible = true;

            // get focus (so the esc button works)
            BringToFront();
            Activate();

            // check hass status
            var hass = await CheckHassManagerAsync();
            if (!hass) CloseWindow();
        }

        /// <summary>
        /// Prepares the FlowLayout, resizes our form accordingly and load the QuickAction controls
        /// </summary>
        private void BuildLayout()
        {
            // determine layout
            var (columns, rows) = HelperFunctions.DetermineRowColumnCount(_quickActions);
            if (columns == 0 && rows == 0)
            {
                CloseWindow();
                return;
            }

            _columns = columns;
            _rows = rows;
            
            // prepare our panel
            PnlActions.AutoSize = true;

            for (var c = 0; c <= _columns; c++) PnlActions.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 152));
            PnlActions.ColumnCount = _columns;

            for (var r = 0; r <= _columns; r++) PnlActions.RowStyles.Add(new RowStyle(SizeType.Absolute, 255));
            PnlActions.RowCount = _rows;

            PnlActions.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            
            // resize window
            Width = 152 * columns + 20;
            Height = 255 * rows + 30;

            if (columns > 1) Width += 5 * (columns - 1);
            if (rows > 1) Height += 5 * (rows - 1);

            // add the quickactions as controls
            var currentColumn = 0;
            var currentRow = 0;
            foreach (var quickAction in _quickActions.Select(qA => new QuickActionControl(qA, this)))
            {
                // prepare the panelcontrol (so we can its location later)
                var panelControl = new QuickActionPanelControl
                {
                    QuickActionControl = quickAction,
                    Column = currentColumn,
                    Row = currentRow
                };

                // add to list
                _quickActionPanelControls.Add(panelControl);

                // store position
                if (!_rowColumnCounts.ContainsKey(currentRow)) _rowColumnCounts.Add(currentRow, currentColumn);
                else _rowColumnCounts[currentRow] = currentColumn;
                
                // add to the panel
                PnlActions.Controls.Add(quickAction, currentColumn, currentRow);

                // set next column & row
                if (currentColumn < columns - 1) currentColumn++;
                else
                {
                    // on to the next row (if there is one)
                    currentColumn = 0;
                    if (currentRow < rows - 1) currentRow++;
                }
            }
        }

        /// <summary>
        /// Tries to close the window
        /// </summary>
        internal void CloseWindow()
        {
            if (!IsHandleCreated) return;
            if (IsDisposed) return;

            Invoke(new MethodInvoker(delegate
            {
                DialogResult = DialogResult.OK;
                Close();
            }));
        }

        /// <summary>
        /// Check whether the HASS manager is ready to process our request
        /// </summary>
        /// <returns></returns>
        private async Task<bool> CheckHassManagerAsync()
        {
            switch (HassApiManager.ManagerStatus)
            {
                case HassManagerStatus.Ready:
                    return true;

                case HassManagerStatus.ConfigMissing:
                    MessageBoxAdv.Show("Unable to fetch your entities because of missing config, please enter the required values in the config screen.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;

                case HassManagerStatus.Failed:
                    MessageBoxAdv.Show("There was an error trying to fetch your entities.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;

                case HassManagerStatus.Initialising:
                case HassManagerStatus.LoadingData:
                    SetGuiLoading(true);
                    while (HassApiManager.ManagerStatus != HassManagerStatus.Ready)
                    {
                        await Task.Delay(150);
                        if (HassApiManager.ManagerStatus != HassManagerStatus.Failed) continue;

                        MessageBoxAdv.Show("There was an error trying to fetch your entities.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    SetGuiLoading(false);
                    break;
            }

            return true;
        }

        /// <summary>
        /// Lock the UI while loading
        /// </summary>
        /// <param name="loading"></param>
        private void SetGuiLoading(bool loading)
        {
            if (!IsHandleCreated) return;
            if (IsDisposed) return;

            Invoke(new MethodInvoker(delegate
            {
                LblLoading.Visible = loading;
            }));
        }

        /// <summary>
        /// Close when ESC is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuickActions_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape) return;
            Close();
        }

        private void QuickActions_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                foreach (var control in _quickActionPanelControls) control.Dispose();
            }
            catch
            {
                // best effort
            }
        }

        /// <summary>
        /// Intercepts and processes the arrow keys
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {
                // if never pressed before ..
                if (_selectedColumn == -1)
                {
                    // .. always select first one
                    var control = _quickActionPanelControls.Find(x => x.Row == 0 && x.Column == 0);
                    if (control == null) return true;

                    control.QuickActionControl.OnFocus();
                    _selectedColumn = 0;
                    _selectedRow = 0;
                    return true;
                }

                if (keyData == Keys.Down)
                {
                    // is there a next row?
                    if (_selectedRow == _rows - 1) return true;

                    // jep, select the control below (or the last)
                    _selectedRow++;
                    var control = _quickActionPanelControls.Find(x => x.Row == _selectedRow && x.Column == _selectedColumn);
                    if (control == null)
                    {
                        // none found with same column, get the last
                        _selectedColumn = _rowColumnCounts[_selectedRow];
                        control = _quickActionPanelControls.Find(x => x.Row == _selectedRow && x.Column == _selectedColumn);
                        control?.QuickActionControl.OnFocus();
                        return true;
                    }

                    control.QuickActionControl.OnFocus();
                    return true;
                }

                if (keyData == Keys.Right)
                {
                    // is there a next column?
                    var maxColumnsForRow = _rowColumnCounts[_selectedRow];
                    if (_selectedColumn == maxColumnsForRow) return true;

                    // jep, select the control to the right
                    _selectedColumn++;
                    var control = _quickActionPanelControls.Find(x => x.Row == _selectedRow && x.Column == _selectedColumn);
                    control?.QuickActionControl.OnFocus();
                    return true;
                }

                if (keyData == Keys.Left)
                {
                    // is there a previous column?
                    if (_selectedColumn == 0) return true;

                    // jep, select the control to the left
                    _selectedColumn--;
                    var control = _quickActionPanelControls.Find(x => x.Row == _selectedRow && x.Column == _selectedColumn);
                    control?.QuickActionControl.OnFocus();
                    return true;
                }

                if (keyData == Keys.Up)
                {
                    // is there a previous row?
                    if (_selectedRow == 0) return true;

                    // jep, select the control above (or the last)
                    _selectedRow--;
                    var control = _quickActionPanelControls.Find(x => x.Row == _selectedRow && x.Column == _selectedColumn);
                    if (control == null)
                    {
                        // none found with same column, get the first
                        _selectedColumn = 0;
                        control = _quickActionPanelControls.Find(x => x.Row == _selectedRow && x.Column == _selectedColumn);
                        control?.QuickActionControl.OnFocus();
                        return true;
                    }

                    control.QuickActionControl.OnFocus();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[QUICKACTIONS] Error while trying to handle arrowkeys: {msg}", ex.Message);
            }

            // ignore the rest
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Triggers clearing the focus of all controls
        /// </summary>
        public void ClearAllFocus() => OnClearFocus();

        protected virtual void OnClearFocus()
        {
            ClearFocus?.Invoke(this, EventArgs.Empty);
        }
    }
}
