using System;
using ArabWaha.Employer;
using ArabWaha.Employer.iOS.Renders;
using CoreAnimation;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(LineEntry), typeof(LineEntryRenderer))]
namespace ArabWaha.Employer.iOS.Renders
{
    public class LineEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.BorderStyle = UIKit.UITextBorderStyle.None;

                var view = Element as LineEntry;

                if (view != null)
                {
                    DrawBorder(view);
                }
            }
        }

        private void DrawBorder(LineEntry view)
        {
            var borderLayer = new CALayer();
            borderLayer.MasksToBounds = true;
            borderLayer.Frame = new CoreGraphics.CGRect(0f, Frame.Height / 2, Frame.Width-40, 1f);
            borderLayer.BorderColor = UIKit.UIColor.White.CGColor;
            borderLayer.BorderWidth = 0.5f;

            Control.Layer.AddSublayer(borderLayer);
            Control.BorderStyle = UIKit.UITextBorderStyle.None;
        }
    }
}
