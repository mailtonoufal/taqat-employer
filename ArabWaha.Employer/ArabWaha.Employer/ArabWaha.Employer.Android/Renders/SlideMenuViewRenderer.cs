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
using SlideOverKit;
using Xamarin.Forms;
using ArabWaha.Employer.Droid.Renders;
using SlideOverKit.Droid;
using Xamarin.Forms.Platform.Android;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(SlideMenuView), typeof(SlideMenuViewRenderer_Droid))]

namespace ArabWaha.Employer.Droid.Renders
{
    public class SlideMenuViewRenderer_Droid : SlideMenuDroidRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }
        protected override void OnElementChanged(ElementChangedEventArgs<SlideMenuView> e)
        {
            base.OnElementChanged(e);
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            return base.OnTouchEvent(e);
        }
    }

}