using ArabWaha.Core.DBAccess;
using ArabWaha.Employee.BaseClasses;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArabWaha.Employee.ViewModels
{
    public class NotificationDetailsPageViewModel : AWMVVMBase, INavigatedAware
    {
        public NotificationDetailsPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {
            IsBusy = false;

        }

        // data
        #region notify data item

        private Notifications _notifyItem;
        public Notifications NotifyItem
        {
            get
            {
                return _notifyItem;
            }
            set
            {
                SetProperty<Notifications>(ref _notifyItem, value); 
            }
        }

        #endregion

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            var data = parameters.Where(x => x.Key == "DETAILS").FirstOrDefault();
            if (data.Value != null)
            {
                NotifyItem = data.Value as Notifications;
             //   RaisePropertyChanged(nameof(NotifyItem));
            }
        }
    }
}
