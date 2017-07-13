using System;
using System.Collections.Generic;
using ArabWaha.Employer.Layouts;
using ArabWaha.Employer.Layouts.Filter;
using ArabWaha.Employer.StaticData;
using MapsPCL;
using Xamarin.Forms;


namespace ArabWaha.Employer.Layouts
{
	public class CalendarViewEventArgs : EventArgs
	{
		public DateTime gregorianSelectedDate { get; set; }
		public int hijriSelectedYear { get; set; }
		public int hijriSelectedMonth { get; set; }
		public int hijriSelectedDay { get; set; }
	}

	public delegate void CalendarViewEventDelegate(CalendarViewEventArgs _args);

	public partial class CalendarMonthView : ContentView
	{
		public event CalendarViewEventDelegate dateSelected;
		private readonly IList<string> hijriMonthsArabic = new List<string> { GlobalSetting.Muharram_month_arabic, GlobalSetting.Safar_month_arabic, GlobalSetting.Rabialawwal_month_arabic, GlobalSetting.Rabialthani_month_arabic, GlobalSetting.Jumadaalawwal_month_arabic, GlobalSetting.Jumadaalthani_month_arabic, GlobalSetting.Rajab_month_arabic, GlobalSetting.Shaaban_month_arabic, GlobalSetting.Ramadan_month_arabic, GlobalSetting.Shawwal_month_arabic, GlobalSetting.DhualQidah_month_arabic, GlobalSetting.DhualHijjah_month_arabic };
		private readonly IList<string> hijriWeekdaysArabic = new List<string> { GlobalSetting.Saturday_arabic, GlobalSetting.Sunday_arabic, GlobalSetting.Monday_arabic, GlobalSetting.Tuesday_arabic, GlobalSetting.Wednesday_arabic, GlobalSetting.Thursday_arabic, GlobalSetting.Friday_arabic };
		private bool fromFilterScreen { get; set; }
		private readonly int maxLabelsInView = 37;
		private DateTime gregorianDate { get; set; }
		private DateTime prevSelectedDate { get; set; }
		private IHijriEventArgs hijriDateArgs { get; set; }

		public CalendarMonthView(DateTime dt, DateTime previousSelectedDate, bool fromFilter = false, int hijriYear = 0, int hijriMonth = 0, int hijriDay = 0)
		{
			InitializeComponent();

			fromFilterScreen = fromFilter;
			prevSelectedDate = previousSelectedDate;

			if (GlobalSetting.IsArabic)
			{
				IHijriService hijri = DependencyService.Get<IHijriService>();
				hijri.dateObtained += (object sender, IHijriEventArgs e) =>
							{
								hijriDateArgs = e;
								SetHijriView(e);
							};
				hijri.ObtainHijriDate(dt);
			}
			else
			{
				gregorianDate = dt;
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
					//add gesture on each visible lable
					AddGestureToDaylabel(lblDay);
					//check & set bg shadow for current date
					if (e.currentDay.Equals(counter) && e.currentMonth.Equals(e.month) && e.currentYear.Equals(e.year))
					{
						SetBackgroundFrameForTodayOrSelectedDay(lblDay, lblDaySchedulerDot, Color.LightGray);
					}
					//check & set bg shadow for previous selected date
					//if (date.Equals(prevSelectedDate))
					//{
					//                   SetBackgroundFrameForTodayOrSelectedDay(lblDay, lblDaySchedulerDot, Color.LightGreen);
					//}

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
					//add gesture on each visible lable
					AddGestureToDaylabel(lblDay);
					var date = new DateTime(dt.Year, dt.Month, counter);

					//check & set bg shadow for current date
					if (date.Equals(currentDate))
					{
						SetBackgroundFrameForTodayOrSelectedDay(lblDay, lblDaySchedulerDot, Color.LightGray);
					}

					//check & set bg shadow for previous selected date
					if (date.Equals(prevSelectedDate))
					{
						SetBackgroundFrameForTodayOrSelectedDay(lblDay, lblDaySchedulerDot, Color.LightGreen);
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
			if (fromFilterScreen)
			{
				day.VerticalOptions = LayoutOptions.CenterAndExpand;
				day.VerticalTextAlignment = TextAlignment.Center;
			}
			//hide & show dots label if calendar showing from Filters Page & Sidebar calendar respectively
			dot.IsVisible = !fromFilterScreen;
		}

		private void SetBackgroundFrameForTodayOrSelectedDay(Label day, Label dot, Color bgColor)
		{
			var bgFrame = new Frame();

			bgFrame.CornerRadius = 15;
			bgFrame.HasShadow = false;
			bgFrame.BackgroundColor = bgColor;

			MonthGrid.Children.Add(bgFrame, 20, 0);
			Grid.SetRow(bgFrame, Grid.GetRow(day));
			Grid.SetColumn(bgFrame, Grid.GetColumn(day));

			MonthGrid.Children.Remove(day);
			MonthGrid.Children.Add(day);

			MonthGrid.Children.Remove(dot);
			MonthGrid.Children.Add(dot);
		}

		private void AddGestureToDaylabel(Label day)
		{
			var tapStartDate = new TapGestureRecognizer
			{
				NumberOfTapsRequired = 1
			};
			tapStartDate.Tapped += TapDay_Tapped;
			day.GestureRecognizers.Add(tapStartDate);
		}

		private void TapDay_Tapped(object sender, EventArgs e)
		{
			var lblDay = (Label)sender;
			var dayDate = Convert.ToInt16(lblDay.Text);
			if (fromFilterScreen)
			{
				HandleTapForFilterScreen(dayDate);
			}
			else
			{
				HandleTapForSidebarCalendarScreen(dayDate);
			}
		}

		private void HandleTapForFilterScreen(int dayDate)
		{
			var args = new CalendarViewEventArgs();
			if (GlobalSetting.IsArabic)
			{
				args.hijriSelectedYear = hijriDateArgs.year;
				args.hijriSelectedMonth = hijriDateArgs.month;
				args.hijriSelectedDay = dayDate;
			}
			else
			{
				args.gregorianSelectedDate = new DateTime(gregorianDate.Year, gregorianDate.Month, dayDate);
			}
			dateSelected(args);
		}

		private void HandleTapForSidebarCalendarScreen(int dayDate)
		{

		}

		#endregion
	}
}
