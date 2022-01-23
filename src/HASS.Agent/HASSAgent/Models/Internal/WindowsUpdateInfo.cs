using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HASSAgent.Models.Internal
{
    public class WindowsUpdateInfo
    {
        public WindowsUpdateInfo()
        {
            //
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> KbArticleIDs { get; set; }
        public bool Hidden { get; set; }
        public string SupportUrl { get; set; }
        public string Type { get; set; }
        public List<string> Categories { get; set; }
    }
}
