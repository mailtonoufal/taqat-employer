using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ArabWaha.Employer.Controls
{
    public class HighProgressBar: ProgressBar
    {
        public static BindableProperty ScaleAmountProperty = BindableProperty.Create(nameof(ScaleAmount), typeof(int),
          typeof(HighProgressBar), 10, BindingMode.TwoWay);


        public static BindableProperty IsHeaderProperty = BindableProperty.Create(nameof(IsHeader), typeof(bool),
            typeof(HighProgressBar), false, BindingMode.TwoWay);

        public static BindableProperty BarColorProperty = BindableProperty.Create(nameof(BarColor), typeof(Color),
            typeof(HighProgressBar), Color.Gray, BindingMode.TwoWay);

        // add a height to this here..
        public static BindableProperty BarHeightProperty = BindableProperty.Create(nameof(BarHeight), typeof(int),
            typeof(HighProgressBar), 15, BindingMode.TwoWay);

        public HighProgressBar()
        {

        }

        public int BarHeight
        {
            get { return (int)GetValue(BarHeightProperty); }
            set { SetValue(BarHeightProperty, value); }
        }

        public int ScaleAmount
        {
            get { return (int)GetValue(ScaleAmountProperty); }
            set { SetValue(ScaleAmountProperty, value); }
        }

        public Color BarColor
        {
            get { return (Color)GetValue(BarColorProperty); }
            set
            {

                SetValue(BarColorProperty, value);

            }
        }

        public bool IsHeader
        {
            get { return (bool)GetValue(IsHeaderProperty); }
            set { SetValue(IsHeaderProperty, value); }
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            var t = this.BindingContext;
        }


    }
}
