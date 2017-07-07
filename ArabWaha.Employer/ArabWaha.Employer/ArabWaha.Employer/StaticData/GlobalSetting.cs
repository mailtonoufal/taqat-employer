using System;
using Xamarin.Forms;
using ArabWaha.Core.Services;
using System.Text.RegularExpressions;

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
        public static string FilterQuery { get; set; }
		public static LayoutAlignment AlignLabel { get { return IsArabic ? LayoutAlignment.End : LayoutAlignment.Start; } }
		public static LayoutAlignment AlignData { get { return IsArabic ? LayoutAlignment.Start : LayoutAlignment.End; } }

		public static TextAlignment AlignText { get { return IsArabic ? TextAlignment.End : TextAlignment.Start; } }
		public static TextAlignment AlignLabelText { get { return IsArabic ? TextAlignment.End : TextAlignment.Start; } }

		public static TextAlignment AlignTextReverse { get { return IsArabic ? TextAlignment.Start : TextAlignment.End; } }

		public static TextAlignment SkipText { get { return IsArabic ? TextAlignment.Start : TextAlignment.End; } }


		public static LayoutOptions HorizontalLayoutOptions { get { return IsArabic ? LayoutOptions.EndAndExpand : LayoutOptions.StartAndExpand; } }
		public static LayoutOptions SkipLayoutOptions { get { return IsArabic ? LayoutOptions.StartAndExpand : LayoutOptions.EndAndExpand; } }
		public static LayoutOptions HorizontalOptions { get { return IsArabic ? LayoutOptions.EndAndExpand : LayoutOptions.StartAndExpand; } }


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

        public static GridLength StarColWidth { get { return IsArabic ? new GridLength(1, GridUnitType.Star) : new GridLength(1, GridUnitType.Auto); } }
        public static GridLength AutoColWidth { get { return IsArabic ? new GridLength(1, GridUnitType.Auto) : new GridLength(1, GridUnitType.Star); } }


		public static string HomeProgGuestColNo { get { return IsArabic ? "2" : "1"; } }
		public static string HomeStartLabelColNo { get { return IsArabic ? "1" : "0"; } }
		public static string HomeStartImgColNo { get { return IsArabic ? "0" : "1"; } }







		public static string AppWatchButtonColNo { get { return IsArabic ? "1" : "2"; } }
		public static string AppWatchLabelColNo { get { return IsArabic ? "2" : "1"; } }

		// Search Result Screen 
		public static string SearchResultTitleColNo { get { return IsArabic ? "2" : "1"; } }
		public static string SearchResultProgressColNo { get { return IsArabic ? "1" : "2"; } }
		public static GridLength SearchResultProgressWidth { get { return IsArabic ? new GridLength(3, GridUnitType.Star) : new GridLength(8, GridUnitType.Star); } }
		public static GridLength SearchResultLabelWidth { get { return IsArabic ? new GridLength(8, GridUnitType.Star) : new GridLength(3, GridUnitType.Star); } }
		public static string SearchResultBottomRowCellArabic { get { return IsArabic ? "True" : "False"; } }
		public static string SearchResultBottomRowCellEng { get { return IsArabic ? "False" : "True"; } }


		public static GridLength HomeContactFirstColWidth { get { return IsArabic ? new GridLength(1, GridUnitType.Star) : new GridLength(24, GridUnitType.Absolute); } }
		public static GridLength HomeContactThirdColWidth { get { return IsArabic ? new GridLength(24, GridUnitType.Absolute) : new GridLength(1, GridUnitType.Star); } }

		//Personal details set 
		public static string PersonalDetailLabelColNo { get { return IsArabic ? "1" : "0"; } }
		public static string PersonalDetailValueColNo { get { return IsArabic ? "0" : "1"; } }

		public static GridLength EditPersonalDetailCol1Width { get { return IsArabic ? new GridLength(20, GridUnitType.Absolute) : new GridLength(1, GridUnitType.Star); } }
		public static GridLength EditPersonalDetailCol3Width { get { return IsArabic ? new GridLength(1, GridUnitType.Star) : new GridLength(20, GridUnitType.Absolute); } }

		public static string EditPersonalDetailImageColNo { get { return IsArabic ? "2" : "0"; } }
		public static string EditPersonalDetailLabelColNo { get { return IsArabic ? "0" : "2"; } }


		//Job Post details details set 
		public static string LicencesLabelColNo { get { return IsArabic ? "1" : "0"; } }
		public static string LicencesValueColNo { get { return IsArabic ? "0" : "1"; } }

		//Job Post details contact person set 
		public static string ContactPersonLeftColNo { get { return IsArabic ? "1" : "0"; } }
		public static string ContactPersonRightColNo { get { return IsArabic ? "0" : "1"; } }

		#endregion


        public static Regex CreateValidEmailRegex()
		{
			string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
				+ @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
				+ @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

			return new Regex(validEmailPattern, RegexOptions.IgnoreCase);
		}




	}
}
