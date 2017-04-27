using ArabWaha.Core.ModelsEmployer.Programs;
using ArabWaha.Employer.BaseCalsses;
using ArabWaha.Models;
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
    public class ProgramDetailsPageViewModel : AWMVVMBase, INavigationAware
    {
        public ProgramDetailsPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {
            IsBusy = false;

            _nav = navigationService;
            _dialog = dialog;

            RegServiceCommand = new DelegateCommand(ProcessRegServiceCommand);
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
                var t = ex.Message;
            }
        }
    }
}
