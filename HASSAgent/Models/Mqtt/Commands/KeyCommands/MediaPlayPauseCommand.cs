using System;

namespace HASSAgent.Models.Mqtt.Commands.KeyCommands
{
    internal class MediaPlayPauseCommand : KeyCommand
    {
        internal MediaPlayPauseCommand(string name = "PlayPause", Guid id = default) : base(VK_MEDIA_PLAY_PAUSE, name ?? "PlayPause", id) { }
    }
}
