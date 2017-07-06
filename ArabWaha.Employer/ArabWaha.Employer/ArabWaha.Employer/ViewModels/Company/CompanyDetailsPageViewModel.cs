﻿using ArabWaha.Core.ModelsEmployer.Company;
using ArabWaha.Core.Services;
using ArabWaha.Employer.BaseCalsses;
using ArabWaha.Employer.Views;
using ArabWaha.Common;
using Prism.Commands;
using ArabWaha.Models;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System.Threading.Tasks;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using ArabWaha.Core.Models.Company;
using ArabWaha.Web;
using ArabWaha.Core.DBAccess;
using System.Diagnostics;
using ArabWaha.Employer.Helpers;

namespace ArabWaha.Employer.ViewModels
{
    public class CompanyDetailsPageViewModel : AWMVVMBase, INavigationAware
    {

        private MyCompany _companyInfo;
        public MyCompany CompanyInfo
        {
            get { return _companyInfo; }
            set { SetProperty(ref _companyInfo, value); }
        }

		private string _CompanyDescription;
		public string CompanyDescription
		{
			get { return _CompanyDescription; }
			set
			{
				SetProperty(ref _CompanyDescription, value);
			}
		}

		private string _CompanyInformation;
		public string CompanyInformation
		{
			get { return _CompanyInformation; }
			set
			{
				SetProperty(ref _CompanyInformation, value);
			}
		}

		private string _CompanyContact;
		public string CompanyContact
		{
			get { return _CompanyContact; }
			set
			{
				SetProperty(ref _CompanyContact, value);
			}
		}

		private string _CompanyLocation;
		public string CompanyLocation
		{
			get { return _CompanyLocation; }
			set
			{
				SetProperty(ref _CompanyLocation, value);
			}
		}

		private string _ManageUserButton;
		public string ManageUserButton
		{
			get { return _ManageUserButton; }
			set
			{
				SetProperty(ref _ManageUserButton, value);
			}
		}

		private string _Namelabell;
		public string Namelabell
		{
			get { return _Namelabell; }
			set
			{
				SetProperty(ref _Namelabell, value);
			}
		}

		private string _PositionLabell;
		public string PositionLabell
		{
			get { return _PositionLabell; }
			set
			{
				SetProperty(ref _PositionLabell, value);
			}
		}

		private string _MobilePhoneLabell;
		public string MobilePhoneLabell
		{
			get { return _MobilePhoneLabell; }
			set
			{
				SetProperty(ref _MobilePhoneLabell, value);
			}
		}

		private string _TelephoneNumberLabell;
		public string TelephoneNumberLabell
		{
			get { return _TelephoneNumberLabell; }
			set
			{
				SetProperty(ref _TelephoneNumberLabell, value);
			}
		}

		private string _EmailAddressLabell;
		public string EmailAddressLabell
		{
			get { return _EmailAddressLabell; }
			set
			{
				SetProperty(ref _EmailAddressLabell, value);
			}
		}


        public DelegateCommand<string> CallCommand { get; set; }
        public DelegateCommand ManageCommand { get; set; }


        public CompanyDetailsPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {
            SetDefaultColumn(0, 1);
            CallCommand = new DelegateCommand<string>(CallNumber);
            ManageCommand = new DelegateCommand(ManageCompany);

            DbAccessor db = new DbAccessor();
            //retrieve the company details from the db
            var myCompanyFromDb = db.GetTableItems<MyCompany>();

            var MyCompanyDetails = myCompanyFromDb[0];

            CompanyInfo = myCompanyFromDb[0];
			// var lattitude = CompanyInfo.contactPersonGeocodeLattitude;
			// var longitude = CompanyInfo.contactPersonGeocodeLongitude;

			


            TranslateExtension tran = new TranslateExtension();



			//CompanyDescription = App.Translation != null ? App.Translation.employer.mycompanydescription : tran.GetProviderValueString("CompanyDescriptionLabel");
			CompanyDescription = tran.GetProviderValueString("CompanyDescriptionLabel");

			// CompanyInformation = App.Translation != null ? App.Translation.employer.mycompanyinformation : tran.GetProviderValueString("CompanyInformationLabel");
			CompanyInformation = tran.GetProviderValueString("CompanyInformationLabel");

			//CompanyContact = App.Translation != null ? App.Translation.employer.mycompanycontactdt : tran.GetProviderValueString("ContactDetailsLabel");
			CompanyContact = tran.GetProviderValueString("ContactDetailsLabel");

			//CompanyLocation = App.Translation != null ? App.Translation.employer.mycompanylocation : tran.GetProviderValueString("LocationLabel");
			CompanyLocation = tran.GetProviderValueString("LocationLabel");

			//ManageUserButton = App.Translation != null ? App.Translation.employer.mycompanyuserbutton : tran.GetProviderValueString("ManageCompanyUsersButton");
			ManageUserButton = tran.GetProviderValueString("ManageCompanyUsersButton");

			//Namelabell = App.Translation != null ? App.Translation.employer.companydtname : tran.GetProviderValueString("Name");
			Namelabell = tran.GetProviderValueString("Name");

			//PositionLabell = App.Translation != null ? App.Translation.employer.companydtposition : tran.GetProviderValueString("Position");
			PositionLabell = tran.GetProviderValueString("Position");


			//MobilePhoneLabell = App.Translation != null ? App.Translation.employer.companydtmobile : tran.GetProviderValueString("Mobile Phone");
			MobilePhoneLabell = tran.GetProviderValueString("Mobile Phone");


			//TelephoneNumberLabel = App.Translation != null ? App.Translation.employer.companydttelephone : tran.GetProviderValueString("Telephone Number");
			TelephoneNumberLabell = tran.GetProviderValueString("Telephone Number");


			//EmailAddressLabel = App.Translation != null ? App.Translation.employer.companydtemail : tran.GetProviderValueString("Email Address");
			EmailAddressLabell = tran.GetProviderValueString("Email Address");



		}

        private void ManageCompany()
        {
            _nav.NavigateAsync(nameof(CompanyManageUsersPage));
        }

        private void CallNumber(string obj)
        {
            Device.OpenUri(new Uri($"tel:{obj}"));
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
           // SetupTestData();
        }

       
    }
}
