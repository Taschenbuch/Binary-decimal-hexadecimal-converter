namespace BinHexDecConverter.Bin2Hex2DecConverters
{
    public class HexadecimalToDecimalService
    {
        public static string HexadecimalToDecimal(string hexadecimalString)
        {
            if (hexadecimalString.IsNullOrWhiteSpace())
                return string.Empty;

            hexadecimalString = SeparatorService.RemoveSeparatorBlanks(hexadecimalString);
            var decimalString = ConvertBaseToBaseService.ConvertFromBaseToBase(hexadecimalString, NumberBase.Hexadecimal, NumberBase.Decimal);

            return SeparatorService.AddSeparatorBlanks(decimalString, 3);
        }
    }
}