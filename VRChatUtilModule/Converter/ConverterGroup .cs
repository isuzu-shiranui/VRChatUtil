using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Markup;

namespace VRChatUtilModule.Converter
{
    [ContentProperty(nameof(Converters))]
    public class ConverterGroup : IValueConverter
    {
        public Collection<IValueConverter> Converters { get; } = new Collection<IValueConverter>();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object result = value;

            if (this.Converters == null) return result;

            foreach (IValueConverter conv in this.Converters)
            {
                result = conv.Convert(result, targetType, parameter, culture);
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object result = value;

            return this.Converters == null ? result : this.Converters.Reverse().Aggregate(result, (current, conv) => conv.ConvertBack(current, targetType, parameter, culture));
        }
    }
}