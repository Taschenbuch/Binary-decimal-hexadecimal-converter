using System.Collections.ObjectModel;

namespace BinHexDecConverter
{
    public class RowService
    {
        public static void AddRowIfNoRowIsLeft(ObservableCollection<DecBinHexRowViewModel> decBinHexValues, MainViewModel mainViewModel)
        {
            if (decBinHexValues.IsEmpty())
                decBinHexValues.Add(new DecBinHexRowViewModel(mainViewModel));
        }


        public static void DeleteRow(DecBinHexRowViewModel selectedDecBinHexRowValue, ObservableCollection<DecBinHexRowViewModel> decBinHexValues)
        {
            var rowIsSelected = selectedDecBinHexRowValue != null;
            if (rowIsSelected)
                decBinHexValues.Remove(selectedDecBinHexRowValue);
        }
    }
}