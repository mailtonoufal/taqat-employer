using ArabWaha.Core.BaseClasses;
using ArabWaha.Core.ModelsEmployer.Jobs;
using ArabWaha.Core.ModelsEmployer.Programs;
using ArabWaha.Core.ModelsEmployer.Services;
using ArabWaha.Core.Services;
using ArabWaha.Employer.BaseCalsses;
using ArabWaha.Employer.Controls;
using ArabWaha.Employer.Helpers;
using ArabWaha.Employer.Layouts;
using ArabWaha.Employer.Layouts.Home;
using ArabWaha.Employer.Views;
using ArabWaha.Employer.Views.Home;
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
using System.Windows.Input;
using Xamarin.Forms;

namespace ArabWaha.Employer.ViewModels
{
    public class HomePageViewModel : AWMVVMBase, INavigatedAware
    {

        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set { SetProperty(ref _searchText, value); }
        }

        TabControl _ctrl;


        public HomePageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {
            IsBusy = false;

            _nav = navigationService;
            _dialog = dialog;

            Tab1Command = new DelegateCommand(SetHome);
            Tab2Command = new DelegateCommand(SetJobPosts);
            Tab3Command = new DelegateCommand(Setprograms);
            Tab4Command = new DelegateCommand(SetServices);
            SearchBarCommand = new DelegateCommand(ExecuteSearch);

            // job commands
            DeleteJobCommand = new DelegateCommand<EmployerJobDetail>(ProcessDeleteJob);
            EditJobCommand = new DelegateCommand<EmployerJobDetail>(ProcessEditJob);
            ViewJobCommand = new DelegateCommand<EmployerJobDetail>(ProcessViewJob);
            ProgramSelectedCommand = new DelegateCommand<EmployerProgram>(ProcessProgramSelected);
            ServicesSelectedCommand = new DelegateCommand<EmployerService>(ProcessServicesSelectedCommand);
            AddNewJobCommand = new DelegateCommand(ProcessAddNewJobCommand);

            // load views    
            LoadContentViews();
        }


        void LoadContentViews()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                // load data first 
                ApiService apiServ = new ApiService();
                HomePageSource = await apiServ.GetAnnouncementsAsync();

                // need to pull from db
                SwipeSource = new List<SfRotatorItem>() {
                new SfRotatorItem() {  Image="sample_carousel.png" },
                new SfRotatorItem() {  Image="sample_carousel.png"  },
                new SfRotatorItem() { ItemContent = new Label { Text = "tab image 3 will be here" ,TextColor=Color.Black }, BackgroundColor=Color.Transparent,  Image="sample_carousel.png" } ,
                new SfRotatorItem() { ItemContent = new Label { Text = "tab image 4 will be here", TextColor = Color.Black }, BackgroundColor = Color.Transparent, Image="sample_carousel.png" } };

