using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace BinHexDecConverter
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            DeleteRowCommand          = new RelayCommand(DeleteRow);
            AddEmptyRowCommand        = new RelayCommand(AddEmptyRow);
            UpdateNumberFormatCommand = new RelayCommand(UpdateNumberFormat);
        }

        private void UpdateNumberFormat()
        {
            foreach (var decBinHexValue in DecBinHexValues)
                decBinHexValue.UpdateNumberFormat();
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


        public ICommand UpdateNumberFormatCommand { get; set; }
        public ICommand DeleteRowCommand          { get; set; }
        public ICommand AddEmptyRowCommand        { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<DecBinHexRowViewModel> DecBinHexValues { get; set; } = new ObservableCollection<DecBinHexRowViewModel>() {new DecBinHexRowViewModel()};

        public DecBinHexRowViewModel SelectedDecBinHexRowValue { get; set; }
    }
}