using ArabWaha.Core.DBAccess;
using ArabWaha.Core.Services;
using ArabWaha.Employee.BaseClasses;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArabWaha.Employee.ViewModels
{
    public class EventsDetailPageViewModel :  AWMVVMBase, INavigatedAware
    {
        public EventsDetailPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {
            IsBusy = false;

            // commands
            AcceptCommand = new DelegateCommand(ProcessAcceptCommand);
            DeclineCommand = new DelegateCommand(ProcessRejectCommand);

            // propose new date/time
            NewdateCommand = new DelegateCommand(ProcessNewdateCommand);

        }

        private EventDetails _eventData;
        public EventDetails EventData
        {
            get
            {
                return _eventData;
            }
            set
            {
                SetProperty<EventDetails>(ref _eventData, value);
            }
        }

        #region commands

        public DelegateCommand AcceptCommand { get; set; }
        public DelegateCommand DeclineCommand { get; set; }
        public DelegateCommand NewdateCommand { get; set; }

        private async void ProcessNewdateCommand()
        {
            await _dialog.DisplayAlertAsync("Info", "Will be implemented soon", "OK");    
        }

        private void ProcessAcceptCommand()
        {
           AcceptRejectEvent(true);
        }

        private void ProcessRejectCommand()
        {
            AcceptRejectEvent(false);
        }

        private async void AcceptRejectEvent(bool val)
        {
            ApiServiceIndividual api = new ApiServiceIndividual();
            await api.SetEventStatus(EventData.EventId, val);

            // go back to last page.. with details :) 
            NavigationParameters navP = new NavigationParameters();
            navP.Add("UpdateEvent", EventData.EventId);
            await _nav.GoBackAsync(navP);
        }

        #endregion

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
           
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            var data = parameters.Where(x => x.Key == "DETAILS").FirstOrDefault();
            if (data.Value != null)
            {
                EventData = data.Value as EventDetails;
            }
        }
    }
}
