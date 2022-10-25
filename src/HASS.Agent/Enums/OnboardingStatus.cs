using System.Diagnostics.CodeAnalysis;

namespace HASS.Agent.Enums
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public enum OnboardingStatus
    {
        NeverDone = 0,
        Aborted = 1,
        Startup = 2,
        API = 3,
        MQTT = 4,
        Integrations = 5,
        HotKey = 6,
        Updates = 7,
        Completed = 9
    }
}