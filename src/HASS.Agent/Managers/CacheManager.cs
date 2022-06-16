using HASS.Agent.Settings;
using Serilog;

namespace HASS.Agent.Managers
{
    internal static class CacheManager
    {
        private static bool _imageCacheCleanerActive = true;
        private static bool _audioCacheCleanerActive = true;
        private static bool _webViewCacheCleanerActive = true;

        /// <summary>
        /// Initializes the cache manager, which periodically clears all caches based on their retention policy
        /// </summary>
        internal static void Initialize()
        {
            // rmeove the legacy 'temp' folder if it's there
            var legacyTempFolder = Path.Combine(Variables.StartupPath, "Temp");
            if (Directory.Exists(legacyTempFolder)) _ = Task.Run(() => StorageManager.DeleteDirectoryAsync(legacyTempFolder));

            // start the periodic cleaners
            Task.Run(StartPeriodicCleaners);
        }

        private static async void StartPeriodicCleaners()
        {
            // start periodic image cache cleaner
            _ = Task.Run(PeriodicImageCacheCleaner);

            // wait 15 min to spread io actions
            await Task.Delay(TimeSpan.FromMinutes(15));

            // start periodic audio cache cleaner
            _ = Task.Run(PeriodicAudioCacheCleaner);

            // wait 15 min to spread io actions
            await Task.Delay(TimeSpan.FromMinutes(15));

            // start periodic webview cache cleaner
            _ = Task.Run(PeriodicWebViewCacheCleaner);
        }

        /// <summary>
        /// Completely clears the image cache, ignoring the retention days
        /// </summary>
        /// <returns></returns>
        internal static async Task ClearImageCacheAsync()
        {
            try
            {
                // pause the periodic cleaner
                _imageCacheCleanerActive = true;

                // folder still there?
                if (!Directory.Exists(Variables.ImageCachePath)) return;

                // enumerate all files
                var imageFiles = Directory.EnumerateFiles(Variables.ImageCachePath, "*.*", SearchOption.TopDirectoryOnly).ToArray();

                // delete them
                foreach (var imageFile in imageFiles) await StorageManager.DeleteFileAsync(imageFile);

                // done
                Log.Information("[CACHE] Clear cache: {count} images removed", imageFiles.Length);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[CACHE] Error while cleaning image cache: {err}", ex.Message);
            }
            finally
            {
                _imageCacheCleanerActive = true;
            }
        }

        /// <summary>
        /// Completely clears the audio cache, ignoring the retention days
        /// </summary>
        /// <returns></returns>
        internal static async Task ClearAudioCacheAsync()
        {
            try
            {
                // pause the periodic cleaner
                _audioCacheCleanerActive = true;

                // folder still there?
                if (!Directory.Exists(Variables.AudioCachePath)) return;

                // enumerate all files
                var audioFiles = Directory.EnumerateFiles(Variables.AudioCachePath, "*.*", SearchOption.TopDirectoryOnly).ToArray();

                // delete them
                foreach (var audioFile in audioFiles) await StorageManager.DeleteFileAsync(audioFile);

                // done
                Log.Information("[CACHE] Clear cache: {count} audio files removed", audioFiles.Length);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[CACHE] Error while cleaning audio cache: {err}", ex.Message);
            }
            finally
            {
                _audioCacheCleanerActive = true;
            }
        }

        /// <summary>
        /// Completely clears the webview cache, ignoring the retention days
        /// </summary>
        /// <returns></returns>
        internal static async Task ClearWebViewCacheAsync()
        {
            try
            {
                // pause the periodic cleaner
                _webViewCacheCleanerActive = true;

                // folder still there?
                if (!Directory.Exists(Variables.WebViewCachePath)) return;

                // clear the directory
                var (success, dirsDeleted, filesDeleted) = await StorageManager.ClearDirectoryAsync(Variables.WebViewCachePath);

                if (!success)
                {
                    Log.Error("[CACHE] Clear cache: webview cache removal failed");
                    return;
                }

                // done
                Log.Information("[CACHE] Clear cache: {dirs} webview cache directories and {files} files removed", dirsDeleted, filesDeleted);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[CACHE] Error while cleaning webview cache: {err}", ex.Message);
            }
            finally
            {
                _webViewCacheCleanerActive = true;
            }
        }

