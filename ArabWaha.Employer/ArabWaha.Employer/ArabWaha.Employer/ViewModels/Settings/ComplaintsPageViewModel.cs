using ArabWaha.Core.DBAccess;
using ArabWaha.Core.Services;
using ArabWaha.Employer.BaseCalsses;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ArabWaha.Employer.Views.Settings;
using System.Linq;

namespace ArabWaha.Employer.ViewModels
{
    public class ComplaintsPageViewModel : AWMVVMBase, INavigatedAware
    {
        public ComplaintsPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {
            LoadSourceData();

            AddNewComplaintsCommand = new DelegateCommand(processAddComplaintCommand);

            LabelColumn = 1;
            DataColumn = 2;

            if(CultureCode=="ar")
            {
                LabelColumn = 2;
                DataColumn = 1;
            }
        }

        public DelegateCommand AddNewComplaintsCommand { get; set; }

        private async void processAddComplaintCommand()
        {
                // create new command but pass in user/company id for recording it.
                NavigationParameters navP = new NavigationParameters();
                await _nav.NavigateAsync(nameof(AddNewComplaintPage));
       }

        private async void LoadSourceData()
        {
            ApiService api = new ApiService();
            ComplaintsSource = await api.GetComplaintsAsync();
        }

        private ObservableCollection<ComplaintRaised> _complaintsSource;

        public ObservableCollection<ComplaintRaised> ComplaintsSource
        {
            get
            {
                return _complaintsSource;
            }
            set
            {
                SetProperty<ObservableCollection<ComplaintRaised>>(ref _complaintsSource, value);
            }
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            // check params 
            var data = parameters.Where(x => x.Key == "UPDATE").FirstOrDefault();
            if (data.Value != null)
            {
                //refresh complains list here
                LoadSourceData(); ;
            }

        }



    }
}
