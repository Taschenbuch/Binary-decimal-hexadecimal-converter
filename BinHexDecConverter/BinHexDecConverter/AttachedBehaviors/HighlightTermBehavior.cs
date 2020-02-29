using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace BinHexDecConverter.AttachedBehaviors
{
    // Sources:


    public static class HighlightTermBehavior
    {
        public static readonly DependencyProperty TextProperty = DependencyProperty.RegisterAttached(
            "Text",
            typeof(string),
            typeof(HighlightTermBehavior),
            new FrameworkPropertyMetadata("", OnTextChanged));

        public static string GetText(FrameworkElement frameworkElement)               => (string) frameworkElement.GetValue(TextProperty);
        public static void   SetText(FrameworkElement frameworkElement, string value) => frameworkElement.SetValue(TextProperty, value);


        public static readonly DependencyProperty TermToBeHighlightedProperty = DependencyProperty.RegisterAttached(
            "TermToBeHighlighted",
            typeof(string),
            typeof(HighlightTermBehavior),
            new FrameworkPropertyMetadata("", OnTextChanged));

        public static string GetTermToBeHighlighted(FrameworkElement frameworkElement)               => (string) frameworkElement.GetValue(TermToBeHighlightedProperty);
        public static void   SetTermToBeHighlighted(FrameworkElement frameworkElement, string value) => frameworkElement.SetValue(TermToBeHighlightedProperty, value);


        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TextBlock textBlock)
                SetTextBoxAndHighlightTerm(textBlock, GetText(textBlock), GetTermToBeHighlighted(textBlock));
        }

        private static void SetTextBoxAndHighlightTerm(TextBlock textBlock, string text, string termToBeHighlighted)
        {
            textBlock.Text = text;

            if (text.Length == 0)
                return;

            var foundIndices = text.AllIndicesOf(termToBeHighlighted, false)
                                   .ToList();

            if (foundIndices.IsEmpty())
                return;

            textBlock.Text = string.Empty;
            textBlock.Inlines.Clear();

            var textParts = SplitTextIntoTermAndNotTermParts(text, termToBeHighlighted);

            foreach (var part in textParts)
            {
                if (part == termToBeHighlighted)
                    textBlock.Inlines.Add(new Run {Text = part, FontWeight = FontWeights.ExtraBold});
                else
                    textBlock.Inlines.Add(new Run {Text = part, FontWeight = FontWeights.Light});
            }
        }


        public static List<string> SplitTextIntoTermAndNotTermParts(string text, string term)
        {
            if (text.IsNullOrEmpty())
                return new List<string>() { string.Empty };

            return Regex.Split(text, $@"({Regex.Escape(term)})")
                                                          .Where(p => p != string.Empty)
                                                          .ToList();
        }
    }
}