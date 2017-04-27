using ArabWaha.Core.BaseClasses;
using ArabWaha.Core.ModelsEmployer.Jobs;
using ArabWaha.Core.ModelsIndividual.Jobs;
using ArabWaha.Core.ModelsIndividual.Programs;
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
using Syncfusion.SfRotator.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ArabWaha.Employee.ViewModels
{
    public class HomePageViewModel : AWMVVMBase, INavigatedAware
    {

        // bit hacky fix when more time
        TabControl _ctrl;

        public HomePageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {

            Tab1Command = new DelegateCommand(SetAnnouncements);
            Tab2Command = new DelegateCommand(SetAppliedJobs);
            Tab3Command = new DelegateCommand(SetMyPrograms);
            SearchBarCommand = new DelegateCommand(ExecuteSearch);

            // view applied jobs
            ViewJobCommand = new DelegateCommand<JobApplication>(ProcessViewJob);

            // load any data we need here
            // load views    
            LoadContentViews();

        }

        void LoadContentViews()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                // load data first 
                ApiServiceIndividual apiServ = new ApiServiceIndividual();
                AnnouncementsSource = await apiServ.GetAnnouncementsAsync();

                // setup banners here
                // need to pull from db
                SwipeSource = new List<SfRotatorItem>() {
                new SfRotatorItem() { ItemContent = new Label { Text = "tab image 1 will be here", TextColor=Color.Black }, BackgroundColor=Color.Transparent },
                new SfRotatorItem() { ItemContent = new Label { Text = "tab image 2 will be here" ,TextColor=Color.Black }, BackgroundColor=Color.Transparent  },
                new SfRotatorItem() { ItemContent = new Label { Text = "tab image 3 will be here" ,TextColor=Color.Black }, BackgroundColor=Color.Transparent  } ,
                new SfRotatorItem() { ItemContent = new Label { Text = "tab image 4 will be here", TextColor = Color.Black }, BackgroundColor = Color.Transparent  } };



                AnnouncementContent = new HomePageContent();
                SetAnnouncements();

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
                MyProgramsSource = await apiServ.GetMyProgramsAsync(); // add employer id if logged on
                MyProgramsContent = new MyProgramsContent();

                // bind data here
            });
        }

        public void SetTabs(TabControl ctrl)
        {
            _ctrl = ctrl;

            _ctrl.SetSearchVisible(true);

            if(GlobalSetting.CultureCode.Equals("en"))
                _ctrl.SetTabText("Announcements", "Applied Jobs", "My programs");
            else
                _ctrl.SetTabText("الإعلانات", "وظائف تطبيقية", "برامجي");


            _ctrl.SetTabVisble(1);
        }

    
        #region Commands

        public DelegateCommand Tab1Command { get; set; }
        public DelegateCommand Tab2Command { get; set; }
        public DelegateCommand Tab3Command { get; set; }
        public DelegateCommand SearchBarCommand { get; set; }

        private void SetAnnouncements()
        {
            SetCurrentTab(1);
            CurrentView = AnnouncementContent;
        }

        private void SetAppliedJobs()
        {
            SetCurrentTab(2);
            CurrentView = AppliedJobsContent;
        }

        private void SetMyPrograms()
        {
            SetCurrentTab(3);
            CurrentView = MyProgramsContent;
        }
        private void ExecuteSearch()
        {
            // do search here

        }

        private void SetCurrentTab(int num)
        {
            if (_ctrl != null)
            {
                //MessagingCenter.Send(this, "HideMenu");
                _ctrl.SetTabVisble(num);
            }

        }

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

        #region tab views

        private HomePageContent _announcementContent;
        private HomePageContent AnnouncementContent
        {
            get { return _announcementContent; }
            set { SetProperty<HomePageContent>(ref _announcementContent, value); }
        }

        private AppliedJobsContent _appliedJobsContent;
        private AppliedJobsContent AppliedJobsContent
        {
            get { return _appliedJobsContent; }
            set { SetProperty<AppliedJobsContent>(ref _appliedJobsContent, value); }
        }

        private MyProgramsContent _myProgramsContent;
        private MyProgramsContent MyProgramsContent
        {
            get { return _myProgramsContent; }
            set { SetProperty<MyProgramsContent>(ref _myProgramsContent, value); }
        }

        #endregion

        #region tab Sources


        private List<SfRotatorItem> _swipeSource;

        public List<SfRotatorItem> SwipeSource
        {
            get { return _swipeSource; }
            set { _swipeSource = value; }
        }



        private ObservableCollection<Announcement> _announcementsSource;
        public ObservableCollection<Announcement> AnnouncementsSource
        {
            get { return _announcementsSource; }
            set { SetProperty<ObservableCollection<Announcement>>(ref _announcementsSource, value); }
        }

        // AppliedJob
        private ObservableCollection<MyProgramItem> _myProgramsSource;
        public ObservableCollection<MyProgramItem> MyProgramsSource
        {
            get { return _myProgramsSource; }
            set { SetProperty<ObservableCollection<MyProgramItem>>(ref _myProgramsSource, value); }
        }

        private ObservableCollection<JobApplication> _appliedJobsSource;
        public ObservableCollection<JobApplication> AppliedJobsSource
        {
            get { return _appliedJobsSource; }
            set { SetProperty<ObservableCollection<JobApplication>>(ref _appliedJobsSource, value); }
        }

        #endregion

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            // debug text set initial page            
            //SetAnnouncements();
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
                if (!Core.Services.AuthService.IsAuthorised && (
                    value is AppliedJobsContent || value is MyProgramsContent))
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
