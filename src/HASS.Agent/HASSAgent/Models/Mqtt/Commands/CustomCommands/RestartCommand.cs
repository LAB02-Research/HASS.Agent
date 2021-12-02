using System;

namespace HASSAgent.Models.Mqtt.Commands.CustomCommands
{
    internal class RestartCommand : CustomCommand
    {
        internal RestartCommand(string name = "Restart", Guid id = default) : base("shutdown /r", name ?? "Restart", id)
        {
            State = "OFF";
        }
    }
}
