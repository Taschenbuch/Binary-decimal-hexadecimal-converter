using System;

namespace BinHexDecConverter.NumberConverters
{
    public class BinaryService
    {
        public static string BinaryToDecimal(string binaryString)
        {
            if (binaryString.IsNullOrWhiteSpace())
                return String.Empty;

            InvalidCharactersExceptionService.ThrowIfRegexMatches(binaryString, InvalidCharacterRegexFor.Binary, "Only 1, 0 and whitespace allowed. Contains not allowed characters:");

            binaryString = SeparatorService.RemoveSeparatorBlanks(binaryString);
            var decimalString = ConvertBaseToBaseService.ConvertFromBaseToBase(binaryString, NumberBase.Binary, NumberBase.Decimal);

            return SeparatorService.AddSeparatorBlanks(decimalString, SeparatorService.DECIMAL_THOUSAND_GROUP_SIZE);
        }

        public static string AddZerosToFillHighestNibbleWithZeros(string binaryString)
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