using ArabWaha.Employer.BaseCalsses;
using ArabWaha.Employer.Views;

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
    public class SettingsPageViewModel : AWMVVMBase
    {
        public DelegateCommand LogoutCommand { get; set; }
        public DelegateCommand ResetPasswordCommand { get; set; }

        public DelegateCommand ComplaintsCommand { get; set; }
        public DelegateCommand AboutCommand { get; set; }

		private string _textlanguage;
		public string textlanguage
		{
			get { return _textlanguage; }
			set
			{
				SetProperty(ref _textlanguage, value);
			}
		}

		private string _textsettingsresetpw;
		public string textsettingsresetpw
		{
			get { return _textsettingsresetpw; }
			set
			{
				SetProperty(ref _textsettingsresetpw, value);
			}
		}

		private string _textcomplaints;
		public string textcomplaints
		{
			get { return _textcomplaints; }
			set
			{
				SetProperty(ref _textcomplaints, value);
			}
		}

		private string _textaboutpagetitle;
		public string textaboutpagetitle
		{
			get { return _textaboutpagetitle; }
			set
			{
				SetProperty(ref _textaboutpagetitle, value);
			}
		}
		private string _settingslogoutbtn;
		public string settingslogoutbtn
		{
			get { return _settingslogoutbtn; }
			set
			{
				SetProperty(ref _settingslogoutbtn, value);
			}
		}
		private string _settingspagetitle;
		public string settingspagetitle
		{
			get { return _settingspagetitle; }
			set
			{
				SetProperty(ref _settingspagetitle, value);
			}
		}

        public SettingsPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {
            LogoutCommand = new DelegateCommand(Logout);
            ResetPasswordCommand = new DelegateCommand(ResetPassword);
            ComplaintsCommand = new DelegateCommand(ComplaintsNavigate);
            AboutCommand = new DelegateCommand(About);


			TranslateExtension tran = new TranslateExtension();



			textlanguage = App.Translation != null ? App.Translation.employer.settingslbltxtlang : tran.GetProviderValueString("TextLanguage");
			//textlanguage = tran.GetProviderValueString("TextLanguage");

			textsettingsresetpw = App.Translation != null ? App.Translation.employer.settingslblresetpwd : tran.GetProviderValueString("TextSettingsResetPassword");
			//textsettingsresetpw = tran.GetProviderValueString("TextSettingsResetPassword");

			textcomplaints = App.Translation != null ? App.Translation.employer.settingslblcomplaints : tran.GetProviderValueString("TextComplaints");
			//textcomplaints = tran.GetProviderValueString("TextComplaints");

			textaboutpagetitle = App.Translation != null ? App.Translation.employer.settingslblpagetitle : tran.GetProviderValueString("TextAboutPageTitle");
			//textaboutpagetitle = tran.GetProviderValueString("TextAboutPageTitle");

			settingslogoutbtn = App.Translation != null ? App.Translation.employer.settingslbllogoutbtn : tran.GetProviderValueString("LabelButtonLogOutText");
			//settingslogoutbtn = tran.GetProviderValueString("LabelButtonLogOutText");

			settingspagetitle = App.Translation != null ? App.Translation.employer.settingslbltitle : tran.GetProviderValueString("TextSettingPageTitle");
			//settingspagetitle = tran.GetProviderValueString("TextSettingPageTitle");


		}


        private void About()
        {
            _nav.NavigateAsync(nameof(AboutPage));
        }

        private void ComplaintsNavigate()
        {
            _nav.NavigateAsync(nameof(ComplaintsPage));
        }

        private void ResetPassword()
        {
            _nav.NavigateAsync(nameof(PasswordPage));
        }

        private void Logout()
        {
            _nav.NavigateAsync(nameof(LoginPage));
        }
                
        public string CurrentLanguage
        {
            get {

                if (CultureCode == "ar")
                    return "عربى";
                else
                    return "English";

            }
        }

    }
}
