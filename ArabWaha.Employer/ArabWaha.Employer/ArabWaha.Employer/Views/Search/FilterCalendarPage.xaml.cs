using System;
using System.Collections.Generic;
using ArabWaha.Employer.StaticData;
using ArabWaha.Employer.ViewModels;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace ArabWaha.Employer.Views
{
	public class FilterCalendarPageEventArgs : EventArgs
	{
		public DateTime gregorianSelectedDate { get; set; }
		public int hijriSelectedYear { get; set; }
		public int hijriSelectedMonth { get; set; }
		public int hijriSelectedDay { get; set; }
	}

	public delegate void FilterCalendarPageEventDelegate(FilterCalendarPageEventArgs _args);

	public partial class FilterCalendarPage : PopupPage
	{
		public event FilterCalendarPageEventDelegate dateSelected;
		public FilterCalendarPage(DateTime dt, int hijriYear = 0, int hijriMonth = 0, int hijriDay = 0)
		{
			InitializeComponent();

			var viewModel = ((FilterCalendarPageViewModel)BindingContext);
			if (GlobalSetting.IsArabic)
			{
				viewModel.CurrentHijriYear = hijriYear;
				viewModel.CurrentHijriMonth = hijriMonth;
				viewModel.CurrentHijriDay = hijriDay;
			}
			else
			{
				viewModel.MonthViewCurrentGregorianDate = dt;
			}

			viewModel.PropertyChanged += Handle_PropertyChanged;

		}

		void Handle_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "SelectedGregorianDate")
			{
				var viewModel = ((FilterCalendarPageViewModel)BindingContext);
				var args = new FilterCalendarPageEventArgs
				{
					gregorianSelectedDate = viewModel.SelectedGregorianDate
				};
				dateSelected(args);
			}
			else if (e.PropertyName == "SelectedHijriYear" || e.PropertyName == "SelectedHijriMonth" || e.PropertyName == "SelectedHijriDay")
			{
				var viewModel = ((FilterCalendarPageViewModel)BindingContext);
				var args = new FilterCalendarPageEventArgs
				{
					hijriSelectedYear = viewModel.SelectedHijriYear,
					hijriSelectedMonth = viewModel.SelectedHijriMonth,
					hijriSelectedDay = viewModel.SelectedHijriDay
				};
				dateSelected(args);
			}
		}


	}
}
