using System;
using System.Globalization;
using System.Windows.Data;

namespace VRChatUtilModule.Converter
{
    public class ProgressConverter : IMultiValueConverter
    {
        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture) => $"{value[0]}/{value[1]}";

        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
        {
            var items = ((string) value).Split('/');
            return new object[] { items[1], items[0] };
        }
    }
}