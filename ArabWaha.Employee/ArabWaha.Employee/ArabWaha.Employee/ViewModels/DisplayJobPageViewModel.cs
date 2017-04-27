using ArabWaha.Core.ModelsEmployer.Jobs;
using ArabWaha.Core.Services;
using ArabWaha.Employee.BaseClasses;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ArabWaha.Employee.ViewModels
{
    public class DisplayJobPageViewModel : AWMVVMBase, INavigatedAware
    {
        public DisplayJobPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {
            IsBusy = false;

            // hook up the comands
            RemoveWatchlistCommand = new DelegateCommand(ProcessRemoveWatchlistCommand);
            AddWatchlistCommand = new DelegateCommand(ProcessAddWatchlistCommand);
            ApplyJobCommand = new DelegateCommand(ProcessApplyJobCommand);
        }

        #region commands

        public DelegateCommand RemoveWatchlistCommand { get; set; }
        private async void ProcessRemoveWatchlistCommand()
        {
            // remove based on job id
            ApiServiceIndividual api = new ApiServiceIndividual();
            await api.DeleteWatchListJobasync(JobDetails.JobPostId);

            await _dialog.DisplayAlertAsync("Watch Info", "Removed From watch List", "OK");

            // just return here and update watch list??
            NavigationParameters navP = new NavigationParameters();
            navP.Add("JOBWATCHREMOVE", JobDetails.JobPostId);
            await _nav.GoBackAsync(navP);

        }
        public DelegateCommand AddWatchlistCommand { get; set; }
        private async void ProcessAddWatchlistCommand()
        {
            // add a new watch list item
            ApiServiceIndividual api = new ApiServiceIndividual();
            await api.AddWatchListJobasync(JobDetails.JobPostId);

            await _dialog.DisplayAlertAsync("Watch Info", "Added to watch List", "OK");

            NavigationParameters navP = new NavigationParameters();
            navP.Add("JOBWATCHADD", JobDetails.JobPostId);
            await _nav.GoBackAsync(navP);
        }
        public DelegateCommand ApplyJobCommand { get; set; }
        private async void ProcessApplyJobCommand()
        {
            NavigationParameters navP = new NavigationParameters();
            navP.Add("JOBAPPLY", JobDetails.JobPostId);
            await _nav.GoBackAsync(navP);
        }

        #endregion

        private EmployerJobDetail _jobDetails;

        public EmployerJobDetail JobDetails
        {
            get { return _jobDetails; }
            set { SetProperty<EmployerJobDetail>(ref _jobDetails, value); }
        }

        public ObservableCollection<JobDetailLanguage> JobLanguages
        {
            get
            {
                if(JobDetails==null || JobDetails.JobLanguages==null)
                {
                    return new ObservableCollection<JobDetailLanguage>();
                }
                return JobDetails.JobLanguages;

            }
        }

        public ObservableCollection<JobDetailLicenses> JobLicenses
        {
            get
            {
                if (JobDetails == null || JobDetails.JobLicenses == null)
                {
                    return new ObservableCollection<JobDetailLicenses>();
                }

                return JobDetails.JobLicenses;
            }
        }

        public ObservableCollection<EmployerJobDetailTraining> JobTraining
        {
            get
            {
                if (JobDetails == null || JobDetails.JobTraining == null)
                {
                    return new ObservableCollection<EmployerJobDetailTraining>();
                }


                return JobDetails.JobTraining ;
            }
        }


        #region visible buttons props

        private bool _isRemoveWatchlistVisible;
        public bool IsRemoveWatchlistVisible
        {
            get { return _isRemoveWatchlistVisible; }
            set { SetProperty<bool> (ref _isRemoveWatchlistVisible , value); }
        }

        private bool _isAddWatchlistVisible;
        public bool IsAddWatchlistVisible
        {
            get { return _isAddWatchlistVisible; }
            set { SetProperty<bool>(ref _isAddWatchlistVisible, value); }
        }

        private bool _isApplyJobVisible;
        public bool IsApplyJobVisible
        {
            get { return _isApplyJobVisible; }
            set { SetProperty<bool>(ref _isApplyJobVisible, value); }
        }


        #endregion
        public void OnNavigatedFrom(NavigationParameters parameters)
        {
           // throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            IsAddWatchlistVisible = false;
            IsApplyJobVisible = false;
            IsRemoveWatchlistVisible = false;

            // setup job here :) 
            var data = parameters.Where(x => x.Key == "DETAILS").FirstOrDefault();
            if (data.Value != null)
            {
                // set object up here 
                JobDetails = data.Value as EmployerJobDetail;

                RaisePropertyChanged("JobLanguages");
                RaisePropertyChanged("JobTraining");
                RaisePropertyChanged("JobLicenses");


                // pull the mode here so we can add a 'add to watch list or not' and also an 'apply for job'
                var mode = parameters.Where(x => x.Key == "MODE").FirstOrDefault(); 
                if( mode.Value !=null && !string.IsNullOrEmpty(mode.Value.ToString()))
                {
                    // show buttons or not here // default is no show
                    var modeVal = mode.Value.ToString();
                    // modes -> VIEWONLY, VIEWMATCHED, VIEWWATCHED
                    // validate mode here 


                    // viewonly -> do nothing
                    // viewmatched -> allow to add to watch list or apply for job
                    // viewwatched -> allow to remove from watch list

                    switch(modeVal)
                    {
                        case "VIEWONLY":
                            break;

                        default:

                            // show remove from watched button
                            ApiServiceIndividual api = new ApiServiceIndividual();

                            var jb = api.GetJobInfo(JobDetails.JobPostId);

                            IsAddWatchlistVisible = !jb.IsWatched;
                            IsApplyJobVisible = !jb.IsAppliedForJob;
                            IsRemoveWatchlistVisible = jb.IsWatched;
                            break;
                    }

                }
            }
        }
    }
}
