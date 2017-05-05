using ArabWaha.Employer.BaseCalsses;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArabWaha.Employer.ViewModels
{
    public class ContactUsPageViewModel : AWMVVMBase
    {
        public ContactUsPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {

        }
    }
}
