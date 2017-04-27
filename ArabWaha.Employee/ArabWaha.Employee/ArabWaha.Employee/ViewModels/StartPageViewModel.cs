using ArabWaha.Core.BaseClasses;
using ArabWaha.Employee.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace ArabWaha.Employee.ViewModels
{
    public class StartPageViewModel : MVVMBase
    {
        INavigationService _nav;
        IPageDialogService _dialog;
        public DelegateCommand SignInCommand { get; set; }
        public DelegateCommand SignUpCommand { get; set; }
        public DelegateCommand ContinueAsGuestCommand { get; set; }

        private int _pagePosition;
        public int PagePosition
        {
            get { return _pagePosition; }
            set { SetProperty(ref _pagePosition, value); }
        }

        public StartPageViewModel(INavigationService navigationService, IPageDialogService dialog)
        {
            _nav = navigationService;
            _dialog = dialog;
            SignInCommand = new DelegateCommand(NavigateSignIn);
            SignUpCommand = new DelegateCommand(NavigateExternal);
            ContinueAsGuestCommand = new DelegateCommand(ContinueAsGuest);
        }

        private async void ContinueAsGuest()
        {
            await _nav.NavigateAsync(nameof(SearchPage), animated: false);
        }

        private void NavigateSignIn()
        {
            _nav.NavigateAsync(nameof(LoginPage), animated: false);
        }

        private async void NavigateExternal()
        {
            // Need to start a webView..
            await _dialog.DisplayAlertAsync("External", "You are about to login using an external website", "OK");
            Device.OpenUri(new Uri("https://www.taqat.sa/web/guest/individualregistration"));
        }

     }
}
