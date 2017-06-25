using ArabWaha.Employer.Views.Menus;
using SlideOverKit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ArabWaha.Employer.StaticData;

namespace ArabWaha.Employer.BaseCalsses
{
    public partial class AWMenuContainerPage : MenuContainerPage
    {

        private MenuMaster _mainMenu;
        public AWMenuContainerPage()
        {
            _mainMenu = new MenuMaster();
            this.SlideMenu = _mainMenu;
            //var tbarItem = new ToolbarItem()
            //{
            //    Icon = "hamburger.png",
            //    Command = new Command((sender) => { ShowMainMenu(); }),
            //    Priority = 100,

            //};
            //this.ToolbarItems.Add(tbarItem);
            if (
				GlobalSetting.CultureCode == "ar")
                this.SlideMenu.MenuOrientations = MenuOrientation.RightToLeft;
            else
                this.SlideMenu.MenuOrientations = MenuOrientation.LeftToRight;

        }

       

        private ICommand _menuTapped;
        private string v;

        public ICommand MenuTappedCommand
        {
            get
            {
                return _menuTapped
                       ?? (_menuTapped = new Command(
                           () =>
                           {
                               ShowMainMenu();
                           }
                           ));
            }
        }



        protected virtual void ShowMainMenu()
        {
            this.SlideMenu = _mainMenu;
            // default 
            this.ShowMenu();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                this.HideMenu();
            }
            catch
            {
                Debug.WriteLine("ERROR: Exception Hiding Menu Page");
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            try
            {
                this.HideMenu();
            }
            catch
            {
                Debug.WriteLine("ERROR: Exception Hiding Menu Page");
            }
        }
    }
}