                HomeContent = new HomeHomeContent();
                SetHome();

            });

            Task.Run(async () =>
            {
                ApiService apiServ = new ApiService();
                JobPageSource = await apiServ.GetEmployerPostedJobsAsync(1);

                TranslateExtension tran = new TranslateExtension();
                
                // mod the text here for translations 
                foreach (var t in JobPageSource)
                {
                    t.JobStatusText = tran.GetProviderValueString("LabelJobStatus");  
                    t.PostedText = tran.GetProviderValueString("LabelJobPosted");

                    if (string.IsNullOrEmpty(t.CompanyLogo)) t.CompanyLogo = "jobcompanyicon.png";
                }

                JobContent = new HomeJobPostsContent();
            });

            Task.Run(async () =>
            {
                ApiService apiServ = new ApiService();
                ServicesPageSource = await apiServ.GetEmployerServicesAsync(0); // add employer id if logged on
                ServicesContent = new HomeServicesContent();
            });

            Task.Run(async () =>
            {
                // get data
                ApiService apiServ = new ApiService();
                ProgramsPageSource = await apiServ.GetCurrentProgramsAsync();

                TranslateExtension tran = new TranslateExtension();
                string progStatusLabel = tran.GetProviderValueString("LabelProgramStatusText");
                // setup Program Status:
                foreach(var item in ProgramsPageSource)
                {
                    item.StatusLabelText = progStatusLabel;
                }



                ProgramsContent = new HomeProgramsContent();
            });

        }

        public void SetTabs(TabControl ctrl)
        {
            if (_ctrl != null) return;
            _ctrl = ctrl;

            _ctrl.SetSearchVisible(true);

            TranslateExtension tran = new TranslateExtension();
            string _Home = tran.GetProviderValueString("MenuHome");
            string _JobPosts = tran.GetProviderValueString("MenuJobPosts");
            string _Programs = tran.GetProviderValueString("MenuPrograms");
            string _Services = tran.GetProviderValueString("MenuServices");

            _ctrl.SetTabText(_Home, _JobPosts, _Programs, _Services);


            //if (CultureCode.Equals("en"))
            //    _ctrl.SetTabText("Home", "Jobs Posts", "Programs", "Services");
            //else
            //    _ctrl.SetTabText("الصفحة الرئيسية", "وظائف الوظائف", "البرامج", "خدمات");


            _ctrl.SetTabVisble(1);
        }


        #region Commands

        public DelegateCommand Tab1Command { get; set; }
        public DelegateCommand Tab2Command { get; set; }
        public DelegateCommand Tab3Command { get; set; }
        public DelegateCommand Tab4Command { get; set; }

        public DelegateCommand SearchBarCommand { get; set; }


        #region setup content views
        // create dynamic content view or not?
        private HomeHomeContent _homeContent;
        private HomeHomeContent HomeContent
        {
            get { return _homeContent; }
            set { SetProperty<HomeHomeContent>(ref _homeContent, value); }
        }

        private HomeServicesContent _servicesContent;
        private HomeServicesContent ServicesContent
        {
            get { return _servicesContent; }
            set { SetProperty<HomeServicesContent>(ref _servicesContent, value); }
        }

        private HomeJobPostsContent _jobContent;
        private HomeJobPostsContent JobContent
        {
            get { return _jobContent; }
            set { SetProperty<HomeJobPostsContent>(ref _jobContent, value); }
        }

        private HomeProgramsContent _programsContent;
        private HomeProgramsContent ProgramsContent
        {
            get { return _programsContent; }
            set { SetProperty<HomeProgramsContent>(ref _programsContent, value); }
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

            var res = await _dialog.DisplayActionSheetAsync(confirm, cancel, delete, "");
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
        public DelegateCommand<EmployerProgram> ProgramSelectedCommand { get; set; }
        async void ProcessProgramSelected(EmployerProgram vals)
        {
            if (vals != null)
            {
                NavigationParameters paramx = new NavigationParameters();
                paramx.Add("Data", vals); 
                await _nav.NavigateAsync(nameof(ProgramDetailsPage), paramx, false, true);
            }
        }

        // ServicesSelectedCommand
        public DelegateCommand<EmployerService> ServicesSelectedCommand { get; set; }
        async void ProcessServicesSelectedCommand(EmployerService vals)
        {
            if (vals != null)
            {
                NavigationParameters paramx = new NavigationParameters();
                paramx.Add("Data", vals);
                await _nav.NavigateAsync(nameof(ServiceDetailsPage), paramx, false, true);
            }
        }

        public DelegateCommand AddNewJobCommand { get; set; }
        async void ProcessAddNewJobCommand()
        {
                NavigationParameters paramx = new NavigationParameters();
                paramx.Add("MODE", "NEW");
                await _nav.NavigateAsync(nameof(JobNewPostPage), paramx, false, true);
        }


        #endregion

        #region sources

        private ObservableCollection<Announcement> _homePageSource;
        public ObservableCollection<Announcement> HomePageSource
        {
            get { return _homePageSource; }
            set { SetProperty<ObservableCollection<Announcement>>(ref _homePageSource, value);}
        }

        private ObservableCollection<EmployerJobDetail> _jobPageSource;
        public ObservableCollection<EmployerJobDetail> JobPageSource
        {
            get { return _jobPageSource; }
            set { SetProperty<ObservableCollection<EmployerJobDetail>>(ref _jobPageSource, value); }
        }

        // ProgramsPageSource
        private ObservableCollection<EmployerProgram> _programsPageSource;
        public ObservableCollection<EmployerProgram> ProgramsPageSource
        {
            get { return _programsPageSource; }
            set { SetProperty<ObservableCollection<EmployerProgram>>(ref _programsPageSource, value); }
        }

        // EmployerService source
        private ObservableCollection<EmployerService> _servicesPageSource;
        public ObservableCollection<EmployerService> ServicesPageSource
        {
            get { return _servicesPageSource; }
            set { SetProperty<ObservableCollection<EmployerService>>(ref _servicesPageSource, value); }
        }


        private List<SfRotatorItem> _swipeSource;

        public List<SfRotatorItem> SwipeSource
        {
            get { return _swipeSource; }
            set { _swipeSource = value; }
        }


        #endregion

        private void SetHome()
        {
            SetCurrentTab(1);
            CurrentView = HomeContent;
        }

        private void SetJobPosts()
        {
            SetCurrentTab(2);
            CurrentView = JobContent;
        }

        private void Setprograms()
        {
            SetCurrentTab(3);
            CurrentView = ProgramsContent;
        }
 
        private void SetServices()
        {
            SetCurrentTab(4);
            CurrentView = ServicesContent;
        }

        private void SetCurrentTab(int num)
        {
            if (_ctrl != null)
            {
                MessagingCenter.Send(this, "HideMenu");
                _ctrl.SetTabVisble(num);
            }

        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        private void ExecuteSearch()
        {
            if (!string.IsNullOrEmpty(SearchText))
            {
                _nav.NavigateAsync($"{nameof(SearchResultsPage)}?SearchText={SearchText}");
            }

        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            
            var tab = parameters.Where(x => x.Key == "TAB").FirstOrDefault();
            if (tab.Value != null && (!string.IsNullOrEmpty(tab.Value.ToString())))
            { 
                int x;
                if (int.TryParse(tab.Value.ToString(), out x))
                {
                    switch(x)
                    {
                        case 1:
                            SetHome();
                            break;
                        case 2:
                            SetJobPosts();
                            break;
                        case 3:
                            Setprograms();
                            break;
                        case 4:
                            SetServices();
                            break;

                    }
                }
            }
            else             // do we have a job update
            {
                tab = parameters.Where(x => x.Key == "JOBUPDATE").FirstOrDefault();
                if (tab.Value != null && (!string.IsNullOrEmpty(tab.Value.ToString())))
                {
                    // parameters	{?DATA=JOBUPDATE&__NavigationMode=Back}	Prism.Navigation.NavigationParameters
                    var val = tab.Value.ToString();

                    ApiService apiServ = new ApiService();
                    var updated = await apiServ.GetEmployerPostedJobsSingleAsync(val);

                    var existing = JobPageSource.Where(x => x.JobPostId == val).FirstOrDefault();
                    if (existing != null)
                    {
                        var index = JobPageSource.IndexOf(existing);
                        JobPageSource.Remove(existing);
                        JobPageSource.Insert(index, updated);
                    }
                    else
                        JobPageSource.Add(updated); // must be a new job


                }


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

                //if (value != null)
                //    SetProperty<ContentView>(ref _CurrentView, value);

                if (!Core.Services.AuthService.IsAuthorised && (
                    value is HomeJobPostsContent 
                    || value is HomeServicesContent
                    || value is HomeProgramsContent))
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
