using System;

namespace HASSAgent.Models.Mqtt.Commands.CustomCommands
{
    internal class ShutdownCommand : CustomCommand
    {
        internal ShutdownCommand(string name = "Shutdown", Guid id = default) : base("shutdown /s", name ?? "Shutdown", id)
        {
            State = "OFF";
        }
    }
}
