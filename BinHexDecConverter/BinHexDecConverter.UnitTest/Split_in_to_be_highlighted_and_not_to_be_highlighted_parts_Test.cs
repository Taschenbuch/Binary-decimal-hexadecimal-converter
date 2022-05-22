using BinHexDecConverter.AttachedBehaviors;
using FluentAssertions;
using NUnit.Framework;

namespace BinHexDecConverter.UnitTest
{
    public class Split_in_to_be_highlighted_and_not_to_be_highlighted_parts_Test
    {
        [TestCase("", new[] { "" })]
        [TestCase("0", new[] { "0" })]
        [TestCase("00", new[] { "00" })]
        [TestCase("01", new[] { "0", "1" })]
        [TestCase("001", new[] { "00", "1" })]
        [TestCase("10", new[] { "1", "0" })]
        [TestCase("100", new[] { "1", "00" })]
        [TestCase("010", new[] { "0", "1", "0" })]
        [TestCase("00100", new[] { "00", "1", "00" })]
        [TestCase("1", new[] { "1" })]
        [TestCase("1111", new[] { "1", "1", "1", "1" })]
        [TestCase("1  1  1  1", new[] { "1", "  ", "1", "  ", "1", "  ", "1" })]
        public void Split_in_to_be_highlighted_and_not_to_be_highlighted_parts(string inputText, string [] expectedTextParts)
        {
            var textParts = HighlightTermBehavior.SplitTextIntoTermAndNotTermParts(inputText, "1");

            textParts.Should().BeEquivalentTo(expectedTextParts);
        }

    }
}