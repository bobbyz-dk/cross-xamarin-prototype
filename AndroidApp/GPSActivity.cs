using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using CommonLibrary.location;
using CommonLibrary.location.impl;
using Cirrious.MvvmCross.Plugins.Messenger;

namespace AndroidApp
{
	[Activity(Label = "GPSActivity", MainLauncher = true, Icon = "@drawable/icon")]
	public class GPSActivity : Activity
	{
		private Button btnShow;
		private TextView lblLongitude;
		private TextView lblLatitude;

		private IMvxMessenger _messenger;
		private MvxSubscriptionToken _token;
		private ILocationApi location;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Set our view from the "GPS" layout resource
			SetContentView(Resource.Layout.GPS);

			// Create your application here
			btnShow = (Button)FindViewById(Resource.Id.btnShowLocation);
			lblLongitude = FindViewById<TextView>(Resource.Id.lblLongitude);
			lblLatitude = FindViewById<TextView>(Resource.Id.lblLatitude);

			btnShow.Click += delegate { getLocation(); };

			_messenger = new MvxMessengerHub();
			_token = _messenger.Subscribe<LocationReceivedEvent>(OnLocationReceived);
			location = new LocationApi(_messenger);
		}

		private void OnLocationReceived(LocationReceivedEvent obj)
		{
			lblLongitude.Text = obj.Longitude.ToString();
			lblLatitude.Text = obj.Latitude.ToString();
		}

		private void getLocation()
		{
			location.GetLocation();
        }
	}
}