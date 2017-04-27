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

namespace ArabWaha.Employer.Controls
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabControl3Column : StackLayout
    {
        public TabControl3Column()
        {
            InitializeComponent();
        }
        public void SetTabVisble(int number)
        {
            tab1Selected.IsVisible = false;
            tab2Selected.IsVisible = false;
            tab3Selected.IsVisible = false;

            if (number == 1)
            {
                tab1Selected.IsVisible = true;
            }
            else if (number == 2)
            {
                tab2Selected.IsVisible = true;
            }
            else
                tab3Selected.IsVisible = true;

        }

        public void SetTabText(string tab1text, string tab2text, string tab3text)
        {
            Tab1.Text = tab1text;
            Tab2.Text = tab2text;
            Tab3.Text = tab3text;
        }

        public void SetSearchVisible(bool val)
        {
            Searcher.IsVisible = val;
        }

    }
}
