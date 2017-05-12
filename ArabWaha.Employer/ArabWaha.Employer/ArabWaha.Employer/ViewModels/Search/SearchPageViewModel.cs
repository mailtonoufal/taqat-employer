using ArabWaha.Core.BaseClasses;
using ArabWaha.Employer.BaseCalsses;
using ArabWaha.Employer.Views;
using ArabWaha.Employer.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArabWaha.Employer.ViewModels
{
    public class SearchPageViewModel : AWMVVMBase, INavigationAware
    {
        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set { SetProperty(ref _searchText, value); SearchCommand.RaiseCanExecuteChanged();  }
        }

        private string _searchLocation;
        public string SearchLocation
        {
            get { return _searchLocation; }
            set { SetProperty(ref _searchLocation, value); SearchCommand.RaiseCanExecuteChanged(); }
        }
        public DelegateCommand SearchCommand { get; set; }
        public DelegateCommand SignInCommand { get; set; }
        
        public SearchPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {

            SearchCommand = new DelegateCommand(Search);//, CanSearch);
            SignInCommand = new DelegateCommand(SignIn);
        }

        private void SignIn()
        {
            _nav.NavigateAsync(nameof(LoginPage));
        }

        private void Search()
        {

            // do search
            _nav.NavigateAsync($"{nameof(SearchResultsPage)}?SearchText={SearchText}&SearchLocation={SearchLocation}");

        }

        private bool CanSearch()
        {
            return true;
            //return !string.IsNullOrEmpty(SearchText);
        }


        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
        }
    }
}
