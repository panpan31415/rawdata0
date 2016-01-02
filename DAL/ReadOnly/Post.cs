using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL
{
	public class Post:IIdentityField
	{
		public int OwnerId { get; set; }
		public int Id { get; set; }
		public string CreationDate { get; set; }
		public int Score { get; set; }
		public string Body { get; set; }
		
	}
}