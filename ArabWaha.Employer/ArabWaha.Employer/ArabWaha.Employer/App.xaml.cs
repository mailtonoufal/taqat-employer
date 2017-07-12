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
using System.Diagnostics;
using ArabWaha.Models;
using NStackPortable;
using ArabWaha.Employer.StaticData;
using MapsPCL;
using Xamarin.Forms.Maps;

namespace ArabWaha.Employer
{

	public partial class App : PrismApplication
	{
		public static Translation Translation;
		public static string appLang;
		public static bool nstackCalled;
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


			//StackPortableCode
			Task.Run(async () =>
			{
				await loadTranslations();
				//To set latitude for whole application
				GlobalSetting.posAddress = await SetCurrentLocation();
			});

			_appInstance = this;
			SetStartPage(); // NavigationService.NavigateAsync($"NavigationPage/{nameof(StartPage)}");
		}

		public static async Task<string> SetCurrentLocation()
		{
			GlobalSetting.position = new Position(17.456508, 78.412616);//default location

			ILocation loc = DependencyService.Get<ILocation>();
			loc.locationObtained += (object ss, ILocationEventArgs ee) =>
				{
					GlobalSetting.position = new Position(ee.lat, ee.lng);
				};
			loc.ObtainMyLocation();

			var geocoder = new Geocoder();

			var addresses = await geocoder.GetAddressesForPositionAsync(GlobalSetting.position);
			//{System.Linq.Enumerable.WhereSelectArrayIterator<CoreLocation.CLPlacemark,string>}

			foreach (var address in addresses)
			{
				var arrAddress = address.Split(new char[] { '\n' });

				return arrAddress[1];
			}

			return null;
		}

		public async void SetStartPage()
		{
			try
			{
				await NavigationService.NavigateAsync($"NavigationPage/{nameof(StartPage)}");
				//await NavigationService.NavigateAsync($"NavigationPage/{nameof(HomePage)}");
			}
			catch (Exception ex)
			{
				Debug.WriteLine("ERROR:" + ex.Message);
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
			Container.RegisterTypeForNavigation<SearchPage, SearchPageViewModel>();
			Container.RegisterTypeForNavigation<SignUpPage, SignUpPageViewModel>();
			Container.RegisterTypeForNavigation<StartPage>();
			Container.RegisterTypeForNavigation<HomePage>();
			Container.RegisterTypeForNavigation<SearchResultsPage, SearchResultsPageViewModel>();
			Container.RegisterTypeForNavigation<CompanyDetailsPage>();
			Container.RegisterTypeForNavigation<CompanyUserDetailsPage>();
			Container.RegisterTypeForNavigation<ProgramDetailsPage, ProgramDetailsPageViewModel>();
			Container.RegisterTypeForNavigation<ServiceDetailsPage, ServiceDetailsPageViewModel>();
			Container.RegisterTypeForNavigation<JobPage, JobPageViewModel>();
			Container.RegisterTypeForNavigation<CompanyEditUserDetailsPage>();
			Container.RegisterTypeForNavigation<CompanyManageUsersPage>();
			Container.RegisterTypeForNavigation<CompanyAddUserPage>();
			//            Container.RegisterTypeForNavigation<LoginOptionsPage, StartPageViewModel>();
			Container.RegisterTypeForNavigation<SettingsPage, SettingsPageViewModel>();
			Container.RegisterTypeForNavigation<AboutPage, AboutPageViewModel>();
			Container.RegisterTypeForNavigation<ContactUsPage, ContactUsPageViewModel>();
			Container.RegisterTypeForNavigation<ComplaintsPage, ComplaintsPageViewModel>();
			Container.RegisterTypeForNavigation<CalendarPage, CalendarPageViewModel>();

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
			Container.RegisterTypeForNavigation<PersonalDetailsPage, PersonalDetailsViewModel>();
			Container.RegisterTypeForNavigation<EditPersonalDetailsPage>();
			Container.RegisterTypeForNavigation<AssignCandidateToJobPost>();
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

		public static async Task StartNStack()
		{
			try
			{
				if (nstackCalled == false)
				{
					NStack<Translation>.Init(Common.Constants.NSTACK_APPID, Common.Constants.NSTACK_RESTKEY);

					var cachedAppOpen = await NStack<Translation>.Instance().Load("fallback.json");

					var appOpen = await NStack<Translation>.Instance().AppOpenProvider.Update(GlobalSetting.IsEnglish ? "en" : "ar-SA");

					Translation = appOpen?.Data?.Translate != null ? appOpen.Data.Translate : cachedAppOpen.Data.Translate;
					nstackCalled = true;
				}
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine("Cookie-" + DebugDataSingleton.Instance.COOKIE);
			}
		}

		public async Task loadTranslations()
		{
			try
			{
				await StartNStack();
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}
		}


		#endregion
	}
}
