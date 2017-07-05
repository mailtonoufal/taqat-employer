using System;
using Acr.UserDialogs;

namespace ArabWaha.Employer.Helpers
{
    public class Dialog
    {
		public static void ShowLoading()
		{
            UserDialogs.Instance.ShowLoading();
		}

		public static void HideLoading()
		{
            UserDialogs.Instance.HideLoading();
		}

        public static void ShowErrorMessage(string msg)
		{
            UserDialogs.Instance.ShowError(msg);
		}

		public static void ShowErrorAlert(string msg)
		{
            UserDialogs.Instance.Alert(msg,"Error");
		}
    }
}
