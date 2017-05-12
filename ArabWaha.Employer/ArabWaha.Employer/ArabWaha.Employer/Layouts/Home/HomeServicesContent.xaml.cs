using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ArabWaha.Employer.Layouts
{
    public partial class HomeServicesContent : ContentView
    {
        public HomeServicesContent()
        {
            InitializeComponent();
        }

        private void ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // just to stop the highlight/selection for now as its distracting client away from real issues.
            if (e.SelectedItem == null) return;
            ((ListView)sender).SelectedItem = null;
        }
    }
}
