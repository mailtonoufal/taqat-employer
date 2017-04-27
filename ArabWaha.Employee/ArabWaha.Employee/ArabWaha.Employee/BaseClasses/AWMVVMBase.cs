using ArabWaha.Core.BaseClasses;
using ArabWaha.Employee.Views.Menus;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabWaha.Employee.BaseClasses
{
    public class AWMVVMBase : MVVMBase
    {
        protected INavigationService _nav;
        protected IPageDialogService _dialog;

        // Private - due to fact we should pass at least NavigationService to intialise otherwise Slideout menu can fail.
        private AWMVVMBase()
        {
        }



        public AWMVVMBase(INavigationService navigationService)
        {
            _nav = navigationService;
        }

        public AWMVVMBase(INavigationService navigationService, IPageDialogService dialog)
        {
            _nav = navigationService;
            _dialog = dialog;
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
            catch (Exception ex)
            {
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
            if(_dialog!=null)
                await _dialog.DisplayAlertAsync(title, bodytext, ok);

            return true;
        }
    }
}
