using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using VRChatApiWrapper.WorldApi;
using VRChatUtilModule.Utility;

namespace VRChatUtilModule.Converter
{
    [ValueConversion(typeof(EndpointType), typeof(string))]
    public class EndpointTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value is EndpointType
            ? Enum.GetValues(typeof(EndpointType)).Cast<EndpointType>().ToList()
                .First(x => x == (EndpointType)value).GetDisplayName()
            : DependencyProperty.UnsetValue;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is string s ? Enum.GetValues(typeof(EndpointType)).OfType<EndpointType>().ToList().First(x => x.GetDisplayName() == s) : DependencyProperty.UnsetValue;
        }
    }
}
