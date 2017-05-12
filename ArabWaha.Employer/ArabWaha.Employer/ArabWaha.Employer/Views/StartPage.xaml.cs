using System;
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
                var t = ex.Message;
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
                var t = ex.Message;
            }
        }
    }
}
