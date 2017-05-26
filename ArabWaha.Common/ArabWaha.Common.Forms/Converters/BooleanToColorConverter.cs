using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace ArabWaha.Common.Forms.Converters
{
    public class BooleanToColorConverter : IValueConverter
    {
        private string _truecol { get; set; }
        private string _falsecol { get; set; }

        public BooleanToColorConverter(string truecol, string falsecol)
        {
            _truecol = truecol;
            _falsecol = falsecol;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool blval = (bool)value;
            if (blval)
            {
                return Color.FromHex(_truecol);
            }
            else
            {
                return Color.FromHex(_falsecol);
            }
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }
}
