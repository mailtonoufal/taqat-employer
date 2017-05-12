using ArabWaha.Core.ModelsEmployer;
using ArabWaha.Core.ModelsEmployer.Jobs;
using ArabWaha.Core.ModelsEmployer.Programs;
using ArabWaha.Core.ModelsEmployer.Services;
using ArabWaha.Core.Services;
using ArabWaha.Employer.BaseCalsses;
using ArabWaha.Employer.Helpers;
using ArabWaha.Employer.Layouts;
using ArabWaha.Employer.Views;
using ArabWaha.Employer.Views.Home;
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
        Tab3View _ctrl;

        public void SetTabs(Tab3View ctrl)
        {
            if (_ctrl != null) return;
            _ctrl = ctrl;
            ApllicationsNavigate();
        }

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

        public DelegateCommand<ApplicationsForJob> ApplicationDetailsCommand { get; set; }

        private ObservableCollection<ApplicationsForJob> _watchList;
        public ObservableCollection<ApplicationsForJob> WatchList
        {
            get { return _watchList; }
            set { SetProperty(ref _watchList, value); }
        }

        public DelegateCommand<ApplicationProfile> InviteCommand { get; set; }


        private ObservableCollection<EmployerJobDetail> _jobPageSource;
        public ObservableCollection<EmployerJobDetail> JobPageSource
        {
            get { return _jobPageSource; }
            set { SetProperty(ref _jobPageSource, value); }
        }

        public ApplicationsPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {
            TranslateExtension tran = new TranslateExtension();

            Title =    tran.GetProviderValueString("LabelApplicationsTitle");

            Tab1Text = tran.GetProviderValueString("Applications");
            Tab2Text = tran.GetProviderValueString("LabelJobPosts");
            Tab3Text = tran.GetProviderValueString("LabelWatchList");

            ApplicationDetailsCommand = new DelegateCommand<ApplicationsForJob>(ApplicationDetails);
            Tab1Command = new DelegateCommand(ApllicationsNavigate);
            Tab2Command = new DelegateCommand(JobPostNavigate);
            Tab3Command = new DelegateCommand(WatchListNavigate);

            InviteCommand = new DelegateCommand<ApplicationProfile>(InviteCandidate);

            // job commands
            DeleteJobCommand = new DelegateCommand<EmployerJobDetail>(ProcessDeleteJob);
            EditJobCommand = new DelegateCommand<EmployerJobDetail>(ProcessEditJob);
            ViewJobCommand = new DelegateCommand<EmployerJobDetail>(ProcessViewJob);
            AddNewJobCommand = new DelegateCommand(ProcessAddNewJobCommand);

            // Default Tab1
         //   ApllicationsNavigate();

            LoadData();

            MessagingCenter.Subscribe<JobPageViewModel>(this, "WatchEntryUpdated", WatchEntryUpdatedMessage);

        }

        private void WatchEntryUpdatedMessage(JobPageViewModel obj)
        {
            LoadWatchList();
        }

        private void InviteCandidate(ApplicationProfile obj)
        {
            NavigationParameters p = new NavigationParameters();
            p.Add("JobPostId", obj.JobPostId);
            p.Add("ProfileId", obj.ProfileId);

            _nav.NavigateAsync(nameof(CandidateInvitePage), p);
        }

        private void ApllicationsNavigate()
        {
            IsTab1Selected = true;
            IsTab2Selected = IsTab3Selected = false;
            _ctrl.SetTabVisble(1);
            MessagingCenter.Send(this, "HideMenu");
        }

        private void WatchListNavigate()
        {
            IsTab3Selected = true;
            _ctrl.SetTabVisble(3);
            IsTab1Selected = IsTab2Selected = false;
            MessagingCenter.Send(this, "HideMenu");
        }

        private void JobPostNavigate()
        {
            IsTab2Selected = true;
            _ctrl.SetTabVisble(2);
            IsTab1Selected = IsTab3Selected = false;
            MessagingCenter.Send(this, "HideMenu");
        }

        private void ApplicationDetails(ApplicationsForJob obj)
        {
            _nav.NavigateAsync($"{nameof(ApplicationDetailsPage)}?JobPostId={obj.JobDetails.JobPostId}");
        }

        private async void LoadData()
        {
            ApiService api = new ApiService();
            CompanyApplicationList = await api.GetCompanyJobApplicationsAsync(0);
            Jobs = CompanyApplicationList.Jobs;
            JobPageSource = await api.GetEmployerPostedJobsAsync(1);

            TranslateExtension tran = new TranslateExtension();
            string displayJobText = tran.GetProviderValueString("LabelApplicationsToText");
            string applicationDateText = tran.GetProviderValueString("LabelApplicationDateText");

            // update job page source data
            foreach (var t in JobPageSource)
            {
                t.JobStatusText = tran.GetProviderValueString("LabelJobStatus");
                t.PostedText = tran.GetProviderValueString("LabelJobPosted");

                if (string.IsNullOrEmpty(t.CompanyLogo)) t.CompanyLogo = "jobcompanyicon.png";
            }



            // do a translate here
            foreach (var itemx in Jobs)
            {
                itemx.JobDetails.ApplicationsLanguageText = displayJobText;
                foreach (var appin in itemx.Applications)
                    appin.ApplicationDateText = applicationDateText;
            }



            LoadWatchList();
        }

        private async void  LoadWatchList()
        {
            ApiService api = new ApiService();
            WatchList = await api.GetCompanyWatchListAsync(0, 0);
        }

        #region Job Commands
        public DelegateCommand<EmployerJobDetail> ViewJobCommand { get; set; }
        async void ProcessViewJob(EmployerJobDetail vals)
        {
            if (vals != null)
            {
                NavigationParameters paramx = new NavigationParameters();
                paramx.Add("MODE", "VIEW");
                paramx.Add("JOB", vals);
                await _nav.NavigateAsync(nameof(JobPage), paramx, false, true);
            }
        }



        public DelegateCommand AddNewJobCommand { get; set; }
        async void ProcessAddNewJobCommand()
        {
            NavigationParameters paramx = new NavigationParameters();
            paramx.Add("MODE", "NEW");
            await _nav.NavigateAsync(nameof(JobNewPostPage), paramx, false, true);
        }

        // JOB edit / delete commands
        public DelegateCommand<EmployerJobDetail> DeleteJobCommand { get; set; }
        //        public DelegateCommand<EmployerJobDetail> EditJobCommand;
        //public ICommand EditJobCommand { get; }

        private async void ProcessDeleteJob(EmployerJobDetail vals)
        {
            TranslateExtension tran = new TranslateExtension();
            string confirm = tran.GetProviderValueString("ButtonConfirmDelete");
            string delete = tran.GetProviderValueString("ButtonDelete");
            string cancel = tran.GetProviderValueString("ButtonCancel");

            var res = await _dialog.DisplayActionSheetAsync("Confirm delete!!", "Cancel", "Delete", "");
            if (res.Equals(delete))
            {
                ApiService apiServ = new ApiService();
                if (await apiServ.DeleteEmployerJobasync(vals.JobPostId))
                {
                    JobPageSource.Remove(vals);
                }
            }
        }

        public DelegateCommand<EmployerJobDetail> EditJobCommand { get; set; }
        async void ProcessEditJob(EmployerJobDetail vals)
        {
            if (vals != null)
            {
                NavigationParameters paramx = new NavigationParameters();
                paramx.Add("MODE", "EDIT");
                paramx.Add("JOB", vals);
                await _nav.NavigateAsync(nameof(JobPage), paramx, false, true);
            }
        }





        #endregion  
    }
}
