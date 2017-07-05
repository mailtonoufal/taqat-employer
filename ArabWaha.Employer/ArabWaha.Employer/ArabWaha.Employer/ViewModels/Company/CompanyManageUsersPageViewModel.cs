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
using ArabWaha.Web;
using ArabWaha.Core.Models.SubUser;
using ArabWaha.Common;

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

        private ObservableCollection<SubUser> _representativeUsers;
        public ObservableCollection<SubUser> RepresentativeUsers
        {
            get { return _representativeUsers; }
            set { SetProperty(ref _representativeUsers, value); }
        }

        private ObservableCollection<SubUser> _recruiterUsers;
        public ObservableCollection<SubUser> RecruiterUsers
        {
            get { return _recruiterUsers; }
            set { SetProperty(ref _recruiterUsers, value); }
        }

        private ObservableCollection<SubUser> _subUsers;
        public ObservableCollection<SubUser> subUsers
        {
            get { return _subUsers; }
            set { SetProperty(ref _subUsers, value); }
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

            DeleteRepCommand = new DelegateCommand<SubUser>(DeleteRep);

            DeleteRecCommand = new DelegateCommand<SubUser>(async (obj) =>
            {
                await DeleteRec(obj);

            });

            UserDetailCommand = new DelegateCommand<SubUser>(UserDetails);
        }



        private void UserDetails(SubUser obj)
        {
            _nav.NavigateAsync($"{nameof(CompanyUserDetailsPage)}?UserId={obj.eyrUserCredentialId}");
        }

        private async Task DeleteRec(SubUser obj)
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
                Dialog.ShowLoading();
                var isDeleted = await api.DeleteCompanyUserAsync(obj.eyrUserCredentialId);
                Dialog.HideLoading();
                if (isDeleted)
                {
                    Dialog.ShowLoading();
                    await LoadData();
                    Dialog.HideLoading();
                }
                else
                {
                    Dialog.ShowErrorAlert("Unable to delete");
                }

            }
        }


        private async void DeleteRep(SubUser obj)
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
                await api.DeleteCompanyUserAsync(obj.eyrUserCredentialId);
                UpdateRepresentatives();
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


        public void AddButtonClick()
        {
            if (IsTab1Selected)
            {
                AddRepresentative();
            }
            else
            {
                AddRecruiter();

            }
        }

        void UpdateRepresentatives()
        {
            if (subUsers != null && subUsers.Count > 0)
            {
                RepresentativeUsers = new ObservableCollection<SubUser>(subUsers.Where(o => o.role == "OFFREP"));
            }

        }

        void UpdateRecruiters()
        {
            if (subUsers != null && subUsers.Count > 0)
            {
                RecruiterUsers = new ObservableCollection<SubUser>(subUsers.Where(o => o.role == "RCRTR"));
            }
            foreach (var item in RecruiterUsers)
            {
                item.DeleteCommand = new DelegateCommand<SubUser>(async (obj) =>
                {

                    await DeleteRec(obj);
                });
            }
        }


        #region Commands

        public DelegateCommand Tab1Command { get; set; }
        public DelegateCommand Tab2Command { get; set; }

        public DelegateCommand SearchBarCommand { get; set; }

        public DelegateCommand AddRecruiterCommand { get; set; }
        public DelegateCommand AddRepresentativeCommand { get; set; }

        public DelegateCommand<SubUser> DeleteRecCommand { get; set; }

        public DelegateCommand<SubUser> DeleteRepCommand { get; set; }

        public DelegateCommand<SubUser> UserDetailCommand { get; set; }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            // In theory only one company id so we should set it globally when user has logged in..       

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            //Get the SubUserDetails
            Task.Run(async () =>
            {
                Dialog.ShowLoading();
                await LoadData();
                Dialog.HideLoading();

            });

        }

        private async Task LoadData()
        {
            if (!Constants.IsStaticDataRequired)
            {
                var subUserDetails = await AWHttpClient.Instance.GetSubUser("1237894562", "PUBE");
                if (subUserDetails.IsSuccess)
                {
                    if (subUserDetails.Result != null && subUserDetails.Result.subUsersListObject != null && subUserDetails.Result.subUsersListObject.subUsersList.Count > 0)
                    {
                        subUsers = new ObservableCollection<SubUser>(subUserDetails.Result.subUsersListObject.subUsersList);

                    }
                }
            }
            else
            {
                subUsers = new ObservableCollection<SubUser>();
                subUsers.Add(new SubUser() { email = "ashutoshg88@aecl.com", username = "ashugupta88", existFlag = true, userType = "AOB", role = "OFFREP", eyrUserCredentialId = 6321004, ninIqama = "1122334444" });
                subUsers.Add(new SubUser() { email = "test5252@cuvox.de", username = "test5252", existFlag = true, userType = "AOB", role = "RCRTR", eyrUserCredentialId = 6319101, ninIqama = "1617823671" });
            }

            if (subUsers != null && subUsers.Count > 0)
            {
                UpdateRepresentatives();
                UpdateRecruiters();
            }
        }

        #endregion


    }
}
