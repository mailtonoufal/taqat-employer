using System;
using Xamarin.Forms;

namespace ArabWaha.Employee.Views.Badges
{
    public partial class BadgesPage : ContentPage
    {
        public BadgesPage()
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
