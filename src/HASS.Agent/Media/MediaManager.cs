using System.IO;
using System.Text.Json;
using Windows.Media.Control;
using Windows.Media.Playback;
using CoreAudio;
using HASS.Agent.Enums;
using HASS.Agent.Extensions;
using HASS.Agent.Managers;
using HASS.Agent.Models.HomeAssistant;
using HASS.Agent.MQTT;
using HASS.Agent.Shared.Extensions;
using MQTTnet;
using Serilog;
using MediaPlayerState = HASS.Agent.Enums.MediaPlayerState;
using Octokit;

namespace HASS.Agent.Media
{
    internal static class MediaManager
    {
        private static bool _monitoring = true;
        private static bool _mediaActive = true;

        private static string _lastError = string.Empty;

        private static GlobalSystemMediaTransportControlsSessionManager _sessionManager;

        internal static MediaPlayerState State { get; private set; } = MediaPlayerState.Idle;
        internal static string Playing { get; private set; } = string.Empty;

        /// <summary>
        /// Initializes the media manager
        /// </summary>
        internal static async Task InitializeAsync()
        {
            if (!Variables.AppSettings.MediaPlayerEnabled)
            {
                Log.Information("[MEDIA] Disabled");
                return;
            }
            
            if (!Variables.AppSettings.LocalApiEnabled && !Variables.AppSettings.MqttEnabled)
            {
                Log.Warning("[MEDIA] Both local API and MQTT are disabled, unable to receive media requests");
                return;
            }

            // try to initialize and prepare Windows' mediaplayer platform
            // todo: optional, but add an OS check - not all OSs support this
            try
            {
                // create the objects
                Variables.AudioDeviceEnumerator = new MMDeviceEnumerator();
                Variables.MediaPlayer = new MediaPlayer();

                _sessionManager = await GlobalSystemMediaTransportControlsSessionManager.RequestAsync();

                // prepare the mediaplayer
                Variables.MediaPlayer.IsLoopingEnabled = false;
                Variables.MediaPlayer.AutoPlay = false;

                Variables.MediaPlayer.MediaFailed += MediaPlayerOnMediaFailed;
            }
            catch (TypeInitializationException ex)
            {
                Log.Error("[MEDIA] Unable to initialize, your OS doesn't seem to be supported or isn't fully updated:\r\n{err}", ex.Message);
                Variables.AppSettings.MediaPlayerEnabled = false;

                Log.Warning("[MEDIA] Failed, disabled");
                return;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[MEDIA] Unable to initialize: {err}" , ex.Message);
                Variables.AppSettings.MediaPlayerEnabled = false;

                Log.Warning("[MEDIA] Failed, disabled");
                return;
            }

            // start monitoring playing media
            _ = Task.Run(MediaMonitor);
            
            if (!Variables.AppSettings.MqttEnabled) Log.Warning("[MEDIA] MQTT is disabled, only basic media functionality will work");
            else
            {
                // subscribe to commands
                _ = Task.Run(Variables.MqttManager.SubscribeMediaCommandsAsync);
            }

            // ready
            Log.Information("[MEDIA] Ready");
        }

