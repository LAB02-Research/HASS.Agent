using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using HASSAgent.Enums;
using HASSAgent.HomeAssistant;
using HASSAgent.Models.Internal;
using Syncfusion.Windows.Forms;
using WK.Libraries.HotkeyListenerNS;

namespace HASSAgent.Forms.QuickActions
{
    public partial class QuickActionsMod : MetroForm
    {
        private readonly HotkeySelector _hotkeySelector = new HotkeySelector();
        internal readonly QuickAction QuickAction;

        public QuickActionsMod(QuickAction quickAction)
        {
            QuickAction = quickAction;
            InitializeComponent();
        }

        public QuickActionsMod()
        {
            QuickAction = new QuickAction();
            InitializeComponent();
        }

        private async void QuickActionsMod_Load(object sender, EventArgs e)
        {
            // check hass manager status
            if (!await CheckHassManagerAsync())
            {
                DialogResult = DialogResult.Abort;
                return;
            }

            // catch all key presses
            KeyPreview = true;

            // load enums
            CbDomain.DataSource = Enum.GetValues(typeof(HassDomain));
            CbAction.DataSource = Enum.GetValues(typeof(HassAction));
            
            // load or set quick action
            if (QuickAction.Id == Guid.Empty)
            {
                QuickAction.Id = Guid.NewGuid();
                Text = "New Quick Action";

                _hotkeySelector.Enable(TbHotkey);
                TbHotkey.Text = _hotkeySelector.EmptyHotkeyText;

                return;
            }

            LoadQuickAction();
            Text = "Mod Quick Action";
        }

        /// <summary>
        /// Check whether the HASS manager is ready
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
                    return true;
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
                BtnStore.Enabled = !loading;

