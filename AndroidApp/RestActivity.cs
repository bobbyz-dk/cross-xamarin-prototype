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
using CommonLibrary.model;
using Cirrious.MvvmCross.Plugins.Messenger;
using CommonLibrary.rest;
using CommonLibrary.rest.impl;

namespace AndroidApp
{
	[Activity(Label = "RestActivity"/*, MainLauncher = true, Icon = "@drawable/icon" */)]
	public class RestActivity : Activity
	{
		private MvxSubscriptionToken _token1;
		private MvxSubscriptionToken _token2;
		private IMvxMessenger _messenger;
		private IRestApi rest;

		EditText txtComment;
		EditText txtEmail;
		Button btnPost;
		Button btnGet;
		ListView lvComments;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Set our view from the "Rest" layout resource
			SetContentView(Resource.Layout.Rest);

			_messenger = new MvxMessengerHub();
			rest = new RestApi(_messenger);
			_token1 = _messenger.Subscribe<CommentPostedEvent>(OnCommentPosted);
			_token2 = _messenger.Subscribe<CommentsReceivedEvent>(OnCommentsReceived);

			// Create your application here
			txtComment = FindViewById<EditText>(Resource.Id.txtComment);
			txtEmail = FindViewById<EditText>(Resource.Id.txtEmail);
			btnPost = (Button)FindViewById(Resource.Id.btnPost);
			btnGet = (Button)FindViewById(Resource.Id.btnGet);
			lvComments = (ListView)FindViewById(Resource.Id.lvComments);

			btnPost.Click += delegate { postComment(new Comment(txtComment.Text, txtEmail.Text)); };
			btnGet.Click += delegate { getComments(); };
		}

		private void OnCommentsReceived(CommentsReceivedEvent obj)
		{
			// use the SimpleCursorAdapter to show the elements in a ListView
			ArrayAdapter<Comment> adapter = new ArrayAdapter<Comment>(this, Android.Resource.Layout.SimpleListItem1, obj.Comments);
			lvComments.Adapter = adapter;
		}

		private void getComments()
		{
			_messenger.Publish<GetCommentsEvent>(new GetCommentsEvent(this));
		}

		private void OnCommentPosted(CommentPostedEvent obj)
		{
			new AlertDialog.Builder(this)
				.SetTitle("Posted")
				.SetMessage("Comment posted")
				.SetNegativeButton("OK", (sender, args) =>
				{})
                .Show();
		}

		private void postComment(Comment comment)
		{
			_messenger.Publish<PostCommentEvent>(new PostCommentEvent(this, comment));
		}

		
	}
}