using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace ArabWaha.Employer.Views
{
    public partial class StartPage : ContentPage
    {
        public StartPage()
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

        protected override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                ForceLayout();
            }
            catch(Exception ex)
            {
                Debug.WriteLine("ERROR:" + ex.Message);
            }
        }
    }
}
