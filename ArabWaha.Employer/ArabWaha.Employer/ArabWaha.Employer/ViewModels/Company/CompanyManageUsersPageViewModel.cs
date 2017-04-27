using ArabWaha.Core.ModelsEmployer.Company;
using ArabWaha.Core.Services;
using ArabWaha.Employer.BaseCalsses;
using ArabWaha.Employer.Controls;
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
            Title = "Manage Company Users";
            IsBusy = false;

            Tab1Text = "Representatives";
            Tab2Text = "Recruiters";

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

        private void DeleteRec(CompanyUserDetails obj)
        {
            this._dialog.DisplayAlertAsync("Delete", "Delete Recruiter User?", "OK", "Cancel");

        }

        private void DeleteRep(CompanyUserDetails obj)
        {
            this._dialog.DisplayAlertAsync("Delete", "Delete Representative User?", "OK", "Cancel");
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

        void LoadData()
        {

            Task.Run(async () =>
            {
                // get data
                ApiService apiServ = new ApiService();
                RepresentativeUsers = await apiServ.GetCompanyRepresentativeUsersAsync(0);
            });

            Task.Run(async () =>
            {
                // get data
                ApiService apiServ = new ApiService();
                RecruiterUsers = await apiServ.GetCompanyRecruiterUserssAsync(100);
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
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            LoadData();
        }

        #endregion


    }
}
