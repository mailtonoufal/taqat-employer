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
    public class CompanyEditUserDetailsPageViewModel : AWMVVMBase, INavigationAware
    {
        private CompanyUserDetails _userDetails;
        public CompanyUserDetails UserDetails
        {
            get { return _userDetails; }
            set { SetProperty(ref _userDetails, value); }
        }
        public DelegateCommand SaveCommand { get; set; }

        public CompanyEditUserDetailsPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {
            SaveCommand = new DelegateCommand(Save);

        }

        private async void Save()
        {
            ApiService api = new ApiService();
            int id = await api.AddCompanyUser(_userDetails);
            // Updated/Created user
            NavigationParameters p = new NavigationParameters();
            p.Add("UserId", id);
            await _nav.GoBackAsync(p);
        }



        public void OnNavigatedFrom(NavigationParameters parameters)
        {
           
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            
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
