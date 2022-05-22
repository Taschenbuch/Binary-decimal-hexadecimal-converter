using System;
using System.Globalization;
using System.Security;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;

namespace BinHexDecConverter.Converters
{
    // todo obsolete
    // source https://stackoverflow.com/a/22026985/4394435

    class HighlightTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string input = value as string;
            if (input != null)
            {
                var textBlock = new TextBlock();
                textBlock.TextWrapping = TextWrapping.Wrap;
                string escapedXml = SecurityElement.Escape(input);

                while (escapedXml.IndexOf("|~S~|") != -1)
                {
                    //up to |~S~| is normal
                    textBlock.Inlines.Add(new Run(escapedXml.Substring(0, escapedXml.IndexOf("|~S~|"))));
                    //between |~S~| and |~E~| is highlighted
                    textBlock.Inlines.Add(new Run(escapedXml.Substring(escapedXml.IndexOf("|~S~|") + 5,
                            escapedXml.IndexOf("|~E~|") - (escapedXml.IndexOf("|~S~|") + 5)))
                        { FontWeight = FontWeights.Bold, Foreground = Brushes.Red });
                    //the rest of the string (after the |~E~|)
                    escapedXml = escapedXml.Substring(escapedXml.IndexOf("|~E~|") + 5);
                }

                if (escapedXml.Length > 0)
                {
                    textBlock.Inlines.Add(new Run(escapedXml));
                }
                return textBlock;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("This converter cannot be used in two-way binding.");
        }

    }
}