using Cirrious.MvvmCross.Plugins.Messenger;
using CommonLibrary.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.rest.impl
{
	public class CommentsReceivedEvent : MvxMessage
	{
		private List<Comment> comments;
		public List<Comment> Comments
		{
			get
			{
				return comments;
			}
			set
			{
				comments = value;
			}
		}

		public CommentsReceivedEvent(object sender, List<Comment> comments) : base(sender)
		{
			Comments = comments;
		}
	}
}
