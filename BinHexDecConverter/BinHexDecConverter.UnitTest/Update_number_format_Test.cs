using BinHexDecConverter.NumberConverters;
using FluentAssertions;
using NUnit.Framework;

namespace BinHexDecConverter.UnitTest
{
    [TestFixture]
    public class Update_number_format_Test
    {
        [TestCase(null, "")]
        [TestCase("", "")]
        [TestCase("1", "1")]
        [TestCase("11111", "1 1111")]
        public void Update_number_format(string oldFormattedNumber, string expectedNumberFormat)
        {
            var result = SeparatorService.RemoveAndAddSeparatorBlanks(oldFormattedNumber, 4);
            result.Should().Be(expectedNumberFormat);
        }
    }
}