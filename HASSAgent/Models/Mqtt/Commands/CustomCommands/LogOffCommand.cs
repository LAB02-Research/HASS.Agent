using System;

namespace HASSAgent.Models.Mqtt.Commands.CustomCommands
{
    internal class LogOffCommand : CustomCommand
    {
        internal LogOffCommand(string name = "LogOff", Guid id = default) : base("shutdown /l", name ?? "LogOff", id)
        {
            State = "OFF";
        }
    }
}
