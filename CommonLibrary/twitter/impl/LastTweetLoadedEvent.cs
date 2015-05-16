using Cirrious.MvvmCross.Plugins.Messenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.twitter.impl
{
	public class LastTweetLoadedEvent : MvxMessage
	{
		private string tweet;
		public string Tweet
		{
			get
			{
				return tweet;
			}
			set
			{
				tweet = value;
			}
		}

		public LastTweetLoadedEvent(object sender, string tweet) : base(sender)
		{
			Tweet = tweet;
		}
	}
}
