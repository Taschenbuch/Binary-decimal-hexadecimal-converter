namespace BinHexDecConverter.NumberConverters
{
    public class DecimalToBinaryService
    {
        public static string DecimalToBinary(string decimalString)
        {
            if (string.IsNullOrWhiteSpace(decimalString))
                return string.Empty;

            InvalidCharactersExceptionService.ThrowIfRegexMatches(decimalString, InvalidCharacterRegexFor.Decimal, "Only 0-9 and whitespace allowed. Contains not allowed characters:");

            decimalString = SeparatorService.RemoveSeparatorBlanks(decimalString);

            var binaryString = ConvertBaseToBaseService.ConvertFromBaseToBase(decimalString, NumberBase.Decimal, NumberBase.Binary);
            binaryString = BinaryService.AddZerosToFillHighestNibbleWithZeros(binaryString);
            return SeparatorService.AddSeparatorBlanks(binaryString, SeparatorService.NIBBLE_SIZE);
        }
    }
}