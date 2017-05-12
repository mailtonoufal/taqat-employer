using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ArabWaha.Employer.Layouts.Jobs
{
    public partial class JobDisplayContent : ContentView
    {
        public JobDisplayContent()
        {
            try
            {
                InitializeComponent();
            }
            catch(Exception ex)
            {
                var t = ex.Message;
            }
        }
    }
}
