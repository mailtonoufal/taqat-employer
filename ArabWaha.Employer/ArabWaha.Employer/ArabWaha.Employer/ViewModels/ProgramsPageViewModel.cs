using ArabWaha.Core.ModelsEmployer.Programs;
using ArabWaha.Core.Services;
using ArabWaha.Employer.BaseCalsses;
using ArabWaha.Employer.Views.Home;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Diagnostics;
using ArabWaha.Employer.Helpers;

using static ArabWaha.Models.Translation;

namespace ArabWaha.Employer.ViewModels
{
    public class ProgramsPageViewModel : AWMVVMBase
    {
        public ProgramsPageViewModel(INavigationService navigationService, IPageDialogService dialog) : base(navigationService, dialog)
        {
            ProgramSelectedCommand = new DelegateCommand<Program>(ProcessProgramSelected);

            LoadSource();
        }

        private async void LoadSource()
        {
            ApiService apiServ = new ApiService();
            try
            {
                ProgramsSource = await apiServ.GetAllProgramsAsync();



                //for program status text

				TranslateExtension tran = new TranslateExtension();
				string progStatusLabel = tran.GetProviderValueString("LabelProgramStatusText");
				// setup Program Status:
				foreach (var item in ProgramsSource)
				{
					item.StatusLabelText = progStatusLabel;
				}






            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private ObservableCollection<EmployerProgram> _ProgramsSource;

        public ObservableCollection<EmployerProgram> ProgramsSource
        {
            get { return _ProgramsSource; }
            set { SetProperty<ObservableCollection<EmployerProgram>>(ref _ProgramsSource, value); }
        }

        #region commands

        public DelegateCommand<Program> ProgramSelectedCommand { get; set; }
        async void ProcessProgramSelected(Program vals)
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
