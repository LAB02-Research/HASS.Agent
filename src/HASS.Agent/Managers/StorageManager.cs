using System.Diagnostics.CodeAnalysis;
using System.IO;
using Serilog;
using Task = System.Threading.Tasks.Task;

namespace HASS.Agent.Managers
{
    internal static class StorageManager
    {
        /// <summary>
        /// Download an image to local temp path
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        internal static async Task<(bool success, string localFile)> DownloadImageAsync(string uri)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(uri))
                {
                    Log.Error("[STORAGE] Unable to download image: got an empty uri");
                    return (false, string.Empty);
                }

                if (!uri.ToLower().StartsWith("http"))
                {
                    Log.Error("[STORAGE] Unable to download image: only HTTP uri's are allowed, got: {uri}", uri);
                    return (false, string.Empty);
                }

                if (!Directory.Exists(Variables.ImageCachePath)) Directory.CreateDirectory(Variables.ImageCachePath);

                // check for extension
                // this fails for hass proxy urls, so add an extra length check
                var ext = Path.GetExtension(uri);
                if (string.IsNullOrEmpty(ext) || ext.Length > 5) ext = ".png";

                // create a random local filename
                var localFile = $"{DateTime.Now:yyyyMMddHHmmss}_{Guid.NewGuid().ToString()[..8]}";
                localFile = Path.Combine(Variables.ImageCachePath, $"{localFile}{ext}");

                // parse the uri as a check
                var safeUri = new Uri(uri);

                // download the file
                await DownloadRemoteFileAsync(safeUri.AbsoluteUri, localFile);

