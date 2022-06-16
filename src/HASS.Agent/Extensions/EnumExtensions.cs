using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HASS.Agent.Extensions
{
    internal static class EnumExtensions
    {
        /// <summary>
        /// Gets the enum based on the enum's member value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumMemberValue"></param>
        /// <returns></returns>
        internal static T EnumMemberToEnum<T>(this string enumMemberValue)
        {
            var enumType = typeof(T);
            foreach (var name in Enum.GetNames(enumType))
            {
                var enumMemberAttribute = (((EnumMemberAttribute[])enumType.GetField(name)?.GetCustomAttributes(typeof(EnumMemberAttribute), true)) ?? Array.Empty<EnumMemberAttribute>()).Single();
                if (enumMemberAttribute.Value == enumMemberValue) return (T)Enum.Parse(enumType, name);
            }

            return default;
        }
    }
}
