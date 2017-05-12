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

namespace ArabWaha.Employer.ViewModels
{
    public class SearchResultsPageViewModel : AWMVVMBase, INavigationAware
    {
        public SearchResultsPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {
            SearchCommand = new DelegateCommand(ProcessSearch);
            FilterCommand = new DelegateCommand(ProcessFilter);
        }

        private ObservableCollection<ApplicationProfile> _candidateList = new ObservableCollection<ApplicationProfile>();
        public ObservableCollection<ApplicationProfile> CandidateList
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

        private async void ProcessSearch()
        {
            ApiService sv = new ApiService();
            CandidateList = await sv.GetSearchApplicationsAsync(SearchText, SearchLocation);

            // set up ApplicationSearchResultPostedDate for localization
            foreach(var item in CandidateList)
            {
                item.ApplicationSearchResultPostedDate = GetApplicationPostedDate(item.ApplicationDate);
            }

            TranslateExtension trans = new TranslateExtension();

            // setup count here
            SearchResultCount = $"{CandidateList.Count} {trans.GetProviderValueString("LabelResultsFoundText")}";

        }

        private string _SearchResultCount;

        public string SearchResultCount
        {
            get { return _SearchResultCount; }
            set { SetProperty<string>(ref _SearchResultCount , value); }
        }


        private string GetApplicationPostedDate(DateTime dt)
        {
            
            TranslateExtension trans = new TranslateExtension();

            string retDate = trans.GetProviderValueString("LabelJobPosted");

            DateTime current = DateTime.Now;
            var dateSpan = DateTimeSpan.CompareDates(dt, current);

            if(dateSpan.Months<1)
            {
                retDate+= $" {((int)dateSpan.Days/7).ToString()} {trans.GetProviderValueString("LabelWeeksText")} {trans.GetProviderValueString("LabelAgoText")}" ;
            }
            else
            {
                // weeks 
                retDate += $" {dateSpan.Months.ToString()} {trans.GetProviderValueString("LabelMonthsText")} {trans.GetProviderValueString("LabelAgoText")}";
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
            ProcessSearch();
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