                CbDomain.Enabled = !loading;
                CbEntity.Enabled = !loading;
                CbAction.Enabled = !loading;
                TbDescription.Enabled = !loading;
            }));
        }

        /// <summary>
        /// Loads the to-be-modded quickaction
        /// </summary>
        private void LoadQuickAction()
        {
            // load the domain and corresponding entity's
            CbDomain.Text = QuickAction.Domain.ToString();
            LoadEntityList();

            // set the entity
            CbEntity.Text = QuickAction.Entity;

            // set the action
            CbAction.Text = QuickAction.Action.ToString();

            // set the optional description
            TbDescription.Text = QuickAction.Description;
            if (!string.IsNullOrWhiteSpace(TbDescription.Text)) TbDescription.SelectionStart = TbDescription.Text.Length;

            // load the hotkey
            if (!string.IsNullOrEmpty(QuickAction.HotKey)) _hotkeySelector.Enable(TbHotkey, new Hotkey(QuickAction.HotKey));
            else
            {
                _hotkeySelector.Enable(TbHotkey);
                TbHotkey.Text = _hotkeySelector.EmptyHotkeyText;
            }
        }

        /// <summary>
        /// Prepare the quickaction for processing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStore_Click(object sender, EventArgs e)
        {
            // get and check entity
            var entity = CbEntity.Text;
            if (string.IsNullOrEmpty(entity))
            {
                MessageBox.Show("Select an entity first.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = CbEntity;
                return;
            }

            // get and check domain
            var parsed = Enum.TryParse<HassDomain>(CbDomain.SelectedValue.ToString(), out var domain);
            if (!parsed)
            {
                MessageBox.Show("Unknown domain, please select a valid one.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = CbDomain;
                return;
            }

            // get and check action
            parsed = Enum.TryParse<HassAction>(CbAction.SelectedValue.ToString(), out var action);
            if (!parsed)
            {
                MessageBox.Show("Unknown action, please select a valid one.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = CbAction;
                return;
            }

            // get and check hotkey
            var enableHotkey = CbEnableHotkey.Checked;
            var hotkey = TbHotkey.Text;
            if (string.IsNullOrWhiteSpace(hotkey))
            {
                hotkey = string.Empty;
                enableHotkey = false;
            }

            // get description
            var description = TbDescription.Text.Trim();

            // set values
            QuickAction.Entity = entity;
            QuickAction.Domain = domain;
            QuickAction.Action = action;
            QuickAction.HotKeyEnabled = enableHotkey;
            QuickAction.HotKey = hotkey;
            QuickAction.Description = description;

            // done
            DialogResult = DialogResult.OK;
        }
        
        private void CbDomain_SelectedIndexChanged(object sender, EventArgs e)
        {
            // set focus to entity list
            ActiveControl = CbEntity;

            // load entities
            LoadEntityList();
        }

        /// <summary>
        /// Load the entity's corresponding to the currently selected domain, and set autocompletion
        /// </summary>
        private void LoadEntityList()
        {
            CbEntity.AutoCompleteCustomSource = new AutoCompleteStringCollection();
            CbEntity.Items.Clear();

            var parsed = Enum.TryParse<HassDomain>(CbDomain.SelectedValue.ToString(), out var type);
            if (!parsed) return;

            switch (type)
            {
                case HassDomain.Automation:
                    foreach (var item in HassApiManager.AutomationList)
                    {
                        CbEntity.AutoCompleteCustomSource.Add(item);
                        CbEntity.Items.Add(item);
                    }
                    break;

                case HassDomain.Climate:
                    foreach (var item in HassApiManager.ClimateList)
                    {
                        CbEntity.AutoCompleteCustomSource.Add(item);
                        CbEntity.Items.Add(item);
                    }
                    break;

                case HassDomain.Cover:
                    foreach (var item in HassApiManager.CoverList)
                    {
                        CbEntity.AutoCompleteCustomSource.Add(item);
                        CbEntity.Items.Add(item);
                    }
                    break;

                case HassDomain.InputBoolean:
                    foreach (var item in HassApiManager.InputBooleanList)
                    {
                        CbEntity.AutoCompleteCustomSource.Add(item);
                        CbEntity.Items.Add(item);
                    }
                    break;

                case HassDomain.Light:
                    foreach (var item in HassApiManager.LightList)
                    {
                        CbEntity.AutoCompleteCustomSource.Add(item);
                        CbEntity.Items.Add(item);
                    }
                    break;

                case HassDomain.MediaPlayer:
                    foreach (var item in HassApiManager.MediaPlayerList)
                    {
                        CbEntity.AutoCompleteCustomSource.Add(item);
                        CbEntity.Items.Add(item);
                    }
                    break;

                case HassDomain.Scene:
                    foreach (var item in HassApiManager.SceneList)
                    {
                        CbEntity.AutoCompleteCustomSource.Add(item);
                        CbEntity.Items.Add(item);
                    }
                    break;

                case HassDomain.Script:
                    foreach (var item in HassApiManager.ScriptList)
                    {
                        CbEntity.AutoCompleteCustomSource.Add(item);
                        CbEntity.Items.Add(item);
                    }
                    break;

                case HassDomain.Switch:
                    foreach (var item in HassApiManager.SwitchList)
                    {
                        CbEntity.AutoCompleteCustomSource.Add(item);
                        CbEntity.Items.Add(item);
                    }
                    break;
            }
        }

        private void CbEntity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbEntity.SelectedIndex == -1)
            {
                LblEntity.Text = string.Empty;
                return;
            }

            // set focus to description
            ActiveControl = TbDescription;
            if (!string.IsNullOrWhiteSpace(TbDescription.Text)) TbDescription.SelectionStart = TbDescription.Text.Length;

            // load entity name
            LblEntity.Text = CbEntity.Text;
        }

        private void QuickActionsMod_FormClosing(object sender, FormClosingEventArgs e)
        {
            // stop and dispose selector
            _hotkeySelector?.Disable(TbHotkey);
            _hotkeySelector?.Dispose();
        }

        private void TbHotkey_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbHotkey.Text)
                || TbHotkey.Text == _hotkeySelector?.EmptyHotkeyText
                || TbHotkey.Text == _hotkeySelector?.InvalidHotkeyText)
            {
                CbEnableHotkey.CheckState = CheckState.Unchecked;
                return;
            }

            CbEnableHotkey.CheckState = CheckState.Checked;
        }

        private void QuickActionsMod_ResizeEnd(object sender, EventArgs e)
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

        private void CbDomain_DrawItem(object sender, DrawItemEventArgs e) => DrawComboBox(sender, e);
        private void CbEntity_DrawItem(object sender, DrawItemEventArgs e) => DrawComboBox(sender, e);
        private void CbAction_DrawItem(object sender, DrawItemEventArgs e) => DrawComboBox(sender, e);

        /// <summary>
        /// Makes sure our combobox has the right colors
        /// <para>Source: https://stackoverflow.com/a/60421006 </para>
        /// <para>Source: https://stackoverflow.com/a/11650321 </para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void DrawComboBox(object sender, DrawItemEventArgs e)
        {
            // fetch the sender
            if (!(sender is ComboBox comboBox)) return;
            if (comboBox.Items.Count <= 0) return;

            // fetch the index
            var index = e.Index >= 0 ? e.Index : 0;

            // draw the control's background
            e.DrawBackground();

            // check if we have an item to process
            if (index != -1)
            {
                // optionally set the item's background color as selected
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(241, 241, 241)), e.Bounds);
                }

                // draw the string
                var brush = (e.State & DrawItemState.Selected) > 0 ? new SolidBrush(Color.FromArgb(63, 63, 70)) : new SolidBrush(comboBox.ForeColor);
                e.Graphics.DrawString(comboBox.Items[index].ToString(), e.Font, brush, e.Bounds, StringFormat.GenericDefault);
            }

            // draw focus rectangle
            e.DrawFocusRectangle();
        }

        private void QuickActionsMod_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape) return;
            Close();
        }

        private void CbAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            // set focus to description
            ActiveControl = TbDescription;
            if (!string.IsNullOrWhiteSpace(TbDescription.Text)) TbDescription.SelectionStart = TbDescription.Text.Length;
        }
    }
}
