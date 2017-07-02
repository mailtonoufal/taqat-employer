using ArabWaha.Core.ModelsEmployer.Company;
using ArabWaha.Core.Services;
using ArabWaha.Employer.BaseCalsses;
using ArabWaha.Employer.Views;
using ArabWaha.Common;
using Prism.Commands;
using ArabWaha.Models;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System.Threading.Tasks;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using ArabWaha.Core.Models.Company;
using ArabWaha.Web;
using ArabWaha.Core.DBAccess;
using System.Diagnostics;

namespace ArabWaha.Employer.ViewModels
{
    public class CompanyDetailsPageViewModel : AWMVVMBase, INavigationAware
    {

        private MyCompany _companyInfo;
        public MyCompany CompanyInfo
        {
            get { return _companyInfo; }
            set { SetProperty(ref _companyInfo, value); }
        }


        public DelegateCommand<string> CallCommand { get; set; }
        public DelegateCommand ManageCommand { get; set; }


        public  CompanyDetailsPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {
            SetDefaultColumn(0, 1);
            CallCommand = new DelegateCommand<string>(CallNumber);
            ManageCommand = new DelegateCommand(ManageCompany);
           
            DbAccessor db = new DbAccessor();
            //retrieve the company details from the db
		    var myCompanyFromDb = db.GetTableItems<MyCompany>();

            var MyCompanyDetails = myCompanyFromDb[0];

            CompanyInfo = myCompanyFromDb[0];


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
           // SetupTestData();
        }

       
    }
}
