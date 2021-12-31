namespace HASSAgent.Models.HomeAssistant.Commands.KeyCommands
{
    internal class MediaVolumeUpCommand : KeyCommand
    {
        internal MediaVolumeUpCommand(string name = "VolumeUp", string id = default) : base(VK_VOLUME_UP, name ?? "VolumeUp", id) { }
    }
}
