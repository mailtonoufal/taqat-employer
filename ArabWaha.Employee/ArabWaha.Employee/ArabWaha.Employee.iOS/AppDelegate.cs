using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using CarouselView.FormsPlugin.iOS;
using System.IO;
using Syncfusion.SfBusyIndicator.XForms.iOS;
using Syncfusion.SfAutoComplete.XForms.iOS;
using Syncfusion.SfSchedule.XForms.iOS;
using Syncfusion.SfRotator.XForms.iOS;
//using ArabWaha.Employee.Controls;
using ArabWaha.Common.Forms.Controls;
using ArabWaha.Common.iOS.Controls;
using ArabWaha.Employee.Interfaces;
using Syncfusion.ListView.XForms;
using Syncfusion.ListView.XForms.iOS;

namespace ArabWaha.Employee.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate//, ISQLPlatformHandle
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            // copy db when in place
            CopyDB("individual.db3", "ArabWaha.Employee.iOS.Resources.individual.db3");

            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());
            CarouselViewRenderer.Init();
            SlideOverKit.iOS.SlideOverKit.Init();

            // syncfusion inits
            new SfBusyIndicatorRenderer();
            new SfAutoCompleteRenderer();
            new SfScheduleRenderer();
            new SfRotatorRenderer();
            SfListViewRenderer.Init();

            new GaugeControl();
            new CheckBox();
            new CheckBoxRenderer();

           

            return base.FinishedLaunching(app, options);
        }

        //public ISQLitePlatform GetPlatform()
        //{
        //    return new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
        //}

        private void CopyDB(string dbname, string resourcename)
        {
//            var destinationPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), dbname);

            // need to be library folder for ios - apple terms
//            string destinationPath = Path.Combine(
//                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", dbname);

            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = System.IO.Path.Combine(docFolder, "..", "Library");

            if (!System.IO.Directory.Exists(libFolder))
            {
                System.IO.Directory.CreateDirectory(libFolder);
            }

            var destPath = System.IO.Path.Combine(libFolder, dbname);

            if (!File.Exists(destPath))
            {
                using (Stream source = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(resourcename))
                {
                    using (var destination = System.IO.File.Create(destPath))
                    {
                        source.CopyTo(destination);
                    }
                }
            }
        }
    }
}
