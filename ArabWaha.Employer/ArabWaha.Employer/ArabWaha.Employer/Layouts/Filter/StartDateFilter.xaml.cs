using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Rg.Plugins.Popup.Extensions;
using ArabWaha.Employer.Views;
using ArabWaha.Employer.StaticData;

namespace ArabWaha.Employer.Layouts.Filter
{
	public partial class StartDateFilter : ContentView
	{
		private DateTime currentDate { get; set; }
		private int currentHijriYear { get; set; }
		private int currentHijriMonth { get; set; }
		private int currentHijriDay { get; set; }
		public StartDateFilter()
		{
			InitializeComponent();

			var tapStartDate = new TapGestureRecognizer
			{
				NumberOfTapsRequired = 1
			};
			tapStartDate.Tapped += TapStartDate_Tapped;
			lblStartDate.GestureRecognizers.Add(tapStartDate);
		}

		void TapStartDate_Tapped(object sender, EventArgs e)
		{
			var calendar = new FilterCalendarPage(currentDate, currentHijriYear, currentHijriMonth, currentHijriDay);
			calendar.dateSelected += (FilterCalendarPageEventArgs _args) =>
			{
				if (GlobalSetting.IsArabic)
				{
					currentHijriYear = _args.hijriSelectedYear;
					currentHijriMonth = _args.hijriSelectedMonth;
					currentHijriDay = _args.hijriSelectedDay;
					lblStartDate.Text = currentHijriDay.ToString() + "-" + currentHijriMonth.ToString() + "-" + currentHijriYear.ToString();
				}
				else
				{
					currentDate = _args.gregorianSelectedDate;
					lblStartDate.Text = currentDate.ToString("d");
				}

				Navigation.PopPopupAsync();
			};
			Navigation.PushPopupAsync(calendar);
		}
	}
}
