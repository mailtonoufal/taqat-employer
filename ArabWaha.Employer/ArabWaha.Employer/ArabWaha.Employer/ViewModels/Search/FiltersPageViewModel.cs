using ArabWaha.Employer.BaseCalsses;
using ArabWaha.Employer.StaticData;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ArabWaha.Employer.ViewModels
{
    public class FiltersPageViewModel : AWMVVMBase, INavigationAware
    {
        public DelegateCommand CancelCommand { get; set; }
        public DelegateCommand ApplyCommand { get; set; }

        public DelegateCommand<SortByEntry> SortByCheckedCommand { get; set;  }
        public DelegateCommand<JobTypeEntry> JobTypeCheckedCommand { get; set; }
        public DelegateCommand<WorkTypeEntry> WorkTypeCheckedCommand { get; set; }
        public DelegateCommand<ShiftTypeEntry> ShiftTypeCheckedCommand { get; set; }
        public DelegateCommand<TravellingRequiredEntry> TravellingRequiredCheckedCommand { get; set; }
        public DelegateCommand<TeleWorkingEntry> TeleWorkingCheckedCommand { get; set; }
        public DelegateCommand<RequiredEducationEntry> RequiredEducationCheckedCommand { get; set; }
        public DelegateCommand<SpecializationEntry> SpecializationCheckedCommand { get; set; }
        public DelegateCommand<GenderEntry> GenderCheckedCommand { get; set; }
        public DelegateCommand<PostedSinceEntry> PostedSinceCheckedCommand { get; set; }

        public DelegateCommand<EntryBase> LabelCheckedCommand { get; set; }

        private ObservableCollection<SortByEntry> _sortByList;
        public ObservableCollection<SortByEntry> SortByList
        {
            get { return _sortByList; }
            set { SetProperty(ref _sortByList, value); }
        }


        private ObservableCollection<JobTypeEntry> _jobTypeList;
        public ObservableCollection<JobTypeEntry> JobTypeList
        {
            get { return _jobTypeList; }
            set { SetProperty(ref _jobTypeList, value); }
        }


        private ObservableCollection<WorkTypeEntry> _workTypeList;
        public ObservableCollection<WorkTypeEntry> WorkTypeList
        {
            get { return _workTypeList; }
            set { SetProperty(ref _workTypeList, value); }
        }

        private ObservableCollection<ShiftTypeEntry> _shiftTypeList;
        public ObservableCollection<ShiftTypeEntry> ShiftTypeList
        {
            get { return _shiftTypeList; }
            set { SetProperty(ref _shiftTypeList, value); }
        }

        private ObservableCollection<TravellingRequiredEntry> _travellingRequiredList;
        public ObservableCollection<TravellingRequiredEntry> TravellingRequiredList
        {
            get { return _travellingRequiredList; }
            set { SetProperty(ref _travellingRequiredList, value); }
        }

        private ObservableCollection<TeleWorkingEntry> _teleWorkingList;
        public ObservableCollection<TeleWorkingEntry> TeleWorkingList
        {
            get { return _teleWorkingList; }
            set { SetProperty(ref _teleWorkingList, value); }
        }

        private ObservableCollection<RequiredEducationEntry> _requiredEducationList;
        public ObservableCollection<RequiredEducationEntry> RequiredEducationList
        {
            get { return _requiredEducationList; }
            set { SetProperty(ref _requiredEducationList, value); }
        }

        private ObservableCollection<SpecializationEntry> _specializationList;
        public ObservableCollection<SpecializationEntry> SpecializationList
        {
            get { return _specializationList; }
            set { SetProperty(ref _specializationList, value); }
        }

        private ObservableCollection<GenderEntry> _genderList;
        public ObservableCollection<GenderEntry> GenderList
        {
            get { return _genderList; }
            set { SetProperty(ref _genderList, value); }
        }

        private ObservableCollection<PostedSinceEntry> _postedSinceList;
        public ObservableCollection<PostedSinceEntry> PostedSinceList
        {
            get { return _postedSinceList; }
            set { SetProperty(ref _postedSinceList, value); }
        }



        public FiltersPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {
            CancelCommand = new DelegateCommand(ProcessCancelCommand);
            ApplyCommand = new DelegateCommand(ProcessApplyCommand);

            SortByCheckedCommand = new DelegateCommand<SortByEntry>(ProcessSortByCheckedCommand);
            JobTypeCheckedCommand = new DelegateCommand<JobTypeEntry>(ProcessJobTypeCheckedCommand);
            WorkTypeCheckedCommand = new DelegateCommand<WorkTypeEntry>(ProcessWorkTypeCheckedCommand);
            ShiftTypeCheckedCommand = new DelegateCommand<ShiftTypeEntry>(ProcessShiftTypeCheckedCommand);
            TravellingRequiredCheckedCommand = new DelegateCommand<TravellingRequiredEntry>(ProcessTravellingRequiredCheckedCommand);
            TeleWorkingCheckedCommand = new DelegateCommand<TeleWorkingEntry>(ProcessTeleWorkingCheckedCommand);
            RequiredEducationCheckedCommand = new DelegateCommand<RequiredEducationEntry>(ProcessRequiredEducationCheckedCommand);
            SpecializationCheckedCommand = new DelegateCommand<SpecializationEntry>(ProcessSpecializationCheckedCommand);
            GenderCheckedCommand = new DelegateCommand<GenderEntry>(ProcessGenderCheckedCommand);
            PostedSinceCheckedCommand = new DelegateCommand<PostedSinceEntry>(ProcessPostedSinceCheckedCommand);


            LabelCheckedCommand = new DelegateCommand<EntryBase>(ProcessLabelCheckedCommand);
            LoadData();
        }

        private void ProcessPostedSinceCheckedCommand(PostedSinceEntry obj)
        {
        }

        private void ProcessGenderCheckedCommand(GenderEntry obj)
        {
        }

        private void ProcessSpecializationCheckedCommand(SpecializationEntry obj)
        {
        }

        private void ProcessRequiredEducationCheckedCommand(RequiredEducationEntry obj)
        {
        }

        private void ProcessTeleWorkingCheckedCommand(TeleWorkingEntry obj)
        {
        }

        private void ProcessShiftTypeCheckedCommand(ShiftTypeEntry obj)
        {
        }

        private void ProcessTravellingRequiredCheckedCommand(TravellingRequiredEntry obj)
        {
        }

        private void ProcessWorkTypeCheckedCommand(WorkTypeEntry obj)
        {
        }

        private void ProcessLabelCheckedCommand(EntryBase obj)
        {
            // lable clicks just negate current
            obj.Selected = !obj.Selected;
        }

        private void ProcessJobTypeCheckedCommand(JobTypeEntry obj)
        {
        }

        private void ProcessSortByCheckedCommand(SortByEntry obj)
        {
            var x = 0;
        }

        

        private void ProcessApplyCommand()
        {
			//Words.Where(w => w.Contains(":"));
			StringBuilder searchFilter = new StringBuilder();
			string filterJoin = string.Empty;

            var selectedGenderList = new ObservableCollection<GenderEntry>(_genderList.Where(w => w.Selected));
            var selectedSortByList = new ObservableCollection<SortByEntry>(_sortByList.Where(w => w.Selected));
            var selectedJobTypeList = new ObservableCollection<JobTypeEntry>(_jobTypeList.Where(w => w.Selected));
            var selectedWorkTypeList = new ObservableCollection<WorkTypeEntry>(_workTypeList.Where(w => w.Selected));
            var selectedShiftTypeList = new ObservableCollection<ShiftTypeEntry>(_shiftTypeList.Where(w => w.Selected));
            var selectedTeleWorkingList = new ObservableCollection<TeleWorkingEntry>(_teleWorkingList.Where(w => w.Selected));
            var selectedRequiredEducationList = new ObservableCollection<RequiredEducationEntry>(_requiredEducationList.Where(w => w.Selected));
			var selectedTravellingRequiredList = new ObservableCollection<TravellingRequiredEntry>(_travellingRequiredList.Where(w => w.Selected));
            var selectedSpecializationList = new ObservableCollection<SpecializationEntry>(_specializationList.Where(w => w.Selected));
            var selectedPostedSinceList = new ObservableCollection<PostedSinceEntry>(_postedSinceList.Where(w => w.Selected));

            if (selectedJobTypeList ==null || selectedJobTypeList.Count<1)
            {
				filterJoin = String.Format("JobType eq * and ");
				searchFilter.Append(filterJoin);
            }
            else
            {
                foreach (JobTypeEntry jobType in selectedJobTypeList)
                {
                    filterJoin = String.Format("JobType eq '{0}' and ", jobType.JobType.ToString());
					searchFilter.Append(filterJoin);
                }
            }
            if (selectedGenderList != null && selectedGenderList.Count>0)
            {
                foreach (GenderEntry gender in selectedGenderList)
				{
                    filterJoin = String.Format("Gender eq '{0}' and ", gender.Gender.ToString());
					searchFilter.Append(filterJoin);
				}
            }
            if (selectedSortByList != null && selectedSortByList.Count > 0)
			{
                foreach (SortByEntry sortBy in selectedSortByList)
				{
					filterJoin = String.Format("SortBy eq '{0}' and ", sortBy.SortBy.ToString());
					searchFilter.Append(filterJoin);
				}
			}
			if (selectedWorkTypeList != null && selectedWorkTypeList.Count > 0)
			{
                foreach (WorkTypeEntry workType in selectedWorkTypeList)
				{
                    filterJoin = String.Format("WorkTime eq '{0}' and ", workType.WorkType.ToString());
					searchFilter.Append(filterJoin);
				}
			}
            if (selectedShiftTypeList != null && selectedShiftTypeList.Count > 0)
			{
                foreach (ShiftTypeEntry shiftType in selectedShiftTypeList)
				{
                    filterJoin = String.Format("ShiftType eq '{0}' and ", shiftType.ShiftType.ToString());
					searchFilter.Append(filterJoin);
				}
			}
            if (selectedRequiredEducationList != null && selectedRequiredEducationList.Count > 0)
			{
                foreach (RequiredEducationEntry requiredEducation in selectedRequiredEducationList)
				{
                    filterJoin = String.Format("RequiredEducation eq '{0}' and ", requiredEducation.RequiredEducation.ToString());
					searchFilter.Append(filterJoin);
				}
			}
            if (selectedTravellingRequiredList != null && selectedTravellingRequiredList.Count > 0)
			{
                foreach (TravellingRequiredEntry travellingRequired in selectedTravellingRequiredList)
				{
                    filterJoin = String.Format("TravellingRequired eq '{0}' and ", travellingRequired.TravellingRequired.ToString());
					searchFilter.Append(filterJoin);
				}
			}
            if (selectedTeleWorkingList != null && selectedTeleWorkingList.Count > 0)
			{
                foreach (TeleWorkingEntry teleWorking in selectedTeleWorkingList)
				{
                    filterJoin = String.Format("TeleWorking eq '{0}' and ", teleWorking.TeleWorking.ToString());
					searchFilter.Append(filterJoin);
				}
			}
            if (selectedSpecializationList != null && selectedSpecializationList.Count > 0)
			{
                foreach (SpecializationEntry specialization in selectedSpecializationList)
				{
                    filterJoin = String.Format("Specialization eq '{0}' and ", specialization.Specialization.ToString());
					searchFilter.Append(filterJoin);
				}
			}
            if (selectedPostedSinceList != null && selectedPostedSinceList.Count > 0)
			{
                foreach (PostedSinceEntry postedSince in selectedPostedSinceList)
				{
                    filterJoin = String.Format("PostedSince eq '{0}' and ", postedSince.Id.ToString());
					searchFilter.Append(filterJoin);
				}
			}
			if (searchFilter.Length > 0)
			searchFilter.Remove(searchFilter.Length - 4, 4);
            GlobalSetting.FilterQuery = searchFilter.ToString();
			// need to set/store all the options and pass them back to the search page
			_nav.GoBackAsync();

        }

        private void ProcessCancelCommand()
        {
            _nav.GoBackAsync();
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
        }
        private void LoadData()
        {
            SortByList = StaticEntryHelper.GetSortByEntries();
            JobTypeList = StaticEntryHelper.GetJobTypeEntries();
            WorkTypeList = StaticEntryHelper.GetWorkTypeEntries();
            ShiftTypeList = StaticEntryHelper.GetShiftTypeEntries();
            TravellingRequiredList = StaticEntryHelper.GetTravellingRequiredEntries();
            TeleWorkingList = StaticEntryHelper.GetTeleWorkingEntries();
            RequiredEducationList = StaticEntryHelper.GetRequiredEducationEntries();
            SpecializationList = StaticEntryHelper.GetSpecializationEntries();
            GenderList = StaticEntryHelper.GetGenderEntries();
            PostedSinceList = StaticEntryHelper.GetPostedSinceEntries();
                
        }
    }
}
