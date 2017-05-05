using Xamarin.Forms;

namespace ArabWaha.Employer.Views
{
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ForceLayout();
        }
    }
}
