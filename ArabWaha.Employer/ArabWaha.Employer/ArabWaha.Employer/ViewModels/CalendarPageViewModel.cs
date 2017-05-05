using ArabWaha.Core.DBAccess;
using ArabWaha.Core.Helpers;
using ArabWaha.Core.Services;
using ArabWaha.Employer.BaseCalsses;
using ArabWaha.Employer.Views.Detail;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Syncfusion.SfSchedule.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace ArabWaha.Employer.ViewModels
{
    public class CalendarPageViewModel : AWMVVMBase
    {
            public CalendarPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
            {
                IsBusy = false;

                // make sure we have a default item collection
                EventsCollection = new ScheduleAppointmentCollection();

                // test locale. 
                Locale = GlobalSetting.CultureCode;

                AppointmentCommand = new DelegateCommand<ScheduleAppointment>(ShowAppointment);

                LoadEventData();
            }

            private string _locale;
            public string Locale
            {
                get
                {
                    return _locale;
                }

                set
                {
                    SetProperty<string>(ref _locale, value);
                }
            }

            async void LoadEventData()
            {
                ApiService api = new ApiService();
                var eventsCollection = await api.GetEventsAsync();

                foreach (var item in eventsCollection)
                    AddToSchedule(item);
            }

            public void OnNavigatedFrom(NavigationParameters parameters)
            {
                // set selected item in the parameters
            }

            public async void OnNavigatedTo(NavigationParameters parameters)
            {
                // check for UpdateEvent with event id to update in calendar
                var data = parameters.Where(x => x.Key == "UpdateEvent").FirstOrDefault();
                if (data.Value != null)
                {
                    var eventid = data.Value.ToString();

                    var currentevent = EventsCollection.Where(x => x.Notes == eventid).FirstOrDefault();
                    if (currentevent == null) return;

                    ApiService api = new ApiService();
                    var singleEvent = await api.GetEventSingleAsync(eventid);
                    if (singleEvent == null) return;

                    currentevent.Subject = singleEvent.TitleInfo;

                }


            }

            public DelegateCommand<ScheduleAppointment> AppointmentCommand { get; set; }

            private async void ShowAppointment(ScheduleAppointment appointment)
            {
                ApiService api = new ApiService();
                var ev = await api.GetEventSingleAsync(appointment.Notes);

                // now process the event as parameter
                if (ev == null) return;

                NavigationParameters navP = new NavigationParameters();
                navP.Add("DETAILS", ev);
                await _nav.NavigateAsync(nameof(EventsDetailPage), navP);
            }


            #region datasource events
            // EventsCollection
            private ScheduleAppointmentCollection _eventsCollection;
            public ScheduleAppointmentCollection EventsCollection
            {
                get
                {
                    return _eventsCollection;
                }
                set
                {
                    SetProperty<ScheduleAppointmentCollection>(ref _eventsCollection, value);
                }
            }

            private void AddToSchedule(EventDetails newEvent)
            {
                // contruct from event
                EventsCollection.Add(new ScheduleAppointment
                {
                    Subject = newEvent.TitleInfo,
                    Location = newEvent.EventLocation,
                    StartTime = UtilHelper.GetDatefromSqlDate(newEvent.EventStart),
                    EndTime = UtilHelper.GetDatefromSqlDate(newEvent.EventEnd),
                    Color = Color.Red,
                    Notes = newEvent.EventId.ToString()
                });
            }

            #endregion

        }
    }
