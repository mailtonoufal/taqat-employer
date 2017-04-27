using ArabWaha.Core.BaseClasses;
using ArabWaha.Employer.BaseCalsses;
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
    // tmp
    public class JobType : MVVMBase
    {
        public string TypeofJob { get; set; }
        public string Description { get; set; }

        private bool _selected;
        public bool Selected
        {
            get { return _selected; }
            set { SetProperty(ref _selected, value); }
        }
    }

    public class JobNewPostPageViewModel : AWMVVMBase
    {

        public DelegateCommand NextStepCommand { get; set; }
        public DelegateCommand<JobType> ItemCheckedCommand { get; set; }

        public ObservableCollection<JobType> JobTypeList { get; set; }
        public JobNewPostPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {
            Title = "Create New Job Post";

            // Build a list of items as these will need to be in the CMS??
            SetData();

            ItemCheckedCommand = new DelegateCommand<JobType>(ItemChecked);
            NextStepCommand = new DelegateCommand(NextStep);
        }

        private void NextStep()
        {
            _nav.NavigateAsync(nameof(JobNewPostTypePage));
        }

        private void ItemChecked(JobType obj)
        {
            JobTypeList.Where(c => c.TypeofJob != obj.TypeofJob).Select(c => { c.Selected = false; return c; }).ToList();
        }

        private void SetData()
        {
            JobTypeList = new ObservableCollection<JobType>()
            {
                new JobType { TypeofJob="Permanent", Description="Long-Term Employmnet with unspecified end", Selected=true },
                new JobType { TypeofJob="Contract", Description="Temporary Employment on Pre-Agreed Terms", Selected=false },
                new JobType { TypeofJob="Mini Job", Description="Short-term Employment up to 6 months for students", Selected=false },
                new JobType { TypeofJob="Internship", Description="", Selected=false },
                new JobType { TypeofJob="Summer Job", Description="Temporary Employment during the summer", Selected=false },
                new JobType { TypeofJob="Tamheer", Description="On the job training", Selected=false },
                new JobType { TypeofJob="Employer Driven Academy", Description="", Selected=false },
            };

        }
    }
}
