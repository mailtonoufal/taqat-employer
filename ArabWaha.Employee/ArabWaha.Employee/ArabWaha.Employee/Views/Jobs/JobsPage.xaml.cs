using ArabWaha.Employee.BaseClasses;
using ArabWaha.Employee.ViewModels;
using Xamarin.Forms;

namespace ArabWaha.Employee.Views.Jobs
{
    public partial class JobsPage : AWMenuContainerPage
    {
        public JobsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var vm = this.BindingContext as JobsPageViewModel;
            vm.SetTabs(tabCtrl);
        }
    }
}
