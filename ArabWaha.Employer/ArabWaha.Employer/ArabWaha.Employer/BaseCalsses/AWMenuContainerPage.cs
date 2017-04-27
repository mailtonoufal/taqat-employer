﻿using ArabWaha.Employer.Views.Menus;
using SlideOverKit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ArabWaha.Employer.BaseCalsses
{
    public partial class AWMenuContainerPage : MenuContainerPage
    {
        public AWMenuContainerPage()
        {
            this.SlideMenu = new MenuMaster();
            var tbarItem = new ToolbarItem()
            {
                Icon = "hamburger.png",
                Command = new Command((sender) => { ShowMenu(); }),
                Priority = 100,
            };
            this.ToolbarItems.Add(tbarItem);
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
                Debug.WriteLine("Exception Hiding Menu Page");
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
                Debug.WriteLine("Exception Hiding Menu Page");
            }
        }
    }
}
