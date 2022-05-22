using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using BinHexDecConverter.NumberConverters;
using BinHexDecConverter.Properties;
using PropertyChanged;

namespace BinHexDecConverter
{
    public class DecBinHexRowViewModel : INotifyPropertyChanged
    {
        private readonly MainViewModel _mainViewModel;

        public DecBinHexRowViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            UpdateNumberFormatCommand = new RelayCommand(UpdateNumberFormat);
        }

        public ICommand UpdateNumberFormatCommand { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        public string Comment { get; set; }


        [AlsoNotifyFor(nameof(Binary), nameof(Hexadecimal))]
        public string Dec
        {
            get => _dec;
            set => TryConvertToHexadecimalAndBinaryAndSetColumnsAndBitPositionView(value);
        }


        [AlsoNotifyFor(nameof(Dec), nameof(Hexadecimal))]
        public string Binary
        {
            get => _binary;
            set => TryConvertToDecimalAndHexadecimalAndSetColumnsAndBitPositionView(value);
        }


        [AlsoNotifyFor(nameof(Binary), nameof(Dec))]
        public string Hexadecimal
        {
            get => _hexadecimal;
            set => TryConvertToDecimalAndBinaryAndSetColumnsAndBitPositionView(value);
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
            OnPropertyChanged(nameof(Binary));
            OnPropertyChanged(nameof(Hexadecimal));
            OnPropertyChanged(nameof(Dec));
        }


        #region Private methods

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

        #endregion

        #region Fields

        private string _dec;
        private string _binary;
        private string _hexadecimal;

        #endregion

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}