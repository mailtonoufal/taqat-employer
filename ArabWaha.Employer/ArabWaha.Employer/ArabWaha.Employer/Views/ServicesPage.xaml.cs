using System;
using System.Diagnostics;
using ArabWaha.Employer.BaseCalsses;
using Xamarin.Forms;

namespace ArabWaha.Employer.Views
{
    public partial class ServicesPage : AWMenuContainerPage
    {
        public ServicesPage()
        {
			
			try
            {
                InitializeComponent();
				//headerservice.ShowImg = false;
				headerservice.ShowLogo = false;
				headerservice.ShowLabel = true;
				headerservice.Title = "Services";

			}
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
          

        }
		private void ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			// just to stop the highlight/selection for now as its distracting client away from real issues.
			if (e.SelectedItem == null) return;
			((ListView)sender).SelectedItem = null;
		}



		 
	}
}
