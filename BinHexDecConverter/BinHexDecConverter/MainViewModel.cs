using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
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
            var nibbles = binaryString.Split(" ")
                                      .Reverse()
                                      .ToList();


            if (nibbles.Count >= 16)
                Bit63To60 = nibbles[15];

            if (nibbles.Count >= 15)
                Bit59To56 = nibbles[14];

            if (nibbles.Count >= 14)
                Bit55To52 = nibbles[13];

            if (nibbles.Count >= 13)
                Bit51To48 = nibbles[12];

            if (nibbles.Count >= 12)
                Bit47To44 = nibbles[11];

            if (nibbles.Count >= 11)
                Bit43To40 = nibbles[10];

            if (nibbles.Count >= 10)
                Bit39To36 = nibbles[9];

            if (nibbles.Count >= 9)
                Bit35To32 = nibbles[8];

            if (nibbles.Count >= 8)
                Bit31To28 = nibbles[7];

            if (nibbles.Count >= 7)
                Bit27To24 = nibbles[6];

            if (nibbles.Count >= 6)
                Bit23To20 = nibbles[5];

            if (nibbles.Count >= 5)
                Bit19To16 = nibbles[4];

            if (nibbles.Count >= 4)
                Bit15To12 = nibbles[3];

            if (nibbles.Count >= 3)
                Bit11To8 = nibbles[2];

            if (nibbles.Count >= 2)
                Bit7To4 = nibbles[1];

            if (nibbles.Count >= 1)
                Bit3To0 = nibbles[0];
        }

        public string Bit63To60 { get; set; }
        public string Bit59To56 { get; set; }
        public string Bit55To52 { get; set; }
        public string Bit51To48 { get; set; }
        public string Bit47To44 { get; set; }
        public string Bit43To40 { get; set; }
        public string Bit39To36 { get; set; }
        public string Bit35To32 { get; set; }
        public string Bit31To28 { get; set; }
        public string Bit27To24 { get; set; }
        public string Bit23To20 { get; set; }
        public string Bit19To16 { get; set; }
        public string Bit15To12 { get; set; }
        public string Bit11To8  { get; set; }
        public string Bit7To4   { get; set; }
        public string Bit3To0   { get; set; }


        public ICommand DeleteRowCommand                      { get; set; }
        public ICommand AddEmptyRowCommand                    { get; set; }
        public ICommand SetNibblesInBitPositionSectionCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

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