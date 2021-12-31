namespace HASSAgent.Models.HomeAssistant.Commands.KeyCommands
{
    internal class MediaVolumeDownCommand : KeyCommand
    {
        internal MediaVolumeDownCommand(string name = "VolumeDown", string id = default) : base(VK_VOLUME_DOWN, name ?? "VolumeDown", id) { }
    }
}
