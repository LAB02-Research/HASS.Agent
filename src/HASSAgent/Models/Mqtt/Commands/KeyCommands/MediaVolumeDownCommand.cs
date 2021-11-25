using System;

namespace HASSAgent.Models.Mqtt.Commands.KeyCommands
{
    internal class MediaVolumeDownCommand : KeyCommand
    {
        internal MediaVolumeDownCommand(string name = "VolumeDown", Guid id = default) : base(VK_VOLUME_DOWN, name ?? "VolumeDown", id) { }
    }
}
