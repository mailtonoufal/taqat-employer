using System;
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
                var t = ex.Message;
            }
        }
    }
}
