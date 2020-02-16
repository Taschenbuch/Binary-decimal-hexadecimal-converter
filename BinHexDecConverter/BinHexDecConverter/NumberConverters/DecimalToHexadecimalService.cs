namespace BinHexDecConverter.NumberConverters
{
    public class DecimalToHexadecimalService
    {

        public static string DecimalToHexadecimal(string decimalString)
        {
            if (decimalString.IsNullOrWhiteSpace())
                return string.Empty;

            InvalidCharactersExceptionService.ThrowIfRegexMatches(decimalString, InvalidCharacterRegexFor.Decimal, "Only 0-9 and whitespace allowed. Contains not allowed characters:");


            decimalString = SeparatorService.RemoveSeparatorBlanks(decimalString);
            var hexadecimalString = ConvertBaseToBaseService.ConvertFromBaseToBase(decimalString, NumberBase.Decimal, NumberBase.Hexadecimal);
            hexadecimalString = hexadecimalString.ToUpper();

            return SeparatorService.AddSeparatorBlanks(hexadecimalString, SeparatorService.HEXADECIMAL_PAIR_SIZE);
        }
    }
}