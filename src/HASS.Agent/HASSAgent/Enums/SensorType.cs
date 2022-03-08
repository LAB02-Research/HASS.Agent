using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace HASSAgent.Enums
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public enum SensorType
    {
        [EnumMember(Value = "ActiveWindowSensor")]
        ActiveWindowSensor,

        [EnumMember(Value = "AudioSensors")]
        AudioSensors,

        [EnumMember(Value = "BatterySensors")]
        BatterySensors,

        [EnumMember(Value = "CpuLoadSensor")]
        CpuLoadSensor,

        [EnumMember(Value = "CurrentClockSpeedSensor")]
        CurrentClockSpeedSensor,

        [EnumMember(Value = "CurrentVolumeSensor")]
        CurrentVolumeSensor,

        [EnumMember(Value = "DisplaySensors")]
        DisplaySensors,

        [EnumMember(Value = "DummySensor")]
        DummySensor,

        [EnumMember(Value = "GpuLoadSensor")]
        GpuLoadSensor,

        [EnumMember(Value = "GpuTemperatureSensor")]
        GpuTemperatureSensor,

        [EnumMember(Value = "LastActiveSensor")]
        LastActiveSensor,

        [EnumMember(Value = "LastBootSensor")]
        LastBootSensor,

        [EnumMember(Value = "LastSystemStateChangeSensor")]
        LastSystemStateChangeSensor,

        [EnumMember(Value = "LoggedUserSensor")]
        LoggedUserSensor,

        [EnumMember(Value = "LoggedUsersSensor")]
        LoggedUsersSensor,

        [EnumMember(Value = "MemoryUsageSensor")]
        MemoryUsageSensor,

        [EnumMember(Value = "MicrophoneActiveSensor")]
        MicrophoneActiveSensor,

        [EnumMember(Value = "NamedWindowSensor")]
        NamedWindowSensor,

        [EnumMember(Value = "NetworkSensors")]
        NetworkSensors,

        [EnumMember(Value = "PerformanceCounterSensor")]
        PerformanceCounterSensor,

        [EnumMember(Value = "ProcessActiveSensor")]
        ProcessActiveSensor,

        [EnumMember(Value = "ServiceStateSensor")]
        ServiceStateSensor,

        [EnumMember(Value = "SessionStateSensor")]
        SessionStateSensor,

        [EnumMember(Value = "StorageSensors")]
        StorageSensors,

        [EnumMember(Value = "UserNotificationStateSensor")]
        UserNotificationStateSensor,

        [EnumMember(Value = "WebcamActiveSensor")]
        WebcamActiveSensor,

        [EnumMember(Value = "WindowsUpdatesSensors")]
        WindowsUpdatesSensors,

        [EnumMember(Value = "WmiQuerySensor")]
        WmiQuerySensor
    }
}