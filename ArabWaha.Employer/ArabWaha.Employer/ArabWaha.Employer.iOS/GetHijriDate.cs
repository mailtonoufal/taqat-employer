using System;
using ArabWaha.Employer.iOS;
using MapsPCL;
using Xamarin.Forms;
using System.Globalization;

[assembly: Dependency(typeof(GetHijriDate))]
namespace ArabWaha.Employer.iOS
{
	public class HijriEventArgs : EventArgs, IHijriEventArgs
	{
		public int year { get; set; }
		public int month { get; set; }
		public int dayOfMonth { get; set; }
		public int daysInMonth { get; set; }
		public int monthStartWeekDay { get; set; }
		public int currentYear { get; set; }
		public int currentMonth { get; set; }
		public int currentDay { get; set; }
	}

	public class GetHijriDate : IHijriService
	{
		public event EventHandler<IHijriEventArgs> dateObtained;

		public void ObtainHijriDate(DateTime dt)
		{
			var hcal = new HijriCalendar();
			HijriEventArgs args = new HijriEventArgs();
			args.year = hcal.GetYear(dt);
			args.month = hcal.GetMonth(dt);
			args.daysInMonth = hcal.GetDaysInMonth(args.year, args.month);
			args.dayOfMonth = hcal.GetDayOfMonth(dt);

			//start date of same month in hijri
			var sdt = dt.AddDays(-args.dayOfMonth + 1);
			args.monthStartWeekDay = (int)hcal.GetDayOfWeek(sdt);

			//set hijri current year, month, & day
			args.currentYear = hcal.GetYear(DateTime.Now);
			args.currentMonth = hcal.GetMonth(DateTime.Now);
			args.currentDay = hcal.GetDayOfMonth(DateTime.Now);

			dateObtained(this, args);
		}
	}
}
