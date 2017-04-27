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
using ArabWaha.Employee.Droid;
using Xamarin.Forms;
using ArabWaha.Employee.Interfaces;

[assembly: Dependency(typeof(IndividualDB))]
namespace ArabWaha.Employee.Droid
{
    public class IndividualDB : IDBInfo
    {
        public string GetIndividualDbPath()
        {
            return System.IO.Path.Combine(GetFolder(), "individual.db3");
        }

        private string GetFolder()
        {
            return System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        }
    }
}