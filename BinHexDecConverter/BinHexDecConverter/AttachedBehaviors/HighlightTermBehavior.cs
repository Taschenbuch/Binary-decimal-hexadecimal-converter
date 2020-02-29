using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

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

            var textParts = SeparateTextIntoTermAndNotTermParts(text, termToBeHighlighted);

            foreach (var part in textParts)
            {
                if (part == termToBeHighlighted)
                    textBlock.Inlines.Add(new Run {Text = part, FontWeight = FontWeights.ExtraBold});
                else
                    textBlock.Inlines.Add(new Run {Text = part, FontWeight = FontWeights.Light});
            }
        }


        public static List<string> SeparateTextIntoTermAndNotTermParts(string text, string term)
        {
            if (text.IsNullOrEmpty())
                return new List<string>() {string.Empty};

            var termPositions = text.AllIndicesOf(term, false)
                                                 .ToList();

            var textParts = new List<string>();
            var nextStartPosition = 0;

            foreach (var termPosition in termPositions)
            {
                textParts = AddNotTermPart(text, nextStartPosition, termPosition, textParts);
                textParts.Add(term);
                nextStartPosition = termPosition + 1;
            }

            textParts = IfTextEndsWithNotTermPartAddIt(text, nextStartPosition, textParts);

            return textParts;
        }

        private static List<string> IfTextEndsWithNotTermPartAddIt(string text, int nextIndex, List<string> textParts)
        {
            var notHighlightedTextPart = text.Substring(nextIndex, text.Length - nextIndex);
            if (TextIsNotEndingWithTerm(notHighlightedTextPart))
                textParts.Add(notHighlightedTextPart);

            return textParts;
        }

        private static List<string> AddNotTermPart(string text, int nextIndex, int termIndex, List<string> textParts)
        {
            if (TermIsAtTextStartOrTermIsRightAfterOtherTerm(nextIndex, termIndex))
                return textParts;

            var notHighlightedTextPart = text.Substring(nextIndex, termIndex - nextIndex);
            if (notHighlightedTextPart != string.Empty)
                textParts.Add(notHighlightedTextPart);

            return textParts;
        }

        private static bool TextIsNotEndingWithTerm(string notHighlightedTextPart)
        {
            return notHighlightedTextPart != string.Empty;
        }

        private static bool TermIsAtTextStartOrTermIsRightAfterOtherTerm(int nextIndex, int termIndex)
        {
            return nextIndex == termIndex;
        }
    }
}