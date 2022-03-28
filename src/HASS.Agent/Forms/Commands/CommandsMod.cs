using Syncfusion.Windows.Forms;
using System.Text;
using HASS.Agent.Commands;
using HASS.Agent.Functions;
using HASS.Agent.Models.Internal;
using HASS.Agent.Sensors;
using HASS.Agent.Shared.Enums;
using HASS.Agent.Shared.Extensions;
using HASS.Agent.Shared.Models.Config;
using Newtonsoft.Json;

namespace HASS.Agent.Forms.Commands
{
    public partial class CommandsMod : MetroForm
    {
        internal readonly ConfiguredCommand Command;

        private readonly bool _serviceMode;
        private readonly string _serviceDeviceName;

        private bool _interfaceLockedWrongType;
        private bool _loading = true;

        public CommandsMod(ConfiguredCommand command, bool serviceMode = false, string serviceDeviceName = "")
        {
            Command = command;

            _serviceMode = serviceMode;
            _serviceDeviceName = serviceDeviceName;

            InitializeComponent();

            BindListViewTheme();
        }

        public CommandsMod(bool serviceMode = false, string serviceDeviceName = "")
        {
            Command = new ConfiguredCommand();

            _serviceMode = serviceMode;
            _serviceDeviceName = serviceDeviceName;

            InitializeComponent();

            BindListViewTheme();
        }

        private void BindListViewTheme()
        {
            LvCommands.DrawItem += ListViewTheme.DrawItem;
            LvCommands.DrawSubItem += ListViewTheme.DrawSubItem;
            LvCommands.DrawColumnHeader += ListViewTheme.DrawColumnHeader;
        }

        private void CommandsMod_Load(object sender, EventArgs e)
        {
            // catch all key presses
            KeyPreview = true;

            // load commands
            LvCommands.BeginUpdate();
            foreach (var command in CommandsManager.CommandInfoCards.Select(x => x.Value))
            {
                var lvCommand = new ListViewItem(command.Name);
                lvCommand.SubItems.Add(command.AgentCompatible ? "√" : "");
                lvCommand.SubItems.Add(command.SatelliteCompatible ? "√" : "");
                LvCommands.Items.Add(lvCommand);
            }
            LvCommands.EndUpdate();

            // load or set command
            if (Command.Id == Guid.Empty)
            {
                Command.Id = Guid.NewGuid();
                Text = "New Command";

                // done
                _loading = false;
                return;
            }

            // we're modding, load it
            LoadCommand();
            Text = "Mod Command";

            // done
            _loading = false;
        }

        /// <summary>
        /// Loads the to-be-modded command
        /// </summary>
        private void LoadCommand()
        {
            // load the card
            var commandCard = CommandsManager.CommandInfoCards[Command.Type];
            
            // select it as well
            foreach (ListViewItem lvi in LvCommands.Items)
            {
                if (lvi.Text != commandCard.Name) continue;
                lvi.Selected = true;
                LvCommands.SelectedItems[0].EnsureVisible();
                break;
            }

            // set gui
            var guiOk = SetType(false);
            if (!guiOk) return;

            // set the name
            TbName.Text = Command.Name;
            if (!string.IsNullOrWhiteSpace(TbName.Text)) TbName.SelectionStart = TbName.Text.Length;

            // set optional settings
            switch (commandCard.CommandType)
            {
                case CommandType.CustomCommand:
                    TbSetting.Text = Command.Command;
                    break;

                case CommandType.PowershellCommand:
                    TbSetting.Text = Command.Command;
                    break;

                case CommandType.KeyCommand:
                    TbSetting.Text = Command.KeyCode.ToString();
                    break;

                case CommandType.MultipleKeysCommand:
                    var commands = new StringBuilder();
                    foreach (var command in Command.Keys) commands.Append($"[{command}] ");
                    TbSetting.Text = commands.ToString().Trim();
                    break;

                case CommandType.LaunchUrlCommand:
                    var urlInfo = Command.Command;
                    if (string.IsNullOrEmpty(urlInfo)) break;
                    var urlPackage = JsonConvert.DeserializeObject<UrlInfo>(urlInfo);
                    if (urlPackage == null) break;

                    TbSetting.Text = urlPackage.Url;
                    CbCommandSpecific.Checked = urlPackage.Incognito;
                    break;

                case CommandType.CustomExecutorCommand:
                    TbSetting.Text = Command.Command;
                    break;
            }

            CbRunAsLowIntegrity.CheckState = Command.RunAsLowIntegrity ? CheckState.Checked : CheckState.Unchecked;
        }

