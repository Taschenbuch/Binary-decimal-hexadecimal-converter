using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace BinHexDecConverter.NumberConverters
{
    public class InvalidCharactersExceptionService
    {
        public static void ThrowIfRegexMatches(string text, Regex regex, string exceptionMessagePrefix)
        {
            if (regex.IsMatch(text))
            {
                var invalidCharactersString = GetStringWithInvalidCharacters(text, regex);
                var exceptionMessage        = $"{exceptionMessagePrefix} {invalidCharactersString}{WHITESPACE_FOR_BETTER_READABILITY_OF_POPUP}";
                throw new ArgumentOutOfRangeException(PREVENT_PARAMETER_NAME_IN_EXCEPTION_MESSAGE, exceptionMessage);
            }
        }


        private static string GetStringWithInvalidCharacters(string text, Regex regex)
        {
            return regex.Matches(text)
                        .Select(m => m.Value)
                        .Distinct()
                        .Aggregate((a, b) => $"{a}{b}");
        }

        private const string PREVENT_PARAMETER_NAME_IN_EXCEPTION_MESSAGE = "";
        private const string WHITESPACE_FOR_BETTER_READABILITY_OF_POPUP = "  ";
    }
}