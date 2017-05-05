using ArabWaha.Employer.BaseCalsses;
using ArabWaha.Employer.ViewModels;
using Xamarin.Forms;

namespace ArabWaha.Employer.Views
{
    public partial class ComplaintsPage : ContentPage
    {
        public ComplaintsPage()
        {
            InitializeComponent();

            // add menu items here to bind to then bind command in viewmodel
            SetupToolbarItems();

        }

        private void SetupToolbarItems()
        {
            var tbicon = new ToolbarItem();
            tbicon.Icon = "addicon.png";

            var tbitem = new ToolbarItem();
//            tbitem.Icon = "addicon.png";
            // tbitem.Command = ;

            // mod based on access
            if (GlobalSetting.CultureCode=="ar")
                tbitem.Text = "إضافة شكوى جديدة";
            else
                tbitem.Text = "Add New Complaint";


            tbitem.Command = (BindingContext as ComplaintsPageViewModel).AddNewComplaintsCommand;
            tbicon.Command = (BindingContext as ComplaintsPageViewModel).AddNewComplaintsCommand;

            this.ToolbarItems.Add(tbicon);
            this.ToolbarItems.Add(tbitem);
        }
    }
}
