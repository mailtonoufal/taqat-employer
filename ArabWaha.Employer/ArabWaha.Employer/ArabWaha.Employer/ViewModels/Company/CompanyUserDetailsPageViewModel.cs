using ArabWaha.Core.ModelsEmployer.Company;
using ArabWaha.Core.Services;
using ArabWaha.Employer.BaseCalsses;
using ArabWaha.Employer.Helpers;
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
    public class CompanyUserDetailsPageViewModel : AWMVVMBase, INavigationAware
    {
        private CompanyUserDetails _userDetails;
        public CompanyUserDetails UserDetails
        {
            get { return _userDetails; }
            set { SetProperty(ref _userDetails, value); }
        }
        public DelegateCommand<string> CallCommand { get; set; }
        public DelegateCommand<CompanyUserDetails> EditCommand { get; set; }


        public CompanyUserDetailsPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {
            SetDefaultColumn(1,2);
            Title = TranslateExtension.GetString("PersonalDetailsTitle");

            CallCommand = new DelegateCommand<string>(CallNumber);
            EditCommand = new DelegateCommand<CompanyUserDetails>(EditUser);

        }

        private void EditUser(CompanyUserDetails obj)
        {
            _nav.NavigateAsync($"{nameof(CompanyEditUserDetailsPage)}?UserId={obj.UserId}");
        }

        private void CallNumber(string obj)
        {
            Device.OpenUri(new Uri($"tel:{obj}"));
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            // Parameter will be the user to view pull details back

        }

        public async void OnNavigatingTo(NavigationParameters parameters)
        {
            var id = Convert.ToInt32(parameters["UserId"]); 
            // load user details
            ApiService api = new ApiService();
            UserDetails = await api.GetCompanyUserDetailsAsync(id);
        }

    }
}
