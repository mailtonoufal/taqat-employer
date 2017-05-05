using ArabWaha.Employer.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArabWaha.Employer.Helpers
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        readonly CultureInfo ci;
        const string ResourceId = "ArabWaha.Employer.Resx.AppResources";

        public TranslateExtension()
        {
            if (string.IsNullOrEmpty(GlobalSetting.CultureCode))
            {
                ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            }
            else ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo(GlobalSetting.CultureCode);
        }

        public string Text { get; set; }

        public string GetProviderValueString(string key)
        {
            if (key == null)
                return "";

            ResourceManager temp = new ResourceManager
            (ResourceId, typeof(TranslateExtension).GetTypeInfo().Assembly);
            var translation = temp.GetString(key, ci);
            if (translation == null)
            {
                translation = key;
            }
            return translation;
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return GetProviderValueString(Text);
        }

        public static string GetString(string key)
        {
            TranslateExtension tran = new TranslateExtension();
            return tran.GetProviderValueString(key);
        }
    }
}
