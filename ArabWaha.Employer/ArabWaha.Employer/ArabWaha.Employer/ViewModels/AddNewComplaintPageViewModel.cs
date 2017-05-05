using ArabWaha.Core.DBAccess;
using ArabWaha.Core.Helpers;
using ArabWaha.Core.Services;
using ArabWaha.Employer.BaseCalsses;
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
    public class AddNewComplaintPageViewModel : AWMVVMBase, INavigatedAware
    {
        private ObservableCollection<AppValues> _MainList;



        public AddNewComplaintPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {

            SaveComplaintCommand = new DelegateCommand(ProcessSaveComplaintCommand);
            CurrentComplaint = new ComplaintRaised();
            GetDropdownValues();

            DataColumn = 2;
            LabelColumn = 1;
            // set up base positions
            if(CultureCode=="ar")
            {
                DataColumn = 1;
                LabelColumn = 2;
            }
        }

        private async void GetDropdownValues()
        {
            // pull from db then pre-populate 
            ApiService api = new ApiService();
            _MainList = await api.GetDefaultValuesAsync("Complaints");

            // set root list here
            Cat1List = UtilHelper.ConvertToObservable<AppValues>(_MainList.Where(x => x.ParentKey == "0").ToList());
        }

        #region lists

        private ObservableCollection<AppValues> _Cat1List;
        public ObservableCollection<AppValues> Cat1List
        {
            get { return _Cat1List; }
            set { SetProperty< ObservableCollection < AppValues >>(ref _Cat1List , value); }
        }

        private ObservableCollection<AppValues> _Cat2List;
        public ObservableCollection<AppValues> Cat2List
        {
            get { return _Cat2List; }
            set { SetProperty<ObservableCollection<AppValues>>(ref _Cat2List, value); }
        }

        private ObservableCollection<AppValues> _Cat3List;
        public ObservableCollection<AppValues> Cat3List
        {
            get { return _Cat3List; }
            set { SetProperty<ObservableCollection<AppValues>>(ref _Cat3List, value); }
        }



        #endregion

        #region properties

        private AppValues _Category1;
        public AppValues Category1
        {
            get { return _Category1; }
            set {

                if (value == _Category1) return;

                SetProperty< AppValues>(ref _Category1 , value);

                // set current to value
                _currentCategory = value;

                // filter cat 2 based on cat 1 :) if we have any parentkeys that match chosen item
                if(_MainList.Where(x=>x.ParentKey==_Category1.Key).ToList().Count>0)
                {
                    Cat2List = UtilHelper.ConvertToObservable<AppValues>(_MainList.Where(x => x.ParentKey == _Category1.Key).ToList());
                    IsCat2Enabled = true;
                }
                else
                {
                    Cat2List = new ObservableCollection<AppValues>();
                    IsCat2Enabled = false; // no items so disable
                }

            }
        }


        private AppValues _Category2;
        public AppValues Category2
        {
            get { return _Category2; }
            set {

                if (value == _Category2) return;
                SetProperty<AppValues>(ref _Category2, value);

                // set current to value
                _currentCategory = value;

                // filter cat 2 based on cat 1 :) if we have any parentkeys that match chosen item
                if (_MainList.Where(x => x.ParentKey == _Category2.Key).ToList().Count > 0)
                {
                    Cat3List = UtilHelper.ConvertToObservable<AppValues>(_MainList.Where(x => x.ParentKey == _Category2.Key).ToList());
                    IsCat3Enabled = true;
                }
                else
                {
                    Cat3List = new ObservableCollection<AppValues>();
                    IsCat3Enabled = false; // no items so disable
                }

            }
        }

        private AppValues _Category3;
        public AppValues Category3
        {
            get { return _Category3; }
            set { SetProperty<AppValues>(ref _Category3, value); }
        }

        private AppValues _currentCategory; // for the last chosen values we need to save



        private bool _isCat2Enabled;

        public bool IsCat2Enabled
        {
            get { return _isCat2Enabled; }
            set { SetProperty<bool>(ref _isCat2Enabled, value); }
        }

        private bool _isCat3Enabled;

        public bool IsCat3Enabled
        {
            get { return _isCat3Enabled; }
            set { SetProperty<bool>(ref _isCat3Enabled, value); }
        }

        private ComplaintRaised _CurrentComplaint;

        public ComplaintRaised CurrentComplaint
        {
            get { return _CurrentComplaint; }
            set { SetProperty<ComplaintRaised>(ref _CurrentComplaint , value); }
        }

        #endregion

        #region Commands

        public DelegateCommand SaveComplaintCommand { get; set; }

        private async void ProcessSaveComplaintCommand()
        {

            // validate we have all fields filled in
            if(string.IsNullOrEmpty(CurrentComplaint.ComplaintText)
                || string.IsNullOrEmpty(CurrentComplaint.Subject)
                || string.IsNullOrEmpty(CurrentComplaint.DOB)
                || string.IsNullOrEmpty(CurrentComplaint.NIN))
            {
                await _dialog.DisplayAlertAsync("Missing Info", "Please Fill all field Data and set valid date of birth before submit", "OK");
                return;
            }

            CurrentComplaint.CreatedOn = UtilHelper.GetStringFormatFromDate(DateTime.Now);
            CurrentComplaint.Category = _currentCategory.Value;
            CurrentComplaint.Status = "Created";

            ApiService api = new ApiService();
            await api.AddNewComplaint(CurrentComplaint);

            // push back with update
            NavigationParameters navP = new NavigationParameters();
            navP.Add("UPDATE", "UPDATE");
            await _nav.GoBackAsync(navP);
        }

        #endregion

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
           // throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
           // throw new NotImplementedException();
        }
    }
}
