using System;
using System.ComponentModel;
using BinHexDecConverter.Bin2Hex2DecConverters;

namespace BinHexDecConverter
{
    public class DecBinHexRowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        public string Comment { get; set; }

        private string _dec;

        public string Dec
        {
            get => _dec;
            set => TryConvertToAndSetBinaryAndHexadecimal(value);
        }


        private string _binary;

        public string Binary
        {
            get => _binary;
            set => TryConvertToAndSetDecimalAndHexadecimal(value);
        }


        private string _hexadecimal;

        public string Hexadecimal
        {
            get => _hexadecimal;
            set => TryConvertToAndSetDecimalAndBinary(value);
        }


        private void TryConvertToAndSetDecimalAndHexadecimal(string value)
        {
            try
            {
                _binary = value;
                Dec = BinaryToDecimalService.BinaryToDecimal(_binary);
                Hexadecimal = DecimalToHexadecimalService.DecimalToHexadecimal(_dec);
            }
            catch (Exception)
            {
                Dec = "";
                Hexadecimal = "";
                throw;
            }
        }


        private void TryConvertToAndSetBinaryAndHexadecimal(string value)
        {
            try
            {
                _dec = value;
                Binary = DecimalToBinaryService.DecimalToBinary(_dec);
                Hexadecimal = DecimalToHexadecimalService.DecimalToHexadecimal(_dec);
            }
            catch (Exception)
            {
                Binary = "";
                Hexadecimal = "";
                throw;
            }
        }


        private void TryConvertToAndSetDecimalAndBinary(string value)
        {
            try
            {
                _hexadecimal = value;
                Dec = HexadecimalToDecimalService.HexadecimalToDecimal(_hexadecimal);
                Binary = DecimalToBinaryService.DecimalToBinary(_dec);
            }
            catch (Exception)
            {
                Dec = "";
                Binary = "";
                throw;
            }
        }
    }
}