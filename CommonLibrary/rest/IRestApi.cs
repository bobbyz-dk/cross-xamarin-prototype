using CommonLibrary.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.rest
{
	public interface IRestApi
	{
		Task postComment(Comment comment);
		Task<string> getComments();
	}
}
