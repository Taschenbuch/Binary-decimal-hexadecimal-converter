using System;

namespace BinHexDecConverter.NumberConverters
{
    public class DecimalService
    {
        public static string ConvertToBinary(string decimalString)
        {
            if (decimalString.IsNullOrWhiteSpace())
                return string.Empty;

            InvalidCharactersExceptionService.ThrowIfRegexMatches(decimalString, InvalidCharacterRegexFor.Decimal,
                "Only 0-9 and whitespace allowed. Contains not allowed characters:");

            decimalString = SeparatorService.RemoveSeparatorBlanks(decimalString);

            var binaryString = ConvertBaseToBaseService.ConvertFromBaseToBase(decimalString, NumberBase.Decimal, NumberBase.Binary);
            binaryString = BinaryService.AddZerosToFillHighestNibbleWithZeros(binaryString);
            return SeparatorService.AddSeparatorBlanks(binaryString, SeparatorService.NIBBLE_SIZE);
        }


        public static string ConvertToHexadecimal(string decimalString)
        {
            if (decimalString.IsNullOrWhiteSpace())
                return String.Empty;

            InvalidCharactersExceptionService.ThrowIfRegexMatches(decimalString, InvalidCharacterRegexFor.Decimal,
                "Only 0-9 and whitespace allowed. Contains not allowed characters:");


            decimalString = SeparatorService.RemoveSeparatorBlanks(decimalString);
            var hexadecimalString = ConvertBaseToBaseService.ConvertFromBaseToBase(decimalString, NumberBase.Decimal, NumberBase.Hexadecimal);
            hexadecimalString = hexadecimalString.ToUpper();

            return SeparatorService.AddSeparatorBlanks(hexadecimalString, SeparatorService.HEXADECIMAL_PAIR_SIZE);
        }
    }
}