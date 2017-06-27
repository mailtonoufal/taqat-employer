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
using System.Diagnostics;
using Acr.UserDialogs;
using ArabWaha.Employer.Helpers;

namespace ArabWaha.Employer.ViewModels
{
    public class LoginPageViewModel : AWMVVMBase, INavigationAware
    {
        private string _SigninText;
        public string SigninText
        {
            get { return _SigninText; }
            set
            {
                SetProperty(ref _SigninText, value);
            }
        }

        private string _UsernameText;
        public string UsernameText
        {
            get { return _UsernameText; }
            set
            {
                SetProperty(ref _UsernameText, value);
            }
        }

        private string _UsernameTextHolder;
        public string UsernameTextHolder
        {
            get { return _UsernameTextHolder; }
            set
            {
                SetProperty(ref _UsernameTextHolder, value);
            }
        }

        private string _PasswordText;
        public string PasswordText
        {
            get { return _PasswordText; }
            set
            {
                SetProperty(ref _PasswordText, value);
            }
        }


        private string _PasswordTextHolder;
        public string PasswordTextHolder
        {
            get { return _PasswordTextHolder; }
            set
            {
                SetProperty(ref _PasswordTextHolder, value);
            }
        }


        private string _LoginForgotPassword;
        public string LoginForgotPassword
        {
            get { return _LoginForgotPassword; }
            set
            {
                SetProperty(ref _LoginForgotPassword, value);
            }
        }


        private string _StartContinueAsGuest;
        public string StartContinueAsGuest
        {
            get { return _StartContinueAsGuest; }
            set
            {
                SetProperty(ref _StartContinueAsGuest, value);
            }
        }


        private string _LoginNoAccountSignup;
        public string LoginNoAccountSignup
        {
            get { return _LoginNoAccountSignup; }
            set
            {
                SetProperty(ref _LoginNoAccountSignup, value);
            }
        }



        public LoginPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {
            //  Title = "Sign in";

#if DEBUG
            UserName = "gosi001";
            Password = "Password1";
#endif
            TranslateExtension tran = new TranslateExtension();

            SigninText = App.Translation != null ? App.Translation.employer.signinlbltitle : tran.GetProviderValueString("LabelWatchList");
			UsernameText = App.Translation != null ? App.Translation.employer.guestprofiledetlblusername : tran.GetProviderValueString("LabelWatchList");
			UsernameTextHolder = App.Translation != null ? App.Translation.employer.guestprofiledetlblusername : tran.GetProviderValueString("LabelWatchList");
			PasswordText = tran.GetProviderValueString("Password");
			PasswordTextHolder = tran.GetProviderValueString("Password");
			LoginForgotPassword =tran.GetProviderValueString("LoginForgotPassword");
			StartContinueAsGuest = App.Translation != null ? App.Translation.employer.signinbtnguest : tran.GetProviderValueString("LabelWatchList");
			LoginNoAccountSignup = App.Translation != null ? App.Translation.employer.signinbtnsignup : tran.GetProviderValueString("LabelWatchList");



			LostPasswordCommand = new DelegateCommand(LostPassword);
            SignInCommand = new DelegateCommand(async () => { await SignIn(); }, CanSignIn);
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
            set
            {
                SetProperty(ref _username, value);
                //SignInCommand.RaiseCanExecuteChanged(); 
            }
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
            _nav.NavigateAsync(nameof(SearchPage), animated: false);
            //_nav.GoBackAsync();
        }

        private bool CanSignIn()
        {
            return true;
            //return !string.IsNullOrEmpty(UserName);
        }

        private async Task SignIn()
        {
            //await Task.Delay(10000);
            //TODO: remove
            //HAFIZ -> Otp screen

            //Non-Hafiz -> Main screen
            //txtUserName.Text = "Fahad@arabwaha.com";
            //txtPassword.Text = "12345";
            AuthService sv = new AuthService();
            bool isLoginSuccess = false;
            try
            {
                UserDialogs.Instance.ShowLoading();
                isLoginSuccess = await sv.Login(UserName, Password, false);
                UserDialogs.Instance.HideLoading();
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                Debug.WriteLine(ex.Message);
            }

            if (isLoginSuccess)
            {
                await _nav.NavigateAsync(nameof(HomePage), animated: false);
            }
            else
            {
                UserDialogs.Instance.ShowError("Something went wrong");
            }

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
