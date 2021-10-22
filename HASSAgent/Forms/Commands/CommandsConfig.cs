using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HASSAgent.Commands;
using HASSAgent.Models.Config;
using HASSAgent.Mqtt;
using HASSAgent.Settings;
using Serilog;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Grid;

namespace HASSAgent.Forms.Commands
{
    public partial class CommandsConfig : MetroForm
    {
        private List<ConfiguredCommand> _commands = new List<ConfiguredCommand>();
        private readonly List<ConfiguredCommand> _toBeDeletedCommands = new List<ConfiguredCommand>();

        public CommandsConfig()
        {
            InitializeComponent();
        }

        private void CommandsConfig_Load(object sender, EventArgs e)
        {
            // pause the commands manager
            CommandsManager.Pause();

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

            // bind to the list
            LcCommands.DataSource = _commands;

            // hide id column
            LcCommands.Grid.HideCols["Id"] = true;

            // hide command column
            LcCommands.Grid.HideCols["Command"] = true;

            // hide keycode column
            LcCommands.Grid.HideCols["KeyCode"] = true;

            // force column resize
            LcCommands.Grid.ColWidths.ResizeToFit(GridRangeInfo.Table(), GridResizeToFitOptions.IncludeHeaders);

            // add extra space
            for (var i = 1; i <= LcCommands.Grid.ColCount; i++) LcCommands.Grid.ColWidths[i] += 15;

            // redraw
            LcCommands.Refresh();
        }

        /// <summary>
        /// Reload the commands
        /// </summary>
        private void UpdateCommandsList()
        {
            // reload data
            LcCommands.Grid.ResetVolatileData();

            // force column resize
            LcCommands.Grid.ColWidths.ResizeToFit(GridRangeInfo.Table(), GridResizeToFitOptions.IncludeHeaders);

            // add extra space
            for (var i = 1; i <= LcCommands.Grid.ColCount; i++) LcCommands.Grid.ColWidths[i] += 15;

            // redraw
            LcCommands.Refresh();
        }

        /// <summary>
        /// Open a new form to modify the selected command
        /// </summary>
        private void ModifySelectedCommand()
        {
            // find all (if any) selected rows
            var selectedRows = LcCommands.Grid.Selections.GetSelectedRows(true, true);
            if (selectedRows.Count == 0) return;

            // we can just modify one, so the first
            var selectedRow = selectedRows[0];
            var selectedCommand = (ConfiguredCommand)LcCommands.Items[selectedRow.Top - 1];

            // show modding form
            using (var command = new CommandsMod(selectedCommand))
            {
                var res = command.ShowDialog();
                if (res != DialogResult.OK) return;

                // update in temp list
                _commands[_commands.FindIndex(x => x.Id == command.Command.Id)] = command.Command;

                // reload the gui list
                UpdateCommandsList();
            }
        }

