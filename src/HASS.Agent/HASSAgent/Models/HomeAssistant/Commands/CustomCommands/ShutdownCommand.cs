namespace HASSAgent.Models.HomeAssistant.Commands.CustomCommands
{
    internal class ShutdownCommand : CustomCommand
    {
        internal ShutdownCommand(string name = "Shutdown", string id = default) : base("shutdown /s", false, name ?? "Shutdown", id)
        {
            State = "OFF";
        }
    }
}
