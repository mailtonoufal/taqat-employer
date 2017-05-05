using ArabWaha.Core.ModelsEmployer.Company;
using ArabWaha.Core.Services;
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
    public class CompanyDetailsPageViewModel : AWMVVMBase, INavigationAware
    {

        private CompanyDetails _companyInfo;
        public CompanyDetails CompanyInfo
        {
            get { return _companyInfo; }
            set { SetProperty(ref _companyInfo, value); }
        }


        public DelegateCommand<string> CallCommand { get; set; }
        public DelegateCommand ManageCommand { get; set; }


        public CompanyDetailsPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {
            SetDefaultColumn(0, 1);
            CallCommand = new DelegateCommand<string>(CallNumber);
            ManageCommand = new DelegateCommand(ManageCompany);
        }

        private void ManageCompany()
        {
            _nav.NavigateAsync(nameof(CompanyManageUsersPage));
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
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            SetupTestData();
        }

        private async void SetupTestData()
        {
            ApiService srv = new ApiService();
            CompanyInfo = await srv.GetCompanyDetailsAsync(10);
        }

    }
}
