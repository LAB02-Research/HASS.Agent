using System.Diagnostics;
using HASS.Agent.Enums;
using HASS.Agent.Functions;
using HASS.Agent.Models.Internal;
using HASS.Agent.Resources.Localization;
using HASS.Agent.Settings;
using Octokit;
using Serilog;
using Syncfusion.Windows.Forms;

namespace HASS.Agent.Managers
{
    internal static class UpdateManager
    {
        private static readonly Version CurrentVersion = Version.Parse(Variables.Version.Split('-').First());

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
                
                // check if it's newer
                var isNewer = UpdateIsNewer(Variables.Version, latestRelease.TagName);
                if (!isNewer) return (false, pendingUpdate);

                // there's an update!
                pendingUpdate.Version = latestRelease.TagName;
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

                    // check for beta
                    if (release.TagName.Contains('b')) pendingUpdate.IsBeta = true;

                    // check if it's newer
                    var isNewer = UpdateIsNewer(Variables.Version, release.TagName, true);
                    if (!isNewer) return (false, pendingUpdate);

                    // newer :)
                    pendingUpdate.Version = release.TagName;
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

                pendingUpdate.ReleaseNotes = Languages.UpdateManager_GetLatestVersionInfo_Error;
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
                MessageBoxAdv.Show(Languages.UpdateManager_DownloadAndExecuteUpdate_MessageBox1,
                    Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LaunchReleaseUrl(pendingUpdate);
                return;
            }

            // download the installer
            var downloaded = await StorageManager.DownloadFileAsync(pendingUpdate.InstallerUrl, tempFile);
            if (!downloaded || !File.Exists(tempFile))
            {
                MessageBoxAdv.Show(Languages.UpdateManager_DownloadAndExecuteUpdate_MessageBox2,
                    Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LaunchReleaseUrl(pendingUpdate);
                return;
            }

            // check the certificate
            var certCheck = HelperFunctions.ConfirmCertificate(tempFile);
            if (!certCheck)
            {
                MessageBoxAdv.Show(Languages.UpdateManager_DownloadAndExecuteUpdate_MessageBox3, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBoxAdv.Show(Languages.UpdateManager_DownloadAndExecuteUpdate_MessageBox4, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        /// <summary>
        /// Returns whether the available version is newer than the current
        /// </summary>
        /// <param name="currentVersion"></param>
        /// <param name="availableVersion"></param>
        /// <param name="includeBeta"></param>
        /// <returns></returns>
        private static bool UpdateIsNewer(string currentVersion, string availableVersion, bool includeBeta = false)
        {
            try
            {
                // check for beta?
                if (!includeBeta && availableVersion.Contains('b')) return false;

                // determine beta status
                var currentVersionIsBeta = currentVersion.Contains('b');
                var availableVersionIsBeta = availableVersion.Contains('b');

                // backwards compatiblity
                if (currentVersion.StartsWith('v') || currentVersion.StartsWith('b')) currentVersion = currentVersion.Remove(0 ,1);
                if (availableVersion.StartsWith('v') || availableVersion.StartsWith('b')) availableVersion = availableVersion.Remove(0, 1);

                // try to parse the versions
                var versionParsed = Version.TryParse(currentVersion.Split('-').First(), out var currentVersionClean);
                if (!versionParsed)
                {
                    Log.Error("[UPDATER] Unable to parse current version tag: {v}", currentVersion);
                    return false;
                }

                versionParsed = Version.TryParse(availableVersion.Split('-').First(), out var availableVersionClean);
                if (!versionParsed)
                {
                    Log.Error("[UPDATER] Unable to parse available version tag: {v}", currentVersion);
                    return false;
                }

                // compare versions
                var versionComparison = (VersionComparisonResult)currentVersionClean.CompareTo(availableVersionClean);
                switch (versionComparison)
                {
                    // the available version is older, ignore
                    case VersionComparisonResult.Older:
                        return false;

                    // the available version appears identical
                    case VersionComparisonResult.Identical:
                        switch (currentVersionIsBeta)
                        {
                            // are we going from beta to release?
                            case true when !availableVersionIsBeta:
                                // yep! update
                                return true;

                            // are we both beta?
                            case true:
                                // battle of the beta's
                                return AvailableBetaIsNewerThanCurrentBeta(currentVersion, availableVersion);

                            // nothing to do
                            default:
                                return false;
                        }

                    case VersionComparisonResult.Newer:
                        // newer, beta or not
                        return true;

                    default:
                        // nothing to do
                        return false;
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[UPDATER] Unable to compare version {a} with {b}: {err}", currentVersion, availableVersion, ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Returns whether the available beta version is newer than the current beta version
        /// </summary>
        /// <param name="currentBetaVersion"></param>
        /// <param name="availableBetaVersion"></param>
        /// <returns></returns>
        private static bool AvailableBetaIsNewerThanCurrentBeta(string currentBetaVersion, string availableBetaVersion)
        {
            try
            {
                if (!currentBetaVersion.Contains('b')) return false;
                if (!availableBetaVersion.Contains('b')) return false;

                var currentBeta = int.Parse(currentBetaVersion.Split('a').Last());
                var availableBeta = int.Parse(availableBetaVersion.Split('a').Last());

                return availableBeta > currentBeta;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[UPDATER] Unable to compare beta version {a} with {b}: {err}", currentBetaVersion, availableBetaVersion, ex.Message);
                return false;
            }
        }
    }
}
