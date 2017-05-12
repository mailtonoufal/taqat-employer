using ArabWaha.Employer.BaseCalsses;
using ArabWaha.Employer.ViewModels;
using ArabWaha.Employer;
using Pillar;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ArabWaha.Employer.Views.Menus
{
    public class MenuListView : ListView
    {
        public MenuListView()
        {
            List<MasterPageItem> data = new MenuListData();
            ItemsSource = data;
            VerticalOptions = LayoutOptions.FillAndExpand;
            BackgroundColor = Color.Transparent;
            Margin = 0;

            ItemTemplate = new DataTemplate(typeof(MenuListTemplate));
        }


        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
        }

    }
}
