using System;
using BinHexDecConverter.NumberConverters;
using FluentAssertions;
using NUnit.Framework;

namespace BinHexDecConverter.UnitTest
{
    public class Convert_between_hex_bin_dec_Test
    {
        [TestCase("", "")]
        [TestCase(null, "")]
        [TestCase(" 0 ", "0000")]
        [TestCase("0", "0000")]
        [TestCase("1", "0001")]
        [TestCase("8", "1000")]
        [TestCase("16", "0001 0000")]
        [TestCase("32", "0010 0000")]
        [TestCase("128", "1000 0000")]
        [TestCase("256", "0001 0000 0000")]
        [TestCase("1 000", "0011 1110 1000")]
        [TestCase("1 000 000", "1111 0100 0010 0100 0000")]
        [TestCase("1000000", "1111 0100 0010 0100 0000")]
        public void Convert_decimal_to_binary(string decimalString, string expectedBinaryString)
        {
            var result = DecimalService.ConvertToBinary(decimalString);

            result.Should().Be(expectedBinaryString);
        }


        [TestCase("aa", "a")]
        [TestCase("a", "a")]
        [TestCase("9a", "a")]
        [TestCase("a9", "a")]
        [TestCase("9a9", "a")]
        [TestCase("a?+", "a?+")]
        public void Throw_if_not_decimal_input_for_binary(string decimalString, string expectedNotAllowedCharacters)
        {
            Action act = () => DecimalService.ConvertToBinary(decimalString);

            act.Should()
               .Throw<ArgumentOutOfRangeException>()
               .WithMessage($"Only 0-9 and whitespace allowed. Contains not allowed characters: {expectedNotAllowedCharacters}  ");
        }


        [TestCase("", "")]
        [TestCase(null, "")]
        [TestCase(" 0 ", "0")]
        [TestCase("0", "0")]
        [TestCase("10", "2")]
        [TestCase("0000", "0")]
        [TestCase("0010", "2")]
        [TestCase("1000", "8")]
        [TestCase("0001 0000", "16")]
        [TestCase("1000 0000", "128")]
        [TestCase("0001 0000 0000", "256")]
        [TestCase("0011 1110 1000", "1 000")]
        [TestCase("1111 0100 0010 0100 0000", "1 000 000")]
        [TestCase("11110100001001000000", "1 000 000")]
        public void Converter_binary_to_decimal(string binaryString, string expectedDecimalString)
        {
            var result = BinaryService.BinaryToDecimal(binaryString);

            result.Should().Be(expectedDecimalString);
        }

        [TestCase("aa", "a")]
        [TestCase("a", "a")]
        [TestCase("0a", "a")]
        [TestCase("a0", "a")]
        [TestCase("0a0", "a")]
        [TestCase("a=!", "a=!")]
        public void Throw_if_not_binary_input(string binaryString, string expectedNotAllowedCharacters)
        {
            Action act = () => BinaryService.BinaryToDecimal(binaryString);

            act.Should()
               .Throw<ArgumentOutOfRangeException>()
               .WithMessage($"Only 1, 0 and whitespace allowed. Contains not allowed characters: {expectedNotAllowedCharacters}  ");
        }


        [TestCase("", "")]
        [TestCase(null, "")]
        [TestCase(" 0 ", "0")]
        [TestCase("0", "0")]
        [TestCase("15", "F")]
        [TestCase("255", "FF")]
        [TestCase("4 095", "F FF")]
        [TestCase("65 535", "FF FF")]
        [TestCase("1 048 575", "F FF FF")]
        [TestCase("1048575", "F FF FF")]
        [TestCase("-1", "FF FF FF FF FF FF FF FF")]
        [TestCase("-256", "FF FF FF FF FF FF FF 00")]
        [TestCase("-65536", "FF FF FF FF FF FF 00 00")]
        [TestCase("-111111111181111", "FF FF 9A F1 ED AF FC C9")]

        public void Converter_decimal_to_hexadecimal(string decimalString, string expectedHexadecimalString)
        {
            var result = DecimalService.ConvertToHexadecimal(decimalString);

            result.Should().Be(expectedHexadecimalString);
        }

        [TestCase("a", "a")]
        [TestCase("aa", "a")]
        [TestCase("9a", "a")]
        [TestCase("a9", "a")]
        [TestCase("9a9", "a")]
        [TestCase("a?+", "a?+")]
        [TestCase("  - 1 a 0 0 b", "ab")]
        [TestCase("  - 1 a 0 0 -", "a-")]
        public void Throw_if_not_decimal_input_for_hexadecimal(string decimalString, string expectedNotAllowedCharacters)
        {
            Action act = () => DecimalService.ConvertToHexadecimal(decimalString);

            act.Should()
               .Throw<ArgumentOutOfRangeException>()
               .WithMessage($"Only 0-9 and whitespace allowed. Contains not allowed characters: {expectedNotAllowedCharacters}  ");
        }


        [TestCase("", "")]
        [TestCase(null, "")]
        [TestCase(" 0 ", "0")]
        [TestCase("0", "0")]
        [TestCase("F", "15")]
        [TestCase("FF", "255")]
        [TestCase("F FF", "4 095")]
        [TestCase("FF FF", "65 535")]
        [TestCase("F FF FF", "1 048 575")]
        [TestCase("FFFFF", "1 048 575")]
        public void Converter_hexadecimal_to_decimal(string hexadecimalString, string expectedDecimalString)
        {
            var result = HexadecimalService.ConvertToDecimal(hexadecimalString);

            result.Should().Be(expectedDecimalString);
        }


        [TestCase("z", "z")]
        [TestCase("zz", "z")]
        [TestCase("Z", "Z")]
        [TestCase("aZ", "Z")]
        [TestCase("Za", "Z")]
        [TestCase("aZa", "Z")]
        [TestCase("zu?=", "zu?=")]
        public void Throw_if_not_hexadecimal(string hexadecimalString, string expectedNotAllowedCharacters)
        {
            Action act = () => HexadecimalService.ConvertToDecimal(hexadecimalString);

            act.Should()
               .Throw<ArgumentOutOfRangeException>()
               .WithMessage($"Only 0-9, A-F and whitespace allowed. Contains not allowed characters: {expectedNotAllowedCharacters}  ");
        }
    }
}