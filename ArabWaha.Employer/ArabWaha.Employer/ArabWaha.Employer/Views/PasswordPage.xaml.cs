using ArabWaha.Employer.ViewModels;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace ArabWaha.Employer.Views
{
    public partial class PasswordPage : ContentPage
    {
        public PasswordPage()
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
            var vm = this.BindingContext as PasswordPageViewModel;
            vm.SetTabs(tabCtrl);
        }

        //private void UsernameSwitchEmail_Toggled(object sender, ToggledEventArgs e)
        //{
        //    (BindingContext as PasswordPageViewModel).ProcessUsernameSwitchCommand("EMAIL");
        //}

        //private void UsernameSwitchSMS_Toggled(object sender, ToggledEventArgs e)
        //{
        //    (BindingContext as PasswordPageViewModel).ProcessUsernameSwitchCommand("SMS");
        //}
    }
}
