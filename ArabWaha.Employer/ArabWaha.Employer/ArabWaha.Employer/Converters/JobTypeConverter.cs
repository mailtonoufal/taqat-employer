using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ArabWaha.Employer.Converters
{
    public class JobTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // JobType will be the Text representation of the Enum, so use the extension methods to return the display value.
            string retVal = "";
            if (!string.IsNullOrEmpty((string)value))
            {
                retVal = value.ToString().ToJobType();
            }
            return retVal; 
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
