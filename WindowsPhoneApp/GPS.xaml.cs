using Cirrious.MvvmCross.Plugins.Messenger;
using CommonLibrary.location;
using CommonLibrary.location.impl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace WindowsPhoneApp
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class GPS : Page
	{
		private IMvxMessenger _messenger;
		private MvxSubscriptionToken _token;
		private ILocationApi location;

		public GPS()
		{
			this.InitializeComponent();

			_messenger = new MvxMessengerHub();
			_token = _messenger.Subscribe<LocationReceivedEvent>(OnLocationReceived);
			location = new LocationApi(_messenger);
		}

		private void OnLocationReceived(LocationReceivedEvent obj)
		{
			lblLongitude.Text = obj.Longitude.ToString();
			lblLatitude.Text = obj.Latitude.ToString();
		}


		/// <summary>
		/// Invoked when this page is about to be displayed in a Frame.
		/// </summary>
		/// <param name="e">Event data that describes how this page was reached.
		/// This parameter is typically used to configure the page.</param>
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
		}

		private void btnShowLocation_Click(object sender, RoutedEventArgs e)
		{
			location.GetLocation();
		}
	}
}
