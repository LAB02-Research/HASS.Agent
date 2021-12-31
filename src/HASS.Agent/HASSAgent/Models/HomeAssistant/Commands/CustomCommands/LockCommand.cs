namespace HASSAgent.Models.HomeAssistant.Commands.CustomCommands
{
    internal class LockCommand : CustomCommand
    {
        internal LockCommand(string name = "Lock", string id = default) : base("Rundll32.exe user32.dll,LockWorkStation", name ?? "Lock", id)
        {
            State = "OFF";
        }
    }
}
