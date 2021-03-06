﻿using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

using System.Threading.Tasks;

namespace MapsPCL
{

	public partial class MapsPCLPage : ContentPage
	{
		double lat;
		double lng;

		public MapsPCLPage()
		{
			try
			{
				InitializeComponent();
			}
			catch (System.Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
			//         MyMap.MoveToRegion(new MapSpan(new Position(17.456508, 78.412616), 0.09, 0.09));

			//         var pin = new Pin()
			//         {
			//             Position = new Position(17.456508, 78.412616),
			//             Label = string.Empty
			//};
			//MyMap.Pins.Add(pin);

			ILocation loc = DependencyService.Get<ILocation>();
			loc.locationObtained += (object ss, ILocationEventArgs ee) =>
														   {
															   lat = ee.lat;
															   lng = ee.lng;
															   Position position = new Position(lat, lng);
															   Pin pin = new Pin
															   {
																   Type = PinType.Place,
																   Position = position,
																   Label = string.Empty,
															   };
															   MyMap.Pins.Add(pin);
															   //MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(lat, lng), Distance.FromMiles(10)));
															   MyMap.MoveToRegion(new MapSpan(new Position(lat, lng), 0.09, 0.09));


														   };
			loc.ObtainMyLocation();
			//loc = null;

			//             //await Task.Delay(4000);

			//         

		}
	}
}
