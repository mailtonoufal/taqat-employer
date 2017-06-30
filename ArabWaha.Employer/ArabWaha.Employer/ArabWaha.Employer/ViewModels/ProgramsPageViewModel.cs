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
using ArabWaha.Models;


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
				//ProgramsSource = await apiServ.GetAllProgramsAsync();

				var progList = await Web.AWHttpClient.Instance.GetPrograms();

				if (progList.Data != null && progList.Data.Programs.Count > 0)
				{
					ProgramsSource = new ObservableCollection<Program>(progList.Data.Programs);
				}





				//for program status text

				TranslateExtension tran = new TranslateExtension();
				string progStatusLabel = tran.GetProviderValueString("LabelProgramStatusText");
				// setup Program Status:
				foreach (var item in ProgramsSource)
				{
					//item.StatusLabelText = progStatusLabel;
                    item.StatusText = $"{progStatusLabel} {item.StatusText} ";
				}






            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private ObservableCollection<Program> _ProgramsSource;

        public ObservableCollection<Program> ProgramsSource
        {
            get { return _ProgramsSource; }
            set { SetProperty<ObservableCollection<Program>>(ref _ProgramsSource, value); }
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
