namespace HASSAgent.Models.HomeAssistant.Commands.KeyCommands
{
    internal class MediaPlayPauseCommand : KeyCommand
    {
        internal MediaPlayPauseCommand(string name = "PlayPause", string id = default) : base(VK_MEDIA_PLAY_PAUSE, name ?? "PlayPause", id) { }
    }
}
