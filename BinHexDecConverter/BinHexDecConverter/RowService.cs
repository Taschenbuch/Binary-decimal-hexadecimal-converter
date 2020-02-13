using System.Collections.ObjectModel;

namespace BinHexDecConverter
{
    public class RowService
    {
        public static void AddRowIfNoRowIsLeft(ObservableCollection<DecBinHexRowViewModel> decBinHexValues)
        {
            if (decBinHexValues.IsEmpty())
                decBinHexValues.Add(new DecBinHexRowViewModel());
        }


        public static void DeleteRow(DecBinHexRowViewModel selectedDecBinHexRowValue, ObservableCollection<DecBinHexRowViewModel> decBinHexValues)
        {
            var rowIsSelected = selectedDecBinHexRowValue != null;
            if (rowIsSelected)
                decBinHexValues.Remove(selectedDecBinHexRowValue);
        }
    }
}