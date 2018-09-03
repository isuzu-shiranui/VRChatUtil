using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using VRChatUtilModule.Models;
using VRChatUtilModule.Utility;

namespace VRChatUtilModule.Converter
{
    [ValueConversion(typeof(CultureType), typeof(string))]
    public class CultureTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value is CultureType
            ? Enum.GetValues(typeof(CultureType)).Cast<CultureType>().ToList()
                .First(x => x == (CultureType)value).GetDisplayName()
            : DependencyProperty.UnsetValue;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is string s ? Enum.GetValues(typeof(CultureType)).OfType<CultureType>().ToList().First(x => x.GetDisplayName() == s) : DependencyProperty.UnsetValue;
        }
    }
}
