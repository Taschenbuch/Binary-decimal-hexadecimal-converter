namespace BinHexDecConverter.NumberConverters
{
    public class BinaryService
    {
        public static string AddZerosToFillHighestNibbleWithZeros(string binaryString)
        {
            if (HighestNibbleIsNotMissingZeros(binaryString))
                return binaryString;

            return binaryString.PadLeft(DetermineLengthOfBinaryStringFilledWithZeros(binaryString), '0');

        }


        private static bool HighestNibbleIsNotMissingZeros(string binaryString)
        {
            return binaryString.Length % 4 == 0;
        }

        private static int DetermineLengthOfBinaryStringFilledWithZeros(string binaryString)
        {
            var missingZerosCount = 4 - binaryString.Length % 4;
            return binaryString.Length + missingZerosCount;
        }
    }
}