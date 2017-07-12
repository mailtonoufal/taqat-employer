using System;
using System.Collections.Generic;
using ArabWaha.Employer.StaticData;
using MapsPCL;
using Xamarin.Forms;

namespace ArabWaha.Employer.Layouts
{
	public partial class CalendarMonthView : ContentView
	{
		private readonly IList<string> hijriMonthsArabic = new List<string> { GlobalSetting.Muharram_month_arabic, GlobalSetting.Safar_month_arabic, GlobalSetting.Rabialawwal_month_arabic, GlobalSetting.Rabialthani_month_arabic, GlobalSetting.Jumadaalawwal_month_arabic, GlobalSetting.Jumadaalthani_month_arabic, GlobalSetting.Rajab_month_arabic, GlobalSetting.Shaaban_month_arabic, GlobalSetting.Ramadan_month_arabic, GlobalSetting.Shawwal_month_arabic, GlobalSetting.DhualQidah_month_arabic, GlobalSetting.DhualHijjah_month_arabic };
		private readonly IList<string> hijriWeekdaysArabic = new List<string> { GlobalSetting.Saturday_arabic, GlobalSetting.Sunday_arabic, GlobalSetting.Monday_arabic, GlobalSetting.Tuesday_arabic, GlobalSetting.Wednesday_arabic, GlobalSetting.Thursday_arabic, GlobalSetting.Friday_arabic };
		private bool hideSchedules { get; set; }
		private readonly int maxLabelsInView = 37;
		public CalendarMonthView(DateTime dt, bool fromFilter = false)
		{
			InitializeComponent();

			hideSchedules = fromFilter;

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
			FillHijriMonthDates(e, maxLabelsInView);
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

					//check & set bg shadow for current date
					if (e.currentDay.Equals(counter) && e.currentMonth.Equals(e.month) && e.currentYear.Equals(e.year))
					{
						SetBackgroundFrameForToday(lblDay, lblDaySchedulerDot);
					}

					ShowHideScheduleDotsIfPageFromFilter(lblDay, lblDaySchedulerDot);

				}
				else
				{
					HideBlankLabels(lblDay, lblDaySchedulerDot);
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
			FillGregorianMonthDates(dt, daysInMonth, monthStartWeekDay, maxLabelsInView);
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

					var date = new DateTime(dt.Year, dt.Month, counter);

					//check & set bg shadow for current date
					if (date.Equals(currentDate))
					{
						SetBackgroundFrameForToday(lblDay, lblDaySchedulerDot);
					}

					ShowHideScheduleDotsIfPageFromFilter(lblDay, lblDaySchedulerDot);
				}
				else
				{
					HideBlankLabels(lblDay, lblDaySchedulerDot);
				}
			}
		}
		#endregion

		#region commonFunctionsForGregorianHijri
		private void HideBlankLabels(Label day, Label dot)
		{
			day.IsVisible = false;
			dot.IsVisible = false;
		}

		private void ShowHideScheduleDotsIfPageFromFilter(Label day, Label dot)
		{
			//align day labels center if calendar showing from Filters Page
			if (hideSchedules)
			{
				day.VerticalOptions = LayoutOptions.CenterAndExpand;
				day.VerticalTextAlignment = TextAlignment.Center;
			}
			//hide & show dots label if calendar showing from Filters Page & Sidebar calendar respectively
			dot.IsVisible = !hideSchedules;
		}

		private void SetBackgroundFrameForToday(Label day, Label dot)
		{
			var bgFrame = new Frame();

			bgFrame.CornerRadius = 15;
			bgFrame.HasShadow = false;
			bgFrame.BackgroundColor = Color.LightGray;

			MonthGrid.Children.Add(bgFrame, 20, 0);
			Grid.SetRow(bgFrame, Grid.GetRow(day));
			Grid.SetColumn(bgFrame, Grid.GetColumn(day));

			MonthGrid.Children.Remove(day);
			MonthGrid.Children.Add(day);

			MonthGrid.Children.Remove(dot);
			MonthGrid.Children.Add(dot);
		}

		#endregion
	}
}
