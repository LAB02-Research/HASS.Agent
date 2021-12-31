using System.Runtime.Serialization;

namespace HASSAgent.Enums
{
    public enum CommandType
    {
        [EnumMember(Value = "ShutdownCommand")]
        ShutdownCommand,
        [EnumMember(Value = "RestartCommand")]
        RestartCommand,
        [EnumMember(Value = "LogOffCommand")]
        LogOffCommand,
        [EnumMember(Value = "LockCommand")]
        LockCommand,
        [EnumMember(Value = "CustomCommand")]
        CustomCommand,
        [EnumMember(Value = "MediaPlayPauseCommand")]
        MediaPlayPauseCommand,
        [EnumMember(Value = "MediaNextCommand")]
        MediaNextCommand,
        [EnumMember(Value = "MediaPreviousCommand")]
        MediaPreviousCommand,
        [EnumMember(Value = "MediaVolumeUpCommand")]
        MediaVolumeUpCommand,
        [EnumMember(Value = "MediaVolumeDownCommand")]
        MediaVolumeDownCommand,
        [EnumMember(Value = "MediaMuteCommand")]
        MediaMuteCommand,
        [EnumMember(Value = "KeyCommand")]
        KeyCommand
    }
}