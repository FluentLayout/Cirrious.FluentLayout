using System;
using System.Globalization;
using MvvmCross.Converters;

namespace QuickLayout.Mac.Converters
{
    public class FloatToIntConverter : MvxValueConverter<float, int>
    {
        protected override int Convert(float value, Type targetType, object parameter, CultureInfo culture)
        {
            return (int)value;
        }

        protected override float ConvertBack(int value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
