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
using System.IO;
using ArabWaha.Employee.Interfaces;
//using HockeyApp;
using HockeyApp.Android;
//using SQLite.Net.Interop;

namespace ArabWaha.Employee.Droid
{
    [Activity(Label = "ArabWaha.Employee", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, 
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity//, ISQLPlatformHandle
    {
        //public ISQLitePlatform GetPlatform()
        //{
        //    return  new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
        //}

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            CopyAssetToDocuments("individual.db3");

            global::Xamarin.Forms.Forms.Init(this, bundle);

            CrashManager.Register(this, "c72744fcc7af4a6dbcbd698c2cafc7e4");
            // c72744fcc7af4a6dbcbd698c2cafc7e4


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
    }
}

