using System;
using ArabWaha.Employer.iOS.Renders;
using ArabWaha.Employer.StaticData;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SearchBar), typeof(CustomiseSearchBarRenderer))]
namespace ArabWaha.Employer.iOS.Renders
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
				base.Control.SemanticContentAttribute = UISemanticContentAttribute.ForceRightToLeft;
			}
		}
	}
}
