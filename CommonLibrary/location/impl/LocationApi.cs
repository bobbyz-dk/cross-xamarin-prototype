using Cirrious.CrossCore;
using Cirrious.MvvmCross.Plugins.Location;
using Cirrious.MvvmCross.Plugins.Messenger;
using CommonLibrary.location.impl;
using Geolocator.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.location.impl
{
	public class LocationApi : ILocationApi
	{
		private IMvxMessenger _messenger;

		public LocationApi(IMvxMessenger messenger)
		{
			_messenger = messenger;
		}

		public async void GetLocation()
		{
			var locator = CrossGeolocator.Current;
			locator.DesiredAccuracy = 50;

			var location = await locator.GetPositionAsync(timeout: 10000);

			var locationEvent = new LocationReceivedEvent(this,
											  location.Latitude,
											  location.Longitude
				);

			_messenger.Publish(locationEvent);
		}

		private void OnError(MvxLocationError error)
		{
			Mvx.Error("Seen location error {0}", error.Code);
		}
	}
}
