using System.Diagnostics;
using HASSAgent.Models.Internal;
using HASSAgent.Settings;
using Octokit;
using Serilog;
using Syncfusion.Windows.Forms;

namespace HASSAgent.Functions
{
    internal static class UpdateManager
    {
        private static readonly Version CurrentVersion = Version.Parse(Variables.Version);

        /// <summary>
        /// Initialize initial and periodic update checking
        /// </summary>
        internal static async void Initialize()
        {
            // wait a minute in case Windows is busy launching
            await Task.Delay(TimeSpan.FromMinutes(1));

            // initial check
            var (isAvailable, version) = await CheckIsUpdateAvailableAsync();
            if (isAvailable) ProcessAvailableUpdate(version);

            // start periodic check
            _ = Task.Run(PeriodicUpdateCheck);
        }

        /// <summary>
        /// Checks for new updates every 30 minutes
        /// </summary>
        private static async void PeriodicUpdateCheck()
        {
            while (!Variables.ShuttingDown)
            {
                // once every 30 min
                await Task.Delay(TimeSpan.FromMinutes(30));

                // check if we're shutting down
                if (Variables.ShuttingDown) return;

                // disabled by now?
                if (!Variables.AppSettings.CheckForUpdates) continue;

                // check for new update
                var (isAvailable, version) = await CheckIsUpdateAvailableAsync();
                if (!isAvailable) continue;

                // jep! process
                ProcessAvailableUpdate(version);
            }
        }

        /// <summary>
        /// Called by the automatic updater (on launch or periodically), informs the user of a new update
        /// </summary>
        /// <param name="pendingUpdate"></param>
        private static void ProcessAvailableUpdate(PendingUpdate pendingUpdate)
        {
            // did we show this version already?
            if (pendingUpdate.Version == Variables.AppSettings.LastUpdateNotificationShown) return;

            // nope, store that we're showing info about this version
            Variables.AppSettings.LastUpdateNotificationShown = pendingUpdate.Version;
            SettingsManager.StoreAppSettings();

            // now show the window
            Variables.MainForm.ShowUpdateInfo(pendingUpdate);
        }

        /// <summary>
        /// Queries the GitHub API to determine whether the latest release tag is greater than this version
        /// </summary>
        /// <returns></returns>
        internal static async Task<(bool isAvailable, PendingUpdate pendingUpdate)> CheckIsUpdateAvailableAsync()
        {
            // are betas enabled?
            if (Variables.AppSettings.ShowBetaUpdates) return await CheckIsBetaUpdateAvailableAsync();

            // nope, regular only
            var pendingUpdate = new PendingUpdate();

            try
            {
                // create a new unauthorized github client
                var client = new GitHubClient(new ProductHeaderValue("HASS.Agent"));

                // fetch the latest release
                var latestRelease = await client.Repository.Release.GetLatest("LAB02-Research", "HASS.Agent");

                // ignore if it's a draft
                if (latestRelease.Draft) return (false, pendingUpdate);

                // check for prerelease
                if (latestRelease.Prerelease) return (false, pendingUpdate);

                // check for betas (starting with b)
                if (latestRelease.TagName.StartsWith("b")) return (false, pendingUpdate);

                // remove the leading char
                var tagName = latestRelease.TagName.Remove(0, 1);

                // check if we can parse
                var versionParsed = Version.TryParse(tagName, out var latestGitHubVersion);
                if (!versionParsed)
                {
                    Log.Error("[UPDATER] Unable to parse version tag: {v}", tagName);
                    return (false, pendingUpdate);
                }

                // compare version
                var versionComparison = CurrentVersion.CompareTo(latestGitHubVersion);
                if (versionComparison >= 0)
                {
                    // no new version
                    return (false, pendingUpdate);
                }

                // there's an update!
                pendingUpdate.Version = tagName;
                pendingUpdate.GitHubRelease = latestRelease;

                return (true, pendingUpdate);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[UPDATER] Error checking for updates: {err}", ex.Message);
                return (false, pendingUpdate);
            }
        }

