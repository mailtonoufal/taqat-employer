using ArabWaha.Core.BaseClasses;
using ArabWaha.Employer.BaseCalsses;
using ArabWaha.Employer.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace ArabWaha.Employer.ViewModels
{
    public class StartPageViewModel : AWMVVMBase
    {
        public DelegateCommand SkipCommand { get; set; }
        public DelegateCommand SignInCommand { get; set; }
        public DelegateCommand SignInExternalCommand { get; set; }
        public DelegateCommand SignUpCommand { get; set; }
        public DelegateCommand ContinueAsGuestCommand { get; set; }

        private int _pagePosition;
        public int PagePosition
        {
            get { return _pagePosition; }
            set { SetProperty(ref _pagePosition, value); }
        }

        public StartPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {
            Title = "Welcome";
            SkipCommand = new DelegateCommand(SkipPage);
            SignInCommand = new DelegateCommand(NavigateInternal);
            SignInExternalCommand = new DelegateCommand(NavigateExternal);
            SignUpCommand = new DelegateCommand(NavigateSignUp);
            ContinueAsGuestCommand = new DelegateCommand(ContinueAsGuest);
        }

        private async void ContinueAsGuest()
        {
            await _nav.NavigateAsync(nameof(SearchPage),animated:false);
        }

        private void NavigateSignUp()
        {
            _nav.NavigateAsync(nameof(SignUpPage), animated: false);
        }

        private async void NavigateExternal()
        {
            // Need to start a webView..
            await _dialog.DisplayAlertAsync("External", "You are about to login using an external website", "OK");
            Device.OpenUri(new Uri("http://www.bbc.co.uk"));
        }

        private void NavigateInternal()
        {
            _nav.NavigateAsync(nameof(LoginPage), animated: false);
        }
        private void SkipPage()
        {
            // show goto search page
            _nav.NavigateAsync(nameof(SearchPage), animated: false);
        }

    }
}
