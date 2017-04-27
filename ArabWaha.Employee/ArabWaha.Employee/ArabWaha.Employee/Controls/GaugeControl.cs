using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ArabWaha.Employee.Controls
{
    public class GaugeControl : Grid
    {
        View _progress1, _progress2, _background1, _background2;
        public GaugeControl()
        {
            _progress1 = AddImage("prg_done.png");
            _background1 = AddImage("prg_pending.png");
            _background2 = AddImage("prg_pending.png");
            _progress2 = AddImage("prg_done.png");
            HandleProgressChanged(1, 0);
        }

        private View AddImage(string filename)
        {
            var img = new Image() { Source = ImageSource.FromFile(filename) };
            this.Children.Add(img);
            return img;
        }

        public static BindableProperty ProgressProperty = BindableProperty.Create("Progress", typeof(double), typeof(GaugeControl), 0d, propertyChanged: ProgressChanged);

        private static void ProgressChanged(BindableObject bindable, object oldValue, object newValue)
        {
            try
            {
                double newValx = 0.0d;
                double oldValx = 0.0d;

                if (newValue != null)
                {
                    double temp;
                    if (double.TryParse(newValue.ToString(), out temp))
                        newValx = temp;
                }
                if (oldValx != null)
                {
                    double temp;
                    if (double.TryParse(oldValx.ToString(), out temp))
                        oldValx = temp;
                }


                var c = bindable as GaugeControl;
                c.HandleProgressChanged(CheckValue(oldValx), CheckValue(newValx)); //  (double)newValue));

            }
            catch(Exception ex)
            {
                var t = ex.Message;
            }
        }

        static double CheckValue(double value)
        {
            int min = 0, max = 1;
            value = value / 100;
            if (value <= max && value >= min) return value;
            else if (value > max) return max;
            else return min;
        }

        private void HandleProgressChanged(double oldValue, double p)
        {
            if (p < .5)
            {
                if (oldValue >= .5)
                {
                    _background1.IsVisible = true;
                    _progress2.IsVisible = false;
                    _background2.Rotation = 180;
                    _progress1.Rotation = 0;
                }
                double rotation = 360 * p;
                _background1.Rotation = rotation;
            }
            else
            {
                if (oldValue < .5)
                {
                    _background1.IsVisible = false;
                    _progress2.IsVisible = true;
                    _progress1.Rotation = 180;
                }
                double rotation = 360 * p;
                _background2.Rotation = rotation;
            }
        }

        public double Progress
        {
            get { return (double)this.GetValue(ProgressProperty); }
            set { SetValue(ProgressProperty, value); }
        }

        protected override void OnRemoved(View view)
        {
            try
            {
                _progress1 = null;
                _background1 = null;
                _background2 = null;
                _progress2 = null;
            }
            catch(Exception ex)
            {
                var t = ex.Message;
            }

            base.OnRemoved(view);
        }
    }
}
