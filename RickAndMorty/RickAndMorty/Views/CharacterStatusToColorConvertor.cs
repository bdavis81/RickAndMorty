using RickAndMorty.Models;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace RickAndMorty.Views
{
    public class CharacterStatusToColorConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is CharacterStatus enumValue)
            {
                switch (enumValue)
                {
                    case CharacterStatus.Alive:
                        return Color.GreenYellow;
                    case CharacterStatus.Dead:
                        return Color.IndianRed;
                    case CharacterStatus.Unknown:
                        return Color.Gray;
                }
            }

            return Color.Default;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
