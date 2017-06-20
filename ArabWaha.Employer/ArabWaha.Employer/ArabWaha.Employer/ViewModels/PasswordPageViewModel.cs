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

namespace ArabWaha.Employer.ViewModels
{
    public class PasswordPageViewModel : AWMVVMBase
    {
        TabControl3Column _ctrl;


        public PasswordPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {
            Tab1Command = new DelegateCommand(SetUsername);
            Tab2Command = new DelegateCommand(SetPassword);
            Tab3Command = new DelegateCommand(SetEmail);

            // commands for items
            usernameSwitchCommand = new DelegateCommand<string>(ProcessUsernameSwitchCommand);



            SetUsername();
        }


        #region tabs

        public void SetTabs(TabControl3Column ctrl)
        {
            _ctrl = ctrl;

            _ctrl.SetSearchVisible(false);

            if (GlobalSetting.CultureCode.Equals("en"))
            {
                _ctrl.SetTabText("Username", "Password", "Email");
                TitleText = "Forget Login Information";
                EmailTextUsername = "You will get your username information to the email you have signed up with";
                SMSTextUsername = "You will get your desired information via SMS to the cell phone number that is registered when you signed up";
                ButtonText = "Submit";

                EmailTextPassword = "You will get your password information to the email you have signed up with";
                SMSTextPassword = "You will get your password via SMS to the cell phone number that is registered when you signed up";
                ForgotEmailUsername = "If you have fogotten your password and Email address and want to change your email, please enter your username";
            }
            else
            {
                _ctrl.SetTabText("اسم المستخدم", "كلمه السر", "البريد الإلكتروني");
                TitleText = "ننسى معلومات تسجيل الدخول";
                EmailTextUsername = "ستحصل على معلومات اسم المستخدم على البريد الإلكتروني الذي اشتركت معه";
                SMSTextUsername = "سوف تحصل على المعلومات المطلوبة عبر الرسائل القصيرة إلى رقم الهاتف الخليوي التي يتم تسجيلها عند الاشتراك";
                ButtonText = "عرض";

                EmailTextPassword = "ستحصل على معلومات كلمة المرور على البريد الإلكتروني الذي اشتركت معه";
                SMSTextPassword = "سوف تحصل على كلمة المرور الخاصة بك عن طريق الرسائل القصيرة سمز إلى رقم الهاتف الخليوي الذي تم تسجيله عند الاشتراك";
                ForgotEmailUsername = "إذا كان لديك فوجوتن كلمة المرور وعنوان البريد الإلكتروني وتريد تغيير البريد الإلكتروني الخاص بك، يرجى إدخال اسم المستخدم الخاص بك";

            }
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

        private string _SMSText;
        public string SMSTextUsername
        {
            get { return _SMSText; }
            set { SetProperty<string>(ref _SMSText, value); }
        }

        private string _EmailTextPassword;
        public string EmailTextPassword
        {
            get { return _EmailTextPassword; }
            set { SetProperty<string>(ref _EmailTextPassword, value); }
        }

        private string _SMSTextPassword;
        public string SMSTextPassword
        {
            get { return _SMSTextPassword; }
            set { SetProperty<string>(ref _SMSTextPassword, value); }
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


        #endregion
    }
}
