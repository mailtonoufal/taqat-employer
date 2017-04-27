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
    public class OneTimePasswordViewModel : AWMVVMBase, INavigationAware
    {
        public OneTimePasswordViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {

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
