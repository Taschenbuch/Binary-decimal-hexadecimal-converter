using System;
using System.ComponentModel;
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
            //TargetUpdated += Tb_TargetUpdated;

            var dp = DependencyPropertyDescriptor.FromProperty(
                TextBlock.TextProperty,
                typeof(TextBlock));
            dp.AddValueChanged(HighlightingTextBlock, (sender, args) =>
            {
                MessageBox.Show("text changed");
            });
        }


        private static void Tb_TargetUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            var tb = sender as TextBlock;

            if (tb.Text.Length == 0)
                return;



            string textUpper  = tb.Text.ToUpper();
            String toFind     = "1";
            int    firstIndex = textUpper.IndexOf(toFind, StringComparison.OrdinalIgnoreCase);
            String firstStr   = tb.Text.Substring(0, firstIndex);
            String foundStr   = tb.Text.Substring(firstIndex, toFind.Length);
            String endStr = tb.Text.Substring(firstIndex + toFind.Length,
                tb.Text.Length - (firstIndex + toFind.Length));

            tb.Inlines.Clear();
            var run = new Run();
            run.Text = firstStr;
            tb.Inlines.Add(run);
            run            = new Run();
            run.Background = Brushes.Yellow;
            run.Text       = foundStr;
            tb.Inlines.Add(run);
            run      = new Run();
            run.Text = endStr;

            tb.Inlines.Add(run);



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