using System.Runtime.InteropServices;
using HASS.Agent.Functions;
using HASS.Agent.Shared.Enums;
using Microsoft.Win32;
using Serilog;

namespace HASS.Agent.Managers
{
    internal static class SystemStateManager
    {
        /// <summary>
        /// The pointer to unregister the monitor power notifications
        /// </summary>
        internal static IntPtr UnRegPowerNotify { get; set; } = IntPtr.Zero;
        
        /// <summary>
        /// Notes the last time something happened to the system's state, eg. user logged on, session locked, etc
        /// </summary>
        internal static DateTime LastSystemStateChange { get; private set; } = DateTime.Now;

        /// <summary>
        /// Contains the last event that happened to the system, eg. user logged on, session locked, etc
        /// </summary>
        internal static SystemStateEvent LastSystemStateEvent { get; private set; } = SystemStateEvent.ApplicationStarted;

        /// <summary>
        /// Contains the last event that happened to the monitors, eg. power on
        /// </summary>
        internal static MonitorPowerEvent LastMonitorPowerEvent { get; private set; } = MonitorPowerEvent.Unknown;

        /// <summary>
        /// Initializes the systemstate manager and binds to Windows' event announcements
        /// </summary>
        internal static async void Initialize()
        {
            await Task.Run(Monitor);
        }

        /// <summary>
        /// Neatly closes all event handlers
        /// </summary>
        internal static void Stop()
        {
            // unbind all events
            SystemEvents.SessionEnded -= SystemEventsOnSessionEnded;
            SystemEvents.SessionEnding -= SystemEventsOnSessionEnding;
            SystemEvents.PowerModeChanged -= SystemEventsOnPowerModeChanged;
            SystemEvents.SessionSwitch -= SystemEventsOnSessionSwitch;

            // unregister monitor power notifications
            NativeMethods.UnregisterPowerSettingNotification(UnRegPowerNotify);
        }

        /// <summary>
        /// Process a session ending (checks for shutdown, otherwise asumes logoff)
        /// </summary>
        internal static void ProcessSessionEnd()
        {
            try
            {
                // announce offline as fast as possible
                Task.Run(() => Variables.MqttManager.AnnounceAvailabilityAsync(true));

                var shutdownPending = NativeMethods.GetSystemMetrics(NativeMethods.SM_SHUTTINGDOWN) != 0;
                if (shutdownPending)
                {
                    Log.Information("[SYSTEMSTATE] Session ending: system shutting down");
                    Task.Run(() => HelperFunctions.ShutdownAsync(TimeSpan.Zero));
                    LastSystemStateEvent = SystemStateEvent.SystemShutdown;
                    
                }
                else
                {
                    Log.Information("[SYSTEMSTATE] Session ending: logging off");
                    Task.Run(() => HelperFunctions.ShutdownAsync(TimeSpan.Zero));
                    LastSystemStateEvent = SystemStateEvent.Logoff;
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SYSTEMSTATE] Error while processing session end: {err}", ex.Message);
            }
        }

        /// <summary>
        /// Process a changed monitor powerstate
        /// </summary>
        /// <param name="m"></param>
        internal static void ProcessMonitorPowerChange(Message m)
        {
            try
            {
                if (m.WParam != (IntPtr)NativeMethods.PBT_POWERSETTINGCHANGE) return;

                var settings = (NativeMethods.POWERBROADCAST_SETTING)m.GetLParam(typeof(NativeMethods.POWERBROADCAST_SETTING))!;
                LastMonitorPowerEvent = settings.Data switch
                {
                    0 => MonitorPowerEvent.PowerOff,
                    1 => MonitorPowerEvent.PowerOn,
                    2 => MonitorPowerEvent.Dimmed,
                    _ => MonitorPowerEvent.Unknown
                };
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SYSTEMSTATE] Error while processing monitor power change: {err}", ex.Message);
            }
            finally
            {
                m.Result = (IntPtr)1;
            }
        }

