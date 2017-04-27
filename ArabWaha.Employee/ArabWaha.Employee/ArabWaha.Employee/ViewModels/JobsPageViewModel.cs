using ArabWaha.Core.ModelsEmployer.Jobs;
using ArabWaha.Core.ModelsIndividual.Jobs;
using ArabWaha.Core.Services;
using ArabWaha.Employee.BaseClasses;
using ArabWaha.Employee.Controls;
using ArabWaha.Employee.Layouts;
using ArabWaha.Employee.Views.Jobs;
using ArabWaha.Models;
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

namespace ArabWaha.Employee.ViewModels
{
    public class JobsPageViewModel : AWMVVMBase, INavigatedAware
    {
        TabControl _ctrl;

        public JobsPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {
            Tab1Command = new DelegateCommand(SetMatchedJobs);
            Tab2Command = new DelegateCommand(SetAppliedJobs);
            Tab3Command = new DelegateCommand(SetWatchList);
            SearchBarCommand = new DelegateCommand(ExecuteSearch);

            // load any data we need here
            // load views    
            LoadContentViews();

            // view applied jobs
            ViewJobCommand = new DelegateCommand<JobApplication>(ProcessViewJob);
            ViewJobCommandmatched = new DelegateCommand<EmployerJobDetail>(ProcessViewJobMatched);
            ViewJobCommandWatched = new DelegateCommand<EmployerJobDetail>(ProcessViewJobWatched);
            RemoveWatchedCommandmatched = new DelegateCommand<EmployerJobDetail>(ProcessRemoveJobWatched);
        }

        void LoadContentViews()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                // load data first 
                ApiServiceIndividual apiServ = new ApiServiceIndividual();
                MatchedJobsSource = await apiServ.GetMatchedJobsAsync();