        /// <summary>
        /// Queries the GitHub API to determine whether there's a beta update available (or a regular one)
        /// </summary>
        /// <returns></returns>
        private static async Task<(bool isAvailable, PendingUpdate pendingUpdate)> CheckIsBetaUpdateAvailableAsync()
        {
            var pendingUpdate = new PendingUpdate();

            try
            {
                // create a new unauthorized github client
                var client = new GitHubClient(new ProductHeaderValue("HASS.Agent"));

                // fetch the latest releases
                var latestReleases = await client.Repository.Release.GetAll("LAB02-Research", "HASS.Agent");
                Release latestRelease = null;

                // iterate them, and see if there's a new one
                foreach (var release in latestReleases)
                {
                    // ignore if it's a draft
                    if (release.Draft) return (false, pendingUpdate);

                    // check for prerelease
                    if (release.Prerelease) pendingUpdate.IsBeta = true;

                    // check for betas (starting with b)
                    if (release.TagName.StartsWith("b")) pendingUpdate.IsBeta = true;

                    // remove the leading char
                    var tagName = release.TagName.Remove(0, 1);

                    // check if we can parse
                    var versionParsed = Version.TryParse(tagName, out var latestGitHubVersion);
                    if (!versionParsed)
                    {
                        Log.Error("[UPDATER] Unable to parse version tag: {v}", tagName);
                        return (false, pendingUpdate);
                    }

                    // compare version
                    var versionComparison = CurrentVersion.CompareTo(latestGitHubVersion);
                    if (versionComparison >= 0)
                    {
                        // no new version
                        continue;
                    }

                    // newer :)
                    pendingUpdate.Version = tagName;
                    latestRelease = release;
                    break;
                }

                // update found?
                if (latestRelease == null)
                {
                    // nope
                    return (false, pendingUpdate);
                }

                // yep, there's an update!
                pendingUpdate.GitHubRelease = latestRelease;
                return (true, pendingUpdate);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[UPDATER] Error checking for beta updates: {err}", ex.Message);
                return (false, pendingUpdate);
            }
        }

        /// <summary>
        /// Returns the release's URL, release notes and installer url for the latest release tag
        /// </summary>
        /// <returns></returns>
        internal static PendingUpdate GetLatestVersionInfo(PendingUpdate pendingUpdate)
        {
            try
            {
                // get the installer
                var installerAssetUrl = string.Empty;
                var installerAsset = pendingUpdate.GitHubRelease.Assets.Select(x => x).FirstOrDefault(y => y.BrowserDownloadUrl.ToLower().EndsWith("installer.exe"));
                if (installerAsset == null)
                {
                    // not found ..
                    Log.Error("[UPDATER] No .installer.exe asset found for release: {v}", pendingUpdate.GitHubRelease.TagName);
                }
                else installerAssetUrl = installerAsset.BrowserDownloadUrl;

                // set the installer
                pendingUpdate.InstallerUrl = installerAssetUrl;

                // get the release url
                pendingUpdate.ReleaseUrl = pendingUpdate.GitHubRelease.HtmlUrl;

                // get the release notes
                pendingUpdate.ReleaseNotes = pendingUpdate.GitHubRelease.Body;

                // done
                return pendingUpdate;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[UPDATER] Error getting the latest version's info: {err}", ex.Message);

                pendingUpdate.ReleaseNotes = "error fetching info, check the logs";
                return pendingUpdate;
            }
        }

        /// <summary>
        /// Downloads the latest installer to a local temp file, and executes it
        /// </summary>
        /// <param name="pendingUpdate"></param>
        /// <returns></returns>
        internal static async Task DownloadAndExecuteUpdate(PendingUpdate pendingUpdate)
        {
            // yep, prepare a temporary filename
            var tempFile = await StorageManager.PrepareTempInstallerFilename();
            if (string.IsNullOrEmpty(tempFile))
            {
                MessageBoxAdv.Show("Unable to prepare downloading the update, check the logs for more info.\r\n\r\nThe release page will now open instead.",
                    "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LaunchReleaseUrl(pendingUpdate);
                return;
            }

            // download the installer
            var downloaded = await StorageManager.DownloadFileAsync(pendingUpdate.InstallerUrl, tempFile);
            if (!downloaded || !File.Exists(tempFile))
            {
                MessageBoxAdv.Show("Unable to download the update, check the logs for more info.\r\n\r\nThe release page will now open instead.",
                    "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LaunchReleaseUrl(pendingUpdate);
                return;
            }

            // check the certificate
            var certCheck = HelperFunctions.ConfirmCertificate(tempFile);
            if (!certCheck)
            {
                MessageBoxAdv.Show("The downloaded file FAILED the certificate check.\r\n\r\nThis could be a technical error, but also a tampered file!\r\n\r\n" +
                                   "Please check the logs, and post a ticket with the findings.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LaunchReleaseUrl(pendingUpdate);
                return;
            }

            // finally, execute it
            try
            {
                using (_ = Process.Start(new ProcessStartInfo(tempFile) { UseShellExecute = true })) { }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[UPDATER] Error while launching the installer: {err}", ex.Message);
                MessageBoxAdv.Show("Unable to launch the installer (did you approve the UAC prompt?), check the logs for more info.\r\n\r\nThe release page will now open instead.",
                    "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LaunchReleaseUrl(pendingUpdate);
            }
        }

        /// <summary>
        /// Attempts to launch the release's page, if that's not found, the latest release page
        /// </summary>
        /// <param name="pendingUpdate"></param>
        internal static void LaunchReleaseUrl(PendingUpdate pendingUpdate)
        {
            // check if we got the release url
            if (string.IsNullOrEmpty(pendingUpdate.ReleaseUrl))
            {
                // nope, weird
                HelperFunctions.LaunchUrl("https://github.com/LAB02-Research/HASS.Agent/releases/latest");
                return;
            }

            // open the release's github page
            HelperFunctions.LaunchUrl(pendingUpdate.ReleaseUrl);
        }
    }
}
