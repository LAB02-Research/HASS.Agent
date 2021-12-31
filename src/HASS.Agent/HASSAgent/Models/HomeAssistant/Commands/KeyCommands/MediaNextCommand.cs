namespace HASSAgent.Models.HomeAssistant.Commands.KeyCommands
{
    internal class MediaNextCommand : KeyCommand
    {
        internal MediaNextCommand(string name = "Next", string id = default) : base(VK_MEDIA_NEXT_TRACK, name ?? "Next", id) { }
    }
}
