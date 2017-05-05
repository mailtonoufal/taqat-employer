using ArabWaha.Core.ModelsEmployer.Programs;
using ArabWaha.Core.Services;
using ArabWaha.Employee.BaseClasses;
using ArabWaha.Employee.Helpers;
using ArabWaha.Employee.Views.Details;
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
    public class ProgramsPageViewModel : AWMVVMBase
    {
        string _statusText { get; set; }
        public ProgramsPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {
            ProgramSelectedCommand = new DelegateCommand<EmployerProgram>(ProcessProgramSelected);

            TranslateExtension tr = new TranslateExtension();
            _statusText = tr.GetProviderValueString("LabelProgramsProgStatus");

            LoadSource();

        }

        private async void LoadSource()
        {
            ApiServiceIndividual apiServ = new ApiServiceIndividual();
            ProgramsSource = await apiServ.GetAllProgramsAsync(_statusText);
        }

        private ObservableCollection<EmployerProgram> _ProgramsSource;

        public ObservableCollection<EmployerProgram> ProgramsSource
        {
            get { return _ProgramsSource; }
            set { SetProperty<ObservableCollection<EmployerProgram>>(ref _ProgramsSource, value); }
        }

        #region commands

        public DelegateCommand<EmployerProgram> ProgramSelectedCommand { get; set; }
        async void ProcessProgramSelected(EmployerProgram vals)
        {
            if (vals != null)
            {
                NavigationParameters paramx = new NavigationParameters();
                paramx.Add("Data", vals);
                await _nav.NavigateAsync(nameof(ProgramDetailsPage), paramx, false, true);
            }
        }

        #endregion

    }
}
