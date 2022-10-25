using System.Diagnostics;
using System.Globalization;
using System.Printing;
using CoreAudio;
using HASS.Agent.Models.Internal;
using HASS.Agent.Shared.Functions;
using HASS.Agent.Shared.HomeAssistant.Sensors.GeneralSensors.MultiValue.DataTypes;
using HASS.Agent.Shared.Models.HomeAssistant;
using HASS.Agent.Shared.Models.Internal;
using Newtonsoft.Json;
using Serilog;

namespace HASS.Agent.HomeAssistant.Sensors.GeneralSensors.MultiValue
{
    /// <summary>
    /// Multivalue sensor containing printer-related info
    /// </summary>
    public class PrintersSensors : AbstractMultiValueSensor
    {
        private bool _errorPrinted = false;

        private readonly int _updateInterval;

        public sealed override Dictionary<string, AbstractSingleValueSensor> Sensors { get; protected set; } = new();

        public PrintersSensors(int? updateInterval = null, string name = "printers", string id = default) : base(name ?? "printers", updateInterval ?? 20, id)
        {
            _updateInterval = updateInterval ?? 20;

            UpdateSensorValues();
        }

        public sealed override void UpdateSensorValues()
        {
            try
            {
                // lowercase and safe name of the multivalue sensor
                var parentSensorSafeName = SharedHelperFunctions.GetSafeValue(Name);

                // get the latest printer info
                var printerInfo = GetPrinterInfo();

                // printers count
                var printersCountId = $"{parentSensorSafeName}_printers_count";
                var printersCountSensor = new DataTypeIntSensor(_updateInterval, $"{Name} Printers Count", printersCountId, string.Empty, "mdi:printer", string.Empty, Name);
                printersCountSensor.SetState(printerInfo.PrintQueues.Count);

                if (!Sensors.ContainsKey(printersCountId)) Sensors.Add(printersCountId, printersCountSensor);
                else Sensors[printersCountId] = printersCountSensor;

                // default queue name
                var defaultQueueId = $"{parentSensorSafeName}_default_queue";
                var defaultQueueSensor = new DataTypeStringSensor(_updateInterval, $"{Name} Default Queue", defaultQueueId, string.Empty, "mdi:printer", string.Empty, Name);
                defaultQueueSensor.SetState(printerInfo.DefaultQueue);

                if (!Sensors.ContainsKey(defaultQueueId)) Sensors.Add(defaultQueueId, defaultQueueSensor);
                else Sensors[defaultQueueId] = defaultQueueSensor;

                // default queue jobs
                var defaultQueueJobsId = $"{parentSensorSafeName}_default_queue_jobs";
                var defaultQueueJobsSensor = new DataTypeIntSensor(_updateInterval, $"{Name} Default Queue Jobs", defaultQueueJobsId, string.Empty, "mdi:printer", string.Empty, Name);
                defaultQueueJobsSensor.SetState(printerInfo.DefaultQueueJobs);

                if (!Sensors.ContainsKey(defaultQueueJobsId)) Sensors.Add(defaultQueueJobsId, defaultQueueJobsSensor);
                else Sensors[defaultQueueJobsId] = defaultQueueJobsSensor;

                // all printers
                foreach (var printer in printerInfo.PrintQueues)
                {
                    var printerQueueInfo = JsonConvert.SerializeObject(printer, Formatting.Indented);
                    var printerId = $"{parentSensorSafeName}_{SharedHelperFunctions.GetSafeValue(printer.Name)}";
                    var printerSensor = new DataTypeIntSensor(_updateInterval, $"{Name} {printer.Name}", printerId, string.Empty, "mdi:printer", string.Empty, Name, true);

                    printerSensor.SetState(printer.Jobs);
                    printerSensor.SetAttributes(printerQueueInfo);

                    if (!Sensors.ContainsKey(printerId)) Sensors.Add(printerId, printerSensor);
                    else Sensors[printerId] = printerSensor;
                }

                // optionally reset error flag
                if (_errorPrinted) _errorPrinted = false;
            }
            catch (Exception ex)
            {
                // something went wrong, only print once
                if (_errorPrinted) return;
                _errorPrinted = true;

                Log.Fatal(ex, "[PRINTERS] [{name}] Error while fetching audio info: {err}", Name, ex.Message);
            }
        }

