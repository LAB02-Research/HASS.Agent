using HASS.Agent.Enums;
using HASS.Agent.Functions;
using HASS.Agent.HomeAssistant;
using HASS.Agent.Models.Internal;
using HASS.Agent.Resources.Localization;
using HASS.Agent.Shared.Enums;
using HASS.Agent.Shared.Functions;
using Syncfusion.Windows.Forms;
using WK.Libraries.HotkeyListenerNS;

namespace HASS.Agent.Forms.QuickActions
{
    public partial class QuickActionsMod : MetroForm
    {
        private readonly HotkeySelector _hotkeySelector = new();
        internal readonly QuickAction QuickAction;

        private readonly Dictionary<int, string> _hassDomainEntityTypes = new();
        private readonly Dictionary<int, string> _hassActionEntityTypes = new();

        public QuickActionsMod(QuickAction quickAction)
        {
            QuickAction = quickAction;

            InitializeComponent();

            BindComboBoxTheme();

            BindListViewTheme();
        }

        public QuickActionsMod()
        {
            QuickAction = new QuickAction();

            InitializeComponent();
            
            BindComboBoxTheme();

            BindListViewTheme();
        }

        private void BindComboBoxTheme()
        {
            CbEntity.DrawItem += ComboBoxTheme.DrawItem;
            CbAction.DrawItem += ComboBoxTheme.DrawDictionaryIntStringItem;
        }

        private void BindListViewTheme()
        {
            LvDomain.DrawItem += ListViewTheme.DrawItem;
            LvDomain.DrawSubItem += ListViewTheme.DrawSubItem;
            LvDomain.DrawColumnHeader += ListViewTheme.DrawColumnHeader;
        }

