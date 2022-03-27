using Octokit;

namespace HASSAgent.Models.Internal
{
    public class PendingUpdate
    {
        public PendingUpdate()
        {
            //
        }

        public string Version { get; set; } = string.Empty;
        public string ReleaseUrl { get; set; } = string.Empty;
        public string ReleaseNotes { get; set; } = string.Empty;
        public string InstallerUrl { get; set; } = string.Empty;
        public bool IsBeta { get; set; }
        public Release GitHubRelease { get; set; } = null;
    }
}
