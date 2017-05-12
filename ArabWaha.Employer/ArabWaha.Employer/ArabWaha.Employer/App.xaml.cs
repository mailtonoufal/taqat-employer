using Prism.Unity;
using ArabWaha.Employer.Views;
using Xamarin.Forms;
using System;
using ArabWaha.Core.Services;
using ArabWaha.Employer.Views.Menus;
using ArabWaha.Employer.Views.Home;
using ArabWaha.Employer.ViewModels;
using System.Linq;
using ArabWaha.Employer.Interfaces;
using System.Threading.Tasks;
using ArabWaha.Employer.Views.Detail;
using ArabWaha.Employer.Views.Settings;

namespace ArabWaha.Employer
{
    public static class GlobalSetting
    {
        public static string CultureCode { get; set; }
        public static LayoutAlignment AlignLabel { get; set; }
        public static LayoutAlignment AlignData { get; set; }

        public static TextAlignment AlignText { get; set; }
        public static TextAlignment AlignLabelText { get; set; }

        public static LayoutOptions HorizontalLayoutOptions { get; set; }

        public static bool IsArVisible { get; set; }
        public static bool IsEnVisible { get; set; }

        public static void SetupCulture()
        {
            ApiService svr = new ApiService();
            GlobalSetting.CultureCode = svr.GetCurrentCulture();
            GlobalSetting.AlignLabel = GlobalSetting.CultureCode == "ar" ? LayoutAlignment.End : LayoutAlignment.Start;
            GlobalSetting.AlignData = GlobalSetting.CultureCode == "ar" ? LayoutAlignment.Start : LayoutAlignment.End;
            GlobalSetting.HorizontalLayoutOptions = GlobalSetting.CultureCode == "ar" ? LayoutOptions.EndAndExpand : LayoutOptions.StartAndExpand;

            GlobalSetting.AlignText = GlobalSetting.CultureCode == "ar" ? TextAlignment.End : TextAlignment.Start;
            GlobalSetting.AlignLabelText = GlobalSetting.CultureCode == "ar" ? TextAlignment.End: TextAlignment.Start;

            GlobalSetting.IsArVisible = GlobalSetting.CultureCode == "ar" ? true : false;
            GlobalSetting.IsEnVisible = GlobalSetting.CultureCode == "ar" ? false : true;


        }

        #region well hacky till i fix this correctly for view cell items

        public static int LabelColumn { get; set; }
        public static int DataColumn { get; set; }
        public static int ImageColumn { get; set; }


        #endregion
    }


    public partial class App : PrismApplication
    {
      //  public static string CultureCode { get; set; }
        public static App _appInstance;
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            // debug test
            AuthService.IsAuthorised = false;

            // init db string in dependant pcl
            Core.DBAccess.DbAccessor.ConnectionString = DependencyService.Get<IDBInfo>().GetEmployerDbPath();

            // set culture code here
            GlobalSetting.SetupCulture();

            SyncDbAsync();

            _appInstance = this;
            SetStartPage(); // NavigationService.NavigateAsync($"NavigationPage/{nameof(StartPage)}");
        }

        public async void SetStartPage()
        {
            try {
                //await NavigationService.NavigateAsync($"NavigationPage/{nameof(StartPage)}");
                await NavigationService.NavigateAsync($"NavigationPage/{nameof(HomePage)}");
            }
            catch (Exception ex)
            {
                var t = ex.Message;
            }
         }

        async Task SyncDbAsync()
        {
            ApiService svr = new ApiService(); // sync any data we need here for testing and for api when live
            svr.SyncAPiToDB();
        }

        public void Navigate(Type navToPage)
        {
            NavigationService.NavigateAsync(nameof(navToPage));
        }

        public void Navigate(MasterPageItem item)
        {
            NavigationService.NavigateAsync(new Uri(item.TargetType, UriKind.Relative));
        }

        public void SetRootPage(MasterPageItem item)
        {
            // need to check for params if we are passing them 
            NavigationService.NavigateAsync($"NavigationPage/{item.TargetType}");
        }


        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<PasswordPage, PasswordPageViewModel>();
            Container.RegisterTypeForNavigation<SearchPage,SearchPageViewModel>();
            Container.RegisterTypeForNavigation<SignUpPage, SignUpPageViewModel>();
            Container.RegisterTypeForNavigation<StartPage>();
            Container.RegisterTypeForNavigation<HomePage>();
            Container.RegisterTypeForNavigation<SearchResultsPage,SearchResultsPageViewModel>();
            Container.RegisterTypeForNavigation<CompanyDetailsPage>();
            Container.RegisterTypeForNavigation<CompanyUserDetailsPage>();
            Container.RegisterTypeForNavigation<ProgramDetailsPage, ProgramDetailsPageViewModel>();
            Container.RegisterTypeForNavigation<ServiceDetailsPage, ServiceDetailsPageViewModel>();
            Container.RegisterTypeForNavigation<JobPage, JobPageViewModel>();
            Container.RegisterTypeForNavigation<CompanyEditUserDetailsPage>();
            Container.RegisterTypeForNavigation<CompanyManageUsersPage>();
            Container.RegisterTypeForNavigation<CompanyAddUserPage>();            
//            Container.RegisterTypeForNavigation<LoginOptionsPage, StartPageViewModel>();
            Container.RegisterTypeForNavigation<SettingsPage,SettingsPageViewModel>();
            Container.RegisterTypeForNavigation<AboutPage,AboutPageViewModel>();
            Container.RegisterTypeForNavigation<ContactUsPage,ContactUsPageViewModel>();
            Container.RegisterTypeForNavigation<ComplaintsPage, ComplaintsPageViewModel>();
            Container.RegisterTypeForNavigation<CalendarPage,CalendarPageViewModel>();

            Container.RegisterTypeForNavigation<JobNewPostPage>();
            Container.RegisterTypeForNavigation<JobNewPostTypePage>();
            Container.RegisterTypeForNavigation<ApplicationsPage, ApplicationsPageViewModel>();
            Container.RegisterTypeForNavigation<ApplicationDetailsPage, ApplicationDetailsPageViewModel>();
            Container.RegisterTypeForNavigation<LoginPage, LoginPageViewModel>();
            //    Container.RegisterTypeForNavigation<WatchListPage>();
            Container.RegisterTypeForNavigation<ProgramsPage, ProgramsPageViewModel>();
            Container.RegisterTypeForNavigation<ServicesPage, ServicesPageViewModel>();
            Container.RegisterTypeForNavigation<EventsDetailPage, EventsDetailPageViewModel>();
            Container.RegisterTypeForNavigation<AddNewComplaintPage, AddNewComplaintPageViewModel>();
            Container.RegisterTypeForNavigation<CandidateInvitePage>();
            Container.RegisterTypeForNavigation<MatchingCandidatesPage>();
            Container.RegisterTypeForNavigation<FiltersPage>();
        }

        #region Singleton instance for nav and user checking

        public static App GetInstance()
        {
            return _appInstance;
        }

        public static Page GetCurrentPage()
        {
            return Application.Current.MainPage.Navigation.NavigationStack.Last();
        }


        #endregion
    }
}
