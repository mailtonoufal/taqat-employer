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

		public static LayoutOptions HorizontalLayoutOptions { get { return IsArabic ? LayoutOptions.EndAndExpand : LayoutOptions.StartAndExpand; } }

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

		#endregion
	}
}
