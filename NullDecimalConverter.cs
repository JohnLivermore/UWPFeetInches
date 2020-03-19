using System;

using Windows.UI.Xaml.Data;

namespace UWPFeetInches
{
    public sealed class NullDecimalConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is decimal m)
            {
                return m == 0 ? "" : m.ToString();
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (!string.IsNullOrWhiteSpace(value?.ToString()))
            {
                if (Decimal.TryParse(value.ToString(), out decimal m))
                {
                    return m;
                }
            }
            return null;
        }
    }
}
