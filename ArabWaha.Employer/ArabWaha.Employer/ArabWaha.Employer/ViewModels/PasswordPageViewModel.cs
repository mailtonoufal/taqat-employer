using ArabWaha.Core.BaseClasses;
using ArabWaha.Employer.BaseCalsses;
using ArabWaha.Employer.Controls;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using ArabWaha.Employer.StaticData;

namespace ArabWaha.Employer.ViewModels
{
    public class PasswordPageViewModel : AWMVVMBase,INavigationAware
    {
        TabControl3Column _ctrl;


        public PasswordPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {
            Tab1Command = new DelegateCommand(SetUsername);
            Tab2Command = new DelegateCommand(SetPassword);
            Tab3Command = new DelegateCommand(SetEmail);
			//if (GlobalSetting.IsEnglish)
			//{
			//	Tab1Command = new DelegateCommand(SetUsername);
			//	Tab2Command = new DelegateCommand(SetPassword);
			//	Tab3Command = new DelegateCommand(SetEmail);
			//}
			//else
			//{
   //             Tab1Command = new DelegateCommand(SetPassword);
			//	Tab2Command = new DelegateCommand(SetUsername);
			//	Tab3Command = new DelegateCommand(SetEmail);
			//}
            // commands for items
            usernameSwitchCommand = new DelegateCommand<string>(ProcessUsernameSwitchCommand);



            SetUsername();
        }


        #region tabs

        public void SetTabs(TabControl3Column ctrl)
        {
            _ctrl = ctrl;

            _ctrl.SetSearchVisible(false);
            _ctrl.SetTabText(App.Translation != null ? App.Translation.employer.forgotloginlblusername : "Username", App.Translation != null ? App.Translation.employer.forgotloginlblpassword : "Password", "Email");
            TitleText =App.Translation != null ? App.Translation.employer.forgotloginlbltitle :"Forget Login Information";
            ButtonText = App.Translation != null ? App.Translation.employer.forgotloginbtnsubmit : "Submit";
            PasswordPH =App.Translation != null ? App.Translation.employer.forgotloginphusername : "Type your username";
            UserNamePH = App.Translation != null ? App.Translation.employer.forgotloginphemail :"Type your Email Address";
            UserName = App.Translation != null ? App.Translation.employer.forgotloginlblusername : "Username";
            EmailAddress =App.Translation != null ? App.Translation.employer.forgotloginlblemail: "Email Address";

            _ctrl.SetTabVisble(1);
        }


		#endregion


		#region properties

		
        private string _ButtonText;

        public string ButtonText
        {
            get { return _ButtonText; }
            set { SetProperty<string>(ref _ButtonText, value); }
        }


        private string _EmailText;
        public string EmailTextUsername
        {
            get { return _EmailText; }
            set { SetProperty<string>(ref _EmailText, value); }
        }


        public LayoutOptions AlignLayoutOptions
        {
            get { return GlobalSetting.HorizontalLayoutOptions; }
        }

        public LayoutAlignment TextAlignOptions
        {
            get
            {
                return GlobalSetting.AlignLabel;

            }
        }

        private string _TitleText;

        public string TitleText
        {
            get { return _TitleText; }
            set { SetProperty<string>(ref _TitleText, value); }
        }

        private string _UserNamePH;
		public string UserNamePH
		{
			get { return _UserNamePH; }
			set { SetProperty<string>(ref _UserNamePH, value); }
		}
		private string _UserName;
		public string UserName
		{
			get { return _UserName; }
			set { SetProperty<string>(ref _UserName, value); }
		}

		private string _EmailAddress;
		public string EmailAddress
		{
			get { return _EmailAddress; }
			set { SetProperty<string>(ref _EmailAddress, value); }
		}

		private string _PassowrdPH;
		public string PasswordPH
		{
			get { return _PassowrdPH; }
			set { SetProperty<string>(ref _PassowrdPH, value); }
		}


		private bool _ShowUsernameContent;

        public bool ShowUsernameContent
        {
            get { return _ShowUsernameContent; }
            set { SetProperty<bool>(ref _ShowUsernameContent, value); }
        }

        private bool _ShowPasswordContent;

        public bool ShowPasswordContent
        {
            get { return _ShowPasswordContent; }
            set { SetProperty<bool>(ref _ShowPasswordContent, value); }
        }

        private bool _ShowEmailContent;

        public bool ShowEmailContent
        {
            get { return _ShowEmailContent; }
            set { SetProperty<bool>(ref _ShowEmailContent, value); }
        }

        private bool _UsernameSwitchEmail;

        public bool UsernameSwitchEmail
        {
            get { return _UsernameSwitchEmail; }
            set { SetProperty<bool>(ref _UsernameSwitchEmail, value); }
        }

        private bool _PasswordSwitchSms;

        public bool PasswordSwitchSms
        {
            get { return _PasswordSwitchSms; }
            set { SetProperty<bool>(ref _PasswordSwitchSms, value); }
        }

        private bool _PasswordSwitchEmail;

        public bool PasswordSwitchEmail
        {
            get { return _PasswordSwitchEmail; }
            set { SetProperty<bool>(ref _PasswordSwitchEmail, value); }
        }

        private bool _UsernameSwitchSms;

        public bool UsernameSwitchSms
        {
            get { return _UsernameSwitchSms; }
            set { SetProperty<bool>(ref _UsernameSwitchSms, value); }
        }

        private string _ForgotEmailUsername;

        public string ForgotEmailUsername
        {
            get { return _ForgotEmailUsername; }
            set { SetProperty<string>(ref _ForgotEmailUsername, value); }
        }

        private string _EmailUsername;

        public string EmailUsername
        {
            get { return _EmailUsername; }
            set { SetProperty<string>(ref _EmailUsername, value); }
        }


        #endregion

        // commands
        #region commands

        public DelegateCommand Tab1Command { get; set; }
        public DelegateCommand Tab2Command { get; set; }
        public DelegateCommand Tab3Command { get; set; }

        // not working
        public DelegateCommand<string> usernameSwitchCommand { get; set; }

        public void ProcessUsernameSwitchCommand(string val)
        {
            if (val == "EMAIL")
            {
                UsernameSwitchEmail = true;
                UsernameSwitchSms = false;
            }
            else
            {
                UsernameSwitchEmail = true;
                UsernameSwitchSms = false;
            }
        }

        private void SetUsername()
        {
            SetCurrentTab(1);
            ShowEmailContent = false;
            ShowPasswordContent = false;
            ShowUsernameContent = true;
        }

        private void SetPassword()
        {
            SetCurrentTab(2);
            ShowEmailContent = false;
            ShowPasswordContent = true;
            ShowUsernameContent = false;
        }

        private void SetEmail()
        {
            SetCurrentTab(3);
            ShowEmailContent = true;
            ShowPasswordContent = false;
            ShowUsernameContent = false;
        }

        private void SetCurrentTab(int num)
        {
            if (_ctrl != null)
            {
                _ctrl.SetTabVisble(num);
            }
        }
		public void OnNavigatedTo(NavigationParameters parameters)
		{
			//if (parameters.ContainsKey("title"))
				//Title = (string)parameters["title"];
		}

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
           
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            
        }

        #endregion
    }
}
