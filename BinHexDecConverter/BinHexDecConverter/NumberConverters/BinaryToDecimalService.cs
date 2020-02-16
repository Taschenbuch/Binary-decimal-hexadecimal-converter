
using System.Text.RegularExpressions;

namespace BinHexDecConverter.NumberConverters
{
    public static class BinaryToDecimalService
    {

        public static string BinaryToDecimal(string binaryString)
        {
            if (binaryString.IsNullOrWhiteSpace())
                return string.Empty;

            InvalidCharactersExceptionService.ThrowIfRegexMatches(binaryString, new Regex(@"[^0-1\s]"), "Only 1, 0 and whitespace allowed. Contains not allowed characters:");

            binaryString = SeparatorService.RemoveSeparatorBlanks(binaryString);
            var decimalString = ConvertBaseToBaseService.ConvertFromBaseToBase(binaryString, NumberBase.Binary, NumberBase.Decimal);

            return SeparatorService.AddSeparatorBlanks(decimalString, SeparatorService.DECIMAL_THOUSAND_GROUP_SIZE);
        }


    
    }
}