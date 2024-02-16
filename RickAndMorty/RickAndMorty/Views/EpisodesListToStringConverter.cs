using System;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;

namespace RickAndMorty.Views
{
    public class EpisodesListToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string[] urls)
            {
                return string.Join(", ", urls.Select(url => url.Split('/').Last()));
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
