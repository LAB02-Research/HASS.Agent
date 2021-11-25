using System;

namespace HASSAgent.Models.Mqtt.Commands.KeyCommands
{
    internal class MediaVolumeUpCommand : KeyCommand
    {
        internal MediaVolumeUpCommand(string name = "VolumeUp", Guid id = default) : base(VK_VOLUME_UP, name ?? "VolumeUp", id) { }
    }
}
