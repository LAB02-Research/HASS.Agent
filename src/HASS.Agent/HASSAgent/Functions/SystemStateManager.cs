using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using HASSAgent.Enums;
using HASSAgent.Mqtt;
using Microsoft.Win32;
using Serilog;

namespace HASSAgent.Functions
{
    internal static class SystemStateManager
    {
        private static int SM_SHUTTINGDOWN = 0x2000;

        [DllImport("user32.dll")]
        private static extern int GetSystemMetrics(int smIndex);

        /// <summary>
        /// Notes the last time something happened to the system's state, ie. user logged on, session locked, etc
        /// </summary>
        internal static DateTime LastSystemStateChange { get; private set; } = DateTime.Now;

        /// <summary>
        /// Contains the last event that happened to the system, ie. user logged on, session locked, etc
        /// </summary>
        internal static SystemStateEvent LastSystemStateEvent { get; private set; } = SystemStateEvent.HassAgentStarted;

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
                Task.Run(() => MqttManager.AnnounceAvailabilityAsync(true));

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

        private static void Monitor()
        {
            try
            {
                LastSystemStateChange = DateTime.Now;

                SystemEvents.SessionEnded += delegate(object sender, SessionEndedEventArgs e)
                {
                    // this means our session has ended, process as fast as possible
                    Task.Run(() => MqttManager.AnnounceAvailabilityAsync(true));

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

                SystemEvents.SessionEnding += delegate (object sender, SessionEndingEventArgs e)
                {
                    // this means our session is ending, process as fast as possible
                    Task.Run(() => MqttManager.AnnounceAvailabilityAsync(true));

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

                SystemEvents.PowerModeChanged += delegate (object sender, PowerModeChangedEventArgs e)
                {
                    // we're either going to sleep/hibernation or coming out of it
                    // if we're going under, process as fast as possible because we don't know how/when we're coming out of it
                    switch (e.Mode)
                    {
                        case PowerModes.Resume:
                            Log.Information("[SYSTEMSTATE] Session resuming");
                            Task.Run(() => MqttManager.AnnounceAvailabilityAsync());
                            LastSystemStateEvent = SystemStateEvent.Resume;
                            break;

                        case PowerModes.Suspend:
                            // announce offline as fast as possible
                            Task.Run(() => MqttManager.AnnounceAvailabilityAsync(true));

                            Log.Information("[SYSTEMSTATE] Session halting: system suspending");
                            Task.Run(() => MqttManager.AnnounceAvailabilityAsync(true));
                            LastSystemStateEvent = SystemStateEvent.Suspend;
                            break;
                    }
                };

                SystemEvents.SessionSwitch += delegate (object sender, SessionSwitchEventArgs e)
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
