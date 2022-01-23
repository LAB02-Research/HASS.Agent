using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HASSAgent.Enums;
using HASSAgent.Mqtt;
using HASSAgent.Settings;
using Serilog;

namespace HASSAgent.Commands
{
    /// <summary>
    /// Continuously performs command autodiscovery and state publishing
    /// </summary>
    internal static class CommandsManager
    {
        private static readonly Dictionary<CommandType, string> CommandInfo = new Dictionary<CommandType, string>();

        private static bool _active = true;
        private static bool _pause;

        private static DateTime _lastAutoDiscoPublish = DateTime.MinValue;

        /// <summary>
        /// Initializes the command manager
        /// </summary>
        internal static async void Initialize()
        {
            // load command descriptions
            LoadCommandInfo();

            // wait while mqtt's connecting
            while (MqttManager.GetStatus() == MqttStatus.Connecting) await Task.Delay(250);

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
                await MqttManager.UnubscribeAsync(command);
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
                        firstRun = false;
                    }
                    else await Task.Delay(TimeSpan.FromSeconds(30));

                    // are we paused?
                    if (_pause) continue;

                    // is mqtt available?
                    if (MqttManager.GetStatus() != MqttStatus.Connected)
                    {
                        // nothing to do
                        continue;
                    }

                    // do we have commands?
                    if (!CommandsPresent()) continue;

                    // publish availability & sensor autodisco's every 30 sec
                    if ((DateTime.Now - _lastAutoDiscoPublish).TotalSeconds > 30)
                    {
                        // let hass know we're still here
                        await MqttManager.AnnounceAvailabilityAsync();

                        // publish command autodisco's
                        foreach (var command in Variables.Commands.TakeWhile(command => !_pause).TakeWhile(command => _active))
                        {
                            await command.PublishAutoDiscoveryConfigAsync();
                        }

                        // are we subscribed?
                        if (!subscribed)
                        {
                            foreach (var command in Variables.Commands.TakeWhile(command => !_pause).TakeWhile(command => _active))
                            {
                                await MqttManager.SubscribeAsync(command);
                            }
                            subscribed = true;
                        }

                        // log moment
                        _lastAutoDiscoPublish = DateTime.Now;
                    }

                    // publish command states (they have their own time-based scheduling)
                    foreach (var command in Variables.Commands.TakeWhile(command => !_pause).TakeWhile(command => _active))
                    {
                        await command.PublishStateAsync();
                    }
                }
                catch (Exception ex)
                {
                    Log.Fatal(ex, "[COMMANDSMANAGER] Eroor while publishing: {err}", ex.Message);
                }
            }
        }

        private static bool CommandsPresent() => Variables.Commands != null && Variables.Commands.Any();

        /// <summary>
        /// Returns default information for the specified command type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        internal static string GetCommandDefaultInfo(CommandType type)
        {
            return !CommandInfo.ContainsKey(type) ? "unknown command" : CommandInfo[type];
        }

        /// <summary>
        /// Loads info regarding the various command types
        /// </summary>
        private static void LoadCommandInfo()
        {
            CommandInfo.Add(CommandType.ShutdownCommand, "Shuts down the machine after one minute.\r\n\r\nTip: accidentally triggered? Run 'shutdown /a' to abort.");
            CommandInfo.Add(CommandType.RestartCommand, "Restarts the machine after one minute.\r\n\r\nTip: accidentally triggered? Run 'shutdown /a' to abort.");
            CommandInfo.Add(CommandType.HibernateCommand, "Sets the machine in hibernation.");
            CommandInfo.Add(CommandType.LogOffCommand, "Logs off the current session.");
            CommandInfo.Add(CommandType.LockCommand, "Locks the current session.");
            CommandInfo.Add(CommandType.CustomCommand, "Execute a custom command.\r\n\r\nThese commands run without special elevation. To run elevated, create a Scheduled Task, and use 'schtasks /Run /TN \"TaskName\"' as the command to execute your task.\r\n\r\nOr enable 'run as low integrity' for even stricter execution.");
            CommandInfo.Add(CommandType.PowershellCommand, "Execute a Powershell command or script.\r\n\r\nYou can either provide the location of a script (*.ps1), or a single-line command.\r\n\r\nThis will run without special elevation.");
            CommandInfo.Add(CommandType.MediaPlayPauseCommand, "Simulates 'media playpause' key.");
            CommandInfo.Add(CommandType.MediaNextCommand, "Simulates 'media next' key.");
            CommandInfo.Add(CommandType.MediaPreviousCommand, "Simulates 'media previous' key.");
            CommandInfo.Add(CommandType.MediaVolumeUpCommand, "Simulates 'volume up' key.");
            CommandInfo.Add(CommandType.MediaVolumeDownCommand, "Simulates 'volume down' key.");
            CommandInfo.Add(CommandType.MediaMuteCommand, "Simulates 'mute' key.");
            CommandInfo.Add(CommandType.KeyCommand, "Simulates a single keypress.\r\n\r\nYou can pick any of these values: https://docs.microsoft.com/en-us/windows/win32/inputdev/virtual-key-codes \r\n\r\nAnother option is using a tool like AutoHotKey and binding it to a CustomCommand.");
        }
    }
}
