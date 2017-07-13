using System;
using ArabWaha.Employer.BaseCalsses;
using ArabWaha.Employer.Layouts;
using ArabWaha.Employer.StaticData;
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

		private DateTime _MonthViewCurrentGregorianDate;

		public DateTime MonthViewCurrentGregorianDate
		{
			get
			{
				return _MonthViewCurrentGregorianDate;
			}
			set
			{
				if (value != DateTime.MinValue)
				{
					SetProperty<DateTime>(ref _MonthViewCurrentGregorianDate, value);

					MonthViewDate = value;
					SetContentView();
				}
				else
				{
					MonthViewDate = DateTime.Now;
					SetContentView();
				}
			}
		}

		private DateTime _selectedGregorianDate;
		public DateTime SelectedGregorianDate
		{
			get { return _selectedGregorianDate; }
			set { SetProperty(ref _selectedGregorianDate, value); }
		}

		private int _currentHijriYear;
		public int CurrentHijriYear
		{
			get { return _currentHijriYear; }
			set { SetProperty(ref _currentHijriYear, value); }
		}

		private int _currentHijriMonth;
		public int CurrentHijriMonth
		{
			get { return _currentHijriMonth; }
			set { SetProperty(ref _currentHijriMonth, value); }
		}

		private int _currentHijriDay;
		public int CurrentHijriDay
		{
			get { return _currentHijriDay; }
			set
			{

				if (value > 0)
				{
					SetProperty(ref _currentHijriDay, value);

					MonthViewDate = new DateTime(CurrentHijriYear, CurrentHijriMonth, CurrentHijriDay);

					SetContentView();
				}
				else
				{
					MonthViewDate = DateTime.Now;
					SetContentView();
				}
			}
		}

		private int _selectedHijriYear;
		public int SelectedHijriYear
		{
			get { return _selectedHijriYear; }
			set { SetProperty(ref _selectedHijriYear, value); }
		}

		private int _selectedHijriMonth;
		public int SelectedHijriMonth
		{
			get { return _selectedHijriMonth; }
			set { SetProperty(ref _selectedHijriMonth, value); }
		}

		private int _selectedHijriDay;
		public int SelectedHijriDay
		{
			get { return _selectedHijriDay; }
			set { SetProperty(ref _selectedHijriDay, value); }
		}

		public DelegateCommand OnPrevCommand { get; set; }
		public DelegateCommand OnNextCommand { get; set; }

		private void SetPreviousMonth()
		{
			MonthViewDate = MonthViewDate.AddMonths(-1);
			SetContentView();
		}

		private void SetNextMonth()
		{
			MonthViewDate = MonthViewDate.AddMonths(1);
			SetContentView();
		}

		private void SetContentView()
		{
			var calendar = new CalendarMonthView(MonthViewDate, MonthViewCurrentGregorianDate, true);
			HandleDateSelectedEvent(calendar);
			MonthView = calendar;
		}

		private void HandleDateSelectedEvent(CalendarMonthView calendar)
		{
			calendar.dateSelected += (CalendarViewEventArgs _args) =>
			{
				if (GlobalSetting.IsArabic)
				{
					SelectedHijriYear = _args.hijriSelectedYear;
					SelectedHijriMonth = _args.hijriSelectedMonth;
					SelectedHijriDay = _args.hijriSelectedDay;
				}
				else
				{
					SelectedGregorianDate = _args.gregorianSelectedDate;
				}
			};
		}

	}
}
