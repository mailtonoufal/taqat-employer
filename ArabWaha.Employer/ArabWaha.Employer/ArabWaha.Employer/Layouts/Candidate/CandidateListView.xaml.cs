using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Diagnostics;

namespace ArabWaha.Employer.Layouts.Candidate
{
    public partial class CandidateListView : ContentView
    {
        public CandidateListView()
        {
			try
			{
				InitializeComponent();
			}
			catch (Exception ex)
			{
				Debug.WriteLine("ERROR:" + ex.Message);
			}
        }
    }
}
