using Cirrious.MvvmCross.Plugins.Messenger;
using CommonLibrary.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.rest.impl
{
	public class PostCommentEvent : MvxMessage
	{
		private Comment comment;
		public Comment Comment
		{
			get
			{
				return comment;
			}
			set
			{
				comment = value;
			}
		}

		public PostCommentEvent(object sender, Comment comment) : base(sender)
		{
			Comment = comment;
		}
	}
}
