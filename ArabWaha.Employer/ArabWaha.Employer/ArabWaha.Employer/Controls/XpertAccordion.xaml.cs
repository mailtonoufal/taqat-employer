using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ArabWaha.Employer.Controls
{
    public partial class XpertAccordion : StackLayout
    {
        Label _ExpandedText;
        StackLayout _StackContents;
        Image _image;
        Label _TextHeader;
        ContentView _AccordionContents;

        public XpertAccordion()
        {
            try {
                InitializeComponent();

                _StackContents = this.FindByName<StackLayout>("ShowContents");
                _ExpandedText = this.FindByName<Label>("TextExpanded");
                _image = this.FindByName<Image>("IconImage");
                _TextHeader = this.FindByName<Label>("TextHeader");
                _AccordionContents = this.FindByName<ContentView>("AccContents");
            }
            catch(Exception ex)
            {
                var t = ex.Message;
            }
        }

        // need to use a bindable prop to stop crashed in viewcell
        public static readonly BindableProperty HeaderTextProperty = BindableProperty.Create(nameof(HeaderText), typeof(string), typeof(XpertAccordion));

        public string HeaderText
        {
            get
            {
                return (string)GetValue(HeaderTextProperty);
            }
            set
            {
                SetValue(HeaderTextProperty, value);
                _TextHeader.Text = value;
            }
        }



        public StackLayout AccordionContents
        {
            set
            {
                _AccordionContents.Content = value;
            }
        }

        //public string HeaderText
        //{
        //    set
        //    {
        //        _TextHeader.Text = value;
        //    }
        //}
        public FileImageSource AccordionImage
        {
            set
            {
                this._image.Source = value;
            }
        }

        private bool _isExpanded;
        public bool AccordionIsExpanded
        {
            set
            {
                _isExpanded = value;

                // ShowContents
                _StackContents.IsVisible = value;
                _ExpandedText.Text = value ? "-" : "+";

            }
        }

        private void Accordion_Tapped(object sender, EventArgs e)
        {
            AccordionIsExpanded = !_isExpanded;
        }



    }
}
