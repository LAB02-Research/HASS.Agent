using Windows.Media.Control;
using HASS.Agent.Enums;
using HASS.Agent.Extensions;
using HASS.Agent.Managers;
using HASS.Agent.Shared.Enums;
using HASS.Agent.Shared.Extensions;
using Serilog;

namespace HASS.Agent.Media
{
    internal static class MediaManager
    {
        private static bool _monitoring = true;

        internal static MediaPlayerState State { get; private set; } = MediaPlayerState.Idle;
        internal static string Playing { get; private set; } = string.Empty;

        /// <summary>
        /// Initializes the media manager
        /// </summary>
        internal static void Initialize()
        {
            if (!Variables.AppSettings.MediaPlayerEnabled)
            {
                Log.Information("[MEDIA] Disabled");
                return;
            }

            if (!Variables.AppSettings.LocalApiEnabled)
            {
                Log.Warning("[MEDIA] Local API is disabled, unable to receive media requests");
                return;
            }

            // prepare the mediaplayer
            Variables.MediaPlayer.IsLoopingEnabled = false;
            Variables.MediaPlayer.AutoPlay = false;

            // start monitoring playing media
            Task.Run(MediaMonitor);

            // ready
            Log.Information("[MEDIA] Ready");
        }

        private static async void MediaMonitor()
        {
            var sessionManager = await GlobalSystemMediaTransportControlsSessionManager.RequestAsync();

            while (_monitoring)
            {
                try
                {
                    // get the current sessions
                    var sessions = sessionManager.GetSessions();
                    if (!sessions.Any()) continue;

                    GlobalSystemMediaTransportControlsSession session = null;

                    // if there's one session: pick that one
                    // if there are multiple: pick the first playing
                    // if none are playing: pick the first

                    if (sessions.Count == 1) session = sessions[0];
                    else if (sessions.Any(x =>
                                 x.GetPlaybackInfo().PlaybackStatus == GlobalSystemMediaTransportControlsSessionPlaybackStatus.Playing))
                    {
                        session = sessions.First(x =>
                            x.GetPlaybackInfo().PlaybackStatus == GlobalSystemMediaTransportControlsSessionPlaybackStatus.Playing);
                    }
                    else session = sessions[0];

                    // get the media properties
                    var mediaProperties = await session.TryGetMediaPropertiesAsync();

                    // create and set the playing title
                    var title = $"{mediaProperties.Artist} - {mediaProperties.Title}";
                    if (Playing != title)
                    {
                        Playing = title;
                        if (Variables.ExtendedLogging) Log.Information("[MEDIA] Now playing: {playing}", Playing);
                    }

                    // get and set the playback state
                    var state = session.GetPlaybackInfo().PlaybackStatus.ConvertToMediaPlayerState();
                    if (state != State)
                    {
                        State = state;
                        if (Variables.ExtendedLogging) Log.Information("[MEDIA] New state: {state}", State.ToString());
                    }

                    // done
                }
                catch (Exception ex)
                {
                    Log.Error("[MEDIA] Error while monitoring: {err}", ex.Message);
                }
                finally
                {
                    await Task.Delay(TimeSpan.FromSeconds(2));
                }
            }
        }

        /// <summary>
        /// Stops and disposes the mediaplayer
        /// </summary>
        internal static void Stop()
        {
            _monitoring = false;

            if (Variables.MediaPlayer.CurrentState == Windows.Media.Playback.MediaPlayerState.Playing) Variables.MediaPlayer.Pause();
            Variables.MediaPlayer.Dispose();
        }

        /// <summary>
        /// Returns the requested media-request value
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        internal static string ProcessRequest(MediaPlayerRequest request)
        {
            if (!Variables.AppSettings.MediaPlayerEnabled) return string.Empty;

            switch (request)
            {
                case MediaPlayerRequest.Unknown:
                    Log.Warning("[MEDIA] Unknown request received, dropped");
                    break;

                case MediaPlayerRequest.Muted:
                    Log.Debug("[MEDIA] Request received: MUTE");
                    return MediaManagerRequests.GetMuteState() ? "1" : "0";

                case MediaPlayerRequest.Volume:
                    Log.Debug("[MEDIA] Request received: VOLUME");
                    return MediaManagerRequests.GetVolume().ToString();

                case MediaPlayerRequest.Playing:
                    Log.Debug("[MEDIA] Request received: PLAYING");
                    return Playing;

                case MediaPlayerRequest.State:
                    Log.Debug("[MEDIA] Request received: STATE");
                    return State.GetEnumMemberValue();
            }

            return string.Empty;
        }

