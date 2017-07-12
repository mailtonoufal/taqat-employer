using System.Diagnostics;
using ArabWaha.Employer.BaseCalsses;
using Xamarin.Forms;

namespace ArabWaha.Employer.Views
{
    public partial class ContactUsPage : ContentPage
    {
        public ContactUsPage()
        {
            try
            {
				InitializeComponent();
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine("ERROR:" + ex.Message);
            }
           
        }
    }
}
