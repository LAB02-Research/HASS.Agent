using HASS.Agent.Commands;
using HASS.Agent.Functions;
using HASS.Agent.Resources.Localization;
using HASS.Agent.Settings;
using HASS.Agent.Shared.Extensions;
using HASS.Agent.Shared.Models.Config;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Grid;

namespace HASS.Agent.Forms.Commands
{
    public partial class CommandsConfig : MetroForm
    {
        private List<ConfiguredCommand> _commands = new();
        private readonly List<ConfiguredCommand> _toBeDeletedCommands = new();

        private bool _storing = false;

        public CommandsConfig()
        {
            InitializeComponent();

            BindListViewTheme();
        }

        private void BindListViewTheme()
        {
            LvCommands.DrawItem += ListViewTheme.DrawItem;
            LvCommands.DrawSubItem += ListViewTheme.DrawSubItem;
            LvCommands.DrawColumnHeader += ListViewTheme.DrawColumnHeader;
        }

        private void CommandsConfig_Load(object sender, EventArgs e)
        {
            // catch all key presses
            KeyPreview = true;

            // load stored commands
            PrepareCommandsList();
        }

        /// <summary>
        /// Load the stored commands into the grid
        /// </summary>
        private void PrepareCommandsList()
        {
            // make a copy of the current commands
            _commands = Variables.Commands.Select(StoredCommands.ConvertAbstractToConfigured).Where(configuredCommand => configuredCommand != null).ToList();

            // show them
            UpdateCommandsList();
        }

        /// <summary>
        /// Reload the commands
        /// </summary>
        private void UpdateCommandsList()
        {
            LvCommands.BeginUpdate();

            // reload data
            LvCommands.Items.Clear();
            
            foreach (var command in _commands)
            {
                var commandCard = CommandsManager.CommandInfoCards[command.Type];

                var lviCommand = new ListViewItem(command.Id.ToString());
                lviCommand.SubItems.Add(command.Name);
                lviCommand.SubItems.Add(commandCard.Name);
                lviCommand.SubItems.Add(command.RunAsLowIntegrity ? "√" : string.Empty);
                lviCommand.SubItems.Add(commandCard.ActionCompatible ? "√" : string.Empty);

                LvCommands.Items.Add(lviCommand);
            }

            LvCommands.EndUpdate();
        }

        /// <summary>
        /// Open a new form to modify the selected command
        /// </summary>
        private void ModifySelectedCommand()
        {
            // are we currently storing them?
            if (_storing) return;

            // check for selected rows
            if (LvCommands.SelectedItems.Count == 0) return;

            // we can just modify one, so the first
            var guid = Guid.Parse(LvCommands.SelectedItems[0].Text);
            var selectedCommand = (_commands).Find(x => x.Id == guid);

            // show modding form
            using var command = new CommandsMod(selectedCommand);
            var res = command.ShowDialog();
            if (res != DialogResult.OK) return;

            // update in temp list
            _commands[_commands.FindIndex(x => x.Id == command.Command.Id)] = command.Command;

            // reload the gui list
            UpdateCommandsList();
        }

        /// <summary>
        /// Delete all selected commands
        /// <para>Note: doesn't actually execute deletion, that's done after the user clicks 'store'</para>
        /// </summary>
        private void DeleteSelectedCommands()
        {
            // check for selected rows
            if (LvCommands.SelectedItems.Count == 0) return;

            // iterate them
            foreach (ListViewItem row in LvCommands.SelectedItems)
            {
                // get object
                var guid = Guid.Parse(row.Text);
                var selectedCommand = _commands.Find(x => x.Id == guid);

                // add to to-be-deleted list
                _toBeDeletedCommands.Add(selectedCommand);

                // remove from the list
                _commands.RemoveAt(_commands.FindIndex(x => x.Id == guid));
            }

            // reload the gui list
            UpdateCommandsList();
        }

        /// <summary>
        /// Show a form to add a new command
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using var command = new CommandsMod();
            var res = command.ShowDialog();
            if (res != DialogResult.OK) return;

            // add to the temp list
            _commands.Add(command.Command);

            // reload the gui list
            UpdateCommandsList();
        }

        /// <summary>
        /// Stores our temporary list, and syncs it to HASS through MQTT 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnStore_Click(object sender, EventArgs e)
        {
            // prevent user from opening commands
            _storing = true;

            // lock interface
            BtnRemove.Enabled = false;
            BtnModify.Enabled = false;
            BtnAdd.Enabled = false;
            BtnStore.Enabled = false;
            BtnStore.Text = Languages.CommandsConfig_BtnStore_Storing;

            // store
            var stored = await Task.Run(async () => await CommandsManager.StoreAsync(_commands, _toBeDeletedCommands));
            if (!stored) MessageBoxAdv.Show(Languages.CommandsConfig_BtnStore_MessageBox1, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);

            // done
            Close();
        }

        private void BtnModify_Click(object sender, EventArgs e) => ModifySelectedCommand();

        private void BtnRemove_Click(object sender, EventArgs e) => DeleteSelectedCommands();

        private void CommandsConfig_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape) return;
            Close();
        }

        private void CommandsConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            //
        }

        private void LvCommands_DoubleClick(object sender, EventArgs e) => ModifySelectedCommand();

        private void CommandsConfig_ResizeEnd(object sender, EventArgs e)
        {
            if (Variables.ShuttingDown) return;
            if (!IsHandleCreated) return;
            if (IsDisposed) return;

            try
            {
                // show the listview
                LvCommands.Visible = true;

                // hide the pesky horizontal scrollbar
                ListViewTheme.ShowScrollBar(LvCommands.Handle, ListViewTheme.SB_HORZ, false);

                Refresh();
            }
            catch
            {
                // best effort
            }
        }

        private void CommandsConfig_ResizeBegin(object sender, EventArgs e)
        {
            if (Variables.ShuttingDown) return;
            if (!IsHandleCreated) return;
            if (IsDisposed) return;

            try
            {
                // hide the listview to prevent flickering
                LvCommands.Visible = false;
            }
            catch
            {
                // best effort
            }
        }

        private void CommandsConfig_Layout(object sender, LayoutEventArgs e)
        {
            // hide the pesky horizontal scrollbar
            ListViewTheme.ShowScrollBar(LvCommands.Handle, ListViewTheme.SB_HORZ, false);
        }

        private void PbActionInfo_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://github.com/LAB02-Research/HASS.Agent/wiki/Command-Actions-Usage-&-Examples");

        private void LblActionInfo_Click(object sender, EventArgs e) => HelperFunctions.LaunchUrl("https://github.com/LAB02-Research/HASS.Agent/wiki/Command-Actions-Usage-&-Examples");
    }
}
