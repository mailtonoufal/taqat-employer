using ArabWaha.Core.ModelsEmployer.Services;
using ArabWaha.Core.Services;
using ArabWaha.Employer.BaseCalsses;
using ArabWaha.Employer.Views.Home;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ArabWaha.Employer.ViewModels
{
    public class ServicesPageViewModel : AWMVVMBase
    {
        public ServicesPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {
            ServicesSelectedCommand = new DelegateCommand<EmployerService>(ProcessServicesSelectedCommand);

            LoadSource();
        }

        private async void LoadSource()
        {
            ApiService apiServ = new ApiService();
            ServicesSource = await apiServ.GetAllServicesAsync(); // add employer id if logged on
        }

        private ObservableCollection<EmployerService> _ServicesSource;

        public ObservableCollection<EmployerService> ServicesSource
        {
            get { return _ServicesSource; }
            set { SetProperty< ObservableCollection < EmployerService >>(ref _ServicesSource , value); }
        }

        #region commands

        public DelegateCommand<EmployerService> ServicesSelectedCommand { get; set; }
        async void ProcessServicesSelectedCommand(EmployerService vals)
        {
            if (vals != null)
            {
                NavigationParameters paramx = new NavigationParameters();
                paramx.Add("Data", vals);
                await _nav.NavigateAsync(nameof(ServiceDetailsPage), paramx, false, true);
            }
        }


        #endregion

    }
}
