using System.Text.RegularExpressions;

namespace BinHexDecConverter.Bin2Hex2DecConverters
{
    public class DecimalToBinaryService
    {
        public static string DecimalToBinary(string decimalString)
        {
            if (string.IsNullOrWhiteSpace(decimalString))
                return string.Empty;

            InvalidCharactersExceptionService.ThrowIfRegexMatches(decimalString, new Regex(@"[^0-9\s]"), "Only 0-9 and whitespace allowed. Contains not allowed characters:");

            decimalString = SeparatorService.RemoveSeparatorBlanks(decimalString);

            var binaryString = ConvertBaseToBaseService.ConvertFromBaseToBase(decimalString, NumberBase.Decimal, NumberBase.Binary);
            binaryString = AddZerosToFillHighestNibbleWithZeros(binaryString);
            return SeparatorService.AddSeparatorBlanks(binaryString, SeparatorService.NIBBLE_SIZE);
        }


        private static string AddZerosToFillHighestNibbleWithZeros(string binaryString)
        {
            if (HighestNibbleIsNotMissingZeros(binaryString))
                return binaryString;

            return binaryString.PadLeft(DetermineLengthOfBinaryStringFilledWithZeros(binaryString), '0');

        }


        private static bool HighestNibbleIsNotMissingZeros(string binaryString)
        {
            return binaryString.Length % 4 == 0;
        }

        private static int DetermineLengthOfBinaryStringFilledWithZeros(string binaryString)
        {
            var missingZerosCount = 4 - binaryString.Length % 4;
            return binaryString.Length + missingZerosCount;
        }
    }
}