using ArabWaha.Employer.BaseCalsses;
using ArabWaha.Employer.ViewModels;
using System;
using Xamarin.Forms;

namespace ArabWaha.Employer.Views
{
    public partial class ApplicationsPage : AWMenuContainerPage
    {
        public ApplicationsPage()
        {
            try
            {
                InitializeComponent();
            }
            catch(Exception ex)
            {
                var t = ex.Message;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                var vm = this.BindingContext as ApplicationsPageViewModel;
                if (vm != null)
                    vm.SetTabs(tabCtrl);
            }
            catch(Exception ex)
            {
                var t = ex.Message;
            }
        }
    }
}
