using System;
using System.Collections.Generic;
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
            InitializeComponent();
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
                                                                nameof(LeftToRight), //Public name to use
                                                                typeof(bool), //this type
                                                                typeof(AWHeader), //parent type (tihs control)
                                                                true); //default value
        public bool LeftToRight
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
    }
}