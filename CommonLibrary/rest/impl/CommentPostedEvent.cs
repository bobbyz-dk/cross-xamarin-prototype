﻿using Cirrious.MvvmCross.Plugins.Messenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.rest.impl
{
	public class CommentPostedEvent : MvxMessage
	{
		public CommentPostedEvent(object sender) : base(sender)
		{
		}
	}
}
