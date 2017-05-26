using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ArabWaha.Common.Forms.Controls
{
    public partial class AWAccordion : ContentView
    {
        Label _ExpandedText;
        StackLayout _StackContents;
        Image _image;
        Label _TextHeader;
        ContentView _AccordionContents;

        public AWAccordion()
        {
            try
            {
                InitializeComponent();

                _StackContents = this.FindByName<StackLayout>("ShowContents");
                _ExpandedText = this.FindByName<Label>("TextExpanded");
                _image = this.FindByName<Image>("IconImage");
                _TextHeader = this.FindByName<Label>("TextHeader");
                _AccordionContents = this.FindByName<ContentView>("AccContents");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR:" + ex.Message);
            }
        }



        #region HeaderText (Bindable String)
        public static readonly BindableProperty HeaderTextProperty = BindableProperty.Create(
                                                                nameof(HeaderText), //Public name to use
                                                                typeof(string), //this type
                                                                typeof(AWAccordion), //parent type (tihs control)
                                                                string.Empty); //default value
        public string HeaderText
        {
            get { return (string)GetValue(HeaderTextProperty); }
            set { SetValue(HeaderTextProperty, value); }
        }
        #endregion

        // Need to add the properties to display Left-Right/Right-Left options.





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