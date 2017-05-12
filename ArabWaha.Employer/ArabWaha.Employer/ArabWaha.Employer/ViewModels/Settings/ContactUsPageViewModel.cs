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
            ContactUsText = "If you have any question please call us on\nLine Available from sunday to Thursday\n\nYou can also email for any technical questions.";
        }

        private string _contactText;

        public string ContactUsText
        {
            get { return _contactText; }
            set { SetProperty<string>(ref _contactText, value); }
        }

    }
}
