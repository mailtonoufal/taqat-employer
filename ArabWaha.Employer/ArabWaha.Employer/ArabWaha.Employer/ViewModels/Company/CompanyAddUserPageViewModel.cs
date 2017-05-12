using ArabWaha.Core.ModelsEmployer.Company;
using ArabWaha.Core.Services;
using ArabWaha.Employer.BaseCalsses;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArabWaha.Employer.ViewModels
{
    public class CompanyAddUserPageViewModel : AWMVVMBase, INavigationAware
    {

        private CompanyUserDetails _userDetails;
        public CompanyUserDetails UserDetails
        {
            get { return _userDetails; }
            set { SetProperty(ref _userDetails, value); }
        }

        private string _userRole;

        public DelegateCommand SaveCommand { get; set; }
        public CompanyAddUserPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {
           // SetDefaultColumn(0, 1);
            SaveCommand = new DelegateCommand(Save);
        }

        private async void Save()
        {
            // ************* TODO ************
            // Validate new user before saving
            ApiService api = new ApiService();            
            await api.AddCompanyUser(UserDetails);
            _nav.GoBackAsync();
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            UserDetails = new CompanyUserDetails();
            UserDetails.AssignedRole = (string)parameters["UserRole"];
        }
    }
}
