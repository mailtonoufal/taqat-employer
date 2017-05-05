using ArabWaha.Common;
using ArabWaha.Core.Services;
using ArabWaha.Core.BaseClasses;
using ArabWaha.Employer.BaseCalsses;
using ArabWaha.Employer.Views;
using ArabWaha.Models;
using ArabWaha.Web;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ArabWaha.Employer.ViewModels
{
    public class LoginPageViewModel : AWMVVMBase, INavigationAware
    {


        public LoginPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {
          //  Title = "Sign in";

            LostPasswordCommand = new DelegateCommand(LostPassword);
            SignInCommand = new DelegateCommand(SignIn, CanSignIn);
            GuestCommand = new DelegateCommand(ProcessGuestCommand);
            SignupCommand = new DelegateCommand(ProcessSignupCommand);

        }

        //public TextAlignment AlignText
        //{
        //    get
        //    {
        //        return GlobalSetting.AlignText;
        //    }
        //}

        //public LayoutOptions AlignLayoutOptions
        //{
        //    get { return GlobalSetting.HorizontalLayoutOptions; }
        //}

        string _username;
        string _password;

        public string UserName
        {
            get { return _username; }
            set { SetProperty(ref _username, value); SignInCommand.RaiseCanExecuteChanged(); }
        }
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public DelegateCommand SignInCommand { get; set; }
        public DelegateCommand LostPasswordCommand { get; set; }
        public DelegateCommand GuestCommand { get; set; }
        public DelegateCommand SignupCommand { get; set; }

        private async void ProcessSignupCommand()
        {
            // open web page here 
            await _dialog.DisplayAlertAsync("External", "You are about to login using an external website", "OK");
            Device.OpenUri(new Uri("https://www.taqat.sa/web/guest/individualregistration"));
        }

        private void ProcessGuestCommand()
        {
            _nav.GoBackAsync();
        }

        private bool CanSignIn()
        {
            return true;
            //return !string.IsNullOrEmpty(UserName);
        }

        private async void SignIn()
        {
            IsBusy = true;

            //await Task.Delay(10000);
            //TODO: remove
            //HAFIZ -> Otp screen
            UserName = "ashugupta";
            Password = "sap@1234";
            //Non-Hafiz -> Main screen
            //txtUserName.Text = "Fahad@arabwaha.com";
            //txtPassword.Text = "12345";
            AuthService sv = new AuthService();
            await sv.Login(UserName, Password, false);
            await _nav.NavigateAsync(nameof(SearchPage), animated: false);

            IsBusy = false;
        }

        private async void LostPassword()
        {
            await _nav.NavigateAsync(nameof(PasswordPage), animated: false);
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            
        }
    }
}
