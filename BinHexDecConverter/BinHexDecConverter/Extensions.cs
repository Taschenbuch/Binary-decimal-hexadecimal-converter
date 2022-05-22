using System;
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

        public static bool IsNullOrEmpty(this string text)
        {
            return string.IsNullOrEmpty(text);
        }

        public static bool IsEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.Any() == false;
        }

        public static IEnumerable<int> AllIndicesOf(this string text, string searchTerm, bool isIgnoringCase)
        {
            if (text == null)
                throw new ArgumentNullException($"null for parameter {nameof(text)} is not allowed");

            if (searchTerm.IsNullOrEmpty())  // because empty searchTerm "" returns a searchIndex == 0 which causes an infinite while(searchTerm != -1 ) loop
                yield break;

            var stringComparison = isIgnoringCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
            var searchIndex = text.IndexOf(searchTerm, 0, stringComparison);

            while (searchIndex != -1)
            {
                yield return searchIndex;
                searchIndex = text.IndexOf(searchTerm, searchIndex + searchTerm.Length, stringComparison);
            }
        }
    }
}
