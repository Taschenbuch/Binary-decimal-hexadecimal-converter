namespace BinHexDecConverter.NumberConverters
{
    public class HexadecimalService
    {
        public static string ConvertToDecimal(string hexadecimalString)
        {
            if (hexadecimalString.IsNullOrWhiteSpace())
                return string.Empty;

            InvalidCharactersExceptionService.ThrowIfRegexMatches(hexadecimalString, InvalidCharacterRegexFor.Hexadecimal, "Only 0-9, A-F and whitespace allowed. Contains not allowed characters:");

            hexadecimalString = SeparatorService.RemoveSeparatorBlanks(hexadecimalString);
            var decimalString = ConvertBaseToBaseService.ConvertFromBaseToBase(hexadecimalString, NumberBase.Hexadecimal, NumberBase.Decimal);

            return SeparatorService.AddSeparatorBlanks(decimalString, 3);
        }
    }
}