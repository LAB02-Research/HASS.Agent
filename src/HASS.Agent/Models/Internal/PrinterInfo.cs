using System.Diagnostics.CodeAnalysis;
using System.Printing;

namespace HASS.Agent.Models.Internal
{
    public class PrinterInfo
    {
        public PrinterInfo()
        {
            //
        }

        public string DefaultQueue { get; set; } = string.Empty;
        public int DefaultQueueJobs { get; set; } = 0;

        public List<PrintQueueInfo> PrintQueues { get; set; } = new();
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class PrintQueueInfo
    {
        public PrintQueueInfo()
        {
            //
        }

        public string Name { get; set; } = string.Empty;
        public int Jobs { get; set; } = 0;
        public string Location { get; set; } = string.Empty;
        public string Driver { get; set; } = string.Empty;

        public List<PrintJobInfo> PrintJobs { get; set; } = new();

        public string Status { get; set; } = "None";
        public int AveragePagesPerMinute { get; set; } = 0;
        public bool HasPaperProblem { get; set; }
        public bool IsBusy { get; set; }
        public bool IsDoorOpened { get; set; }
        public bool IsInError { get; set; }
        public bool IsInitializing { get; set; }
        public bool IsNotAvailable { get; set; }
        public bool IsOffline { get; set; }
        public bool IsIOActive { get; set; }
        public bool IsOutOfMemory { get; set; }
        public bool IsOutOfPaper { get; set; }
        public bool IsPaperJammed { get; set; }
        public bool IsOutputBinFull { get; set; }
        public bool IsManualFeedRequired { get; set; }
        public bool IsPaused { get; set; }
        public bool IsPendingDeletion { get; set; }
        public bool IsPowerSaveOn { get; set; }
        public bool IsPrinting { get; set; }
        public bool IsProcessing { get; set; }
        public bool IsPublished { get; set; }
        public bool IsQueued { get; set; }
        public bool IsTonerLow { get; set; }
        public bool IsWaiting { get; set; }
        public bool IsWarmingUp { get; set; }
        public bool NeedUserIntervention { get; set; }
        public bool PrintingIsCancelled { get; set; }
    }

    public class PrintJobInfo
    {
        public PrintJobInfo()
        {
            //
        }

        public string Nmae { get; set; } = string.Empty;
        public string Submitter { get; set; } = string.Empty;
        public string Status { get; set; } = "None";
        public int NumberOfPages { get; set; } = 0;
        public int NumberOfPagesPrinted { get; set; } = 0;
        public int PositionInPrintQueue { get; set; } = 0;
    }
}
