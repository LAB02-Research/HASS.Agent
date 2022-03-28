using HASS.Agent.Models.Internal;
using HASS.Agent.Settings;
using HASS.Agent.Shared.Enums;
using HASS.Agent.Shared.Models.Config;
using Serilog;

namespace HASS.Agent.Commands
{
    /// <summary>
    /// Continuously performs command autodiscovery and state publishing
    /// </summary>
    internal static class CommandsManager
    {
        internal static readonly Dictionary<CommandType, CommandInfoCard> CommandInfoCards = new();

        private static bool _active = true;
        private static bool _pause;

        private static DateTime _lastAutoDiscoPublish = DateTime.MinValue;

        /// <summary>
        /// Initializes the command manager
        /// </summary>
        internal static async void Initialize()
        {
            // wait while mqtt's connecting
            while (Variables.MqttManager.GetStatus() == MqttStatus.Connecting) await Task.Delay(250);

            // start background processing
            _ = Task.Run(Process);
        }

        /// <summary>
        /// Stop processing commands
        /// </summary>
        internal static void Stop() => _active = false;

        /// <summary>
        /// Pause processing commands
        /// </summary>
        internal static void Pause() => _pause = true;

        /// <summary>
        /// Resume processing commands
        /// </summary>
        internal static void Unpause() => _pause = false;

        /// <summary>
        /// Unpublishes all commands
        /// </summary>
        /// <returns></returns>
        internal static async Task UnpublishAllCommands()
        {
            // unpublish the autodisco's
            if (!CommandsPresent()) return;
            foreach (var command in Variables.Commands)
            {
                await command.UnPublishAutoDiscoveryConfigAsync();
                await Variables.MqttManager.UnubscribeAsync(command);
            }
        }

        /// <summary>
        /// Generates new ID's for all commands
        /// </summary>
        internal static void ResetCommandIds()
        {
            if (!CommandsPresent()) return;
            foreach (var command in Variables.Commands) command.Id = Guid.NewGuid().ToString();

            StoredCommands.Store();
        }

        /// <summary>
        /// Continuously processes commands (autodiscovery, state)
        /// </summary>
        private static async void Process()
        {
            var firstRun = true;
            var subscribed = false;

            while (_active)
            {
                try
                {
                    if (firstRun)
                    {
                        // on the first run, just wait 1 sec - this is to make sure we're announcing ourselves,
                        // when there are no sensors or when the sensor manager's still initialising
                        await Task.Delay(TimeSpan.FromSeconds(1));
                    }
                    else await Task.Delay(TimeSpan.FromSeconds(30));

                    // are we paused?
                    if (_pause) continue;

                    // is mqtt available?
                    if (Variables.MqttManager.GetStatus() != MqttStatus.Connected)
                    {
                        // nothing to do
                        continue;
                    }

                    // we're starting the first real run
                    firstRun = false;

                    // do we have commands?
                    if (!CommandsPresent()) continue;

                    // publish availability & sensor autodisco's every 30 sec
                    if ((DateTime.Now - _lastAutoDiscoPublish).TotalSeconds > 30)
                    {
                        // let hass know we're still here
                        await Variables.MqttManager.AnnounceAvailabilityAsync();

                        // publish command autodisco's
                        foreach (var command in Variables.Commands.TakeWhile(_ => !_pause).TakeWhile(_ => _active))
                        {
                            if (_pause || Variables.MqttManager.GetStatus() != MqttStatus.Connected) continue;
                            await command.PublishAutoDiscoveryConfigAsync();
                        }

                        // are we subscribed?
                        if (!subscribed)
                        {
                            foreach (var command in Variables.Commands.TakeWhile(_ => !_pause).TakeWhile(_ => _active))
                            {
                                if (_pause || Variables.MqttManager.GetStatus() != MqttStatus.Connected) continue;
                                await Variables.MqttManager.SubscribeAsync(command);
                            }
                            subscribed = true;
                        }

                        // log moment
                        _lastAutoDiscoPublish = DateTime.Now;
                    }

                    // publish command states (they have their own time-based scheduling)
                    foreach (var command in Variables.Commands.TakeWhile(_ => !_pause).TakeWhile(_ => _active))
                    {
                        if (_pause || Variables.MqttManager.GetStatus() != MqttStatus.Connected) continue;
                        await command.PublishStateAsync();
                    }
                }
                catch (Exception ex)
                {
                    Log.Fatal(ex, "[COMMANDSMANAGER] Error while publishing: {err}", ex.Message);
                }
            }
        }

