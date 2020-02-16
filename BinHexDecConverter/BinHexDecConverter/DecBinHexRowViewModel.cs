using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BinHexDecConverter.Annotations;
using BinHexDecConverter.NumberConverters;
using PropertyChanged;

namespace BinHexDecConverter
{
    public class DecBinHexRowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string                            Comment { get; set; }


        [AlsoNotifyFor(nameof(Binary), nameof(Hexadecimal))]
        public string Dec
        {
            get => _dec;
            set => TryConvertToAndSetBinaryAndHexadecimal(value);
        }


        [AlsoNotifyFor(nameof(Dec), nameof(Hexadecimal))]
        public string Binary
        {
            get => _binary;
            set => TryConvertToAndSetDecimalAndHexadecimal(value);
        }


        [AlsoNotifyFor(nameof(Binary), nameof(Dec))]
        public string Hexadecimal
        {
            get => _hexadecimal;
            set => TryConvertToAndSetDecimalAndBinary(value);
        }

        #region Private methods

        private void TryConvertToAndSetDecimalAndHexadecimal(string value)
        {
            try
            {
                _binary      = value;
                _dec         = BinaryToDecimalService.BinaryToDecimal(_binary);
                _hexadecimal = DecimalToHexadecimalService.DecimalToHexadecimal(_dec);
            }
            catch (Exception)
            {
                _dec         = string.Empty;
                _hexadecimal = string.Empty;
                throw;
            }
        }


        private void TryConvertToAndSetBinaryAndHexadecimal(string value)
        {
            try
            {
                _dec         = value;
                _binary      = DecimalToBinaryService.DecimalToBinary(_dec);
                _hexadecimal = DecimalToHexadecimalService.DecimalToHexadecimal(_dec);
            }
            catch (Exception)
            {
                _binary      = string.Empty;
                _hexadecimal = string.Empty;
                throw;
            }
        }


        private void TryConvertToAndSetDecimalAndBinary(string value)
        {
            try
            {
                _hexadecimal = value;
                _dec         = HexadecimalToDecimalService.HexadecimalToDecimal(_hexadecimal);
                _binary      = DecimalToBinaryService.DecimalToBinary(_dec);
            }
            catch (Exception)
            {
                _dec    = string.Empty;
                _binary = string.Empty;
                throw;
            }
        }

        #endregion

        #region Fields

        private string _dec;
        private string _binary;
        private string _hexadecimal;

        #endregion

        public void UpdateNumberFormat()
        {
            _binary      = SeparatorService.RemoveAndAddSeparatorBlanks(_binary, 4);
            _dec         = SeparatorService.RemoveAndAddSeparatorBlanks(_dec, 3);
            _hexadecimal = SeparatorService.RemoveAndAddSeparatorBlanks(_hexadecimal, 2);

            OnPropertyChanged(nameof(Binary));
            OnPropertyChanged(nameof(Hexadecimal));
            OnPropertyChanged(nameof(Dec));
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}