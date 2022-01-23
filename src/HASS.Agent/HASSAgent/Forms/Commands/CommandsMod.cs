using Syncfusion.Windows.Forms;
using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HASSAgent.Commands;
using HASSAgent.Enums;
using HASSAgent.Functions;
using HASSAgent.Models.Config;

namespace HASSAgent.Forms.Commands
{
    public partial class CommandsMod : MetroForm
    {
        internal readonly ConfiguredCommand Command;

        public CommandsMod(ConfiguredCommand command)
        {
            Command = command;
            InitializeComponent();
        }

        public CommandsMod()
        {
            Command = new ConfiguredCommand();
            InitializeComponent();
        }

        private void CommandsMod_Load(object sender, EventArgs e)
        {
            // load enums
            CbType.DataSource = Enum.GetValues(typeof(CommandType));

            // catch all key presses
            KeyPreview = true;

            // load or set command
            if (Command.Id == Guid.Empty)
            {
                Command.Id = Guid.NewGuid();
                Text = "New Command";
                return;
            }

            LoadCommand();
            Text = "Mod Command";
        }

        /// <summary>
        /// Loads the to-be-modded command
        /// </summary>
        private void LoadCommand()
        {
            // load the type
            CbType.Text = Command.Type.ToString();
            SetType(false);

            // set the name
            TbName.Text = Command.Name;

            // set optional setting
            var parsed = Enum.TryParse<CommandType>(CbType.SelectedValue.ToString(), out var type);
            if (!parsed) return;

            switch (type)
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
            }

            CbRunAsLowIntegrity.CheckState = Command.RunAsLowIntegrity ? CheckState.Checked : CheckState.Unchecked;

            // redraw
            Refresh();
        }

        /// <summary>
        /// Prepare the command for processing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStore_Click(object sender, EventArgs e)
        {
            // get and check type
            var typeStr = CbType.Text;
            if (string.IsNullOrEmpty(typeStr))
            {
                MessageBox.Show("Select a type first.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = CbType;
                return;
            }

            // get and check name
            var name = TbName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Enter a name first.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = TbName;
                return;
            }

            // name already used by us?
            if (Variables.Commands.Any(x => string.Equals(x.Name, name, StringComparison.InvariantCultureIgnoreCase) && x.Id != Command.Id.ToString()))
            {
                var confirm = MessageBoxAdv.Show("There's already a command with that name. Are you sure you want to continue?", "HASS.Agent", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes)
                {
                    ActiveControl = TbName;
                    return;
                }
            }

            // check and set optional settings
            var parsed = Enum.TryParse<CommandType>(CbType.SelectedValue.ToString(), out var type);
            if (!parsed)
            {
                MessageBox.Show("Select a valid type first.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = CbType;
                return;
            }

            switch (type)
            {
                case CommandType.CustomCommand:
                    var command = TbSetting.Text.Trim();
                    if (string.IsNullOrEmpty(command))
                    {
                        MessageBox.Show("Enter a command first.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ActiveControl = TbSetting;
                        return;
                    }
                    Command.Command = command;
                    break;

                case CommandType.PowershellCommand:
                    var script = TbSetting.Text.Trim();
                    if (string.IsNullOrEmpty(script))
                    {
                        MessageBox.Show("Enter a command or script first.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ActiveControl = TbSetting;
                        return;
                    }
                    Command.Command = script;
                    break;

                case CommandType.KeyCommand:
                    var keycode = TbSetting.Text.Trim();
                    if (string.IsNullOrEmpty(keycode))
                    {
                        MessageBox.Show("Enter a keycode first.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ActiveControl = TbSetting;
                        return;
                    }
                    Command.KeyCode = Encoding.ASCII.GetBytes(keycode).First();
                    break;
            }

            Command.RunAsLowIntegrity = CbRunAsLowIntegrity.CheckState == CheckState.Checked;

            // set values
            Command.Type = type;
            Command.Name = name;

            // done
            DialogResult = DialogResult.OK;
        }

        private void CbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetType();

            // redraw
            Refresh();
        }

        /// <summary>
        /// Change the UI depending on the selected type
        /// </summary>
        /// <param name="setInfo"></param>
        private void SetType(bool setInfo = true)
        {
            var parsed = Enum.TryParse<CommandType>(CbType.SelectedValue.ToString(), out var type);
            if (!parsed) return;

            if (setInfo)
            {
                TbName.Text = type.GetCommandName();
                TbDescription.Text = CommandsManager.GetCommandDefaultInfo(type);
            }

            switch (type)
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

                default:
                    SetEmptyGui();
                    break;
            }
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
                TbSetting.Visible = true;

                CbRunAsLowIntegrity.Visible = true;
                LblIntegrityInfo.Visible = true;
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
                TbSetting.Visible = true;

                CbRunAsLowIntegrity.CheckState = CheckState.Unchecked;
                CbRunAsLowIntegrity.Visible = false;
                LblIntegrityInfo.Visible = false;
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
                TbSetting.Visible = true;

                CbRunAsLowIntegrity.CheckState = CheckState.Unchecked;
                CbRunAsLowIntegrity.Visible = false;
                LblIntegrityInfo.Visible = false;
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
                TbSetting.Visible = false;

                CbRunAsLowIntegrity.CheckState = CheckState.Unchecked;
                CbRunAsLowIntegrity.Visible = false;
                LblIntegrityInfo.Visible = false;
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
                Refresh();
            }
            catch
            {
                // best effort
            }
        }

        /// <summary>
        /// Makes sure our combobox has the right colors
        /// <para>Source: https://stackoverflow.com/a/60421006 </para>
        /// <para>Source: https://stackoverflow.com/a/11650321 </para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbType_DrawItem(object sender, DrawItemEventArgs e)
        {
            // only if there are items
            if (CbType.Items.Count <= 0) return;

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
                var brush = (e.State & DrawItemState.Selected) > 0 ? new SolidBrush(Color.FromArgb(63, 63, 70)) : new SolidBrush(CbType.ForeColor);
                e.Graphics.DrawString(CbType.Items[index].ToString(), e.Font, brush, e.Bounds, StringFormat.GenericDefault);
            }

            // draw focus rectangle
            e.DrawFocusRectangle();
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
    }
}
