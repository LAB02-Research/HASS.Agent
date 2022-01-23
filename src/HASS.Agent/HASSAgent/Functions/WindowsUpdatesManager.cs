using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HASSAgent.Models.Internal;
using Serilog;
using WUApiLib;

namespace HASSAgent.Functions
{
    internal static class WindowsUpdatesManager
    {
        private static DateTime _lastCheck = DateTime.MinValue;

        private static List<WindowsUpdateInfo> _driverUpdates = new List<WindowsUpdateInfo>();
        private static List<WindowsUpdateInfo> _softwareUpdates = new List<WindowsUpdateInfo>();

        /// <summary>
        /// Attempts to look for available driver- and software updates (max once per 10 minutes)
        /// </summary>
        /// <returns></returns>
        internal static (List<WindowsUpdateInfo> driverUpdates, List<WindowsUpdateInfo> softwareUpdates) GetAvailableUpdates()
        {
            try
            {
                if ((DateTime.Now - _lastCheck).TotalMinutes < 10) return (_driverUpdates, _softwareUpdates);
                _lastCheck = DateTime.Now;

                // reset the current lists
                _driverUpdates = new List<WindowsUpdateInfo>();
                _softwareUpdates = new List<WindowsUpdateInfo>();

                // fetch a new list
                var updateList = GetUpdateList();
                if (!updateList.Any())
                {
                    // nothing, easy
                    return (_driverUpdates, _softwareUpdates);
                }

                // split the returns
                if (updateList.Any(x => x.Type == "Driver"))
                {
                    // fetch all driver updates
                    _driverUpdates = updateList.Select(x => x).Where(x => x.Type == "Driver").ToList();
                }

                if (updateList.Any(x => x.Type == "Software"))
                {
                    // fetch all software updates
                    _softwareUpdates = updateList.Select(x => x).Where(x => x.Type == "Software").ToList();
                }

                // all done!
                return (_driverUpdates, _softwareUpdates);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[WUPDATE] Error while checking for available updates: {err}", ex.Message);
                return (_driverUpdates, _softwareUpdates);
            }
        }

        private static List<WindowsUpdateInfo> GetUpdateList()
        {
            try
            {
                var updateList = new List<WindowsUpdateInfo>();

                // prepare an updater session
                var uSession = new UpdateSessionClass();

                // prepare an updater searcher
                var uSearcher = uSession.CreateUpdateSearcher();
                if (uSearcher == null)
                {
                    Log.Error("[WUPDATE] Unable to create an update searcher, possibly corrupt?");
                    return updateList;
                }

                // we want all updates
                uSearcher.ServerSelection = ServerSelection.ssOthers;
                uSearcher.ServiceID = "7971f918-a847-4430-9279-4a52d1efe18d";

                // search for all non-installed updates
                var uResult = uSearcher.Search("IsInstalled=0");
                if (uResult == null)
                {
                    Log.Error("[WUPDATE] Unable to search for updates, possibly corrupt?");
                    return updateList;
                }

                // process not-ok result codes
                if (uResult.ResultCode != OperationResultCode.orcSucceeded)
                {
                    switch (uResult.ResultCode)
                    {
                        case OperationResultCode.orcNotStarted:
                            Log.Error("[WUPDATE] Updater returned 'not started', is the service running?");
                            break;
                        case OperationResultCode.orcInProgress:
                            Log.Warning("[WUPDATE] Updater returned 'in progress', try again later");
                            break;
                        case OperationResultCode.orcSucceededWithErrors:
                            Log.Warning("[WUPDATE] Updater returned 'succeeded with errors', not all updates may be found");
                            break;
                        case OperationResultCode.orcFailed:
                            Log.Error("[WUPDATE] Updater returned 'failed'");
                            break;
                        case OperationResultCode.orcAborted:
                            Log.Error("[WUPDATE] Updater returned 'aborted', try again later");
                            break;
                    }
                }

                // check if there are warnings we need to log
                if (uResult.Warnings != null && uResult.Warnings.Count > 0)
                {
                    foreach (IUpdateException warning in uResult.Warnings) Log.Warning("[WUPDATE] Updater provided a warning (code: {code}): {msg}", warning.HResult, warning.Message ?? "-");
                }

                // check the update objects
                if (uResult.Updates == null)
                {
                    Log.Error("[WUPDATE] Searching for updates failed, returned null");
                    return updateList;
                }

                if (uResult.Updates.Count == 0)
                {
                    // no updates found
                    return updateList;
                }

                // start processing the updates
                foreach (IUpdate update in uResult.Updates)
                {
                    // prepare the category list
                    var categories = new List<string>();
                    if (update.Categories != null && update.Categories.Count > 0)
                    {
                        for (var i = 0; i < update.Categories.Count; i++) categories.Add(update.Categories[i].Name);
                    }

                    // prepare the kb article list
                    var kbArticleIds = new List<string>();
                    if (update.KBArticleIDs != null && update.KBArticleIDs.Count > 0)
                    {
                        for (var i = 0; i < update.KBArticleIDs.Count; i++) kbArticleIds.Add(update.KBArticleIDs[i]);
                    }

                    // prepare a readble type
                    var type = update.Type == UpdateType.utDriver ? "Driver" : "Software";

                    // fill the update info object
                    var wuInfo = new WindowsUpdateInfo()
                    {
                        Title = update.Title,
                        Description = update.Description,
                        KbArticleIDs = kbArticleIds,
                        Hidden = update.IsHidden,
                        SupportUrl = update.SupportUrl,
                        Type = type,
                        Categories = categories
                    };

                    // add to the list
                    updateList.Add(wuInfo);
                }

                // done
                return updateList;
            }
            catch (Exception ex)
            {
                var stackTrace = ex.StackTrace ?? "";

                Log.Fatal(ex, stackTrace.Contains("WUApiLib")
                        ? "[WUPDATE] Unable to query update status, Windows update seems to be corrupt: {err}"
                        : "[WUPDATE] Error while searching for updates: {err}", ex.Message);

                return new List<WindowsUpdateInfo>();
            }
        }
    }
}