        /// <summary>
        /// Prepare the command for processing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStore_Click(object sender, EventArgs e)
        {
            if (LvCommands.SelectedItems.Count == 0)
            {
                MessageBoxAdv.Show("Select a commandtype first.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // get and check type
            var commandName = LvCommands.SelectedItems[0].Text;
            var commandCard = CommandsManager.CommandInfoCards.Where(card => card.Value.Name == commandName)
                .Select(card => card.Value).FirstOrDefault();

            if (commandCard == null)
            {
                MessageBoxAdv.Show("Select a valid commandtype first.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // get and check name
            var name = TbName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBoxAdv.Show("Enter a name first.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = TbName;
                return;
            }

            // name already used?
            if (!_serviceMode && Variables.Commands.Any(x => string.Equals(x.Name, name, StringComparison.InvariantCultureIgnoreCase) && x.Id != Command.Id.ToString()))
            {
                var confirm = MessageBoxAdv.Show("There's already a command with that name. Are you sure you want to continue?", "HASS.Agent", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes)
                {
                    ActiveControl = TbName;
                    return;
                }
            }

            switch (commandCard.CommandType)
            {
                case CommandType.CustomCommand:
                    var command = TbSetting.Text.Trim();
                    if (string.IsNullOrEmpty(command))
                    {
                        MessageBoxAdv.Show("Enter a command first.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ActiveControl = TbSetting;
                        return;
                    }
                    Command.Command = command;
                    break;

                case CommandType.PowershellCommand:
                    var script = TbSetting.Text.Trim();
                    if (string.IsNullOrEmpty(script))
                    {
                        MessageBoxAdv.Show("Enter a command or script first.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ActiveControl = TbSetting;
                        return;
                    }
                    Command.Command = script;
                    break;

                case CommandType.KeyCommand:
                    var keycode = TbSetting.Text.Trim();
                    if (string.IsNullOrEmpty(keycode))
                    {
                        MessageBoxAdv.Show("Enter a keycode first.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ActiveControl = TbSetting;
                        return;
                    }
                    Command.KeyCode = Encoding.ASCII.GetBytes(keycode).First();
                    break;

                case CommandType.MultipleKeysCommand:
                    var keysParsed = HelperFunctions.ParseMultipleKeys(TbSetting.Text.Trim(), out var keys, out var errorMsg);
                    if (!keysParsed)
                    {
                        MessageBoxAdv.Show($"Processing keys failed: {errorMsg}", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        ActiveControl = TbSetting;
                        return;
                    }
                    Command.Keys = keys;
                    break;

                case CommandType.LaunchUrlCommand:
                    var url = TbSetting.Text.Trim();
                    if (string.IsNullOrEmpty(url))
                    {
                        MessageBoxAdv.Show("Enter a URL first.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ActiveControl = TbSetting;
                        return;
                    }

                    var urlInfo = new UrlInfo
                    {
                        Url = url,
                        Incognito = CbCommandSpecific.Checked
                    };

                    Command.Command = JsonConvert.SerializeObject(urlInfo);
                    break;

                case CommandType.CustomExecutorCommand:
                    var executorCommand = TbSetting.Text.Trim();
                    if (string.IsNullOrEmpty(executorCommand))
                    {
                        MessageBoxAdv.Show("Enter a command or script first.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ActiveControl = TbSetting;
                        return;
                    }
                    Command.Command = executorCommand;
                    break;
            }

            Command.RunAsLowIntegrity = CbRunAsLowIntegrity.CheckState == CheckState.Checked;

            // set values
            Command.Type = commandCard.CommandType;
            Command.Name = name;

            // done
            DialogResult = DialogResult.OK;
        }
        
        private void LvCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_loading) return;

            // set the ui to the selected type
            SetType();

            // set focus to the name field
            ActiveControl = TbName;
            if (!string.IsNullOrWhiteSpace(TbName.Text)) TbName.SelectionStart = TbName.Text.Length;
        }

        /// <summary>
        /// Change the UI depending on the selected type
        /// </summary>
        /// <param name="setDefaultValues"></param>
        private bool SetType(bool setDefaultValues = true)
        {
            if (LvCommands.SelectedItems.Count == 0)
            {
                // was the interface locked?
                if (_interfaceLockedWrongType) UnlockWrongClient();
                return false;
            }

            // find the command card
            var commandName = LvCommands.SelectedItems[0].Text;
            var commandCard = CommandsManager.CommandInfoCards.Where(card => card.Value.Name == commandName)
                .Select(card => card.Value).FirstOrDefault();
            if (commandCard == null) return false;

            // can the current client load this type?
            if (_serviceMode && !commandCard.SatelliteCompatible)
            {
                LockWrongClient();
                return false;
            }

            if (!_serviceMode && !commandCard.AgentCompatible)
            {
                LockWrongClient();
                return false;
            }

            // was the interface locked?
            if (_interfaceLockedWrongType) UnlockWrongClient();

            // set default values
            if (setDefaultValues) TbName.Text = _serviceMode ? commandCard.CommandType.GetCommandName(_serviceDeviceName) : commandCard.CommandType.GetCommandName();

            TbSelectedType.Text = commandCard.CommandType.ToString();
            TbDescription.Text = CommandsManager.GetCommandDefaultInfo(commandCard.CommandType).Description;

            switch (commandCard.CommandType)
            {
                case CommandType.CustomCommand:
                    SetCommandGui();
                    break;

                case CommandType.PowershellCommand:
                    SetPowershellGui();
                    break;

                case CommandType.KeyCommand:
                    SetKeyGui();
                    break;

                case CommandType.MultipleKeysCommand:
                    SetMultipleKeysGui();
                    break;

                case CommandType.LaunchUrlCommand:
                    SetUrlGui();
                    break;

                case CommandType.CustomExecutorCommand:
                    SetCustomExecutorUi();
                    break;

                default:
                    SetEmptyGui();
                    break;
            }

            return true;
        }

        /// <summary>
        /// Change the UI to a 'command' type
        /// </summary>
        private void SetCommandGui()
        {
            Invoke(new MethodInvoker(delegate
            {
                LblSetting.Text = "command";
                LblSetting.Visible = true;

                TbSetting.Text = string.Empty;
                TbSetting.Visible = true;

                CbRunAsLowIntegrity.Visible = true;
                LblIntegrityInfo.Visible = true;

                CbCommandSpecific.CheckState = CheckState.Unchecked;
                CbCommandSpecific.Visible = false;

                LblInfo.Text = string.Empty;
                LblInfo.Visible = false;
            }));
        }

        /// <summary>
        /// Change the UI to a 'powershell' type
        /// </summary>
        private void SetPowershellGui()
        {
            Invoke(new MethodInvoker(delegate
            {
                LblSetting.Text = "command or script";
                LblSetting.Visible = true;

                TbSetting.Text = string.Empty;
                TbSetting.Visible = true;

                CbRunAsLowIntegrity.CheckState = CheckState.Unchecked;
                CbRunAsLowIntegrity.Visible = false;
                LblIntegrityInfo.Visible = false;

                CbCommandSpecific.CheckState = CheckState.Unchecked;
                CbCommandSpecific.Visible = false;

                LblInfo.Text = string.Empty;
                LblInfo.Visible = false;
            }));
        }

        /// <summary>
        /// Change the UI to a 'key' type
        /// </summary>
        private void SetKeyGui()
        {
            Invoke(new MethodInvoker(delegate
            {
                LblSetting.Text = "keycode";
                LblSetting.Visible = true;

                TbSetting.Text = string.Empty;
                TbSetting.Visible = true;

                CbRunAsLowIntegrity.CheckState = CheckState.Unchecked;
                CbRunAsLowIntegrity.Visible = false;
                LblIntegrityInfo.Visible = false;

                CbCommandSpecific.CheckState = CheckState.Unchecked;
                CbCommandSpecific.Visible = false;

                LblInfo.Text = string.Empty;
                LblInfo.Visible = false;
            }));
        }

        /// <summary>
        /// Change the UI to a 'multiple keys' type
        /// </summary>
        private void SetMultipleKeysGui()
        {
            Invoke(new MethodInvoker(delegate
            {
                LblSetting.Text = "keycodes";
                LblSetting.Visible = true;

                TbSetting.Text = string.Empty;
                TbSetting.Visible = true;

                CbRunAsLowIntegrity.CheckState = CheckState.Unchecked;
                CbRunAsLowIntegrity.Visible = false;
                LblIntegrityInfo.Visible = false;

                CbCommandSpecific.CheckState = CheckState.Unchecked;
                CbCommandSpecific.Visible = false;

                LblInfo.Text = string.Empty;
                LblInfo.Visible = false;
            }));
        }

        /// <summary>
        /// Change the UI to a 'url' type
        /// </summary>
        private void SetUrlGui()
        {
            Invoke(new MethodInvoker(delegate
            {
                LblSetting.Text = "URL";
                LblSetting.Visible = true;

                TbSetting.Text = string.Empty;
                TbSetting.Visible = true;

                CbRunAsLowIntegrity.CheckState = CheckState.Unchecked;
                CbRunAsLowIntegrity.Visible = false;
                LblIntegrityInfo.Visible = false;
                
                CbCommandSpecific.CheckState = CheckState.Unchecked;
                CbCommandSpecific.Text = "launch in incognito mode";

                if (string.IsNullOrEmpty(Variables.AppSettings.BrowserBinary))
                {
                    LblInfo.Text = "browser: default\r\n\r\nplease configure a browser to enable incognito mode";
                    LblInfo.Visible = true;

                    CbCommandSpecific.CheckState = CheckState.Unchecked;
                    CbCommandSpecific.Visible = false;
                }
                else
                {
                    var browser = string.IsNullOrEmpty(Variables.AppSettings.BrowserName)
                        ? Path.GetFileNameWithoutExtension(Variables.AppSettings.BrowserBinary)
                        : Variables.AppSettings.BrowserName;

                    LblInfo.Text = $"browser: {browser}";
                    LblInfo.Visible = true;

                    CbCommandSpecific.Visible = true;
                }
            }));
        }

        /// <summary>
        /// Change the UI to a 'custom executor' type
        /// </summary>
        private void SetCustomExecutorUi()
        {
            Invoke(new MethodInvoker(delegate
            {
                LblSetting.Text = "command or script";
                LblSetting.Visible = true;

                TbSetting.Text = string.Empty;
                TbSetting.Visible = true;

                CbRunAsLowIntegrity.CheckState = CheckState.Unchecked;
                CbRunAsLowIntegrity.Visible = false;
                LblIntegrityInfo.Visible = false;

                CbCommandSpecific.CheckState = CheckState.Unchecked;
                CbCommandSpecific.Visible = false;

                if (string.IsNullOrEmpty(Variables.AppSettings.CustomExecutorBinary)) LblInfo.Text = "executor: none\r\n\r\nplease configure an executor or your command won't run";
                else
                {
                    var executor = string.IsNullOrEmpty(Variables.AppSettings.CustomExecutorName)
                        ? Path.GetFileNameWithoutExtension(Variables.AppSettings.CustomExecutorBinary)
                        : Variables.AppSettings.CustomExecutorName;

                    LblInfo.Text = $"executor: {executor}";
                }

                LblInfo.Visible = true;
            }));
        }

        /// <summary>
        /// Change the UI to a general type
        /// </summary>
        private void SetEmptyGui()
        {
            Invoke(new MethodInvoker(delegate
            {
                LblSetting.Visible = false;

                TbSetting.Text = string.Empty;
                TbSetting.Visible = false;

                CbRunAsLowIntegrity.CheckState = CheckState.Unchecked;
                CbRunAsLowIntegrity.Visible = false;
                LblIntegrityInfo.Visible = false;

                CbCommandSpecific.CheckState = CheckState.Unchecked;
                CbCommandSpecific.Visible = false;

                LblInfo.Text = string.Empty;
                LblInfo.Visible = false;
            }));
        }

        private void TbDescription_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.LinkText)) return;
            if (!e.LinkText.ToLower().StartsWith("http")) return;

            HelperFunctions.LaunchUrl(e.LinkText);
        }

        private void CommandsMod_ResizeEnd(object sender, EventArgs e)
        {
            if (Variables.ShuttingDown) return;
            if (!IsHandleCreated) return;
            if (IsDisposed) return;

            try
            {
                // hide the pesky horizontal scrollbar
                ListViewTheme.ShowScrollBar(LvCommands.Handle, ListViewTheme.SB_HORZ, false);

                Refresh();
            }
            catch
            {
                // best effort
            }
        }

        private void LblIntegrityInfo_Click(object sender, EventArgs e)
        {
            var infoMsg = new StringBuilder();
            infoMsg.AppendLine("Low integrity means your command will be executed with restricted privileges.");
            infoMsg.AppendLine("");
            infoMsg.AppendLine("That means it will only be able to save and modify files in certain locations,");
            infoMsg.AppendLine("such as the '%USERPROFILE%\\AppData\\LocalLow' folder or");
            infoMsg.AppendLine("the 'HKEY_CURRENT_USER\\Software\\AppDataLow' registry key.");
            infoMsg.AppendLine("");
            infoMsg.AppendLine("You should test your command to make sure it's not influenced by this.");

            MessageBoxAdv.Show(infoMsg.ToString(), "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CommandsMod_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape) return;
            Close();
        }

        private void CommandsMod_Layout(object sender, LayoutEventArgs e)
        {
            // hide the pesky horizontal scrollbar
            ListViewTheme.ShowScrollBar(LvCommands.Handle, ListViewTheme.SB_HORZ, false);
        }

        /// <summary>
        /// Locks the interface if the selected entity can't be added to the current client
        /// </summary>
        private void LockWrongClient()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(LockWrongClient));
                return;
            }

            _interfaceLockedWrongType = true;

            var requiredClient = _serviceMode ? "hass.agent" : "service";
            LblSpecificClient.Text = $"{requiredClient} only!";

            LblSpecificClient.Visible = true;

            TbName.Enabled = false;
            TbName.Text = string.Empty;

            SetEmptyGui();

            BtnStore.Enabled = false;
        }

        /// <summary>
        /// Unlocks the interface if the selected entity can be added to the current client
        /// </summary>
        private void UnlockWrongClient()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(UnlockWrongClient));
                return;
            }

            _interfaceLockedWrongType = false;

            LblSpecificClient.Visible = false;

            TbName.Enabled = true;
            BtnStore.Enabled = true;
        }
    }
}
