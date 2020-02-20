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


        public ICommand DeleteRowCommand          { get; set; }
        public ICommand AddEmptyRowCommand        { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<DecBinHexRowViewModel> DecBinHexValues { get; set; } = new ObservableCollection<DecBinHexRowViewModel>() {new DecBinHexRowViewModel()};

        public DecBinHexRowViewModel SelectedDecBinHexRowValue { get; set; }
    }
}