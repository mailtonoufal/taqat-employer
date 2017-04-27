using ArabWaha.Employee.BaseClasses;
using ArabWaha.Employee.ViewModels;
using ArabWaha.Employee.Views.Menus;
using SlideOverKit;
using Xamarin.Forms;

namespace ArabWaha.Employee.Views
{
    public partial class HomePage : AWMenuContainerPage
    {
        public HomePage()
        {
            InitializeComponent();


        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var vm = this.BindingContext as HomePageViewModel;
            vm.SetTabs(tabCtrl);
        }
    }
}
