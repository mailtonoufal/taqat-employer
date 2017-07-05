using ArabWaha.Core.BaseClasses;
using ArabWaha.Core.ModelsEmployer;
using ArabWaha.Core.Services;
using ArabWaha.Employer.BaseCalsses;
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
using ArabWaha.Web;
using ArabWaha.Core.Models.Candidates;
using System.Diagnostics;
using Acr.UserDialogs;
using System.Threading.Tasks;
using System.Text;
using ArabWaha.Employer.StaticData;

namespace ArabWaha.Employer.ViewModels
{
	public class SearchResultsPageViewModel : AWMVVMBase, INavigationAware
	{
		public SearchResultsPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
		{
            SearchCommand = new DelegateCommand(async () => {
                await ProcessSearch();
            });
			FilterCommand = new DelegateCommand(ProcessFilter);
		}

		private ObservableCollection<Candidate> _candidateList = new ObservableCollection<Candidate>();
		public ObservableCollection<Candidate> CandidateList
		{
			get { return _candidateList; }
			set { SetProperty(ref _candidateList, value); UpdateResults(); }
		}


		private string _searchText;
		public string SearchText
		{
			get { return _searchText; }
			set { SetProperty(ref _searchText, value); }
		}

		private string _searchLocaiton;
		public string SearchLocation
		{
			get { return _searchLocaiton; }
			set { SetProperty(ref _searchLocaiton, value); }
		}

		private bool _hasResults;
		public bool HasResults
		{
			get { return _hasResults; }
			set { SetProperty(ref _hasResults, value); }
		}

		private bool _noResults;
		public bool NoResults
		{
			get { return _noResults; }
			set { SetProperty(ref _noResults, value); }
		}
		public DelegateCommand SearchCommand { get; set; }
		public DelegateCommand FilterCommand { get; set; }



		private void ProcessFilter()
		{
			_nav.NavigateAsync(nameof(FiltersPage));
		}

		private async Task ProcessSearch()
		{
			try
			{
                Dialog.ShowLoading();
                StringBuilder searchFilter = new StringBuilder();
                string filterJoin = string.Empty;
                if (GlobalSetting.FilterQuery == null || GlobalSetting.FilterQuery.Length < 0)
                {
					filterJoin = String.Format("JobType eq * ");
					searchFilter.Append(filterJoin);
                }
                if (_searchLocaiton !=null && _searchLocaiton.Length>0)
                {
                    filterJoin = String.Format("and location eq '{0}' ", _searchLocaiton);
					searchFilter.Append(filterJoin);
                }
                if (_searchText !=null && _searchText.Length>0)
				{
                    filterJoin = String.Format("and Keyword eq '{0}' ", _searchText);
					searchFilter.Append(filterJoin);
				}
                var result = await AWHttpClient.Instance.GetCandidatesList(searchFilter.ToString());
				if (result.Result.candidateObjectList.candidateList != null && result.Result.candidateObjectList.candidateList.Count > 0)
				{
					CandidateList = new ObservableCollection<Candidate>(result.Result.candidateObjectList.candidateList);
				}
              
			}
			catch (Exception ex)
            {
				Debug.WriteLine(ex.Message);
			}
            finally{
                Dialog.HideLoading();
            }
			//ApiService sv = new ApiService();
			//Get the CandidateList


			//CandidateList = await sv.GetSearchApplicationsAsync(SearchText, SearchLocation);

			// set up ApplicationSearchResultPostedDate for localization
			//foreach(var item in CandidateList)
			//{
			//    item.ApplicationSearchResultPostedDate = GetApplicationPostedDate(item.ApplicationDate);
			//}

			CMSTranslateExtension trans = new CMSTranslateExtension();

			//// setup count here
			SearchResultCount = $"{CandidateList.Count} {trans.GetProviderValueString("talentsearchlblresultsfound")}";

		}

		private string _SearchResultCount;

		public string SearchResultCount
		{
			get { return _SearchResultCount; }
			set { SetProperty<string>(ref _SearchResultCount, value); }
		}


		private string GetApplicationPostedDate(DateTime dt)
		{

			CMSTranslateExtension trans = new CMSTranslateExtension();

			string retDate = trans.GetProviderValueString("talentsearchlblposted");

			DateTime current = DateTime.Now;
			var dateSpan = DateTimeSpan.CompareDates(dt, current);

			if (dateSpan.Months < 1)
			{
				retDate += $" {((int)dateSpan.Days / 7).ToString()} {trans.GetProviderValueString("talentsearchlblweeks")} {trans.GetProviderValueString("talentsearchlblpostedago")}";
			}
			else
			{
				// weeks 
				retDate += $" {dateSpan.Months.ToString()} {trans.GetProviderValueString("talentsearchlblmonths")} {trans.GetProviderValueString("talentsearchlblpostedago")}";
			}

			return retDate;
		}

		public void OnNavigatedFrom(NavigationParameters parameters)
		{
		}

		public async void OnNavigatedTo(NavigationParameters parameters)
		{
			// Get the parameters 
			SearchText = (string)parameters["SearchText"];
			SearchLocation = (string)parameters["SearchLocation"];
            await ProcessSearch();
		}

		public void OnNavigatingTo(NavigationParameters parameters)
		{
		}

		private void UpdateResults()
		{
			HasResults = CandidateList.Count > 0;
			NoResults = !HasResults;
		}
	}
}
