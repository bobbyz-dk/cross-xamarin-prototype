using Cirrious.MvvmCross.Plugins.Messenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.location.impl
{
	public class LocationReceivedEvent : MvxMessage
	{
		private double longitude;
		private double latitude;
		public double Longitude
		{
			get
			{
				return longitude;
			}
			set
			{
				longitude = value;
			}
		}

		public double Latitude
		{
			get
			{
				return latitude;
			}
			set
			{
				latitude = value;
			}
		}

		public LocationReceivedEvent(object sender, double longitude, double latitude) : base(sender)
		{
			Longitude = longitude;
			Latitude = latitude;
		}
	}
}
