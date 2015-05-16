using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CommonLibrary.model
{
	public class Comment : object
	{

		public Comment(string text, string email)
		{
			this.Text = text;
			this.Email = email;
			this.Created = DateTime.Now.ToString();
		}
		public string Text { get; set; }
		public string Email { get; set; }
		public string Created { get; set; }

		public override string ToString()
		{
			return this.Text + " (" + Created + ")";
		}

		public string ToJSON()
		{
			var settings = new JsonSerializerSettings();
			settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            string json = JsonConvert.SerializeObject(this, Formatting.Indented, settings);
			return json;
        }

		public static List<Comment> JSONToList(string json)
		{
			return JsonConvert.DeserializeObject<Comment[]>(json).ToList<Comment>();
		}
	}
}
