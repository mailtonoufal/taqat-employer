using ArabWaha.Core.ModelsEmployer;
using ArabWaha.Core.Services;
using ArabWaha.Employer.BaseCalsses;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArabWaha.Employer.ViewModels
{
    public class ApplicationDetailsPageViewModel : AWMVVMBase
    {
        private ApplicationsForJob _applicationsForJob;
        public ApplicationsForJob JobApplications
        {
            get { return _applicationsForJob; }
            set { SetProperty(ref _applicationsForJob, value); }
        }

        public ApplicationDetailsPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {
            Title = "Job Application";
            GetData();
        }

        private async void GetData()
        {
            ApiService api = new ApiService();
            JobApplications = await api.GetCompanyJobApplicationsByJobIdAsync(0, 1);
        }
    }
}
