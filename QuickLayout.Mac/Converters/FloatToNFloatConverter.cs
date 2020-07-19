using System;
using System.Globalization;
using MvvmCross.Converters;

namespace QuickLayout.Mac.Converters
{
    public class FloatToNFloatConverter : MvxValueConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new nfloat((float)value);
        }
    }
}