                return (true, localFile);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[STORAGE] Error downloading image: {uri}", uri);
                return (false, string.Empty);
            }
        }

        /// <summary>
        /// Download an audio file to local temp path
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        internal static async Task<(bool success, string localFile)> DownloadAudioAsync(string uri)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(uri))
                {
                    Log.Error("[STORAGE] Unable to download audio: got an empty uri");
                    return (false, string.Empty);
                }

                if (!uri.ToLower().StartsWith("http"))
                {
                    Log.Error("[STORAGE] Unable to download audio: only HTTP uri's are allowed, got: {uri}", uri);
                    return (false, string.Empty);
                }

                if (!Directory.Exists(Variables.AudioCachePath)) Directory.CreateDirectory(Variables.AudioCachePath);

                // check for extension
                // this fails for hass proxy urls, so add an extra length check
                var ext = Path.GetExtension(uri);
                if (string.IsNullOrEmpty(ext) || ext.Length > 5) ext = ".mp3";

                // create a random local filename
                var localFile = $"{DateTime.Now:yyyyMMddHHmmss}_{Guid.NewGuid().ToString()[..8]}";
                localFile = Path.Combine(Variables.AudioCachePath, $"{localFile}{ext}");

                // parse the uri as a check
                var safeUri = new Uri(uri);

                // download the file
                await DownloadRemoteFileAsync(safeUri.AbsoluteUri, localFile);

                return (true, localFile);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[STORAGE] Error downloading audio: {uri}", uri);
                return (false, string.Empty);
            }
        }

        /// <summary>
        /// Downloads the provided uri into the provided local file
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="localFile"></param>
        /// <returns></returns>
        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        internal static async Task<bool> DownloadFileAsync(string uri, string localFile)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(uri))
                {
                    Log.Error("[STORAGE] Unable to download file: got an empty uri");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(localFile))
                {
                    Log.Error("[STORAGE] Unable to download file: got an empty local file");
                    return false;
                }

                if (!uri.ToLower().StartsWith("http"))
                {
                    Log.Error("[STORAGE] Unable to download file: only HTTP uri's are allowed, got: {uri}", uri);
                    return false;
                }

                var localFilePath = Path.GetDirectoryName(localFile);
                if (!Directory.Exists(localFilePath)) Directory.CreateDirectory(localFilePath!);

                // parse the uri as a check
                var safeUri = new Uri(uri);

                // download the file
                await DownloadRemoteFileAsync(safeUri.AbsoluteUri, localFile);

                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[STORAGE] Error downloading file: {uri}", uri);
                return false;
            }
        }

        /// <summary>
        /// Deletes the provided directory and its containing files, optionally recursively
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="recursive"></param>
        /// <returns></returns>
        internal static async Task<bool> DeleteDirectoryAsync(string directory, bool recursive = true)
        {
            try
            {
                if (!Directory.Exists(directory)) return true;

                // get dir info
                var dirInfo = new DirectoryInfo(directory);

                if (recursive) await Task.Run(async () => await DeleteDirectoryRecursively(dirInfo));
                else
                {
                    await Task.Run(async delegate
                    {
                        var files = dirInfo.GetFiles();

                        // remove readonly from files and remove them
                        foreach (var file in files)
                        {
                            file.IsReadOnly = false;
                            file.Delete();
                        }

                        // give io time to catchup
                        await Task.Delay(250);

                        // delete the directory
                        Directory.Delete(directory, false);
                    });
                }

                // done
                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal("[STORAGE] Error while deleting directory '{dir}': {err}", directory, ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Clears the provided directory and its containing files, optionally recursively
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="recursive"></param>
        /// <returns></returns>
        internal static async Task<(bool success, int dirsDeleted, int filesDeleted)> ClearDirectoryAsync(string directory, bool recursive = true)
        {
            try
            {
                // prepare vars
                var searchOption = recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;

                var dirsDeleted = 0;
                var dirsFailed = 0;

                var filesDeleted = 0;
                var filesFailed = 0;

                // first all directories
                foreach (var dir in Directory.EnumerateDirectories(directory, "*", searchOption))
                {
                    var dirDeleted = await DeleteDirectoryAsync(dir, recursive);
                    if (dirDeleted) dirsDeleted++;
                    else dirsFailed++;
                }

                // now the files (only of the root folder)
                foreach (var file in Directory.EnumerateFiles(directory, "*", SearchOption.TopDirectoryOnly))
                {
                    var fileDeleted = await DeleteFileAsync(file);
                    if (fileDeleted) filesDeleted++;
                    else filesFailed++;
                }
                
                // done
                var success = dirsFailed == 0 && filesFailed == 0;
                return (success, dirsDeleted, filesDeleted);
            }
            catch (Exception ex)
            {
                Log.Fatal("[STORAGE] Error while clearing directory '{dir}': {err}", directory, ex.Message);
                return (false, 0, 0);
            }
        }

        private static async Task DeleteDirectoryRecursively(DirectoryInfo baseDir)
        {
            try
            {
                if (!baseDir.Exists) return;

                foreach (var dir in baseDir.EnumerateDirectories()) await DeleteDirectoryRecursively(dir);

                var files = baseDir.GetFiles();

                foreach (var file in files)
                {
                    file.IsReadOnly = false;
                    file.Delete();
                }

                var errMsg = string.Empty;
                for (var attempt = 0; attempt < 3; attempt++)
                {
                    try
                    {
                        baseDir.Delete(true);
                        return;
                    }
                    catch (Exception ex)
                    {
                        errMsg = ex.Message;

                        // give io time to catchup and try again
                        await Task.Delay(250);
                    }
                }

                Log.Error("[STORAGE] Error while deleting sub-directory '{dir}': {err}", baseDir.FullName, errMsg);
            }
            catch (Exception ex)
            {
                Log.Fatal("[STORAGE] Error while cleaning sub-directory '{dir}': {err}", baseDir.FullName, ex.Message);
            }
        }

        /// <summary>
        /// Deletes the provided file, by default three attempts
        /// </summary>
        /// <param name="file"></param>
        /// <param name="threeAttempts"></param>
        /// <returns></returns>
        internal static async Task<bool> DeleteFileAsync(string file, bool threeAttempts = true)
        {
            try
            {
                if (!File.Exists(file)) return true;

                // remove readonly if set
                try
                {
                    var fileInfo = new FileInfo(file);
                    if (fileInfo.IsReadOnly) fileInfo.IsReadOnly = false;
                }
                catch
                {
                    // best effort
                }

                if (!threeAttempts)
                {
                    // just once
                    File.Delete(file);
                    return true;
                }

                // three attempts
                var errMsg = string.Empty;
                for (var i = 0; i < 3; i++)
                {
                    try
                    {
                        File.Delete(file);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        errMsg = ex.Message;
                        await Task.Delay(TimeSpan.FromSeconds(3));
                    }
                }

                Log.Error("[STORAGE] Errors during three attempts to delete file '{file}': {err}", file, errMsg);
                return false;
            }
            catch (Exception ex)
            {
                Log.Fatal("[STORAGE] Error while deleting file '{file}': {err}", file, ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Prepares a local temp filename for the installer
        /// </summary>
        /// <returns></returns>
        [SuppressMessage("ReSharper", "InvertIf")]
        internal static async Task<string> PrepareTempInstallerFilename()
        {
            try
            {
                // prepare the folder
                var tempFolder = Path.Combine(Path.GetTempPath(), "HASS.Agent");
                if (Directory.Exists(tempFolder)) Directory.CreateDirectory(tempFolder);

                // prepare the file
                var tempFile = Path.Combine(tempFolder, "HASS.Agent.Installer.exe");

                // check if there's an old one there
                if (File.Exists(tempFile))
                {
                    // yep, try to delete
                    var deleted = await DeleteFileAsync(tempFile);
                    if (!deleted)
                    {
                        Log.Error("[STORAGE] Unable to delete the current temp installer, is it still running?");
                        return string.Empty;
                    }
                }

                // all done
                return tempFile;
            }
            catch (Exception ex)
            {
                Log.Error("[STORAGE] Unable to prepare a temp filename for the installer: {err}", ex.Message);
                return string.Empty;
            }
        }

        /// <summary>
        /// Downloads the provided URI to a local file
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="localFile"></param>
        /// <returns></returns>
        private static async Task<bool> DownloadRemoteFileAsync(string uri, string localFile)
        {
            try
            {
                if (File.Exists(localFile))
                {
                    File.Delete(localFile);
                    await Task.Delay(50);
                }

                // get a stream from our http client
                await using var stream = await Variables.HttpClient.GetStreamAsync(uri);

                // get a local file stream
                await using var fileStream = new FileStream(localFile!, FileMode.CreateNew);

                // transfer the data
                await stream.CopyToAsync(fileStream);

                // done
                return true;
            }
            catch (Exception ex)
            {
                Log.Error("[STORAGE] Error while downloading file!\r\nRemote URI: {uri}\r\nLocal file: {localFile}\r\nError: {err}", uri, localFile, ex.Message);
                return false;
            }
        }
    }
}
