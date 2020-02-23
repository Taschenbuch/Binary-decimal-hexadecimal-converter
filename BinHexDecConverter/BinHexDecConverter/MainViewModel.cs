using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using BinHexDecConverter.NumberConverters;

namespace BinHexDecConverter
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private DecBinHexRowViewModel _selectedDecBinHexRowValue;

        public MainViewModel()
        {
            DeleteRowCommand                      = new RelayCommand(DeleteRow);
            AddEmptyRowCommand                    = new RelayCommand(AddEmptyRow);
            SetNibblesInBitPositionSectionCommand = new RelayCommand(SetNibblesInBitPositionSection);
        }


        private void AddEmptyRow()
        {
            DecBinHexValues.Add(new DecBinHexRowViewModel());
        }

        private void DeleteRow()
        {
            RowService.DeleteRow(SelectedDecBinHexRowValue, DecBinHexValues);
            RowService.AddRowIfNoRowIsLeft(DecBinHexValues);
        }

        private void SetNibblesInBitPositionSection()
        {
            var binaryString = SelectedDecBinHexRowValue.Binary;
            if (binaryString.IsNullOrWhiteSpace())
                return;

            binaryString = SeparatorService.RemoveSeparatorBlanks(binaryString);
            binaryString = SeparatorService.AddSeparatorBlanks(binaryString, 4);
            var nibbles = NibbleService.SplitIntoNibbles(binaryString);
            NibblesWithBitPosition = NibbleService.CreateNibbleArray(NibblesWithBitPosition, nibbles);
        }


        public ICommand DeleteRowCommand                      { get; set; }
        public ICommand AddEmptyRowCommand                    { get; set; }
        public ICommand SetNibblesInBitPositionSectionCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<string> NibblesWithBitPosition { get; set; } = new ObservableCollection<string>(new string[16]);

        public ObservableCollection<DecBinHexRowViewModel> DecBinHexValues { get; set; } =
            new ObservableCollection<DecBinHexRowViewModel>() {new DecBinHexRowViewModel()};

        public DecBinHexRowViewModel SelectedDecBinHexRowValue
        {
            get => _selectedDecBinHexRowValue;
            set
            {
                _selectedDecBinHexRowValue = value;

                if (value == null)
                    return;

                SetNibblesInBitPositionSection();
            }
        }
    }
}