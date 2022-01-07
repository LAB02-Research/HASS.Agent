using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace HASSAgent.Functions
{
    internal static class CacheManager
    {
        private static bool _imageCacheCleanerActive = true;

        /// <summary>
        /// Initializes the cache manager, which periodically clears all caches based on their retention policy
        /// </summary>
        internal static void Initialize()
        {
            // rmeove the legacy 'temp' folder if it's there
            var legacyTempFolder = Path.Combine(Variables.StartupPath, "Temp");
            if (Directory.Exists(legacyTempFolder)) _ = Task.Run(() => HelperFunctions.DeleteDirectoryAsync(legacyTempFolder));

            // start periodic image cache cleaner
            _ = Task.Run(PeriodicImageCacheCleaner);
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

                if (!Directory.Exists(Variables.ImageCachePath)) return;

                // enumerate all files
                var imageFiles = Directory.EnumerateFiles(Variables.ImageCachePath, "*.*", SearchOption.TopDirectoryOnly).ToArray();
                foreach (var imageFile in imageFiles) await HelperFunctions.DeleteFileAsync(imageFile);

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

                    // enumerate all files
                    var imageFiles = Directory.EnumerateFiles(Variables.ImageCachePath, "*.*", SearchOption.TopDirectoryOnly).ToArray();
                    var now = DateTime.Now;
                    foreach (var imageFile in imageFiles)
                    {
                        // get & check file age
                        var fileInfo = new FileInfo(imageFile);
                        if ((now - fileInfo.CreationTime).TotalDays < Variables.AppSettings.ImageCacheRetentionDays) continue;

                        // too old, remove
                        await HelperFunctions.DeleteFileAsync(imageFile);
                    }
                }
                catch (Exception ex)
                {
                    Log.Fatal("[CACHE] Error while periodically cleaning image cache: {err}", ex.Message);
                }
            }
        }
    }
}
