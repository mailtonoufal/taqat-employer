using ArabWaha.Core.ModelsEmployer.Jobs;
using ArabWaha.Core.Services;
using ArabWaha.Employer.BaseCalsses;
using ArabWaha.Employer.Layouts.Jobs;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace ArabWaha.Employer.ViewModels
{
    public class JobPageViewModel : AWMVVMBase, INavigatedAware
    {

        public JobPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {
            IsBusy = false;

            _nav = navigationService;
            _dialog = dialog;

            ViewCandidatesCommand = new DelegateCommand(ProcessViewCandidatesCommand);
            EditJobCommand = new DelegateCommand(ProcessEditJobCommand);
            DeleteJobCommand = new DelegateCommand(ProcessDeleteJobCommand);

            // edit commands for listview languages
            AddLanguageCommand= new DelegateCommand(AddLanguage);
            DeleteLanguageCommand = new DelegateCommand(RemoveLanguage);
            EditLanguageCommand = new DelegateCommand<JobDetailLanguage>(EditLanguage);

            //  edit licences 
            AddLicenceCommand = new DelegateCommand(AddLicence);
            DeleteLicenceCommand = new DelegateCommand(RemoveLicence);
            EditLicenceCommand = new DelegateCommand<JobDetailLicenses>(EditLicence);

            // training licences
            AddTrainingCommand = new DelegateCommand(AddTraining);
            DeleteTrainingCommand = new DelegateCommand(RemoveTraining);
            EditTrainingCommand = new DelegateCommand<EmployerJobDetailTraining>(EditTraining);

            // save / discard commands
            DiscardChangesJobCommand = new DelegateCommand(ProcessDiscardChangesJobCommand);
            SaveChangesJobCommand = new DelegateCommand(ProcessSaveChangesJobCommand);

    }

        private Map _locationMap;
        public async void SetupMap(Map mapin)
        {
            Task.Run(() =>
                {
                    _locationMap = mapin;

                    Position pos = new Position(double.Parse(JobDetails.CompanyLocation.Latitude), double.Parse(JobDetails.CompanyLocation.Latitude));
                    var mappin = new Pin { Type = PinType.Place, Position = pos, Label = "Company Location", Address = JobDetails.CompanyLocation.Address };

                    _locationMap.Pins.Add(mappin);

                });


        }


        #region Commands

        public DelegateCommand ViewCandidatesCommand { get; set; }

        async void ProcessViewCandidatesCommand()
        {
            var res = await _dialog.DisplayActionSheetAsync("Will goto matching candiates!! (demo action)", "Cancel","Ok", "" );
        }

        public DelegateCommand EditJobCommand { get; set; }
        async void ProcessEditJobCommand()
        {
            var res = await _dialog.DisplayActionSheetAsync("Will open edit mode!! (demo action)", "Cancel", "Ok", "");
        }

        public DelegateCommand DeleteJobCommand { get; set; }

        async void ProcessDeleteJobCommand()
        {
            var res = await _dialog.DisplayActionSheetAsync("Confirm delete!! (demo action)", "Cancel", "Delete", "");
        }



        // DiscardChangesJobCommand
        public DelegateCommand DiscardChangesJobCommand { get; set; }

        async void ProcessDiscardChangesJobCommand()
        {
            var res = await _dialog.DisplayActionSheetAsync("Confirm you want to Discard All Changes!!", "Cancel", "Discard Changes", "");
            if(res!="Cancel")
            {
                ApiService apiServ = new ApiService();
                var tmp = await apiServ.GetEmployerPostedJobsAsync(1);
                var discarded = tmp.Where(x => x.JobPostId == JobDetails.JobPostId).FirstOrDefault();
                JobDetails = discarded; // has to exist if we are showing it but currently changing in static objects. will eb fixed when we have db.
                await _nav.GoBackAsync();
            }
        }

        // SaveChangesJobCommand
        public DelegateCommand SaveChangesJobCommand { get; set; }
        async void ProcessSaveChangesJobCommand()
        {

            var res = await _dialog.DisplayActionSheetAsync("Confirm Save Changes!!", "Cancel", "Save Edits", "");

            if (res != "Cancel")
            {
                // save data here 
                ApiService apiServ = new ApiService();
                await apiServ.UpdateEmployerJob(JobDetails);

                // send message back as param to update job list here
                NavigationParameters navP = new NavigationParameters();
                navP.Add("JOBUPDATE", JobDetails.JobPostId);
                await _nav.GoBackAsync(navP);
            }
        }


        #endregion

        #region Modes

        private bool _isEditMode;
        public bool IsEditMode
        {
            get { return _isEditMode; }
            set { SetProperty<bool>(ref _isEditMode, value); }
        }

        private bool _isViewMode;
        public bool IsViewMode
        {
            get { return _isViewMode; }
            set { SetProperty<bool>(ref _isViewMode, value); }
        }


        void SetEditMode()
        {
            IsEditMode = true;
            IsViewMode = false;
            JobEditContent = new JobEditContent();
            CurrentView = JobEditContent;
        }

        void SetNewMode()
        {
            JobNewContent = new JobEditContent();
            CurrentView = JobNewContent;
        }

        void SetViewMode()
        {
            IsEditMode = false;
            IsViewMode = true;

            JobDisplayContent = new JobDisplayContent();
            CurrentView = JobDisplayContent;
        }

        #endregion

        #region job licence editing process

        private string _licenceNameEdit;

        public string LicenceNameEdit
        {
            get { return _licenceNameEdit; }
            set { SetProperty<string>(ref _licenceNameEdit, value); }
        }

        private string _licenceExpireEdit;

        public string LicenceExpireEdit
        {
            get { return _licenceExpireEdit; }
            set { SetProperty<string>(ref _licenceExpireEdit, value); }
        }


        public DelegateCommand AddLicenceCommand { get; set; }
        public DelegateCommand DeleteLicenceCommand { get; set; }
        public DelegateCommand<JobDetailLicenses> EditLicenceCommand { get; set; }


        private JobDetailLicenses _selectedLicenceEditItem;
        public JobDetailLicenses SelectedLicenceEditItem
        {
            get
            {
                return _selectedLicenceEditItem;
            }
            set
            {
                _selectedLicenceEditItem = value;

                if (_selectedLicenceEditItem == null)
                    return;

                EditLicenceCommand.Execute(_selectedLicenceEditItem);

                _selectedLicenceEditItem = null;
            }
        }

        void AddLicence()
        {
            if (string.IsNullOrEmpty(LicenceNameEdit) || string.IsNullOrEmpty(LicenceExpireEdit))
                return;

            int index = -1;
            // check if already exists if so update else add
            var t = JobDetails.JobLicenses.Where(x => x.Value.ToLower().Trim() == LicenceNameEdit.ToLower().Trim()).FirstOrDefault();
            if (t != null)
            {
                index = JobDetails.JobLicenses.IndexOf(t);
                JobDetails.JobLicenses.Remove(t);
            }

            // new so just add
            JobDetailLicenses lnew = new JobDetailLicenses { Value = LicenceNameEdit, ExpiryValue = LicenceExpireEdit };
            if (index > -1)
                JobDetails.JobLicenses.Insert(index, lnew);
            else
                JobDetails.JobLicenses.Add(lnew);

            ClearLicenceEdit();
        }

        void RemoveLicence()
        {
            if (string.IsNullOrEmpty(LicenceNameEdit))
                return;

            // check if already exists if so update else add
            var t = JobDetails.JobLicenses.Where(x => x.Value.ToLower().Trim() == LicenceNameEdit.ToLower().Trim()).FirstOrDefault();
            if (t != null)
            {
                JobDetails.JobLicenses.Remove(t);
            }

            ClearLicenceEdit();
        }

        void EditLicence(JobDetailLicenses det)
        {
            if (det == null || string.IsNullOrEmpty(det.Value) || string.IsNullOrEmpty(det.ExpiryValue)) return;

            LicenceExpireEdit = det.ExpiryValue;
            LicenceNameEdit = det.Value;
        }

        // EditLanguageSelected
        void ClearLicenceEdit()
        {
            LicenceNameEdit= "";
            LicenceExpireEdit = "";
        }

        #endregion

        #region job Training editing process

        private string _trainingNameEdit;
        public string TrainingNameEdit
        {
            get { return _trainingNameEdit; }
            set { SetProperty<string>(ref _trainingNameEdit, value); }
        }

        private string _trainingExpireEdit;
        public string TrainingExpireEdit
        {
            get { return _trainingExpireEdit; }
            set { SetProperty<string>(ref _trainingExpireEdit, value); }
        }

        private string _trainingLocationEdit;
        public string TrainingLocationEdit
        {
            get { return _trainingLocationEdit; }
            set { SetProperty<string>(ref _trainingLocationEdit, value); }
        }

        private string _trainingInstituteEdit;
        public string TrainingInstituteEdit
        {
            get { return _trainingInstituteEdit; }
            set { SetProperty<string>(ref _trainingInstituteEdit, value); }
        }

        public DelegateCommand AddTrainingCommand { get; set; }
        public DelegateCommand DeleteTrainingCommand { get; set; }
        public DelegateCommand<EmployerJobDetailTraining> EditTrainingCommand { get; set; }


        private EmployerJobDetailTraining _selectedTrainingEditItem;
        public EmployerJobDetailTraining SelectedTrainingEditItem
        {
            get
            {
                return _selectedTrainingEditItem;
            }
            set
            {
                _selectedTrainingEditItem = value;

                if (_selectedTrainingEditItem == null)
                    return;

                EditTrainingCommand.Execute(_selectedTrainingEditItem);

                _selectedTrainingEditItem = null;
            }
        }

        void AddTraining()
        {
            if (string.IsNullOrEmpty(TrainingNameEdit) || string.IsNullOrEmpty(TrainingExpireEdit)
                || string.IsNullOrEmpty(TrainingInstituteEdit) || string.IsNullOrEmpty(TrainingLocationEdit))
                return;


            int index = -1;
            // check if already exists if so update else add
            var t = JobDetails.JobTraining.Where(x => x.Name.ToLower().Trim() == TrainingNameEdit.ToLower().Trim()).FirstOrDefault();
            if (t != null)
            {
                index = JobDetails.JobTraining.IndexOf(t);
                JobDetails.JobTraining.Remove(t);
            }

            // new so just add
            EmployerJobDetailTraining lnew = new EmployerJobDetailTraining { Name = TrainingNameEdit, InstituteName=TrainingInstituteEdit,
                                                                                    Validity=TrainingExpireEdit, Location=TrainingLocationEdit};
            if (index > -1)
                JobDetails.JobTraining.Insert(index, lnew);
            else
                JobDetails.JobTraining.Add(lnew);

            ClearTrainingEdit();
        }

        void RemoveTraining()
        {
            if (string.IsNullOrEmpty(TrainingNameEdit))
                return;

            // check if already exists if so update else add
            var t = JobDetails.JobTraining.Where(x => x.Name.ToLower().Trim() == TrainingNameEdit.ToLower().Trim()).FirstOrDefault();
            if (t != null)
            {
                JobDetails.JobTraining.Remove(t);
            }

            ClearTrainingEdit();
        }

        void EditTraining(EmployerJobDetailTraining det)
        {
            if (string.IsNullOrEmpty(det.Name) ) return;

            TrainingNameEdit = det.Name;
            TrainingInstituteEdit = det.InstituteName;
            TrainingExpireEdit = det.Validity;
            TrainingLocationEdit = det.Location;
        }

        // EditLanguageSelected
        void ClearTrainingEdit()
        {
            TrainingNameEdit = "";
            TrainingInstituteEdit = "";
            TrainingExpireEdit = "";
            TrainingLocationEdit = "";
        }

        #endregion

        #region languages editing processing

        private string _languageEdit;

        public string LanguageEdit
        {
            get { return _languageEdit; }
            set { SetProperty<string>(ref _languageEdit, value); }
        }

        private double _LanguageSliderValue;

        public double LanguageSliderValue
        {
            get { return _LanguageSliderValue; }
            set { SetProperty<double>(ref _LanguageSliderValue , value); }
        }

        public DelegateCommand AddLanguageCommand { get; set; }
        public DelegateCommand DeleteLanguageCommand { get; set; }
        public DelegateCommand<JobDetailLanguage> EditLanguageCommand { get; set; }


        private JobDetailLanguage _selectedEditItem;
        public JobDetailLanguage SelectedEditItem
        {
            get
            {
                return _selectedEditItem;
            }
            set
            {
                _selectedEditItem = value;

                if (_selectedEditItem == null)
                    return;

                EditLanguageCommand.Execute(_selectedEditItem);

                _selectedEditItem = null;
            }
        }

        void AddLanguage()
        {
            if (string.IsNullOrEmpty(LanguageEdit))
                return;

            int index = -1;

            // check if already exists if so update else add
            var t = JobDetails.JobLanguages.Where(x => x.Name.ToLower().Trim() == LanguageEdit.ToLower().Trim()).FirstOrDefault();
            if (t != null)
            {
                index = JobLanguages.IndexOf(t);
                JobLanguages.Remove(t);
            }

            // new so just add
            JobDetailLanguage lnew = new JobDetailLanguage { Name = LanguageEdit, ProficiencyLevel = ((int)LanguageSliderValue).ToString() };

            if (index > -1)
                JobDetails.JobLanguages.Insert(index, lnew);
            else
                JobDetails.JobLanguages.Add(lnew);

            ClearLanguageEdit();
        }

        void RemoveLanguage()
        {
            if (string.IsNullOrEmpty(LanguageEdit))
                return;

            // check if already exists if so update else add
            var t = JobDetails.JobLanguages.Where(x => x.Name.ToLower().Trim() == LanguageEdit.ToLower().Trim()).FirstOrDefault();
            if (t != null)
            {
                JobLanguages.Remove(t);
            }

            ClearLanguageEdit();
        }

        void EditLanguage(JobDetailLanguage det)
        {
            if (det == null || string.IsNullOrEmpty(det.Name)) return;

            LanguageEdit = det.Name;
            LanguageSliderValue = det.ProficiencyValue * 100;
        }

        // EditLanguageSelected

        void ClearLanguageEdit()
        {
            LanguageSliderValue = 0;
            LanguageEdit = "";
        }

        #endregion

        public ObservableCollection<JobDetailLanguage> JobLanguages
        {
            get { return JobDetails.JobLanguages;}
        }

        public ObservableCollection<JobDetailLicenses> JobLicenses
        {
            get { return JobDetails.JobLicenses; }
        }

        public ObservableCollection<EmployerJobDetailTraining> JobTraining
        {
            get { return JobDetails.JobTraining; }
        }
        // end test

        private EmployerJobDetail _jobDetails;
        public EmployerJobDetail JobDetails
        {
            get { return _jobDetails; }
            set { SetProperty<EmployerJobDetail>(ref _jobDetails, value); }

        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            var mode = parameters.Where(x => x.Key == "MODE").FirstOrDefault();
            if (mode.Value != null && (!string.IsNullOrEmpty(mode.Value.ToString())))
            {
                var jobDetails = parameters.Where(x => x.Key == "JOB").FirstOrDefault();

                var modeVal = mode.Value.ToString();
                switch(modeVal)
                {
                    case "NEW":
                        SetNewMode();
                        break;

                    case "EDIT":
                        if(jobDetails.Value==null)
                        {
                            _dialog.DisplayAlertAsync("Error", "No job to edit.", "OK");
                            _nav.GoBackAsync();
                        }
                        else
                        {
                            JobDetails = jobDetails.Value as EmployerJobDetail;
                            SetEditMode();
                        }
                        break;
                    case "VIEW":
                        if (jobDetails.Value == null)
                        {
                            _dialog.DisplayAlertAsync("Error", "No job to View.", "OK");
                            _nav.GoBackAsync();
                        }
                        else
                        {
                            JobDetails = jobDetails.Value as EmployerJobDetail;
                            SetViewMode();
                        }
                        break;
                    
                }

//                JobDetails.SalaryFrom
            }
        }

        #region views

        // only need 2 content view. one for new/edit and one for display only
        private JobEditContent _jobEditContent;
        public JobEditContent JobEditContent
        {
            get { return _jobEditContent; }
            set { SetProperty<JobEditContent>(ref _jobEditContent, value); }
        }


        private JobEditContent _jobNewContent;
        public JobEditContent JobNewContent
        {
            get { return _jobNewContent; }
            set { SetProperty<JobEditContent>(ref _jobNewContent, value); }
        }

        private JobDisplayContent _jobDisplayContent;
        private JobDisplayContent JobDisplayContent
        {
            get { return _jobDisplayContent; }
            set { SetProperty<JobDisplayContent>(ref _jobDisplayContent, value); }
        }

        private ContentView _CurrentView;

        public ContentView CurrentView
        {
            get
            {
                return _CurrentView;
            }
            set
            {

                if (value != null)
                    SetProperty<ContentView>(ref _CurrentView, value);
            }
        }


        #endregion
    }
}
