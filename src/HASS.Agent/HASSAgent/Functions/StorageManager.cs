using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading.Tasks;
using Serilog;
using Task = System.Threading.Tasks.Task;

namespace HASSAgent.Functions
{
    internal static class StorageManager
    {
        /// <summary>
        /// Download an image to local temp path
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="localPath"></param>
        /// <returns></returns>
        internal static bool DownloadImage(string uri, out string localPath)
        {
            localPath = string.Empty;

            try
            {
                if (string.IsNullOrWhiteSpace(uri))
                {
                    Log.Error("[STORAGE] Unable to download image: got an empty uri");
                    return false;
                }

                if (!uri.ToLower().StartsWith("http"))
                {
                    Log.Error("[STORAGE] Unable to download image: only HTTP uri's are allowed, got: {uri}", uri);
                    return false;
                }

                if (!Directory.Exists(Variables.ImageCachePath)) Directory.CreateDirectory(Variables.ImageCachePath);

                // check for extension
                // this fails for hass proxy urls, so add an extra length check
                var ext = Path.GetExtension(uri);
                if (string.IsNullOrEmpty(ext) || ext.Length > 5) ext = ".png";

                // create a random local filename
                var localFile = $"{DateTime.Now:yyyyMMddHHmmss}_{Guid.NewGuid().ToString().Substring(0, 8)}";
                localPath = Path.Combine(Variables.ImageCachePath, $"{localFile}{ext}");

                // make the uri safe
                var safeUri = Uri.EscapeUriString(uri);

                // download the file
                Variables.WebClient.DownloadFile(new Uri(safeUri), localPath);

                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[STORAGE] Error downloading image: {uri}", uri);
                return false;
            }
        }

        /// <summary>
        /// Downloads the provided uri into the provided local file
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="localFile"></param>
        /// <returns></returns>
        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        internal static bool DownloadFile(string uri, string localFile)
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
                if (!Directory.Exists(localFilePath)) Directory.CreateDirectory(localFilePath);
                
                // make the uri safe
                var safeUri = Uri.EscapeUriString(uri);

                // download the file
                Variables.WebClient.DownloadFile(new Uri(safeUri), localFile);

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

                if (recursive) await Task.Run((Func<Task>)(async () => await DeleteDirectoryRecursively(dirInfo)));
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
    }
}
