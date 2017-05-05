using System;
using Xamarin.Forms;

namespace ArabWaha.Employee.Views.Badges
{
    public partial class BadgesDetailPage : ContentPage
    {
        public BadgesDetailPage()
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
