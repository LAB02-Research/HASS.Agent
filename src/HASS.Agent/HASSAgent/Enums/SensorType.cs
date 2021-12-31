using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace HASSAgent.Enums
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public enum SensorType
    {
        [EnumMember(Value = "UserNotificationStateSensor")]
        UserNotificationStateSensor,
        [EnumMember(Value = "DummySensor")]
        DummySensor,
        [EnumMember(Value = "CurrentClockSpeedSensor")]
        CurrentClockSpeedSensor,
        [EnumMember(Value = "CpuLoadSensor")]
        CpuLoadSensor,
        [EnumMember(Value = "MemoryUsageSensor")]
        MemoryUsageSensor,
        [EnumMember(Value = "ActiveWindowSensor")]
        ActiveWindowSensor,
        [EnumMember(Value = "NamedWindowSensor")]
        NamedWindowSensor,
        [EnumMember(Value = "LastActiveSensor")]
        LastActiveSensor,
        [EnumMember(Value = "LastBootSensor")]
        LastBootSensor,
        [EnumMember(Value = "WebcamActiveSensor")]
        WebcamActiveSensor,
        [EnumMember(Value = "MicrophoneActiveSensor")]
        MicrophoneActiveSensor,
        [EnumMember(Value = "SessionStateSensor")]
        SessionStateSensor,
        [EnumMember(Value = "CurrentVolumeSensor")]
        CurrentVolumeSensor,
        [EnumMember(Value = "GpuLoadSensor")]
        GpuLoadSensor,
        [EnumMember(Value = "GpuTemperatureSensor")]
        GpuTemperatureSensor,
        [EnumMember(Value = "WmiQuerySensor")]
        WmiQuerySensor,
        [EnumMember(Value = "StorageSensors")]
        StorageSensors,
        [EnumMember(Value = "NetworkSensors")]
        NetworkSensors
    }
}