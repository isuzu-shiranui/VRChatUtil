using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using VRChatApiWrapper.WorldApi;
using VRChatUtilModule.Utility;

namespace VRChatUtilModule.Converter
{
    [ValueConversion(typeof(SortOptions), typeof(string))]
    public class SortOptionsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value is SortOptions
            ? Enum.GetValues(typeof(SortOptions)).Cast<SortOptions>().ToList()
                .First(x => x == (SortOptions)value).GetDisplayName()
            : DependencyProperty.UnsetValue;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is string s ? Enum.GetValues(typeof(SortOptions)).OfType<SortOptions>().ToList().First(x => x.GetDisplayName() == s) : DependencyProperty.UnsetValue;
        }
    }
}
