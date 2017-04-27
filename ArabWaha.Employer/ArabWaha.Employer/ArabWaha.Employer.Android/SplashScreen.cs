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
using Android.Content.PM;
using HockeyApp.Android;

namespace ArabWaha.Employer.Droid
{
    [Activity(Label = "TAQAT Employer",
        Icon = "@drawable/icon",
        NoHistory = true,
        MainLauncher = true,
        Theme = "@style/Theme.Splash",
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);


            // HockeyApp paul@arabwaha.com  : f37c9dbfdea445af8c5929748fd7678e
            CrashManager.Register(this, "f37c9dbfdea445af8c5929748fd7678e", new AppCrashManagerListener());

            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
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