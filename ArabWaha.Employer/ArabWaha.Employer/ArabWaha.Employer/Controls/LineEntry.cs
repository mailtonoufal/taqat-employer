using System;
using Xamarin.Forms;

namespace ArabWaha.Employer
{
    public class LineEntry : Entry
    {
        public static BindableProperty LineColorProperty = BindableProperty.Create(nameof(LineColor), typeof(Color),
                                                                                   typeof(LineEntry), Color.White, BindingMode.TwoWay);

        public Color LineColor
        {
            get { return (Color)GetValue(LineColorProperty); }
            set
            {
                SetValue(LineColorProperty, value);
            }
        }
    }
}
