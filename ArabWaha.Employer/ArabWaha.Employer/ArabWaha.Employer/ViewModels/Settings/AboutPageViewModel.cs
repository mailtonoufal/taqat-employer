using ArabWaha.Core.Services;
using ArabWaha.Employer.BaseCalsses;
using ArabWaha.Employer.Helpers;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArabWaha.Employer.ViewModels
{
    public class AboutPageViewModel : AWMVVMBase
    {
        public AboutPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {
            LoadData();
        }

        private async void LoadData()
        {
            // load the version and terms data here into vars

            TranslateExtension tran = new TranslateExtension();
            var ver = tran.GetProviderValueString("LabelAboutVersionText");

            ApiService serv = new ApiService();
            var verNo = await serv.GetAppVersionAsync();

            if (CultureCode == "ar")
                AppVersion = $"{verNo} {ver}";
            else
                AppVersion = $"{ver} {verNo}";

            // pull terms.. maybe from db or api or resources
            TermsText = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim. Aliquam lorem ante, dapibus in, viverra quis, feugiat a, tellus. Phasellus viverra nulla ut metus varius laoreet. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum";
        }

        private string _version;

        public string AppVersion
        {
            get { return _version; }
            set { SetProperty<string>(ref _version , value); }
        }

        private string _termsText;
        public string TermsText
        {
            get { return _termsText; }
            set { SetProperty<string>(ref _termsText, value); }
        }

        public object ServiceApi { get; private set; }
    }
}
