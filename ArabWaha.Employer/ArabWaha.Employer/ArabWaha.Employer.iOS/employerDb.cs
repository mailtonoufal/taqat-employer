using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using ArabWaha.Employer.Interfaces;
using System.IO;
using Xamarin.Forms;
using ArabWaha.Employer.iOS;

[assembly: Dependency(typeof(EmployerDb))]
namespace ArabWaha.Employer.iOS
{
    public class EmployerDb : IDBInfo
    {
        public string GetEmployerDbPath()
        {

            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = System.IO.Path.Combine(docFolder, "..", "Library");

            if (!System.IO.Directory.Exists(libFolder))
            {
                System.IO.Directory.CreateDirectory(libFolder);
            }

            return System.IO.Path.Combine(libFolder, "employerdb.db3");


        }

        private string GetFolder()
        {
            return System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        }

    }
}