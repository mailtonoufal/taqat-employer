using ArabWaha.Core.ModelsEmployer;
using ArabWaha.Core.Services;
using ArabWaha.Employer.BaseCalsses;
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

namespace ArabWaha.Employer.ViewModels
{
	public class MatchingCandidatesPageViewModel : AWMVVMBase, INavigationAware
	{
		public MatchingCandidatesPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
		{
			Title = "Matching Candidates";
		}

		public void OnNavigatedFrom(NavigationParameters parameters)
		{
		}

		public void OnNavigatedTo(NavigationParameters parameters)
		{
		}

		private ObservableCollection<ApplicationProfile> _candidateList = new ObservableCollection<ApplicationProfile>();
		public ObservableCollection<ApplicationProfile> CandidateList
		{
			get { return _candidateList; }
			set { SetProperty(ref _candidateList, value); UpdateResults(); }
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
		public async void OnNavigatingTo(NavigationParameters parameters)
		{
			var jobId = parameters["JobPostId"];

			if (jobId != null)
			{
				// Get the data for the matching candidates!!
				ApiService api = new ApiService();
				//Comment below code to hide data from Local DB
				CandidateList = await api.GetMatchingCandidatesForJobPost(jobId.ToString());

				//Uncomment below code to show data from API
				/*var result = await AWHttpClient.Instance.GetMatchingCandidatesList(jobId.ToString());
				if (result != null && result.Result != null && result.Result.matchingCandidateObject != null)
				{
					CandidateList = new ObservableCollection<MatchingCandidate>(result.Result.matchingCandidateObject.results);
				}*/
			}
		}

		private void UpdateResults()
		{
			HasResults = CandidateList.Count > 0;
			NoResults = !HasResults;
		}
	}
}
