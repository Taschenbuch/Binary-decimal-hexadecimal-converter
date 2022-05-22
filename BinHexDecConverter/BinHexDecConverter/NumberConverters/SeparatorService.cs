namespace BinHexDecConverter.NumberConverters
{
    public class SeparatorService
    {
        public const string BLANK_AS_SEPARATOR = " ";
        public const int DECIMAL_THOUSAND_GROUP_SIZE = 3;
        public const int HEXADECIMAL_PAIR_SIZE = 2;
        public const int NIBBLE_SIZE = 4;

        public static string RemoveAndAddSeparatorBlanks(string text, int distanceBetweenSeparators)
        {
            if (text.IsNullOrWhiteSpace())
                return string.Empty;

            text = RemoveSeparatorBlanks(text);
            return AddSeparatorBlanks(text, distanceBetweenSeparators);
        }


        public static string RemoveSeparatorBlanks(string text)
        {
            return text.Replace(BLANK_AS_SEPARATOR, string.Empty);
        }
        

        public static string AddSeparatorBlanks(string text, int distanceBetweenSeparators)
        {
            if (text.Length <= distanceBetweenSeparators)
                return text;

            var positionOfLastSeparator = text.Length - distanceBetweenSeparators;

            for (var separatorPosition = positionOfLastSeparator; separatorPosition > 0; separatorPosition -= distanceBetweenSeparators)
                text = text.Insert(separatorPosition, " ");

            return text;
        }
    }
}