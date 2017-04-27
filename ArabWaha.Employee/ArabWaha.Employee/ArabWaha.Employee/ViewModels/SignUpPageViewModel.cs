using ArabWaha.Core.BaseClasses;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArabWaha.Employee.ViewModels
{
    public class SignUpPageViewModel : MVVMBase
    {
        INavigationService _nav;
        IPageDialogService _dialog;
        public SignUpPageViewModel(INavigationService navigationService, IPageDialogService dialog)
        {
            Title = "Sign up";

            _nav = navigationService;
            _dialog = dialog;

        }
    }
}
