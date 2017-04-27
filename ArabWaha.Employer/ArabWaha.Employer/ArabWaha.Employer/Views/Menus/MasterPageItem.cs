using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ArabWaha.Employer.Views.Menus
{
    public class MasterPageItem
    {
        public string Title { get; set; }

        public string IconSource { get; set; }

        public string TargetType { get; set; }
        public Type PageType { get; set; }

        public object ParamX { get; set; }

        public FileImageSource IconImage { get; set; }
    }
}
