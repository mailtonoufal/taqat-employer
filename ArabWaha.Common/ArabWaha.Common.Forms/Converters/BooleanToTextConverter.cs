using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace ArabWaha.Common.Forms.Converters
{
    public class BooleanToTextConverter : IValueConverter
    {
        private string _truetext { get; set; }
        private string _falsetext { get; set; }

        public BooleanToTextConverter(string truetext, string falsetext)
        {
            _truetext = truetext;
            _falsetext = falsetext;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool blval = (bool)value;
            if (blval)
            {
                return _truetext;
            }
            else
            {
                return _falsetext;
            }
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }
}
