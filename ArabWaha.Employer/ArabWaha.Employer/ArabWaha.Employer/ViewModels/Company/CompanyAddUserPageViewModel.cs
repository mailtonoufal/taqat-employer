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

        private int _userRoleSelectedIndex;
        public int userRoleSelectedIndex
		{
			get { return _userRoleSelectedIndex; }
			set { SetProperty(ref _userRoleSelectedIndex, value); }
		}


		private List<string> _userRoleList;
		public List<string> userRoleList
		{
			get { return _userRoleList; }
			set { SetProperty(ref _userRoleList, value); }
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
            userRoleList = new List<string>();
            userRoleList.Add("Recruiter");
            userRoleList.Add("User");
            userRoleSelectedIndex = 0;
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            UserDetails = new CompanyUserDetails();
            UserDetails.AssignedRole = (string)parameters["UserRole"];
        }

    }
}
