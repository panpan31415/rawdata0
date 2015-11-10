using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace portfolio2gr4.Models
{
	public class UserModel
	{
		public string Url { get; set; }
		public string Name { get; set; }
		public string WebsiteUrl { get; set; }
		public DateTime CreationDate { get; set; }
		public int Reputation { get; set; }
		public int Age { get; set; }
		public int UpVotes { get; set; }
		public int DownVotes { get; set; }
		public int LocationId { get; set; }
	}
}