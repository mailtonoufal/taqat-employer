using ArabWaha.Core.ModelsEmployer;
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
    public class ApplicationDetailsPageViewModel : AWMVVMBase, INavigationAware
    {
        private ApplicationsForJob _applicationsForJob;
        public ApplicationsForJob JobApplications
        {
            get { return _applicationsForJob; }
            set { SetProperty(ref _applicationsForJob, value); }
        }

        public ApplicationDetailsPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {
            Title = TranslateExtension.GetString("LabelJobApplications");
        }

        private async void LoadData(int JobPostId)
        {
            ApiService api = new ApiService();
            JobApplications = await api.GetCompanyJobApplicationsByJobIdAsync(0, JobPostId);
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            var id = parameters["JobPostId"];
            LoadData(Convert.ToInt32(id));
        }
    }
}
