using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        /// <param name="version"></param>
        private static void ProcessAvailableUpdate(string version)
        {
            // did we show this version already?
            if (version == Variables.AppSettings.LastUpdateNotificationShown) return;

            // nope, store that we're showing info about this version
            Variables.AppSettings.LastUpdateNotificationShown = version;
            SettingsManager.StoreAppSettings();

            // now show the window
            Variables.MainForm.ShowUpdateInfo(version);
        }

        /// <summary>
        /// Queries the GitHub API to determine whether the latest release tag is greater than this version
        /// </summary>
        /// <returns></returns>
        internal static async Task<(bool isAvailable, string version)> CheckIsUpdateAvailableAsync()
        {
            try
            {
                // create a new unauthorized github client
                var client = new GitHubClient(new ProductHeaderValue("HASS.Agent"));

                // fetch the latest release
                var latestRelease = await client.Repository.Release.GetLatest("LAB02-Research", "HASS.Agent");

                // ignore if it's a draft
                if (latestRelease.Draft) return (false, string.Empty);

                // ignore prereleases
                if (latestRelease.Prerelease) return (false, string.Empty);

                // ignore betas (starting with a b)
                if (latestRelease.TagName.StartsWith("b")) return (false, string.Empty);

                // remove the 'v' if it's there
                var tagName = latestRelease.TagName.StartsWith("v")
                    ? latestRelease.TagName.Remove(0, 1)
                    : latestRelease.TagName;

                // check if we can parse
                var versionParsed = Version.TryParse(tagName, out var latestGitHubVersion);
                if (!versionParsed)
                {
                    Log.Error("[UPDATER] Unable to parse version tag: {v}", tagName);
                    return (false, string.Empty);
                }

                // compare version
                var versionComparison = CurrentVersion.CompareTo(latestGitHubVersion);
                if (versionComparison >= 0)
                {
                    // no new version
                    return (false, string.Empty);
                }

                // there's an update!
                return (true, tagName);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[UPDATER] Error checking for updates: {err}", ex.Message);
                return (false, string.Empty);
            }
        }

        /// <summary>
        /// Returns the release's URL, release notes and installer url for the latest release tag
        /// </summary>
        /// <returns></returns>
        internal static async Task<(string releaseUrl, string releaseNotes, string installerExe)> GetLatestVersionInfoAsync()
        {
            try
            {
                // create a new unauthorized github client
                var client = new GitHubClient(new ProductHeaderValue("HASS.Agent"));

                // fetch the latest release
                var latestRelease = await client.Repository.Release.GetLatest("LAB02-Research", "HASS.Agent");

                // get the installer
                var installerAssetUrl = string.Empty;
                var installerAsset = latestRelease.Assets.Select(x => x).FirstOrDefault(y => y.BrowserDownloadUrl.ToLower().EndsWith("installer.exe"));
                if (installerAsset == null)
                {
                    // not found ..
                    Log.Error("[UPDATER] No .installer.exe asset found for release: {v}", latestRelease.TagName);
                }
                else installerAssetUrl = installerAsset.BrowserDownloadUrl;

                // get the release url
                var releaseUrl = latestRelease.HtmlUrl;

                // get the release notes
                var releaseNotes = latestRelease.Body;

                // done
                return (releaseUrl, releaseNotes, installerAssetUrl);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[UPDATER] Error getting the latest version's info: {err}", ex.Message);
                return (string.Empty, "error fetching info, check the logs", string.Empty);
            }
        }

        /// <summary>
        /// Downloads the latest installer to a local temp file, and executes it
        /// </summary>
        /// <param name="installerUrl"></param>
        /// <param name="releaseUrl"></param>
        /// <returns></returns>
        internal static async Task DownloadAndExecuteUpdate(string installerUrl, string releaseUrl)
        {
            // yep, prepare a temporary filename
            var tempFile = await StorageManager.PrepareTempInstallerFilename();
            if (string.IsNullOrEmpty(tempFile))
            {
                MessageBoxAdv.Show("Unable to prepare downloading the update, check the logs for more info.\r\n\r\nThe release page will now open instead.",
                    "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LaunchReleaseUrl(releaseUrl);
                return;
            }

            // download the installer
            var downloaded = await Task.Run(() => StorageManager.DownloadFile(installerUrl, tempFile));
            if (!downloaded || !File.Exists(tempFile))
            {
                MessageBoxAdv.Show("Unable to download the update, check the logs for more info.\r\n\r\nThe release page will now open instead.",
                    "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LaunchReleaseUrl(releaseUrl);
                return;
            }

            // check the certificate
            var certCheck = HelperFunctions.ConfirmCertificate(tempFile);
            if (!certCheck)
            {
                MessageBoxAdv.Show("The downloaded file FAILED the certificate check.\r\n\r\nThis could be a technical error, but also a tampered file!\r\n\r\n" +
                                   "Please check the logs, and post a ticket with the findings.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LaunchReleaseUrl(releaseUrl);
                return;
            }

            // finally, execute it
            try
            {
                Process.Start(tempFile);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[UPDATER] Error while launching the installer: {err}", ex.Message);
                MessageBoxAdv.Show("Unable to launch the installer (did you approve the UAC prompt?), check the logs for more info.\r\n\r\nThe release page will now open instead.",
                    "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LaunchReleaseUrl(releaseUrl);
            }
        }

        /// <summary>
        /// Attempts to launch the release's page, if that's not found, the latest release page
        /// </summary>
        internal static void LaunchReleaseUrl(string releaseUrl)
        {
            // check if we got the release url
            if (string.IsNullOrEmpty(releaseUrl))
            {
                // nope, weird
                HelperFunctions.LaunchUrl("https://github.com/LAB02-Research/HASS.Agent/releases/latest");
                return;
            }

            // open the release's github page
            HelperFunctions.LaunchUrl(releaseUrl);
        }
    }
}
