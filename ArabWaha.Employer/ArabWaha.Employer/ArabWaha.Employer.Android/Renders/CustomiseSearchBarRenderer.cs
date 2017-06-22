using System;
using Android.App;
using Android.Widget;
using ArabWaha.Employer.Droid.Renders;
using ArabWaha.Employer.StaticData;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SearchBar), typeof(CustomiseSearchBarRenderer))]
namespace ArabWaha.Employer.Droid.Renders
{
	public class CustomiseSearchBarRenderer : SearchBarRenderer
	{
		public CustomiseSearchBarRenderer()
		{
		}

		protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
		{
			base.OnElementChanged(e);

			if (GlobalSetting.IsArabic)
			{
				base.Control.SetGravity(Android.Views.GravityFlags.Right);
			}

			//removes underline
			LinearLayout linearLayout = this.Control.GetChildAt(0) as LinearLayout;
			linearLayout = linearLayout.GetChildAt(2) as LinearLayout;
			linearLayout = linearLayout.GetChildAt(1) as LinearLayout;
			linearLayout.Background = null;
		}
	}
}

