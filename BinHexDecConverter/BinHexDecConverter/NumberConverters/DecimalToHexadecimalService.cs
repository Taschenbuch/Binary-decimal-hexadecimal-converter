namespace BinHexDecConverter.Bin2Hex2DecConverters
{
    public class DecimalToHexadecimalService
    {

        public static string DecimalToHexadecimal(string decimalString)
        {
            if (decimalString.IsNullOrWhiteSpace())
                return string.Empty;

            decimalString = SeparatorService.RemoveSeparatorBlanks(decimalString);
            var hexadecimalString = ConvertBaseToBaseService.ConvertFromBaseToBase(decimalString, NumberBase.Decimal, NumberBase.Hexadecimal);
            hexadecimalString = hexadecimalString.ToUpper();

            return SeparatorService.AddSeparatorBlanks(hexadecimalString, SeparatorService.HEXADECIMAL_PAIR_SIZE);
        }
    }
}