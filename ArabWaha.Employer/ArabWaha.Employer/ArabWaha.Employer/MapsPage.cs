using System;

using Xamarin.Forms;

namespace ArabWaha.Employer
{
    public class MapsPage : ContentPage
    {
        public MapsPage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

