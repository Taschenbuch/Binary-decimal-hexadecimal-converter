using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BinHexDecConverter.NumberConverters;

namespace BinHexDecConverter
{
    public class NibbleService
    {
        public static ObservableCollection<string> UpdateBitPositionNibbles(string binaryString, ObservableCollection<string> nibblesWithBitPosition)
        {
            if (binaryString.IsNullOrWhiteSpace())
                return ClearNibbles(nibblesWithBitPosition);

            if (InvalidCharacterRegexFor.Binary.IsMatch(binaryString))
                return ClearNibbles(nibblesWithBitPosition);

            var nibbles = SplitIntoNibbles(binaryString);
            nibbles = AdjustBitSpacing(nibbles);

            nibblesWithBitPosition = ClearNibbles(nibblesWithBitPosition);
            return SetNibbles(nibblesWithBitPosition, nibbles);
        }


        private static List<string> AdjustBitSpacing(List<string> nibbles)
        {
            for (var position = 0; position < nibbles.Count; position++)
                nibbles[position] = AdjustBitSpacing(nibbles[position]);

            return nibbles;
        }

        private static string AdjustBitSpacing(string nibble)
        {
            return nibble.Insert(3, "  ")
                         .Insert(2, "  ")
                         .Insert(1, "  ");
        }


        public static ObservableCollection<string> ClearNibbles(ObservableCollection<string> nibblesWithBitPosition)
        {
            for (var position = 0; position < nibblesWithBitPosition.Count; position++)
                nibblesWithBitPosition[position] = string.Empty;

            return nibblesWithBitPosition;
        }


        private static ObservableCollection<string> SetNibbles(ObservableCollection<string> nibblesWithBitPosition, IReadOnlyList<string> nibbles)
        {
            for (var position = 0; position < nibbles.Count; position++)
                nibblesWithBitPosition[position] = nibbles[position];

            return nibblesWithBitPosition;
        }


        private static List<string> SplitIntoNibbles(string binaryString)
        {
            binaryString = SeparatorService.RemoveSeparatorBlanks(binaryString);
            binaryString = BinaryService.AddZerosToFillHighestNibbleWithZeros(binaryString);
            binaryString = SeparatorService.AddSeparatorBlanks(binaryString, 4);

            return binaryString.Split(" ")
                               .Reverse()
                               .ToList();
        }
    }
}