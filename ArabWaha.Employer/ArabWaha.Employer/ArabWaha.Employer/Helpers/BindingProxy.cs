using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ArabWaha.Employer.Helpers
{
    public class BindingProxy : BindableObject
    {
        public static readonly BindableProperty DataProperty =
            BindableProperty.Create("Data", typeof(object), typeof(BindingProxy), null, BindingMode.OneWay);

        public object Data
        {
            get { return (object)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }
    }
}
