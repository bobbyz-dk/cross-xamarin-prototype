using Cirrious.MvvmCross.Plugins.Messenger;
using CommonLibrary.twitter;
using CommonLibrary.twitter.impl;
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
	public sealed partial class Twitter : Page
	{
		private MvxSubscriptionToken _token;
		private IMvxMessenger _messenger;
		private ITwitterApi twitter;

		public Twitter()
		{
			this.InitializeComponent();

			_messenger = new MvxMessengerHub();
			twitter = new TwitterApi(_messenger);
			_token = _messenger.Subscribe<LastTweetLoadedEvent>(OnLastTweetLoaded);
		}

		private void OnLastTweetLoaded(LastTweetLoadedEvent obj)
		{
			lblResult.Text = obj.Tweet;
		}


		/// <summary>
		/// Invoked when this page is about to be displayed in a Frame.
		/// </summary>
		/// <param name="e">Event data that describes how this page was reached.
		/// This parameter is typically used to configure the page.</param>
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
		}

		private void btnRetrieveTweet_Click(object sender, RoutedEventArgs e)
		{
			_messenger.Publish<LoadLastTweetEvent>(new LoadLastTweetEvent(this, txtScreenName.Text));
		}
	}
}
