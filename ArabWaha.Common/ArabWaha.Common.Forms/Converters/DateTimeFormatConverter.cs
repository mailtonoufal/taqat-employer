using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace ArabWaha.Common.Forms.Converters
{
    public class DateTimeFormatConverter : IValueConverter
    {
        private string _format { get; set; }

        public DateTimeFormatConverter(string format)
        {
            _format = format;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((DateTime)value == DateTime.MinValue)
                return string.Empty;
            else
                return string.Format(_format, (DateTime)value);
        }


        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }

    public class TimeSpanFormatConverter : IValueConverter
    {
        private string _format { get; set; }

        public TimeSpanFormatConverter(string format)
        {
            _format = format;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((TimeSpan)value == null || (TimeSpan)value == TimeSpan.MinValue)
                return string.Empty;
            else
                return ((TimeSpan)value).ToString(_format);
        }


        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }
}
