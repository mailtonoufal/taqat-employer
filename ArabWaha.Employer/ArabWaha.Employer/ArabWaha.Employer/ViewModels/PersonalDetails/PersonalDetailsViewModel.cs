using ArabWaha.Core.ModelsEmployer;
using ArabWaha.Core.ModelsEmployer.Jobs;
using ArabWaha.Core.ModelsEmployer.Programs;
using ArabWaha.Core.ModelsEmployer.Services;
using ArabWaha.Core.Services;
using ArabWaha.Employer.BaseCalsses;
using ArabWaha.Employer.Helpers;
using ArabWaha.Employer.Layouts;
using ArabWaha.Employer.Views;
using ArabWaha.Employer.Views.Home;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using ArabWaha.Core.Models.Profile;

namespace ArabWaha.Employer.ViewModels
{
	public class PersonalDetailsViewModel : AWMVVMBase
	{
		private PersonalDetails _personalDetails;
		public PersonalDetails PersonalDetails
		{
			get { return _personalDetails; }
			set { SetProperty(ref _personalDetails, value); }
		}

		public DelegateCommand EditDetailsCommand { get; set; }

		public PersonalDetailsViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
		{
			TranslateExtension tran = new TranslateExtension();

			Title = tran.GetProviderValueString("LabelApplicationsTitle");

			EditDetailsCommand = new DelegateCommand(DetailsNavigate);

			LoadData();

		}

		private void DetailsNavigate()
		{
			_nav.NavigateAsync(nameof(EditPersonalDetailsPage));
		}

		private void LoadData()
		{
			
			PersonalDetails = new PersonalDetails()
			{
				fullName = "subhash sharma",
				position = "developer",
				ninIqama = "nin/iqama",
				mobileNumber = "9799845632",
				additionalNumber = "9529878485",
				emailId = "subhash.sharma@dotsquares.com",

				userName = "subhash.sharma",
				userType = "verified by MoL",
				assignedUserRole = "representative",
				preferChannel = "SMS",
				molAccountStatus = "Active"

			};
		}
	}
}
