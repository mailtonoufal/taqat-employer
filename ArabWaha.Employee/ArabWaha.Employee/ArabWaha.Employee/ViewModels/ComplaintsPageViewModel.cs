using ArabWaha.Core.DBAccess;
using ArabWaha.Core.Services;
using ArabWaha.Employee.BaseClasses;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ArabWaha.Employee.ViewModels
{
    public class ComplaintsPageViewModel : AWMVVMBase, INavigatedAware
    {
        public ComplaintsPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {
            // get data 
            LoadSourceData();
        }

        private async void LoadSourceData()
        {
            ApiServiceIndividual api = new ApiServiceIndividual();
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
            
        }
    }
}
