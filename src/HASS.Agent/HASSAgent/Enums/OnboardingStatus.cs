using System.Diagnostics.CodeAnalysis;

namespace HASSAgent.Enums
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public enum OnboardingStatus
    {
        NeverDone,
        Aborted,
        ScheduledTask,
        Notifications,
        Integration,
        API,
        MQTT,
        HotKey,
        Updates,
        Completed
    }
}