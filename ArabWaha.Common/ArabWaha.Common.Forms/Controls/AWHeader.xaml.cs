using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ArabWaha.Common.Forms.Controls
{
    public partial class AWHeader : ContentView
    {
        public AWHeader()
        {
            ShowLogo = true;
            //ShowImg = false;
            ShowLabel = false;
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }

        #region NavigationText (Bindable String)
        public static readonly BindableProperty NavigationTextProperty = BindableProperty.Create(
                                                                nameof(NavigationText), //Public name to use
                                                                typeof(string), //this type
                                                                typeof(AWHeader), //parent type (tihs control)
                                                                string.Empty); //default value
        public string NavigationText
        {
            get { return (string)GetValue(NavigationTextProperty); }
            set { SetValue(NavigationTextProperty, value); }
        }
        #endregion

        #region NavigationCommand (Bindable Command)
        public static readonly BindableProperty NavigationCommandProperty = BindableProperty.Create(
                                                                  nameof(NavigationCommand), //Public name to use
                                                                  typeof(ICommand), //this type
                                                                  typeof(AWHeader), //parent type (tihs control)
                                                                  null); //default value
        public ICommand NavigationCommand
        {
            get { return (ICommand)GetValue(NavigationCommandProperty); }
            set { SetValue(NavigationCommandProperty, value); }
        }
        #endregion NavigationCommand (Bindable Command)

        #region NavigationParameter (Bindable CommandParameter)
        public static readonly BindableProperty NavigationParameterProperty = BindableProperty.Create(
                                                                  nameof(NavigationParameter), //Public name to use
                                                                  typeof(object), //this type
                                                                  typeof(AWHeader), //parent type (tihs control)
                                                                  null); //default value
        public object NavigationParameter
        {
            get { return (object)GetValue(NavigationCommandProperty); }
            set { SetValue(NavigationCommandProperty, value); }
        }
        #endregion NavigationParameter (Bindable CommandParameter)

        #region MenuCommand (Bindable Command)
        public static readonly BindableProperty MenuCommandProperty = BindableProperty.Create(
                                                                  nameof(MenuCommand), //Public name to use
                                                                  typeof(ICommand), //this type
                                                                  typeof(AWHeader), //parent type (tihs control)
                                                                  null); //default value
        public ICommand MenuCommand
        {
            get { return (ICommand)GetValue(MenuCommandProperty); }
            set { SetValue(MenuCommandProperty, value); }
        }
        #endregion MenuCommand (Bindable Command)

        #region LeftToRight (Bindable bool)
        public static readonly BindableProperty LeftToRightProperty = BindableProperty.Create(
                                                                nameof(RightToLeft), //Public name to use
                                                                typeof(bool), //this type
                                                                typeof(AWHeader), //parent type (tihs control)
                                                                true); //default value
        public bool RightToLeft
        {
            get { return (bool)GetValue(LeftToRightProperty); }
            set { SetValue(LeftToRightProperty, value); }
        }
        #endregion NavigationText (Bindable bool)

        #region ShowLogo (Bindable bool)
        public static readonly BindableProperty ShowLogoProperty = BindableProperty.Create(
                                                                nameof(ShowLogo), //Public name to use
                                                                typeof(bool), //this type
                                                                typeof(AWHeader), //parent type (tihs control)
                                                                true); //default value
        public bool ShowLogo
        {
            get { return (bool)GetValue(ShowLogoProperty); }
            set { SetValue(ShowLogoProperty, value); }
        }
        #endregion ShowLogo (Bindable bool)



        //#region ShowImg (Bindable bool)
        //public static readonly BindableProperty ShowImgProperty = BindableProperty.Create(
        //                                                              nameof(ShowImg), //Public name to use
        //                                                              typeof(bool), //this type
        //                                                              typeof(AWHeader), //parent type (tihs control)
        //                                                              false); //default value
        //      public bool ShowImg
        //{
        //	get { return (bool)GetValue(ShowImgProperty); }
        //	set { SetValue(ShowImgProperty, value); }
        //}
        //#endregion ShowLogo (Bindable bool)


        #region ShowLabel (Bindable bool)
        public static readonly BindableProperty ShowLabelProperty = BindableProperty.Create(
                                                                nameof(ShowLabel), //Public name to use
                                                                typeof(bool), //this type
                                                                typeof(AWHeader), //parent type (tihs control)
                                                                false); //default value
        public bool ShowLabel
        {
            get { return (bool)GetValue(ShowLabelProperty); }
            set { SetValue(ShowLabelProperty, value); }
        }
        #endregion ShowLogo (Bindable bool)




        #region Title (Bindable text)
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
                                                                        nameof(Title),
                                                                       typeof(string),
                                                                     typeof(AWHeader),
                                                                       string.Empty);

        public string Title
		{
            get { return (string)GetValue(TitleProperty); }
			set { SetValue(TitleProperty, value); }
		}
		#endregion
	}
}
