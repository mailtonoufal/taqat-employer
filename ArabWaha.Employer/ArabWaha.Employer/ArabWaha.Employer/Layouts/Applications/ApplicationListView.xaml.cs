using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ArabWaha.Employer.Layouts
{
    public partial class ApplicationListView : ContentView
    {
        public ApplicationListView()
        {
            try
            {
                InitializeComponent();
            }
            catch(Exception ex)
            {
                Debug.WriteLine("ERROR:" + ex.Message);
            }
        }
    }
}
