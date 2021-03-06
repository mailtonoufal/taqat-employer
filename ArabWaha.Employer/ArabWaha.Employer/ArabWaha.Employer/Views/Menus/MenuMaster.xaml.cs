﻿using ArabWaha.Core.Services;
using ArabWaha.Employer.BaseCalsses;
using Pillar;
using Prism.Commands;
using SlideOverKit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ArabWaha.Employer.StaticData;

namespace ArabWaha.Employer.Views.Menus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuMaster : SlideMenuView
    {
        public ListView LstView { get; set; }

        public MenuMaster()
        {
           try
            {
				
				InitializeComponent();
				
			}
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
           

            this.IsFullScreen = true;
            this.WidthRequest = 250;
            this.MenuOrientations = MenuOrientation.RightToLeft;
            this.BackgroundColor = Color.Navy;
            this.BackgroundViewColor = Color.Transparent; //  FromHex("#CE766C");

            this.MenuOrientations = MenuOrientation.LeftToRight;

            if (GlobalSetting.CultureCode == "ar")
                this.MenuOrientations = MenuOrientation.RightToLeft;


            SetupMenu();
			if (AuthService.IsAuthorised == false)
			{
				profile.IsVisible = false;
			}
			else
			{
				profile.IsVisible = true;
			}

           
        }

        private void SetupMenu()
        {
            LstView = new MenuListView();
            LstView.SeparatorVisibility = SeparatorVisibility.None;
            var layout = this.FindByName<ContentView>("menuContent");
            layout.Content = LstView;

            MenuNavigateCommand = new DelegateCommand<MasterPageItem>(NavigateMenu);

            // add buttons
            var english = this.FindByName<Button>("ChangeEnglish");
            english.Clicked += async (sender, args) =>
            {
                if (!GlobalSetting.CultureCode.Equals("en"))
                {
                    ApiService api = new ApiService();
                    await api.SetCurrentCultureAsync("en");
                    GlobalSetting.SetupCulture();

                    await ((AWMVVMBase)this.ParentView.BindingContext).ShowMessage("Language Change", "Language Changed to English", "OK");
                    ((AWMVVMBase)this.ParentView.BindingContext).NavigateAsync($"{nameof(StartPage)}");
                }

            };

            var arabic = this.FindByName<Button>("ChangeArabic");
            arabic.Clicked += async (sender, args) =>
            {
                if (!GlobalSetting.CultureCode.Equals("ar"))
                {
                    ApiService api = new ApiService();
                    await api.SetCurrentCultureAsync("ar");
                    GlobalSetting.SetupCulture();

                    await ((AWMVVMBase)this.ParentView.BindingContext).ShowMessage("تغير اللغة", "تم تغيير اللغة إلى الإنجليزية", "حسنا");
                    ((AWMVVMBase)this.ParentView.BindingContext).NavigateAsync($"{nameof(StartPage)}");
                }
            };

            if(GlobalSetting.CultureCode.Equals("ar"))
			{
				arabic.TextColor = Color.White;
				arabic.BackgroundColor = Color.FromHex("#012148");
				english.TextColor = Color.FromHex("#012148");
				english.BackgroundColor = Color.White;
            }
            else
            {
				english.TextColor = Color.White;
				english.BackgroundColor = Color.FromHex("#012148");
				arabic.TextColor = Color.FromHex("#012148");
				arabic.BackgroundColor = Color.White;
            }
        }

        public DelegateCommand<MasterPageItem> MenuNavigateCommand { get; set; }

        private void NavigateMenu(MasterPageItem obj)
        {
            try {
                var layout = this.FindByName<ContentView>("menuContent");
                (layout.Content as ListView).SelectedItem = null;
                ((AWMVVMBase)this.ParentView.BindingContext).NavigateAsync(obj);
            }
            catch(Exception ex)
            {
                Debug.WriteLine("ERROR:" + ex.Message);
            }
       }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
        }

        protected override void OnParentSet()
        {
            base.OnParentSet();
            var layout = this.FindByName<ContentView>("menuContent");
            layout.Content.Behaviors.Clear();
            layout.Content.Behaviors.Add(new EventToCommandBehavior
            {
                EventName = "ItemTapped",
                Command = MenuNavigateCommand,
                EventArgsConverter = new ItemTappedEventArgsConverter()
            });
        }
    }
}
