using ArabWaha.Employer.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ArabWaha.Employer.Helpers
{
    public class StartPageDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Page1Template { get; set; }
        public DataTemplate Page2Template { get; set; }

        public StartPageDataTemplateSelector()
        {
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var val = item.ToString();

            var temp = Page1Template;
            if (val=="2")
            {
                temp = Page2Template;
            }
            return temp;
        }
    }
}
