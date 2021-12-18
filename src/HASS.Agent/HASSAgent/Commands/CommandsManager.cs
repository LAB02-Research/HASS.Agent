using System;
using System.Threading.Tasks;
using HASSAgent.Enums;
using HASSAgent.Models.Mqtt.Commands;
using HASSAgent.Models.Mqtt.Commands.CustomCommands;
using HASSAgent.Models.Mqtt.Commands.KeyCommands;
using HASSAgent.Mqtt;
using Serilog;

namespace HASSAgent.Commands
{
    /// <summary>
    /// Continuously performs command autodiscovery and state publishing
    /// </summary>
    internal static class CommandsManager
    {
        private static bool _active = true;
        private static bool _pause;

        /// <summary>
        /// Initializes the command manager
        /// </summary>
        internal static async void Initialize()
        {
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
        /// Continuously processes commands (autodiscovery, state)
        /// </summary>
        private static async void Process()
        {
            while (_active)
            {
                try
                {
                    await Task.Delay(TimeSpan.FromSeconds(30));

                    // are we paused?
                    if (_pause) continue;

                    // is mqtt available?
                    if (MqttManager.GetStatus() != MqttStatus.Connected)
                    {
                        // nothing to do
                        continue;
                    }

                    // let hass know we're still here
                    await MqttManager.AnnounceAvailabilityAsync("sensor");

                    // publish command autodisco's
                    foreach (var command in Variables.Commands) await command.PublishAutoDiscoveryConfigAsync();

                    // publish command states
                    foreach (var command in Variables.Commands) await command.PublishStateAsync();
                }
                catch (Exception ex)
                {
                    Log.Fatal(ex, "[COMMANDSMANAGER] Eroor while publishing: {err}", ex.Message);
                }
            }
        }

        /// <summary>
        /// Returns default information for the specified command type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        internal static string GetCommandDefaultInfo(CommandType type)
        {
            switch (type)
            {
                case CommandType.ShutdownCommand:
                    return new ShutdownCommand().GetInfo();
                case CommandType.RestartCommand:
                    return new RestartCommand().GetInfo();
                case CommandType.LogOffCommand:
                    return new LogOffCommand().GetInfo();
                case CommandType.CustomCommand:
                    return new CustomCommand("").GetInfo();
                case CommandType.MediaPlayPauseCommand:
                    return new MediaPlayPauseCommand().GetInfo();
                case CommandType.MediaNextCommand:
                    return new MediaNextCommand().GetInfo();
                case CommandType.MediaPreviousCommand:
                    return new MediaPreviousCommand().GetInfo();
                case CommandType.MediaVolumeUpCommand:
                    return new MediaVolumeUpCommand().GetInfo();
                case CommandType.MediaVolumeDownCommand:
                    return new MediaVolumeDownCommand().GetInfo();
                case CommandType.MediaMuteCommand:
                    return new MediaMuteCommand().GetInfo();
                case CommandType.KeyCommand:
                    return new KeyCommand(byte.MinValue).GetInfo();
                default:
                    return "";
            }
        }
    }
}
