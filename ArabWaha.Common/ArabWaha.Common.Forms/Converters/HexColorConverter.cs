using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ArabWaha.Common.Forms.Converters
{
    public class HexColorConverter : IValueConverter
    {
        private Color? _default = null;

        public HexColorConverter(Color? dft = null)
        {
            if (dft.HasValue)
            {
                _default = dft;
            }
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (value == null) ? value : (string.IsNullOrEmpty(value.ToString()) ?
                _default : Color.FromHex(value.ToString()));
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}


