﻿using ArabWaha.Core.BaseClasses;
using ArabWaha.Core.ModelsEmployer.Jobs;
using ArabWaha.Core.ModelsEmployer.Programs;
using ArabWaha.Core.ModelsEmployer.Services;
using ArabWaha.Core.Services;
using ArabWaha.Core;
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
using ArabWaha.Employer.StaticData;
using ArabWaha.Web;
using ArabWaha.Core.Models.JobLists;

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

			if (GlobalSetting.IsEnglish)
			{
				Tab1Command = new DelegateCommand(SetHome);
				Tab2Command = new DelegateCommand(SetJobPosts);
				Tab3Command = new DelegateCommand(Setprograms);
				Tab4Command = new DelegateCommand(SetServices);
			}
			else
			{
				Tab1Command = new DelegateCommand(SetServices);
				Tab2Command = new DelegateCommand(Setprograms);
				Tab3Command = new DelegateCommand(SetJobPosts);
				Tab4Command = new DelegateCommand(SetHome);
			}
			SearchBarCommand = new DelegateCommand(ExecuteSearch);

			// job commands
			DeleteJobCommand = new DelegateCommand<Job>(ProcessDeleteJob);
			EditJobCommand = new DelegateCommand<Job>(ProcessEditJob);
			ViewJobCommand = new DelegateCommand<Job>(ProcessViewJob);
			JobPostsSelectedCommand = new DelegateCommand<Job>(ProcessJobPostsSelectedCommand);

			ProgramSelectedCommand = new DelegateCommand<Program>(ProcessProgramSelected);
			ServicesSelectedCommand = new DelegateCommand<EmployerService>(ProcessServicesSelectedCommand);
			AddNewJobCommand = new DelegateCommand(ProcessAddNewJobCommand);

			// load views    
			LoadContentViews();
		}


		void LoadContentViews()
		{
			Device.BeginInvokeOnMainThread(async () =>
			{
				var responseAnnouncements = await Web.AWHttpClient.Instance.GetAnnouncements();

				if (responseAnnouncements.Data != null && responseAnnouncements.Data.Announcements.Data.Count > 0)
				{
					HomePageSource = new ObservableCollection<Announcement>(responseAnnouncements.Data.Announcements.Data);
				}
				//ApiService apiServ = new ApiService();

				if (responseAnnouncements.Data != null && responseAnnouncements.Data.Featured.Count > 0)
				{
					initialPostion = "0";
					SwipeSource = new ObservableCollection<FeaturedAnnouncement>(responseAnnouncements.Data.Featured);
					if (GlobalSetting.IsArabic)
					{
						SwipeSource = new ObservableCollection<FeaturedAnnouncement>(SwipeSource.Reverse());
						initialPostion = (responseAnnouncements.Data.Featured.Count() - 1).ToString();
					}
				}

				HomeContent = new HomeHomeContent();
				SetHome();

			});

			Task.Run(async () =>
			{
				var jobListRoot = await AWHttpClient.Instance.GetJobsList();
				JobPageSource = new ObservableCollection<Job>(jobListRoot.Result.jobsListObject.jobsList);


				TranslateExtension tran = new TranslateExtension();

				// mod the text here for translations 
				foreach (var t in JobPageSource)
				{
					//t.JobStatusText = tran.GetProviderValueString("LabelJobStatus");
					//t.PostedText = tran.GetProviderValueString("LabelJobPosted");

					//if (string.IsNullOrEmpty(t.CompanyLogo)) t.CompanyLogo = "jobcompanyicon.png";
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
				//ProgramsPageSource = await apiServ.GetCurrentProgramsAsync();
				//           try
				//           {
				//var programsList = await AWHttpClient.Instance.GetPrograms();
				//    ProgramsPageSource = new ObservableCollection<Program>(programsList.Data.Programs);

				//}
				//catch (Exception ex)
				//{

				//}

				var programsList = await Web.AWHttpClient.Instance.GetPrograms();

				if (programsList.Data != null && programsList.Data.Programs.Count > 0)
				{
					ProgramsPageSource = new ObservableCollection<Program>(programsList.Data.Programs);
				}








				TranslateExtension tran = new TranslateExtension();

				string progStatusLabel = tran.GetProviderValueString("LabelProgramStatusText");
				// setup Program Status:
				foreach (var item in ProgramsPageSource)
				{
					//item.StatusLabelText = progStatusLabel;
					item.StatusText = $"{progStatusLabel} {item.StatusText} ";
				}



				ProgramsContent = new HomeProgramsContent();
			});

		}

		public void SetTabs(TabControl ctrl)
		{
			string _Home, _JobPosts, _Programs, _Services;
			if (_ctrl != null) return;
			_ctrl = ctrl;
			_ctrl.SetSearchVisible(true);

			TranslateExtension tran = new TranslateExtension();
			try
			{

				_Home = App.Translation.employer.homelblhome;
				_JobPosts = App.Translation.employer.homelbljobposts;
				_Programs = App.Translation.employer.homelblprograms;
				_Services = App.Translation.employer.homelblservices;
			}
			catch (Exception ex)
			{
				_Home = tran.GetProviderValueString("MenuHome");
				_JobPosts = tran.GetProviderValueString("MenuJobPosts");
				_Programs = tran.GetProviderValueString("MenuPrograms");
				_Services = tran.GetProviderValueString("MenuServices");
			}
			if (GlobalSetting.IsEnglish)
			{
				_ctrl.SetTabText(_Home, _JobPosts, _Programs, _Services);
			}
			else
			{
				_ctrl.SetTabText(_Services, _Programs, _JobPosts, _Home);
			}
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
		public DelegateCommand<Job> DeleteJobCommand { get; set; }
		//        public DelegateCommand<EmployerJobDetail> EditJobCommand;
		//public ICommand EditJobCommand { get; }

		private async void ProcessDeleteJob(Job vals)
		{
			TranslateExtension tran = new TranslateExtension();
			string confirm = tran.GetProviderValueString("ButtonConfirmDelete");
			string delete = tran.GetProviderValueString("ButtonDelete");
			string cancel = tran.GetProviderValueString("ButtonCancel");

			var res = await _dialog.DisplayActionSheetAsync(confirm, cancel, delete, "");
			if (res.Equals(delete))
			{
				ApiService apiServ = new ApiService();
				if (await apiServ.DeleteEmployerJobasync(vals.jobPostId))
				{
					JobPageSource.Remove(vals);
				}
			}
		}

		public DelegateCommand<Job> EditJobCommand { get; set; }
		async void ProcessEditJob(Job vals)
		{
			if (vals != null)
			{
				NavigationParameters paramx = new NavigationParameters();
				paramx.Add("MODE", "EDIT");
				paramx.Add("JOB", vals);
				await _nav.NavigateAsync(nameof(JobPage), paramx, false, true);
			}
		}

		public DelegateCommand<Job> ViewJobCommand { get; set; }
		async void ProcessViewJob(Job vals)
		{
			if (vals != null)
			{
				NavigationParameters paramx = new NavigationParameters();
				paramx.Add("MODE", "VIEW");
				paramx.Add("JOB", vals);
				await _nav.NavigateAsync(nameof(JobPage), paramx, false, true);
			}
		}
		public DelegateCommand<Program> ProgramSelectedCommand { get; set; }
		async void ProcessProgramSelected(Program vals)
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

		public DelegateCommand<Job> JobPostsSelectedCommand { get; set; }
		async void ProcessJobPostsSelectedCommand(Job vals)
		{
			NavigationParameters paramx = new NavigationParameters();
			paramx.Add("JOB", vals);
			paramx.Add("MODE", "VIEW");
			await _nav.NavigateAsync(nameof(JobPage), paramx, false, true);
		}


		#endregion

		#region sources

		private ObservableCollection<Announcement> _homePageSource;
		public ObservableCollection<Announcement> HomePageSource
		{
			get { return _homePageSource; }
			set { SetProperty<ObservableCollection<Announcement>>(ref _homePageSource, value); }
		}

		private ObservableCollection<Job> _jobPageSource;
		public ObservableCollection<Job> JobPageSource
		{
			get { return _jobPageSource; }
			set { SetProperty<ObservableCollection<Job>>(ref _jobPageSource, value); }
		}


		// ProgramsPageSource
		private ObservableCollection<Program> _programsPageSource;
		public ObservableCollection<Program> ProgramsPageSource
		{
			get { return _programsPageSource; }
			set { SetProperty<ObservableCollection<Program>>(ref _programsPageSource, value); }
		}

		// EmployerService source
		private ObservableCollection<EmployerService> _servicesPageSource;
		public ObservableCollection<EmployerService> ServicesPageSource
		{
			get { return _servicesPageSource; }
			set { SetProperty<ObservableCollection<EmployerService>>(ref _servicesPageSource, value); }
		}


		private ObservableCollection<FeaturedAnnouncement> _swipeSource;

		public ObservableCollection<FeaturedAnnouncement> SwipeSource
		{
			get { return _swipeSource; }
			set { _swipeSource = value; }
		}
		public string initialPostion { get; set; }

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
					switch (x)
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

					var existing = JobPageSource.Where(x => x.jobPostId == val).FirstOrDefault();
					//if (existing != null)
					//{
					//	var index = JobPageSource.IndexOf(existing);
					//	JobPageSource.Remove(existing);
					//	JobPageSource.Insert(index, updated);
					//}
					//else
					//	JobPageSource.Add(updated); // must be a new job


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

				//if (!Core.Services.AuthService.IsAuthorised && (
				//	value is HomeJobPostsContent))
				//{
				//	// NotLoggedInContent
				//	SetProperty<ContentView>(ref _CurrentView, new NotLoggedInContent());
				//}
				//else if (value != null)
				SetProperty<ContentView>(ref _CurrentView, value);


			}
		}





		#endregion

	}
}
