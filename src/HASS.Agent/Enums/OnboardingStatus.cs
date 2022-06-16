using System.Diagnostics.CodeAnalysis;

namespace HASS.Agent.Enums
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public enum OnboardingStatus
    {
        NeverDone,
        Aborted,
        Startup,
        LocalApi,
        Integrations,
        API,
        MQTT,
        HotKey,
        Updates,
        Completed
    }
}