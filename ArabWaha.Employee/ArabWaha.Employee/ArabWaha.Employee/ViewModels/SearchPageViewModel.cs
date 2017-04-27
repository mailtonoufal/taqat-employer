using ArabWaha.Core.BaseClasses;
using ArabWaha.Employee.BaseClasses;
using ArabWaha.Employee.Views;
using ArabWaha.Employee.Views.Search;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArabWaha.Employee.ViewModels
{
    public class SearchPageViewModel : AWMVVMBase, INavigationAware
    {

        private string _searchText;
        private string _searchLocation;
        public string SearchText
        {
            get { return _searchText; }
            set { SetProperty(ref _searchText, value); SearchCommand.RaiseCanExecuteChanged(); }
        }

        public string SearchLocation
        {
            get { return _searchLocation; }
            set { SetProperty(ref _searchLocation, value); SearchCommand.RaiseCanExecuteChanged(); }
        }
        public DelegateCommand SearchCommand { get; set; }
        public DelegateCommand SignInCommand { get; set; }

        public SearchPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {
            Title = "Search";
            SearchCommand = new DelegateCommand(Search, CanSearch);
            SignInCommand = new DelegateCommand(SignIn);
        }

        private void SignIn()
        {
            _nav.NavigateAsync(nameof(LoginPage));
        }

        private void Search()
        {
            // do search
            //IsBusy = true;

            _nav.NavigateAsync(nameof(SearchResultsPage));

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
