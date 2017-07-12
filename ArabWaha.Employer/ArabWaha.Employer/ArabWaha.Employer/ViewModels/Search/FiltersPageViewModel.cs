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
        public DelegateCommand RangeSliderChangedCommand { get; set; }
        public DelegateCommand<SortByEntryCMS> SortByCheckedCommand { get; set;  }
        public DelegateCommand<SortByEntryCMS> JobTypeCheckedCommand { get; set; }
        public DelegateCommand<SortByEntryCMS> WorkTypeCheckedCommand { get; set; }
        public DelegateCommand<SortByEntryCMS> ShiftTypeCheckedCommand { get; set; }
        public DelegateCommand<SortByEntryCMS> TravellingRequiredCheckedCommand { get; set; }
        public DelegateCommand<SortByEntryCMS> TeleWorkingCheckedCommand { get; set; }
        public DelegateCommand<SortByEntryCMS> RequiredEducationCheckedCommand { get; set; }
        public DelegateCommand<SortByEntryCMS> SpecializationCheckedCommand { get; set; }
        public DelegateCommand<SortByEntryCMS> GenderCheckedCommand { get; set; }
        public DelegateCommand<SortByEntryCMS> PostedSinceCheckedCommand { get; set; }

        public DelegateCommand<EntryBase> LabelCheckedCommand { get; set; }

        private ObservableCollection<SortByEntryCMS> _sortByList;
        public ObservableCollection<SortByEntryCMS> SortByList
        {
            get { return _sortByList; }
            set { SetProperty(ref _sortByList, value); }
        }
        private ObservableCollection<SortByEntryCMS> _jobTypeList;
        public ObservableCollection<SortByEntryCMS> JobTypeList
        {
            get { return _jobTypeList; }
            set { SetProperty(ref _jobTypeList, value); }
        }


        private ObservableCollection<SortByEntryCMS> _workTypeList;
        public ObservableCollection<SortByEntryCMS> WorkTypeList
        {
            get { return _workTypeList; }
            set { SetProperty(ref _workTypeList, value); }
        }

        private ObservableCollection<SortByEntryCMS> _shiftTypeList;
        public ObservableCollection<SortByEntryCMS> ShiftTypeList
        {
            get { return _shiftTypeList; }
            set { SetProperty(ref _shiftTypeList, value); }
        }

        private ObservableCollection<SortByEntryCMS> _travellingRequiredList;
        public ObservableCollection<SortByEntryCMS> TravellingRequiredList
        {
            get { return _travellingRequiredList; }
            set { SetProperty(ref _travellingRequiredList, value); }
        }

        private ObservableCollection<SortByEntryCMS> _teleWorkingList;
        public ObservableCollection<SortByEntryCMS> TeleWorkingList
        {
            get { return _teleWorkingList; }
            set { SetProperty(ref _teleWorkingList, value); }
        }

        private ObservableCollection<SortByEntryCMS> _requiredEducationList;
        public ObservableCollection<SortByEntryCMS> RequiredEducationList
        {
            get { return _requiredEducationList; }
            set { SetProperty(ref _requiredEducationList, value); }
        }

        private double _SalaryMin;
        public double SalaryMin
		{
			get { return _SalaryMin; }
			set { SetProperty(ref _SalaryMin, value); }
		}

		private double _SalaryMax;
		public double SalaryMax
		{
			get { return _SalaryMax; }
            set { SetProperty(ref _SalaryMax, value); }
		}

        private ObservableCollection<SortByEntryCMS> _specializationList;
        public ObservableCollection<SortByEntryCMS> SpecializationList
        {
            get { return _specializationList; }
            set { SetProperty(ref _specializationList, value); }
        }

        private ObservableCollection<SortByEntryCMS> _genderList;
        public ObservableCollection<SortByEntryCMS> GenderList
        {
            get { return _genderList; }
            set { SetProperty(ref _genderList, value); }
        }

        private ObservableCollection<SortByEntryCMS> _postedSinceList;
        public ObservableCollection<SortByEntryCMS> PostedSinceList
        {
            get { return _postedSinceList; }
            set { SetProperty(ref _postedSinceList, value); }
        }



        public FiltersPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {
			SalaryMax = 3000;
			SalaryMin = 1500;
            CancelCommand = new DelegateCommand(ProcessCancelCommand);
            ApplyCommand = new DelegateCommand(ProcessApplyCommand);
            //RangeSliderChangedCommand=new DelegateCommand(RangeSliderChangedCommand);
            SortByCheckedCommand = new DelegateCommand<SortByEntryCMS>(ProcessSortByCheckedCommand);
            JobTypeCheckedCommand = new DelegateCommand<SortByEntryCMS>(ProcessJobTypeCheckedCommand);
            WorkTypeCheckedCommand = new DelegateCommand<SortByEntryCMS>(ProcessWorkTypeCheckedCommand);
            ShiftTypeCheckedCommand = new DelegateCommand<SortByEntryCMS>(ProcessShiftTypeCheckedCommand);
            TravellingRequiredCheckedCommand = new DelegateCommand<SortByEntryCMS>(ProcessTravellingRequiredCheckedCommand);
            TeleWorkingCheckedCommand = new DelegateCommand<SortByEntryCMS>(ProcessTeleWorkingCheckedCommand);
            RequiredEducationCheckedCommand = new DelegateCommand<SortByEntryCMS>(ProcessRequiredEducationCheckedCommand);
            SpecializationCheckedCommand = new DelegateCommand<SortByEntryCMS>(ProcessSpecializationCheckedCommand);
            GenderCheckedCommand = new DelegateCommand<SortByEntryCMS>(ProcessGenderCheckedCommand);
            PostedSinceCheckedCommand = new DelegateCommand<SortByEntryCMS>(ProcessPostedSinceCheckedCommand);


            LabelCheckedCommand = new DelegateCommand<EntryBase>(ProcessLabelCheckedCommand);
            LoadData();
        }

        private void ProcessPostedSinceCheckedCommand(SortByEntryCMS obj)
        {
        }

        private void ProcessGenderCheckedCommand(SortByEntryCMS obj)
        {
        }

        private void ProcessSpecializationCheckedCommand(SortByEntryCMS obj)
        {
        }

        private void ProcessRequiredEducationCheckedCommand(SortByEntryCMS obj)
        {
        }

        private void ProcessTeleWorkingCheckedCommand(SortByEntryCMS obj)
        {
        }

        private void ProcessShiftTypeCheckedCommand(SortByEntryCMS obj)
        {
        }

        private void ProcessTravellingRequiredCheckedCommand(SortByEntryCMS obj)
        {
        }

        private void ProcessWorkTypeCheckedCommand(SortByEntryCMS obj)
        {
        }

        private void ProcessLabelCheckedCommand(EntryBase obj)
        {
            // lable clicks just negate current
            obj.Selected = !obj.Selected;
        }

        private void ProcessJobTypeCheckedCommand(SortByEntryCMS obj)
        {
        }

        private void ProcessSortByCheckedCommand(SortByEntryCMS obj)
        {
            var x = 0;
        }

        

        private void ProcessApplyCommand()
        {
			//Words.Where(w => w.Contains(":"));
			StringBuilder searchFilter = new StringBuilder();
			string filterJoin = string.Empty;
            var selectedGenderList = new ObservableCollection<SortByEntryCMS>(_genderList.Where(w => w.Selected));
            var selectedSortByList = new ObservableCollection<SortByEntryCMS>(_sortByList.Where(w => w.Selected));
            var selectedJobTypeList = new ObservableCollection<SortByEntryCMS>(_jobTypeList.Where(w => w.Selected));
            var selectedWorkTypeList = new ObservableCollection<SortByEntryCMS>(_workTypeList.Where(w => w.Selected));
            var selectedShiftTypeList = new ObservableCollection<SortByEntryCMS>(_shiftTypeList.Where(w => w.Selected));
            var selectedTeleWorkingList = new ObservableCollection<SortByEntryCMS>(_teleWorkingList.Where(w => w.Selected));
            var selectedRequiredEducationList = new ObservableCollection<SortByEntryCMS>(_requiredEducationList.Where(w => w.Selected));
			var selectedTravellingRequiredList = new ObservableCollection<SortByEntryCMS>(_travellingRequiredList.Where(w => w.Selected));
            var selectedSpecializationList = new ObservableCollection<SortByEntryCMS>(_specializationList.Where(w => w.Selected));
            var selectedPostedSinceList = new ObservableCollection<SortByEntryCMS>(_postedSinceList.Where(w => w.Selected));

            if (selectedJobTypeList ==null || selectedJobTypeList.Count<1)
            {
				filterJoin = String.Format("JobType eq * and ");
				searchFilter.Append(filterJoin);
            }
            else
            {
                foreach (SortByEntryCMS jobType in selectedJobTypeList)
                {
                    filterJoin = String.Format("JobType eq '{0}' and ", jobType.Value);
					searchFilter.Append(filterJoin);
                }
            }
            if (selectedGenderList != null && selectedGenderList.Count>0)
            {
                foreach (SortByEntryCMS gender in selectedGenderList)
				{
                    filterJoin = String.Format("Gender eq '{0}' and ", gender.Value);
					searchFilter.Append(filterJoin);
				}
            }
            if (selectedSortByList != null && selectedSortByList.Count > 0)
			{
                foreach (SortByEntryCMS sortBy in selectedSortByList)
				{
                    filterJoin = String.Format("SortBy eq '{0}' and ", sortBy.Value);
					searchFilter.Append(filterJoin);
				}
			}
			if (selectedWorkTypeList != null && selectedWorkTypeList.Count > 0)
			{
                foreach (SortByEntryCMS workType in selectedWorkTypeList)
				{
                    filterJoin = String.Format("WorkTime eq '{0}' and ", workType.Value);
					searchFilter.Append(filterJoin);
				}
			}
            if (selectedShiftTypeList != null && selectedShiftTypeList.Count > 0)
			{
                foreach (SortByEntryCMS shiftType in selectedShiftTypeList)
				{
                    filterJoin = String.Format("ShiftType eq '{0}' and ", shiftType.Value);
					searchFilter.Append(filterJoin);
				}
			}
            if (selectedRequiredEducationList != null && selectedRequiredEducationList.Count > 0)
			{
                foreach (SortByEntryCMS requiredEducation in selectedRequiredEducationList)
				{
                    filterJoin = String.Format("Education eq '{0}' and ", requiredEducation.Value);
					searchFilter.Append(filterJoin);
				}
			}
            if (selectedTravellingRequiredList != null && selectedTravellingRequiredList.Count > 0)
			{
                foreach (SortByEntryCMS travellingRequired in selectedTravellingRequiredList)
				{
                    filterJoin = String.Format("WillegnessToTravel eq '{0}' and ", travellingRequired.Value);
					searchFilter.Append(filterJoin);
				}
			}
            if (selectedTeleWorkingList != null && selectedTeleWorkingList.Count > 0)
			{
                foreach (SortByEntryCMS teleWorking in selectedTeleWorkingList)
				{
                    filterJoin = String.Format("TeleWorking eq '{0}' and ", teleWorking.Value);
					searchFilter.Append(filterJoin);
				}
			}
            if (selectedSpecializationList != null && selectedSpecializationList.Count > 0)
			{
                foreach (SortByEntryCMS specialization in selectedSpecializationList)
				{
                    filterJoin = String.Format("Specialization eq '{0}' and ", specialization.Value);
					searchFilter.Append(filterJoin);
				}
			}
            if (selectedPostedSinceList != null && selectedPostedSinceList.Count > 0)
			{
                foreach (SortByEntryCMS postedSince in selectedPostedSinceList)
				{
                    filterJoin = String.Format("PostedSince eq '{0}' and ", postedSince.Value);
					searchFilter.Append(filterJoin);
				}
			}

            filterJoin = String.Format("SalaryFrom eq '{0}' and ", SalaryMin.ToString());
			searchFilter.Append(filterJoin);

            filterJoin = String.Format("SalaryTo eq '{0}' and ", SalaryMax.ToString());
			searchFilter.Append(filterJoin);

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
            SortByList = CMSEntryHelper.GetSortByEntries();
            JobTypeList = CMSEntryHelper.GetJobTypeEntries();
            WorkTypeList = CMSEntryHelper.GetWorkTypeEntries();
            ShiftTypeList = CMSEntryHelper.GetShiftTypeEntries();
            TravellingRequiredList = CMSEntryHelper.GetTravellingRequiredEntries();
            TeleWorkingList = CMSEntryHelper.GetTeleWorkingEntries();
            RequiredEducationList = CMSEntryHelper.GetRequiredEducationEntries();
            SpecializationList = CMSEntryHelper.GetSpecializationEntries();
            GenderList = CMSEntryHelper.GetGenderEntries();
            PostedSinceList = CMSEntryHelper.GetPostedSinceEntries();
                
        }
    }
}