        private static async void MediaMonitor()
        {
            while (_monitoring)
            {
                var message = new MqttMediaPlayerMessage();

                try
                {
                    var session = GetCurrentMediaSession();
                    if (session == null)
                    {
                        // no session found, optionally log
                        if (_mediaActive)
                        {
                            _mediaActive = false;
                            if (Variables.ExtendedLogging) Log.Warning("[MEDIA] No MediaSession active");
                        }

                        // done
                        continue;
                    }

                    // new session?
                    if (!_mediaActive)
                    {
                        // yep, optionally log
                        _mediaActive = true;
                        if (Variables.ExtendedLogging) Log.Warning("[MEDIA] New MediaSession active");
                    }

                    // get the media properties
                    var mediaProperties = await session.TryGetMediaPropertiesAsync();
                    if (mediaProperties == null)
                    {
                        // nothing to do
                        if (Variables.ExtendedLogging) Log.Warning("[MEDIA] Null object received when requesting MediaProperties");
                        continue;
                    }

                    // create and set the playing title
                    var title = $"{mediaProperties.Artist} - {mediaProperties.Title}";
                    if (Playing != title)
                    {
                        Playing = title;
                        if (Variables.ExtendedLogging) Log.Information("[MEDIA] Now playing: {playing}", Playing);

                        // optionally publish the thumbnail
                        if (Variables.AppSettings.MqttEnabled)
                        {
                            if (mediaProperties.Thumbnail != null)
                            {
                                using var reference = await mediaProperties.Thumbnail.OpenReadAsync();
                                await using var stream = reference.AsStreamForRead();

                                var haMessageBuilder = new MqttApplicationMessageBuilder()
                                    .WithTopic($"hass.agent/media_player/{Variables.DeviceConfig.Name}/thumbnail")
                                    .WithPayload(stream)
                                    .WithRetainFlag();

                                await Variables.MqttManager.PublishAsync(haMessageBuilder.Build());
                            }
                            else
                            {
                                var haMessageBuilder = new MqttApplicationMessageBuilder()
                                    .WithTopic($"hass.agent/media_player/{Variables.DeviceConfig.Name}/thumbnail")
                                    .WithPayload(Array.Empty<byte>())
                                    .WithRetainFlag();

                                await Variables.MqttManager.PublishAsync(haMessageBuilder.Build());
                            }
                        }
                    }

                    // get and set the playback state
                    var state = MediaPlayerState.Idle;
                    var playbackInfo = session.GetPlaybackInfo();
                    if (playbackInfo != null)
                    {
                        state = playbackInfo.PlaybackStatus.ConvertToMediaPlayerState();
                        if (state != State)
                        {
                            State = state;
                            if (Variables.ExtendedLogging) Log.Information("[MEDIA] New state: {state}", State.ToString());
                        }
                    }
                    else
                    {
                        if (Variables.ExtendedLogging) Log.Warning("[MEDIA] Null object received when requesting PlaybackInfo");
                    }

                    // rest is only relevant for mqtt
                    if (!Variables.AppSettings.MqttEnabled) continue;

                    // set info
                    message.State = state;
                    message.Title = mediaProperties.Title;
                    message.Artist = mediaProperties.Artist;
                    message.AlbumArtist = mediaProperties.AlbumArtist;
                    message.AlbumTitle = mediaProperties.AlbumTitle;
                    message.Volume = MediaManagerRequests.GetVolume();
                    
                    // get timeline info
                    var timeline = session.GetTimelineProperties();
                    if (timeline != null)
                    {
                        message.Duration = timeline.StartTime.Add(timeline.EndTime).TotalSeconds;
                        message.CurrentPosition = timeline.Position.TotalSeconds;
                    }
                    else
                    {
                        if (Variables.ExtendedLogging) Log.Warning("[MEDIA] Null object received when requesting TimeLineProperties");
                    }

                    // done
                    _lastError = string.Empty;
                }
                catch (Exception ex)
                {
                    if (ex.Message != _lastError)
                    {
                        _lastError = ex.Message;
                        Log.Error("[MEDIA] Error while monitoring: {err}", ex.Message);
                    }
                }
                finally
                {
                    // publish our state
                    if (Variables.AppSettings.MqttEnabled)
                    {
                        var haMessageBuilder = new MqttApplicationMessageBuilder()
                            .WithTopic($"hass.agent/media_player/{Variables.DeviceConfig.Name}/state")
                            .WithPayload(JsonSerializer.Serialize(message, MqttManager.JsonSerializerOptions));
                        await Variables.MqttManager.PublishAsync(haMessageBuilder.Build());
                    }

                    // wait a bit
                    await Task.Delay(TimeSpan.FromSeconds(2));
                }
            }
        }

        private static GlobalSystemMediaTransportControlsSession GetCurrentMediaSession()
        {
            // get the current sessions
            var sessions = _sessionManager.GetSessions();
            if (!sessions.Any()) return null;

            // if there's one session: pick that one
            // if there are multiple: pick the first playing
            // if none are playing: pick the first

            if (sessions.Count == 1) return sessions[0];
            
            return sessions.Any(x => x.GetPlaybackInfo().PlaybackStatus == GlobalSystemMediaTransportControlsSessionPlaybackStatus.Playing) 
                ? sessions.First(x => x.GetPlaybackInfo().PlaybackStatus == GlobalSystemMediaTransportControlsSessionPlaybackStatus.Playing) 
                : sessions[0];
        }

        /// <summary>
        /// Stops and disposes the mediaplayer
        /// </summary>
        internal static void Stop()
        {
            _monitoring = false;
            Variables.AppSettings.MediaPlayerEnabled = false;

            if (Variables.MediaPlayer == null) return;

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

                    case MediaPlayerCommand.SetVolume:
                        if (Variables.ExtendedLogging) Log.Information("[MEDIA] Command received: SetVolume");
                        // not implemented through the API
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

                if (Variables.ExtendedLogging) Log.Information("[MEDIA] Playing: {file}", Path.GetFileName(localFile));

                // play it
                Variables.MediaPlayer.Play();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[MEDIA] Error playing media: {err}", ex.Message);
            }
        }

        /// <summary>
        /// Attempt to change playback position to the requested value
        /// </summary>
        /// <param name="position"></param>
        internal static async void ProcessSeekCommand(long position)
        {
            try
            {
                var session = GetCurrentMediaSession();
                await session.TryChangePlaybackPositionAsync(position);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[MEDIA] Error processing seek: {err}", ex.Message);
            }
        }

        private static void MediaPlayerOnMediaFailed(MediaPlayer sender, MediaPlayerFailedEventArgs args)
        {
            try
            {
                Log.Fatal(args.ExtendedErrorCode, "[MEDIA] [{code}] Error playing media: {err}", args.Error.ToString(), args.ErrorMessage);
            }
            catch
            {
                // best effort
            }
        }
    }
}