        /// <summary>
        /// Hooks onto system events and acts accordingly
        /// </summary>
        private static void Monitor()
        {
            try
            {
                LastSystemStateChange = DateTime.Now;

                // bind all events
                SystemEvents.SessionEnded += SystemEventsOnSessionEnded;
                SystemEvents.SessionEnding += SystemEventsOnSessionEnding;
                SystemEvents.PowerModeChanged += SystemEventsOnPowerModeChanged;
                SystemEvents.SessionSwitch += SystemEventsOnSessionSwitch;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SYSTEMSTATE] Error while processing change: {err}", ex.Message);
            }
        }

        private static void SystemEventsOnSessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            // something changed to the session (eg. local or remote login, logout, etc)
            switch (e.Reason)
            {
                case SessionSwitchReason.ConsoleConnect:
                    LastSystemStateEvent = SystemStateEvent.ConsoleConnect;
                    break;

                case SessionSwitchReason.ConsoleDisconnect:
                    LastSystemStateEvent = SystemStateEvent.ConsoleDisconnect;
                    break;

                case SessionSwitchReason.RemoteConnect:
                    LastSystemStateEvent = SystemStateEvent.RemoteConnect;
                    break;

                case SessionSwitchReason.RemoteDisconnect:
                    LastSystemStateEvent = SystemStateEvent.RemoteDisconnect;
                    break;

                case SessionSwitchReason.SessionLock:
                    LastSystemStateEvent = SystemStateEvent.SessionLock;
                    break;

                case SessionSwitchReason.SessionLogoff:
                    LastSystemStateEvent = SystemStateEvent.SessionLogoff;
                    break;

                case SessionSwitchReason.SessionLogon:
                    LastSystemStateEvent = SystemStateEvent.SessionLogon;
                    break;

                case SessionSwitchReason.SessionRemoteControl:
                    LastSystemStateEvent = SystemStateEvent.SessionRemoteControl;
                    break;

                case SessionSwitchReason.SessionUnlock:
                    LastSystemStateEvent = SystemStateEvent.SessionUnlock;
                    break;
            }
        }

        private static void SystemEventsOnPowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            // we're either going to sleep/hibernation or coming out of it
            // if we're going under, process as fast as possible because we don't know how/when we're coming out of it
            switch (e.Mode)
            {
                case PowerModes.Resume:
                    Log.Information("[SYSTEMSTATE] Session resuming");
                    Task.Run(() => Variables.MqttManager.AnnounceAvailabilityAsync());
                    LastSystemStateEvent = SystemStateEvent.Resume;
                    break;

                case PowerModes.Suspend:
                    // announce offline as fast as possible
                    Task.Run(() => Variables.MqttManager.AnnounceAvailabilityAsync(true));

                    Log.Information("[SYSTEMSTATE] Session halting: system suspending");
                    Task.Run(() => Variables.MqttManager.AnnounceAvailabilityAsync(true));
                    LastSystemStateEvent = SystemStateEvent.Suspend;
                    break;
            }
        }

        private static void SystemEventsOnSessionEnding(object sender, SessionEndingEventArgs e)
        {
            // this means our session is ending, process as fast as possible
            Task.Run(() => Variables.MqttManager.AnnounceAvailabilityAsync(true));

            switch (e.Reason)
            {
                case SessionEndReasons.Logoff:
                    Log.Information("[SYSTEMSTATE] Session ending: logging off");
                    Task.Run(() => HelperFunctions.ShutdownAsync(TimeSpan.Zero));
                    LastSystemStateEvent = SystemStateEvent.Logoff;
                    break;

                case SessionEndReasons.SystemShutdown:
                    Log.Information("[SYSTEMSTATE] Session ending: system shutting down");
                    Task.Run(() => HelperFunctions.ShutdownAsync(TimeSpan.Zero));
                    LastSystemStateEvent = SystemStateEvent.SystemShutdown;
                    break;
            }
        }

        private static void SystemEventsOnSessionEnded(object sender, SessionEndedEventArgs e)
        {
            // this means our session has ended, process as fast as possible
            Task.Run(() => Variables.MqttManager.AnnounceAvailabilityAsync(true));

            switch (e.Reason)
            {
                case SessionEndReasons.Logoff:
                    Log.Information("[SYSTEMSTATE] Session ending: logging off");
                    Task.Run(() => HelperFunctions.ShutdownAsync(TimeSpan.Zero));
                    LastSystemStateEvent = SystemStateEvent.Logoff;
                    break;

                case SessionEndReasons.SystemShutdown:
                    Log.Information("[SYSTEMSTATE] Session ending: system shutting down");
                    Task.Run(() => HelperFunctions.ShutdownAsync(TimeSpan.Zero));
                    LastSystemStateEvent = SystemStateEvent.SystemShutdown;
                    break;
            }
        }
    }
}
