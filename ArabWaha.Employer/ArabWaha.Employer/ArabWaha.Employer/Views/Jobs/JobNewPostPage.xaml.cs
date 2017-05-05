using Xamarin.Forms;

namespace ArabWaha.Employer.Views
{
    public partial class JobNewPostPage : ContentPage
    {
        public JobNewPostPage()
        {
            InitializeComponent();
        }

        private void Button_DescendantAdded(object sender, ElementEventArgs e)
        {

        }

        private void ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // just to stop the highlight/selection.
            if (e.SelectedItem == null) return;
            ((ListView)sender).SelectedItem = null;
        }
    }
}
