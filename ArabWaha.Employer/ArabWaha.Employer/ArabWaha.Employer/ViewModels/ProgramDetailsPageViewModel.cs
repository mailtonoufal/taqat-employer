using ArabWaha.Core.ModelsEmployer.Programs;
using ArabWaha.Employer.BaseCalsses;
using ArabWaha.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;

namespace ArabWaha.Employer.ViewModels
{
    public class ProgramDetailsPageViewModel : AWMVVMBase, INavigationAware
    {
        public ProgramDetailsPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {
            IsBusy = false;

            _nav = navigationService;
            _dialog = dialog;

            RegServiceCommand = new DelegateCommand(ProcessRegServiceCommand);

            ProgImage = "Saned.png";
            ProgImgName = "Saned";

            IsBenefitVisible = true;
            IsBeneficiariesVisible = true;
            HowToRegister = true;
            ProgramIntroduction = true;
            WhocanBenefit = true;



        }

        private EmployerProgram _programDetails;

        public EmployerProgram ProgramDetails
        {
            get { return _programDetails; }
            set { SetProperty<EmployerProgram>(ref _programDetails, value); }
        }



        public void OnNavigatedFrom(NavigationParameters parameters)
        {
           
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            // set data from params.. 
            var data = parameters.Where(x => x.Key == "Data").FirstOrDefault();
            var obj = data.Value;

            if (obj != null && obj is EmployerProgram)
            {
                // yah we have what we need so continue.. 
                ProgramDetails = obj as EmployerProgram;
            }
        }

        public DelegateCommand RegServiceCommand { get; set; }
        void ProcessRegServiceCommand()
        {
            try
            {
                Device.OpenUri(new Uri(ProgramDetails.ProgramUrl));
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR:" + ex.Message);
            }
        }

       
        private string _progImage;
        public string ProgImage
		{
            get { return _progImage; }
            set { SetProperty<string>(ref _progImage, value); }
		}

		private string _progImgName;
		public string ProgImgName
		{
            get { return _progImgName; }
            set { SetProperty<string>(ref _progImgName, value); }
		}

        private bool _isBenefitVisible;
        public bool IsBenefitVisible
		{
			get { return _isBenefitVisible; }
            set { SetProperty<bool>(ref _isBenefitVisible, value); }
		}


		private bool _isBeneficiariesVisible;
		public bool IsBeneficiariesVisible
		{
			get { return _isBenefitVisible; }
			set { SetProperty<bool>(ref _isBeneficiariesVisible, value); }
		}

		private bool _howToRegister;
		public bool HowToRegister
		{
			get { return _howToRegister; }
			set { SetProperty<bool>(ref _howToRegister, value); }
		}
		private bool _programIntroduction;
		public bool ProgramIntroduction
		{
			get { return _programIntroduction; }
			set { SetProperty<bool>(ref _programIntroduction, value); }
		}

        private bool _whocanBenefit;
        public bool WhocanBenefit
		{
			get { return _whocanBenefit; }
            set { SetProperty<bool>(ref _whocanBenefit, value); }
		}

	


	}
}