        private async void QuickActionsMod_Load(object sender, EventArgs e)
        {
            // catch all key presses
            KeyPreview = true;
            
            // check hass manager status
            if (!await Task.Run(async () => await CheckHassManagerAsync()))
            {
                DialogResult = DialogResult.Abort;
                return;
            }

            // load enums info
            foreach (HassDomain entityType in Enum.GetValues(typeof(HassDomain)))
            {
                var (key, description) = entityType.GetLocalizedDescriptionAndKey();
                _hassDomainEntityTypes.Add(key, description);
            }

            foreach (HassAction entityType in Enum.GetValues(typeof(HassAction)))
            {
                var (key, description) = entityType.GetLocalizedDescriptionAndKey();
                _hassActionEntityTypes.Add(key, description);
            }

            // load in gui
            CbAction.DataSource = new BindingSource(_hassActionEntityTypes, null);
            
            LvDomain.BeginUpdate();
            foreach (var domain in _hassDomainEntityTypes)
            {
                var lvDomain = new ListViewItem(domain.Key.ToString());
                lvDomain.SubItems.Add(domain.Value);
                LvDomain.Items.Add(lvDomain);
            }
            LvDomain.EndUpdate();

            // load or new quickaction?
            if (QuickAction.Id == Guid.Empty)
            {
                // new quickaction
                Text = Languages.QuickActionsMod_Title_New;
                QuickAction.Id = Guid.NewGuid();

                _hotkeySelector.Enable(TbHotkey);
                TbHotkey.Text = _hotkeySelector.EmptyHotkeyText;

                LvDomain.Items[0].Selected = true;
                if (CbEntity.Items.Count > 0) CbEntity.SelectedIndex = 0;

                return;
            }

            // load existing one
            Text = Languages.QuickActionsMod_Title_Mod;
            LoadQuickAction();
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
                    MessageBoxAdv.Show(this, Languages.QuickActionsMod_CheckHassManager_MessageBox1, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;

                case HassManagerStatus.Failed:
                    MessageBoxAdv.Show(this, Languages.QuickActionsMod_MessageBox_Entities, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;

                case HassManagerStatus.Initialising:
                case HassManagerStatus.LoadingData:
                    // lock interface
                    SetGuiLoading(true);

                    // wait for the manager to finish loading
                    while (HassApiManager.ManagerStatus != HassManagerStatus.Ready)
                    {
                        await Task.Delay(150);
                        if (HassApiManager.ManagerStatus != HassManagerStatus.Failed) continue;

                        // manager failed, abort
                        MessageBoxAdv.Show(this, Languages.QuickActionsMod_MessageBox_Entities, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }

                    // wait a bit after loading or we'll cause an exception
                    await Task.Delay(150);

                    // release interface
                    SetGuiLoading(false);

                    // done
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

                LvDomain.Enabled = !loading;
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
            // load the domain
            var domainId = (int)QuickAction.Domain;
            var domainIdStr = domainId.ToString();
            foreach (ListViewItem lvDomain in LvDomain.Items)
            {
                if (lvDomain.Text != domainIdStr) continue;
                lvDomain.Selected = true;
                LvDomain.SelectedItems[0].EnsureVisible();
                break;
            }

            // load the corresponding entity's
            LoadEntityList();
            
            // set the entity
            CbEntity.Text = QuickAction.Entity;

            // set the action
            var actionId = (int)QuickAction.Action;
            CbAction.SelectedItem = new KeyValuePair<int, string>(actionId, _hassActionEntityTypes[actionId]);

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
            var entity = CbEntity.SelectedItem.ToString();
            if (string.IsNullOrEmpty(entity))
            {
                MessageBoxAdv.Show(this, Languages.QuickActionsMod_BtnStore_MessageBox1, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = CbEntity;
                return;
            }

            if (LvDomain.SelectedItems.Count == 0)
            {
                MessageBoxAdv.Show(this, Languages.QuickActionsMod_BtnStore_MessageBox2, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = LvDomain;
                return;
            }

            // get domain
            var domainId = int.Parse(LvDomain.SelectedItems[0].Text);
            var domain = (HassDomain)domainId;

            // get and check action
            var actionItem = (KeyValuePair<int, string>)CbAction.SelectedItem;
            var action = (HassAction)actionItem.Key;

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

        private void LvDomain_SelectedIndexChanged(object sender, EventArgs e)
        {
            // set focus to entity list
            ActiveControl = CbEntity;

            // load entities
            LoadEntityList();

            // select the first
            if (CbEntity.Items.Count > 0) CbEntity.SelectedIndex = 0;
        }

        /// <summary>
        /// Load the entity's corresponding to the currently selected domain, and set autocompletion
        /// </summary>
        private void LoadEntityList()
        {
            if (LvDomain.SelectedItems.Count == 0)
            {
                CbEntity.Items.Clear();
                return;
            }

            CbEntity.AutoCompleteCustomSource = new AutoCompleteStringCollection();
            CbEntity.Items.Clear();

            // get domain
            var domainId = int.Parse(LvDomain.SelectedItems[0].Text);
            
            // nope, HA domain
            var domain = (HassDomain)domainId;

            // load relevant entities
            switch (domain)
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

                case HassDomain.HASSAgentCommands:
                    foreach (var item in Variables.Commands)
                    {
                        CbEntity.AutoCompleteCustomSource.Add(item.Name);
                        CbEntity.Items.Add(item.Name);
                    }
                    break;
            }
        }

        private void CbEntity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbEntity.SelectedIndex == -1) return;

            // set focus to description
            ActiveControl = TbDescription;
            if (!string.IsNullOrWhiteSpace(TbDescription.Text)) TbDescription.SelectionStart = TbDescription.Text.Length;
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
                // hide the pesky horizontal scrollbar
                ListViewTheme.ShowScrollBar(LvDomain.Handle, ListViewTheme.SB_HORZ, false);

                Refresh();
            }
            catch
            {
                // best effort
            }
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

        private void QuickActionsMod_Layout(object sender, LayoutEventArgs e)
        {
            // hide the pesky horizontal scrollbar
            ListViewTheme.ShowScrollBar(LvDomain.Handle, ListViewTheme.SB_HORZ, false);
        }
    }
}