        /// <summary>
        /// Stores the provided commands, and (re)publishes them
        /// </summary>
        /// <param name="commands"></param>
        /// <param name="toBeDeletedCommands"></param>
        /// <returns></returns>
        internal static async Task<bool> StoreAsync(List<ConfiguredCommand> commands, List<ConfiguredCommand> toBeDeletedCommands = null)
        {
            toBeDeletedCommands ??= new List<ConfiguredCommand>();

            try
            {
                // pause processing
                Pause();

                // process the to-be-removed
                if (toBeDeletedCommands.Any())
                {
                    foreach (var abstractCommand in toBeDeletedCommands.Select(StoredCommands.ConvertConfiguredToAbstract).Where(abstractCommand => abstractCommand != null))
                    {
                        // remove and unregister
                        await abstractCommand.UnPublishAutoDiscoveryConfigAsync();
                        await Variables.MqttManager.UnubscribeAsync(abstractCommand);
                        Variables.Commands.RemoveAt(Variables.Commands.FindIndex(x => x.Id == abstractCommand.Id));

                        Log.Information("[COMMANDS] Removed command: {command}", abstractCommand.Name);
                    }
                }

                // copy our list to the main one
                foreach (var abstractCommand in commands.Select(StoredCommands.ConvertConfiguredToAbstract).Where(abstractCommand => abstractCommand != null))
                {
                    if (Variables.Commands.All(x => x.Id != abstractCommand.Id))
                    {
                        // new, add and register
                        Variables.Commands.Add(abstractCommand);
                        await Variables.MqttManager.SubscribeAsync(abstractCommand);
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
                        await Variables.MqttManager.UnubscribeAsync(Variables.Commands[currentCommandIndex]);
                        await Variables.MqttManager.SubscribeAsync(abstractCommand);
                    }

                    Variables.Commands[currentCommandIndex] = abstractCommand;
                    await abstractCommand.PublishAutoDiscoveryConfigAsync();
                    await abstractCommand.PublishStateAsync(false);

                    Log.Information("[COMMANDS] Modified command: {command}", abstractCommand.Name);
                }

                // annouce ourselves
                await Variables.MqttManager.AnnounceAvailabilityAsync();

                // store to file
                StoredCommands.Store();

                // done
                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[COMMANDSMANAGER] Error while storing: {err}", ex.Message);
                return false;
            }
            finally
            {
                // resume processing
                Unpause();
            }
        }

        private static bool CommandsPresent() => Variables.Commands != null && Variables.Commands.Any();

        /// <summary>
        /// Returns default information for the specified command type, or null if not found
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        internal static CommandInfoCard GetCommandDefaultInfo(CommandType type)
        {
            return CommandInfoCards.ContainsKey(type) ? CommandInfoCards[type] : null;
        }

