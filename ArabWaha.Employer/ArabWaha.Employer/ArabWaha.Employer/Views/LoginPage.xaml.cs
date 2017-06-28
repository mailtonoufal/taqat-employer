using System;
using Xamarin.Forms;

namespace ArabWaha.Employer.Views
{
    public partial class LoginPage : ContentPage
    {
       
        public LoginPage()
        {
			InitializeComponent();
			//var btn = new Button
			//{
			//	Image = "Saned.png",
			//	HorizontalOptions = LayoutOptions.Start,
   //             HeightRequest=10,
   //             WidthRequest=10
			//};
			btn.Clicked += btn_Clicked;
			void btn_Clicked(object sender, EventArgs e)
			{
				this.Navigation.PushAsync(new StartPage());
			}
			
           
			
		}
		


       
       
    }



	
	
}
