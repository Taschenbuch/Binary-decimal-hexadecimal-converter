using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BinHexDecConverter
{
    public static class Extensions
    {
        public static bool IsNullOrWhiteSpace(this string text)
        {
            return string.IsNullOrWhiteSpace(text);
        }

        public static bool IsEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.Any() == false;
        }
    }
}