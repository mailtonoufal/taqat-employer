using ArabWaha.Core.ModelsEmployer.Company;
using ArabWaha.Core.Services;
using ArabWaha.Employer.BaseCalsses;
using ArabWaha.Employer.Controls;
using ArabWaha.Employer.Helpers;
using ArabWaha.Employer.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ArabWaha.Employer.ViewModels
{
    public class CompanyManageUsersPageViewModel : AWMVVMBase, INavigationAware
    {
        private int companyId;

        private string _tab1Test;
        public string Tab1Text
        {
            get { return _tab1Test; }
            set { SetProperty(ref _tab1Test, value); }
        }

        private string _tab2Text;
        public string Tab2Text
        {
            get { return _tab2Text; }
            set { SetProperty(ref _tab2Text, value); }
        }

        private bool _isTab1Selected;
        public bool IsTab1Selected
        {
            get { return _isTab1Selected; }
            set { SetProperty(ref _isTab1Selected, value); }
        }

        private bool _isTab2Selected;
        public bool IsTab2Selected
        {
            get { return _isTab2Selected; }
            set { SetProperty(ref _isTab2Selected, value); }
        }

        private ObservableCollection<CompanyUserDetails> _representativeUsers;
        public ObservableCollection<CompanyUserDetails> RepresentativeUsers
        {
            get { return _representativeUsers; }
            set { SetProperty(ref _representativeUsers, value); }
        }

        private ObservableCollection<CompanyUserDetails> _recruiterUsers;
        public ObservableCollection<CompanyUserDetails> RecruiterUsers
        {
            get { return _recruiterUsers; }
            set { SetProperty(ref _recruiterUsers, value); }
        }

        

        public CompanyManageUsersPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {
            Title = TranslateExtension.GetString("ManageCompanyUsersTitle");
            IsBusy = false;

            Tab1Text = TranslateExtension.GetString("RepresentativesTab"); 
            Tab2Text = TranslateExtension.GetString("RecruitersTab");

            IsTab1Selected = true;

            Tab1Command = new DelegateCommand(Tab1Clicked);
            Tab2Command = new DelegateCommand(Tab2Clicked);
            //SearchBarCommand = new DelegateCommand(ExecuteSearch);

            AddRecruiterCommand = new DelegateCommand(AddRecruiter);
            AddRepresentativeCommand = new DelegateCommand(AddRepresentative);

            EditRepCommand = new DelegateCommand<CompanyUserDetails>(EditUser);
            DeleteRepCommand = new DelegateCommand<CompanyUserDetails>(DeleteRep);
            EditRecCommand = new DelegateCommand<CompanyUserDetails>(EditUser);
            DeleteRecCommand = new DelegateCommand<CompanyUserDetails>(DeleteRec);

            UserDetailCommand = new DelegateCommand<CompanyUserDetails>(UserDetails);
        }



        private void UserDetails(CompanyUserDetails obj)
        {
            _nav.NavigateAsync($"{nameof(CompanyUserDetailsPage)}?UserId={obj.UserId}");
        }

        private async void DeleteRec(CompanyUserDetails obj)
        {
            TranslateExtension trn = new TranslateExtension();

            var delete = trn.GetProviderValueString("ButtonDelete");
            var deleteMsg = trn.GetProviderValueString("DeleteUserRecruiterMessage");
            var ok = trn.GetProviderValueString("ButtonOk");
            var cancel = trn.GetProviderValueString("ButtonCancel");
            var res = await this._dialog.DisplayAlertAsync(delete, deleteMsg, ok, cancel);
            ApiService api = new ApiService();
            if (res == true)
            {
                await api.DeleteCompanyUserAsync(obj.UserId);
                UpdateRecruiters(companyId);
            }
        }
    

        private async void DeleteRep(CompanyUserDetails obj)
        {
            TranslateExtension trn = new TranslateExtension();
            var delete = trn.GetProviderValueString("ButtonDelete");
            var deleteMsg = trn.GetProviderValueString("DeleteUserRepresentativeMessage");
            var ok = trn.GetProviderValueString("ButtonOk");
            var cancel = trn.GetProviderValueString("ButtonCancel");
            var res = await this._dialog.DisplayAlertAsync(delete, deleteMsg, ok, cancel);
            ApiService api = new ApiService();
            if (res == true)
            {
                await api.DeleteCompanyUserAsync(obj.UserId);
                UpdateRepresentatives(companyId);
            }
        }

        private void EditUser(CompanyUserDetails obj)
        {
            _nav.NavigateAsync($"{nameof(CompanyEditUserDetailsPage)}?UserId={obj.UserId}");
        }
 

        private void AddRepresentative()
        {
            _nav.NavigateAsync($"{nameof(CompanyAddUserPage)}?UserRole=Representative");
        }

        private void AddRecruiter()
        {
            _nav.NavigateAsync($"{nameof(CompanyAddUserPage)}?UserRole=Recruiter");
        }

        private void Tab2Clicked()
        {
            IsTab2Selected = true;
            IsTab1Selected = !IsTab2Selected;
        }

        private void Tab1Clicked()
        {
            IsTab1Selected = true;
            IsTab2Selected = !IsTab1Selected;
        }

        void LoadData(int companyId)
        {

            UpdateRepresentatives(companyId);
            UpdateRecruiters(companyId);

        }

        void UpdateRepresentatives(int companyId)
        {
            Task.Run(async () =>
            {
                // get data
                ApiService apiServ = new ApiService();
                RepresentativeUsers = await apiServ.GetCompanyRepresentativeUsersAsync(companyId);
            });
        }

        void UpdateRecruiters(int companyId)
        {
            Task.Run(async () =>
            {
                // get data
                ApiService apiServ = new ApiService();
                RecruiterUsers = await apiServ.GetCompanyRecruiterUserssAsync(companyId);
            });
        }


        #region Commands

        public DelegateCommand Tab1Command { get; set; }
        public DelegateCommand Tab2Command { get; set; }

        public DelegateCommand SearchBarCommand { get; set; }

        public DelegateCommand AddRecruiterCommand { get; set; }
        public DelegateCommand AddRepresentativeCommand { get; set; }

        public DelegateCommand<CompanyUserDetails> EditRecCommand { get; set; }
        public DelegateCommand<CompanyUserDetails> DeleteRecCommand { get; set; }

        public DelegateCommand<CompanyUserDetails> EditRepCommand { get; set; }
        public DelegateCommand<CompanyUserDetails> DeleteRepCommand { get; set; }

        public DelegateCommand<CompanyUserDetails> UserDetailCommand { get; set; }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            LoadData(0);
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            // In theory only one company id so we should set it globally when user has logged in..       
            LoadData(0);
        }

        #endregion


    }
}
