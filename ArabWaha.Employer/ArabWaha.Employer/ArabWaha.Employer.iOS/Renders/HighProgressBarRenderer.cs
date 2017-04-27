using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using ArabWaha.Employer.Controls;
using ArabWaha.Employer.iOS.Renders;
using System.ComponentModel;
using CoreGraphics;

//[assembly: ExportRenderer(typeof(HighProgressBar), typeof(HighProgressBarRenderer))]
namespace ArabWaha.Employer.iOS.Renders
{
    class HighProgressBarRenderer : ProgressBarRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ProgressBar> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
                return;

            if (Control != null)
            {
                Control.TintColor = UIColor.Orange;
            }

            LayoutSubviews();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == HighProgressBar.ProgressProperty.PropertyName)
            {
                Control.TintColor = UIColor.Orange;
            }

            LayoutSubviews();
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            var X = 1.0f;
            var Y = 10.0f;

            CGAffineTransform transform = CGAffineTransform.MakeScale(X, Y);
            transform.TransformSize (this.Frame.Size);
            this.Transform = transform;
            this.ClipsToBounds = true;
            this.Layer.MasksToBounds = true;
        }
    }
}