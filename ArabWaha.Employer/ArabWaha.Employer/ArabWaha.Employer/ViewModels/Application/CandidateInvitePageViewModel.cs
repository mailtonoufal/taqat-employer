using ArabWaha.Core.ModelsEmployer;
using ArabWaha.Core.ModelsEmployer.Jobs;
using ArabWaha.Core.Services;
using ArabWaha.Employer.BaseCalsses;
using ArabWaha.Employer.Helpers;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArabWaha.Employer.ViewModels
{
    public class CandidateInvitePageViewModel : AWMVVMBase, INavigationAware
    {

        private ApplicationProfile _candidate;
        public ApplicationProfile Candidate
        {
            get { return _candidate; }
            set { SetProperty(ref _candidate, value); }
        }

        private EmployerJobDetail _jobDetails;
        public EmployerJobDetail JobDetails
        {
            get { return _jobDetails; }
            set { SetProperty(ref _jobDetails, value); }
        }

        public DelegateCommand SendInviteCommand { get; set; }

        public CandidateInvitePageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {
            Title = TranslateExtension.GetString("LabelCandidateInviteTitle");
            SendInviteCommand = new DelegateCommand(ProcessSendInviteCommand);
        }

        private async void ProcessSendInviteCommand()
        {
            // ********** TODO **********
            // Call API to send Invite
            TranslateExtension trn = new TranslateExtension();
            var title = trn.GetProviderValueString("CanadidateSendInvite");
            var msg = trn.GetProviderValueString("CandidateSendInviteMessage");
            var btn = trn.GetProviderValueString("ButtonOk");
            await _dialog.DisplayAlertAsync(title, msg, btn);
            await _nav.GoBackAsync();
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }


        public async void OnNavigatingTo(NavigationParameters parameters)
        {
            // JobPostId should be passed in and Candidate ProfileId
            var jobId = parameters["JobPostId"];
            var profId = parameters["ProfileId"];

            ApiService api = new ApiService();

            Candidate = await api.GetApplicationProfileAsync(profId.ToString());
            JobDetails = await api.GetEmployerPostedJobsSingleAsync(jobId.ToString());

        }
    }
}
