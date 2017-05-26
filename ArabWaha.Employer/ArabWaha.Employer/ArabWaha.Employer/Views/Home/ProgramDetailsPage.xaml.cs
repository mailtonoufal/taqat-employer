using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace ArabWaha.Employer.Views.Home
{
    public partial class ProgramDetailsPage : ContentPage
    {
        public ProgramDetailsPage()
        {
            try
            {
                InitializeComponent();
            }
            catch(Exception ex)
            {
                Debug.WriteLine("ERROR:" + ex.Message);
            }
        }
    }
}