        /// <summary>
        /// Processes the provided media-command
        /// </summary>
        /// <param name="command"></param>
        internal static void ProcessCommand(MediaPlayerCommand command)
        {
            if (!Variables.AppSettings.MediaPlayerEnabled) return;

            try
            {
                switch (command)
                {
                    case MediaPlayerCommand.Unknown:
                        Log.Warning("[MEDIA] Unknown command received, dropped");
                        break;

                    case MediaPlayerCommand.VolumeUp:
                        if (Variables.ExtendedLogging) Log.Information("[MEDIA] Command received: VolumeUp");
                        MediaManagerCommands.VolumeUp();
                        break;

                    case MediaPlayerCommand.VolumeDown:
                        if (Variables.ExtendedLogging) Log.Information("[MEDIA] Command received: VolumeDown");
                        MediaManagerCommands.VolumeDown();
                        break;

                    case MediaPlayerCommand.Mute:
                        if (Variables.ExtendedLogging) Log.Information("[MEDIA] Command received: Mute");
                        MediaManagerCommands.Mute();
                        break;

                    case MediaPlayerCommand.Play:
                        if (Variables.ExtendedLogging) Log.Information("[MEDIA] Command received: Play");
                        MediaManagerCommands.Play();
                        break;

                    case MediaPlayerCommand.Pause:
                        if (Variables.ExtendedLogging) Log.Information("[MEDIA] Command received: Pause");
                        MediaManagerCommands.Pause();
                        break;

                    case MediaPlayerCommand.Stop:
                        if (Variables.ExtendedLogging) Log.Information("[MEDIA] Command received: Stop");
                        MediaManagerCommands.Stop();
                        break;

                    case MediaPlayerCommand.Next:
                        if (Variables.ExtendedLogging) Log.Information("[MEDIA] Command received: Next");
                        MediaManagerCommands.Next();
                        break;

                    case MediaPlayerCommand.Previous:
                        if (Variables.ExtendedLogging) Log.Information("[MEDIA] Command received: Previous");
                        MediaManagerCommands.Previous();
                        break;
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[MEDIA] Error processing command '{cmd}': {err}", command.ToString(), ex.Message);
            }
        }

        /// <summary>
        /// Downloads (in case of non-local file) and plays the media, stopping anything that might be playing
        /// </summary>
        /// <param name="mediaUri"></param>
        internal static async void ProcessMedia(string mediaUri)
        {
            if (!Variables.AppSettings.MediaPlayerEnabled) return;

            try
            {
                if (Variables.ExtendedLogging) Log.Information("[MEDIA] Received media: {com}", mediaUri);

                // prepare the localfile var
                var localFile = mediaUri;

                if (localFile.ToLower().StartsWith("http"))
                {
                    // remote file, try to download
                    var (success, downloadedLocalFile) = await StorageManager.DownloadAudioAsync(mediaUri);
                    if (!success)
                    {
                        Log.Error("[MEDIA] Unable to download media");
                        return;
                    }

                    // done
                    localFile = downloadedLocalFile;
                }

                // pause if we're playing
                if (Variables.MediaPlayer.CurrentState == Windows.Media.Playback.MediaPlayerState.Playing) Variables.MediaPlayer.Pause();

                // set the uri source
                Variables.MediaPlayer.SetUriSource(new Uri(localFile));

                if (Variables.ExtendedLogging) Log.Information("[MEDIAPLAYER] Playing: {file}", Path.GetFileName(localFile));

                // play it
                Variables.MediaPlayer.Play();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[MEDIA] Error playing media: {err}", ex.Message);
            }
        }
    }
}
