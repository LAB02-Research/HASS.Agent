using System.Runtime.InteropServices;
using HASS.Agent.Shared.Enums;
using Microsoft.Win32;
using Serilog;

namespace HASS.Agent.Functions
{
    internal static class SystemStateManager
    {
        // ReSharper disable once InconsistentNaming
        private const int SM_SHUTTINGDOWN = 0x2000;

        [DllImport("user32.dll")]
        private static extern int GetSystemMetrics(int smIndex);

        /// <summary>
        /// Notes the last time something happened to the system's state, ie. user logged on, session locked, etc
        /// </summary>
        internal static DateTime LastSystemStateChange { get; private set; } = DateTime.Now;

        /// <summary>
        /// Contains the last event that happened to the system, ie. user logged on, session locked, etc
        /// </summary>
        internal static SystemStateEvent LastSystemStateEvent { get; private set; } = SystemStateEvent.ApplicationStarted;

        /// <summary>
        /// Initializes the systemstate manager and binds to Windows' event announcements
        /// </summary>
        internal static async void Initialize()
        {
            await Task.Run(Monitor);
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

                var shutdownPending = GetSystemMetrics(SM_SHUTTINGDOWN) != 0;
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
        /// Hooks onto system events and acts accordingly
        /// </summary>
        private static void Monitor()
        {
            try
            {
                LastSystemStateChange = DateTime.Now;

                SystemEvents.SessionEnded += delegate(object _, SessionEndedEventArgs e)
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
                };

                SystemEvents.SessionEnding += delegate (object _, SessionEndingEventArgs e)
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
                };

                SystemEvents.PowerModeChanged += delegate (object _, PowerModeChangedEventArgs e)
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
                };

                SystemEvents.SessionSwitch += delegate (object _, SessionSwitchEventArgs e)
                {
                    // something changed to the session (ie. local or remote login, logout, etc)
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
                };
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SYSTEMSTATE] Error while processing change: {err}", ex.Message);
            }
        }
    }
}
