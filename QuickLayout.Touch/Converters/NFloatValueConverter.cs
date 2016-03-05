using System;
using System.Globalization;
using Cirrious.CrossCore.Converters;

namespace QuickLayout.Touch.Converters
{
	public class NFloatValueConverter : IMvxValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => new nfloat((float)value);

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}

