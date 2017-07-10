using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ArabWaha.Employer.Layouts.Calendar
{
	public partial class CalendarMonthView : ContentView
	{


		public CalendarMonthView(DateTime dt)
		{
			try
			{
				InitializeComponent();
			}
			catch (Exception ex)
			{

			}
			lblPrevious.Text = "<";
			lblNext.Text = ">";

			SetMonthAndYearText(dt);

			GetMonthDaysAndYear(dt);
		}



		public void SetMonthAndYearText(DateTime dt)
		{
			var cdt = dt.ToString("yyyy MMMMM dd");
			var arrCD = cdt.Split(' ');
			lblMonthYear.Text = arrCD[1] + " " + arrCD[0];
		}

		public void GetMonthDaysAndYear(DateTime dt)
		{
			var daysInMonth = DateTime.DaysInMonth(dt.Year, dt.Month);
			var firstDateOfMonth = new DateTime(dt.Year, dt.Month, 1);
			var monthStartWeekDay = (int)firstDateOfMonth.DayOfWeek;
			FillMonthDates(dt, daysInMonth, monthStartWeekDay, 37);
		}

		public void FillMonthDates(DateTime dt, int noOfDaysInMonth, int monthStartWeekDay, int totalDaysInView)
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
	}
}
