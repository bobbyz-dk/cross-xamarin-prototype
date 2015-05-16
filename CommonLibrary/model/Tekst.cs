using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;

namespace CommonLibrary.model
{
	public class Tekst : object
	{

		public Tekst(int id, string t)
		{
			this.id = id;
			this.text = t;
		}

		public int id { get; set; }
		public string text { get; set; }

		public override string ToString()
		{
			return this.text;
		}
	}
}
