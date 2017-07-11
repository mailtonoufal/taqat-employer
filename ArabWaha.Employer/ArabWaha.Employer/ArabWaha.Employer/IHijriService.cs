using System;
namespace MapsPCL
{
	public interface IHijriService
	{
		void ObtainHijriDate(DateTime dt);
		event EventHandler<IHijriEventArgs> dateObtained;
	}
	public interface IHijriEventArgs
	{
		int year { get; set; }
		int month { get; set; }
		int dayOfMonth { get; set; }
		int daysInMonth { get; set; }
		int monthStartWeekDay { get; set; }
		int currentYear { get; set; }
		int currentMonth { get; set; }
		int currentDay { get; set; }
	}
}