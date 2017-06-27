using System;
using System.Diagnostics;
using ArabWaha.Employer.BaseCalsses;
using Xamarin.Forms;
using System.Collections.Generic;

namespace ArabWaha.Employer.Views
{
    public partial class ProgramsPage : AWMenuContainerPage
    {
        public ProgramsPage()
        {
			
            try
            {
                InitializeComponent();
				//header.ShowImg = true;
				header.ShowLogo = false;
				header.Title = "Programs";
				header.ShowLabel = true;
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
