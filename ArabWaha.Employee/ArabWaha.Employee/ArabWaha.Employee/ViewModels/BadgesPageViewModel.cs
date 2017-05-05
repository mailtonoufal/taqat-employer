using ArabWaha.Core.DBAccess;
using ArabWaha.Core.Services;
using ArabWaha.Employee.BaseClasses;
using ArabWaha.Employee.Helpers;
using ArabWaha.Employee.Views.Badges;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ArabWaha.Employee.ViewModels
{
    public class BadgesPageViewModel : AWMVVMBase, INavigationAware
    {
        public BadgesPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {

            // set up commands here
            BadgeSelectedCommand = new DelegateCommand<Badges>(ProcessBadgeSelected);


            LoadData();
        }

        async void LoadData()
        {
            ApiServiceIndividual api = new ApiServiceIndividual();
            BadgeSource = await api.GetBadgesAsync();
            TranslateExtension trans = new TranslateExtension();

            // set init data here
            foreach (var item in BadgeSource)
            {
                if (item.Locked == 0) // locked item
                {
                    item.BadgeIcon = "startemptyy.png";
                    item.BadgeStatus = trans.GetProviderValueString("LabelBadgeLockedStatus");
                }
                else
                {
                    item.BadgeIcon = "starfilledy.png";
                    item.BadgeStatus = trans.GetProviderValueString("LabelBadgeUNLockedStatus");
                }
            }
        }

        private Badges _SelectedBadge;

        public  Badges SelectedBadge
        {
            get { return _SelectedBadge; }
            set {
                if (value!=null && _SelectedBadge != value)
                {
                    SetProperty<Badges>(ref _SelectedBadge, value);

                    //                    NavigationParameters navP = new NavigationParameters();
                    //                    navP.Add("DETAIL", value);
                    //                    _nav.NavigateAsync(nameof(BadgesDetailPage), navP);
                    OpenBadgeInfo(value);
                }
            }
        }

        private async void OpenBadgeInfo(Badges info)
        {
            try
            {
                // now push to the badge details screen
                NavigationParameters navP = new NavigationParameters();
                navP.Add("DETAIL", info);

                await _nav.NavigateAsync(nameof(BadgesDetailPage), navP);
            }
            catch(Exception ex)
            {
                var t = ex.Message;
            }

        }

        #region props

        #region commands

        public DelegateCommand<Badges> BadgeSelectedCommand { get; set; }

        #endregion



        async void ProcessBadgeSelected(Badges vals)
        {
            if (vals != null)
            {
                NavigationParameters paramx = new NavigationParameters();
                paramx.Add("Data", vals);
                //await _nav.NavigateAsync(nameof(ProgramDetailsPage), paramx, false, true);
            }
        }

        private ObservableCollection<Badges> _badgeSource;

        public ObservableCollection<Badges> BadgeSource
        {
            get { return _badgeSource; }
            set { SetProperty< ObservableCollection < Badges >>(ref _badgeSource , value); }
        }


        #endregion

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            //throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            //throw new NotImplementedException();
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            //throw new NotImplementedException();
        }
    }
}
