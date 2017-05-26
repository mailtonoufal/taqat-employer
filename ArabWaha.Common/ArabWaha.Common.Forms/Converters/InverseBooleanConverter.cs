using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ArabWaha.Common.Forms.Converters
{
    /* https://xamarinhelp.com/xamarin-forms-binding/
      <ContentPage xmlns:converters="clr-namespace:MyApp.NamespaceConvertersAreIn" ... >
    <ContentPage.Resources>
        <ResourceDictionary>
            <converters:InverseBooleanConverter x:Key="InverseBooleanConverter"/>
        </ResourceDictionary>
    </ContentPage.Resources>

        <Label IsVisible="{Binding IsHidden, Converter={StaticResource InverseBooleanConverter}}" />
    */

    public class InverseBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(bool))
                throw new InvalidOperationException("The target must be a boolean");

            return !(bool)value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Optional: throw new NotSupportedException();
            return null;
        }
    }
}
