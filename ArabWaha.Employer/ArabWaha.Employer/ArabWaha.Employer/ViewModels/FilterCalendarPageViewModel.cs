using System;
using ArabWaha.Employer.BaseCalsses;
using ArabWaha.Employer.Layouts;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

namespace ArabWaha.Employer.ViewModels
{
	public class FilterCalendarPageViewModel : AWMVVMBase
	{
		public FilterCalendarPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
		{
			MonthViewDate = DateTime.Now;
			MonthView = new CalendarMonthView(MonthViewDate, true);

			OnPrevCommand = new DelegateCommand(SetPreviousMonth);
			OnNextCommand = new DelegateCommand(SetNextMonth);
		}

		private ContentView _MonthView;

		public ContentView MonthView
		{
			get
			{
				return _MonthView;
			}
			set
			{
				if (value != null)
					SetProperty<ContentView>(ref _MonthView, value);
			}
		}

		private DateTime _MonthViewDate;

		public DateTime MonthViewDate
		{
			get
			{
				return _MonthViewDate;
			}
			set
			{
				if (value != null)
					SetProperty<DateTime>(ref _MonthViewDate, value);
			}
		}

		public DelegateCommand OnPrevCommand { get; set; }
		public DelegateCommand OnNextCommand { get; set; }

		private void SetPreviousMonth()
		{
			MonthViewDate = MonthViewDate.AddMonths(-1);
			MonthView = new CalendarMonthView(MonthViewDate, true);
		}

		private void SetNextMonth()
		{
			MonthViewDate = MonthViewDate.AddMonths(1);
			MonthView = new CalendarMonthView(MonthViewDate, true);
		}

	}
}
