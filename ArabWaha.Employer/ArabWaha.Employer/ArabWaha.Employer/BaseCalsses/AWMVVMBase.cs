using ArabWaha.Core.BaseClasses;
using ArabWaha.Employer.Views.Menus;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ArabWaha.Employer.BaseCalsses
{
    public class AWMVVMBase : MVVMBase
    {
        protected INavigationService _nav;
        protected IPageDialogService _dialog;

        public bool IsAuth
        {
            get { return Core.Services.AuthService.IsAuthorised; }
        }

        // Private - due to fact we should pass at least NavigationService to intialise otherwise Slideout menu can fail.
        private AWMVVMBase()
        {
            SetDefaultColumn();
        }



        public AWMVVMBase(INavigationService navigationService)
        {
            _nav = navigationService;
            SetDefaultColumn();
        }

        public AWMVVMBase(INavigationService navigationService, IPageDialogService dialog)
        {
            _nav = navigationService;
            _dialog = dialog;

            SetDefaultColumn();
        }


        protected void SetDefaultColumn(int labelCol = 1, int dataCol = 2)
        {
            // pass in dfaults for EN (and then swap for AR)
            LabelColumn = labelCol;
            DataColumn = dataCol;
            ImageColumn = 3;

            if (CultureCode == "ar")
            {
                DataColumn = labelCol;
                LabelColumn = dataCol;
                ImageColumn = 1;
            }
        }

        public async void NavigateAsync(MasterPageItem obj)
        {
            try
            {
                if (_nav != null)
                {
                    await _nav.NavigateAsync(obj.TargetType);
                }
            }
            catch(Exception ex)
            {
                var t = ex.Message;
                // ignore
                Debug.WriteLine("ERROR NAVIGATING");
            }
        }

        public async void NavigateAsync(string obj)
        {
            try
            {
                if (_nav != null)
                {
                    await _nav.NavigateAsync(obj);
                }
            }
            catch (Exception ex)
            {
                // ignore
                Debug.WriteLine("ERROR NAVIGATING");
            }
        }

        public async Task<bool> ShowMessage(string title, string bodytext, string ok)
        {
            if (_dialog != null)
                await _dialog.DisplayAlertAsync(title, bodytext, ok);

            return true;
        }

        #region setup layout options here

        public TextAlignment AlignText
        {
            get
            {
                return GlobalSetting.AlignText;
            }
        }

        public TextAlignment AlignLabelText
        {
            get
            {
                return GlobalSetting.AlignLabelText;
            }
        }

        public LayoutOptions AlignLayoutOptions
        {
            get { return GlobalSetting.HorizontalLayoutOptions; }
        }

        // setup columns 
        private int _LabelColumns;

        public int LabelColumn
        {
            get { return _LabelColumns; }
            set
            {
                SetProperty<int>(ref _LabelColumns, value);
                GlobalSetting.LabelColumn = value;
            }
        }

        private int _dataColumn;
    
        public int DataColumn
        {
            get { return _dataColumn; }
            set {
                SetProperty<int>(ref _dataColumn, value);
                GlobalSetting.DataColumn = value;
            }
        }

        private int _imageColumn;

        public int ImageColumn
        {
            get { return _imageColumn; }
            set {
                SetProperty<int>(ref _imageColumn, value);
                GlobalSetting.ImageColumn = value;
            }
        }

        public string CultureCode
        {
            get
            {
                return GlobalSetting.CultureCode;
            }
        }

        #endregion


    }
}
