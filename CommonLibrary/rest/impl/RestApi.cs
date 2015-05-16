using Cirrious.MvvmCross.Plugins.Messenger;
using CommonLibrary.model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.rest.impl
{
	public class RestApi : IRestApi
	{
		private const String baseAddress = "http://192.168.1.103:2403/";
		private const String commentResource = "http://192.168.1.103:2403/comment";
		private readonly MvxSubscriptionToken _token1;
		private readonly MvxSubscriptionToken _token2;
		private IMvxMessenger _messenger;

		public RestApi(IMvxMessenger messenger)
		{
			_messenger = messenger;
			_token1 = _messenger.Subscribe<PostCommentEvent>(OnPostComment);
			_token2 = _messenger.Subscribe<GetCommentsEvent>(OnGetComments);
		}

		private async void OnGetComments(GetCommentsEvent obj)
		{
			// Get comments
			string json = await getComments();
			List<Comment> comments = Comment.JSONToList(json);

			_messenger.Publish<CommentsReceivedEvent>(new CommentsReceivedEvent(this, comments));
		}

		private async void OnPostComment(PostCommentEvent obj)
		{
			// Post comment
			await this.postComment(obj.Comment);

			_messenger.Publish<CommentPostedEvent>(new CommentPostedEvent(this));
		}

		public async Task postComment(Comment comment)
		{
			try
			{
				var client = new HttpClient();
				client.BaseAddress = new Uri(baseAddress);
				client.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/json"));
				Debug.WriteLine(comment.ToJSON());
				HttpContent content = new StringContent(comment.ToJSON(), Encoding.UTF8, "application/json");
                await client.PostAsync("comment", content);
			}
			catch (Exception e)
			{
				Debug.WriteLine(e.StackTrace);
			}
		}

		public async Task<string> getComments()
		{
			try
			{
				HttpClientHandler handler = new HttpClientHandler();
				HttpClient client = new HttpClient(handler);
				client.BaseAddress = new Uri(baseAddress);
				return await client.GetStringAsync("comment"); //return await client.GetStringAsync(commentResource);
			}
			catch (Exception e)
			{
				Debug.WriteLine(e.Message);
				Debug.WriteLine(e.StackTrace);
				return "";
			}
		}
    }

}
