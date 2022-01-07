using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using Serilog;

namespace HASSAgent.Functions
{
    /// <summary>
    /// Source: https://wojciechkulik.pl/csharp/get-a-performancecounter-using-english-name
    /// </summary>
    internal static class PerformanceCounters
    {
        [DllImport("pdh.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern uint PdhLookupPerfNameByIndex(string szMachineName, uint dwNameIndex, StringBuilder szNameBuffer, ref uint pcchNameBufferSize);
        
        /// <summary>
        /// Retrieve the counter based on its English category & -name
        /// </summary>
        /// <param name="englishCategoryName"></param>
        /// <param name="englishCounterName"></param>
        /// <returns></returns>
        internal static PerformanceCounter GetSingleInstanceCounter(string englishCategoryName, string englishCounterName)
        {
            try
            {
                // try first with english names
                return new PerformanceCounter(englishCategoryName, englishCounterName);
            }
            catch
            {
                // too bad
            }

            const string perfCountersKey = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Perflib\009";

            // get list of counters & check them
            if (!(Registry.GetValue(perfCountersKey, "Counter", null) is string[] englishNames)) return null;
            if (!englishNames.Any()) return null;

            // filter the null values
            englishNames = englishNames.Select(x => x).Where(x => !string.IsNullOrEmpty(x)).ToArray();

            // anything left?
            if (!englishNames.Any()) return null;

            // get localized category name
            var localizedCategoryId = FindNameId(englishNames, englishCategoryName);
            var localizedCategoryName = GetNameByIndex(localizedCategoryId);

            // get localized counter name
            var localizedCounterId = FindNameId(englishNames, englishCounterName);
            var localizedCounterName = GetNameByIndex(localizedCounterId);

            return GetCounterIfExists(localizedCategoryName, localizedCounterName) ??
                   GetCounterIfExists(localizedCategoryName, englishCounterName) ??
                   GetCounterIfExists(englishCategoryName, localizedCounterName);
        }

        /// <summary>
        /// Returns the counter if it's found, otherwise null
        /// </summary>
        /// <param name="categoryName"></param>
        /// <param name="counterName"></param>
        /// <returns></returns>
        private static PerformanceCounter GetCounterIfExists(string categoryName, string counterName)
        {
            try
            {
                return new PerformanceCounter(categoryName, counterName);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Retrieve the counter's ID based on its English name
        /// </summary>
        /// <param name="englishNames"></param>
        /// <param name="name"></param>
        /// <returns></returns>

        private static int FindNameId(IReadOnlyList<string> englishNames, string name)
        {
            // englishNames contains alternately id and name, so only check odd lines
            for (var i = 1; i < englishNames.Count; i += 2)
            {
                if (englishNames[i] == name)
                {
                    return int.Parse(englishNames[i - 1]);
                }
            }

            return -1;
        }

        /// <summary>
        /// Retrieve the counter's name based on its ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private static string GetNameByIndex(int id)
        {
            if (id < 0) return null;

            var buffer = new StringBuilder(1024);
            var bufSize = (uint)buffer.Capacity;
            var ret = PdhLookupPerfNameByIndex(null, (uint)id, buffer, ref bufSize);

            return ret == 0 && buffer.Length != 0 ? buffer.ToString() : null;
        }
    }
}
