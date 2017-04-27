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
using ArabWaha.Employer.Interfaces;
using System.IO;
using ArabWaha.Employer.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(EmployerDb))]
namespace ArabWaha.Employer.Droid
{
    public class EmployerDb : IDBInfo
    {
        public string GetEmployerDbPath()
        {
            return Path.Combine(GetFolder(), "employerdb.db3");
        }

        private string GetFolder()
        {
            return System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        }

    }
}