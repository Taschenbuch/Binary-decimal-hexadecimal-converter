using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using BinHexDecConverter.NumberConverters;
using BinHexDecConverter.Properties;

namespace BinHexDecConverter
{
    public class DecBinHexRowViewModel : PropertyChangedBase
    {
        private readonly MainViewModel _mainViewModel;

        public DecBinHexRowViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            UpdateNumberFormatCommand = new RelayCommand(UpdateNumberFormat);
        }

        public ICommand UpdateNumberFormatCommand { get; set; }
        public string Comment { get; set; }

        public string Dec
        {
            get => _dec;
            set
            {
                TryConvertToHexadecimalAndBinaryAndSetColumnsAndBitPositionView(value);
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(Binary));
                RaisePropertyChanged(nameof(Hexadecimal));
            }
        }

        public string Binary
        {
            get => _binary;
            set
            {
                TryConvertToDecimalAndHexadecimalAndSetColumnsAndBitPositionView(value);
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(Dec));
                RaisePropertyChanged(nameof(Hexadecimal));
            }
        }

        public string Hexadecimal
        {
            get => _hexadecimal;
            set
            {
                TryConvertToDecimalAndBinaryAndSetColumnsAndBitPositionView(value);
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(Binary));
                RaisePropertyChanged(nameof(Dec));
            }
        }

        public void UpdateNumberFormat()
        {
            _binary = SeparatorService.RemoveAndAddSeparatorBlanks(_binary, 4);
            _dec = SeparatorService.RemoveAndAddSeparatorBlanks(_dec, 3);
            _hexadecimal = SeparatorService.RemoveAndAddSeparatorBlanks(_hexadecimal, 2);
            _hexadecimal = _hexadecimal.ToUpper();

            NotifyBinHexDec();
        }

        private void NotifyBinHexDec()
        {
            // necessary because when exception was thrown, fody.notifypropertyChange didnt work anymore
            RaisePropertyChanged(nameof(Binary));
            RaisePropertyChanged(nameof(Hexadecimal));
            RaisePropertyChanged(nameof(Dec));
        }

        private void TryConvertToDecimalAndHexadecimalAndSetColumnsAndBitPositionView(string value)
        {
            try
            {
                _binary = value;
                _dec = BinaryService.BinaryToDecimal(_binary);
                _hexadecimal = DecimalService.ConvertToHexadecimal(_dec);

                _mainViewModel.NibblesWithBitPosition = NibbleService.UpdateBitPositionNibbles(_binary, _mainViewModel.NibblesWithBitPosition);
            }
            catch (Exception)
            {
                _dec = string.Empty;
                _hexadecimal = string.Empty;

                _mainViewModel.NibblesWithBitPosition = NibbleService.ClearNibbles(_mainViewModel.NibblesWithBitPosition);
                NotifyBinHexDec();
                throw;
            }
        }

        private void TryConvertToHexadecimalAndBinaryAndSetColumnsAndBitPositionView(string value)
        {
            try
            {
                _dec = value;
                _binary = DecimalService.ConvertToBinary(_dec);
                _hexadecimal = DecimalService.ConvertToHexadecimal(_dec);

                _mainViewModel.NibblesWithBitPosition = NibbleService.UpdateBitPositionNibbles(_binary, _mainViewModel.NibblesWithBitPosition);
            }
            catch (Exception)
            {
                _binary = string.Empty;
                _hexadecimal = string.Empty;

                _mainViewModel.NibblesWithBitPosition = NibbleService.ClearNibbles(_mainViewModel.NibblesWithBitPosition);
                NotifyBinHexDec();
                throw;
            }
        }

        private void TryConvertToDecimalAndBinaryAndSetColumnsAndBitPositionView(string value)
        {
            try
            {
                _hexadecimal = value;
                _dec = HexadecimalService.ConvertToDecimal(_hexadecimal);
                _binary = DecimalService.ConvertToBinary(_dec);

                _mainViewModel.NibblesWithBitPosition = NibbleService.UpdateBitPositionNibbles(_binary, _mainViewModel.NibblesWithBitPosition);
            }
            catch (Exception)
            {
                _dec = string.Empty;
                _binary = string.Empty;

                _mainViewModel.NibblesWithBitPosition = NibbleService.ClearNibbles(_mainViewModel.NibblesWithBitPosition);
                NotifyBinHexDec();
                throw;
            }
        }

        private string _dec;
        private string _binary;
        private string _hexadecimal;
    }
}