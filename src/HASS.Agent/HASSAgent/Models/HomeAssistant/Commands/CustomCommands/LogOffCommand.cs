namespace HASSAgent.Models.HomeAssistant.Commands.CustomCommands
{
    internal class LogOffCommand : CustomCommand
    {
        internal LogOffCommand(string name = "LogOff", string id = default) : base("shutdown /l", false, name ?? "LogOff", id)
        {
            State = "OFF";
        }
    }
}
