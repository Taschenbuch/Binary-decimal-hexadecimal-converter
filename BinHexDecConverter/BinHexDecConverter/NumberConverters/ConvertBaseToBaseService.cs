using System;

namespace BinHexDecConverter.NumberConverters
{
    public static class ConvertBaseToBaseService
    {
        public static string ConvertFromBaseToBase(string numberString, NumberBase fromNumberBase, NumberBase toNumberBase)
        {
            try
            {
                return Convert.ToString(Convert.ToInt64(numberString, (int)fromNumberBase), (int)toNumberBase);
            }
            catch (Exception)
            {
                throw new OverflowException("Number is too big. Max 64 bit is allowed");
            }
        }
    }
}