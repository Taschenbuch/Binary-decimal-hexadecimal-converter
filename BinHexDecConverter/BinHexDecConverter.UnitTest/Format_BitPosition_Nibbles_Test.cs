using System.Collections.ObjectModel;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace BinHexDecConverter.UnitTest
{
    public class Format_BitPosition_Nibbles_Test
    {
        [TestCase(
            "a",
            new[]
            {
                "", "", "", "",
                "", "", "", "",
                "", "", "", "",
                "", "", "", ""
            }
        )]
        [TestCase(
            "",
            new[]
            {
                "", "", "", "",
                "", "", "", "",
                "", "", "", "",
                "", "", "", ""
            }
        )]
        [TestCase(
            "1",
            new[]
            {
                "0  0  0  1", "", "", "",
                "", "", "", "",
                "", "", "", "",
                "", "", "", ""
            }
        )]
        [TestCase(
            "111",
            new[]
            {
                "0  1  1  1", "", "", "",
                "", "", "", "",
                "", "", "", "",
                "", "", "", ""
            }
        )]
        [TestCase(
            "1111",
            new[]
            {
                "1  1  1  1", "", "", "",
                "", "", "", "",
                "", "", "", "",
                "", "", "", ""
            }
        )]
        [TestCase(
            "11111111",
            new[]
            {
                "1  1  1  1", "1  1  1  1", "", "",
                "", "", "", "",
                "", "", "", "",
                "", "", "", ""
            }
        )]
        [TestCase(
            "1111111111111111111111111111111111111111111111111111111111111111",
            new[]
            {
                "1  1  1  1", "1  1  1  1", "1  1  1  1", "1  1  1  1",
                "1  1  1  1", "1  1  1  1", "1  1  1  1", "1  1  1  1",
                "1  1  1  1", "1  1  1  1", "1  1  1  1", "1  1  1  1",
                "1  1  1  1", "1  1  1  1", "1  1  1  1", "1  1  1  1"
            }
        )]
        public void Format_BitPosition_Nibbles(string binaryString, string[] expectedBitPositionNibbles)
        {
            var bitPositionNibbles = CreateOldBitPositionNibbles();

            bitPositionNibbles = NibbleService.UpdateBitPositionNibbles(binaryString, bitPositionNibbles);

            bitPositionNibbles.Should().HaveCount(expectedBitPositionNibbles.Length);
            bitPositionNibbles.Should().ContainInOrder(expectedBitPositionNibbles);
        }

        private static ObservableCollection<string> CreateOldBitPositionNibbles()
        {
            var bitPositionNibbles = new ObservableCollection<string>(Enumerable.Repeat(string.Empty, 16));
            return bitPositionNibbles;
        }
    }
}