﻿using System;
using CoreLocation;
using MapsPCL;
using MyLocationSample.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(GetMyLocation))]
namespace MyLocationSample.iOS
{
	public class LocationEventArgs : EventArgs, ILocationEventArgs
	{
		public double lat { get; set; }
		public double lng { get; set; }
	}
	public class GetMyLocation : ILocation
	{
		public event EventHandler<ILocationEventArgs> locationObtained;

		public void ObtainMyLocation()
		{
			try
			{
				CLLocationManager lm = new CLLocationManager();
				lm.DesiredAccuracy = CLLocation.AccuracyBest;
				lm.DistanceFilter = CLLocationDistance.FilterNone;

				lm.LocationsUpdated += (object sender, CLLocationsUpdatedEventArgs e) =>
					 {
						 CLLocation[] locations = e.Locations;
						 string strLocation = locations[locations.Length - 1].Coordinate.Latitude.ToString();
						 strLocation = strLocation + "," + locations[locations.Length - 1].Coordinate.Longitude.ToString();
						 LocationEventArgs args = new LocationEventArgs();
						 args.lat = locations[locations.Length - 1].Coordinate.Latitude;
						 args.lng = locations[locations.Length - 1].Coordinate.Longitude;
						 locationObtained(this, args);
					 };
				lm.AuthorizationChanged += (object sender, CLAuthorizationChangedEventArgs e) =>
				{
					if (e.Status == CLAuthorizationStatus.AuthorizedWhenInUse)
					{
						lm.StartUpdatingLocation();
					}
				};
				lm.RequestWhenInUseAuthorization();

			}
			catch (Exception ex)
			{

			}


		}
	}
}

