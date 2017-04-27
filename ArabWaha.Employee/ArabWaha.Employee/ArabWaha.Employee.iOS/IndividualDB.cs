using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using ArabWaha.Employee.Interfaces;
using System.IO;
using ArabWaha.Employee.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(IndividualDB))]
namespace ArabWaha.Employee.iOS
{
    public class IndividualDB : IDBInfo
    {
        public string GetIndividualDbPath()
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = System.IO.Path.Combine(docFolder, "..", "Library");

            if (!System.IO.Directory.Exists(libFolder))
            {
                System.IO.Directory.CreateDirectory(libFolder);
            }

            return System.IO.Path.Combine(libFolder, "individual.db3");



//            string destinationPath = Path.Combine(
//              Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", "individual.db3");

  //          return destinationPath; //  Path.Combine(GetFolder(), "individual.db3");
        }

        private string GetFolder()
        {
            return System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        }
    }
}