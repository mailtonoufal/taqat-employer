using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Prism.Unity;
using Microsoft.Practices.Unity;
using CarouselView.FormsPlugin.Android;
using HockeyApp.Android;
using Xamarin.Forms;
using System.IO;

namespace ArabWaha.Employer.Droid
{
    [Activity(Label = "ArabWaha.Employer", Theme = "@style/MainTheme",
         ScreenOrientation = ScreenOrientation.Portrait, ConfigurationChanges = Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.ScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            CopyAssetToDocuments("employerdb.db3");

            global::Xamarin.Forms.Forms.Init(this, bundle);
            Xamarin.FormsMaps.Init(this, bundle);
            CarouselViewRenderer.Init();
            LoadApplication(new App(new AndroidInitializer()));
            // LoadApplication(new App());
        }

        private void CopyAssetToDocuments(string fileName)
        {
            var destinationPath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), fileName);
            if (!File.Exists(destinationPath))
            {
                using (Stream source = Assets.Open(fileName))
                {
                    using (var destination = System.IO.File.Create(destinationPath))
                    {
                        source.CopyTo(destination);
                    }
                }
            }
        }



        public class AndroidInitializer : IPlatformInitializer
        {
            public void RegisterTypes(IUnityContainer container)
            {

            }
        }
        private class AppCrashManagerListener : CrashManagerListener
        {
            public override bool ShouldAutoUploadCrashes()
            {
                return true;
            }

            public override bool IncludeDeviceData()
            {
                return true;
            }

            public override bool IncludeDeviceIdentifier()
            {
                return true;
            }


        }
    }

}

