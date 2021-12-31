namespace HASSAgent.Models.HomeAssistant.Commands.KeyCommands
{
    internal class MediaMuteCommand : KeyCommand
    {
        internal MediaMuteCommand(string name = "Mute", string id = default) : base(VK_VOLUME_MUTE, name ?? "Mute", id) { }
    }
}
