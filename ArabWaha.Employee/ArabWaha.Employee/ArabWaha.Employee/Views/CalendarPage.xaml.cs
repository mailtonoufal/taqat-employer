using ArabWaha.Employee.ViewModels;
using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;

namespace ArabWaha.Employee.Views
{
    public partial class CalendarPage : ContentPage
    {
        public CalendarPage()
        {
            InitializeComponent();
        }

        private void Schedule_MonthInlineAppointmentTapped(object sender, Syncfusion.SfSchedule.XForms.MonthInlineAppointmentTappedEventArgs args)
        {
            var appointment = args.Appointment;

            var t = "";
            // execute view model command here .. 
            (BindingContext as CalendarPageViewModel).AppointmentCommand.Execute(appointment as ScheduleAppointment);

        }
    }
}
