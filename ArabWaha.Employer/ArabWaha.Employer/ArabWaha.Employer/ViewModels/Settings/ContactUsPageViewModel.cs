using ArabWaha.Employer.BaseCalsses;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using ArabWaha.Employer.Helpers;

namespace ArabWaha.Employer.ViewModels
{
    public class ContactUsPageViewModel : AWMVVMBase
    {

		private string _PhonecontactLabel;
		public string PhonecontactLabel
		{
			get { return _PhonecontactLabel; }
			set
			{
				SetProperty(ref _PhonecontactLabel, value);
			}
		}
		private string _MailcontactLabel;
		public string MailcontactLabel
		{
			get { return _MailcontactLabel; }
			set
			{
				SetProperty(ref _MailcontactLabel, value);
			}
		}

		private string _ContactLabelText;
		public string ContactLabelText
		{
			get { return _ContactLabelText; }
			set
			{
				SetProperty(ref _ContactLabelText, value);
			}
		}

		private string _ContactPageTitle;
		public string ContactPageTitle
		{
			get { return _ContactPageTitle; }
			set
			{
				SetProperty(ref _ContactPageTitle, value);
			}
		}




		public ContactUsPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {
            //ContactUsText = "If you have any question please call us on\nLine Available from sunday to Thursday\n\nYou can also email for any technical questions.";

			TranslateExtension tran = new TranslateExtension();


            try
            {
				//PhonecontactLabel = tran.GetProviderValueString("PhoneLabel");

				PhonecontactLabel = App.Translation != null ? App.Translation.employer.contactuslblphone : tran.GetProviderValueString("PhoneLabel");


				MailcontactLabel = App.Translation != null ? App.Translation.employer.contactuslblmail : tran.GetProviderValueString("MailLabel");
				//MailcontactLabel = tran.GetProviderValueString("MailLabel");

				ContactLabelText = App.Translation != null ? App.Translation.employer.contactuslbltext : tran.GetProviderValueString("ContactUsLabel");
				//ContactLabelText = tran.GetProviderValueString("ContactUsLabel");

				ContactPageTitle = App.Translation != null ? App.Translation.employer.contactuslbltitle : tran.GetProviderValueString("TextContactPageTitle");
				//ContactPageTitle = tran.GetProviderValueString("TextContactPageTitle");

			}
            catch (Exception ex)
            {

            }

		}

		//private string _contactText;

		//public string ContactUsText
		//{
		//    get { return _contactText; }
		//    set { SetProperty<string>(ref _contactText, value); }
		//}

		
    }
}
