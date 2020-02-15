using System.Text.RegularExpressions;

namespace BinHexDecConverter.Bin2Hex2DecConverters
{
    public class DecimalToHexadecimalService
    {

        public static string DecimalToHexadecimal(string decimalString)
        {
            if (decimalString.IsNullOrWhiteSpace())
                return string.Empty;

            InvalidCharactersExceptionService.ThrowIfRegexMatches(decimalString, new Regex(@"[^0-9\s]"), "Only 0-9 and whitespace allowed. Contains not allowed characters:");


            decimalString = SeparatorService.RemoveSeparatorBlanks(decimalString);
            var hexadecimalString = ConvertBaseToBaseService.ConvertFromBaseToBase(decimalString, NumberBase.Decimal, NumberBase.Hexadecimal);
            hexadecimalString = hexadecimalString.ToUpper();

            return SeparatorService.AddSeparatorBlanks(hexadecimalString, SeparatorService.HEXADECIMAL_PAIR_SIZE);
        }
    }
}