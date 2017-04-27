using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ArabWaha.Employee.Views.Menus
{
    public class MenuListView : ListView
    {
        public MenuListView()
        {
            List<MasterPageItem> data = new MenuListData();

            ItemsSource = data;
            VerticalOptions = LayoutOptions.FillAndExpand;
            BackgroundColor = Color.Transparent;
            ItemTemplate = new DataTemplate(typeof(MenuListTemplate));

        //    this.ItemSelected += MenuListView_ItemSelected;

        }

        private void MenuListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var itm = e.SelectedItem as MasterPageItem;
            App.GetInstance().Navigate(itm); // .TargetType);
        }
    }
}