        private PrinterInfo GetPrinterInfo()
        {
            var printerInfo = new PrinterInfo();

            try
            {
                var errors = false;

                try
                {
                    using var localPrintServer = new LocalPrintServer();
                    localPrintServer.Refresh();

                    // fetch the default queue info
                    using var defaultPrintQueue = LocalPrintServer.GetDefaultPrintQueue();
                    defaultPrintQueue.Refresh();

                    printerInfo.DefaultQueue = defaultPrintQueue.Name;
                    printerInfo.DefaultQueueJobs = defaultPrintQueue.NumberOfJobs;

                    // fetch all queues
                    foreach (var queue in localPrintServer.GetPrintQueues())
                    {
                        if (queue == null) continue;

                        try
                        {
                            queue.Refresh();

                            // general info
                            var queueInfo = new PrintQueueInfo
                            {
                                Name = queue.Name,
                                Jobs = queue.NumberOfJobs,
                                Location = queue.Location,
                                Driver = queue.QueueDriver.Name
                            };

                            // jobs
                            using var jobs = queue.GetPrintJobInfoCollection();
                            foreach (var job in jobs)
                            {
                                if (job == null) continue;

                                try
                                {
                                    job.Refresh();

                                    var queueJob = new PrintJobInfo
                                    {
                                        Nmae = job.Name,
                                        Submitter = job.Submitter,
                                        Status = job.JobStatus.ToString(),
                                        NumberOfPages = job.NumberOfPages,
                                        NumberOfPagesPrinted = job.NumberOfPagesPrinted,
                                        PositionInPrintQueue = job.PositionInPrintQueue
                                    };

                                    queueInfo.PrintJobs.Add(queueJob);
                                }
                                catch (Exception ex)
                                {
                                    if (!_errorPrinted) Log.Fatal(ex, "[PRINTERS] [{name}] [{queue}] Exception while retrieving job: {err}", Name, queue.Name ?? "-", ex.Message);
                                    errors = true;
                                }
                                finally
                                {
                                    job.Dispose();
                                }
                            }

                            // status
                            queueInfo.Status = queue.QueueStatus.ToString();
                            queueInfo.AveragePagesPerMinute = queue.AveragePagesPerMinute;
                            queueInfo.HasPaperProblem = queue.HasPaperProblem;
                            queueInfo.IsBusy = queue.IsBusy;
                            queueInfo.IsDoorOpened = queue.IsDoorOpened;
                            queueInfo.IsInError = queue.IsInError;
                            queueInfo.IsInitializing = queue.IsInitializing;
                            queueInfo.IsNotAvailable = queue.IsNotAvailable;
                            queueInfo.IsOffline = queue.IsOffline;
                            queueInfo.IsIOActive = queue.IsIOActive;
                            queueInfo.IsOutOfMemory = queue.IsOutOfMemory;
                            queueInfo.IsOutOfPaper = queue.IsOutOfPaper;
                            queueInfo.IsPaperJammed = queue.IsPaperJammed;
                            queueInfo.IsOutputBinFull = queue.IsOutputBinFull;
                            queueInfo.IsManualFeedRequired = queue.IsManualFeedRequired;
                            queueInfo.IsPaused = queue.IsPaused;
                            queueInfo.IsPendingDeletion = queue.IsPendingDeletion;
                            queueInfo.IsPowerSaveOn = queue.IsPowerSaveOn;
                            queueInfo.IsPrinting = queue.IsPrinting;
                            queueInfo.IsProcessing = queue.IsProcessing;
                            queueInfo.IsPublished = queue.IsPublished;
                            queueInfo.IsQueued = queue.IsQueued;
                            queueInfo.IsTonerLow = queue.IsTonerLow;
                            queueInfo.IsWaiting = queue.IsWaiting;
                            queueInfo.IsWarmingUp = queue.IsWarmingUp;
                            queueInfo.NeedUserIntervention = queue.NeedUserIntervention;
                            queueInfo.PrintingIsCancelled = queue.PrintingIsCancelled;

                            // ready to add
                            printerInfo.PrintQueues.Add(queueInfo);
                        }
                        catch (Exception ex)
                        {
                            if (!_errorPrinted) Log.Fatal(ex, "[PRINTERS] [{name}] [{queue}] Exception while retrieving queue: {err}", Name, queue.Name ?? "-", ex.Message);
                            errors = true;
                        }
                        finally
                        {
                            queue.Dispose();
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (!_errorPrinted) Log.Fatal(ex, "[PRINTERS] [{name}] Exception while retrieving info: {err}", Name, ex.Message);
                    errors = true;
                }

                // only print errors once
                if (errors && !_errorPrinted)
                {
                    _errorPrinted = true;
                    return printerInfo;
                }

                // optionally reset error flag
                if (_errorPrinted) _errorPrinted = false;
            }
            catch (Exception ex)
            {
                // something went wrong, only print once
                if (_errorPrinted) return printerInfo;
                _errorPrinted = true;

                Log.Fatal(ex, "[PRINTERS] [{name}] Fatal exception while getting info: {err}", Name, ex.Message);
            }

            return printerInfo;
        }

        public override DiscoveryConfigModel GetAutoDiscoveryConfig() => null;
    }
}
