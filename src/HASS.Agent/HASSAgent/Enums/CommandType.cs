using System.Runtime.Serialization;

namespace HASSAgent.Enums
{
    public enum CommandType
    {
        [EnumMember(Value = "CustomCommand")]
        CustomCommand,
        [EnumMember(Value = "CustomExecutorCommand")]
        CustomExecutorCommand,
        [EnumMember(Value = "HibernateCommand")]
        HibernateCommand,
        [EnumMember(Value = "KeyCommand")]
        KeyCommand,
        [EnumMember(Value = "LaunchUrlCommand")]
        LaunchUrlCommand,
        [EnumMember(Value = "LockCommand")]
        LockCommand,
        [EnumMember(Value = "LogOffCommand")]
        LogOffCommand,
        [EnumMember(Value = "MediaMuteCommand")]
        MediaMuteCommand,
        [EnumMember(Value = "MediaNextCommand")]
        MediaNextCommand,
        [EnumMember(Value = "MediaPlayPauseCommand")]
        MediaPlayPauseCommand,
        [EnumMember(Value = "MediaPreviousCommand")]
        MediaPreviousCommand,
        [EnumMember(Value = "MediaVolumeDownCommand")]
        MediaVolumeDownCommand,
        [EnumMember(Value = "MediaVolumeUpCommand")]
        MediaVolumeUpCommand,
        [EnumMember(Value = "PowershellCommand")]
        PowershellCommand,
        [EnumMember(Value = "PublishAllSensorsCommand")]
        PublishAllSensorsCommand,
        [EnumMember(Value = "RestartCommand")]
        RestartCommand,
        [EnumMember(Value = "ShutdownCommand")]
        ShutdownCommand,
        [EnumMember(Value = "SleepCommand")]
        SleepCommand
    }
}