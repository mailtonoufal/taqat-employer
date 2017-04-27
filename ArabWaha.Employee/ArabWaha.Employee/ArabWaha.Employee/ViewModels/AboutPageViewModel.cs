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
    public class AboutPageViewModel : AWMVVMBase
    {
        public AboutPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {
            Title = "About";
        }
    }
}
