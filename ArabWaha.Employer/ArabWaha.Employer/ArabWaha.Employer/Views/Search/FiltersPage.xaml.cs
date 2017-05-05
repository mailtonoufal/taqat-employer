using Xamarin.Forms;

namespace ArabWaha.Employer.Views
{
    public partial class FiltersPage : ContentPage
    {
        public FiltersPage()
        {
            InitializeComponent();
        }

        private void ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // just to stop the highlight/selection.
            if (e.SelectedItem == null) return;
            ((ListView)sender).SelectedItem = null; 
        }
    }
}
