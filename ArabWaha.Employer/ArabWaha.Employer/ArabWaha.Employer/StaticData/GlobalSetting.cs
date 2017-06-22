using System;
using Xamarin.Forms;
using ArabWaha.Core.Services;

namespace ArabWaha.Employer.StaticData
{
	public static class GlobalSetting
	{
		public static string CultureCode { get; set; }
		public static bool IsArabic { get; set; }
		public static bool IsEnglish { get; set; }

		public static void SetupCulture()
		{
			ApiService svr = new ApiService();
			CultureCode = svr.GetCurrentCulture();

			IsArabic = CultureCode == "ar";
			IsEnglish = !IsArabic;
		}

		public static LayoutAlignment AlignLabel { get { return IsArabic ? LayoutAlignment.End : LayoutAlignment.Start; } }
		public static LayoutAlignment AlignData { get { return IsArabic ? LayoutAlignment.Start : LayoutAlignment.End; } }

		public static TextAlignment AlignText { get { return IsArabic ? TextAlignment.End : TextAlignment.Start; } }
		public static TextAlignment AlignLabelText { get { return IsArabic ? TextAlignment.End : TextAlignment.Start; } }

		public static TextAlignment SkipText { get { return IsArabic ? TextAlignment.Start : TextAlignment.End; } }


		public static LayoutOptions HorizontalLayoutOptions { get { return IsArabic ? LayoutOptions.EndAndExpand : LayoutOptions.StartAndExpand; } }
        public static LayoutOptions SkipLayoutOptions { get { return IsArabic ? LayoutOptions.StartAndExpand : LayoutOptions.EndAndExpand; } }


		#region well hacky till i fix this correctly for view cell items

		public static int LabelColumn { get; set; }
		public static int DataColumn { get; set; }
		public static int ImageColumn { get; set; }
		#endregion

		#region static constants used for design -- subhash

		public static GridLength HomeJobFirstColWidth { get { return IsArabic ? new GridLength(1, GridUnitType.Star) : new GridLength(55, GridUnitType.Absolute); } }
		public static GridLength HomeJobThirdColWidth { get { return IsArabic ? new GridLength(55, GridUnitType.Absolute) : new GridLength(1, GridUnitType.Star); } }
		public static string HomeJobImgColNo { get { return IsArabic ? "3" : "1"; } }
		public static string HomeJobLabelColNo { get { return IsArabic ? "1" : "3"; } }

        public static string HomeProgImgColNo { get { return IsArabic ? "2" : "1"; } }
        public static string HomeProgLabelColNo { get { return IsArabic ? "1" : "2"; } }
		public static GridLength HomeProgFirstColWidth { get { return IsArabic ? new GridLength(1, GridUnitType.Star) : new GridLength(55, GridUnitType.Absolute); } }
		public static GridLength HomeProgThirdColWidth { get { return IsArabic ? new GridLength(55, GridUnitType.Absolute) : new GridLength(1, GridUnitType.Star); } }


		public static string HomeProgGuestColNo { get { return IsArabic ? "2" : "1"; } }
		public static string HomeStartLabelColNo { get { return IsArabic ? "1" : "0"; } }
		public static string HomeStartImgColNo { get { return IsArabic ? "0" : "1"; } }

       
      
		
		#endregion
	}
}
