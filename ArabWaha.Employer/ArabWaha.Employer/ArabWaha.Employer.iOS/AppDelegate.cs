using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using CarouselView.FormsPlugin.iOS;
using Syncfusion.SfBusyIndicator.XForms.iOS;
using Syncfusion.SfAutoComplete.XForms.iOS;
using Syncfusion.SfSchedule.XForms.iOS;
using Syncfusion.SfRotator.XForms.iOS;
using Xamarin.Forms.Platform.iOS;
using HockeyApp.iOS;
using ArabWaha.Common.Forms.Controls;
using ArabWaha.Common.iOS.Controls;
using System.IO;

namespace ArabWaha.Employer.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
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
            //d16e3b21824b41b59183d48a4efe414f
            var manager = BITHockeyManager.SharedHockeyManager;
            manager.Configure("d16e3b21824b41b59183d48a4efe414f");
            manager.StartManager();

            CarouselViewRenderer.Init();
            SlideOverKit.iOS.SlideOverKit.Init();


            // syncfusion inits
            new SfBusyIndicatorRenderer();
            new SfAutoCompleteRenderer();
            new SfScheduleRenderer();
            new SfRotatorRenderer();
            
            new GaugeControl();
            new Common.Forms.Controls.CheckBox();
            new Common.iOS.Controls.CheckBoxRenderer();
            new RepeaterView();

            // copy db when in place
            CopyDB("employerdb.db3", "ArabWaha.Employer.iOS.Resources.employerdb.db3");

            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }

        private void CopyDB(string dbname, string resourcename)
        {
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
