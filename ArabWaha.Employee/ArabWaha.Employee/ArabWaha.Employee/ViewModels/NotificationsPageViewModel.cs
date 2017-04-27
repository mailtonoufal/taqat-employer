using ArabWaha.Core.DBAccess;
using ArabWaha.Core.Services;
using ArabWaha.Employee.BaseClasses;
using ArabWaha.Employee.Views.Details;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ArabWaha.Employee.ViewModels
{
    public class NotificationsPageViewModel : AWMVVMBase, INavigatedAware
    {
        public NotificationsPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {
            IsBusy = false;

            NotificationCommand = new DelegateCommand<Notifications>(ProcessNotification);

            LoadDatasource();
        }

        #region selected item to read

        // NotificationItem
        private Notifications _notificationsItem;
        public Notifications NotificationItem
        {
            get
            {
                return _notificationsItem;
            }
            set
            {
                _notificationsItem = value;

                if (_notificationsItem == null)
                    return;

                NotificationCommand.Execute(_notificationsItem);

                _notificationsItem = null;
            }
        }

        #endregion

        #region commands

        private DelegateCommand<Notifications> NotificationCommand { get; set; }
        async void ProcessNotification(Notifications notify)
        {
            // set up DETAILS
            if (notify == null) return;

            NavigationParameters navP = new NavigationParameters();
            navP.Add("DETAILS", notify);
            await _nav.NavigateAsync(nameof(NotificationDetailsPage), navP);
        }

        #endregion

        #region datasources


        private async Task LoadDatasource()
        {
            ApiServiceIndividual api = new ApiServiceIndividual();
            NotificationsSource = await api.GetNotificationsAsync();
        }

        private ObservableCollection<Notifications> _notificationsSource;
        public ObservableCollection<Notifications> NotificationsSource
        {
            get
            {
                return _notificationsSource;
            }

            set
            {
                SetProperty<ObservableCollection<Notifications>>(ref _notificationsSource, value);
            }
        }

        #endregion

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
           // throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
           // throw new NotImplementedException();
        }
    }
}
