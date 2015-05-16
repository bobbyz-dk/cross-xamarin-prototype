using Cirrious.MvvmCross.Plugins.Messenger;
using CommonLibrary.location;
using CommonLibrary.location.impl;
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace iPhoneApp
{
	partial class GPSViewcontroller : UIViewController
	{
		private IMvxMessenger _messenger;
		private MvxSubscriptionToken _token;
		private ILocationApi location;

		public GPSViewcontroller (IntPtr handle) : base (handle)
		{
		}

		#region View lifecycle

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			// Perform any additional setup after loading the view, typically from a nib.
			_messenger = new MvxMessengerHub();
			_token = _messenger.Subscribe<LocationReceivedEvent>(OnLocationReceived);
			location = new LocationApi(_messenger);
		}

		private void OnLocationReceived(LocationReceivedEvent obj)
		{
			lblLongitude.Text = obj.Longitude.ToString();
			lblLatitude.Text = obj.Latitude.ToString();
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			btnShowLocation.TouchUpInside += (sender, e) => {
				location.GetLocation();
			};
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
		}

		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);
		}

		public override void ViewDidDisappear(bool animated)
		{
			base.ViewDidDisappear(animated);
		}

		#endregion
	}
}
