using HASS.Agent.Models.Internal;
using HASS.Agent.Resources.Localization;
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
                Languages.CommandsManager_CustomCommandDescription,
                true, true, true);

            CommandInfoCards.Add(commandInfoCard.CommandType, commandInfoCard);

            // =================================

            commandInfoCard = new CommandInfoCard(CommandType.CustomExecutorCommand,
                Languages.CommandsManager_CustomExecutorCommandDescription,
                true, true, true);

            CommandInfoCards.Add(commandInfoCard.CommandType, commandInfoCard);

            // =================================

            commandInfoCard = new CommandInfoCard(CommandType.HibernateCommand,
                Languages.CommandsManager_HibernateCommandDescription,
                true, true, false);

            CommandInfoCards.Add(commandInfoCard.CommandType, commandInfoCard);

            // =================================

            commandInfoCard = new CommandInfoCard(CommandType.KeyCommand,
                Languages.CommandsManager_KeyCommandDescription,
                true, false, false);

            CommandInfoCards.Add(commandInfoCard.CommandType, commandInfoCard);

            // =================================

            commandInfoCard = new CommandInfoCard(CommandType.LaunchUrlCommand,
                Languages.CommandsManager_LaunchUrlCommandDescription,
                true, false, true);

            CommandInfoCards.Add(commandInfoCard.CommandType, commandInfoCard);

            // =================================

            commandInfoCard = new CommandInfoCard(CommandType.LockCommand,
                Languages.CommandsManager_LockCommandDescription,
                true, false, false);

            CommandInfoCards.Add(commandInfoCard.CommandType, commandInfoCard);

            // =================================

            commandInfoCard = new CommandInfoCard(CommandType.LogOffCommand,
                Languages.CommandsManager_LogOffCommandDescription,
                true, false, false);

            CommandInfoCards.Add(commandInfoCard.CommandType, commandInfoCard);

            // =================================

            commandInfoCard = new CommandInfoCard(CommandType.MediaMuteCommand,
                Languages.CommandsManager_MediaMuteCommandDescription,
                true, false, false);

            CommandInfoCards.Add(commandInfoCard.CommandType, commandInfoCard);

            // =================================

            commandInfoCard = new CommandInfoCard(CommandType.MediaNextCommand,
                Languages.CommandsManager_MediaNextCommandDescription,
                true, false, false);

            CommandInfoCards.Add(commandInfoCard.CommandType, commandInfoCard);

            // =================================

            commandInfoCard = new CommandInfoCard(CommandType.MediaPlayPauseCommand,
                Languages.CommandsManager_MediaPlayPauseCommandDescription,
                true, false, false);

            CommandInfoCards.Add(commandInfoCard.CommandType, commandInfoCard);

            // =================================

            commandInfoCard = new CommandInfoCard(CommandType.MediaPreviousCommand,
                Languages.CommandsManager_MediaPreviousCommandDescription,
                true, false, false);

            CommandInfoCards.Add(commandInfoCard.CommandType, commandInfoCard);

            // =================================

            commandInfoCard = new CommandInfoCard(CommandType.MediaVolumeDownCommand,
                Languages.CommandsManager_MediaVolumeDownCommandDescription,
                true, false, false);

            CommandInfoCards.Add(commandInfoCard.CommandType, commandInfoCard);

            // =================================

            commandInfoCard = new CommandInfoCard(CommandType.MediaVolumeUpCommand,
                Languages.CommandsManager_MediaVolumeUpCommandDescription,
                true, false, false);

            CommandInfoCards.Add(commandInfoCard.CommandType, commandInfoCard);

            // =================================

            commandInfoCard = new CommandInfoCard(CommandType.MultipleKeysCommand,
                Languages.CommandsManager_MultipleKeysCommandDescription,
                true, false, false);

            CommandInfoCards.Add(commandInfoCard.CommandType, commandInfoCard);

            // =================================

            commandInfoCard = new CommandInfoCard(CommandType.PowershellCommand,
                Languages.CommandsManager_PowershellCommandDescription,
                true, true, true);

            CommandInfoCards.Add(commandInfoCard.CommandType, commandInfoCard);

            // =================================

            commandInfoCard = new CommandInfoCard(CommandType.PublishAllSensorsCommand,
                Languages.CommandsManager_PublishAllSensorsCommandDescription,
                true, true, false);

            CommandInfoCards.Add(commandInfoCard.CommandType, commandInfoCard);

            // =================================

            commandInfoCard = new CommandInfoCard(CommandType.RestartCommand,
                Languages.CommandsManager_RestartCommandDescription,
                true, true, false);

            CommandInfoCards.Add(commandInfoCard.CommandType, commandInfoCard);

            // =================================

            commandInfoCard = new CommandInfoCard(CommandType.ShutdownCommand,
                Languages.CommandsManager_ShutdownCommandDescription,
                true, true, false);

            CommandInfoCards.Add(commandInfoCard.CommandType, commandInfoCard);

            // =================================

            commandInfoCard = new CommandInfoCard(CommandType.SleepCommand,
                Languages.CommandsManager_SleepCommandDescription,
                true, true, false);

            CommandInfoCards.Add(commandInfoCard.CommandType, commandInfoCard);
        }
    }
}
