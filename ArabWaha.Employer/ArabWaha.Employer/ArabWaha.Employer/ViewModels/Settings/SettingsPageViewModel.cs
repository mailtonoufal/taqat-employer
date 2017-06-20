using ArabWaha.Employer.BaseCalsses;
using ArabWaha.Employer.Views;
using ArabWaha.Employer.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArabWaha.Employer.ViewModels
{
    public class SettingsPageViewModel : AWMVVMBase
    {
        public DelegateCommand LogoutCommand { get; set; }
        public DelegateCommand ResetPasswordCommand { get; set; }

        public DelegateCommand ComplaintsCommand { get; set; }
        public DelegateCommand AboutCommand { get; set; }

        public SettingsPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {
            LogoutCommand = new DelegateCommand(Logout);
            ResetPasswordCommand = new DelegateCommand(ResetPassword);
            ComplaintsCommand = new DelegateCommand(ComplaintsNavigate);
            AboutCommand = new DelegateCommand(About);
        }


        private void About()
        {
            _nav.NavigateAsync(nameof(AboutPage));
        }

        private void ComplaintsNavigate()
        {
            _nav.NavigateAsync(nameof(ComplaintsPage));
        }

        private void ResetPassword()
        {
            _nav.NavigateAsync(nameof(PasswordPage));
        }

        private void Logout()
        {
            _nav.NavigateAsync(nameof(LoginPage));
        }
                
        public string CurrentLanguage
        {
            get {

                if (CultureCode == "ar")
                    return "عربى";
                else
                    return "English";

            }
        }

    }
}
