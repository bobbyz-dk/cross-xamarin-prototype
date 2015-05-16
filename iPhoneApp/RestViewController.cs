using System;
using System.Drawing;

using Foundation;
using UIKit;

using CommonLibrary;
using System.IO;
using System.Collections.Generic;
using CommonLibrary.model;
using Cirrious.MvvmCross.Plugins.Messenger;
using CommonLibrary.rest.impl;
using CommonLibrary.rest;

namespace iPhoneApp
{
	public partial class RestViewController : UIViewController
	{
		private MvxSubscriptionToken _token1;
		private MvxSubscriptionToken _token2;
		private IMvxMessenger _messenger;
		private IRestApi rest;

		public RestViewController(IntPtr handle) : base(handle)
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
			rest = new RestApi(_messenger);
			_token1 = _messenger.Subscribe<CommentPostedEvent>(OnCommentPostedEvent);
			_token2 = _messenger.Subscribe<CommentsReceivedEvent>(OnCommentsReceivedEvent);
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			btnPost.TouchUpInside += (sender, e) => {
				_messenger.Publish<PostCommentEvent>(new PostCommentEvent(this, new Comment(txtComment.Text, txtEmail.Text)));
			};
			btnGet.TouchUpInside += (sender, e) => {
				_messenger.Publish<GetCommentsEvent>(new GetCommentsEvent(this));
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

		private void OnCommentPostedEvent(CommentPostedEvent obj)
		{
			var okAlertController = UIAlertController.Create("Posted", "Comment posted", UIAlertControllerStyle.Alert);
			okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
			PresentViewController(okAlertController, true, null);
		}

		private void OnCommentsReceivedEvent(CommentsReceivedEvent obj)
		{
			tblComments.Source = new CommentTableSource(obj.Comments);
			tblComments.ReloadData();
		}
	}
}