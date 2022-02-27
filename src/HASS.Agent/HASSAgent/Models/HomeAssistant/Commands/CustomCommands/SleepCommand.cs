namespace HASSAgent.Models.HomeAssistant.Commands.CustomCommands
{
    internal class SleepCommand : CustomCommand
    {
        internal SleepCommand(string name = "Sleep", string id = default) : base("Rundll32.exe powrprof.dll,SetSuspendState 0,1,0", false, name ?? "Sleep", id)
        {
            State = "OFF";
        }
    }
}
