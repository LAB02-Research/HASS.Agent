using System;

namespace HASSAgent.Models.Mqtt.Commands.KeyCommands
{
    internal class MediaPreviousCommand : KeyCommand
    {
        internal MediaPreviousCommand(string name = "Previous", Guid id = default) : base(VK_MEDIA_PREV_TRACK, name ?? "Previous", id) { }
    }
}
