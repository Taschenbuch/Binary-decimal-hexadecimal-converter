using System.Text.RegularExpressions;

namespace BinHexDecConverter.Bin2Hex2DecConverters
{
    public class HexadecimalToDecimalService
    {
        public static string HexadecimalToDecimal(string hexadecimalString)
        {
            if (hexadecimalString.IsNullOrWhiteSpace())
                return string.Empty;

            InvalidCharactersExceptionService.ThrowIfRegexMatches(hexadecimalString, new Regex(@"[^0-9A-F\s]", RegexOptions.IgnoreCase), "Only 0-9, A-F and whitespace allowed. Contains not allowed characters:");

            hexadecimalString = SeparatorService.RemoveSeparatorBlanks(hexadecimalString);
            var decimalString = ConvertBaseToBaseService.ConvertFromBaseToBase(hexadecimalString, NumberBase.Hexadecimal, NumberBase.Decimal);

            return SeparatorService.AddSeparatorBlanks(decimalString, 3);
        }
    }
}