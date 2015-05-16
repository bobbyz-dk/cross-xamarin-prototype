using Cirrious.MvvmCross.Plugins.Messenger;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Core.Interfaces;

namespace CommonLibrary.twitter.impl
{
	public class TwitterApi : ITwitterApi
	{
		private readonly MvxSubscriptionToken _token;
		private IMvxMessenger _messenger;

		public TwitterApi(IMvxMessenger messenger)
		{
			TwitterCredentials.SetCredentials("169152255-zWBbsoyw2FU1RfagmIKsozSkYe3jmboUBtm4ghiX", "6tRjNPLbOuHuGjFIieGriOjqa2kMdQoi5JI2ZWTPBEy47", "goqwJWBRzDjgqyzckBN1zXk7z", "8KfuNwB9aTfBRze1HoAc0vLQeJq6DqBhkwTDMvH8CVx8FFunNX");
			_messenger = messenger;
			_token = _messenger.Subscribe<LoadLastTweetEvent>(OnLoadLastTweet);
		}

		private async void OnLoadLastTweet(LoadLastTweetEvent evnt)
        {
			// Call Twitter
			var user = User.GetUserFromScreenName(evnt.ScreenName);
			var timeline = await user.GetUserTimelineAsync(1);
			_messenger.Publish<LastTweetLoadedEvent>(new LastTweetLoadedEvent(this, timeline.First<ITweet>().Text));
		}
	}
}

