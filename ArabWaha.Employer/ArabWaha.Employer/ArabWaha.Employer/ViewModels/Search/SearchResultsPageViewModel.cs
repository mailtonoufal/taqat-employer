using ArabWaha.Core.BaseClasses;
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

namespace ArabWaha.Employer.ViewModels
{
    public class SearchResultsPageViewModel : AWMVVMBase, INavigationAware
    {
        private ObservableCollection<ApplicationProfile> _candidateList = new ObservableCollection<ApplicationProfile>();
        public ObservableCollection<ApplicationProfile> CandidateList
        {
            get { return _candidateList; }
            set { SetProperty(ref _candidateList, value); }
        }

        public DelegateCommand SearchCommand { get; set; }


        public SearchResultsPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {
            SearchCommand = new DelegateCommand(Search);
        }

        private void Search()
        {
            var x = 0;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            // Get the parameters 
            
            ApiService sv = new ApiService();
            // Build the list of data or show message that the search returned nothing.
            CandidateList = await sv.GetSearchApplicationsAsync(null, null);
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
        }
    }
}
