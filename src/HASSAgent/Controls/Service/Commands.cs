using HASSAgent.Commands;
using HASSAgent.Forms.Commands;
using HASSAgent.Functions;
using HASSAgent.Shared.Models.Config;
using Serilog;
using Syncfusion.Windows.Forms;

namespace HASSAgent.Controls.Service
{
    public partial class Commands : UserControl
    {
        private string _deviceName;
        private readonly List<ConfiguredCommand> _commands = new();

        private bool _storing = false;

        public Commands()
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

        private void Commands_Load(object sender, EventArgs e)
        {
            //
        }

        /// <summary>
        /// Load the provided commands
        /// </summary>
        /// <param name="configuredCommands"></param>
        /// <param name="deviceName"></param>
        public void SetCommands(List<ConfiguredCommand> configuredCommands, string deviceName)
        {
            _deviceName = deviceName;
            foreach (var command in configuredCommands) _commands.Add(command);

            UpdateCommandsList();
        }

        /// <summary>
        /// Reload the commands
        /// </summary>
        private void UpdateCommandsList()
        {
            try
            {
                LvCommands.BeginUpdate();

                // reload data
                LvCommands.Items.Clear();

                foreach (var command in _commands)
                {
                    var lviCommand = new ListViewItem(command.Id.ToString());
                    lviCommand.SubItems.Add(command.Name);
                    lviCommand.SubItems.Add(CommandsManager.CommandInfoCards[command.Type].Name);
                    lviCommand.SubItems.Add(command.RunAsLowIntegrity ? "√" : "");

                    LvCommands.Items.Add(lviCommand);
                }

                LvCommands.EndUpdate();
            }
            catch (NullReferenceException)
            {
                // whatever
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SERVICECONFIG_COMMANDS] Error while updating: {err}", ex.Message);
            }
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
            using var command = new CommandsMod(selectedCommand, true, _deviceName);
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
            using var command = new CommandsMod(true, _deviceName);
            var res = command.ShowDialog();
            if (res != DialogResult.OK) return;

            // add to the temp list
            _commands.Add(command.Command);

            // reload the gui list
            UpdateCommandsList();
        }

        private void BtnModify_Click(object sender, EventArgs e) => ModifySelectedCommand();

        private void BtnRemove_Click(object sender, EventArgs e) => DeleteSelectedCommands();

        /// <summary>
        /// Sends the current list to the service
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnStore_Click(object sender, EventArgs e)
        {
            // lock interface
            LockUi();

            // store
            var (storedOk, _) = await Task.Run(async () => await Variables.RpcClient.SetConfiguredCommandsAsync(_commands).WaitAsync(Variables.RpcConnectionTimeout));
            if (!storedOk) MessageBoxAdv.Show("An error occured while saving the commands, check the logs for more info.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else await ShowStored();

            // done, unlock ui
            UnlockUi();
        }

        private void LvCommands_DoubleClick(object sender, EventArgs e) => ModifySelectedCommand();

        private void LockUi()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(LockUi));
                return;
            }

            BtnStore.Text = "storing and registering, please wait .. ";
            _storing = true;

            foreach (var button in Controls.OfType<Button>()) button.Enabled = false;
            foreach (var textBox in Controls.OfType<TextBox>()) textBox.Enabled = false;
            foreach (var checkBox in Controls.OfType<CheckBox>()) checkBox.Enabled = false;
            foreach (var numericUpDown in Controls.OfType<NumericUpDown>()) numericUpDown.Enabled = false;
        }

        private void UnlockUi()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(UnlockUi));
                return;
            }

            BtnStore.Text = "send and activate commands";
            _storing = false;

            foreach (var button in Controls.OfType<Button>()) button.Enabled = true;
            foreach (var textBox in Controls.OfType<TextBox>()) textBox.Enabled = true;
            foreach (var checkBox in Controls.OfType<CheckBox>()) checkBox.Enabled = true;
            foreach (var numericUpDown in Controls.OfType<NumericUpDown>()) numericUpDown.Enabled = true;
        }

        private async Task ShowStored()
        {
            Invoke(new MethodInvoker(delegate { LblStored.Visible = true; }));
            await Task.Delay(TimeSpan.FromSeconds(3));
            Invoke(new MethodInvoker(delegate { LblStored.Visible = false; }));
        }

        private void Commands_Layout(object sender, LayoutEventArgs e)
        {
            // hide the pesky horizontal scrollbar
            ListViewTheme.ShowScrollBar(LvCommands.Handle, ListViewTheme.SB_HORZ, false);
        }
    }
}
