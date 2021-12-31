using HASSAgent.Controls;

namespace HASSAgent.Models.Internal
{
    public class QuickActionPanelControl
    {
        public QuickActionPanelControl()
        {
            //
        }

        /// <summary>
        /// Disposes the QuickActionControl
        /// </summary>
        public void Dispose() => QuickActionControl?.Dispose();

        public QuickActionControl QuickActionControl { get; set; } = null;
        public int Row { get; set; } = -1;
        public int Column { get; set; } = -1;
    }
}
