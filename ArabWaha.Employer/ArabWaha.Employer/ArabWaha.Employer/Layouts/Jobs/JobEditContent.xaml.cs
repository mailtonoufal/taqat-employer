using ArabWaha.Employer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace ArabWaha.Employer.Layouts.Jobs
{
    public partial class JobEditContent : ContentView
    {
        public JobEditContent()
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

        //protected async override void OnBindingContextChanged()
        //{
        //    base.OnBindingContextChanged();

        //    // has map been created. 
        //    var map = this.FindByName<Map>("AddressMap");

        //    // seems a bit hack to pass map to viewmodel :(
        //    var context = this.BindingContext as JobPageViewModel;
        //    context.SetupMap(map);
        //}
    }
}
