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
using Cirrious.MvvmCross.Plugins.Messenger;
using CommonLibrary.twitter;
using CommonLibrary.twitter.impl;

namespace AndroidApp
{
	[Activity(Label = "TwitterActivity"/*, MainLauncher = true, Icon = "@drawable/icon" */)]
	public class TwitterActivity : Activity
	{
		private MvxSubscriptionToken _token;
		private IMvxMessenger _messenger;
		private ITwitterApi twitter;

		EditText txtScreenName;
		Button btnRetrieveTweet;
		TextView lblResult;
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			SetContentView(Resource.Layout.Rest);

			_messenger = new MvxMessengerHub();
			twitter = new TwitterApi(_messenger);
			_token = _messenger.Subscribe<LastTweetLoadedEvent>(OnLastTweetLoaded);

			txtScreenName = FindViewById<EditText>(Resource.Id.txtScreenName);
			btnRetrieveTweet = (Button)FindViewById(Resource.Id.btnRetrieveTweet);
			lblResult = (TextView)FindViewById(Resource.Id.lblResult);

			btnRetrieveTweet.Click += delegate { lastTweet(txtScreenName.Text); };
		}

		private void lastTweet(string screenName)
		{
			_messenger.Publish<LoadLastTweetEvent>(new LoadLastTweetEvent(this, screenName));
		}

		private void OnLastTweetLoaded(LastTweetLoadedEvent evnt)
		{
			lblResult.Text = evnt.Tweet;
        }
	}
}