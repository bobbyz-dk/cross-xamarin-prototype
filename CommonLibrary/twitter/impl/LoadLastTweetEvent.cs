using Cirrious.MvvmCross.Plugins.Messenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.twitter.impl
{
	public class LoadLastTweetEvent : MvxMessage
	{
		private string screenName;
		public string ScreenName
		{
			get
			{
				return screenName;
			}
			set
			{
				screenName = value;
			}
		}

		public LoadLastTweetEvent(object sender, string screenName) : base(sender)
		{
			ScreenName = screenName;
		}
	}
}
