using System.Diagnostics;
using ArabWaha.Employer.ViewModels;
using Xamarin.Forms;

namespace ArabWaha.Employer.Views
{
    public partial class CompanyManageUsersPage : ContentPage
    {
        public CompanyManageUsersPage()
        {
            InitializeComponent();

            var companyManageUsersPageViewModel = (CompanyManageUsersPageViewModel)this.BindingContext;

            ToolbarItems.Add(new ToolbarItem("", "Plus.png", () =>
                {
                    companyManageUsersPageViewModel.AddButtonClick();

                }));


        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //var vm = this.BindingContext as CompanyManageUsersPageViewModel;
            //if (vm != null)
            //    vm.SetTabs(tabCtrl);
        }
    }
}
