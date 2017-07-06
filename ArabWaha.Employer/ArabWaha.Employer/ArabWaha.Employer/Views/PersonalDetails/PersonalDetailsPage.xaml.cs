using System;
using ArabWaha.Employer.BaseCalsses;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Threading.Tasks;
using MapsPCL;
using ArabWaha.Employer.ViewModels;
using System.Diagnostics;
using System.ComponentModel;

namespace ArabWaha.Employer.Views
{
	public partial class PersonalDetailsPage : AWMenuContainerPage
	{
		public PersonalDetailsPage()
		{
			InitializeComponent();

			((PersonalDetailsViewModel)BindingContext).PropertyChanged += locationChanged;

		}

		private void locationChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "LocationChange")
			{
				try
				{
					var vm = (PersonalDetailsViewModel)this.BindingContext;
					var lattitude = vm.PersonalDetails.latitude;
					var longitude = vm.PersonalDetails.longitude;

					MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(Convert.ToDouble(lattitude), Convert.ToDouble(longitude)), Distance.FromMiles(1)));

					var pin = new Pin()
					{
						Position = new Position(Convert.ToDouble(lattitude), Convert.ToDouble(longitude)),
						Label = string.Empty
					};
					MyMap.Pins.Add(pin);
				}


				catch (Exception ex)
				{
					Debug.WriteLine(ex.Message);
				}
			}
		}
	}
}