                MatchedJobsContent = new MatchedJobsContent();
                SetMatchedJobs();

            });

            Task.Run(async () =>
            {
                ApiServiceIndividual apiServ = new ApiServiceIndividual();
                AppliedJobsSource = await apiServ.GetAppliedJobsAsync(); 
                AppliedJobsContent = new AppliedJobsContent();
            });

            Task.Run(async () =>
            {
                ApiServiceIndividual apiServ = new ApiServiceIndividual();
                WatchListJobsSource = await apiServ.GetWatchedJobsAsync(); 
                WatchListContent = new WatchListContent();

                // bind data here
            });

        }

        public void SetTabs(TabControl ctrl)
        {
            _ctrl = ctrl;

            _ctrl.SetSearchVisible(true);
            if (GlobalSetting.CultureCode.Equals("en"))
                _ctrl.SetTabText("Matched Jobs", "Applied Jobs", "Watch List");
            else
                _ctrl.SetTabText("وظائف متطابقة", "وظائف تطبيقية", "قائمة المراقبة");


            _ctrl.SetTabVisble(1);
        }


        #region setup content views

        private MatchedJobsContent _matchedJobsContent;
        private MatchedJobsContent MatchedJobsContent
        {
            get { return _matchedJobsContent; }
            set { SetProperty<MatchedJobsContent>(ref _matchedJobsContent, value); }
        }

        private AppliedJobsContent _appliedJobsContent;
        private AppliedJobsContent AppliedJobsContent
        {
            get { return _appliedJobsContent; }
            set { SetProperty<AppliedJobsContent>(ref _appliedJobsContent, value); }
        }

        private WatchListContent _watchListContent;
        private WatchListContent WatchListContent
        {
            get { return _watchListContent; }
            set { SetProperty<WatchListContent>(ref _watchListContent, value); }
        }

        #endregion

        #region content sources

        private ObservableCollection<EmployerJobDetail> _matchedJobsSource;
        public ObservableCollection<EmployerJobDetail> MatchedJobsSource
        {
            get { return _matchedJobsSource; }
            set { SetProperty<ObservableCollection<EmployerJobDetail>>(ref _matchedJobsSource, value); }
        }

        // AppliedJob
        private ObservableCollection<JobApplication> _appliedJobsSource;
        public ObservableCollection<JobApplication> AppliedJobsSource
        {
            get { return _appliedJobsSource; }
            set { SetProperty<ObservableCollection<JobApplication>>(ref _appliedJobsSource, value); }
        }

        private ObservableCollection<EmployerJobDetail> _watchListSource;
        public ObservableCollection<EmployerJobDetail> WatchListJobsSource
        {
            get { return _watchListSource; }
            set { SetProperty<ObservableCollection<EmployerJobDetail>>(ref _watchListSource, value); }
        }

        #endregion

        #region Commands


        public DelegateCommand<EmployerJobDetail> ViewJobCommandmatched { get; set; }

        public DelegateCommand<EmployerJobDetail> ViewJobCommandWatched { get; set; }

        public DelegateCommand<EmployerJobDetail> RemoveWatchedCommandmatched { get; set; }

        public DelegateCommand<JobApplication> ViewJobCommand { get; set; }
        async void ProcessViewJob(JobApplication vals)
        {
            if (vals != null)
            {
                NavigationParameters paramx = new NavigationParameters();
                paramx.Add("MODE", "VIEWONLY");
                paramx.Add("DETAILS", vals.JobDetails);
                await _nav.NavigateAsync(nameof(DisplayJobPage), paramx, false, true);
            }
        }

        async void ProcessViewJobMatched(EmployerJobDetail vals)
        {
            if (vals != null)
            {
                NavigationParameters paramx = new NavigationParameters();
                paramx.Add("MODE", "MATCHED");
                paramx.Add("DETAILS", vals);
                await _nav.NavigateAsync(nameof(DisplayJobPage), paramx, false, true);
            }
        }

        async void ProcessViewJobWatched(EmployerJobDetail vals)
        {
            if (vals != null)
            {
                NavigationParameters paramx = new NavigationParameters();
                paramx.Add("MODE", "WATCHED");
                paramx.Add("DETAILS", vals);
                await _nav.NavigateAsync(nameof(DisplayJobPage), paramx, false, true);
            }
        }

        async void ProcessRemoveJobWatched(EmployerJobDetail vals)
        {
            if (vals != null)
            {
                ApiServiceIndividual api = new ApiServiceIndividual();
                await api.DeleteWatchListJobasync(vals.JobPostId);

                WatchListJobsSource.Remove(vals);

                await _dialog.DisplayAlertAsync("WatchList", "Removed from watchlist", "Ok");
            }
        }

        public DelegateCommand Tab1Command { get; set; }
        public DelegateCommand Tab2Command { get; set; }
        public DelegateCommand Tab3Command { get; set; }
        public DelegateCommand SearchBarCommand { get; set; }

        private void SetMatchedJobs()
        {
            SetCurrentTab(1);
            CurrentView = MatchedJobsContent;
        }

        private void SetAppliedJobs()
        {
            SetCurrentTab(2);
            CurrentView = AppliedJobsContent;
        }

        private void SetWatchList()
        {
            SetCurrentTab(3);
            CurrentView = WatchListContent;
        }
        private void ExecuteSearch()
        {

        }

        private void SetCurrentTab(int num)
        {
            if (_ctrl != null)
            {
                //MessagingCenter.Send(this, "HideMenu");
                _ctrl.SetTabVisble(num);
            }

        }



        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            // check param mode to refresh the lists we have in jobs
            // JOBWATCHREMOVE / JOBWATCHADD / JOBAPPLY
            var data = parameters.Where(x => x.Key == "JOBWATCHREMOVE").FirstOrDefault();
            if(data.Value!=null)
            {
                var postid = data.Value.ToString();
                var item = WatchListJobsSource.Where(x => x.JobPostId == postid).FirstOrDefault();
                if (item != null)
                    WatchListJobsSource.Remove(item);
            }

            // add watch
            data = parameters.Where(x => x.Key == "JOBWATCHADD").FirstOrDefault();
            if (data.Value != null)
            {
                var postid = data.Value.ToString();
                ApiServiceIndividual api = new ApiServiceIndividual();
                var item = await api.GetWatchedJobsSingleAsync(postid);
                if (item != null)
                    WatchListJobsSource.Add(item);
            }

            // apply job list
            data = parameters.Where(x => x.Key == "JOBAPPLY").FirstOrDefault();
            if (data.Value != null)
            {
                // trigger apply job here...
            }

        }

        #endregion
        #region views

        private ContentView _CurrentView;

        public ContentView CurrentView
        {
            get
            {
                return _CurrentView;
            }
            set
            {
                // check if are auth'd
                if(!Core.Services.AuthService.IsAuthorised)
                {
                    // NotLoggedInContent
                    SetProperty<ContentView>(ref _CurrentView, new NotLoggedInContent());
                }
                else if (value != null)
                    SetProperty<ContentView>(ref _CurrentView, value);
            }
        }


        #endregion


    }
}
