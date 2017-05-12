using ArabWaha.Employer.BaseCalsses;
using ArabWaha.Employer.ViewModels;
using ArabWaha.Employer.Views.Menus;
using SlideOverKit;
using System;
using Xamarin.Forms;

namespace ArabWaha.Employer.Views
{
    public partial class HomePage : AWMenuContainerPage
    {
        public HomePage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<HomePageViewModel>(this, "HideMenu", HideMenuMessage);
        }

        private void HideMenuMessage(HomePageViewModel obj) //  MenuListView obj)
        {
            try
            {
                this.HideMenu();
            }
            catch
            {
                // ignore
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            //MessagingCenter.Unsubscribe<MenuListView>(this, "HideMenu");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var vm = this.BindingContext as HomePageViewModel;
            if (vm != null)
                vm.SetTabs(tabCtrl);
        }

        private void ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // just to stop the highlight/selection for now as its distracting client away from real issues.
            if (e.SelectedItem == null) return;
            ((ListView)sender).SelectedItem = null;
        }
    }
}