        /// <summary>
        /// Delete all selected commands
        /// <para>Note: doesn't actually execute deletion, that's done after the user clicks 'store'</para>
        /// </summary>
        private void DeleteSelectedCommands()
        {
            // check for selected rows
            var selectedRows = LcCommands.Grid.Selections.GetSelectedRows(true, true);
            if (selectedRows.Count == 0) return;

            // get selected row indexes
            var rowList = new List<int>();
            for (var i = LcCommands.Grid.Model.SelectedRanges.ActiveRange.Top; i <= LcCommands.Grid.Model.SelectedRanges.ActiveRange.Bottom; i++)
            {
                rowList.Add(i - 1);
            }

            // make descending
            rowList.Sort();
            rowList.Reverse();

            foreach (var row in rowList)
            {
                // get object
                var qA = (ConfiguredCommand)LcCommands.Items[row];

                // add to to-be-deleted list
                _toBeDeletedCommands.Add(qA);

                // remove from the list
                _commands.RemoveAt(_commands.FindIndex(x => x.Id == qA.Id));
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
            using (var command = new CommandsMod())
            {
                var res = command.ShowDialog();
                if (res != DialogResult.OK) return;

                // add to the temp list
                _commands.Add(command.Command);

                // reload the gui list
                UpdateCommandsList();
            }
        }

        /// <summary>
        /// Stores our temporary list, and syncs it to HASS through MQTT 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnStore_Click(object sender, EventArgs e)
        {
            // lock interface
            LcCommands.Enabled = false;
            BtnRemove.Enabled = false;
            BtnModify.Enabled = false;
            BtnAdd.Enabled = false;
            BtnStore.Enabled = false;
            BtnStore.Text = "storing and registering, please wait .. ";

            await Task.Run(async delegate
            {
                try
                {
                    // process the to-be-removed
                    if (_toBeDeletedCommands.Any())
                    {
                        foreach (var abstractCommand in _toBeDeletedCommands.Select(StoredCommands.ConvertConfiguredToAbstract).Where(abstractCommand => abstractCommand != null))
                        {
                            // remove and unregister
                            await abstractCommand.UnPublishAutoDiscoveryConfigAsync();
                            await MqttManager.UnubscribeAsync(abstractCommand);
                            Variables.Commands.RemoveAt(Variables.Commands.FindIndex(x => x.Id == abstractCommand.Id));

                            Log.Information("[COMMANDS] Removed command: {command}", abstractCommand.Name);
                        }
                    }

                    // copy our list to the main one
                    foreach (var abstractCommand in _commands.Select(StoredCommands.ConvertConfiguredToAbstract).Where(abstractCommand => abstractCommand != null))
                    {
                        if (Variables.Commands.All(x => x.Id != abstractCommand.Id))
                        {
                            // new, add and register
                            Variables.Commands.Add(abstractCommand);
                            await MqttManager.SubscribeAsync(abstractCommand);
                            await abstractCommand.PublishAutoDiscoveryConfigAsync();
                            await abstractCommand.PublishStateAsync(false);

                            Log.Information("[COMMANDS] Added command: {command}", abstractCommand.Name);
                            continue;
                        }

                        // existing, update and re-register
                        var currentCommandIndex = Variables.Commands.FindIndex(x => x.Id == abstractCommand.Id);
                        if (Variables.Commands[currentCommandIndex].Name != abstractCommand.Name)
                        {
                            // name changed, unregister and resubscribe on new mqtt channel
                            Log.Information("[COMMANDS] Command changed name, re-registering as new entity: {old} to {new}", Variables.Commands[currentCommandIndex].Name, abstractCommand.Name);

                            await Variables.Commands[currentCommandIndex].UnPublishAutoDiscoveryConfigAsync();
                            await MqttManager.UnubscribeAsync(Variables.Commands[currentCommandIndex]);
                            await MqttManager.SubscribeAsync(abstractCommand);
                        }
                        
                        Variables.Commands[currentCommandIndex] = abstractCommand;
                        await abstractCommand.PublishAutoDiscoveryConfigAsync();
                        await abstractCommand.PublishStateAsync(false);

                        Log.Information("[COMMANDS] Modified command: {command}", abstractCommand.Name);
                    }

                    // annouce ourselves
                    await MqttManager.AnnounceAvailabilityAsync("sensor");

                    // store to file
                    StoredCommands.Store();
                }
                catch (Exception ex)
                {
                    Log.Fatal(ex, "[COMMANDS] Error while saving: {err}", ex.Message);
                    Variables.FrmM?.ShowMessageBox("An error occured while saving the commands, check the logs for more info.", true);
                }
            });

            // done
            DialogResult = DialogResult.OK;
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            ModifySelectedCommand();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            DeleteSelectedCommands();
        }

        private void CommandsConfig_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape) return;
            Close();
        }

        private void CommandsConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            // unpause the commands manager
            CommandsManager.Unpause();
        }

        private void LcCommands_DoubleClick(object sender, EventArgs e)
        {
            ModifySelectedCommand();
        }
    }
}
