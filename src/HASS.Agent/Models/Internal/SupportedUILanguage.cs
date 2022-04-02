using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HASS.Agent.Models.Internal
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class SupportedUILanguage
    {
        public SupportedUILanguage()
        {
            //
        }

        public SupportedUILanguage(CultureInfo cultureInfo)
        {
            Culture = cultureInfo;
            Name = cultureInfo.Name;
            DisplayName = cultureInfo.EnglishName;
        }

        public CultureInfo Culture { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
    }
}
