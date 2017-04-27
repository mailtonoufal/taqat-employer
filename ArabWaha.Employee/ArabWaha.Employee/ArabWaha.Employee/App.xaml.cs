using Prism.Unity;
using ArabWaha.Employee.Views;
using Xamarin.Forms;
using ArabWaha.Employee.Views.Menus;
using ArabWaha.Core.Services;
using System;
using ArabWaha.Employee.Interfaces;
using System.Linq;
using ArabWaha.Employee.Views.Search;
using ArabWaha.Employee.ViewModels;
using ArabWaha.Employee.Views.Programs;
using ArabWaha.Employee.Views.Jobs;
using ArabWaha.Employee.Views.Home;
using ArabWaha.Employee.Views.Settings;
using ArabWaha.Employee.Views.Branches;
using ArabWaha.Employee.Views.Badges;
using System.Threading.Tasks;
using ArabWaha.Employee.Views.Details;
using ArabWaha.Employee.Views.Login;

namespace ArabWaha.Employee
{
    public static class GlobalSetting
    {
        public static string CultureCode { get; set; }
        public static LayoutAlignment AlignLabel { get; set;  }
        public static LayoutAlignment AlignData { get; set; }

        public static LayoutOptions HorizontalLayoutOptions { get; set; }

        public static void SetupCulture()
        {
            ApiServiceIndividual svr = new ApiServiceIndividual();
            GlobalSetting.CultureCode = svr.GetCurrentCulture();
            GlobalSetting.AlignLabel = GlobalSetting.CultureCode == "ar" ? LayoutAlignment.End : LayoutAlignment.Start;
            GlobalSetting.AlignData = GlobalSetting.CultureCode == "ar" ? LayoutAlignment.Start : LayoutAlignment.End;
            GlobalSetting.HorizontalLayoutOptions = GlobalSetting.CultureCode == "ar" ? LayoutOptions.EndAndExpand : LayoutOptions.StartAndExpand;
        }
    }

    public partial class App : PrismApplication
    {
        public static App _appInstance;
       // public static string CultureCode {get;set;}
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();
            // debug test
            AuthService.IsAuthorised = false;

            // init db string in dependant pcl
            Core.DBAccess.DbAccessor.ConnectionString = DependencyService.Get<IDBInfo>().GetIndividualDbPath();

            GlobalSetting.SetupCulture();

            SyncDbAsync(); 

            _appInstance = this;
            SetStartPage(); //  NavigationService.NavigateAsync($"NavigationPage/{nameof(StartPage)}");
        }

        public async void SetStartPage()
        {
            await NavigationService.NavigateAsync($"NavigationPage/{nameof(StartPage)}");
        }

        async Task SyncDbAsync()
        {
            ApiServiceIndividual svr = new ApiServiceIndividual();
            svr.SyncAPiToDB();
        }

        #region static instance nav functions

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

        #endregion

        #region Singleton instance for nav and user checking

        public static App GetInstance()
        {
            return _appInstance;
        }


        #endregion

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<StartPage, StartPageViewModel>();
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<PasswordPage, PasswordPageViewModel>();
            Container.RegisterTypeForNavigation<LoginPage,LoginOptionsPageViewModel>();
            Container.RegisterTypeForNavigation<SearchPage>();
            Container.RegisterTypeForNavigation<SignUpPage>();
            Container.RegisterTypeForNavigation<ProgramsPage, ProgramsPageViewModel>();
            Container.RegisterTypeForNavigation<HomePage>();
            Container.RegisterTypeForNavigation<SearchResultsPage, SearchResultsPageViewModel>();
            Container.RegisterTypeForNavigation<CalendarPage>();
            Container.RegisterTypeForNavigation<ProfilePage>();
            Container.RegisterTypeForNavigation<ProgramsPage, ProgramsPageViewModel>();
            Container.RegisterTypeForNavigation<JobsPage, JobsPageViewModel>();
            Container.RegisterTypeForNavigation<ContactUsPage, ContactUsPageViewModel>();
            Container.RegisterTypeForNavigation<SettingsPage, SettingsPageViewModel>();
            Container.RegisterTypeForNavigation<LoginOptionsPage, LoginOptionsPageViewModel>();
            Container.RegisterTypeForNavigation<JobFilterPage, JobFilterPageViewModel>();
            Container.RegisterTypeForNavigation<AboutPage, AboutPageViewModel>();
            Container.RegisterTypeForNavigation<ComplaintsPage, ComplaintsPageViewModel>();
            Container.RegisterTypeForNavigation<ContactUsPage, ContactUsPageViewModel>();
            Container.RegisterTypeForNavigation<BranchesPage, BranchesPageViewModel>();
            Container.RegisterTypeForNavigation<BadgesPage, BadgesPageViewModel>();
            Container.RegisterTypeForNavigation<DisplayJobPage,DisplayJobPageViewModel>();
            Container.RegisterTypeForNavigation<NotificationsPage>();
            Container.RegisterTypeForNavigation<NotificationDetailsPage, NotificationDetailsPageViewModel>();
            Container.RegisterTypeForNavigation<EventsDetailPage,EventsDetailPageViewModel>();
            Container.RegisterTypeForNavigation<OneTimePassword, OneTimePasswordViewModel>();
        }

        #region Singleton instance for nav and user checking

        public static Page GetCurrentPage()
        {
            return Application.Current.MainPage.Navigation.NavigationStack.Last();
        }


        #endregion
    }
}
