using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL
{
	public class User
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string About { get; set; }
		public string WebsiteUrl{ get; set; }
		public DateTime CreationDate { get; set; }
		public int Reputation { get; set; }
		public int Age { get; set; }
		public int UpVotes { get; set; }
		public int DownVotes { get; set; }
		public int LocationId { get; set; }
	}
}