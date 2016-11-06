using System;
using System.Globalization;
using Xamarin.Forms;

namespace PersistentStorage.Converters
{
    public class GuidToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string result = null;
            if(value is Guid)
            {
                result = ((value as Guid?) ?? new Guid()).ToString();
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Guid result = new Guid();
            if(value is string && value != null)
            {
                result = Guid.Parse(value as string);
            }
            return result;
        }
    }
}
