using System;
using System.Collections.Generic;
using ArabWaha.Employer.StaticData;
using MapsPCL;
using Xamarin.Forms;

namespace ArabWaha.Employer.Layouts.Calendar
{
	public partial class CalendarMonthView : ContentView
	{
		private readonly IList<string> hijriMonthsArabic = new List<string> { GlobalSetting.Muharram_month_arabic, GlobalSetting.Safar_month_arabic, GlobalSetting.Rabialawwal_month_arabic, GlobalSetting.Rabialthani_month_arabic, GlobalSetting.Jumadaalawwal_month_arabic, GlobalSetting.Jumadaalthani_month_arabic, GlobalSetting.Rajab_month_arabic, GlobalSetting.Shaaban_month_arabic, GlobalSetting.Ramadan_month_arabic, GlobalSetting.Shawwal_month_arabic, GlobalSetting.DhualQidah_month_arabic, GlobalSetting.DhualHijjah_month_arabic };
		private readonly IList<string> hijriWeekdaysArabic = new List<string> { GlobalSetting.Saturday_arabic, GlobalSetting.Sunday_arabic, GlobalSetting.Monday_arabic, GlobalSetting.Tuesday_arabic, GlobalSetting.Wednesday_arabic, GlobalSetting.Thursday_arabic, GlobalSetting.Friday_arabic };

		public CalendarMonthView(DateTime dt)
		{
			InitializeComponent();

			if (GlobalSetting.IsArabic)
			{
				IHijriService hijri = DependencyService.Get<IHijriService>();
				hijri.dateObtained += (object sender, IHijriEventArgs e) =>
							{
								SetHijriView(e);
							};
				hijri.ObtainHijriDate(dt);
			}
			else
			{
				SetGregorianView(dt);
			}
		}

		#region HijriViewRegion
		private void SetHijriView(IHijriEventArgs e)
		{
			SetHijriMonthAndYearText(e);
			FillHijriMonthDates(e, 37);
		}

		public void SetHijriMonthAndYearText(IHijriEventArgs e)
		{
			lblMonthYear.Text = hijriMonthsArabic[e.month - 1] + " " + e.year.ToString();
		}

		public void FillHijriMonthDates(IHijriEventArgs e, int totalDaysInView)
		{
			var counter = 0;
			for (int day = 1; day <= totalDaysInView; day++)
			{
				var lblDay = this.FindByName<Label>("day" + day.ToString());
				var lblDaySchedulerDot = this.FindByName<Label>("dot" + day.ToString());
				if (day > e.monthStartWeekDay && counter < e.daysInMonth)
				{
					counter++;
					lblDay.Text = counter.ToString();
					lblDaySchedulerDot.IsVisible = true;

					//check & set bg shadow for current date
					if (e.currentDay.Equals(counter) && e.currentMonth.Equals(e.month) && e.currentYear.Equals(e.year))
					{
						var bgFrame = new Frame();

						bgFrame.CornerRadius = 15;
						bgFrame.HasShadow = false;
						bgFrame.BackgroundColor = Color.LightGray;

						MonthGrid.Children.Add(bgFrame, 20, 0);
						Grid.SetRow(bgFrame, Grid.GetRow(lblDay));
						Grid.SetColumn(bgFrame, Grid.GetColumn(lblDay));

						MonthGrid.Children.Remove(lblDay);
						MonthGrid.Children.Add(lblDay);

						MonthGrid.Children.Remove(lblDaySchedulerDot);
						MonthGrid.Children.Add(lblDaySchedulerDot);
					}

				}
				else
				{
					lblDay.Text = string.Empty;
					lblDaySchedulerDot.IsVisible = false;
				}
			}
		}

		#endregion

		#region GregorianViewRegion
		private void SetGregorianView(DateTime dt)
		{
			SetGregorianMonthAndYearText(dt);

			GetGregorianMonthDaysAndYear(dt);
		}

		public void SetGregorianMonthAndYearText(DateTime dt)
		{
			var cdt = dt.ToString("yyyy MMMMM dd");
			var arrCD = cdt.Split(' ');
			lblMonthYear.Text = arrCD[1] + " " + arrCD[0];
		}

		public void GetGregorianMonthDaysAndYear(DateTime dt)
		{
			var daysInMonth = DateTime.DaysInMonth(dt.Year, dt.Month);
			var firstDateOfMonth = new DateTime(dt.Year, dt.Month, 1);
			var monthStartWeekDay = (int)firstDateOfMonth.DayOfWeek;
			FillGregorianMonthDates(dt, daysInMonth, monthStartWeekDay, 37);
		}

		public void FillGregorianMonthDates(DateTime dt, int noOfDaysInMonth, int monthStartWeekDay, int totalDaysInView)
		{
			var currentDate = DateTime.Now.Date;
			var counter = 0;
			for (int day = 1; day <= totalDaysInView; day++)
			{
				var lblDay = this.FindByName<Label>("day" + day.ToString());
				var lblDaySchedulerDot = this.FindByName<Label>("dot" + day.ToString());
				if (day > monthStartWeekDay && counter < noOfDaysInMonth)
				{
					counter++;
					lblDay.Text = counter.ToString();
					lblDaySchedulerDot.IsVisible = true;
					var date = new DateTime(dt.Year, dt.Month, counter);

					//check & set bg shadow for current date
					if (date.Equals(currentDate))
					{
						var bgFrame = new Frame();

						bgFrame.CornerRadius = 15;
						bgFrame.HasShadow = false;
						bgFrame.BackgroundColor = Color.LightGray;

						MonthGrid.Children.Add(bgFrame, 20, 0);
						Grid.SetRow(bgFrame, Grid.GetRow(lblDay));
						Grid.SetColumn(bgFrame, Grid.GetColumn(lblDay));

						MonthGrid.Children.Remove(lblDay);
						MonthGrid.Children.Add(lblDay);

						MonthGrid.Children.Remove(lblDaySchedulerDot);
						MonthGrid.Children.Add(lblDaySchedulerDot);
					}

				}
				else
				{
					lblDay.Text = string.Empty;
					lblDaySchedulerDot.IsVisible = false;
				}
			}
		}
		#endregion
	}
}
