using ArabWaha.Employee.ViewModels;
using Xamarin.Forms;

namespace ArabWaha.Employee.Views
{
    public partial class PasswordPage : ContentPage
    {
        public PasswordPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var vm = this.BindingContext as PasswordPageViewModel ;
            vm.SetTabs(tabCtrl);
        }

        private void UsernameSwitchEmail_Toggled(object sender, ToggledEventArgs e)
        {
            (BindingContext as PasswordPageViewModel).ProcessUsernameSwitchCommand("EMAIL");
        }

        private void UsernameSwitchSMS_Toggled(object sender, ToggledEventArgs e)
        {
            (BindingContext as PasswordPageViewModel).ProcessUsernameSwitchCommand("SMS");
        }
    }
}
