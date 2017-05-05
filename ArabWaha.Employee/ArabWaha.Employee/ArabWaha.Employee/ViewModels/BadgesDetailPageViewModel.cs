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
    public class BadgesDetailPageViewModel : AWMVVMBase, INavigationAware
    {
        public BadgesDetailPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {

        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
          //  throw new NotImplementedException();
        }

        #region properties

        private Badges _badgeDetail;
        public Badges BadgeDetail
        {
            get
            {
                return _badgeDetail;
            }
            set
            {
                SetProperty<Badges>(ref _badgeDetail, value);
            }
        }

        #endregion

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            var data = parameters.Where(x => x.Key == "DETAIL").FirstOrDefault();
            if (data.Value != null)
            {
                BadgeDetail = data.Value as Badges;
            }
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            var data = parameters.Where(x => x.Key == "DETAIL").FirstOrDefault();
            if (data.Value != null)
            {
                BadgeDetail = data.Value as Badges;
            }
        }
    }
}
