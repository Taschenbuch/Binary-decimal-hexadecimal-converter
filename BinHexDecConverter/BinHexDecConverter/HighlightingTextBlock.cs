using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace BinHexDecConverter
{
    public class HighlightingTextBlock : TextBlock
    {
        public HighlightingTextBlock()
        {
            TargetUpdated += Tb_TargetUpdated;
        }


        private static void Tb_TargetUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            //e.Handled = true;

            var textBlock = sender as TextBlock;

            if (textBlock.Text.Length == 0)
                return;


            var textBlockText = textBlock.Text;
            var textToBeHighlighted = "11";
            var foundIndices = textBlockText.AllIndicesOf(textToBeHighlighted, false)
                                            .ToList();

            if (foundIndices.IsEmpty())
                return;

            textBlock.Text = string.Empty;
            textBlock.Inlines.Clear();

            var notHighlightedTextPart = string.Empty;
            var startIndex = 0;

            foreach (var foundIndex in foundIndices)
            {
                notHighlightedTextPart = textBlock.Text.Substring(startIndex, foundIndex - startIndex);
                textBlock.Inlines.Add(new Run {Text = notHighlightedTextPart});
                textBlock.Inlines.Add(new Run {Text = textToBeHighlighted, Background = Brushes.Yellow });
                startIndex = foundIndex;
            }

            notHighlightedTextPart = textBlock.Text.Substring(startIndex, foundIndices.Last() - startIndex);
            textBlock.Inlines.Add(new Run { Text = notHighlightedTextPart });
        }


        //if (tb.Text.Length == 0)
        //return;

        //string textUpper  = tb.Text.ToUpper();
        //String toFind     = ((String)e.NewValue).ToUpper();
        //int    firstIndex = textUpper.IndexOf(toFind);
        //String firstStr   = tb.Text.Substring(0, firstIndex);
        //String foundStr   = tb.Text.Substring(firstIndex, toFind.Length);
        //String endStr = tb.Text.Substring(firstIndex + toFind.Length,
        //    tb.Text.Length - (firstIndex + toFind.Length));

        //tb.Inlines.Clear();
        //var run = new Run();
        //run.Text = firstStr;
        //tb.Inlines.Add(run);
        //run            = new Run();
        //run.Background = Brushes.Yellow;
        //run.Text       = foundStr;
        //tb.Inlines.Add(run);
        //run      = new Run();
        //run.Text = endStr;

        //tb.Inlines.Add(run);
    }
}