        private static async void PeriodicImageCacheCleaner()
        {
            while (!Variables.ShuttingDown)
            {
                try
                {
                    // wait an hour
                    await Task.Delay(TimeSpan.FromHours(1));

                    // shutting down?
                    if (Variables.ShuttingDown) return;

                    // check if we're active
                    if (!_imageCacheCleanerActive) continue;

                    // check if we need to clean
                    if (Variables.AppSettings.ImageCacheRetentionDays <= 0) continue;

                    // folder still there?
                    if (!Directory.Exists(Variables.ImageCachePath)) continue;

                    // enumerate all files
                    var imageFiles = Directory.EnumerateFiles(Variables.ImageCachePath, "*.*", SearchOption.TopDirectoryOnly).ToArray();
                    var now = DateTime.Now;
                    foreach (var imageFile in imageFiles)
                    {
                        // get & check file age
                        var fileInfo = new FileInfo(imageFile);
                        if ((now - fileInfo.CreationTime).TotalDays < Variables.AppSettings.ImageCacheRetentionDays) continue;

                        // too old, remove
                        await StorageManager.DeleteFileAsync(imageFile);
                    }
                }
                catch (Exception ex)
                {
                    Log.Fatal("[CACHE] Error while periodically cleaning image cache: {err}", ex.Message);
                }
            }
        }

        private static async void PeriodicAudioCacheCleaner()
        {
            while (!Variables.ShuttingDown)
            {
                try
                {
                    // wait an hour
                    await Task.Delay(TimeSpan.FromHours(1));

                    // shutting down?
                    if (Variables.ShuttingDown) return;

                    // check if we're active
                    if (!_audioCacheCleanerActive) continue;

                    // check if we need to clean
                    if (Variables.AppSettings.AudioCacheRetentionDays <= 0) continue;

                    // folder still there?
                    if (!Directory.Exists(Variables.AudioCachePath)) continue;

                    // enumerate all files
                    var audioFiles = Directory.EnumerateFiles(Variables.AudioCachePath, "*.*", SearchOption.TopDirectoryOnly).ToArray();
                    var now = DateTime.Now;
                    foreach (var audioFile in audioFiles)
                    {
                        // get & check file age
                        var fileInfo = new FileInfo(audioFile);
                        if ((now - fileInfo.CreationTime).TotalDays < Variables.AppSettings.AudioCacheRetentionDays) continue;

                        // too old, remove
                        await StorageManager.DeleteFileAsync(audioFile);
                    }
                }
                catch (Exception ex)
                {
                    Log.Fatal("[CACHE] Error while periodically cleaning audio cache: {err}", ex.Message);
                }
            }
        }

        private static async void PeriodicWebViewCacheCleaner()
        {
            while (!Variables.ShuttingDown)
            {
                try
                {
                    // wait an hour
                    await Task.Delay(TimeSpan.FromHours(1));

                    // shutting down?
                    if (Variables.ShuttingDown) return;

                    // check if we're active
                    if (!_webViewCacheCleanerActive) continue;

                    // check if we need to clean
                    if (Variables.AppSettings.WebViewCacheRetentionDays <= 0) continue;

                    // folder still there?
                    if (!Directory.Exists(Variables.WebViewCachePath)) continue;

                    // check last cleared
                    if ((DateTime.Now - Variables.AppSettings.WebViewCacheLastCleared).TotalDays < Variables.AppSettings.WebViewCacheRetentionDays) continue;

                    // clear it (this isn't done on a file level, but periodically)
                    await StorageManager.ClearDirectoryAsync(Variables.WebViewCachePath);

                    // set the new 'last cleared'
                    Variables.AppSettings.WebViewCacheLastCleared = DateTime.Now;

                    // and store it
                    SettingsManager.StoreAppSettings();
                }
                catch (Exception ex)
                {
                    Log.Fatal("[CACHE] Error while periodically cleaning webview cache: {err}", ex.Message);
                }
            }
        }
    }
}
