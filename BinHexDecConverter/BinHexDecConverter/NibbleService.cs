using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BinHexDecConverter
{
    public class NibbleService
    {
        public static ObservableCollection<string> CreateNibbleArray(ObservableCollection<string> nibblesWithBitPosition, IReadOnlyList<string> nibbles)
        {
            for (var nibbleIndex = 0; nibbleIndex <= 15; nibbleIndex++)
                nibblesWithBitPosition[nibbleIndex] = nibbles.Count > nibbleIndex
                    ? nibbles[nibbleIndex]
                    : string.Empty;

            return nibblesWithBitPosition;
        }

        public static List<string> SplitIntoNibbles(string binaryString)
        {
            return binaryString.Split(" ")
                               .Reverse()
                               .ToList();
        }
    }
}