using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HASS.Agent.Models.Internal
{
    public class WebViewInfo
    {
        public WebViewInfo()
        {
            //
        }

        public string Url { get; set; }

        public bool ShowTitleBar { get; set; } = true;
        public bool CenterScreen { get; set; } = true;
        public bool TopMost { get; set; } = true;

        public bool IsTrayIconWebView { get; set; } = false;
        public bool IsTrayIconPreview { get; set; } = false;

        public int X { get; set; } = -1;
        public int Y { get; set; } = -1;
        public int Width { get; set; } = 1018;
        public int Height { get; set; } = 723;
    }
}
