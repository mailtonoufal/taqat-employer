using ArabWaha.Employee.BaseClasses;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArabWaha.Employee.ViewModels
{
    public class BadgesPageViewModel : AWMVVMBase, INavigatedAware
    {
        public BadgesPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {

        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}
