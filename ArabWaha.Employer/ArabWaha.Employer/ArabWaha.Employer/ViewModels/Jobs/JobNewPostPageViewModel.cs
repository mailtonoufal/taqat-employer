using ArabWaha.Core.BaseClasses;
using ArabWaha.Employer.BaseCalsses;
using ArabWaha.Employer.StaticData;
using ArabWaha.Employer.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ArabWaha.Employer.ViewModels
{



    public class JobNewPostPageViewModel : AWMVVMBase
    {

        public DelegateCommand NextStepCommand { get; set; }
        public DelegateCommand<JobTypeEntry> ItemCheckedCommand { get; set; }

        public ObservableCollection<JobTypeEntry> JobTypeList { get; set; }
        public JobNewPostPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {
            // Build a list of items as these will need to be in the CMS??
            SetData();

            ItemCheckedCommand = new DelegateCommand<JobTypeEntry>(ItemChecked);
            NextStepCommand = new DelegateCommand(NextStep);
        }

        private async void NextStep()
        {
            // Need to pass the JobType in or Create a dummy record and save?
            //_nav.NavigateAsync(nameof(JobNewPostTypePage));
            NavigationParameters paramx = new NavigationParameters();
            paramx.Add("MODE", "NEW");
            await _nav.NavigateAsync(nameof(JobPage), paramx, false, true);
        }


        private void ItemChecked(JobTypeEntry obj)
        {
            JobTypeList.Where(c => c.Text != obj.Text).Select(c => { c.Selected = false; return c; }).ToList();
        }

        private void SetData()
        {
            JobTypeList = StaticEntryHelper.GetJobTypeEntries();
        }
    }
}
