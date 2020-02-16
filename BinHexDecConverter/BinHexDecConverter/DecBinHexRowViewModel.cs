using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BinHexDecConverter.Annotations;
using BinHexDecConverter.Bin2Hex2DecConverters;

namespace BinHexDecConverter
{
    public class DecBinHexRowViewModel : INotifyPropertyChanged
    {


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
                _dec = BinaryToDecimalService.BinaryToDecimal(_binary);
                _hexadecimal = DecimalToHexadecimalService.DecimalToHexadecimal(_dec);
            }
            catch (Exception)
            {
                _dec = "";
                _hexadecimal = "";
                throw;
            }
            OnPropertyChanged(nameof(Dec));
            OnPropertyChanged(nameof(Hexadecimal));
        }


        private void TryConvertToAndSetBinaryAndHexadecimal(string value)
        {
            try
            {
                _dec = value;
                _binary = DecimalToBinaryService.DecimalToBinary(_dec);
                _hexadecimal = DecimalToHexadecimalService.DecimalToHexadecimal(_dec);
            }
            catch (Exception)
            {
                _binary = "";
                _hexadecimal = "";
                throw;
            }
            OnPropertyChanged(nameof(Binary));
            OnPropertyChanged(nameof(Hexadecimal));
        }


        private void TryConvertToAndSetDecimalAndBinary(string value)
        {
            try
            {
                _hexadecimal = value;
                _dec = HexadecimalToDecimalService.HexadecimalToDecimal(_hexadecimal);
                _binary= DecimalToBinaryService.DecimalToBinary(_dec);
            }
            catch (Exception)
            {
                _dec = "";
                _binary = "";
                throw;
            }

            OnPropertyChanged(nameof(Dec));
            OnPropertyChanged(nameof(Binary));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}