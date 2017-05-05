using ArabWaha.Employer.BaseCalsses;
using ArabWaha.Employer.Helpers;
using ArabWaha.Employer.ViewModels;
using ArabWaha.Employer.Views.Menus;
using Prism.Navigation;
using SlideOverKit;
using System;
using Xamarin.Forms;

namespace ArabWaha.Employer.Views
{
    public partial class SearchResultsPage : AWMenuContainerPage
    {
        public SearchResultsPage()
        {
            InitializeComponent();

            AddFilterMenu();
        }

        private void AddFilterMenu()
        {
            // should only be shown when we've got results. (use a message)
            var tbarItem = new ToolbarItem()
            {
                Text = TranslateExtension.GetString("LabelFilter"),
                Command = (this.BindingContext as SearchResultsPageViewModel).FilterCommand                
            };
            this.ToolbarItems.Add(tbarItem);
        }


    }
}
