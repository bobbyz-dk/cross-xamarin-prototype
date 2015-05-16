using Cirrious.MvvmCross.Plugins.Messenger;
using CommonLibrary.model;
using CommonLibrary.rest;
using CommonLibrary.rest.impl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
	public sealed partial class Rest : Page
	{
		private MvxSubscriptionToken _token1;
		private MvxSubscriptionToken _token2;
		private IMvxMessenger _messenger;
		private IRestApi twitter;

		public Rest()
		{
			this.InitializeComponent();

			_messenger = new MvxMessengerHub();
			twitter = new RestApi(_messenger);
			_token1 = _messenger.Subscribe<CommentPostedEvent>(OnCommentPosted);
			_token2 = _messenger.Subscribe<CommentsReceivedEvent>(OnCommentsReceived);
		}

		private void OnCommentsReceived(CommentsReceivedEvent obj)
		{
			lvComments.ItemsSource = obj.Comments;
		}

		private async void OnCommentPosted(CommentPostedEvent obj)
		{
			MessageDialog msgbox = new MessageDialog("Comment Posted","Posted");
			await msgbox.ShowAsync();
		}


		/// <summary>
		/// Invoked when this page is about to be displayed in a Frame.
		/// </summary>
		/// <param name="e">Event data that describes how this page was reached.
		/// This parameter is typically used to configure the page.</param>
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
		}

		private void btnPost_Click(object sender, RoutedEventArgs e)
		{
			_messenger.Publish<PostCommentEvent>(new PostCommentEvent(this, new Comment(txtComment.Text, txtEmail.Text)));
		}

		private void btnGet_Click(object sender, RoutedEventArgs e)
		{
			_messenger.Publish<GetCommentsEvent>(new GetCommentsEvent(this));
		}
	}
}
