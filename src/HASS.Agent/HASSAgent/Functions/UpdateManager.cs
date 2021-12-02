using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octokit;
using Serilog;

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
            var (isAvailable, version) = await UpdateAvailable();
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

                // check for new update
                var (isAvailable, version) = await UpdateAvailable();
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
            // todo
        }

        /// <summary>
        /// Queries the GitHub API to determine whether the latest release tag is greater than this version
        /// </summary>
        /// <returns></returns>
        internal static async Task<(bool isAvailable, string version)> UpdateAvailable()
        {
            try
            {
                // create a new unauthorized github client
                var client = new GitHubClient(new ProductHeaderValue("HASS.Agent"));

                // fetch the latest release
                var latestRelease = await client.Repository.Release.GetLatest("LAB02-Research", "HASS.Agent");
                
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
        /// Returns the .zip asset URL for the latest release tag
        /// </summary>
        /// <returns></returns>
        internal static async Task<string> GetLatestVersionAssetUrl()
        {
            try
            {
                // create a new unauthorized github client
                var client = new GitHubClient(new ProductHeaderValue("HASS.Agent"));

                // fetch the latest release
                var latestRelease = await client.Repository.Release.GetLatest("LAB02-Research", "HASS.Agent");

                // get the .zip asset
                var zipAsset = latestRelease.Assets.Select(x => x).FirstOrDefault(y => y.ContentType == "application/x-zip-compressed");
                if (zipAsset == null)
                {
                    // not found ..
                    Log.Error("[UPDATER] No .zip asset found for release: {v}", latestRelease.TagName);
                    return string.Empty;
                }

                // done
                return zipAsset.BrowserDownloadUrl;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[UPDATER] Error getting the latest version's asset URL: {err}", ex.Message);
                return string.Empty;
            }
        }
    }
}
