using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using System.ComponentModel;
using ArabWaha.Employer.Controls;
using Android.Graphics;
using ArabWaha.Employer.Droid.Renders;

//[assembly: ExportRenderer(typeof(HighProgressBar), typeof(HighProgressBarRenderer))]
namespace ArabWaha.Employer.Droid.Renders
{
    public class HighProgressBarRenderer : ProgressBarRenderer

    {
        float Scaler = 10.0f;
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ProgressBar> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
                return;

            if (Control != null)
            {
                var element = Element as HighProgressBar;
                Scaler = (float)element.ScaleAmount;
                Control.ScaleY = Scaler;
                UpdateBarColor();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == HighProgressBar.ProgressProperty.PropertyName
                || e.PropertyName == HighProgressBar.TriggersProperty.PropertyName
                || e.PropertyName == HighProgressBar.BarColorProperty.PropertyName)
            {
                UpdateBarColor();
            }

        }

        private void UpdateBarColor()
        {

            var element = Element as HighProgressBar;



            // set color based on the value
            var compVal = element.Progress;

            Android.Graphics.Color color = element.BarColor.ToAndroid();

            Control.IndeterminateDrawable.SetColorFilter(color, PorterDuff.Mode.SrcIn);
            Control.ProgressDrawable.SetColorFilter(color, PorterDuff.Mode.SrcIn);

            if ((Element as HighProgressBar).IsHeader)
            {
                try
                {
                    Control.ProgressTintList = Android.Content.Res.ColorStateList.ValueOf(color);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Err: {0}", ex.Message); // simple test for 'java.lang.NoSuchMethodError: no method with name='setProgressTintList'' issue
                }


                // set back ground colour white
                Control.ProgressBackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Xamarin.Forms.Color.FromRgb(216, 216, 216).ToAndroid());
            }

        }
    }
}