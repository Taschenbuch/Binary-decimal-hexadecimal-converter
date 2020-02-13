using System;

namespace BinHexDecConverter.Bin2Hex2DecConverters
{
    public static class ConvertBaseToBaseService
    {
        public static string ConvertFromBaseToBase(string numberString, NumberBase fromNumberBase, NumberBase toNumberBase)
        {
            return Convert.ToString(Convert.ToInt64(numberString, (int) fromNumberBase), (int) toNumberBase);
        }
    }
}