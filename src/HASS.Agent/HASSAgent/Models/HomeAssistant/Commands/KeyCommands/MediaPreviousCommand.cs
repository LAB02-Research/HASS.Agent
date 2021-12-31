namespace HASSAgent.Models.HomeAssistant.Commands.KeyCommands
{
    internal class MediaPreviousCommand : KeyCommand
    {
        internal MediaPreviousCommand(string name = "Previous", string id = default) : base(VK_MEDIA_PREV_TRACK, name ?? "Previous", id) { }
    }
}
