using ArabWaha.Core.ModelsEmployer;
using ArabWaha.Core.ModelsEmployer.Jobs;
using ArabWaha.Core.Services;
using ArabWaha.Employer.BaseCalsses;
using ArabWaha.Employer.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace ArabWaha.Employer.ViewModels
{
    public class ApplicationsPageViewModel : AWMVVMBase
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

        private string _tab3Text;
        public string Tab3Text
        {
            get { return _tab3Text; }
            set { SetProperty(ref _tab3Text, value); }
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

        private bool _isTab3Selected;
        public bool IsTab3Selected
        {
            get { return _isTab3Selected; }
            set { SetProperty(ref _isTab3Selected, value); }
        }


        public DelegateCommand Tab1Command { get; set; }
        public DelegateCommand Tab2Command { get; set; }
        public DelegateCommand Tab3Command { get; set; }




        private ApplicationsForCompanyJobs _companyApplicationList;
        public ApplicationsForCompanyJobs CompanyApplicationList
        {
            get { return _companyApplicationList; }
            set { SetProperty<ApplicationsForCompanyJobs>(ref _companyApplicationList, value); }
        }

        private ObservableCollection<ApplicationsForJob> _jobs;
        public ObservableCollection<ApplicationsForJob> Jobs
        {
            get { return _jobs; }
            set { SetProperty(ref _jobs, value); }
        }

        public DelegateCommand ApplicationDetailsCommand { get; set; }

        private ObservableCollection<JobPostWatchList> _watchList;
        public ObservableCollection<JobPostWatchList> WatchList
        {
            get { return _watchList; }
            set { SetProperty(ref _watchList, value); }
        }

        public DelegateCommand InviteCommand { get; set; }


        private ObservableCollection<EmployerJobDetail> _jobPageSource;
        public ObservableCollection<EmployerJobDetail> JobPageSource
        {
            get { return _jobPageSource; }
            set { SetProperty(ref _jobPageSource, value); }
        }

        public ApplicationsPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {
            Title = "Jobs";
            Tab1Text = "Applications";
            Tab2Text = "Job Posts";
            Tab3Text = "Watch List";
            ApplicationDetailsCommand = new DelegateCommand(ApplicationDetails);
            Tab1Command = new DelegateCommand(ApllicationsNavigate);
            Tab2Command = new DelegateCommand(JobPostNavigate);
            Tab3Command = new DelegateCommand(WatchListNavigate);

            InviteCommand = new DelegateCommand(InviteCandidate);

            // Default Tab1
            ApllicationsNavigate();

            LoadData();

        }

        private void InviteCandidate()
        {
            _dialog.DisplayAlertAsync("Message", "Candidate Invite TODO", "OK");
        }

        private void ApllicationsNavigate()
        {
            IsTab1Selected = true;
            IsTab2Selected = IsTab3Selected = false;
            MessagingCenter.Send(this, "HideMenu");
        }

        private void WatchListNavigate()
        {
            IsTab3Selected = true;
            IsTab1Selected = IsTab2Selected = false;
            MessagingCenter.Send(this, "HideMenu");
        }

        private void JobPostNavigate()
        {
            IsTab2Selected = true;
            IsTab1Selected = IsTab3Selected = false;
            MessagingCenter.Send(this, "HideMenu");
        }

        private void ApplicationDetails()
        {
            _nav.NavigateAsync(nameof(ApplicationDetailsPage));
        }

        private async void LoadData()
        {
            ApiService api = new ApiService();
            CompanyApplicationList = await api.GetCompanyJobApplicationsAsync(0);
            Jobs = CompanyApplicationList.Jobs;

            WatchList = await api.GetCompanyWatchListAsync(0, 0);
            JobPageSource = await api.GetEmployerPostedJobsAsync(1);


        }
    }
}
