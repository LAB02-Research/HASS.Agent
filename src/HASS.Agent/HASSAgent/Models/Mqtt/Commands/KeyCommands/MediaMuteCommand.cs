using System;

namespace HASSAgent.Models.Mqtt.Commands.KeyCommands
{
    internal class MediaMuteCommand : KeyCommand
    {
        internal MediaMuteCommand(string name = "Mute", Guid id = default) : base(VK_VOLUME_MUTE, name ?? "Mute", id) { }
    }
}
