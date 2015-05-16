
using System;
using System.Drawing;

using Foundation;
using UIKit;
using Cirrious.MvvmCross.Plugins.Messenger;
using CommonLibrary.twitter;
using CommonLibrary.twitter.impl;

namespace iPhoneApp
{
	public partial class TwitterViewController : UIViewController
	{
		private MvxSubscriptionToken _token;
		private IMvxMessenger _messenger;
		private ITwitterApi twitter;

		static bool UserInterfaceIdiomIsPhone
		{
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public TwitterViewController(IntPtr handle) : base(handle)
		{
		}

		public override void DidReceiveMemoryWarning()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning();

			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			// Perform any additional setup after loading the view, typically from a nib.
			_messenger = new MvxMessengerHub();
			twitter = new TwitterApi(_messenger);
			_token = _messenger.Subscribe<LastTweetLoadedEvent>(OnLastTweetLoaded);

			this.txtScreenName.ShouldReturn += (textField) =>
			{
				textField.ResignFirstResponder();
				return true;
			};
		}

		private void OnLastTweetLoaded(LastTweetLoadedEvent obj)
		{
			lblResult.Text = obj.Tweet;
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			btnName.TouchUpInside += (sender, e) => {
				_messenger.Publish<LoadLastTweetEvent>(new LoadLastTweetEvent(this, txtScreenName.Text));
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