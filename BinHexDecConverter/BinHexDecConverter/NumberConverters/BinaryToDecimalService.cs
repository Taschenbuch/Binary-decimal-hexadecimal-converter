using System;
using System.Text.RegularExpressions;

namespace BinHexDecConverter.Bin2Hex2DecConverters
{
    public static class BinaryToDecimalService
    {

        public static string BinaryToDecimal(string binaryString)
        {
            ContainsNonBinaryValue(binaryString);

            if (binaryString.IsNullOrWhiteSpace())
                return string.Empty;

            binaryString = SeparatorService.RemoveSeparatorBlanks(binaryString);
            var decimalString = ConvertBaseToBaseService.ConvertFromBaseToBase(binaryString, NumberBase.Binary, NumberBase.Decimal);

            return SeparatorService.AddSeparatorBlanks(decimalString, SeparatorService.DECIMAL_THOUSAND_GROUP_SIZE);
        }

        private static bool ContainsNonBinaryValue(string binaryString)
        {
            Regex regex = new Regex(@"[^0-1\s]");
            return regex.IsMatch(binaryString));
        }
    }
}