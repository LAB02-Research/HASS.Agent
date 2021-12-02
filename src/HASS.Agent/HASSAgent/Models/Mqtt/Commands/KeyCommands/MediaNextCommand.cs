using System;

namespace HASSAgent.Models.Mqtt.Commands.KeyCommands
{
    internal class MediaNextCommand : KeyCommand
    {
        internal MediaNextCommand(string name = "Next", Guid id = default) : base(VK_MEDIA_NEXT_TRACK, name ?? "Next", id) { }
    }
}
