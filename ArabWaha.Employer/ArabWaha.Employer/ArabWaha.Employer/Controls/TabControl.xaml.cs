﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArabWaha.Employer.StaticData;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArabWaha.Employer.Controls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TabControl : StackLayout
	{
		public TabControl()
		{
			InitializeComponent();
		}

		public void SetTabVisble(int number)
		{
			Searcher.Placeholder = App.Translation.employer.guestsearchlbltitle;

			tab1Selected.IsVisible = false;
			tab2Selected.IsVisible = false;
			tab3Selected.IsVisible = false;
			tab4Selected.IsVisible = false;
			Tab1.Style = (Style)Application.Current.Resources["TabButtonFlatNotSelected"];
			Tab2.Style = (Style)Application.Current.Resources["TabButtonFlatNotSelected"];
			Tab3.Style = (Style)Application.Current.Resources["TabButtonFlatNotSelected"];
			Tab4.Style = (Style)Application.Current.Resources["TabButtonFlatNotSelected"];

			if (number == 1)
			{
				if (GlobalSetting.IsEnglish)
                    SelectTab1();
				else
					SelectTab4();
			}
			else if (number == 2)
			{
				if (GlobalSetting.IsEnglish)

					SelectTab2();
				else
					SelectTab3();
			}
			else if (number == 3)
			{
				if (GlobalSetting.IsEnglish)

					SelectTab3();
				else
					SelectTab2();
			}
			else
			{
				if (GlobalSetting.IsEnglish)

					SelectTab4();
				else
					SelectTab1();
			}

			tab1NotSelected.IsVisible = !tab1Selected.IsVisible;
			tab2NotSelected.IsVisible = !tab2Selected.IsVisible;
			tab3NotSelected.IsVisible = !tab3Selected.IsVisible;
			tab4NotSelected.IsVisible = !tab4Selected.IsVisible;
		}

		public void SetTabText(string tab1text, string tab2text, string tab3text, string tab4text)
		{
			Tab1.Text = tab1text;
			Tab2.Text = tab2text;
			Tab3.Text = tab3text;
			Tab4.Text = tab4text;
		}

		public void SetSearchVisible(bool val)
		{
			Searcher.IsVisible = val;
		}

		public void SelectTab1()
		{
			tab1Selected.IsVisible = true;
			Tab1.Style = (Style)Application.Current.Resources["TabButtonFlat"];
		}

		public void SelectTab2()
		{
			tab2Selected.IsVisible = true;
			Tab2.Style = (Style)Application.Current.Resources["TabButtonFlat"];
		}

		public void SelectTab3()
		{
			tab3Selected.IsVisible = true;
			Tab3.Style = (Style)Application.Current.Resources["TabButtonFlat"];
		}

		public void SelectTab4()
		{
			tab4Selected.IsVisible = true;
			Tab4.Style = (Style)Application.Current.Resources["TabButtonFlat"];
		}

	}
}
