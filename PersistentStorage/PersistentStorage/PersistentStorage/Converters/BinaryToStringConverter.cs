using System;
using System.Globalization;
using Xamarin.Forms;

namespace PersistentStorage.Converters
{
    public class BinaryToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string result = null;
            if(value is byte[])
            {
                result = System.Convert.ToBase64String((byte[])value);
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            byte[] result = null;
            if(value is string && value != null)
            {
                result = System.Convert.FromBase64String((string)value);
            }
            return result;
        }
    }
}
