using ArabWaha.Core.ModelsEmployer.Services;
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
    public class ServiceDetailsPageViewModel : AWMVVMBase, INavigationAware
    {
        public ServiceDetailsPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {
            IsBusy = false;

            RegServiceCommand = new DelegateCommand(ProcessRegServiceCommand);
        }
        private EmployerService _serviceDetails;

        public EmployerService ServiceDetails
        {
            get { return _serviceDetails; }
            set { SetProperty<EmployerService>(ref _serviceDetails, value); }
        }


        public void OnNavigatedFrom(NavigationParameters parameters)
        {
          
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            var t = "";
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            // set data from params.. 
            var data = parameters.Where(x => x.Key == "Data").FirstOrDefault();
            var obj = data.Value;

            if (obj != null && obj is EmployerService)
            {
                // yah we have what we need so continue.. 
                ServiceDetails = obj as EmployerService;
            }
        }

        public DelegateCommand RegServiceCommand { get; set; }
        void ProcessRegServiceCommand()
        {
            try
            {
                Device.OpenUri(new Uri(ServiceDetails.ServiceUrl));
            }
            catch (Exception ex)
            {
                var t = ex.Message;
            }
        }
    }
}
