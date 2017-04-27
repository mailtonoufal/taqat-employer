using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArabWaha.Common.Styles
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GlobalStyles : ResourceDictionary
    {
        public GlobalStyles()
        {
            InitializeComponent();
        }
    }
}
