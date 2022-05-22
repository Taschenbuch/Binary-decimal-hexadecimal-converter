using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace BinHexDecConverter
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private DecBinHexRowViewModel _selectedDecBinHexRowValue;

        public MainViewModel()
        {
            DeleteRowCommand = new RelayCommand(DeleteRow);
            AddEmptyRowCommand = new RelayCommand(AddEmptyRow);

            DecBinHexValues = new ObservableCollection<DecBinHexRowViewModel>() {new DecBinHexRowViewModel(this)};
        }


        private void AddEmptyRow()
        {
            DecBinHexValues.Add(new DecBinHexRowViewModel(this));
        }

        private void DeleteRow()
        {
            RowService.DeleteRow(SelectedDecBinHexRowValue, DecBinHexValues);
            RowService.AddRowIfNoRowIsLeft(DecBinHexValues, this);
        }


        public ICommand DeleteRowCommand { get; set; }
        public ICommand AddEmptyRowCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<string> NibblesWithBitPosition { get; set; } = new ObservableCollection<string>(Enumerable.Repeat(string.Empty, 16));

        public ObservableCollection<DecBinHexRowViewModel> DecBinHexValues { get; set; }

        public string Test { get; set; } = "1 1 2";
        public string Highlight { get; set; } = "1";

        public DecBinHexRowViewModel SelectedDecBinHexRowValue
        {
            get => _selectedDecBinHexRowValue;
            set
            {
                _selectedDecBinHexRowValue = value;

                var noRowIsSelectedOrLastRowIsDeleted = value == null;
                if (noRowIsSelectedOrLastRowIsDeleted)
                    NibblesWithBitPosition = NibbleService.ClearNibbles(NibblesWithBitPosition);

                NibblesWithBitPosition = NibbleService.UpdateBitPositionNibbles(SelectedDecBinHexRowValue.Binary, NibblesWithBitPosition);
            }
        }
    }
}