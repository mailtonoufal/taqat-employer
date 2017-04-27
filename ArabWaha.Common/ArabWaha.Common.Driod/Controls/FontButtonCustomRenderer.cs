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

[assembly: ExportRenderer(typeof(FontButton), typeof(FontButtonCustomRenderer))]
namespace ArabWaha.Common.Droid.Controls
{
    public class FontButtonCustomRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            FontButton myl = (FontButton)this.Element;
            if (!string.IsNullOrWhiteSpace(myl.FontFile))
            {
                var btn = (TextView)Control;
                Typeface font = Typeface.CreateFromAsset(Xamarin.Forms.Forms.Context.Assets, string.Format("fonts/{0}", myl.FontFile.Replace("-", "")));
                btn.Typeface = font;
            }
        }
    }
}
