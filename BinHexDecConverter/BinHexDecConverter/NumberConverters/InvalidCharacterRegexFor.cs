using System.Text.RegularExpressions;

namespace BinHexDecConverter.NumberConverters
{
    public class InvalidCharacterRegexFor
    {
        public static Regex Decimal     { get; set; } = new Regex(@"(?!\s*-?[\d\s]).");
        public static Regex Hexadecimal { get; set; } = new Regex(@"[^0-9A-F\s]", RegexOptions.IgnoreCase);
        public static Regex Binary      { get; set; } = new Regex(@"[^0-1\s]");
    }
}