        /// <summary>
        /// Loads info regarding the various command types
        /// </summary>
        internal static void LoadCommandInfo()
        {
            // =================================

            var commandInfoCard = new CommandInfoCard(CommandType.CustomCommand,
                "Execute a custom command.\r\n\r\nThese commands run without special elevation. To run elevated, create a Scheduled Task, and use 'schtasks /Run /TN \"TaskName\"' as the command to execute your task.\r\n\r\nOr enable 'run as low integrity' for even stricter execution.",
                true, true);

            CommandInfoCards.Add(commandInfoCard.CommandType, commandInfoCard);

            // =================================

            commandInfoCard = new CommandInfoCard(CommandType.CustomExecutorCommand,
                "Executes the command through the configured custom executor (in Configuration -> External Tools).\r\n\r\nYour command is provided as an argument 'as is', so you have to supply your own quotes etc. if necessary.",
                true, true);

            CommandInfoCards.Add(commandInfoCard.CommandType, commandInfoCard);

            // =================================

            commandInfoCard = new CommandInfoCard(CommandType.HibernateCommand,
                "Sets the machine in hibernation.",
                true, true);

            CommandInfoCards.Add(commandInfoCard.CommandType, commandInfoCard);

            // =================================

            commandInfoCard = new CommandInfoCard(CommandType.KeyCommand,
                "Simulates a single keypress.\r\n\r\nYou can pick any of these values: https://docs.microsoft.com/en-us/windows/win32/inputdev/virtual-key-codes \r\n\r\nIf you need more keys and/or modifiers like CTRL, use the MultipleKeys command.",
                true, false);

            CommandInfoCards.Add(commandInfoCard.CommandType, commandInfoCard);

            // =================================

            commandInfoCard = new CommandInfoCard(CommandType.LaunchUrlCommand,
                "Launches the provided URL, by default in your default browser.\r\n\r\nTo use 'incognito', provide a specific browser in Configuration -> External Tools.",
                true, false);

            CommandInfoCards.Add(commandInfoCard.CommandType, commandInfoCard);

            // =================================

            commandInfoCard = new CommandInfoCard(CommandType.LockCommand,
                "Locks the current session.",
                true, false);

            CommandInfoCards.Add(commandInfoCard.CommandType, commandInfoCard);

            // =================================

            commandInfoCard = new CommandInfoCard(CommandType.LogOffCommand,
                "Logs off the current session.",
                true, false);

            CommandInfoCards.Add(commandInfoCard.CommandType, commandInfoCard);

            // =================================

            commandInfoCard = new CommandInfoCard(CommandType.MediaMuteCommand,
                "Simulates 'mute' key.",
                true, false);

            CommandInfoCards.Add(commandInfoCard.CommandType, commandInfoCard);

            // =================================

            commandInfoCard = new CommandInfoCard(CommandType.MediaNextCommand,
                "Simulates 'media next' key.",
                true, false);

            CommandInfoCards.Add(commandInfoCard.CommandType, commandInfoCard);

            // =================================

            commandInfoCard = new CommandInfoCard(CommandType.MediaPlayPauseCommand,
                "Simulates 'media playpause' key.",
                true, false);

            CommandInfoCards.Add(commandInfoCard.CommandType, commandInfoCard);

            // =================================

            commandInfoCard = new CommandInfoCard(CommandType.MediaPreviousCommand,
                "Simulates 'media previous' key.",
                true, false);

            CommandInfoCards.Add(commandInfoCard.CommandType, commandInfoCard);

            // =================================

            commandInfoCard = new CommandInfoCard(CommandType.MediaVolumeDownCommand,
                "Simulates 'volume down' key.",
                true, false);

            CommandInfoCards.Add(commandInfoCard.CommandType, commandInfoCard);

            // =================================

            commandInfoCard = new CommandInfoCard(CommandType.MediaVolumeUpCommand,
                "Simulates 'volume up' key.",
                true, false);

            CommandInfoCards.Add(commandInfoCard.CommandType, commandInfoCard);

            // =================================

            commandInfoCard = new CommandInfoCard(CommandType.MultipleKeysCommand,
                "Simulates pressing mulitple keys.\r\n\r\nYou need to put [ ] between every key, otherwise HASS.Agent can't tell them apart. So say you want to press X TAB Y SHIFT-Z, it'd be [X] [{TAB}] [Y] [+Z].\r\n\r\nThere are a few tricks you can use:\r\n\r\n- Special keys go between { }, like {TAB} or {UP}\r\n\r\n- Put a + in front of a key to add SHIFT, ^ for CTRL and % for ALT. So, +C is SHIFT-C. Or, +(CD) is SHIFT-C and SHIFT-D, while +CD is SHIFT-C and D\r\n\r\n- For multiple presses, use {z 15}, which means Z will get pressed 15 times.\r\n\r\nMore info: https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.sendkeys",
                true, false);

            CommandInfoCards.Add(commandInfoCard.CommandType, commandInfoCard);

            // =================================

            commandInfoCard = new CommandInfoCard(CommandType.PowershellCommand,
                "Execute a Powershell command or script.\r\n\r\nYou can either provide the location of a script (*.ps1), or a single-line command.\r\n\r\nThis will run without special elevation.",
                true, true);

            CommandInfoCards.Add(commandInfoCard.CommandType, commandInfoCard);

            // =================================

            commandInfoCard = new CommandInfoCard(CommandType.PublishAllSensorsCommand,
                "Resets all sensor checks, forcing all sensors to process and send their value.\r\n\r\nUseful for example if you want to force HASS.Agent to update all your sensors after a HA reboot.",
                true, true);

            CommandInfoCards.Add(commandInfoCard.CommandType, commandInfoCard);

            // =================================

            commandInfoCard = new CommandInfoCard(CommandType.RestartCommand,
                "Restarts the machine after one minute.\r\n\r\nTip: accidentally triggered? Run 'shutdown /a' to abort.",
                true, true);

            CommandInfoCards.Add(commandInfoCard.CommandType, commandInfoCard);

            // =================================

            commandInfoCard = new CommandInfoCard(CommandType.ShutdownCommand,
                "Shuts down the machine after one minute.\r\n\r\nTip: accidentally triggered? Run 'shutdown /a' to abort.",
                true, true);

            CommandInfoCards.Add(commandInfoCard.CommandType, commandInfoCard);

            // =================================

            commandInfoCard = new CommandInfoCard(CommandType.SleepCommand,
                "Puts the machine to sleep.\r\n\r\nNote: due to a limitation in Windows, this only works if hibernation is disabled, otherwise it will just hibernate.\r\n\r\nYou can use something like NirCmd (http://www.nirsoft.net/utils/nircmd.html) to circumvent this.",
                true, true);

            CommandInfoCards.Add(commandInfoCard.CommandType, commandInfoCard);
        }
    }
}
