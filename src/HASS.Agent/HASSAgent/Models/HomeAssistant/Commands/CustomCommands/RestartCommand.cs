namespace HASSAgent.Models.HomeAssistant.Commands.CustomCommands
{
    internal class RestartCommand : CustomCommand
    {
        internal RestartCommand(string name = "Restart", string id = default) : base("shutdown /r", name ?? "Restart", id)
        {
            State = "OFF";
        }
    }
}
