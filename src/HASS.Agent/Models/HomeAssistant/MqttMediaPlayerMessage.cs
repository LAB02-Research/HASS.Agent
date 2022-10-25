using HASS.Agent.Enums;

namespace HASS.Agent.Models.HomeAssistant;

public class MqttMediaPlayerMessage
{
    public string Title { get; set; }
    public string Artist { get; set; }
    public string AlbumTitle { get; set; }
    public string AlbumArtist { get; set; }

    public double Duration { get; set; }
    public double CurrentPosition { get; set; }
    public MediaPlayerState State { get; set; }
    public int Volume { get; set; }
    public bool Muted { get; set; }
}