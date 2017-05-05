using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SlideOverKit;
using SlideOverKit.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ArabWaha.Employer.Droid.Renders;
using ArabWaha.Employer.BaseCalsses;

[assembly: ExportRenderer (typeof(AWMenuContainerPage), typeof(MenuContainerPage_Droid))]

namespace ArabWaha.Employer.Droid.Renders
{
    public class MenuContainerPage_Droid : MenuContainerPageDroidRenderer
    {

        public MenuContainerPage_Droid()
        {
            var x = 0;
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);
        }
    }
}