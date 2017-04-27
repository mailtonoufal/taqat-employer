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
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics;
using System.Globalization;
using ArabWaha.Common.Forms.Controls;
using ArabWaha.Common.Droid.Controls;

[assembly: ExportRenderer(typeof(FontLabel), typeof(FontLabelCustomRenderer))]
namespace ArabWaha.Common.Droid.Controls
{
    public class FontLabelCustomRenderer : LabelRenderer
    {
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "TextColor")
            {
                UpdateFont();
            }
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            UpdateFont();
        }

        private void UpdateFont()
        {
            FontLabel myl = (FontLabel)this.Element;
            if (!string.IsNullOrWhiteSpace(myl.FontFile))
            {
                var label = (TextView)Control;
                Typeface font = Typeface.CreateFromAsset(Xamarin.Forms.Forms.Context.Assets, string.Format("fonts/{0}", myl.FontFile.Replace("-","")));
                label.Typeface = font;
            }
        }
    }
}
