using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArabWaha.Employer.Helpers
{
	[ContentProperty("Text")]
	public class CMSTranslateExtension : IMarkupExtension
	{
		public string Text { get; set; }

		public CMSTranslateExtension()
		{
		}

		public string GetProviderValueString(string key)
		{
			if (key == null || App.Translation == null)
				return "";

			var property = App.Translation.employer.GetType().GetRuntimeProperty(key);
			var value = property.GetValue(App.Translation.employer).ToString();

			return value;
		}

		public object ProvideValue(IServiceProvider serviceProvider)
		{
			return GetProviderValueString(Text);
		}
	}
}